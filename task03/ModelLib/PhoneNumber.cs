using System.Text.RegularExpressions;

namespace ModelLib;

/// <summary>
/// Представляет телефонный номер в международном формате.
/// </summary>
public class PhoneNumber
{
    public PhoneNumber(string text)
    {   
        text = NormalizeText(text);
        if (text.Length == 0)
        {
            throw new ArgumentException("Номер телефона не может быть пустым", nameof(text));
        }
        if (!IsValidFormat(text))
        {
            throw new ArgumentException("Недопустимый формат. Разрешены только цифры и один разделитель между ними.", nameof(text));
        }
        
        // Сохраняет отдельно основной номер и добавочный номер
        string[] parts = text.Split(Separator, 2);
        if (parts[0] == "")
        {
            throw new ArgumentException("Номер телефона не может быть пустым", nameof(text));
        }
        // Проверка длины основного номера. Максимум 18 цифр (номера в Германии).
        if (parts[0].Length > 18 )
        {
            throw new ArgumentException("Недопустимая длина номера телефона", nameof(text));
        }
        MainNumber = long.Parse(parts[0]);
        
        if (parts.Length > 1 && parts[1] != "")
        {
            if (parts[1].Length > 18 )
            {
                throw new ArgumentException("Недопустимая длина добавочного номера телефона", nameof(text));
            }
            AdditionalNumber = long.Parse(parts[1]);
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
        
        // Удаляет пробелы, дефисы, круглые скобки
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
    
    private long MainNumber { get; }
    private long? AdditionalNumber { get; }
    
    // Возвращает строку номера телефона с символом + в начале, но без добавочного номера
    public String Number => "+" + MainNumber ;
    
    // Возвращает добавочный номер либо пустую строку
    public String Ext => AdditionalNumber?.ToString() ?? "" ;
    
    // TODO: Метод ToString(), возвращающий строку номера телефона с символом + в начале
    // Пример: +78362450272 — когда нет добавочного номера
    // Пример: +12345678901x1234 — когда есть добавочный номер
}