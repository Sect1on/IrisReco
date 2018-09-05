using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// ���ݿ���������
    /// </summary>
    public class DataAccessConfiguration
    {
        #region var
        private Dictionary<string, string> _parameters;
        /// <summary>
        /// ��������
        /// </summary>
        public Dictionary<string, string> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        private string _configName;
        /// <summary>
        /// ����������
        /// </summary>
		public string ConfigName
		{
			get
			{
                return _configName;
			}
			set
			{
                _configName = value;
			}
		}

        private string _dBType;
        /// <summary>
        /// ���ݿ�����
        /// </summary>
		public string DBType
		{
			get
			{
                return _dBType;
			}
			set
			{
                _dBType = value;
			}
		}

        #endregion

        public DataAccessConfiguration()
		{
            _parameters = new Dictionary<string, string>();
		}
    }
}
