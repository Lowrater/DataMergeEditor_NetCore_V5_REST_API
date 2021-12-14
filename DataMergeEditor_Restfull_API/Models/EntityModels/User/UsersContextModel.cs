using Microsoft.EntityFrameworkCore;

namespace DataMergeEditor_Restfull_API.Models.EntityModels.User
{
    /// <summary>
    /// Users context model based on <see cref="Users"/>
    /// </summary>
    public class UsersContextModel : DbContext
    {

        public UsersContextModel(DbContextOptions<UsersContextModel> options) : base(options) 
        {
        }

        public DbSet<Users> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Users>().OwnsOne(property => property.UserID);
        //}
    }
}
