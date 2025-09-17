using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyContext _myContext;
        protected readonly DbSet<T> _dbSet;
        public Repository(MyContext myContext)
        {
            _myContext = myContext;
            _dbSet = _myContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _myContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _myContext.SaveChangesAsync();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return _myContext.SaveChangesAsync();
        }
    }
}
