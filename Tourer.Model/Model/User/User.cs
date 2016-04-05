using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tourer.Model
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(500)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [MaxLength(500)]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        public string Photo { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public IEnumerable<GCM> GCM { get; set; }
    }
}


//enable-migrations -ContextProjectName Tourer.Model -StartUpProjectName Tourer.Model
//-ContextTypeName Tourer.Model.TourerContext -ProjectName Tourer.Main