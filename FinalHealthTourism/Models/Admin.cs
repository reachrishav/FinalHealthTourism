using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalHealthTourism.Models
{
    public class Admin
    {
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* Enter ID")]
        [DisplayName("Admin Id")]
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}