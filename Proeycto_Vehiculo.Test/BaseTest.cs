using AutoMapper;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Proyecto_Vehiculo;
using Proyecto_Vehiculo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proeycto_Vehiculo.Test
{
    public class BaseTest
    {
        protected ApplicationDbContext BuildDataBaseContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName).Options;
            
            var dbContext = new ApplicationDbContext(options);
            
            return dbContext;
        }

        protected IMapper BuildMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Profiles>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    

    }
}
