using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Creationpatterns.Builder
{
    public class FacatedPerson
    {
        public string StreetAddress, Postcode, City;

        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class FacetedPersonBuilder // facade
    {
        //Reference!
        protected FacatedPerson Myperson = new FacatedPerson();

        public PersonJobBuilder Works => new PersonJobBuilder(Myperson);

        public PersonAddressBuilder Lives => new PersonAddressBuilder(Myperson);

        public FacatedPerson Build => Myperson;
    }

    public class PersonJobBuilder : FacetedPersonBuilder
    {
        public PersonJobBuilder(FacatedPerson person)
        {
            Myperson = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            Myperson.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            Myperson.Position = position;
            return this;
        }
        public PersonJobBuilder Earns(int income)
        {
            Myperson.AnnualIncome = income;
            return this;
        }
    }

    public class PersonAddressBuilder : FacetedPersonBuilder
    {
        public PersonAddressBuilder(FacatedPerson person)
        {
            Myperson = person;
        }

        public PersonAddressBuilder OnStreetAddress(string streetAddress)
        {
            Myperson.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder InCity(string City)
        {
            Myperson.City = City;
            return this;
        }

        public PersonAddressBuilder InPostcode(string postcode)
        {
            Myperson.Postcode = postcode;
            return this;
        }
    }

    public class FacetedBuilder
    {
        public void Entry()
        {
            var pb = new FacetedPersonBuilder();
            var person = pb
                .Works.At("ABC Corp")
                .AsA("Engineer")
                .Earns(100000)
                .Lives.OnStreetAddress("123 Appl court")
                .InCity("New Jersey")
                .InPostcode("34456").Build;
            Console.WriteLine(person.ToString());
        }
    }
}