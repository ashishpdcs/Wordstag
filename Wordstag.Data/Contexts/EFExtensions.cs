using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wordstag.Data.Contexts;
using Wordstag.Data.Extensions;

namespace Wordstag.Data.Contexts
{
    public static class EFExtensions
    {
        //public static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storedProcName"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static DbCommand LoadStoredProc(this BaseDBContext context, string storedProcName, int timeout = 20)
        {
            var cmd = context.DbContext.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = storedProcName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = timeout;
            return cmd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storedProcName"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static DbCommand LoadStoredProc(this BaseDBContext context, string storedProcName, string connectionString, int timeout = 20)
        {
            var cmd = context.DbContext.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = storedProcName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = timeout;
            cmd.Connection.ConnectionString = connectionString;
            return cmd;
        }
        /// <summary>
        /// Creates a DbParameter object and adds it to a DbCommand
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, object paramValue, DbType paramType = DbType.String, ParameterDirection paramDirection = System.Data.ParameterDirection.Input, Action<DbParameter> configureParam = null, int size = 0)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != System.Data.CommandType.StoredProcedure)
                throw new InvalidOperationException("Call LoadStoredProc before using this method");

            var param = cmd.CreateParameter();
            param.DbType = paramType;
            param.ParameterName = paramName;
            param.Value = paramValue;
            if (size != 0)
                param.Size = size;
            param.Direction = paramDirection;
            configureParam?.Invoke(param);
            cmd.Parameters.Add(param);
            return cmd;
        }

        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, Action<DbParameter> configureParam = null)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != System.Data.CommandType.StoredProcedure)
                throw new InvalidOperationException("Call LoadStoredProc before using this method");

            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            configureParam?.Invoke(param);
            cmd.Parameters.Add(param);
            return cmd;
        }


        /// <summary>
        /// Executes a DbDataReader and returns a list of mapped column values to the properties of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public static int ExecuteStoredProc(this DbCommand command, Action<SprocResults> handleResults, System.Data.CommandBehavior commandBehaviour = System.Data.CommandBehavior.Default)
        {
            int retVal = 0;

            if (handleResults == null)
            {
                throw new ArgumentNullException(nameof(handleResults));
            }

            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var sprocResults = new SprocResults(reader);
                        // return new SprocResults();
                        handleResults(sprocResults);
                    }
                    foreach (DbParameter param in command.Parameters)
                    {
                        if (param.Direction == ParameterDirection.ReturnValue)
                            retVal = Convert.ToInt32("0" + param.Value);
                    }

                }
                catch (Exception ex)
                {
                    LogException(command, ex);

                    throw ex;
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return retVal;
        }

        /// <summary>
        /// Executes a non query stored proc
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static void ExecuteStoredProc(this DbCommand command, Action<SprocOutParams> handleResults, System.Data.CommandBehavior commandBehaviour = System.Data.CommandBehavior.Default)
        {
            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    var sprocOutParams = new SprocOutParams(command);
                    handleResults(sprocOutParams);
                }
                catch (Exception ex)
                {
                    LogException(command, ex);

                    throw ex;
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ex"></param>
        private static void LogException(DbCommand command, Exception ex)
        {
            string spParams = "";
            string spCommand = command.CommandText + " ";

            foreach (DbParameter param in command.Parameters)
            {

                if (param.DbType == DbType.Binary)
                    spParams += param.ParameterName + "='ZZZ'" + ", ";
                else
                {
                    spParams += param.ParameterName + "=" + (param.Value == null ? "null" : ("'" + param.Value + "'")) + ", ";
                }
            }

            if (spParams.LastIndexOf(",") == spParams.Length - 2)
                spCommand += spParams.Remove(spParams.Length - 2);

            //Log.Error(spCommand, ex);
        }
    }
}
