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
    class Cart
    {
        public string CouponCode { get; set; }



        public Cart FillIn()
        {
            new Faker<Cart>()
                .StrictMode(true)
                .RuleFor(chk => chk.CouponCode, f => f.PickRandom("peqx-nyix-ocxl", "o9q7-ow2w-lcm9", "xtub-fm2p-h22r", "pkjd-2khq-fcpw", "hca0-lmyf-tvod", "1nqr-ehtm-p0r5", "gk4r-oyel-a94k", "chcm-6dvs-1ybf", "gjov-miva-dztg"))
                .Populate(this);

            return this;
        }
    }
}
