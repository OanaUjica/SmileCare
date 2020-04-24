using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmileCare.Domain
{
    public class BillViewModel
    {
        [Display(Name = "Dentist")]
        public string DentistName { get; set; }

        [Display(Name = "Patient")]
        public string PatientName { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Restoration Type")]
        public RestorationType? RestorationType { get; set; }
    }
}
