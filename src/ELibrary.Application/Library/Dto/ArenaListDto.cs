using Abp.Application.Services.Dto;

namespace ELibrary.Library.Dto
{
    public class ArenaListDto : EntityDto<long>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }
    }
}
