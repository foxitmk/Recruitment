//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recruitment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RepositoryOfAnswer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RepositoryOfAnswer()
        {
            this.QuestionareAnswers = new HashSet<QuestionareAnswer>();
        }
    
        public int RepositoryOfAnswers_id { get; set; }
        public Nullable<int> Answers_id { get; set; }
        public string Description { get; set; }
    
        public virtual Answer Answer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionareAnswer> QuestionareAnswers { get; set; }
    }
}
