namespace MovieRater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genre", "MovieID", "dbo.Movie");
            DropForeignKey("dbo.Genre", "ShowID", "dbo.Show");
            DropIndex("dbo.Genre", new[] { "MovieID" });
            DropIndex("dbo.Genre", new[] { "ShowID" });
            AlterColumn("dbo.Genre", "MovieID", c => c.Int());
            AlterColumn("dbo.Genre", "ShowID", c => c.Int());
            CreateIndex("dbo.Genre", "MovieID");
            CreateIndex("dbo.Genre", "ShowID");
            AddForeignKey("dbo.Genre", "MovieID", "dbo.Movie", "MovieID");
            AddForeignKey("dbo.Genre", "ShowID", "dbo.Show", "ShowID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genre", "ShowID", "dbo.Show");
            DropForeignKey("dbo.Genre", "MovieID", "dbo.Movie");
            DropIndex("dbo.Genre", new[] { "ShowID" });
            DropIndex("dbo.Genre", new[] { "MovieID" });
            AlterColumn("dbo.Genre", "ShowID", c => c.Int(nullable: false));
            AlterColumn("dbo.Genre", "MovieID", c => c.Int(nullable: false));
            CreateIndex("dbo.Genre", "ShowID");
            CreateIndex("dbo.Genre", "MovieID");
            AddForeignKey("dbo.Genre", "ShowID", "dbo.Show", "ShowID", cascadeDelete: true);
            AddForeignKey("dbo.Genre", "MovieID", "dbo.Movie", "MovieID", cascadeDelete: true);
        }
    }
}
