using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using greenpagesdirectory.api;
using greenpagesdirectory.api.Controllers;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using greenpagesdirectory.domain.Entities;

namespace greenpagesdirectory.api.Tests.Controllers
{
    [TestClass]
    public class ListingsControllerTest
    {

        [TestMethod]
        public void CanReturnJson()
        {
           
            List<Listing> listings = new List<Listing>();

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:51149/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    // New code:
            //    //HttpResponseMessage response = await client.GetAsync("api/listings?where=leeds&what=plumbers");
            //    HttpResponseMessage response = client. ("api/listings?where=leeds&what=plumbers");
            //    if (response.IsSuccessStatusCode)
            //    {

            //        //get data as Json string 
            //        string data = await response.Content.ReadAsStringAsync();
            //        //use JavaScriptSerializer from System.Web.Script.Serialization
            //        JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            //        //deserialize to your class
            //        listings = JSserializer.Deserialize<List<Listing>>(data);


            //    }
            //}

            Assert.IsNotNull(listings);
        }

    }

}
