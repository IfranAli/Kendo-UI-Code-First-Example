namespace KendoUI_CodeFirst_Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLibraryLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Libraries", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Libraries", "Location");
        }
    }
}
