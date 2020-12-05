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
    class Product
    {

        public string ProductName { get; set; }
        public string ProductDescr { get; set; }
        public string ProductShortDescr { get; set; }
        public string ProductSku { get; set; }

        public string SalePrice { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Image { get; set; }
        public string Qty { get; set; }



        public Product FillIn()
        {
            new Faker<Product>()
                .StrictMode(true)
                .RuleFor(prd => prd.ProductName, p => p.Commerce.ProductName())
                .RuleFor(prd => prd.ProductDescr, p => p.Commerce.ProductDescription())
                .RuleFor(prd => prd.ProductShortDescr, p => p.Commerce.ProductMaterial())
                .RuleFor(prd => prd.ProductSku, p => p.Commerce.Ean8())
                .RuleFor(prd => prd.SalePrice, p => p.Commerce.Price())
                .RuleFor(prd => prd.Qty, p => (p.Random.Int()).ToString())
                .RuleFor(prd => prd.Weight, p => (p.Random.Short(0, 1000) + p.Random.Decimal()).ToString())
                .RuleFor(prd => prd.Length, p => (p.Random.Short(0, 1000) + p.Random.Decimal()).ToString())
                .RuleFor(prd => prd.Width, p => (p.Random.Short(0, 1000) + p.Random.Decimal()).ToString())
                .RuleFor(prd => prd.Height, p => (p.Random.Short(0, 1000) + p.Random.Decimal()).ToString())
                .RuleFor(prd => prd.Image, p => p.Image.Fashion(800,800, true, false))
                .Populate(this);

            return this;
        }
    }
}
