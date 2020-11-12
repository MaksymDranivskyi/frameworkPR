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
    class Checkout
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Transaction { get; set; }
        public string Status1 { get; set; }
        public string Status { get; set; }
        public string Massage { get; set; }

        public Checkout FillIn()
        {
            new Faker<Checkout>()
                .StrictMode(true)
                .RuleFor(chk => chk.FirstName, f => f.Name.FirstName())
                .RuleFor(chk => chk.LastName, f => f.Name.LastName())
                .RuleFor(chk => chk.Email, f => f.Internet.Email())
                .RuleFor(chk => chk.Country, f => f.Address.Country())
                // .RuleFor(chk => chk.Country, f => f.PickRandom("select2-billing_country-result-49by-PT", "select2-billing_country-result-ocit-RW"))
                .RuleFor(chk => chk.Street, f => f.Address.StreetAddress())
                .RuleFor(chk => chk.City, f => f.Address.City())
                .RuleFor(chk => chk.State, f => f.Address.State())
                .RuleFor(chk => chk.Postcode, f => f.Address.ZipCode())
                .RuleFor(chk => chk.Massage, f => f.Random.Words())
                .RuleFor(chk => chk.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(chk => chk.Company, f => f.Company.CompanyName())
                .RuleFor(chk => chk.Transaction, f => f.Random.Odd(100000, 999999).ToString())
                .RuleFor(chk => chk.Status, f => f.PickRandom("Processing","On hold","Completed", "Cancelled", "Cancelled", "Refunded", "Failed"))
                .RuleFor(chk => chk.Status1, f => f.PickRandom("select2-order_status-result-s35j-wc-on-hold", "select2-order_status-result-iumu-wc-processing", "select2-order_status-result-v5rk-wc-completed", "select2-order_status-result-t9c9-wc-cancelled", "select2-order_status-result-xxja-wc-refunded", "select2-order_status-result-m4ix-wc-failed"))
                .Populate(this);

            return this;
        }
    }
}
