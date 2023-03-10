using Abp.Application.Services.Dto;

namespace ELibrary.Shared.Dto
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        public string Sorting { get; set; }

        public PagedAndSortedInputDto()
        {
            MaxResultCount = ELibraryConsts.DefaultPageSize;
        }
    }
}
