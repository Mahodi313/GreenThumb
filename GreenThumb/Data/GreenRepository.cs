﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public class GreenRepository<T> where T : class
    {
        private readonly GreenThumbDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GreenRepository(GreenThumbDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAll() 
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(int id) 
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(T entity) 
        {
            await _dbSet.AddAsync(entity);
        }

        // NICE TO HAVE
        public void Update(T entity) 
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
