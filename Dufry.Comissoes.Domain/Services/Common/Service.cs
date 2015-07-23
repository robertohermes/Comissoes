﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dufry.Comissoes.Domain.Interfaces.Repository.Common;
using Dufry.Comissoes.Domain.Interfaces.Service.Common;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Services.Common
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : class
    {
        #region Constructor

        private readonly IRepository<TEntity> _repository;
        private readonly IReadOnlyRepository<TEntity> _readOnlyRepository;
        private readonly ValidationResult _validationResult;

        public Service(
            IRepository<TEntity> repository,
            IReadOnlyRepository<TEntity> readOnlyRepository)
        {
            _repository = repository;
            _readOnlyRepository = readOnlyRepository;
            _validationResult = new ValidationResult();
        }

        #endregion

        #region Properties

        protected IRepository<TEntity> Repository
        {
            get { return _repository; }
        }

        protected IReadOnlyRepository<TEntity> ReadOnlyRepository
        {
            get { return _readOnlyRepository; }
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        #endregion

        #region Read Methods

        public virtual TEntity Get(int id, bool @readonly = false)
        {
            return @readonly
                ? _readOnlyRepository.Get(id)
                : _repository.Get(id);
        }

        public virtual IEnumerable<TEntity> All(bool @readonly = false)
        {
            return _repository.All(@readonly);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _repository.Find(predicate, @readonly);
        }

        #endregion

        #region CRUD Methods

        public virtual ValidationResult Add(TEntity department)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _repository.Add(department);
            return _validationResult;
        }

        public virtual ValidationResult Update(TEntity department)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _repository.Update(department);
            return _validationResult;
        }

        public virtual ValidationResult Delete(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _repository.Delete(entity);
            return _validationResult;
        }

        #endregion
    }
}