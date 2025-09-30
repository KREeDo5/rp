namespace ModelLib;

public class Contact
{
    // На основе класса `PhoneNumber` спроектируйте и реализуйте модель `Contact`:
    //
    // 2. Контакт может иметь 0, 1 или несколько номеров телефона
    // - один из номеров всегда помечен как основной (primary), кроме случая, когда нет ни одного номера

    private List<PhoneNumber> _phoneNumbers;

    public Contact(String firstName, String middleName = "", String lastName = "")
    {
        if (String.IsNullOrEmpty(firstName.Trim())) //TODO: проверить на необходимость использования Trim
        {
            throw new ArgumentException("Имя - не может быть пустой строкой", nameof(firstName));
        }

        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        _phoneNumbers = new List<PhoneNumber>();
    }
    
    // Имя - не может быть пустой строкой
    public String FirstName { get; } 
    // Отчество
    public String MiddleName { get; } 
    // Фамилия
    public String LastName { get; }

    //- свойство `List<PhoneNumber> PhoneNumbers` возвращает все номера телефонов
    public List<PhoneNumber> PhoneNumbers => new List<PhoneNumber>(_phoneNumbers); // возврат списка копий


    // Возвращает основной номер телефона
    public PhoneNumber? PrimaryPhoneNumber => _primaryPhoneNumber;
    
    private PhoneNumber? _primaryPhoneNumber;

    // Удаляет номер телефона
    public void RemovePhoneNumber(PhoneNumber value)
    {
    }

    // Добавляет номер телефона либо ничего не делает, если номер уже был
    public void AddPhoneNumber(PhoneNumber value)
    {
        //TODO: проверка по хэшкоду, добавить equals в PhoneNumber
    }

    // Меняет основной номер телефона
    public void SetPrimaryPhoneNumber(PhoneNumber value)
    {
        //TODO: проверить, что номер есть в списке
        _primaryPhoneNumber = value;
    }
}