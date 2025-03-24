using System;


public sealed class SingletonLogger
{
    private static readonly SingletonLogger instance = new SingletonLogger();

    private SingletonLogger() { }

    public static SingletonLogger Instance
    {
        get { return instance; }
    }

    public enum LogLevel
    {
        Comment,
        Warning,
        Error
    }

    public void Log(LogLevel level, string message)
    {
        switch (level)
        {
            case LogLevel.Comment:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Comment: {message}");
                break;
            case LogLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {message}");
                break;
            case LogLevel.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {message}");
                Environment.Exit(1);
                break;
        }
        Console.ResetColor();
    }
}


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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Comment: {message}");
                break;
            case LogLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {message}");
                break;
            case LogLevel.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {message}");
                Environment.Exit(1);
                break;
        }
        Console.ResetColor();
    }
}


public interface IAnimal
{
    void Speak();
}

public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("woof");
    }
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("meow");
    }
}


public class AnimalFactory
{
    public enum AnimalType
    {
        Dog,
        Cat
    }

    public static IAnimal CreateAnimal(AnimalType type)
    {
        switch (type)
        {
            case AnimalType.Dog:
                return new Dog();
            case AnimalType.Cat:
                return new Cat();
            default:
                throw new ArgumentException("Invalid animal type");
        }
    }
}


class Program
{
    static void Main()
    {
        
        var singletonLogger = SingletonLogger.Instance;
        singletonLogger.Log(SingletonLogger.LogLevel.Comment, "Starting program");
        singletonLogger.Log(SingletonLogger.LogLevel.Warning, "Low memory");
        

        
        StaticLogger.Log(StaticLogger.LogLevel.Comment, "Static logger test");
        StaticLogger.Log(StaticLogger.LogLevel.Warning, "Static warning");

        
        IAnimal dog = AnimalFactory.CreateAnimal(AnimalFactory.AnimalType.Dog);
        IAnimal cat = AnimalFactory.CreateAnimal(AnimalFactory.AnimalType.Cat);
        dog.Speak(); 
        cat.Speak(); 
    }
}