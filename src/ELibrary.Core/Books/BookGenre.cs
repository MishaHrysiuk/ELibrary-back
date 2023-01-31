using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace ELibrary.Books
{
    [Table("BookGenre")]
    public class BookGenre : Entity<int>
    {
        public string Name { get; set; }
    }
}
