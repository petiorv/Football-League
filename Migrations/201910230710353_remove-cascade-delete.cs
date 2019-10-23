namespace FootballLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecascadedelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "HomeTeamId" });
            DropIndex("dbo.Matches", new[] { "AwayTeamId" });
            AlterColumn("dbo.Matches", "HomeTeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.Matches", "AwayTeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "HomeTeamId");
            CreateIndex("dbo.Matches", "AwayTeamId");
            AddForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "AwayTeamId" });
            DropIndex("dbo.Matches", new[] { "HomeTeamId" });
            AlterColumn("dbo.Matches", "AwayTeamId", c => c.Int());
            AlterColumn("dbo.Matches", "HomeTeamId", c => c.Int());
            CreateIndex("dbo.Matches", "AwayTeamId");
            CreateIndex("dbo.Matches", "HomeTeamId");
            AddForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams", "Id");
            AddForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams", "Id");
        }
    }
}
