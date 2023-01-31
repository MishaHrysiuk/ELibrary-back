using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace ELibrary.Shared.Dto
{
    public class PagedInputDto : IPagedResultRequest
    {
        [Range(1, ELibraryConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public PagedInputDto()
        {
            MaxResultCount = ELibraryConsts.DefaultPageSize;
        }
    }
}
