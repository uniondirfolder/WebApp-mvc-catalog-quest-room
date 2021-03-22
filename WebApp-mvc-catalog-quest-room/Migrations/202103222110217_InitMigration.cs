namespace WebApp_mvc_catalog_quest_room.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Fear = c.Int(nullable: false),
                        Difficulty = c.Int(nullable: false),
                        MinAge = c.Int(nullable: false),
                        MaxAge = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        TransitTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageCQRs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalLink = c.String(),
                        InternalPath = c.String(),
                        DataBase = c.Binary(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ImageId = c.Int(),
                        SizeGroup = c.Int(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageCQRs", t => t.ImageId)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.ImageId)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Sex = c.Boolean(),
                        RegisterDate = c.DateTime(nullable: false),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageCQRs", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.ParticipantTeams",
                c => new
                    {
                        Participant_Id = c.Int(nullable: false),
                        Team_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Participant_Id, t.Team_Id })
                .ForeignKey("dbo.Participants", t => t.Participant_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .Index(t => t.Participant_Id)
                .Index(t => t.Team_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Participants", "ImageId", "dbo.ImageCQRs");
            DropForeignKey("dbo.ParticipantTeams", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.ParticipantTeams", "Participant_Id", "dbo.Participants");
            DropForeignKey("dbo.Teams", "ImageId", "dbo.ImageCQRs");
            DropForeignKey("dbo.ImageCQRs", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.ParticipantTeams", new[] { "Team_Id" });
            DropIndex("dbo.ParticipantTeams", new[] { "Participant_Id" });
            DropIndex("dbo.Participants", new[] { "ImageId" });
            DropIndex("dbo.Teams", new[] { "Room_Id" });
            DropIndex("dbo.Teams", new[] { "ImageId" });
            DropIndex("dbo.ImageCQRs", new[] { "Room_Id" });
            DropTable("dbo.ParticipantTeams");
            DropTable("dbo.Participants");
            DropTable("dbo.Teams");
            DropTable("dbo.ImageCQRs");
            DropTable("dbo.Rooms");
        }
    }
}
