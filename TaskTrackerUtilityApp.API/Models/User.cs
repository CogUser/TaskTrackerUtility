
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
        public string Password { get; set; }
        //public byte[] PasswordHash {get; set;}
        //public byte[] PasswordSalt {get; set;}
        [Required]
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }      
        public Role Role { get; set; }
        public int RoleId { get; set;  }
    }
}
