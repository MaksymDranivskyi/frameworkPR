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
            manufacturer Manufacturer = new manufacturer();
            Manufacturer.name = "Max Iron Maiden";
            Manufacturer.active = 1;
            ManufacturerFactory.Add(Manufacturer);
            
        }

        public void UpdateManufacturerById(int id)
        {
            ManufacturerFactory ManufacturerFactory = new ManufacturerFactory(BaseUrl, Account, Password);
            manufacturer Manufacturer = ManufacturerFactory.Get(id);
            Manufacturer.name = "Max Iron Maiden";
            Manufacturer.active = 1;
            ManufacturerFactory.Update(Manufacturer);

        }

        public void DeleteManufacturerById(int id)
        {
            ManufacturerFactory ManufacturerFactory = new ManufacturerFactory(BaseUrl, Account, Password);
            manufacturer Manufacturer = ManufacturerFactory.Get(id);
            ManufacturerFactory.Delete(Manufacturer);
        }

        public void CreateCustomer(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Profile profile = new Profile().FillIn();
                customer customer = new customer();
                customer.active = 1;
                customer.firstname = profile.FirstName;
                customer.lastname = profile.LastName;
                customer.email = profile.Email;
                customer.passwd = profile.Password;
                customer.id_shop_group = 1;
                customer.id_shop = 1;
                CustomerFactory Customer = new CustomerFactory(BaseUrl, Account, Password);
                Customer.Add(customer);
            }
        }


        public void CreateCategory(int number)
        {
            for (int i = 0; i < number; i ++)
            {
                Category categ = new Category().FillIn();
                category category = new category();
                category.name.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)1, categ.CategoryName[0]));
                category.id_parent = 2;
                category.link_rewrite.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)1, categ.CategoryName[0].Replace(" ", "-").ToLowerInvariant()));
                category.active = 1;
                category.is_root_category = 0;
                category.active = 1;
                category.description.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)1, categ.CategoryDescr));
                category.id_shop_default = 1;
                CategoryFactory Category = new CategoryFactory(BaseUrl, Account, Password);
                Category.Add(category);
            }
        }

        public void CreateProduct(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Product prod = new Product().FillIn();
                var product = new Bukimedia.PrestaSharp.Entities.product();
                product.active = 1;
                product.reference = prod.ProductSku;
                product.price = decimal.Round(prod.Price, 2);
                product.show_price = 1;
                product.available_for_order = 1;
                product.condition = "new";
                product.visibility = "both";
                product.minimal_quantity = 1;
                product.id_manufacturer = 6;
                product.is_virtual = 0;
                product.state = 1;
                product.cache_default_attribute = 0;
                product.id_category_default = 6;
                product.id_tax_rules_group = 1;
                product.redirect_type = "404";
                product.name.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)1, prod.ProductName));
                product.link_rewrite.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)1, prod.ProductSku));
                product.description.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)1, "<p>" + prod.ProductDescr + "</p>")); product.description_short.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)1, "<p>" + prod.ProductDescr + "</p>"));
                ProductFactory pf = new ProductFactory(BaseUrl, Account, Password);
                product = pf.Add(product);
            }
        }


    }
}