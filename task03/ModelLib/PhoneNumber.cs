using System.Text.RegularExpressions;

namespace ModelLib;

/// <summary>
/// Представляет телефонный номер в международном формате.
/// </summary>
public class PhoneNumber
{
    //     Метод ToString(), возвращающий строку номера телефона с символом + в начале
    // Пример: +78362450272 — когда нет добавочного номера
    // Пример: +12345678901x1234 — когда есть добавочный номер
    
    
    
    public PhoneNumber(string text)
    {   
        // Допускаются номера с символом + в начале и без него, например:
        // +7 (8362) 45-02-72 → номер +78362450272
        // 7 (8362) 45-02-72 → номер +78362450272
        // 8 (8362) 45-02-72 → номер +88362450272
        // Допускаются номера с добавочным (внутренним) номером после x, например:
        // 1-234-567-8901 x1234 → номер +12345678901, добавочный 1234
        text = NormalizeText(text);
        if (text.Length == 0)
        {
            throw new ArgumentException("Номер телефона не может быть пустым", nameof(text));
        }
        if (!IsValidFormat(text))
        {
            throw new ArgumentException("Недопустимый формат. Разрешены только цифры и один разделитель между ними.", nameof(text));
        }
        
        // сохраняет отдельно основной номер и добавочный номер
        string[] parts = text.Split(Separator, 2);
        if (parts[0] == "")
        {
            throw new ArgumentException("Номер телефона не может быть пустым", nameof(text));
        }
        MainNumber = int.Parse(parts[0]);
        
        if (parts[1] != "")
        {
            AdditionalNumber = int.Parse(parts[1]);
        }
    }
    
    // Проверяет оставшиеся символы на соответствие формату. Разрешены только цифры и один разделитель между ними.
    private static bool IsValidFormat(string text)
    {   
        string pattern = $@"^(\d+([{Separator}]\d+)?|\d*)$";
        return Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase);
    }
    
    // Убирает пробелы, "+" в начале, заменяет X на x
    private static string NormalizeText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;
        
        // удаляет пробелы, дефисы, круглые скобки
        text = Regex.Replace(text, @"[\s\-\(\)]", "");

        if (text.StartsWith("+"))
        {
            text = text[1..];
        }
        
        // Заменяет все X/x/Х/х на Separator
        text = Regex.Replace(text, "[XxХх]", Separator.ToString());

        return text;
    }
    
    private const Char Separator = 'x';
    
    private int MainNumber { get; }
    private int? AdditionalNumber { get; }
    
    // Свойство string Number, возвращающее строку номера телефона с символом + в начале, но без добавочного номера
    public String Number => "+" + MainNumber ;
    
    // Свойство string Ext, возвращающее добавочный номер либо пустую строку
    public String Ext => AdditionalNumber?.ToString() ?? "" ;
}