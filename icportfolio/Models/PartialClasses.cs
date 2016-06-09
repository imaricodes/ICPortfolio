using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace icportfolio
{

       [MetadataType(typeof(ProjectMetadata))]
       public partial class Project{}

        [MetadataType(typeof(TypeMetaData))]
        public partial class Type { }

    [MetadataType(typeof(ImageMetaData))]
    public partial class Image { }

    
}