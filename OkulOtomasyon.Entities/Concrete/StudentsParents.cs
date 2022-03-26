using OkulOtomasyon.Core.Entities;

namespace OkulOtomasyon.Entities.Concrete
{
    public class StudentsParents : IEntity 
    {
        
        public int Id { get; set; }
        public string StudentsIdentityNumber { get; set; }
        public string FatherName { get; set; }
        public string FatherLastName { get; set; }
        public string FatherEMail { get; set; }
        public string FatherPhoneNumber { get; set; }
        public string MotherName { get; set; }
        public string MotherLastName { get; set; }
        public string MotherEMail { get; set; }
        public string MotherPhoneNumber { get; set; }
        public string FamillyRealitions { get; set; }

    }
}
