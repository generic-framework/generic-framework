﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities;
using Main.Server.Core.Repositories;
using Main.Server.Core.Services;
using Main.Server.Core.UnitOfWorks;

namespace Main.Server.Service.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWorks _unitOfWorks;

        public Service(IGenericRepository<T> repository, IUnitOfWorks unitOfWorks)
        {
            _repository = repository;
            _unitOfWorks = unitOfWorks;
        }
        public virtual async Task AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            await _repository.AddAsync(entity);

            await _unitOfWorks.CommitAsync();
        }

        public void ChangeStatus(T entity)
        {
            entity.UpdatedDate = DateTime.Now;

            _repository.ChangeStatus(entity);
            _unitOfWorks.Commit();
        }

        public int Count()
        {
           return _repository.Count();
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public void Update(T entity)
        {
             _repository.Update(entity);
            _unitOfWorks.Commit();   
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
           return _repository.Where(expression);
        }
    }
}
