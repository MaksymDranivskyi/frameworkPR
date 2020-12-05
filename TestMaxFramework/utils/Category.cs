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
    class Category
    {

        public string []CategoryName { get; set; }
        public string CategoryDescr { get; set; }

        public Category FillIn()
        {
            new Faker<Category>()
                .StrictMode(true)
                .RuleFor(prd => prd.CategoryName, p => p.Commerce.Categories(1))
                .RuleFor(prd => prd.CategoryDescr, p => p.Commerce.ProductDescription())
                .Populate(this);

            return this;
        }
    }
}
