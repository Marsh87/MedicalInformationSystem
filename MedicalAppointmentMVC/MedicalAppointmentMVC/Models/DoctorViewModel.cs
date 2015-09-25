﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicalAppointmentMVC.Models
{
    public class DoctorViewModel:RegisterViewModel
    {
        public int doctor_id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string first_name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname is Required ")]
        public string surname { get; set; }

        [Display(Name = "Cell No")]
        [Required(ErrorMessage = "Cell No is Required")]
        public string cellno { get; set; }

        [Display(Name = "Tel No")]
        [Required(ErrorMessage = "Tel No is Required")]
        public string telno { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string address { get; set; }

        [Display(Name = "Post Code")]
        [Required(ErrorMessage = "Post Code is Required")]
        public string post_code { get; set; }

        [Display(Name = "Practice No")]
        [Required(ErrorMessage = "Practice No is Required")]
        public string med_practice_no { get; set; }

        [Display(Name = "Specialization")]
        [Required(ErrorMessage = "Specialization is Required")]
        public string specialization { get; set; }
    }
}