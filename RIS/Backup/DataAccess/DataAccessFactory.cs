using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// ���ݷ��ʹ���//TODO:���ӳ�
    /// </summary>
    public partial class DataAccessFactory
    {
        /// <summary>
        /// ��ȡĬ�����ݷ���
        /// </summary>
        /// <returns></returns>
        public static DataAccessBroker Instance()
        {
            return Instance("");
        }

        /// <summary>
        /// �������ƻ�ȡ���ݷ���
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns></returns>
        public static DataAccessBroker Instance(string instanceName)
        {
            return Instance(GetConfig(instanceName.Trim()));
        }

        protected static DataAccessConfiguration GetConfig(string instanceName)
        {
            return DataAccessConfigurationMangement.GetDataAccessConfiguration(instanceName.Trim());
        }
    }
}
