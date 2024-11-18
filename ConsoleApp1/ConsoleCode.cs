using Caesar;
using System;
using System.IO;

class ConsoleCode
{
    static void Main(string[] args)
    {
        var cipher = new CaesarCipher();
        bool continueLoop = true;
        while (continueLoop)
        {
            int modeChoice;
            while (true)
            {
                Console.Write("Выберите режим (1 - Зашифровать текст, 2 - Расшифровать текст, 3 - Зашифровать файл, 4 - Расшифровать файл): ");
                if (int.TryParse(Console.ReadLine(), out modeChoice) && (modeChoice >= 1 && modeChoice <= 4))
                {
                    break;
                }
                Console.WriteLine("Некорректный выбор режима. Пожалуйста, выберите 1, 2, 3 или 4.");
                Console.WriteLine();
            }
            if (modeChoice == 1) // Шифрование текста
            {
                Console.Write("Введите текст: ");
                var message = Console.ReadLine();
                int secretKey = GetSecretKey();
                var encryptedText = cipher.Encrypt(message, secretKey);
                Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
                Console.WriteLine();
                SaveEncryptedMessage(encryptedText);
            }
            else if (modeChoice == 2) // Дешифрование текста
            {
                Console.Write("Введите зашифрованный текст: ");
                var encryptedMessage = Console.ReadLine();
                int secretKey = GetSecretKey();
                var decryptedText = cipher.Decrypt(encryptedMessage, secretKey);
                Console.WriteLine("Расшифрованное сообщение: {0}", decryptedText);
                Console.WriteLine();
            }
            else if (modeChoice == 3) // Шифрование файла
            {
                string userName = Environment.UserName;
                Console.Write($"Введите путь к файлу для шифрования (например, C:\\Users\\{userName}\\Documents\\example.txt): ");
                string inputFilePath = Console.ReadLine();
                if (File.Exists(inputFilePath))
                {
                    DateTime creationTime = File.GetCreationTime(inputFilePath);
                    int secretKey = creationTime.Minute; // Используем минуты создания файла как ключ
                    string fileContent = File.ReadAllText(inputFilePath);
                    var encryptedText = cipher.Encrypt(fileContent, secretKey);
                    SaveEncryptedFile(encryptedText, "Зашифрованный_" + Path.GetFileName(inputFilePath));
                }
                else
                {
                    Console.WriteLine("Файл не найден. Пожалуйста, проверьте путь и попробуйте снова.");
                }
            }
            else if (modeChoice == 4) // Дешифрование файла
            {
                string userName = Environment.UserName;
                Console.Write($"Введите путь к зашифрованному файлу (например, C:\\Users\\{userName}\\Documents\\Зашифрованный_example.txt): ");
                string inputFilePath = Console.ReadLine();
                if (File.Exists(inputFilePath))
                {
                    DateTime creationTime = File.GetCreationTime(inputFilePath);
                    int secretKey = creationTime.Minute; // Используем минуты создания файла как ключ
                    string encryptedContent = File.ReadAllText(inputFilePath);
                    var decryptedText = cipher.Decrypt(encryptedContent, secretKey);
                    Console.WriteLine("Расшифрованное сообщение: {0}", decryptedText);
                    Console.WriteLine();
                    SaveDecryptedFile(decryptedText, "Расшифрованный_" + Path.GetFileName(inputFilePath));
                }
                else
                {
                    Console.WriteLine("Файл не найден. Пожалуйста, проверьте путь и попробуйте снова.");
                }
            }
            Console.Write("Желаете продолжить? (д/any): ");
            var continueChoice = Console.ReadLine();
            Console.WriteLine();
            if (continueChoice.ToLower() != "д")
            {
                continueLoop = false;
                Console.Clear();
            }
        }
    }

    private static int GetSecretKey()
    {
        int secretKey;
        while (true)
        {
            Console.Write("Введите ключ: ");
            if (int.TryParse(Console.ReadLine(), out secretKey))
            {
                break;
            }
            Console.WriteLine("Некорректный ключ. Пожалуйста, введите целое число.");
            Console.WriteLine();
        }
        return secretKey;
    }
    // Метод для сохранения зашифрованного сообщения в текстовый файл
    private static void SaveEncryptedMessage(string encryptedText)
    {
        string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ЦЕЗАРЯ");
        Directory.CreateDirectory(documentsPath);
        Console.Write("Введите имя файла для сохранения (без расширения): ");
        var fileName = Console.ReadLine() + ".txt";
        var filePath = Path.Combine(documentsPath, fileName);
        try
        {
            File.WriteAllText(filePath, encryptedText);
            Console.WriteLine("Зашифрованное сообщение успешно сохранено в файл: {0}", filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при сохранении файла: " + ex.Message);
        }
    }
    private static void SaveEncryptedFile(string encryptedText, string originalFileName)
    {
        string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ЦЕЗАРЯ");
        Directory.CreateDirectory(documentsPath);
        string filePath = Path.Combine(documentsPath, originalFileName);
        try
        {
            File.WriteAllText(filePath, encryptedText);
            Console.WriteLine("Зашифрованный файл успешно сохранен в папку 'ЦЕЗАРЯ': {0}", filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при сохранении файла: " + ex.Message);
        }
    }
    private static void SaveDecryptedFile(string decryptedText, string originalFileName)
    {
        string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ЦЕЗАРЯ");
        Directory.CreateDirectory(documentsPath);
        string filePath = Path.Combine(documentsPath, originalFileName);
        try
        {
            File.WriteAllText(filePath, decryptedText);
            Console.WriteLine("Расшифрованный файл успешно сохранен в папку 'ЦЕЗАРЯ': {0}", filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при сохранении файла: " + ex.Message);
        }
    }

    private static string GetFilePath(string prompt, string defaultFileName)
    {
        string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ЦЕЗАРЯ");
        Directory.CreateDirectory(documentsPath);

        Console.Write(prompt);
        string userInput = Console.ReadLine();

        string filePath;
        if (string.IsNullOrWhiteSpace(userInput))
        {
            // Если пользователь не ввел путь, используем путь по умолчанию
            filePath = Path.Combine(documentsPath, defaultFileName + ".txt");
        }
        else
        {
            // Проверяем, существует ли указанный путь
            try
            {
                filePath = Path.Combine(userInput, defaultFileName + ".txt");
                // Проверяем, существует ли директория
                if (!Directory.Exists(userInput))
                {
                    throw new DirectoryNotFoundException();
                }
            }
            catch
            {
                Console.WriteLine("Некорректный путь. Сохранение файла в папку 'ЦЕЗАРЯ'.");
                filePath = Path.Combine(documentsPath, defaultFileName + ".txt");
            }
        }
        return filePath;
    }
}