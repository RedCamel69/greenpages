using greenpagesdirectory.domain.Entities;
using System.Collections.Generic;

namespace greenpagesdirectory.domain.Abstract
{
    public interface IListingRepository
    {
        IEnumerable<Listing> Listings { get; set; }
        IEnumerable<Listing> Search(string what, string where);
        Listing Details(int Id);
    }
}
