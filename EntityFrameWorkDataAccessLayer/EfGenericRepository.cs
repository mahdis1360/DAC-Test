﻿using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameWorkDataAccessLayer
{
      public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private readonly Context _context;

    public EFGenericRepository()
    {
        _context = new Context();
    }

        public void Add(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State =
                    EntityState.Added;
            }
            _context.SaveChanges();
        }

     

         public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State =
                    EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State =
                    EntityState.Modified;
            }
            _context.SaveChanges();
        }
        public T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (
                Expression<Func<T, object>> property
                in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, Object>(property);
            }
            return  dbQuery.Where(where).FirstOrDefault();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (
                Expression<Func<T, object>> property
                in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, Object>(property);
            }
            return dbQuery.ToList();
        }
    }
}

