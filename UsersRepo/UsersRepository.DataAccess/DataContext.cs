namespace UsersRepository.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using UsersRepostory.Models;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
            Database.SetInitializer(new Initializer());
        }
        public virtual DbSet<User> Users { get; set; }
    }
}