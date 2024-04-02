namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Message", c => c.String());
            AddColumn("dbo.Contacts", "IsRead", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "IRead");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "IRead", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "IsRead");
            DropColumn("dbo.Contacts", "Message");
        }
    }
}
