using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    public class Products
    {
        public enum Color
        {
            Red, Green, Blue
        }
        public enum Size
        {
            small, medium, large, yuge
        }

        public class Product
        {
            public string Name;
            public Color Color;
            public Size Size;

            public Product(string name, Color color, Size size)
            {
                if (name == null)
                {
                    throw new ArgumentNullException();
                }
                Name = name;
                Color = color;
                Size = size;
            }
        }

        public interface ISpecification<T>
        {
            bool IsSatified(T t);
        }
        public class AndSpecification<T> : ISpecification<T>
        {
            private ISpecification<T> first, second;

            public AndSpecification(ISpecification<T> first, ISpecification<T> second)
            {
                this.first = first ?? throw new ArgumentException();
                this.second = second ?? throw new ArgumentNullException();
            }
            public bool IsSatified(T t)
            {
                return first.IsSatified(t) && second.IsSatified(t);
            }
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
        }

        public class ColorSpecification : ISpecification<Product>
        {
            Color color;
            public ColorSpecification(Color color)
            {
                this.color = color;
            }
            public bool IsSatified(Product t)
            {
                return t.Color == color;
            }
        }

        public class SizeSpecification : ISpecification<Product>
        {
            Size size;
            public SizeSpecification(Size size)
            {
                this.size = size;
            }
            public bool IsSatified(Product t)
            {
                return t.Size == size;
            }
        }

        public class BetterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
            {
                foreach (var item in items)
                {
                    if (spec.IsSatified(item))
                    {
                        yield return item;
                    }
                }
            }
        }

        public class ProductFilter
        {
            public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
            {
                foreach (var p in products)
                {
                    if (p.Size == size)
                    {
                        yield return p;
                    }
                }
            }
            public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
            {
                foreach (var p in products)
                {
                    if (p.Color == color)
                    {
                        yield return p;
                    }
                }
            }
        }
    }
}