using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace QuizApp.Configurations
{
    internal sealed class Configuration : DbMigrationsConfiguration<QuizApp.Models.QuizAppContext>
   {
       public Configuration()
       {
          AutomaticMigrationsEnabled = true;
       }
  }
}