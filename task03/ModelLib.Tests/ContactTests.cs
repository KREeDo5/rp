namespace ModelLib.Tests;

public class ContactTests
{
    /// Тест инициализации контакта телефона с пустым именем
    [Fact]
    public void Cannot_Init_Contact()
    {
        Assert.Throws<ArgumentException>(() => new Contact(""));
        Assert.Throws<ArgumentException>(() => new Contact("    "));
    }
    
    /// Тест инициализации контакта с лишними пробелами
    [Fact]
    public void Correct_Init_Contact()
    {
        Contact value = new Contact("Иван", "Петрович    ", "    Сидоров");
        Assert.Equal("Иван", value.FirstName);
        Assert.Equal("Петрович", value.MiddleName);
        Assert.Equal("Сидоров", value.LastName);
        Assert.Empty(value.PhoneNumbers);
        Assert.Null(value.PrimaryPhoneNumber);
    }
}