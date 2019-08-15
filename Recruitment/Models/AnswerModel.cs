using System.ComponentModel.DataAnnotations;


namespace Recruitment.Models
{
    [MetadataType(typeof(AnswerMetadata))]

    public partial class Answer
    {
    }
    public partial class AnswerMetadata
    {
        public int Answers_id { get; set; }
        public string Desrciption { get; set; }

    }


}