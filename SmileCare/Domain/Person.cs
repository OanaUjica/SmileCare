﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmileCare.Domain
{
    public abstract class Person : Entity
    {


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
                return FirstName + " " + LastName;
            }
        }


        public ICollection<Case> Cases { get; set; }
    }
}
