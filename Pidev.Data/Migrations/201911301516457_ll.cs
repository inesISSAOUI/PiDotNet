namespace Pidev.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        QuestionDescription = c.String(unicode: false),
                        Question1stSuggestion = c.String(unicode: false),
                        Question2ndSuggestion = c.String(unicode: false),
                        Question3rdSuggestion = c.String(unicode: false),
                        QuestionCorrectAnswer = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Quizs", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        QuizId = c.Int(nullable: false, identity: true),
                        FormationId = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Type = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.QuizId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizs");
            DropIndex("dbo.Questions", new[] { "QuizId" });
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
        }
    }
}
