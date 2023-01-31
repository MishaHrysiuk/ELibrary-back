using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using ELibrary.Library;
using ELibrary.MultiTenancy;

namespace ELibrary.Books
{
    [Table("Books")]
    public class Book : Entity<int>
    {
        public string Name { get; set; }

        public Guid UniqueNumber { get; set; }

        public int? Year { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public BookGenre Genre { get; set; }

        public string Author { get; set; }

        public string Position { get; set; }

        public bool? IsReserved { get; set; }

        public int? TenantId { get; set; }

        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }

        public int? ArenaId { get; set; }

        [ForeignKey("ArenaId")]

        public Arena Arena { get; set; }
    }
}
