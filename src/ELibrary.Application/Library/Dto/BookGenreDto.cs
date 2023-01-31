using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace ELibrary.Library.Dto
{
    public class BookGenreDto : EntityDto<long>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
