using Caesar;
using System;

class ConsoleCode
{
    static void Main(string[] args)
    {
        // Создаем экземпляр класса CaesarCipher
        var cipher = new CaesarCipher();

        // Флаг для продолжения цикла
        bool continueLoop = true;

        while (continueLoop)
        {
            // Переменная для хранения выбора режима
            int modeChoice;
            while (true)
            {
                // Выводим сообщение о выборе режима
                Console.Write("Выберите режим (1 - Зашифровать, 2 - Расшифровать): ");
                // Пытаемся преобразовать ввод в целое число
                if (int.TryParse(Console.ReadLine(), out modeChoice) && (modeChoice == 1 || modeChoice == 2))
                {
                    // Если ввод корректен, выходим из цикла
                    break;
                }
                // Если ввод некорректен, выводим сообщение об ошибке
                Console.WriteLine("Некорректный выбор режима. Пожалуйста, выберите 1 или 2.");
                Console.WriteLine(); // Добавляем пустую строку для разделения
            }

            if (modeChoice == 1)
            {
                // Выводим сообщение о вводе текста
                Console.Write("Введите текст: ");
                // Считываем ввод текста
                var message = Console.ReadLine();
                // Переменная для хранения секретного ключа
                int secretKey;
                while (true)
                {
                    // Выводим сообщение о вводе ключа
                    Console.Write("Введите ключ: ");
                    // Пытаемся преобразовать ввод в целое число
                    if (int.TryParse(Console.ReadLine(), out secretKey))
                    {
                        // Если ввод корректен, выходим из цикла
                        break;
                    }
                    // Если ввод некорректен, выводим сообщение об ошибке
                    Console.WriteLine("Некорректный ключ. Пожалуйста, введите целое число.");
                    Console.WriteLine(); // Добавляем пустую строку для разделения
                }
                // Шифруем текст с помощью секретного ключа
                var encryptedText = cipher.Encrypt(message, secretKey);
                // Выводим зашифрованный текст
                Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
                Console.WriteLine(); // Добавляем пустую строку для разделения
            }
            else if (modeChoice == 2)
            {
                // Выводим сообщение о вводе зашифрованного текста
                Console.Write("Введите зашифрованный текст: ");
                // Считываем ввод зашифрованного текста
                var encryptedMessage = Console.ReadLine();
                // Переменная для хранения секретного ключа
                int secretKey;
                while (true)
                {
                    // Выводим сообщение о вводе ключа
                    Console.Write("Введите ключ: ");
                    // Пытаемся преобразовать ввод в целое число
                    if (int.TryParse(Console.ReadLine(), out secretKey))
                    {
                        // Если ввод корректен, выходим из цикла
                        break;
                    }
                    // Если ввод некорректен, выводим сообщение об ошибке
                    Console.WriteLine("Некорректный ключ. Пожалуйста, введите целое число.");
                    Console.WriteLine(); // Добавляем пустую строку для разделения
                }
                // Расшифровываем текст с помощью секретного ключа
                var decryptedText = cipher.Decrypt(encryptedMessage, secretKey);
                // Выводим расшифрованный текст
                Console.WriteLine("Расшифрованное сообщение: {0}", decryptedText);
                Console.WriteLine(); // Добавляем пустую строку для разделения
            }
            // Выводим сообщение о продолжении работы
            Console.Write("Желаете продолжить? (д/any): ");
            // Считываем ввод о продолжении работы
            var continueChoice = Console.ReadLine();
            Console.WriteLine(); // Добавляем пустую строку для разделения

            // Если пользователь не хочет продолжать, выходим из цикла
            if (continueChoice.ToLower() != "д")
            {
                continueLoop = false;
                Console.Clear();
            }
        }
    }
}

