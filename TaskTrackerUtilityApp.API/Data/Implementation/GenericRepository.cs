using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TaskTrackerUtilityApp.API.Data
{
    public abstract class GenericRepository<T> : IRepositoryBase<T> where T:class
    {
        private IUnitOfWork _unitOfWork {get; set;}

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IQueryable<T> FindAll()
        {
            return this._unitOfWork.Context.Set<T>().AsQueryable();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression)
        {
            return this._unitOfWork.Context.Set<T>().Where(expression).AsQueryable();
        }

        public void Create(T entity)
        {
            this._unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._unitOfWork.Context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._unitOfWork.Context.Set<T>().Remove(entity);
        }
    }
}