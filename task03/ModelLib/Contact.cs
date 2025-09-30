namespace ModelLib;

public class Contact
{
    public Contact(String firstName, String middleName = "", String lastName = "")
    {
        if (String.IsNullOrEmpty(firstName.Trim()))
        {
            throw new ArgumentException("Имя - не может быть пустой строкой", nameof(firstName));
        }

        FirstName = firstName.Trim();
        MiddleName = middleName.Trim();
        LastName = lastName.Trim();
        _phoneNumbers = [];
    }

    // Имя - не может быть пустой строкой
    public String FirstName { get; }

    // Отчество
    public String MiddleName { get; }

    // Фамилия
    public String LastName { get; }

    private List<PhoneNumber> _phoneNumbers;

    /// <summary>
    /// Возвращает все номера телефонов.
    /// Номера не могут быть изменены извне так как PhoneNumber - неизменяемый класс.
    /// Список номеров не может быть изменён извне, так как возвращается IReadOnlyList.
    /// </summary>
    public IReadOnlyList<PhoneNumber> PhoneNumbers => _phoneNumbers;


    /// <summary>
    /// Возвращает основной номер телефона
    /// </summary>
    public PhoneNumber? PrimaryPhoneNumber => _primaryPhoneNumber;

    private PhoneNumber? _primaryPhoneNumber;

    /// <summary>
    /// Удаляет номер телефона
    /// </summary>
    public void RemovePhoneNumber(PhoneNumber value)
    {   
        ArgumentNullException.ThrowIfNull(value);
        // Правило было отключено так как метод по ТЗ ничего не должен возвращать, а предупреждение CA1868 - рекомендует возвращать логическое значение
#pragma warning disable CA1868
        if (_phoneNumbers.Contains(value))
#pragma warning restore CA1868
        {
            _phoneNumbers.Remove(value);
        }
    }

    /// <summary>
    /// Добавляет номер телефона либо ничего не делает, если номер уже был
    /// </summary>
    public void AddPhoneNumber(PhoneNumber value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (_phoneNumbers.Contains(value))
        {
            return;
        }
        //TODO:  один из номеров всегда помечен как основной (primary), кроме случая, когда нет ни одного номера
        _phoneNumbers.Add(value);
    }

    /// <summary>
    /// Меняет основной номер телефона
    /// </summary>
    public void SetPrimaryPhoneNumber(PhoneNumber value)
    {   
        ArgumentNullException.ThrowIfNull(value);
        
        if (!_phoneNumbers.Contains(value))
        {
            AddPhoneNumber(value);
        }
        //TODO:  один из номеров всегда помечен как основной (primary), кроме случая, когда нет ни одного номера
        _primaryPhoneNumber = value;
    }
}