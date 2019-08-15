using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Recruitment.Models
{
    [MetadataType(typeof(RepositoryOfQuestionMetadata))]

    public partial class RepositoryOfQuestion
    {
    }
    public partial class RepositoryOfQuestionMetadata
    {
        public int RepositoryOfQuestions_id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Nullable<int> Answer_id { get; set; }


    }
}