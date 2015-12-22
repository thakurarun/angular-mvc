using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Database;
using DataLayer;
using System.Data.Entity;

namespace RepositoryLayer
{
    public abstract class BaseRepository : ResultSet
    {
        private PasswordManagerEntities _dbContext;
        protected internal PasswordManagerEntities DbContext
        {
            get { return _dbContext ?? (_dbContext = new PasswordManagerEntities()); }
        }

        private ResultSet _ResultSet;
        protected ResultSet ResultSet { get { return _ResultSet ?? (_ResultSet = new ResultSet()); } }
        /// <summary>
        /// This Method will retrieve all the enities from database. Avoid this method as there are no criteria to filter data.
        /// Created by Arun Thakur
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ob"></param>
        /// <returns></returns>
        protected IEnumerable<T> GetAll<T>() where T : class
        {
            var dbSet = DbContext.Set<T>();
            return dbSet.AsEnumerable<T>();
        }
        /// <summary>
        /// This Method will Add the enity and save the changes to database
        /// Created by Arun Thakur
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ob"></param>
        /// <returns></returns>
        protected ResultSet InsertEntity<T>(T ob) where T : class
        {
            try
            {
                var dbSet = DbContext.Set<T>();
                dbSet.Add(ob);
                SaveChanges();
                ResultSet.IsSuccess = true;
                ResultSet.ResultObject = ob;
            }
            catch (Exception ex)
            {
                ResultSet.IsSuccess = false;
                ResultSet.ErrorMessage = ex.GetBaseException().Message;
            }
            return ResultSet;
        }
        /// <summary>
        /// This Method will modified the enity and save the changes to database
        /// Created by Arun Thakur
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ob"></param>
        /// <returns></returns>
        protected ResultSet UpdateEntity<T>(T ob) where T : class
        {
            try
            {
                DbContext.Entry(ob).State = EntityState.Modified;
                SaveChanges();
                ResultSet.IsSuccess = true;
            }
            catch (Exception ex)
            {
                ResultSet.IsSuccess = false;
                ResultSet.ErrorMessage = ex.GetBaseException().Message;
            }
            return ResultSet;
        }
        /// <summary>
        /// This Method will delete the enity and save the changes to database
        /// Avoid this method as it will hard remove from database.
        /// Created by Arun Thakur
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ob"></param>
        /// <returns></returns>
        protected ResultSet DeleteEntity<T>(T ob) where T : class
        {
            try
            {
                DbContext.Entry(ob).State = EntityState.Deleted;
                SaveChanges();
                ResultSet.IsSuccess = true;
            }
            catch (Exception ex)
            {
                ResultSet.IsSuccess = false;
                ResultSet.ErrorMessage = ex.GetBaseException().Message;
            }
            return ResultSet;
        }
        private void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
