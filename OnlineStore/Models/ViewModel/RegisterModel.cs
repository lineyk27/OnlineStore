using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.ViewModel
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Surname{ get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(4)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(4)]
        public string ConfirmPassword { get; set; }

    }
}
