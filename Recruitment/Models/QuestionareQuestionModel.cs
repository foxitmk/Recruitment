using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Recruitment.Models
{
    [MetadataType(typeof(QuestionareQuestionMetadata))]

    public partial class QuestionareQuestion
    {
    }
    public partial class QuestionareQuestionMetadata
    {
        public int QuestionareQuestions_id { get; set; }
        [Required]
        public Nullable<int> Questionare_id { get; set; }
        [Required]
        public Nullable<int> RepositoryOfQuestions_id { get; set; }

    }
}