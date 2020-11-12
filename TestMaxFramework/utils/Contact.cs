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
    class Contact
    {

        public string Name { get; set; }
        public string Massage { get; set; }
        public string Email { get; set; }


        public Contact FillIn()
        {
            new Faker<Contact>()
                .StrictMode(true)
                .RuleFor(o => o.Name, f => f.Name.FirstName())
                .RuleFor(bp => bp.Massage, f => f.Random.Words())
                .RuleFor(bp => bp.Email, f => f.Internet.Email())
                .Populate(this);

            return this;
        }
    }
}
