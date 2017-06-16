﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using System.Data.Entity.Validation;

namespace Beginner.Blog.Core
{
    /// <summary>
    /// 基于EF的资源库基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<TEntity> _entities;

        public EfRepository(IDbContext context)
        {
            _context = context;
        }
        #region Utilities

        /// <summary>
        /// Get full error
        /// </summary>
        /// <param name="exc">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
            return msg;
        }

        #endregion

        #region CURD
        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public virtual async Task DeleteAsync(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);

                await this._context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                    throw new ArgumentNullException("entity");

                Entities.Where(predicate).Delete();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public virtual void Insert(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    this.Entities.Add(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public virtual async Task InsertAsync(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);

                await this._context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public virtual async Task InsertAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    this.Entities.Add(entity);

                await this._context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public virtual void Update(Expression<Func<TEntity, TEntity>> updateExpression)
        {
            try
            {
                if (updateExpression == null)
                    throw new ArgumentNullException("updateExpression");

                Entities.Update(updateExpression);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public virtual async Task UpdateAsync(Expression<Func<TEntity, TEntity>> updateExpression)
        {
            try
            {
                if (updateExpression == null)
                    throw new ArgumentNullException("updateExpression");

                await Entities.UpdateAsync(updateExpression);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public virtual void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        #endregion
        #region Queryable
        public virtual IQueryable<TEntity> Table
        {
            get
            {
                return Entities;
            }
        }
        public virtual IQueryable<TEntity> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }
        #endregion
        #region Query 
        public virtual TEntity FindById(object id)
        {
            return Entities.Find(id);
        }
        public virtual IList<TEntity> FindAll()
        {
            return Entities.OrderBy(p => p.Id).ToList();
        }
        public virtual IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).OrderBy(p => p.Id).ToList();
        }
        public virtual PagedList<TEntity> FindPage(int pageIndex, int pageSize)
        {
            var pageList = new PagedList<TEntity>();
            var items = Entities.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var totalItems = Entities.Count();
            var totalPages = (totalItems % pageSize) == 0 ? (totalItems / pageSize) : (totalItems / pageSize) + 1;
            pageList.CurrentPage = pageIndex;
            pageList.ItemsPerPage = pageSize;
            pageList.TotalPages = totalPages;
            pageList.TotalItems = totalItems;
            pageList.Items = items;
            return pageList;
        }
        public virtual async Task<PagedList<TEntity>> FindPageAsync(int pageIndex, int pageSize)
        {
            var pageList = new PagedList<TEntity>();
            var items = await Entities.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var totalItems = await Entities.CountAsync();
            var totalPages = (totalItems % pageSize) == 0 ? (totalItems / pageSize) : (totalItems / pageSize) + 1;
            pageList.CurrentPage = pageIndex;
            pageList.ItemsPerPage = pageSize;
            pageList.TotalPages = totalPages;
            pageList.TotalItems = totalItems;
            pageList.Items = items;
            return pageList;
        }
        public virtual PagedList<TEntity> FindPage(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            var pageList = new PagedList<TEntity>();
            var items = Entities.Where(predicate).OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var totalItems = Entities.Where(predicate).Count();
            var totalPages = (totalItems % pageSize) == 0 ? (totalItems / pageSize) : (totalItems / pageSize) + 1;
            pageList.CurrentPage = pageIndex;
            pageList.ItemsPerPage = pageSize;
            pageList.TotalPages = totalPages;
            pageList.TotalItems = totalItems;
            pageList.Items = items;
            return pageList;
        }
        public virtual async Task<PagedList<TEntity>> FindPageAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            var pageList = new PagedList<TEntity>();
            var items = await Entities.Where(predicate).OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var totalItems = await Entities.Where(predicate).CountAsync();
            var totalPages = (totalItems % pageSize) == 0 ? (totalItems / pageSize) : (totalItems / pageSize) + 1;
            pageList.CurrentPage = pageIndex;
            pageList.ItemsPerPage = pageSize;
            pageList.TotalPages = totalPages;
            pageList.TotalItems = totalItems;
            pageList.Items = items;
            return pageList;
        }
        #endregion
        #region Protected
        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IDbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();
                return _entities;
            }
        }
        #endregion

    }
}