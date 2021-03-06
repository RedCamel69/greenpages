﻿using greenpagesdirectory.domain.Abstract;
using greenpagesdirectory.domain.Concrete;
using greenpagesdirectory.domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace greenpagesdirectory.api.Controllers
{
    public class ListingsController : ApiController
    {
        // GET: api/Listings
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<Listing> Get(string what, string where)
        {

            IListingRepository repo = new DevListingRepository();
            var res = repo.Search(what, where);

            return res;
        }


        // GET: api/Listings/5
        public Listing Get(int id)
        {
            IListingRepository repo = new DevListingRepository();
            var res = repo.Details(id);

            return res;
        }

        // POST: api/Listings
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Listings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Listings/5
        public void Delete(int id)
        {
        }
    }
}
