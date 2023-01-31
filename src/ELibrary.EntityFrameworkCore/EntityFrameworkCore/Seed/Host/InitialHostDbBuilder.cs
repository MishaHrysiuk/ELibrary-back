namespace ELibrary.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly ELibraryDbContext _context;

        public InitialHostDbBuilder(ELibraryDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            new DefaultArenaCreator(_context).Create();
            new BookGenreCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
