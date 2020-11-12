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
    class Profile
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }



        public Profile FillIn()
        {
            new Faker<Profile>()
                .StrictMode(true)
                .RuleFor(chk => chk.FirstName, f => f.Name.FirstName())
                .RuleFor(chk => chk.LastName, f => f.Name.LastName())
                .RuleFor(chk => chk.Email, f => f.Internet.Email())
                .Populate(this);

            return this;
        }
    }
}
