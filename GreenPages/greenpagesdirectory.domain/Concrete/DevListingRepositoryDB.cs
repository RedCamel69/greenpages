using greenpagesdirectory.domain.Abstract;
using greenpagesdirectory.domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenpagesdirectory.domain.Concrete
{
    public class DevListingRepositoryDB : IListingRepository
    {
        public IEnumerable<Entities.Listing> Listings
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Entities.Listing> Search(string what, string where)
        {
            List<Listing> listings = new List<Listing>();

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            //conn.ConnectionString = @"Data Source=RedCamel-PC\SQLEXPRESS;Initial Catalog=ProjectDirectory;Integrated Security=SSPI;";

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PluginBlogConnection"].ConnectionString;


            System.Data.SqlClient.SqlCommand com = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader rdr;
            com.Connection = conn;

            conn.Open();

            Console.WriteLine(conn.State);


            com.CommandType = System.Data.CommandType.StoredProcedure;
            // com.CommandText = "Insert into Search ('ListingID','ListingName') values " + listing.ListingID + ", " + "'" + listing.ListingName + "'";
            com.CommandText = "spSearch1"; //"spSearch1_dayfiltered_1"

            System.Data.SqlClient.SqlParameter param = new SqlParameter("what", System.Data.SqlDbType.VarChar);
            param.Value = what;
            com.Parameters.Add(param);

            System.Data.SqlClient.SqlParameter param2 = new SqlParameter("where", System.Data.SqlDbType.VarChar);
            param2.Value = where;
            com.Parameters.Add(param2);


            Console.WriteLine(com.CommandText);

            int displayOrder = 0;

            // execute the command
            rdr = com.ExecuteReader();

            // iterate through results, printing each to console
            while (rdr.Read())
            {
                displayOrder++;

                listings.Add(new Listing()
                {

                    DisplayOrder = displayOrder,
                    ListingName = rdr["ListingName"].ToString(),
                    Town = rdr["Town"].ToString(),
                    Latitude = Convert.ToDouble(rdr["Latitude"].ToString()),
                    Longitude = Convert.ToDouble(rdr["Longitude"].ToString()),
                    ListingID = Convert.ToInt64(rdr["ListingID"]),
                    Address = rdr["Address"].ToString(),
                    PostCode = rdr["Postcode"].ToString(),
                    Phone = rdr["Phone"].ToString(),
                    County = rdr["County"].ToString(),
                    Heading = rdr["Heading"].ToString(),
                    Distance = Convert.ToDouble(rdr["Distance"].ToString())
                });

            }


            conn.Close();





            return listings.AsEnumerable<Listing>();
        }





        public Listing Details(int Id)
        {

            Listing res = new Listing();

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            //conn.ConnectionString = @"Data Source=RedCamel-PC\SQLEXPRESS;Initial Catalog=ProjectDirectory;Integrated Security=SSPI;";

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PluginBlogConnection"].ConnectionString;



            System.Data.SqlClient.SqlCommand com = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader rdr;
            com.Connection = conn;

            conn.Open();

            Console.WriteLine(conn.State);


            com.CommandType = System.Data.CommandType.StoredProcedure;
            // com.CommandText = "Insert into Search ('ListingID','ListingName') values " + listing.ListingID + ", " + "'" + listing.ListingName + "'";
            com.CommandText = "spSearch1Details"; //"spSearch1_dayfiltered_1"

            System.Data.SqlClient.SqlParameter param = new SqlParameter("whichListing", System.Data.SqlDbType.Int);
            param.Value = Id;
            com.Parameters.Add(param);



            Console.WriteLine(com.CommandText);

            //int displayOrder = 0;

            // execute the command
            rdr = com.ExecuteReader();

            // iterate through results, printing each to console
            while (rdr.Read())
            {
                //displayOrder++;

                res.ListingName = rdr["ListingName"].ToString();
                res.Town = rdr["Town"].ToString();
                res.Latitude = Convert.ToDouble(rdr["Latitude"].ToString());
                res.Longitude = Convert.ToDouble(rdr["Longitude"].ToString());
                res.ListingID = Convert.ToInt64(rdr["ListingID"]);
                res.Address = rdr["Address"].ToString();
                res.PostCode = rdr["Postcode"].ToString();
                res.Phone = rdr["Phone"].ToString();
                res.County = rdr["County"].ToString();
                res.Heading = rdr["Heading"].ToString();
                //res.Distance = Convert.ToDouble(rdr["Distance"].ToString());

            }


            conn.Close();





            return res;

        }
    }
}
