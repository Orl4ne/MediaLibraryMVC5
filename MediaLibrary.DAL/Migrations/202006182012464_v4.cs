namespace MediaLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Medias", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Medias", "Path", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Medias", "Path", c => c.String());
            AlterColumn("dbo.Medias", "Name", c => c.String());
        }
    }
}
