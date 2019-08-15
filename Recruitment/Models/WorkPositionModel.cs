using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Recruitment.Models
{
    [MetadataType(typeof(WorkPositionMetadata))]

    public partial class WorkPosition
    {
    }
    public partial class WorkPositionMetadata
    {
        public int WorkPosition_id { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string LongDescription { get; set; }

    }
}