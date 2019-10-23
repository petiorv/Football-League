namespace FootballLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addbooleanformatchover : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "IsOver", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "IsOver");
        }
    }
}
