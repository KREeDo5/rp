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
    
    [Theory]
    [MemberData(nameof(CorrectInitContactTestData))]
    public void Correct_Init_Contact(Dictionary<string, string?> input, Dictionary<string, string> expected)
    {
        Contact value = new Contact(input["FirstName"]!, input["MiddleName"], input["LastName"]);
        Assert.Equal(expected["FirstName"], value.FirstName);
        Assert.Equal(expected["MiddleName"], value.MiddleName);
        Assert.Equal(expected["LastName"], value.LastName);
        Assert.Empty(value.PhoneNumbers);
        Assert.Null(value.PrimaryPhoneNumber);
    }

    public static TheoryData<Dictionary<string, string?>, Dictionary<string, string>> CorrectInitContactTestData()
    {
        return new TheoryData<Dictionary<string, string?>, Dictionary<string, string>>
        {   
            // Стандартный сценарий
            {
                new Dictionary<string, string?>
                {
                    { "FirstName", "Тюлень" },
                    { "MiddleName", "Тестович" },
                    { "LastName", "Тестовый" }
                },
                new Dictionary<string, string>
                {
                    { "FirstName", "Тюлень" },
                    { "MiddleName", "Тестович" },
                    { "LastName", "Тестовый" }
                }
            },
            // Передали параметры с лишними пробелами
            {
                new Dictionary<string, string?>
                {
                    { "FirstName", "Тюлень  " },
                    { "MiddleName", "  Тестович" },
                    { "LastName", "Тестовый" }
                },
                new Dictionary<string, string>
                {
                    { "FirstName", "Тюлень" },
                    { "MiddleName", "Тестович" },
                    { "LastName", "Тестовый" }
                }
            },
            // Передано только Имя
            {
                new Dictionary<string, string?>
                {
                    { "FirstName", "Иван" },
                    { "MiddleName", null },
                    { "LastName", null }
                },
                new Dictionary<string, string>
                {
                    { "FirstName", "Иван" },
                    { "MiddleName", "" },
                    { "LastName", "" }
                }
            },
            // Пустое отчество и фамилия
            {
                new Dictionary<string, string?>
                {
                    { "FirstName", "Иван" },
                    { "MiddleName", "" },
                    { "LastName", "" }
                },
                new Dictionary<string, string>
                {
                    { "FirstName", "Иван" },
                    { "MiddleName", "" },
                    { "LastName", "" }
                }
            },
        };
    }
}