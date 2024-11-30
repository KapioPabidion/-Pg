using Caesar;
using System;
using System.IO;

public class ModeHandler
{
    private readonly CaesarCipher cipher;

    public ModeHandler()
    {
        cipher = new CaesarCipher();
    }

    public string EncryptText(string message, int secretKey)
    {
        var encryptedText = cipher.Encrypt(message, secretKey);
        SaveToFile(encryptedText); // Сохраняем зашифрованный текст в файл
        return encryptedText; // Возвращаем зашифрованный текст
    }

    public string DecryptText(string encryptedMessage, int secretKey)
    {
        var decryptedText = cipher.Decrypt(encryptedMessage, secretKey);
        return decryptedText; // Возвращаем расшифрованный текст
    }

    public void EncryptFile()
    {
        string filePath = GetUserInput("Введите путь к файлу для шифрования: ");
        if (File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath);
            int secretKey = GetKeyFromFileCreationTime(filePath);
            var encryptedText = cipher.Encrypt(fileContent, secretKey);
            SaveToFile(encryptedText);
        }
        else
        {
            Console.WriteLine("Файл не найден. Пожалуйста, проверьте путь и попробуйте снова.");
        }
    }

    public void DecryptFile()
    {
        string filePath = GetUserInput("Введите путь к зашифрованному файлу: ");
        if (File.Exists(filePath))
        {
            string encryptedContent = File.ReadAllText(filePath);
            int secretKey = GetKeyFromFileCreationTime(filePath);
            var decryptedText = cipher.Decrypt(encryptedContent, secretKey);
            Console.WriteLine("Расшифрованное сообщение: {0}", decryptedText);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Файл не найден. Пожалуйста, проверьте путь и попробуйте снова.");
        }
    }

    private string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    private int GetKeyFromFileCreationTime(string filePath)
    {
        DateTime creationTime = File.GetCreationTime(filePath);
        return creationTime.Day; // Дни
    }

    public void SaveToFile(string content)
    {
        Console.Write("Введите путь для сохранения (или нажмите Enter для сохранения в C:\\Users\\st53\\Documents\\ЦЕЗАРЯ): ");
        string filePath = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filePath))
        {
            filePath = @"C:\Users\st53\Documents\ЦЕЗАРЯ\default"; // Путь по умолчанию
        }

        try
        {
            File.WriteAllText(filePath + ".txt", content);
            Console.WriteLine("Файл успешно сохранён: {0}.txt", filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при сохранении файла: " + ex.Message);
        }
    }
}
