using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recruitment.Models
{

    [MetadataType(typeof(AplicationMetadata))]
    public partial class Aplication
    {
    }
    public partial class AplicationMetadata
    {

        public int Aplication_id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        /*[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] */
        [Editable(false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime DateOfBirth { get; set; }
        [Required]
        public int Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public byte[] CV { get; set; }
        public Nullable<bool> Accepted { get; set; }
        public Nullable<int> OpenJobs_id { get; set; }
        public Nullable<int> WorkPosition_id { get; set; }

    }
}
