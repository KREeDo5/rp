using System.Text.RegularExpressions;

namespace ModelLib;

/// <summary>
/// Представляет телефонный номер в международном формате.
/// </summary>
public class PhoneNumber
{
    public PhoneNumber(String text)
    {
        text = NormalizeText(text);
        if (text.Length == 0)
        {
            throw new ArgumentException("Номер телефона не может быть пустым", nameof(text));
        }

        if (!IsValidFormat(text))
        {
            throw new ArgumentException("Недопустимый формат. Разрешены только цифры и один разделитель между ними.",
                nameof(text));
        }

        // Разделяет строку на основной номер и дополнительный по разделителю.
        String[] parts = text.Split(Separator, 2);
        if (parts[0] == "")
        {
            throw new ArgumentException("Номер телефона не может быть пустым", nameof(text));
        }

        // Проверка длины основного номера. Максимум 18 цифр (номера в Германии).
        if (parts[0].Length > 18)
        {
            throw new ArgumentOutOfRangeException(nameof(text), "Недопустимая длина номера телефона");
        }

        _number = long.Parse(parts[0]);

        if (parts.Length > 1 && parts[1] != "")
        {
            // Проверка длины дополнительного номера.
            if (parts[1].Length > 18)
            {
                throw new ArgumentOutOfRangeException(nameof(text), "Недопустимая длина добавочного номера телефона");
            }

            _ext = long.Parse(parts[1]);
        }
    }

    // Проверяет оставшиеся символы на соответствие формату. Разрешены только цифры и один разделитель между ними.
    private static bool IsValidFormat(String text)
    {
        String pattern = $@"^(\d+([{Separator}]\d+)?|\d*)$";
        return Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase);
    }

    // Убирает пробелы, "+" в начале, заменяет X на x
    private static String NormalizeText(String text)
    {
        if (String.IsNullOrEmpty(text))
        {
            return text;
        }

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
    
    // Разделитель между основным номером и добавочным
    private const Char Separator = 'x';

    // Приватный параметр для хранения основного номера телефона
    private readonly long _number;

    // Приватный параметр для хранения добавочного номера телефона
    private readonly long? _ext;

    /// <summary>
    /// Возвращает строку номера телефона с символом + в начале, но без добавочного номера
    /// </summary>
    public String Number => "+" + _number;

    /// <summary>
    /// Возвращает добавочный номер либо пустую строку
    /// </summary>
    public String Ext => _ext?.ToString() ?? "";

    /// <summary>
    /// Возвращает строку номера телефона с символом + в начале
    /// </summary>
    public override String ToString() => _ext == null ? $"+{_number}" : $"+{_number}{Separator}{_ext}";
}