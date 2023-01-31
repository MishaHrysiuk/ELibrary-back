using Abp.Application.Services.Dto;

namespace ELibrary.Library.Dto
{
    public class BookDto : EntityDto<long>
    {
        public string Name { get; set; }

        public int? Year { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        public int Count { get; set; }
    }
}
