using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Creationpatterns.Factories
{
    public class Foo
    {
        private Foo()
        {
            //
        }

        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }

    public class Entry
    {
        public static async void Run()
        {
            var f = await Foo.CreateAsync();
        }
    }
}