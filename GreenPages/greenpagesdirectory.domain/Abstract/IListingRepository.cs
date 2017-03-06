using greenpagesdirectory.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenpagesdirectory.domain.Abstract
{
    public interface IListingRepository
    {
        IEnumerable<Listing> Listings { get; set; }
        IEnumerable<Listing> Search(string what, string where);
        Listing Details(int Id);
    }
}
