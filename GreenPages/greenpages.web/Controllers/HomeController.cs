using GreenPages.Web.Viewmodels;
using GreenPagesBlog;
using GreenPagesBlog.Domain.Repositories;
using GreenPagesBlog.Repositories;
using greenpagesdirectory.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GreenPages.WEb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _repository;

        public HomeController()
        {//dummy
            _repository = new BlogRepository(new BlogContext());
        }

        public HomeController(IBlogRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            //Post p = new Post() { Category = new Category() { Description = "WW" } };

            //List<Post> result = new List<Post>();
            //result.Add(p);
            var result = _repository.Posts().OrderByDescending(x => x.PostedOn).Take(3).ToList();
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public async Task<ActionResult> Search()
        {
            List<Listing> listings = new List<Listing>();

            using (var client = new HttpClient())
            {
                //need api running!
                client.BaseAddress = new Uri("http://localhost:51089/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/listings?where=leeds&what=plumbers");
                //HttpResponseMessage response = client. ("api/listings?where=leeds&what=plumbers");
                if (response.IsSuccessStatusCode)
                {

                    //get data as Json string 
                    string data = await response.Content.ReadAsStringAsync();
                    //use JavaScriptSerializer from System.Web.Script.Serialization
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    //deserialize to your class
                    listings = JSserializer.Deserialize<List<Listing>>(data);


                }
                if (!response.IsSuccessStatusCode)
                {
                    var res = response.StatusCode;
                }
                //}


            }

            SearchViewmodel vm = new SearchViewmodel();
            vm.Listings = listings;
            return View(vm);
        }
    }
}