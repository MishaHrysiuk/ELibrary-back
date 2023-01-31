using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.Books;

namespace ELibrary.Library.Dto
{
    public class LibraryMapProfile : Profile
    {
        public LibraryMapProfile()
        {
            //Arena
            CreateMap<Arena, ArenaListDto>();
            CreateMap<CreateArenaInput, Arena>();

            //BookGenre
            CreateMap<BookGenre, BookGenreDto>();
            CreateMap<CreateBookGenreInput, BookGenre>();

            //Books
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookInput, Book>();
            CreateMap<Book, FullInfoBookDto>();
        }
    }
}
