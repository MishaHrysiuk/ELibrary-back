using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Books;

namespace ELibrary.EntityFrameworkCore.Seed.Host
{
    public class BookGenreCreator
    {
        private readonly ELibraryDbContext _context;

        public BookGenreCreator(ELibraryDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateBookGenres();
        }

        public void CreateBookGenres()
        {
            var listOfBookGenres = _context.BookGenres.ToList();

            if (listOfBookGenres.Count < 1)
            {
                foreach (BookGenreEnum bookGenre in (BookGenreEnum[])Enum.GetValues(typeof(BookGenreEnum)))
                {
                    listOfBookGenres.Add(new BookGenre
                    {
                        Name = bookGenre.ToString()
                    });
                }

                _context.BookGenres.AddRange(listOfBookGenres);
                _context.SaveChanges();
            }
        }
    }
}
