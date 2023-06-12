using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Creationpatterns.Factories
{
    public interface IHotDrink
    {
        void consume();
    }

    internal class Tea : IHotDrink
    {
        public void consume()
        {
            System.Console.WriteLine("This tea is nice, but I'd prefer coffee.");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void consume()
        {
            System.Console.WriteLine("This coffee is sensational!");
        }
    }

    public interface IHotDrinkFacotry
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFacotry
    {
        public IHotDrink Prepare(int amount)
        {
            System.Console.WriteLine($"Put in tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFacotry
    {
        public IHotDrink Prepare(int amount)
        {
            System.Console.WriteLine($"Add ground to percolator, percolate, pour {amount} ml, add cream, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinkFacotry>> factories = new();
        public HotDrinkMachine()
        {
            foreach (var type in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFacotry).IsAssignableFrom(type) && !type.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        type.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFacotry)Activator.CreateInstance(type)
                    ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available drinks: ");

            for (int i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                Console.WriteLine($"{i}: {tuple.Item1}");
            }

            while (true)
            {
                string input;

                if ((input = Console.ReadLine()) != null &&
                    int.TryParse(input, out int i) &&
                    i >= 0 &&
                    i < factories.Count
                )
                {
                    Console.WriteLine("Specify Amount: ");
                    input = Console.ReadLine();
                    if (input != null && int.TryParse(input, out int amount) && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                Console.WriteLine("Incorrect input, please try again.");
            }
        }
    }

    public static class AbstractFactory
    {
        public static void entry()
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink.consume();
        }
    }
}