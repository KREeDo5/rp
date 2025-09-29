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
            { "1234455x", "+1234455"},
            { "1234455x2", "+1234455"},
            // Пограничные случаи
            { "", "+" }, //TODO: некорректный номер!!!
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
            { "1234455x", ""},
            { "1234455x2", "2"},
        };
    }
}