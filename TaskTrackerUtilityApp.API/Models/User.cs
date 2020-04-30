
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskTrackerUtilityApp.API.Models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "min 6, max 50 letters")]
        public string Password { get; set; }
        //public byte[] PasswordHash {get; set;}
        //public byte[] PasswordSalt {get; set;}
        [Required]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }      
        public Role Role { get; set; }
        public int RoleId { get; set;  }
    }
}
