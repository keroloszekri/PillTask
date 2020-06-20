namespace Pill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hyuddd : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pills", newName: "Fats");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Fats", newName: "Pills");
        }
    }
}
