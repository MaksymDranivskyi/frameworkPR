using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestMaxFramework.pages;
using TestMaxFramework.utils;

using Bogus;

namespace TestMaxFramework
{
    class Billing
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }



        public Billing FillIn()
        {
            new Faker<Billing>()
                .StrictMode(true)
                .RuleFor(chk => chk.FirstName, f => f.Name.FirstName())
                .RuleFor(chk => chk.LastName, f => f.Name.LastName())
                .RuleFor(chk => chk.Email, f => f.Internet.Email())
                .RuleFor(chk => chk.Company, f => f.Company.CompanyName())
                .RuleFor(chk => chk.Country, f => f.Address.County())
                .RuleFor(chk => chk.Street, f => f.Address.StreetAddress())
                .RuleFor(chk => chk.City, f => f.Address.City())
                .RuleFor(chk => chk.State, f => f.Address.State())
                .RuleFor(chk => chk.Postcode, f => f.Random.ReplaceNumbers("#####"))
                .RuleFor(chk => chk.Phone, f => f.Random.ReplaceNumbers("+380#########"))
                .Populate(this);

            return this;
        }
    }
}
