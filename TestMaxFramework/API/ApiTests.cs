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
using RestSharp;
using System.Linq;
using System.Net;
public class ApiTests 
    {

    
        [Test]
        [Author("Maksym Dramivskyi")]
        [Category("API test")]
    public void TestAPI()
    {
       
            // Initialize();
             string BaseUrl = "http://localhost/prestashop_1.7.6.8/api";
             string Account = "VR6A6NS7VIDKM6D66YU37ACJ7HXPYPV4";
             string Password = "";
           //ManufacturerFactory ManufacturerFactory = new ManufacturerFactory(BaseUrl, Account, Password);
        //List <manufacturer> manufacturers = ManufacturerFactory.GetAll();

        //manufacturer Manufacturer =  ManufacturerFactory.Get(3);
        //manufacturer man = new manufacturer();
        //Manufacturer.name = "Iron Maiden";
        //Manufacturer.active = 1;
        //ManufacturerFactory.Add(Manufacturer);
        //////ManufacturerFactory.Update(Manufacturer);
        // ManufacturerFactory.Delete(Manufacturer);

        //manufacturer man = new manufacturer();
        //man.name = "Iron Maiden";
        //man.active = 1;


        //Manufacturer.description = new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "description" };

        //ManufacturerFactory.Add(man);
        //ManufacturerFactory.Update(Manufacturer);

        category category = new category();
        category.AddName(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "Lang 1" });
        //category.AddName(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 2, Value = "Lang 2" });
        category.id_parent = 3; // This is the beginning category
        category.AddLinkRewrite(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "test_lang1" });
        //category.AddLinkRewrite(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 2, Value = "test_lang2" });
        category.active = 1;
        category.is_root_category = 0;
        category.id_shop_default = 1;
        category.position = 1;
        //category.AddDescription(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "description" });
        //category.AddMetaDescription(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "test_lang1" });
        //category.AddMetaKeywords(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "test_lang1" });
        //category.AddMetaTitle(new Bukimedia.PrestaSharp.Entities.AuxEntities.language { id = 1, Value = "test_lang1" });

        CategoryFactory Category = new CategoryFactory(BaseUrl, Account, Password);
        Category.Add(category);
    }


    }

