using Caesar;
using System;
using System.IO;

class ConsoleCode
{
    private readonly CaesarCipher cipher;
    private readonly ModeHandler modeHandler;

    public ConsoleCode()
    {
        cipher = new CaesarCipher();
        modeHandler = new ModeHandler(cipher);
    }

    static void Main(string[] args)
    {
        var consoleCode = new ConsoleCode();
        consoleCode.Run();
    }

    public void Run()
    {
        bool continueLoop = true;
        while (continueLoop)
        {
            int modeChoice = GetModeChoice();
            switch (modeChoice)
            {
                case 1:
                    modeHandler.EncryptText();
                    break;
                case 2:
                    modeHandler.DecryptText();
                    break;
                case 3:
                    modeHandler.EncryptFile();
                    break;
                case 4:
                    modeHandler.DecryptFile();
                    break;
            }
            continueLoop = AskToContinue();
        }
    }

    private int GetModeChoice()
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
        return modeChoice;
    }

    private bool AskToContinue()
    {
        Console.Write("Желаете продолжить? (д/any): ");
        var continueChoice = Console.ReadLine();
        Console.WriteLine();
        return continueChoice.ToLower() == "д";
    }
}
