using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotebookAppApi.Interfaces;
using NotebookAppApi.Model;
using NotebookAppApi.Infrastructure;
using System;
using System.Collections.Generic;

namespace NotebookAppApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClassesController
    {
        private readonly IClassRepository _classRespository;

        public ClassesController(IClassRepository classRepository)
        {
            _classRespository = classRepository;
        }

        [NoCache]
        [HttpGet]
        public Task<IEnumerable<Class>> Get()
        {
            return _classRespository.GetAllClasses();
        }

        [HttpGet("{id}")]
        public Task<Class> Get(string id) {
            return _classRespository.GetClass(id);
        }

        [HttpPost]
        public void Post([FromBody] ClassParam newClass) 
        {
            _classRespository.AddClass(new Class
            {
                ClassName = newClass.ClassName
            });
        }
    }
}
