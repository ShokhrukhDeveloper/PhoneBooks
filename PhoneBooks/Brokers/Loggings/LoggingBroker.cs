using System;

namespace PhoneBooks.Brokers.Loggings
{
    public class LoggingBroker
    {
        public void LogInformation(string message) =>
            Console.WriteLine(message);
        public void LogError(string userMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(userMessage);
            Console.ResetColor();
        }

        public void LogError(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(exception.Message);
            Console.ResetColor();
        }
    }
}
