using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.EntityCore
{
    /// <summary>
    /// ���ݿ���е�����Ϣ
    /// </summary>
    public class ColumnInfo
    {
        private string _columnName;
        /// <summary>
        /// ����
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        private string _columnCaption;
        /// <summary>
        /// ������
        /// </summary>
        public string ColumnCaption
        {
            get { return _columnCaption; }
            set { _columnCaption = value; }
        }

        private bool _isPrimaryKey;
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }

        private bool _allowNull;
        /// <summary>
        /// �Ƿ�����Ϊ��
        /// </summary>
        public bool AllowNull
        {
            get { return _allowNull; }
            set { _allowNull = value; }
        }

        private object _defaultValue;
        /// <summary>
        /// ������Ϊ�յ�Ĭ��ֵ
        /// </summary>
        public object DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        private Type _dataType;
        /// <summary>
        /// ����
        /// </summary>
        public Type DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        private int _maxLength;
        /// <summary>
        /// ��󳤶�
        /// </summary>
        public int MaxLength
        {
            get { return _maxLength; }
            set { _maxLength = value; }
        }

        public ColumnInfo(string columnName, string columnCaption, bool isPrimaryKey, Type dataType)
        {
            _columnName = columnName;
            _columnCaption = columnCaption;
            _isPrimaryKey = isPrimaryKey;
            _dataType = dataType;
            _allowNull = false;
            _defaultValue = null;
            _maxLength = -1;
        }
    }
}
