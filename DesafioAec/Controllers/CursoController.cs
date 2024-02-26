using DesafioAec.Domain.Interfaces;
using DesafioAec.Domain.Models;
using DesafioAec.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAec.Controllers
{
    [ApiController]
    [Route("Curso/v1")]
    public class CursoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CursoService _cursoService;
        private readonly IRepository<Curso> _cursoRepository;   

        public CursoController(CursoService cursoService, 
            IRepository<Curso> cursoRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cursoService = cursoService;
            _cursoRepository = cursoRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cursos = _cursoRepository.GetAll();

                return Ok(cursos);
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Domain.Models.Curso model)
        {
            if (ModelState.IsValid)
            {
                _cursoRepository.save(model);
                _unitOfWork.Commit();
            }

            return Ok();
        }


       
    }
}
