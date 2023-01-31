using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Library.Dto
{
    public class ReserveBookInput
    {
        public int TenantId { get; set; }

        public string UniqueName { get; set; }
    }
}
