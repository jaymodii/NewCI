

using NewCI.Entities.Data;
using NewCI.Entities.DTOs;
using NewCI.Entities.Models;
using NewCI.Entities.ViewModels;
using NewCI.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserInterface 
    {
        public new readonly DatabasewithDataContext _db;
        public UserRepository(DatabasewithDataContext db):base(db)
        {
            _db = db;
        }






        public SessionDto? Login(CredentialDto obj)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == obj.Email && x.Password == obj.Password && x.DeletedAt == null && x.Status == true);
            if (user == null)
            {
                return null;
            }

            string username = user.FirstName + " " + user.LastName;

            SessionDto sessionData = new SessionDto(username,user.Avtar,user.Role,user.UserId);
            return sessionData;
        }

    }
}
