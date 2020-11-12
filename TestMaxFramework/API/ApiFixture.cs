using Newtonsoft.Json.Linq;
using RestSharp;
using NUnit.Framework;
using System.Linq;
using System.Net;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;
using WooCommerceNET.WooCommerce.v3.Extension;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Text;
namespace NUnitTestProject1.Tests
{
    public class ApiFixture
    {

        //    private string BaseUrl { get; set; }
        //    public static RestClient Client { get; set; }
        //    public RestRequest Request { get; set; }
        //    public IRestResponse Response { get; set; }
        //    public JObject ResponseJson { get; set; }


        //    class MyRestApi : RestAPI
        //    {
        //        public MyRestApi(string url, string key, string sacret, bool autorized = true,
        //            Func<string, string> jsonSerializeFilter = null,
        //            Func<string, string> jsonDeserializeFilter = null,
        //            Action<HttpWebRequest> requestFilter = null) : base(url, key, sacret, autorized, jsonSerializeFilter, jsonDeserializeFilter, requestFilter)
        //        {
        //        }

        //        public override T DeserializeJSon<T>(string jsonString)
        //        {
        //            return JsonConvert.DeserializeObject<T>(jsonString);
        //        }

        //        public override string SerializeJSon<T>(T t)
        //        {
        //            return JsonConvert.SerializeObject(t);
        //        }
        //    }

        //    public static async Task AddProductApi(string name, string desc, int price)
        //    {
        //        MyRestApi rest = new MyRestApi("http://127.0.0.1/wp/wordpress/wp-json/wc/v3", "ck_63f74ea0e36e03d3cccfb884d38fcfda45b80fe5", "cs_eea61cf0ba5b6b29f5e521389e08e16030fb6927");
        //        WCObject wc = new WCObject(rest);
        //        await Task.Run(async () =>
        //        {
        //            string nme = name;
        //            string dsc = desc;
        //            int prc = price;
        //            Product p = new Product()
        //            {
        //                name = nme,
        //                description = dsc,
        //                price = prc

        //            };
        //            await wc.Product.Add(p);

        //        });
        //    }




        //}



    }
}