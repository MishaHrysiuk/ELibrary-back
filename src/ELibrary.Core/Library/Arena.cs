using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace ELibrary.Library
{
    [Table("Arenas")]
    public class Arena : Entity<int>
    {
        public string Name { get; set; }

        public int Capacity { get; set; }
    }
}
