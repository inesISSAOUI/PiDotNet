namespace Pidev.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "pi.formateur",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        disponibilite = c.Boolean(storeType: "bit"),
                        formateurs = c.Binary(storeType: "tinyblob"),
                        name = c.String(maxLength: 255, unicode: false),
                        number = c.Int(nullable: false),
                        specialite = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pi.planification",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateDebut = c.String(maxLength: 255, unicode: false),
                        dateFin = c.String(maxLength: 255, unicode: false),
                        numberP = c.Int(nullable: false),
                        idFormateur = c.Int(),
                        idFormation = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pi.formation", t => t.idFormation)
                .ForeignKey("pi.formateur", t => t.idFormateur)
                .Index(t => t.idFormateur)
                .Index(t => t.idFormation);
            
            CreateTable(
                "pi.formation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        duration = c.String(maxLength: 255, unicode: false),
                        nbPlaceDispo = c.Int(nullable: false),
                        nomFormation = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("pi.planification", "idFormateur", "pi.formateur");
            DropForeignKey("pi.planification", "idFormation", "pi.formation");
            DropIndex("pi.planification", new[] { "idFormation" });
            DropIndex("pi.planification", new[] { "idFormateur" });
            DropTable("pi.formation");
            DropTable("pi.planification");
            DropTable("pi.formateur");
        }
    }
}
