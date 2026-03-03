using KAShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KAShop.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(string[]? includes = null);
        Task<T> CreateAsync(T category);
        Task<T> GetOne(Expression<Func<T, bool>> filter, string[]? includes = null);
    }
}
