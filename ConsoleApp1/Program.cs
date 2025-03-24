// Singleton Logger implementation
public class Logger
{
    
    public enum LogLevel
    {
        Comment,
        Warning,
        Error
    }

    
    private static Logger? _instance;

    
    private static readonly object _lock = new object();

    
    private Logger() { }

    
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
            }
        }
        return _instance;
    }

    
    public void Log(LogLevel level, string message)
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
                Environment.Exit(1); 
                break;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Logger logger = Logger.GetInstance();

        
        logger.Log(Logger.LogLevel.Comment, "This is a comment");
        logger.Log(Logger.LogLevel.Warning, "This is a warning");

        try
        {
            
            int divisor = 0;
            if (divisor == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            int result = 5 / divisor;
        }
        catch (Exception ex)
        {
            logger.Log(Logger.LogLevel.Error, ex.Message); 
        }

        
        logger.Log(Logger.LogLevel.Comment, "This won't be printed");
    }
}