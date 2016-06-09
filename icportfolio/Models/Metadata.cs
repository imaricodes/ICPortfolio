using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace icportfolio
{

    public class ProjectMetadata
    {

        [Display(Name = "Project")]
        public string name { get; set; }
        [Display(Name = "Summary")]
        public string summary { get; set; }
        [Display(Name = "ASP.NET")]
        public bool ASP_NET { get; set; }
        [Display(Name ="DB First")]
        public bool DB_First { get; set; }
        [Display(Name ="Code First")]
        public bool Code_First { get; set; }
    }

    public class TypeMetaData
    {
        [Display(Name = "Type")]
        public string type1 { get; set; }
    }

    public class ImageMetaData
    {
        [Display(Name = "Image Name")]
        public string name { get; set; }

        [Display(Name = "Decription")]
        public string description { get; set; }

        [Display(Name = "Image URL")]
        public string url { get; set; }

    }


}