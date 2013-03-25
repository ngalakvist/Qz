
using QuizApp.Configurations;
using System.Data.Entity;

namespace QuizApp.Models
{
    public class QuizAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        //This is required for auto migrations
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<QuizAppContext,Configuration>());
            base.OnModelCreating(modelBuilder);
        }

        public QuizAppContext() : base("name=QuizAppContext")
        {
             
        }

        public DbSet<AnswerChoice> AnswerChoices { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Quiz> Quizs { get; set; }
    }
}
