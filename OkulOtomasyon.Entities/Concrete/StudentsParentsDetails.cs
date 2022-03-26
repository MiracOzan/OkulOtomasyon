using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Core.Entities;

namespace OkulOtomasyon.Entities.Concrete
{
    public class StudentsParentsDetails : IEntity
    {
        public int Id { get; set; }
        public int Students { get; set; }
        public int StudentsParents { get; set; }
    }
}
