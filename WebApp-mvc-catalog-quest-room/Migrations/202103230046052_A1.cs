namespace WebApp_mvc_catalog_quest_room.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageCQRs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ExternalLink = c.String(maxLength: 250),
                        InternalPath = c.String(maxLength: 250),
                        DataBase = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Age = c.Int(nullable: false),
                        Address = c.String(maxLength: 150),
                        Phone = c.String(maxLength: 30),
                        Email = c.String(maxLength: 30),
                        Sex = c.Boolean(),
                        RegisterDate = c.DateTime(nullable: false),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageCQRs", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 30),
                        CreateDate = c.DateTime(nullable: false),
                        ImageId = c.Int(),
                        SizeGroup = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageCQRs", t => t.ImageId)
                .ForeignKey("dbo.Rooms", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Description = c.String(maxLength: 3000),
                        Fear = c.Int(nullable: false),
                        Difficulty = c.Int(nullable: false),
                        MinAge = c.Int(nullable: false),
                        MaxAge = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        TransitTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamParticipants",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        Participant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.Participant_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.Participants", t => t.Participant_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.Participant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Id", "dbo.Rooms");
            DropForeignKey("dbo.ImageCQRs", "Id", "dbo.Rooms");
            DropForeignKey("dbo.Participants", "ImageId", "dbo.ImageCQRs");
            DropForeignKey("dbo.TeamParticipants", "Participant_Id", "dbo.Participants");
            DropForeignKey("dbo.TeamParticipants", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "ImageId", "dbo.ImageCQRs");
            DropForeignKey("dbo.ImageCQRs", "Id", "dbo.Galleries");
            DropIndex("dbo.TeamParticipants", new[] { "Participant_Id" });
            DropIndex("dbo.TeamParticipants", new[] { "Team_Id" });
            DropIndex("dbo.Teams", new[] { "ImageId" });
            DropIndex("dbo.Teams", new[] { "Id" });
            DropIndex("dbo.Participants", new[] { "ImageId" });
            DropIndex("dbo.ImageCQRs", new[] { "Id" });
            DropTable("dbo.TeamParticipants");
            DropTable("dbo.Rooms");
            DropTable("dbo.Teams");
            DropTable("dbo.Participants");
            DropTable("dbo.ImageCQRs");
            DropTable("dbo.Galleries");
        }
    }
}
