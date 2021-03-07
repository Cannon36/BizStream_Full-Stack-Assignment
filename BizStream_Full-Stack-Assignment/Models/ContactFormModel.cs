using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BizStream_Full_Stack_Assignment.Models
{
    public class ContactFormModel
    {
        [Required (ErrorMessage = "Please Enter your first name.")]
        public string FirstName { get; set; }
        [Required (ErrorMessage = "Please Enter your last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter your Email address.")]
        [EmailAddress (ErrorMessage = "Please Enter a valid Email address.")]
        public string Email { get; set; }
        [Required (ErrorMessage = "Please write a message before sending.")]
        public string Message { get; set; }
    }
}
