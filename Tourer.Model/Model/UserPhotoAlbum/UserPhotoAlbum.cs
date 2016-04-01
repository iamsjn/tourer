using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tourer.Model
{
    public class UserPhotoAlbum
    {
        public int UserPhotoAlbumID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int TouristAttractionID { get; set; }
        [Required]
        public int Privacy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public IEnumerable<UserAlbumPhoto> UserAlbumPhoto { get; set; }

    }
}