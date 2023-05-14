using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Creationpatterns.Factories
{
    public class Point
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        private double x, y;
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class PointFactory
    {

    }
}