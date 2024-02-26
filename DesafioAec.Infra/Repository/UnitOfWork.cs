using DesafioAec.Domain.Interfaces;
using DesafioAec.Infra.DataContext;
using Microsoft.EntityFrameworkCore;


namespace DesafioAec.Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext _context;

        public UnitOfWork(AppDataContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
           await _context.SaveChangesAsync();
        }
    }
}
