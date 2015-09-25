using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MedicalAppointmentMVC.Migrations
{
    public partial class _112 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor_Detail", "Email", c => c.String(nullable: false));
        }
        public override void Down()
        {
            DropColumn("dbo.Doctor_Detail", "Email");
        }
    }
}