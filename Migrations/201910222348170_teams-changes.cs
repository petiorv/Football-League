namespace FootballLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamschanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teams", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "IsDeleted");
            DropColumn("dbo.Teams", "CreatedTime");
        }
    }
}
