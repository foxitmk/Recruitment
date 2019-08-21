using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Recruitment.Models
{
    [MetadataType(typeof(QuestionareAnswerMetadata))]
    public partial class QuestionareAnswer
    {
    }
    public partial class QuestionareAnswerMetadata
    {
        public int QuestionareAnswers_id { get; set; }
        [Required]
        public Nullable<int> Aplication_id { get; set; }
        [Required]
        public Nullable<int> RepositoryOfAnswers_id { get; set; }
        [Required]
        public Nullable<int> RepositoryOfQuestions_id { get; set; }

    }
}