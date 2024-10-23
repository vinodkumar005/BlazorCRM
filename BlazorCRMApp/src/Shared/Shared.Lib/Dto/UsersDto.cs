using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shared.Lib.Dto
{
    public class UsersDto
    {
        public long? Id { get; set; }
        //public string SignUpAdmin { get; set; }

        public Guid? UserLoginId { get; set; }

        [Required(ErrorMessage = "'First Name' is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = null!;

        [DisplayName("Last Name")]
        public string? LastName { get; set; }


        [DisplayName("Email Address")]
        [Required(ErrorMessage = "'Email Address' is required")]
        [EmailAddress(ErrorMessage = "Please enter valid email.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid email.")]

        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "'Mobile No' is required")]
        [DisplayName("Mobile No")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; } = null!;

        [DisplayName("Date Of Birth")]

        public DateTime? Dob { get; set; }

        //public string? Dob { get; set; }

        public string? ShortUrl { get; set; }

        //public string Logo { get; set; }

        //public byte Status { get; set; }
        [Required(ErrorMessage = "'Country' is required")]
        [DisplayName("Country")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "'State' is required")]
        [DisplayName("State")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "'City' is required")]
        [DisplayName("City")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "'ZipCode' is required")]
        [DisplayName("ZipCode")]
        public string ZipCode { get; set; } = null!;

        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address")]
        public string Address { get; set; } = null!;

        //public DateTime CreateDate { get; set; }

        //public DateTime ModifyDate { get; set; }

        public string BodyBackGroundColor { get; set; } = "white";

        //public string HeaderBackGroundColor { get; set; }

        //public string NavigationBackGroundColor { get; set; }

        //public string NavigationtextColor { get; set; }

        //public string SubNavigationBgcolor { get; set; }

        //public string FooterBackGroundColor { get; set; }

        //public string FooterTitleColor { get; set; }

        //public string FooterTextColorH { get; set; }

        //public string NavigationtextSize { get; set; }

        //public string FooterTitleTextSize { get; set; }

        //public string FacebookLink { get; set; }

        //public string TwitterLink { get; set; }

        //public string LinkedInLink { get; set; }

        //public string GooglePlusLink { get; set; }
        //[DisplayName("Profile Picture")]
        //// [FileTypes("jpg,jpeg,png")]
        ////public IFormFile ProfilePic { get; set; }

        //public long? LeadStoreFilterId { get; set; }

        [DisplayName("Time Zone")]
        public byte? TimeZoneId { get; set; }
        //[Required(ErrorMessage = "'Designation' is required")]
        public long? DesignationId { get; set; }

        //[Required(ErrorMessage = "'Colour' is required")]
        public string? Colour { get; set; }

        //[Required(ErrorMessage = "'Parent' is required")]
        public Guid? ParentId { get; set; }

        [Required(ErrorMessage = "'Password' is required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]

        public string Password { get; set; } = null!;

        //public string Role { get; set; }

        //public int CountLeads { get; set; }


        //public string Designations { get; set; }
        //public string Parents { get; set; }



        //public string ProfilePicName { get; set; }
        //public string DesignationName { get; set; }
        //public string ParentName { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; } = false;

        [DisplayName("Verified")]
        public bool IsVerified { get; set; } = false;

        public bool FormType { get; set; } = false;
        //public string CountryName { get; set; }
        //public string StateName { get; set; }
        //public string CityName { get; set; }
        //public string TimeZone { get; set; }

        //public bool IsValid { get; set; }
        //public string BulkNote { get; set; }

        //public string Parent { get; set; }
    }

    //public class FileTypesAttribute : ValidationAttribute
    //{
    //    private readonly List<string> _types;

    //    public FileTypesAttribute(string types)
    //    {
    //        _types = types.Split(',').ToList();
    //    }

    //    public override bool IsValid(object value)
    //    {
    //        if (value == null) return true;

    //        var fileExt = System.IO
    //                            .Path
    //                            .GetExtension((value as
    //                                     IFormFile).FileName).Substring(1);
    //        return _types.Contains(fileExt, StringComparer.OrdinalIgnoreCase);
    //    }

    //    public override string FormatErrorMessage(string name)
    //    {
    //        return string.Format("Invalid file type. Only the following types {0} are supported.", String.Join(", ", _types));
    //    }
    //}

    public class Root
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public List<Sub> subs { get; set; }
    }

    public class Sub
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public List<Sub> subs { get; set; }
    }


}
