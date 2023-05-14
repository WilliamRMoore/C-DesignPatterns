using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Creationpatterns.Builder;
using DesignPatterns.Creationpatterns.Factories;
using DesignPatterns.SOLID;
using static DesignPatterns.SOLID.DependencyInversion;
using static DesignPatterns.SOLID.Liskov;
using static DesignPatterns.SOLID.Products;

namespace DesignPatterns.App
{
    public class App
    {
        public void Entry()
        {
            var apple = new Product("Apple", Color.Green, Size.small);
            var tree = new Product("Tree", Color.Green, Size.large);
            var house = new Product("House", Color.Blue, Size.large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();

            Console.WriteLine("Green products (old):");

            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is Green");
            }

            var bf = new BetterFilter();

            Console.WriteLine("Green products with BF");

            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {p.Name} is Green");
            }

            Console.WriteLine("Large and blue items");

            foreach (var p in bf.Filter(
                products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Blue),
                    new SizeSpecification(Size.large)
                )))
            {
                Console.WriteLine($" - {p.Name}: Is large and blue");
            }

            // var rec = new Rectangle(2, 5);
            // Console.WriteLine($"{rec} has area {Liskov.Area(rec)}");

            // Rectangle sq = new Square();
            // sq.width = 4;
            // Console.WriteLine($"{sq} has area {Liskov.Area(sq)}");

            // var parent = new Person { Name = "John" };
            // var child1 = new Person { Name = "chris" };
            // var child2 = new Person { Name = "marry" };

            // var relationships = new Relationships();
            // relationships.AddParentAndChild(parent, child1);
            // relationships.AddParentAndChild(parent, child2);

            // var research = new Research(relationships);

        }

        public void BuilderRoutine()
        {
            // var hello = "Hello";
            // var sb = new StringBuilder();
            // sb.Append("<p>");
            // sb.Append(hello);
            // sb.Append("</p>");
            // Console.WriteLine(sb);

            // var words = new[] { "Hello", "world" };

            // sb.Clear();
            // sb.Append("<ul>");
            // foreach (var word in words)
            // {
            //     sb.AppendFormat("<li>{0}</li>", word);
            // }
            // sb.Append("</ul>");
            // Console.WriteLine(sb);

            // var builder = new HtmlBuilder("ul");
            // builder.AddChild("li", "hello").AddChild("li", "World");
            // Console.WriteLine(builder.ToString());

            //Console.WriteLine(Creationpatterns.Builder.Person.New.Called("Will").WorksAsA("Eng").build().ToString());

            var res = new FacetedBuilder();
            res.Entry();
        }

        public void FactoryRoutine()
        {
            ThemeFactoryEntry.run();
        }
    }
}