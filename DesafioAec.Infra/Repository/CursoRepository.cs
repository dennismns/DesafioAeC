using DesafioAec.Domain.Models;
using DesafioAec.Infra.DataContext;


namespace DesafioAec.Infra.Repository
{
    public class CursoRepository : Repository<Curso>
    {
        public CursoRepository(AppDataContext context) : base(context)
        { }

        public override Curso GetById(int id)
        {
            var query = _context.Set<Curso>().Where(c => c.Id == id);
            if (query.Any())
                return query.First();
            return null;
        }

        public override IEnumerable<Curso> GetAll() 
        {
            try
            {
                var query = _context.Set<Curso>();

                return query.ToList();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public override void save(Curso obj)
        {
             _context.Add(obj);
        }

        public override void remove(Curso obj)
        {
            _context.Remove(obj);
        }

        public override void update(Curso obj)
        {
            _context.Update(obj);
        }




    }
}
