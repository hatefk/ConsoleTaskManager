using TaskManagerDemo.Resources;

namespace TaskManagerDemo.Services
{
    public static class Display
    {
        public static void Info(string message) 
        {
            Console.WriteLine(message);
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = Colors.Error;
            Console.WriteLine(message); 
            Console.ResetColor();
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = Colors.Warning;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}
