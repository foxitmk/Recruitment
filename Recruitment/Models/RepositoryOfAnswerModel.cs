using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Recruitment.Models
{
    [MetadataType(typeof(RepositoryOfAnswerMetadata))]

    public partial class RepositoryOfAnswer
    {
    }
    public partial class RepositoryOfAnswerMetadata
    {

        public int RepositoryOfAnswers_id { get; set; }
        [Required]
        public Nullable<int> Answers_id { get; set; }
        [Required]
        public string Description { get; set; }


    }
}