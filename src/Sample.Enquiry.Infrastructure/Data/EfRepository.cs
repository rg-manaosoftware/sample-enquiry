using System;
using Sample.Enquiry.Core.Entities;
using Sample.Enquiry.Core.Query;
using Sample.Enquiry.Core.Interfaces;
using Sample.Enquiry.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Enquiry.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(ulong id) where T : BaseEntity
        {
            if (typeof(T) == typeof(Customer))
            {
                return _dbContext.Set<Customer>().Include(g => g.Transactions)
                    .SingleOrDefault(e => e.Id == id) as T;
            }
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public T GetByParams<T>(QueryParameters queryParameters) where T : BaseEntity
        {
            if (typeof(T) == typeof(Customer))
            {
                var customers = _dbContext.Set<Customer>().Include(g => g.Transactions).AsQueryable();
                if( queryParameters.HasIdQuery() )
                {
                    customers = customers.Where( c => c.Id == ulong.Parse(queryParameters.CustomerId));
                }
                if( queryParameters.HasEmailQuery() )
                {
                    customers = customers.Where( c => c.Email == queryParameters.Email);
                }
                return customers.FirstOrDefault() as T;
            }
            return null;
        }

        public List<T> List<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
