using System;
using System.Configuration;
using System.Data.Entity;

namespace GreenPagesBlog
{
    public class BlogContextInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var initData = Convert.ToBoolean(ConfigurationManager.AppSettings["InitData"]);
            if (initData)
            {
                //var post
            }
        }
    }
}
