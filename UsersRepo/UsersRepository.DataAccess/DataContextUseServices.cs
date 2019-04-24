using System.Collections.Generic;
using System.Linq;
using UsersRepostory.Models;

namespace UsersRepository.DataAccess
{
    public class DataContextUseServices
    {
        public List<User> GetAdminUsers()
        {
            using (var context = new DataContext())
            {
                return context.Users.Where(user=>user.Admin==true).ToList();
            }
        }
        public List<User> GetUsersList()
        {
            using(var context = new DataContext())
            {
                return context.Users.ToList();
            }
        }
        public bool AddUser(User user)
        {
            using (var context = new DataContext())
            {
                var existsUser = context.Users.FirstOrDefault(findLogin => findLogin.Login == user.Login);

                if (existsUser == null)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
        public void UpdateUser(User user)
        {
            using(var context = new DataContext())
            {
                var userForUpdate = context.Users.FirstOrDefault(_user => _user.Id == user.Id);
                userForUpdate.Login = user.Login;
                userForUpdate.HashPassword = user.HashPassword;
                userForUpdate.Phone = user.Phone;
                userForUpdate.Address = user.Address;
                userForUpdate.Admin = user.Admin;
                context.SaveChanges();
            }
        }
        public void DeleteUser(User user)
        {
            
            using (var context = new DataContext())
            {

                var userForDelete = context.Users.FirstOrDefault(us => us.Id == user.Id);
                context.Users.Remove(userForDelete);
                context.SaveChanges();
            }
        }
    }
}
