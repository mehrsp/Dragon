using Rosentis.Core;
using Rosentis.Core.Filtering;
using Rosentis.Persistance.Facade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Rosentis.Persistance
{
        public class GenericRepository<TEntity> where TEntity : class
        {
            internal RosentisContext context;
            internal DbSet<TEntity> dbSet;

        protected Expression<Func<TEntity, object>>[] includes;

        public GenericRepository(RosentisContext context)
		{
			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}


		public virtual IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}
			if (includes != null && includes.Length > 0)
			{
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			}
			else
			{
			}
			if (orderBy != null)
			{
				return orderBy(query).ToList();
			}
			else
			{
				return query.ToList();
			}
		}

		public virtual TEntity GetFirst(
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (includes != null && includes.Length > 0)
                {
                    query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

                }
                else
                {
                }
                //foreach (var includeProperty in includeProperties.Split
                //    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    query = query.Include(includeProperty);
                //}

                if (orderBy != null)
                {
                    return orderBy(query).FirstOrDefault();
                }
                else
                {
                    return query.FirstOrDefault();
                }
            }


		//public virtual T GetById(object id)
		//{
		//	return _dbSet.Find(id);
		//}

		public virtual TEntity GetByID(object id)
            {
                return dbSet.Find(id);
                IQueryable<TEntity> query = dbSet;
            var propertyName = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)dbSet).ObjectContext
                .CreateObjectSet<TEntity>().EntitySet.ElementType.KeyMembers.Single().Name;

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var predicate = Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(parameter, propertyName),
                    Expression.Constant(id)),
                parameter);
            if (includes != null && includes.Length > 0)
                 query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.FirstOrDefault(predicate);
            }

            public virtual TEntity Insert(TEntity entity)
            {


			//IQueryable<TEntity> query = dbSet;
			//if (includes != null && includes.Length > 0)
			//{
			//	query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			//}
			//dbSet.Include(query);
			return dbSet.Add(entity);
		}

            public TEntity  Delete(object id)
            {
                TEntity entityToDelete = dbSet.Find(id);

            if(entityToDelete!=null)
               Delete(entityToDelete);
            return Delete(entityToDelete);
            }

            public virtual TEntity Delete(TEntity entityToDelete)
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                return dbSet.Remove(entityToDelete);
            }

            public virtual void Update(TEntity entityToUpdate)
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }

            public void SetIncludes(params Expression<Func<TEntity, object>>[] includeItems)
            {
                includes = includeItems;
            }
            public Expression<Func<TEntity, object>>[] GetIncludes()
            {
                return includes;
            }


		//public IList<TEntity> FindAll(Criteria criteria, List<SortItem> sortItems)
		//{
		//	IQueryable<TEntity> query = dbSet;

		//	IList<TEntity> result = query.FindAll<TEntity, TIdentifier>(criteria, sortItems);
		//	return result;
		//}

		public FilterResponse<TEntity> GetFilteredListForGrid(Expression<Func<TEntity, bool>> predicate, 
			GridRequest request, string queryStr)
		{
			IQueryable<TEntity> query = dbSet;
			if (queryStr != "") {
				query = dbSet.SqlQuery(queryStr).ToList().AsQueryable();
			}
	
			
			if (includes != null && includes.Length > 0)
			{
				query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			}
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			return query.ApplyFilter(request);
		}



	}
    }

