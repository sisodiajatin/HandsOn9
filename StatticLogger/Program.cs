// Static Logger implementation 
public static class StaticLogger
{
    
    public enum LogLevel
    {
        Comment,
        Warning,
        Error
    }

    
    public static void Log(LogLevel level, string message)
    {
        switch (level)
        {
            case LogLevel.Comment:
                Console.WriteLine($"Comment: {message}");
                break;
            case LogLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {message}");
                Console.ResetColor();
                break;
            case LogLevel.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {message}");
                Console.ResetColor();
                Environment.Exit(1); // Stop program execution
                break;
        }
    }
}


public class Program
{
    public static void Main()
    {
        
        StaticLogger.Log(StaticLogger.LogLevel.Comment, "This is a comment");
        StaticLogger.Log(StaticLogger.LogLevel.Warning, "This is a warning");

        try
        {
            
            int divisor = GetDivisor();
            int result = 5 / divisor; 
        }
        catch (Exception ex)
        {
            StaticLogger.Log(StaticLogger.LogLevel.Error, ex.Message); 
        }

        
        StaticLogger.Log(StaticLogger.LogLevel.Comment, "This won't be printed");
    }

    
    private static int GetDivisor()
    {
        return 0; 
    }
}