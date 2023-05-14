using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Creationpatterns.Builder
{
    public enum CarType
    {
        Sedan,
        CrossOver
    }

    public class Car
    {
        public CarType Type;
        public int WheelSize;
    }

    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }

    public interface ISpecifyWheelSize
    {
        IBuildCar WithWheels(int size);
    }

    public interface IBuildCar
    {
        public Car Build();
    }

    public class CarBuilder
    {
        private class Impl :
            ISpecifyCarType,
            ISpecifyWheelSize,
            IBuildCar
        {
            private Car car = new Car();

            public Car Build()
            {
                return car;
            }

            public ISpecifyWheelSize OfType(CarType type)
            {
                car.Type = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (car.Type)
                {
                    case CarType.CrossOver when size < 17 || size > 20:
                    case CarType.Sedan when size < 15 || size > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.Type}");
                }

                car.WheelSize = size;
                return this;
            }
        }

        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }

    public class StepWise
    {
        public void Entry()
        {
            var car = CarBuilder.Create()
            .OfType(CarType.CrossOver)
            .WithWheels(18)
            .Build();
        }
    }
}