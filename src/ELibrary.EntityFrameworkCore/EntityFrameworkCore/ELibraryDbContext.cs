using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ELibrary.Authorization.Roles;
using ELibrary.Authorization.Users;
using ELibrary.Books;
using ELibrary.Library;
using ELibrary.MultiTenancy;

namespace ELibrary.EntityFrameworkCore
{
    public class ELibraryDbContext : AbpZeroDbContext<Tenant, Role, User, ELibraryDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ELibraryDbContext(DbContextOptions<ELibraryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arena> Arenas { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<BookGenre> BookGenres { get; set; }
    }
}
