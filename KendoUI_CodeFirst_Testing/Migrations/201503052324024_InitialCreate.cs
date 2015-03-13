namespace KendoUI_CodeFirst_Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Library_LibraryId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Libraries", t => t.Library_LibraryId)
                .Index(t => t.Library_LibraryId);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        LibraryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LibraryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Library_LibraryId", "dbo.Libraries");
            DropIndex("dbo.Books", new[] { "Library_LibraryId" });
            DropTable("dbo.Libraries");
            DropTable("dbo.Books");
        }
    }
}
