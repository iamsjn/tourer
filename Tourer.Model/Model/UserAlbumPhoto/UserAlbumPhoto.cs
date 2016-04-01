using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tourer.Model
{
    public class UserAlbumPhoto
    {
        public int UserAlbumPhotoID { get; set; }
        [Required]
        public int UserPhotoAlbumID { get; set; }
        [Required]
        public string PhotoPath { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual UserPhotoAlbum UserPhotoAlbum { get; set; }
    }
}