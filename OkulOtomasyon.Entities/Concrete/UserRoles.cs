using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Core.Entities;

namespace OkulOtomasyon.Entities.Concrete
{
    public class UserRoles : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
