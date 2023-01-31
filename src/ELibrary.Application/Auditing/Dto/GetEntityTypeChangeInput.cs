using System;
using Abp.Extensions;
using Abp.Runtime.Validation;
using ELibrary.Shared.Dto;

namespace ELibrary.Auditing.Dto
{
    public class GetEntityTypeChangeInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string EntityTypeFullName { get; set; }

        public string EntityId { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "ChangeTime DESC";
            }

            if (Sorting.IndexOf("UserName", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Sorting = "User." + Sorting;
            }
            else
            {
                Sorting = "EntityChange." + Sorting;
            }
        }
    }
}
