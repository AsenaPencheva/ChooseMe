namespace ChooseMe.Web.Areas.Organization.Models.Photo
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class UploadPhotoViewModel
    {
        [Required(ErrorMessage= "You must select filr before hit upload!")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}