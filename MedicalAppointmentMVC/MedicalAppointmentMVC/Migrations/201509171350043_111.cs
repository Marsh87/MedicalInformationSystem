namespace MedicalAppointmentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _111 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        app_id = c.Int(nullable: false, identity: true),
                        patient_id = c.Int(nullable: false),
                        doctor_id = c.Int(nullable: false),
                        start_date_time = c.DateTime(nullable: false),
                        end_date_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.app_id)
                .ForeignKey("dbo.Doctor_Detail", t => t.doctor_id, cascadeDelete: true)
                .ForeignKey("dbo.Patient_Detail", t => t.patient_id, cascadeDelete: true)
                .Index(t => t.patient_id)
                .Index(t => t.doctor_id);
            
            CreateTable(
                "dbo.Doctor_Detail",
                c => new
                    {
                        doctor_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        cellno = c.String(nullable: false),
                        telno = c.String(nullable: false),
                        address = c.String(nullable: false),
                        post_code = c.String(nullable: false),
                        med_practice_no = c.String(nullable: false),
                        specialization = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.doctor_id);
            
            CreateTable(
                "dbo.Patient_Detail",
                c => new
                    {
                        patient_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        cellno = c.String(nullable: false),
                        telno = c.String(nullable: false),
                        address = c.String(nullable: false),
                        post_code = c.String(nullable: false),
                        med_aid_no = c.String(),
                        med_aid_dep_no = c.String(),
                    })
                .PrimaryKey(t => t.patient_id);
            
            CreateTable(
                "dbo.Nurse_Detail",
                c => new
                    {
                        nurse_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        cellno = c.String(nullable: false),
                        telno = c.String(nullable: false),
                        address = c.String(nullable: false),
                        post_code = c.String(nullable: false),
                        med_practice_no = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.nurse_id);
            
            CreateTable(
                "dbo.Patient_Medical_History",
                c => new
                    {
                        med_hist_id = c.Int(nullable: false, identity: true),
                        patient_id = c.Int(nullable: false),
                        diagnosis = c.String(nullable: false),
                        blood_sugar_level = c.String(nullable: false),
                        cholesterol_rating = c.String(nullable: false),
                        blood_pressure = c.String(nullable: false),
                        recommendation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.med_hist_id)
                .ForeignKey("dbo.Patient_Detail", t => t.patient_id, cascadeDelete: true)
                .Index(t => t.patient_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient_Medical_History", "patient_id", "dbo.Patient_Detail");
            DropForeignKey("dbo.Appointments", "patient_id", "dbo.Patient_Detail");
            DropForeignKey("dbo.Appointments", "doctor_id", "dbo.Doctor_Detail");
            DropIndex("dbo.Patient_Medical_History", new[] { "patient_id" });
            DropIndex("dbo.Appointments", new[] { "doctor_id" });
            DropIndex("dbo.Appointments", new[] { "patient_id" });
            DropTable("dbo.Patient_Medical_History");
            DropTable("dbo.Nurse_Detail");
            DropTable("dbo.Patient_Detail");
            DropTable("dbo.Doctor_Detail");
            DropTable("dbo.Appointments");
        }
    }
}
