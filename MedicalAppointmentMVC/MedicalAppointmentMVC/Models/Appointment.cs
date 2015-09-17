using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentMVC.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int app_id { get; set; }

        [Display(Name = "Patient")]
        [Required(ErrorMessage = "Patient")]
        public int patient_id { get; set; }

        [Display(Name = "Doctor")]
        [Required(ErrorMessage = "Doctor")]
        public int doctor_id { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Start Time")]
        public DateTime start_date_time { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = "End Time")]
        public DateTime end_date_time { get; set; }

        public virtual Patient_Detail Patient_Detail { get; set; }
        public virtual Doctor_Detail Doctor_Detail { get; set; }
    }
}