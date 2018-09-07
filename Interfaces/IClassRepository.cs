using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotebookAppApi.Model;

namespace NotebookAppApi.Interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllClasses();

        Task<Class> GetClass(string id);

        Task AddClass(Class item);
    }
}
