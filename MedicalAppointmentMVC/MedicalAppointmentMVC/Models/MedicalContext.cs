using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MedicalAppointmentMVC.Models
{
    public class MedicalContext : DbContext
    {
        public MedicalContext()
            : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MedicalContext>());
        }
        public System.Data.Entity.DbSet<MedicalAppointmentMVC.Models.Patient_Detail> Patient_Details { get; set; }
        public System.Data.Entity.DbSet<MedicalAppointmentMVC.Models.Doctor_Detail> Doctor_Details { get; set; }
        public System.Data.Entity.DbSet<MedicalAppointmentMVC.Models.Nurse_Detail> Nurse_Details { get; set; }
        public System.Data.Entity.DbSet<MedicalAppointmentMVC.Models.Patient_Medical_History> Patients_Medical_History { get; set; }
        public System.Data.Entity.DbSet<MedicalAppointmentMVC.Models.Appointment> Appointments { get; set; }       
    }
}