using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ELibrary.Authorization;
using ELibrary.Books;
using ELibrary.Library.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Library
{
    //[AbpAuthorize(PermissionNames.Pages_Library)]
    public class LibraryAppService : ELibraryAppServiceBase, ILibraryAppService
    {
        private readonly IRepository<Arena> _arenaRepository;
        private readonly IRepository<BookGenre> _bookGenreRepository;
        private readonly IRepository<Book> _bookRepository;

        public LibraryAppService(
            IRepository<Arena> arenaRepository,
            IRepository<BookGenre> bookGenreRepository,
            IRepository<Book> bookRepository)
        {
            _arenaRepository = arenaRepository;
            _bookGenreRepository = bookGenreRepository;
            _bookRepository = bookRepository;
        }

        #region Arena

        //[AbpAuthorize(PermissionNames.Pages_Library_Arenas)]
        public async Task<PagedResultDto<ArenaListDto>> GetAllArenas()
        {
            var listOfArenas = await _arenaRepository.GetAllListAsync();

            var listOfArenaDtos = ObjectMapper.Map<List<ArenaListDto>>(listOfArenas);

            var resultCount = listOfArenaDtos.Count;

            return new PagedResultDto<ArenaListDto>(resultCount, listOfArenaDtos);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_Arenas)]
        public async Task CreateNewArena(CreateArenaInput input)
        {
            var newArena = ObjectMapper.Map<Arena>(input);

            await _arenaRepository.InsertOrUpdateAsync(newArena);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_Arenas)]
        public async Task DeleteArena(int arenaId)
        {
            var arena = await _arenaRepository.FirstOrDefaultAsync(arenaId);

            if (arena == null)
            {
                throw new UserFriendlyException("ArenaDoNotExist");
            }

            await _arenaRepository.DeleteAsync(arenaId);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_Arenas)]
        public async Task UpdateArena(ArenaInput input)
        {
            var existingArena = await _arenaRepository.FirstOrDefaultAsync(input.Id);

            if (existingArena == null)
            {
                throw new UserFriendlyException("UnableToUpdateArena");
            }

            existingArena.Capacity = input.Capacity;
            existingArena.Name = input.Name;

            await _arenaRepository.UpdateAsync(existingArena);
        }

        #endregion

        #region BookGenre

        //[AbpAuthorize(PermissionNames.Pages_Library_BookGenres)]
        public async Task<PagedResultDto<BookGenreDto>> GetAllBookGenres()
        {
            var listOfBookGenres = await _bookGenreRepository.GetAllListAsync();

            var listOfBookGenresDtos = ObjectMapper.Map<List<BookGenreDto>>(listOfBookGenres);

            var resultCount = listOfBookGenresDtos.Count;

            return new PagedResultDto<BookGenreDto>(resultCount, listOfBookGenresDtos);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_BookGenres)]
        public async Task CreateNewBookGenre(CreateBookGenreInput input)
        {
            var newBookGenre = ObjectMapper.Map<BookGenre>(input);

            await _bookGenreRepository.InsertOrUpdateAsync(newBookGenre);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_BookGenres)]
        public async Task DeleteBookGenre(int bookGenreId)
        {
            var bookGenre = await _bookGenreRepository.FirstOrDefaultAsync(bookGenreId);

            if (bookGenre == null)
            {
                throw new UserFriendlyException("BookGenreDoNotExist");
            }

            await _bookGenreRepository.DeleteAsync(bookGenreId);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_BookGenres)]
        public async Task UpdateBookGenre(BookGenreInput input)
        {
            var existingBookGenre = await _bookGenreRepository.FirstOrDefaultAsync(input.Id);

            if (existingBookGenre == null)
            {
                throw new UserFriendlyException("UnableToUpdateBookGenre");
            }

            existingBookGenre.Name = input.Name;

            await _bookGenreRepository.UpdateAsync(existingBookGenre);
        }

        #endregion

        #region Book

        //[AbpAuthorize(PermissionNames.Pages_Library_Books)]
        public async Task<PagedResultDto<BookDto>> GetAllBooks()
        {
            var allBooks = await _bookRepository.GetAll()
                .Include(x => x.Genre)
                .ToListAsync();

            var uniqueNames = allBooks.Select(x => x.Name).Distinct().ToList();

            var listOfDistinctBookDtos = new List<BookDto>();

            foreach (var uniqueBookName in uniqueNames)
            {
                var specificBooks = allBooks.Where(x => x.Name == uniqueBookName)
                    .ToList();

                var uniqueBook = specificBooks.FirstOrDefault();

                var specificBooksCount = specificBooks.Count();

                var specificBooksDto = ObjectMapper.Map<BookDto>(uniqueBook);
                specificBooksDto.Count = specificBooksCount;
                specificBooksDto.Genre = uniqueBook.Genre.Name;

                listOfDistinctBookDtos.Add(specificBooksDto);
            }

            var resultCount = listOfDistinctBookDtos.Count;

            return new PagedResultDto<BookDto>(resultCount, listOfDistinctBookDtos);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_Books)]
        public async Task CreateNewBook(CreateBookInput input)
        {
            var newBook = ObjectMapper.Map<Book>(input);

            newBook.UniqueNumber = Guid.NewGuid();

            await _bookRepository.InsertOrUpdateAsync(newBook);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_Books)]
        public async Task DeleteBook(int bookId)
        {
            var book = await _bookRepository.FirstOrDefaultAsync(bookId);

            if (book == null)
            {
                throw new UserFriendlyException("BookDoNotExist");
            }

            await _bookRepository.DeleteAsync(bookId);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_Books)]
        public async Task UpdateBook(BookInput input)
        {
            var existingBook = await _bookRepository.FirstOrDefaultAsync(input.Id);

            if (existingBook == null)
            {
                throw new UserFriendlyException("UnableToUpdateBook");
            }

            var allBookToUpdate = await _bookRepository.GetAll()
                .Where(x => x.Name == existingBook.Name)
                .ToListAsync();

            foreach (var bookToUpdate in allBookToUpdate)
            {
                bookToUpdate.Name = input.Name;
                bookToUpdate.Author = input.Author;
                bookToUpdate.Position = input.Position;
                bookToUpdate.GenreId = input.GenreId;
                bookToUpdate.Year = input.Year;

                await _bookRepository.UpdateAsync(bookToUpdate);
            }
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_Books)]
        public async Task ReserveBook(ReserveBookInput input)
        {
            var bookToReserve = await _bookRepository
                .FirstOrDefaultAsync(x => x.UniqueNumber.ToString() == input.UniqueName);

            if (bookToReserve == null)
            {
                throw new UserFriendlyException("BookForReserveDoNotExist");
            }

            bookToReserve.TenantId = input.TenantId;
            bookToReserve.IsReserved = true;

            await _bookRepository.UpdateAsync(bookToReserve);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_Books)]
        public async Task UnreserveBook(ReserveBookInput input)
        {
            var reservedBook = await _bookRepository
                .FirstOrDefaultAsync(x => x.UniqueNumber.ToString() == input.UniqueName);

            if (reservedBook == null || !reservedBook.TenantId.HasValue)
            {
                throw new UserFriendlyException("UnableToUnreserveBook");
            }

            reservedBook.TenantId = null;
            reservedBook.IsReserved = null;

            await _bookRepository.UpdateAsync(reservedBook);
        }

        //[AbpAuthorize(PermissionNames.Pages_Library_Books)]
        public async Task<PagedResultDto<FullInfoBookDto>> GetBookDetails(int bookId)
        {
            var booksToFind = await _bookRepository.FirstOrDefaultAsync(bookId);

            if (booksToFind == null)
            {
                throw new UserFriendlyException("BookDoNotExist");
            }

            var books = await _bookRepository.GetAll()
                .Include(x => x.Genre)
                .Include(x => x.Arena)
                .Include(x => x.Tenant)
                .Where(x => x.Name == booksToFind.Name)
                .ToListAsync();

            var booksDto = new List<FullInfoBookDto>();

            foreach (var b in books)
            {
                var mappedBook = ObjectMapper.Map<FullInfoBookDto>(b);
                mappedBook.UniqueNumber = b.UniqueNumber.ToString();
                mappedBook.Genre = b.Genre.Name;

                booksDto.Add(mappedBook);
            }

            var resultCount = booksDto.Count;

            return new PagedResultDto<FullInfoBookDto>(resultCount, booksDto);
        }

        #endregion
    }
}
