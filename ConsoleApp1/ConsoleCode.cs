using System;

public class Program
{
    public static void Main(string[] args)
    {
        ModeHandler modeHandler = new ModeHandler();

        while (true)
        {
            Console.WriteLine(new string('-', 40)); // Разделитель
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Шифровать текст");
            Console.WriteLine("2. Дешифровать текст");
            Console.WriteLine("3. Шифровать файл");
            Console.WriteLine("4. Дешифровать файл");
            Console.WriteLine(new string('-', 40)); // Разделитель

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Шифрование текста
                    Console.WriteLine(new string('-', 40)); // Разделитель
                    Console.WriteLine();
                    string textToEncrypt = GetUserInput("Введите текст для шифрования: ");
                    int encryptionKey = GetUserInputAsInt("Введите ключ: ");
                    string encryptedText = modeHandler.EncryptText(textToEncrypt, encryptionKey);
                    Console.WriteLine("Зашифрованный текст: {0}", encryptedText);
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 40)); // Разделитель
                    break;
                case "2":
                    // Дешифрование текста
                    Console.WriteLine(new string('-', 40)); // Разделитель
                    Console.WriteLine();
                    string textToDecrypt = GetUserInput("Введите зашифрованный текст: ");
                    int decryptionKey = GetUserInputAsInt("Введите ключ: ");
                    string decryptedText = modeHandler.DecryptText(textToDecrypt, decryptionKey);
                    Console.WriteLine("Расшифрованное сообщение: {0}", decryptedText);
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 40)); // Разделитель
                    break;
                case "3":
                    // Шифрование файла
                    Console.WriteLine(new string('-', 40)); // Разделитель
                    Console.WriteLine();
                    modeHandler.EncryptFile();
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 40)); // Разделитель
                    break;
                case "4":
                    // Дешифрование файла
                    Console.WriteLine(new string('-', 40)); // Разделитель
                    Console.WriteLine();
                    modeHandler.DecryptFile();
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 40)); // Разделитель
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    private static string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    private static int GetUserInputAsInt(string prompt)
    {
        int input;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out input))
            {
                return input;
            }
            Console.WriteLine("Неверный ввод. Пожалуйста, введите целое число.");
            Console.WriteLine();
        }
    }
}