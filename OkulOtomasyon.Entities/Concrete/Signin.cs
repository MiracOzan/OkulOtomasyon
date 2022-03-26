using OkulOtomasyon.Core.Entities;

namespace OkulOtomasyon.Entities.Concrete
{
    public class Signin:IEntity
    {
      
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
