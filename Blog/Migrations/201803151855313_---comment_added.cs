namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        comment = c.String(nullable: false),
                        Article_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Articles", t => t.Article_ID)
                .Index(t => t.Article_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Article_ID", "dbo.Articles");
            DropIndex("dbo.Comments", new[] { "Article_ID" });
            DropTable("dbo.Comments");
        }
    }
}
