using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Text;
using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;
using Bukimedia.PrestaSharp.Deserializers;
using Bukimedia.PrestaSharp.Helpers;
using Bukimedia.PrestaSharp.Lib;
using Bukimedia.PrestaSharp;
using System.Collections.Generic;
using TestMaxFramework.utils;
using RestSharp;
using System.Linq;
using System.Net;
using TestMaxFramework.Reports;
using static NSelene.Selene;
using System.Collections.Generic;

namespace TestMaxFramework
{
    public class ApiFixture
    {
        string BaseUrl = "http://localhost/prestashop_1.7.6.8/api";
        string Account = "VR6A6NS7VIDKM6D66YU37ACJ7HXPYPV4";
        string Password = "";


        public void CreateManufacturer()
        {
            ManufacturerFactory ManufacturerFactory = new ManufacturerFactory(BaseUrl, Account, Password);
            Bukimedia.PrestaSharp.Entities.manufacturer Manufacturer = ManufacturerFactory.Get(6);
            Manufacturer.name = "Iron Maiden";
            Manufacturer.active = 1;
            ManufacturerFactory.Add(Manufacturer);
            ManufacturerFactory.Update(Manufacturer);
            ManufacturerFactory.Delete(Manufacturer);
        }
        
        public void CreateCategory()
        {
            Category categ = new Category().FillIn();
            category category = new category();
            category.AddName(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = categ.CategoryName[0]});
            //category.id_parent = 3; // This is the beginning category
            category.AddLinkRewrite(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = categ.CategoryName[0].Replace(" ","_").ToLowerInvariant() });
            category.active = 1;
            category.is_root_category = 0;
            //category.id_shop_default = 1;
            category.position = 1;
            category.AddDescription(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = categ.CategoryDescr});
            //category.AddMetaDescription(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "test_lang1" });
            //category.AddMetaKeywords(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "test_lang1" });
            //category.AddMetaTitle(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "test_lang1" });

            CategoryFactory Category = new CategoryFactory(BaseUrl, Account, Password);
            Category.Add(category);
        }

        public void CreateProduct()
        {
            Product prod = new Product().FillIn();
            product  product = new product();
            //product.id = 45;
            //product.active = 1;
           // product.reference = prod.ProductSku ;
            product.name.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language(1, prod.ProductName));
            product.condition = "new"; //new, used, refurbished
            product.AddLinkRewrite(new Bukimedia.PrestaSharp.Entities.AuxEntities.language( 1, prod.ProductSku));
           // product.id_category_default = 9;
            //product.price = 1541;
            product.show_price = 1;
            product.available_for_order = 1;

            ProductFactory pf = new ProductFactory(BaseUrl, Account, Password);

            pf.Add(product);
            
            string t = product.id.ToString();
            //category.AddMetaTitle(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "test_lang1" });

        }


    }
}