namespace Caesar
{
    // Создание публичного класса CaesarCipher для шифрования и дешифрования текста
    public class CaesarCipher
    {
        // Строки с символами русской и английской азбуки, а также цифрами
        const string russianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        const string englishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789-1";
        // Метод для кодирования и декодирования текста
        private string CodeEncode(string text, int k)
        {
            // Создаем полный алфавит с учетом русского, английского и цифр
            var fullAlphabet = russianAlphabet + englishAlphabet + digits;
            var letterQty = fullAlphabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                // Ищем индекс символа в алфавите
                var index = fullAlphabet.IndexOf(c);
                if (index < 0)
                {
                    // Если символ не найден в алфавите, оставляем его без изменений
                    retVal += c.ToString();
                }
                else
                {
                    // Шифруем символ, смещая его на k позиций в алфавите
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlphabet[codeIndex];
                }
            }
            return retVal;
        }
        // Метод для шифрования текста
        public string Encrypt(string plainMessage, int key)
            => CodeEncode(plainMessage, key);
        // Метод для дешифрования текста
        public string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key);
    }
}

