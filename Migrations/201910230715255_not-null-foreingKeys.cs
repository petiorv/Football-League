namespace FootballLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notnullforeingKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams");
            AddForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams", "Id");
            AddForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams");
            AddForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
    }
}
