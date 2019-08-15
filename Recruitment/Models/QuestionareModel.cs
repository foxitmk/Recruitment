using System;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.Models
{
    [MetadataType(typeof(QuestionareMetadata))]
    public partial class Questionare
    {
    }
    public partial class QuestionareMetadata
    {
        public int Questionare_id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

    

