using DesafioAec.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesafioAec.Domain.Models
{
    public class CursoService
    {
         readonly IRepository<Curso> _cursoRepository;

        public CursoService(IRepository<Curso> cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public void Save(int id, string titulo,string nomeProfessor,string cargaHoraria,string descricao)
        {
            var curso = _cursoRepository.GetById(id);
            if (curso == null)
            {
                curso = new Curso(titulo, nomeProfessor, cargaHoraria, descricao);
                _cursoRepository.save(curso);
            }
                
        }
    }
}
