using System.Linq;

namespace Caesar
{
    public class CaesarCipher
    {
        const string russianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        const string englishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";

        private string CodeEncode(string text, int k)
        {
            var retVal = "";

            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                int index;

                // Проверяем, к какому алфавиту принадлежит символ
                if (russianAlphabet.Contains(char.ToUpper(c)))
                {
                    index = russianAlphabet.IndexOf(char.ToUpper(c));
                    var codeIndex = (index + k) % russianAlphabet.Length;
                    if (codeIndex < 0)
                    {
                        codeIndex += russianAlphabet.Length;
                    }
                    retVal += char.IsLower(c) ? char.ToLower(russianAlphabet[codeIndex]) : russianAlphabet[codeIndex];
                }
                else if (englishAlphabet.Contains(char.ToUpper(c)))
                {
                    index = englishAlphabet.IndexOf(char.ToUpper(c));
                    var codeIndex = (index + k) % englishAlphabet.Length;
                    if (codeIndex < 0)
                    {
                        codeIndex += englishAlphabet.Length;
                    }
                    retVal += char.IsLower(c) ? char.ToLower(englishAlphabet[codeIndex]) : englishAlphabet[codeIndex];
                }
                else if (digits.Contains(c))
                {
                    index = digits.IndexOf(c);
                    var codeIndex = (index + k) % digits.Length;
                    if (codeIndex < 0)
                    {
                        codeIndex += digits.Length;
                    }
                    retVal += digits[codeIndex];
                }
                else
                {
                    // Если символ не найден в алфавитах, оставляем его без изменений
                    retVal += c.ToString();
                }
            }
            return retVal;
        }

        public string Encrypt(string plainMessage, int key)
            => CodeEncode(plainMessage, key);

        public string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key);
    }
}
