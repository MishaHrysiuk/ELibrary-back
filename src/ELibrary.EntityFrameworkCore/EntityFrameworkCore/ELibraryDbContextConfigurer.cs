using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.EntityFrameworkCore
{
    public static class ELibraryDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ELibraryDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public static void Configure(DbContextOptionsBuilder<ELibraryDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection, ServerVersion.AutoDetect(connection.ConnectionString));
        }
    }
}
