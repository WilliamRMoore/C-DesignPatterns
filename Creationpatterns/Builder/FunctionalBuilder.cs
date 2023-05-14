using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DesignPatterns.Creationpatterns.Builder.FunctionalBuilder;

namespace DesignPatterns.Creationpatterns.Builder
{
    public class FunctionalBuilder
    {
        public class Person
        {
            public string Name, Position;
        }

        public abstract class MyFunctionalBuilder<TSubject, TSelf> where TSelf : MyFunctionalBuilder<TSubject, TSelf> where TSubject : new()
        {
            private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

            public TSelf Do(Action<TSubject> action) => AddAction(action);

            public TSubject Build()
                => actions.Aggregate(new TSubject(), (p, f) => f(p));

            private TSelf AddAction(Action<TSubject> action)
            {
                actions.Add(p =>
                {
                    action(p);
                    return p;
                });
                return (TSelf)this;
            }
        }

        public sealed class FPersonBuilder : MyFunctionalBuilder<Person, FPersonBuilder>
        {
            public FPersonBuilder Called(string name) => Do(p => p.Name = name);

        }

        public void Enrty()
        {
            var person = new FPersonBuilder();
            person.WorksAs("Consultant");
            person.Called("Bob");
            var p = person.Build();
        }
    }

    public static class FPersonBuilderExtensions
    {
        public static FPersonBuilder WorksAs(this FPersonBuilder builder, string position) => builder.Do(p => p.Position = position);
    }
}