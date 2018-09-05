using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// ���ݿ���������
    /// </summary>
    public class SQLiteConnectConfiguration : IConnectConfiguration
    {
        #region var
        DataAccessConfiguration _config;
        #endregion

        public SQLiteConnectConfiguration(DataAccessConfiguration config)
		{
            _config = config;
		}

        #region IConnectConfiguration Members
        /// <summary>
        /// ���ݿ������ִ�
        /// </summary>
		public string ConnectionString
		{
			get
			{
                return "Data Source=" + Path.Combine(Environment.CurrentDirectory, _config.Parameters["DBFile"]);
			}
        }

        public string ParameterPrefix
        {
            get
            {
                return ":";
            }
        }
        #endregion
    }
}
