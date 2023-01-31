using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ELibrary.Library.Dto;

namespace ELibrary.Library
{
    public interface ILibraryAppService : IApplicationService
    {
        Task<PagedResultDto<ArenaListDto>> GetAllArenas();

        Task CreateNewArena(CreateArenaInput input);

        Task DeleteArena(int arenaId);

        Task UpdateArena(ArenaInput input);

        Task<PagedResultDto<BookGenreDto>> GetAllBookGenres();

        Task CreateNewBookGenre(CreateBookGenreInput input);

        Task DeleteBookGenre(int bookGenreId);

        Task UpdateBookGenre(BookGenreInput input);
    }
}
