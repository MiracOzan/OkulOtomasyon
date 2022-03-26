using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.DataAccess.Concrete.EntityFramework.Mapping
{
    public class StudentsMap : EntityTypeConfiguration<Students>
    {
        public StudentsMap()
        {
            ToTable(@"Students", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.IdentityNumber).HasColumnName("IdentityNumber");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.LastName).HasColumnName("LastName");
            Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
            Property(x => x.Picture).HasColumnName("Picture");
            Property(x => x.BusinessPhoneNumber).HasColumnName("BusinessPhoneNumber");
            Property(x => x.City).HasColumnName("City");
            Property(x => x.Country).HasColumnName("Country");
            Property(x => x.DateOfBirth).HasColumnName("DateOfBirth");
            Property(x => x.Class).HasColumnName("Class");
            Property(x => x.Email).HasColumnName("EMail");
            Property(x => x.Street).HasColumnName("Street");
        }
    }
}
