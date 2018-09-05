using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// ���ݷ��ʹ���
    /// </summary>
    public partial class DataAccessFactory
    {
        /// <summary>
        /// �������û�ȡ���ݷ���
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static DataAccessBroker Instance(DataAccessConfiguration config)
        {
            DataAccessBroker _broker = new SQLiteDataAccessBroker();
            _broker.Configuration = new SQLiteConnectConfiguration(config);
            _broker.Create();//�����������ݿ�����
            return _broker;
        }

        public static IConnectConfiguration Config
        {
            get
            {
                return new SQLiteConnectConfiguration(GetConfig(""));
            }
        }

        public static string AssemblyPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory+@"\";
            }
        }
    }
}
