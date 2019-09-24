namespace Support.DataAccess.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeStep : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sec.Access",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        AccessName = c.String(maxLength: 255),
                        AccessDesc = c.String(maxLength: 255),
                        IsGeneral = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccessId);
            
            CreateTable(
                "sec.AccessPolicy",
                c => new
                    {
                        AccessPolicyId = c.Int(nullable: false, identity: true),
                        AccessId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessPolicyId)
                .ForeignKey("sec.Access", t => t.AccessId)
                .ForeignKey("gen.Person", t => t.PersonId)
                .Index(t => t.AccessId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "gen.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        LoginName = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Gender = c.Boolean(nullable: false),
                        Mobile = c.String(maxLength: 255),
                        Password = c.String(maxLength: 255),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("gen.Config", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "gen.Request",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        RequestById = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Title = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        AssignedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("gen.Person", t => t.AssignedId)
                .ForeignKey("gen.Config", t => t.PriorityId)
                .ForeignKey("gen.Config", t => t.ProjectId)
                .ForeignKey("gen.Person", t => t.RequestById)
                .ForeignKey("gen.Config", t => t.StatusId)
                .ForeignKey("gen.Config", t => t.TypeId)
                .Index(t => t.RequestById)
                .Index(t => t.StatusId)
                .Index(t => t.TypeId)
                .Index(t => t.PriorityId)
                .Index(t => t.ProjectId)
                .Index(t => t.AssignedId);
            
            CreateTable(
                "gen.Config",
                c => new
                    {
                        ConfigId = c.Int(nullable: false, identity: true),
                        ConfigHdrId = c.Int(nullable: false),
                        ConfigName = c.String(maxLength: 255),
                        ConfigValue = c.Int(nullable: false),
                        ConfigNote = c.String(maxLength: 255),
                        ConfigSort = c.Int(nullable: false),
                        ClassName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ConfigId)
                .ForeignKey("gen.Config", t => t.ConfigHdrId)
                .Index(t => t.ConfigHdrId);
            
            CreateTable(
                "gen.Response",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        ResponseDate = c.DateTime(nullable: false),
                        CreateById = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                        Note = c.String(maxLength: 255),
                        Private = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseId)
                .ForeignKey("gen.Person", t => t.CreateById)
                .ForeignKey("gen.Request", t => t.RequestId)
                .Index(t => t.CreateById)
                .Index(t => t.RequestId);
            
            CreateTable(
                "gen.Log",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        EntityName = c.String(maxLength: 255),
                        PersonId = c.Int(nullable: false),
                        Description = c.String(),
                        ChangeTypeId = c.Int(nullable: false),
                        PrimaryKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("gen.Person", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "gen.Menu",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        MenuHdrId = c.Int(nullable: false),
                        MenuLabel = c.String(maxLength: 255),
                        MenuLink = c.String(maxLength: 255),
                        IsValid = c.Boolean(nullable: false),
                        SortIndex = c.Int(nullable: false),
                        IconName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("gen.Menu", t => t.MenuHdrId)
                .Index(t => t.MenuHdrId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("gen.Menu", "MenuHdrId", "gen.Menu");
            DropForeignKey("sec.AccessPolicy", "PersonId", "gen.Person");
            DropForeignKey("gen.Person", "StatusId", "gen.Config");
            DropForeignKey("gen.Log", "PersonId", "gen.Person");
            DropForeignKey("gen.Request", "TypeId", "gen.Config");
            DropForeignKey("gen.Request", "StatusId", "gen.Config");
            DropForeignKey("gen.Response", "RequestId", "gen.Request");
            DropForeignKey("gen.Response", "CreateById", "gen.Person");
            DropForeignKey("gen.Request", "RequestById", "gen.Person");
            DropForeignKey("gen.Request", "ProjectId", "gen.Config");
            DropForeignKey("gen.Request", "PriorityId", "gen.Config");
            DropForeignKey("gen.Config", "ConfigHdrId", "gen.Config");
            DropForeignKey("gen.Request", "AssignedId", "gen.Person");
            DropForeignKey("sec.AccessPolicy", "AccessId", "sec.Access");
            DropIndex("gen.Menu", new[] { "MenuHdrId" });
            DropIndex("gen.Log", new[] { "PersonId" });
            DropIndex("gen.Response", new[] { "RequestId" });
            DropIndex("gen.Response", new[] { "CreateById" });
            DropIndex("gen.Config", new[] { "ConfigHdrId" });
            DropIndex("gen.Request", new[] { "AssignedId" });
            DropIndex("gen.Request", new[] { "ProjectId" });
            DropIndex("gen.Request", new[] { "PriorityId" });
            DropIndex("gen.Request", new[] { "TypeId" });
            DropIndex("gen.Request", new[] { "StatusId" });
            DropIndex("gen.Request", new[] { "RequestById" });
            DropIndex("gen.Person", new[] { "StatusId" });
            DropIndex("sec.AccessPolicy", new[] { "PersonId" });
            DropIndex("sec.AccessPolicy", new[] { "AccessId" });
            DropTable("gen.Menu");
            DropTable("gen.Log");
            DropTable("gen.Response");
            DropTable("gen.Config");
            DropTable("gen.Request");
            DropTable("gen.Person");
            DropTable("sec.AccessPolicy");
            DropTable("sec.Access");
        }
    }
}
