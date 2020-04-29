﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerUtilityApp.API.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
