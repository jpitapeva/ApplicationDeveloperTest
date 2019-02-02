using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Volvo.Interface;
using Volvo.Models;
using Volvo.Repository.Context;

namespace Volvo.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private bool _disposed;
        protected DbSet<TEntity> DbSet;
        protected TruckContext Context;
        protected DbContext DbContext { get; set; }
        public IConfiguration Configuration { get; }

        public Repository(TruckContext context, IConfiguration configuration)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
            Configuration = configuration;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
            Context.SaveChanges();
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
            Context.SaveChanges();
        }
        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
            Context.SaveChanges();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void RemoveAll(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).FirstOrDefault();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
        }
    }
}
