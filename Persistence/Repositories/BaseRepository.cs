using INFORAP.API.Persistence.Context;
using INFORAP.API.Persistence.IRepositories;
using INFORAP.API.Persistence.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace INFORAP.API.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly InfoRapContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(InfoRapContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> ListBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> ListBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }
            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> ListBy()
        {
            return await _dbSet.ToListAsync();
        }


        public virtual async Task<T> GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity;
        }
        public async Task<T> Insert(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(object id, T entity)
        {
            try
            {
                var editedEntity = await GetById(id);
                _context.Entry(editedEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return editedEntity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<T> Update(T entity)
        {
            try
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    _context.Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Remove(object id)
        {
            var entity = await GetById(id);
            await Remove(entity);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).AnyAsync();
        }


    }
}
