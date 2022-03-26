using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Core.CrossCuttingConcerns.Security.Jwt;
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

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<StudentsParentsDetails> StudentsParentsDetails { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentsParents> StudentsParents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}