using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.DataAccess.Concrete.EntityFramework.Mapping;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.DataAccess.Concrete
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=conn")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentsMap());
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<StudentsParents> StudentsParents { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}
