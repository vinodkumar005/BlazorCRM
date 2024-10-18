using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shared.Lib.Dto
{

    public class UsersDto
    {
        public long Id { get; set; }

        public Guid UserLoginId { get; set; }

        [Required(ErrorMessage = "'First Name' is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
      
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "'Email Address' is required")]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "'Mobile No' is required")]
        [DisplayName("Mobile No")]
        public string Mobile { get; set; }

        [DisplayName("Date Of Birth")]
        [Required(ErrorMessage = "'Date Of Birth' is required")]
        public DateTime? Dob { get; set; }     

        public string ShortUrl { get; set; }

        public string Logo { get; set; }

        public byte Status { get; set; }
        [Required(ErrorMessage = "'State' is required")]
        [DisplayName("State")]
        public int? StateId { get; set; }
        [Required(ErrorMessage = "'City' is required")]
        [DisplayName("City")]
        public string City { get; set; }
        [Required(ErrorMessage = "'ZipCode' is required")]
        [DisplayName("ZipCode")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "'Address' is required")]
        [DisplayName("Address")]
        public string Address { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public string BodyBackGroundColor { get; set; }

        public string HeaderBackGroundColor { get; set; }

        public string NavigationBackGroundColor { get; set; }

        public string NavigationtextColor { get; set; }

        public string SubNavigationBgcolor { get; set; }

        public string FooterBackGroundColor { get; set; }

        public string FooterTitleColor { get; set; }

        public string FooterTextColorH { get; set; }

        public string NavigationtextSize { get; set; }

        public string FooterTitleTextSize { get; set; }

        public string FacebookLink { get; set; }

        public string TwitterLink { get; set; }

        public string LinkedInLink { get; set; }

        public string GooglePlusLink { get; set; }
        [DisplayName("Profile Picture")]
        //public IFormFile ProfilePic { get; set; }

        public long? LeadStoreFilterId { get; set; }
               
        [DisplayName("Time Zone")]
        public byte? TimeZoneId { get; set; }
        [Required(ErrorMessage = "'DesignationId' is required")]
        public long? DesignationId { get; set; }
        //[Required(ErrorMessage = "'ParentId' is required")]
        public Guid? ParentId { get; set; }

        [Required(ErrorMessage = "'Password' is required")]
        [DisplayName("Password")]
        public string Password { get; set; }

        public string Role { get; set; }

        public List<SelectListDto> StateList { get; set; }

        public List<SelectListDto> DesignationList { get; set; }
        //public List<SelectListItem> ParentList { get; set; }
        public List<SelectListDto> TimeZoneList { get; set; }

        public string ProfilePicName { get; set; }
        public string DesignationName { get; set; }
        public string ParentName { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; }
        [DisplayName("Verified")]
        public bool IsVerified { get; set; }

        public bool FormType { get; set; }
        public string StateName { get; set; }
        public string TimeZone { get; set; }

        public bool IsValid { get; set; }
        public string BulkNote { get; set; }
    }

    public class UserParentDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<UserParentDto> subs { get; set; }
    }

}
