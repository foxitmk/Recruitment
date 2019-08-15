using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Recruitment.Models
{
    [MetadataType(typeof(UserProfileMetadata))]

    public partial class UserProfile
    {
    }
    public partial class UserProfileMetadata
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public bool Enabled { get; set; }

    }
}