using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
    public abstract class DbContext
    {
        private readonly DatabaseConnection connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime)
        };

        protected DbContext(string connectionString)
        {
            connection = new DatabaseConnection(connectionString);

            dbSetProperties = DiscoverDbSets();

            using (new ConnectionManager(connection))
            {
                InitialiseDbSets();
            }

            MapAllRelations();
        }

        public void SaveChanges()
        {
            var dbSets = dbSetProperties.Select(p => p.Value.GetValue(this)).ToArray();

            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet.Where(e => !IsObjectValid(e)).ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException
                        ($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}!");
                }
            }

            using (new ConnectionManager(connection))
            {
                using (var transaction = connection.StartTransaction())
                {
                    foreach (IEnumerable<object> dbSet in dbSets)
                    {
                        var dbSetType = dbSet.GetType().GetGenericArguments().First();

                        var persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                            .MakeGenericMethod(dbSetType);

                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var tableName = GetTableName(typeof(TEntity));

            var columns = connection.FetchColumnNames(tableName).ToArray();

            if (dbSet.ChangeTracker.Added.Any())
            {
                connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            var modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();

            if(modifiedEntities.Any())
            {
                connection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            if(dbSet.ChangeTracker.Removed.Any())
            {
                connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {

        }

        private string GetTableName(Type type)
        {
            throw new NotImplementedException();
        }

        private bool IsObjectValid(object e)
        {
            throw new NotImplementedException();
        }

        private void MapAllRelations()
        {
            throw new NotImplementedException();
        }

        private void InitialiseDbSets()
        {
            foreach (var dbSet in dbSetProperties)
            {
                var dbSetType = dbSet.Key;
                var dbSetProperty = dbSet.Value;

                //PopulateDbSet<dbSetType>(dbSetProperty);  --doesnt work, so reflection has to be used

                var populateDbSetGeneric = typeof(DbContext)
                        .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                        .MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            throw new NotImplementedException();
        }
    }
}