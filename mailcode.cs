namespace Caesar
{
    public class CaesarCipher
    {
        const string russianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        const string englishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789";
        // Метод для кодирования и декодирования текста
        private string CodeEncode(string text, int k)
        {
            var fullAlphabet = russianAlphabet + englishAlphabet + digits;
            var letterQty = fullAlphabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                // Преобразуем символ в верхний регистр для поиска в алфавите
                var upperChar = char.ToUpper(c);
                var index = fullAlphabet.IndexOf(upperChar);
                if (index < 0)
                {
                    // Если символ не найден в алфавите, оставляем его без изменений
                    retVal += c.ToString();
                }
                else
                {
                    // Шифруем символ, смещая его на k позиций в алфавите
                    var codeIndex = (index + k) % letterQty;
                    // Обрабатываем случай, когда codeIndex отрицательный
                    if (codeIndex < 0)
                    {
                        codeIndex += letterQty;
                    }
                    // Добавляем зашифрованный символ в результат
                    retVal += fullAlphabet[codeIndex];
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
