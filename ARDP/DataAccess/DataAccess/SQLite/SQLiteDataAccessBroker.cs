using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using Suzsoft.Smart.EntityCore;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// Sql�����ݷ���broker
    /// </summary>
    public class SQLiteDataAccessBroker : DataAccessBroker
    {
        internal override void Create()
        {
            _connection = new SQLiteConnection(Configuration.ConnectionString);
            _connection.Open();//TODO:
        }

        /// <summary>
        /// ����ǰ׺()
        /// </summary>
        protected override string ParameterPrefix
        {
            get { return Configuration.ParameterPrefix; }
        }

        /// <summary>
        /// ����Command
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        protected override DbCommand CreateCommand(string commandString)
        {
            SQLiteCommand command = new SQLiteCommand(commandString, (SQLiteConnection)_connection);
            return command;
        }

        /// <summary>
        /// ��Ӳ���
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameter"></param>
        protected override void AddParameter(DbCommand command, DataAccessParameter parameter)
        {
            SQLiteCommand comm = command as SQLiteCommand;
            if (comm != null)
            {
                comm.Parameters.AddWithValue(parameter.ParameterName, parameter.ParameterValue);
                comm.Parameters[parameter.ParameterName].Direction = parameter.Direction;
            }
        }

        /// <summary>
        /// ��ȡDataset
        /// </summary>
        /// <param name="command"></param>
        /// <param name="mapping"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override int ExecuteDataSet(DbCommand command, DataTableMapping mapping, ref DataSet result)
        {
            int r = 0;
            SQLiteCommand comm = command as SQLiteCommand;
            if (comm != null)
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                if (mapping != null)
                {
                    adapter.TableMappings.Add(mapping);
                }
                r = adapter.Fill(result);
            }
            return r;
        }
    }
}
