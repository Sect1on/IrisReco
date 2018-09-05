using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.EntityCore
{
    /// <summary>
    /// SQL��������
    /// </summary>
    public class DataAccessParameterCollection : Dictionary<string, DataAccessParameter>
    {
        public DataAccessParameterCollection()
        {
        }

        /// <summary>
        /// ���SQL�����б�-�������
        /// </summary>
        /// <param name="ParamName"></param>
        /// <param name="ParamValue"></param>
        public virtual void AddWithValue(string parameterName, object parameterValue)
        {
            AddWithValue(parameterName, parameterValue, System.Data.ParameterDirection.Input);
        }


        /// <summary>
        /// ���SQL�����б�
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="direction"></param>
        public virtual void AddWithValue(string parameterName, object parameterValue, System.Data.ParameterDirection direction)
        {
            DataAccessParameter parameter = new DataAccessParameter(parameterName, parameterValue, direction);
            this[parameterName] = parameter;
            if (parameterValue is int)
            {
                parameter.DbType = System.Data.DbType.Int32;
            }
        }
    }
}
