using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Library;

namespace ELibrary.EntityFrameworkCore.Seed.Host
{
    public class DefaultArenaCreator
    {
        private readonly ELibraryDbContext _context;

        public DefaultArenaCreator(ELibraryDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateArena();
        }

        public void CreateArena()
        {
            var defaultArena = _context.Arenas.IgnoreQueryFilters().FirstOrDefault(e => e.Name == ELibraryConsts.DefaultArenaName);

            if (defaultArena == null)
            {
                defaultArena = new Arena
                {
                    Name = ELibraryConsts.DefaultArenaName,
                    Capacity = ELibraryConsts.DefaultArenaCapacity
                };

                _context.Arenas.Add(defaultArena);
                _context.SaveChanges();
            }
        }
    }
}
