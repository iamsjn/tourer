using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tourer.Model
{
    public class GCM
    {
        public int GCMID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public string GCMNo { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual User User { get; set; }
    }
}