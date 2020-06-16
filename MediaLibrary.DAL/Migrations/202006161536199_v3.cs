namespace MediaLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MediaEFs", newName: "Medias");
            DropTable("dbo.MediaTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MediaTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            RenameTable(name: "dbo.Medias", newName: "MediaEFs");
        }
    }
}
