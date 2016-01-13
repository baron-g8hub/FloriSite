using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFlorist.DataAccessLayer;

namespace MFlorist.BusinessLogicLayer
{
    public class User
    {

        public int Id { get; set; }

        [StringLength(6, MinimumLength = 5, ErrorMessage = "5-6 char allowed!")]
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]

        public string Username { get; set; }

        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
   
        public System.DateTime RegDate { get; set; }
        public string Email { get; set; }

    }
}
