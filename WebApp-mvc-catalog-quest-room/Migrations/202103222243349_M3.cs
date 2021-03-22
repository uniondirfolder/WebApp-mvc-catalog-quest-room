namespace WebApp_mvc_catalog_quest_room.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ParticipantTeams", newName: "TeamParticipants");
            DropPrimaryKey("dbo.TeamParticipants");
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ImageCQRs", "Gallery_Id", c => c.Int());
            AlterColumn("dbo.Rooms", "Description", c => c.String(maxLength: 3000));
            AlterColumn("dbo.ImageCQRs", "ExternalLink", c => c.String(maxLength: 250));
            AlterColumn("dbo.ImageCQRs", "InternalPath", c => c.String(maxLength: 250));
            AlterColumn("dbo.Teams", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Participants", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Participants", "Address", c => c.String(maxLength: 150));
            AlterColumn("dbo.Participants", "Phone", c => c.String(maxLength: 30));
            AlterColumn("dbo.Participants", "Email", c => c.String(maxLength: 30));
            AddPrimaryKey("dbo.TeamParticipants", new[] { "Team_Id", "Participant_Id" });
            CreateIndex("dbo.ImageCQRs", "Gallery_Id");
            AddForeignKey("dbo.ImageCQRs", "Gallery_Id", "dbo.Galleries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageCQRs", "Gallery_Id", "dbo.Galleries");
            DropIndex("dbo.ImageCQRs", new[] { "Gallery_Id" });
            DropPrimaryKey("dbo.TeamParticipants");
            AlterColumn("dbo.Participants", "Email", c => c.String());
            AlterColumn("dbo.Participants", "Phone", c => c.String());
            AlterColumn("dbo.Participants", "Address", c => c.String());
            AlterColumn("dbo.Participants", "Name", c => c.String());
            AlterColumn("dbo.Teams", "Name", c => c.String());
            AlterColumn("dbo.ImageCQRs", "InternalPath", c => c.String());
            AlterColumn("dbo.ImageCQRs", "ExternalLink", c => c.String());
            AlterColumn("dbo.Rooms", "Description", c => c.String());
            DropColumn("dbo.ImageCQRs", "Gallery_Id");
            DropTable("dbo.Galleries");
            AddPrimaryKey("dbo.TeamParticipants", new[] { "Participant_Id", "Team_Id" });
            RenameTable(name: "dbo.TeamParticipants", newName: "ParticipantTeams");
        }
    }
}
