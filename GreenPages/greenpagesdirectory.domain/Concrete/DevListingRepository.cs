using greenpagesdirectory.domain.Abstract;
using greenpagesdirectory.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenpagesdirectory.domain.Concrete
{
    public class DevListingRepository : IListingRepository
    {
        public IEnumerable<Entities.Listing> Listings
        {
            get
            {
                return new List<Listing> {
                    new Listing {
                        ListingID=1,
                        ListingName="Golf Club 1",
                        Phone="4445555444",Email ="Dummy@GolfClub1.com",
                        PostCode="DUM54R",
                        Latitude=52.9318444086802,
                        Longitude=-1.47089800865272,
                        Distance=0.01,
                         Address="Pudding Lane",
                          Town="Winchester",
                           County="Hampshire",
                           Heading="Plumber"
                    },
                    new Listing { ListingID=2, ListingName="Dummy Plumber 2", Heading="Plumber", Phone="4445555444",Email ="Dummy@Dummy.com",PostCode="DUM54R",Latitude=52.9318444086802,Longitude=-1.47577379207529,Distance=1.2},
                    new Listing { ListingName="Dummy Plumber 3", Heading="Plumber", Phone="4445555444",Email ="Dummy@Dummy.com",PostCode="DUM54R",Latitude=52.9318444086802,Longitude=-1.47589800865272, Distance=0.988},
                    new Listing { ListingName="Dummy Plumber 4", Heading="Plumber", Latitude=52.9318444086802,Longitude=-1.47677379207529},
                    new Listing { ListingName="Dummy Plumber 5", Heading="Plumber", Latitude=52.9318444086802,Longitude=-1.47589800865272},
                    new Listing { ListingName="Dummy Plumber 6", Heading="Plumber", Latitude=52.9318444086802,Longitude=-1.47089800865272},
                    new Listing { ListingName="Dummy Plumber 7", Heading="Plumber", Latitude=52.9318444086802,Longitude=-1.47577379207529},
                    new Listing { ListingName="Dummy Plumber 8", Latitude=52.9318444086802,Longitude=-1.47589800865272},
                    new Listing { ListingName="Dummy Plumber 9", Latitude=52.9318444086802,Longitude=-1.47677379207529},
                    new Listing { ListingName="Dummy Plumber 10", Latitude=52.9318444086802,Longitude=-1.47589800865272},
                    new Listing { ListingName="Dummy Plumber 11", Latitude=52.9318444086802,Longitude=-1.47677379207529}

                }.AsQueryable();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public IEnumerable<Listing> Search(string what, string where)
        {
            // use from client
            /*
             *             List<Listing> listings = new List<Listing>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51149/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/values");
                if (response.IsSuccessStatusCode)
                {

                    //get data as Json string 
                    string data = await response.Content.ReadAsStringAsync();
                    //use JavaScriptSerializer from System.Web.Script.Serialization
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    //deserialize to your class
                    listings = JSserializer.Deserialize<List<Listing>>(data);


                }
            }

            return listings;
*/

            //List<Listing> listings = new List<Listing>();



            var res = Listings
                .Where(x => x.Heading == "Plumber")
                .OrderBy(x => x.Distance);

            int displayOrder = 1;
            foreach (Listing l in res)
            {
                l.DisplayOrder = displayOrder;
                displayOrder++;
            }

            return res;
        }





        public Listing Details(int Id)
        {
            return Listings
                .Where(x => x.ListingID == Id)
                .First();
        }
    }
}
