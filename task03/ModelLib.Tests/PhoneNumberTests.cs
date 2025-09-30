namespace ModelLib.Tests;

public class PhoneNumberTests
{
    // [Fact]
    // public void Init_Correctly()
    // {
    //     Point2D p = new Point2D(1.5, -2.5);
    //     Assert.Equal(1.5, p.X);
    //     Assert.Equal(-2.5, p.Y);
    // }
    
    /// Тест инициализации номера телефона с некорректным номером
    [Theory]
    [MemberData(nameof(ExceptionInitPhoneNumberTestData))]
    public void Cannot_Init_Phone_Number(String text)
    {
        Assert.Throws<ArgumentException>(() => new PhoneNumber(text));
    }

    public static TheoryData<string> ExceptionInitPhoneNumberTestData()
    {
        return new TheoryData<string>
        {
            { "" },
            { " " },
            { "X" },
            { "x" },
            { "xxx" },
            { "1xXx" },
            { "xxx1" },
            { "%" },
            { "12=34" },
            { "+%" },
            { "+X" },
            { "x0-="},
            { "x0-2"},
            { "0-2x"},
        };
    }

    
    [Theory]
    [MemberData(nameof(MainNumberTestData))]
    public void Can_get_main_number(String text, String expected)
    {
        PhoneNumber phoneNumber = new PhoneNumber(text);
        String result = phoneNumber.Number;
        Assert.Equal(expected, result);
    }

    public static TheoryData<String, String> MainNumberTestData()
    {
        return new TheoryData<String, String>
        {
            // Основные сценарии
            { "1234455", "+1234455"},
            { "1234455x2", "+1234455"},
            { "+7 999 888 77 66", "+79998887766"},
            { "+7 999  888   77 66", "+79998887766"},
            // Граничные значения
            { "1", "+1"},
            { "+1-999-555-9999-0000-333", "+199955599990000333"},
        };
    }
    
    [Theory]
    [MemberData(nameof(AdditionalNumberTestData))]
    public void Can_get_additional_number(String text, String expected)
    {
        PhoneNumber phoneNumber = new PhoneNumber(text);
        String result = phoneNumber.Ext;
        Assert.Equal(expected, result);
    }
    public static TheoryData<String, String> AdditionalNumberTestData()
    {
        return new TheoryData<String, String>
        {
            // Основные сценарии
            { "1234455", ""},
            { "1234455x2", "2"},
        };
    }
}