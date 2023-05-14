using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Creationpatterns.Factories
{
    public class PointFExample
    {
        private double x, y;
        public PointFExample(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public static class PointFactoryExample
    {
        public static PointFExample NewCartesianPoint(double x, double y)
        {
            return new PointFExample(x, y);
        }

        public static PointFExample NewPolarPoint(double rho, double theta)
        {
            return new PointFExample(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }

    public static class PointFExampleEntry
    {
        public static void run()
        {
            var res = PointFactoryExample.NewCartesianPoint(1, 2);
        }
    }
}