using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    public class InterfaceSegregation
    {
        public class Document
        {

        }

        public interface IMachine
        {
            void Print(Document d);
            void Scan(Document d);
            void Fax(Document d);
        }

        public interface IPrinter
        {
            void Print(Document d);
        }

        public interface IScaner
        {
            void Scan(Document d);
        }

        public interface IFaxer
        {
            void Fax(Document d);
        }

        public class MultiFunctionPrinter : IPrinter, IScaner, IFaxer
        {
            private IPrinter printer;
            private IScaner scaner;
            private IFaxer faxer;

            public void Fax(Document d)
            {
                faxer.Fax(d);
            }

            public void Print(Document d)
            {
                printer.Print(d);
            }

            public void Scan(Document d)
            {
                scaner.Scan(d);
            } // Decorator pattern
        }

        public class OldFashinPrinter : IPrinter
        {
            public void Print(Document d)
            {
                throw new NotImplementedException();
            }
        }

        public class Scaner : IScaner
        {
            public void Scan(Document d)
            {
                throw new NotImplementedException();
            }
        }

        public class Faxer : IFaxer
        {
            public void Fax(Document d)
            {
                throw new NotImplementedException();
            }
        }
    }
}