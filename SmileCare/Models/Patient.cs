using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmileCare.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }


        public ICollection<Case> Cases { get; set; }

    }
}
