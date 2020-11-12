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
        public string RegularPrice { get; set; }
        public string SalePrice { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string TaxStatus { get; set; }
        public string TaxClass { get; set; }
        public string PurchaseNote { get; set; }
        public string MenuOrder { get; set; }
        public string StockStatus { get; set; }
        public string ShippingClass { get; set; }



        public Product FillIn()
        {
            new Faker<Product>()
                .StrictMode(true)
                .RuleFor(prd => prd.ProductName, p => p.Commerce.ProductName())
                .RuleFor(prd => prd.ProductDescr, p => p.Commerce.ProductAdjective())
                .RuleFor(prd => prd.ProductShortDescr, p => p.Commerce.ProductMaterial())
                .RuleFor(prd => prd.ProductSku, p => p.Commerce.Ean8())
                .RuleFor(prd => prd.RegularPrice, p => p.Commerce.Price())
                .RuleFor(prd => prd.SalePrice, p => p.Commerce.Price())
                .RuleFor(prd => prd.Weight, p => (p.Random.Int() + p.Random.Decimal()).ToString())
                .RuleFor(prd => prd.Length, p => (p.Random.Int() + p.Random.Decimal()).ToString())
                .RuleFor(prd => prd.Width, p => (p.Random.Int() + p.Random.Decimal()).ToString())
                .RuleFor(prd => prd.Height, p => (p.Random.Int() + p.Random.Decimal()).ToString())
                .RuleFor(prd => prd.TaxStatus, p => p.PickRandom("Taxable", "Shipping only", "None"))
                .RuleFor(prd => prd.TaxClass, p => p.PickRandom("Standard", "Reduced rate", "Zero rate"))
                .RuleFor(prd => prd.PurchaseNote, p => p.Commerce.ProductAdjective())
                .RuleFor(prd => prd.MenuOrder, p => p.Random.Number().ToString())
                .RuleFor(prd => prd.StockStatus, p => p.PickRandom("In stock", "Out of stock", "On backorder"))
                .RuleFor(prd => prd.ShippingClass, p => p.PickRandom("No shipping class"))
                .Populate(this);

            return this;
        }
    }
}
