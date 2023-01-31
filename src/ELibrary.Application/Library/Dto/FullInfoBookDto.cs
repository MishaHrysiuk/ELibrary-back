using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Library.Dto
{
    public class FullInfoBookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UniqueNumber { get; set; }

        public int? Year { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        public string Position { get; set; }

        public bool? IsReserved { get; set; }

        public int? TenantId { get; set; }

        public int? ArenaId { get; set; }
    }
}
