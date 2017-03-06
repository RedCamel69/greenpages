using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenpagesdirectory.domain.Entities
{
    public class Listing
    {
        public int DisplayOrder { get; set; }
        public long ListingID { get; set; }
        public string ListingName { get; set; }
        public int CustomerNumber { get; set; }
        public int HeadingID { get; set; }
        public string Heading { get; set; }
        public int HeadingCategoryID { get; set; }
        public string HeadingCategoryDescription { get; set; }
        public int ListingType { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public int LocalityID { get; set; }
        public string Town { get; set; }
        public int TownID { get; set; }
        public string County { get; set; }
        public int CountyID { get; set; }
        public string PostCode { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Phone { get; set; }
        public string WebPage { get; set; }
        public string Email { get; set; }

        public double Distance { get; set; } //distance of listing from search location
    }
}
