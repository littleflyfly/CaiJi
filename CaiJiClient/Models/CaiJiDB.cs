using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiJi.Client.Models
{
    public class CaiJiDB : DbContext
    {
        public CaiJiDB() : base("dbConn")
        {

        }

        public DbSet<User> Users { get { return Set<User>(); } }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var init = new SqliteCreateDatabaseIfNotExists<CaiJiDB>(modelBuilder);
            Database.SetInitializer(init);
        }
    }

    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureUserEntity(modelBuilder);
        }
        private static void ConfigureUserEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
        }
    }
}
