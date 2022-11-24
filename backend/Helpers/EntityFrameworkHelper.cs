using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace Motostore.Helpers
{
    public static class EntityFrameworkHelper
    {
        public static object GetPrimaryKeys<T>(T entity, DbContext dataContext) where T : class
        {
            EntityEntry entry = dataContext.Entry(entity);
            IKey primaryKey = entry.Metadata.FindPrimaryKey();
            IEnumerable<object> primaryKeyValuesList = primaryKey.Properties
                .ToDictionary(x => x.Name, x => x.PropertyInfo.GetValue(entity))
                .ToList()
                .Select((x) => x.Value);
            return primaryKeyValuesList.ToArray();
        }
        public static async Task<T> GetExistingEntity<T>(T entity, DbContext dataContext) where T : class
        {
            object[] primaryKeyValues = (object[])GetPrimaryKeys(entity, dataContext);
            return await dataContext.FindAsync<T>(primaryKeyValues);
        }
        public static async Task<T> SetEntityProperties<T>(T entity, T foundEntity, DbContext dataContext, string[] ignores = null, string[] force = null) where T : class
        {
            string[] ignoreProps = ignores ?? new string[] { };
            string[] forceProps = force ?? new string[] { };

            EntityEntry<T> newOrUpdatedEntity;
            if (foundEntity is T)
            {
                EntityEntry entityEntry = dataContext.Entry(foundEntity);
                Dictionary<string, object> props = new Dictionary<string, object>();
                PropertyInfo[] entityProps = entity.GetType().GetProperties();
                foreach (PropertyInfo propInfo in entityProps)
                {
                    object propValue = propInfo.PropertyType == typeof(DateTime?)
                        ? UtilityHelper.NormalizeDateTime(propInfo.GetValue(entity))
                        : propInfo.GetValue(entity);
                    if (
                        (
                            forceProps.Contains(propInfo.Name)
                            || (propValue != null || propInfo.PropertyType == typeof(DateTime?))
                        )
                        && !ignoreProps.Contains(propInfo.Name)
                    )
                    {
                        props.Add(propInfo.Name, propValue);
                    }
                }
                entityEntry.CurrentValues.SetValues(props);
                newOrUpdatedEntity = dataContext.Set<T>().Update(foundEntity);
            }
            else
            {
                newOrUpdatedEntity = await dataContext.Set<T>().AddAsync(entity);
            }
            return newOrUpdatedEntity.Entity;
        }
        public static async Task<T> AddOrUpdate<T>(T entity, T foundEntity, DbContext dataContext, string[] ignores = null) where T : class
        {
            return await SetEntityProperties(entity, foundEntity, dataContext, ignores);
        }
        public static async Task<T> AddOrUpdate<T>(T entity, DbContext dataContext, string[] ignores = null, string[] force = null) where T : class
        {
            T foundEntity = await GetExistingEntity(entity, dataContext);
            return await SetEntityProperties(entity, foundEntity, dataContext, ignores, force);
        }
        public static async Task<T> Delete<T>(T entity, DbContext dataContext) where T : class
        {
            object[] primaryKeyValues = (object[])GetPrimaryKeys(entity, dataContext);
            T foundEntity = await dataContext.FindAsync<T>(primaryKeyValues);
            if (foundEntity != null)
            {
                dataContext.Set<T>().Remove(foundEntity);
                await dataContext.SaveChangesAsync();
                return foundEntity;
            }
            return null;
        }
    }
}
