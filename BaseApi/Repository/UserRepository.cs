using BaseApi.Core;
using BaseApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }
        #region Methods
        public User GetUserWithEmail(string email)
        {
            return AppContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }
        public IEnumerable<User> getAllReqruites()
        {
            throw new NotImplementedException();
        }


        public User GetUserWithEmailAndPassword(string email, string password)
        {
            return AppContext.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public User GetUserWithRegistrationToken(string token)
        {
            throw new NotImplementedException();
        }

        public User GetUserWithResetToken(string token)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return AppContext.Users.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }
       

        #endregion
    }
}
