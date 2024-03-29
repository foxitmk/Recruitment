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
    
    public partial class Aplication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aplication()
        {
            this.QuestionareAnswers = new HashSet<QuestionareAnswer>();
        }
    
        public int Aplication_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public byte[] CV { get; set; }
        public Nullable<bool> Accepted { get; set; }
        public Nullable<int> OpenJobs_id { get; set; }
        public Nullable<int> WorkPosition_id { get; set; }
    
        public virtual OpenJob OpenJob { get; set; }
        public virtual WorkPosition WorkPosition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionareAnswer> QuestionareAnswers { get; set; }
    }
}
