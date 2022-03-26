using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.DataAccess.Concrete.EntityFramework.Mapping
{
    public class StudentsParentsMap : EntityTypeConfiguration<StudentsParents>
    {
        public StudentsParentsMap()
        {
            ToTable(@"StudentsParents", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.StudentsIdentityNumber).HasColumnName("StudentsIdentityNumber");
            Property(x => x.FatherName).HasColumnName("FatherName");
        }
       
    }
}
