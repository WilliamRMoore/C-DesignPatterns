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
        public enum AvailableDrink
        {
            Tea,
            Coffee
        }

        private Dictionary<AvailableDrink, IHotDrinkFacotry> factories = new Dictionary<AvailableDrink, IHotDrinkFacotry>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFacotry)Activator.CreateInstance
                (
                    Type.GetType("DesignPatterns.Creationpatterns.Factories." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory")
                );

                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }

    public static class AbstractFactory
    {
        public static void entry()
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            drink.consume();

        }
    }
}