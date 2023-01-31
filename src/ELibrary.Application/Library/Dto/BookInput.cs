using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Library.Dto
{
    public class BookInput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Year { get; set; }

        public int GenreId { get; set; }

        public string Author { get; set; }

        public string Position { get; set; }
    }
}
