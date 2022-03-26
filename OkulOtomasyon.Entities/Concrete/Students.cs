using System;
using System.Collections;
using OkulOtomasyon.Core.Entities;

namespace OkulOtomasyon.Entities.Concrete
{
    public sealed class Students : IEntity
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string DistrictRegion { get; set; }
        public string Country { get; set; }
        public byte[] Picture { get; set; }
        public string Class { get; set; }
        public DateTime DateOfBirth { get; set; }

     
    }
}
