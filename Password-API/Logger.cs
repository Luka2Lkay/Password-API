namespace Password_API
{
    public class Logger
    {
        public void Info(string message)
        {
            Write(message, ConsoleColor.Cyan);
        }

        public void Warn(string message)
        {
            Write(message, ConsoleColor.Yellow);
        }

        public void Error(string message)
        {
            Write(message, ConsoleColor.Red);
        }

       public  void Success(string message)
        {
            Write(message, ConsoleColor.Green);
        }
        private static void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
            Console.ResetColor();
        }
    }
}
