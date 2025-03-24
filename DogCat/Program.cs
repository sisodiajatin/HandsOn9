// Animal interface
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
    
    public IAnimal CreateAnimal(string animalType)
    {
        switch (animalType.ToLower())
        {
            case "dog":
                return new Dog();
            case "cat":
                return new Cat();
            default:
                throw new ArgumentException($"Animal type {animalType} is not supported.");
        }
    }
}


public class Program
{
    public static void Main()
    {
        AnimalFactory factory = new AnimalFactory();

        
        IAnimal dog = factory.CreateAnimal("dog");
        dog.Speak(); 

        
        IAnimal cat = factory.CreateAnimal("cat");
        cat.Speak(); 

        
        try
        {
            IAnimal bird = factory.CreateAnimal("bird");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message); 
        }
    }
}