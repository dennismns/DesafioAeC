using DesafioAec.Domain.Interfaces;
using DesafioAec.Domain.Models;
using DesafioAec.Infra.DataContext;
using DesafioAec.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAec.Application
{
    public class Inicializar
    {
        public static void Configuration(IServiceCollection services, string connection)
        {
            services.AddDbContext<AppDataContext>(options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IRepository<Curso>), typeof(CursoRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(CursoService));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        }
    }
}
