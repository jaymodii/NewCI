using AutoMapper;

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
    public class UserRepository : IUserInterface
    {
        public readonly DatabasewithDataContext _db;
        public UserRepository(DatabasewithDataContext db)
        {
            _db = db;
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        public BannersDto? GetBanners()
        {
            BannersDto banners = new BannersDto()
            {
                Banners = _db.Banners.Where(x => x.DeletedAt == null).OrderBy(x => x.SortOrder).ToList(),
            };

          
            return banners;
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
