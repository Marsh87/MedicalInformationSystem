using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentMVC.Models
{
    public class Nurse_Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nurse_id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name")]
        public string first_name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname")]
        public string surname { get; set; }

        [Display(Name = "Cell No")]
        [Required(ErrorMessage = "Cell No")]
        public string cellno { get; set; }

        [Display(Name = "Tel No")]
        [Required(ErrorMessage = "Tel No")]
        public string telno { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address")]
        public string address { get; set; }

        [Display(Name = "Post Code")]
        [Required(ErrorMessage = "Post Code")]
        public string post_code { get; set; }

        [Display(Name = "Practice No")]
        [Required(ErrorMessage = "Practice No")]
        public string med_practice_no { get; set; }
    }
}