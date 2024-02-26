using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAec.Domain.Models
{
    public class Curso : BaseEntity
    {
        

        public Curso(string titulo, string nomeProfessor, string cargaHoraria, string descricao) 
        {
            Titulo = titulo;
            NomeProfessor = nomeProfessor;
            CargaHoraria = cargaHoraria;
            Descricao = descricao;
        }

        public string Titulo { get; set; }

        public string NomeProfessor { get; set; }

        public string CargaHoraria { get; set; }

        public string Descricao { get; set; }
    }
}
