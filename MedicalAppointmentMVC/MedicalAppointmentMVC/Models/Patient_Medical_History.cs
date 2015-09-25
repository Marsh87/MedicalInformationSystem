using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentMVC.Models
{
    public class Patient_Medical_History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int med_hist_id { get; set; }

        [Display(Name = "Patient")]
        [Required(ErrorMessage = "Patient is Required")]
        public int patient_id { get; set; }

        [Display(Name = "Diagnosis")]
        [Required(ErrorMessage = "Diagnosis is Required")]
        public string diagnosis { get; set; }

        [Display(Name = "Blood Sugar Level")]
        [Required(ErrorMessage = "Blood Sugar Level is Required")]
        public string blood_sugar_level { get; set; }

        [Display(Name = "Cholesterol Rating")]
        [Required(ErrorMessage = "Cholesterol Rating is Required")]
        public string cholesterol_rating { get; set; }

        [Display(Name = "Blood Pressure")]
        [Required(ErrorMessage = "Blood Pressure is Required")]
        public string blood_pressure { get; set; }

        [Display(Name = "Recommendation")]
        [Required(ErrorMessage = "Recommendation is Required")]
        public string recommendation { get; set; }

        public virtual Patient_Detail Patient_Detail { get; set; }
    }
}
