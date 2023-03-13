using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Data.Extensions
{
    public class SprocResults
    {

        //  private DbCommand _command;
        private DbDataReader _reader;

        public SprocResults(DbDataReader reader)
        {
            // _command = command;
            _reader = reader;
        }

        public IList<T> ReadToList<T>()
        {
            return MapToList<T>(_reader);
        }

        public Task<bool> NextResultAsync()
        {
            return _reader.NextResultAsync();
        }

        public Task<bool> NextResultAsync(CancellationToken ct)
        {
            return _reader.NextResultAsync(ct);
        }

        public bool NextResult()
        {
            return _reader.NextResult();
        }

        public DataTable ReadToTable()
        {
            DataTable dt = new DataTable();
            dt.Load(_reader);
            return dt;
        }

        /// <summary>
        /// Retrieves the column values from the stored procedure and maps them to <typeparamref name="T"/>'s properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns>IList<<typeparamref name="T"/>></returns>
        private IList<T> MapToList<T>(DbDataReader dr)
        {
            var objList = new List<T>();
            var props = typeof(T).GetRuntimeProperties();

            var colMapping = dr.GetColumnSchema()
                .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                .ToDictionary(key => key.ColumnName.ToLower());

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        if (colMapping.ContainsKey(prop.Name.ToLower()))
                        {
                            var val = dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                            prop.SetValue(obj, val == DBNull.Value ? null : val);
                        }
                    }
                    objList.Add(obj);
                }
            }
            return objList;
        }


    }

    public class SprocOutParams
    {
        private DbCommand _command;

        public SprocOutParams(DbCommand command)
        {
            _command = command;
        }

        public object GetValue(string paramName)
        {
            return _command.Parameters[paramName].Value;
        }

    }
}

    