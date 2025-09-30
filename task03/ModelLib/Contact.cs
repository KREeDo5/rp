namespace ModelLib;

public class Contact
{
    // На основе класса `PhoneNumber` спроектируйте и реализуйте модель `Contact`:
    //
    // 2. Контакт может иметь 0, 1 или несколько номеров телефона
    // - один из номеров всегда помечен как основной (primary), кроме случая, когда нет ни одного номера

    //Контакт имеет свойства `string FirstName`, `string MiddleName` и `string LastName`
    string FirstName; // Имя - не может быть пустой строкой
    string MiddleName; // Отчество
    string LastName; // Фамилия

    //- свойство `List<PhoneNumber> PhoneNumbers` возвращает все номера телефонов
    public List<PhoneNumber> PhoneNumbers => new List<PhoneNumber>(_phoneNumbers); // возврат списка копий


    // - свойство `PhoneNumber? PrimaryPhoneNumber` возвращает основной номер телефона
    public PhoneNumber? PrimaryPhoneNumber => _primaryPhoneNumber;

    // Удаляет номер телефона
    public void RemovePhoneNumber(PhoneNumber value)
    {
    }
    
    // Добавляет номер телефона либо ничего не делает, если номер уже был
    public void AddPhoneNumber(PhoneNumber value)
    {
    }
    
    // Меняет основной номер телефона
    public void SetPrimaryPhoneNumber(PhoneNumber value)
    {
    }
}