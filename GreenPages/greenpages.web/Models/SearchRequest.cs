using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenPages.Web.Models
{
    public class SearchRequest
    {
        [Required]
        [DisplayName("I'm looking for")]
        public string What { get; set; }
        [Required]
        [DisplayName("In")]
        public string Where { get; set; }
    }
}