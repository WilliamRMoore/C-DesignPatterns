using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    public class DependencyInversion
    {
        public enum Relationship
        {
            Parent, Child, Sibling
        }

        public class Person
        {
            public string Name;
        }

        public interface IRelationshipBrowser
        {
            IEnumerable<Person> FindAllChildrenOf(string name);
        }

        //Low level

        public class Relationships : IRelationshipBrowser
        {
            private List<(Person, Relationship, Person)> relations
             = new List<(Person, Relationship, Person)>();

            public void AddParentAndChild(Person parent, Person child)
            {
                relations.Add((parent, Relationship.Parent, child));
                relations.Add((child, Relationship.Child, parent));
            }

            public IEnumerable<Person> FindAllChildrenOf(string name)
            {
                return relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(r => r.Item3);
            }
        }

        public class Research
        {
            public Research(IRelationshipBrowser browser)
            {
                foreach (var p in browser.FindAllChildrenOf("John"))
                {
                    Console.WriteLine($"john has a child called {p.Name}");
                }
            }
        }
    }
}