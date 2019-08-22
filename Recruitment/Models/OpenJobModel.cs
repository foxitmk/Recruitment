using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Recruitment.Models
{
    [MetadataType(typeof(OpenJobMetadata))]
    public partial class OpenJob
    {
    }
    public partial class OpenJobMetadata
    {

        public int OpenJobs_id { get; set; }
        [Required]
        public int WorkPosition_id { get; set; }
        [Required]
        public string Conditions { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public Nullable<System.DateTime> ValidFrom { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public Nullable<System.DateTime> ValidTo { get; set; }
        [Required]
        public Nullable<int> Questionare_id { get; set; }


    }
}