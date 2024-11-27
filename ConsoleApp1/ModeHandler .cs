using Caesar;
using System;
using System.IO;

class ModeHandler
{
    private readonly CaesarCipher cipher;

    public ModeHandler(CaesarCipher cipher)
    {
        this.cipher = cipher;
    }

    public void EncryptText()
    {
        Console.Write("Введите текст: ");
        var message = Console.ReadLine();
        int secretKey = GetSecretKey();
        var encryptedText = cipher.Encrypt(message, secretKey);
        Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
        Console.WriteLine();
        SaveEncryptedMessage(encryptedText);
    }

    public void DecryptText()
    {
        Console.Write("Введите зашифрованный текст: ");
        var encryptedMessage = Console.ReadLine();
        int secretKey = GetSecretKey();
        var decryptedText = cipher.Decrypt(encryptedMessage, secretKey);
        Console.WriteLine("Расшифрованное сообщение: {0}", decryptedText);
        Console.WriteLine();
    }

    public void EncryptFile()
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

    public void DecryptFile()
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

    private int GetSecretKey()
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

    private void SaveEncryptedMessage(string encryptedText)
    {
        string filePath = GetFilePath("Введите имя файла для сохранения (без расширения): ", "Зашифрованное сообщение");
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

    private void SaveEncryptedFile(string encryptedText, string originalFileName)
    {
        string filePath = GetFilePath($"Введите путь для сохранения зашифрованного файла (по умолчанию: 'ЦЕЗАРЯ/{originalFileName}'): ", originalFileName);
        try
        {
            File.WriteAllText(filePath, encryptedText);
            Console.WriteLine("Зашифрованный файл успешно сохранен: {0}", filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при сохранении файла: " + ex.Message);
        }
    }

    private void SaveDecryptedFile(string decryptedText, string originalFileName)
    {
        string filePath = GetFilePath($"Введите путь для сохранения расшифрованного файла (по умолчанию: 'ЦЕЗАРЯ/{originalFileName}'): ", originalFileName);
        try
        {
            File.WriteAllText(filePath, decryptedText);
            Console.WriteLine("Расшифрованный файл успешно сохранен: {0}", filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при сохранении файла: " + ex.Message);
        }
    }

    private string GetFilePath(string prompt, string defaultFileName)
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
