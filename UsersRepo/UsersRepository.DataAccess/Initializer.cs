using System.Collections.Generic;
using System.Data.Entity;
using UsersRepostory.Models;

namespace UsersRepository.DataAccess
{
    internal class Initializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        private List<User> users;
        public Initializer()
        {
            users = new List<User>
            {
                new User
                {
                    Login = "Madi",
                    Address = "Sarayshyk 40",
                    HashPassword = "qwerty".GetHashCode(),
                    Admin =true,
                    Phone = "87025144414",

                },
                new User
                {
                    Login = "Aslan",
                    Address = "La La Lend",
                    HashPassword = "paramparam".GetHashCode(),
                    Phone = "1234567890",
                    Admin = false,
                },
                new User
                {
                    Login ="KakaKingsley",
                    HashPassword = "balonka1".GetHashCode(),
                    Address = "Bangkok",
                    Phone = "HZ",
                    Admin = false,
                },

            };
        }
        protected override void Seed(DataContext context)
        {
            context.Users.AddRange(users);
            base.Seed(context);
        }
    }
}