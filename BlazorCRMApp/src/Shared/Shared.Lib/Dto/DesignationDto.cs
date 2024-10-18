using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shared.Lib.Dto
{
    public class DesignationRequestDto
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Designation Name")]
        public string Name { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }

    public class DesignationResponseDto
    {
        public int Id { get; set; }


        [DisplayName("Designation Name")]
        public string Name { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public string CreatedDate { get; set; }

        public string ModifiedDate { get; set; }
    }

}
