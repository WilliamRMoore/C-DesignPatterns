using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    public class Liskov
    {
        public class Rectangle
        {
            public virtual int width { get; set; }
            public virtual int height { get; set; }

            public Rectangle(int width, int height)
            {
                this.width = width;
                this.height = height;
            }
            public Rectangle()
            {

            }

            public override string ToString()
            {
                return $"{nameof(this.width)}: {this.width}, {nameof(this.height)}: {this.height}";
            }

        }

        public class Square : Rectangle
        {
            public override int width
            {
                set { base.width = base.height = value; }
            }
            public override int height
            {
                set { base.width = base.height = value; }
            }
        }

        public static int Area(Rectangle r) => r.width * r.height;

    }
}