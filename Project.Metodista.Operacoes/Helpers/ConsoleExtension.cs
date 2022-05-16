using System;

namespace Project.Metodista.Operacoes.Helpers
{
    public static class ConsoleExtension
    {
        public static void WriteLineSucesso(string message)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}\n");
            Console.ResetColor();
        }

        public static void WriteLineError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}\n");
            Console.ResetColor();
        }

        public static void WriteLineAlerta(string message)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{message}\n");
            Console.ResetColor();
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine($"{message}");
        }

        public static void Write(string message)
        {
            Console.Write($"{message}");
        }

        public static void WriteSucesso(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}\n");
            Console.ResetColor();
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}\n");
            Console.ResetColor();
        }
    }
}
