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
    
    public partial class QuestionareQuestion
    {
        public int QuestionareQuestions_id { get; set; }
        public Nullable<int> Questionare_id { get; set; }
        public Nullable<int> RepositoryOfQuestions_id { get; set; }
    
        public virtual Questionare Questionare { get; set; }
        public virtual RepositoryOfQuestion RepositoryOfQuestion { get; set; }
    }
}