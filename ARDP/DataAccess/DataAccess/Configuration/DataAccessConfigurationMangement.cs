using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// ���ݿ�������ù���
    /// </summary>
    public static class DataAccessConfigurationMangement
    {
        private const string CONFIGURATION_FILE_NAME = "DataAccessConfiguration.config";
        internal static string ConfigFile;
        internal static string AssemblyPath;
        private static Dictionary<string, DataAccessConfiguration> _cachedConfig;

        /// <summary>
        /// ��ʼ�������ļ�Ŀ¼
        /// </summary>
        internal static void Initialize()
        {
            //AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName) + @"\";
            //ConfigFile = AssemblyPath + CONFIGURATION_FILE_NAME;
            AssemblyPath = DataAccessFactory.AssemblyPath;
            ConfigFile = AssemblyPath + "DataAccessConfiguration.config";
        }

        /// <summary>
        /// ��̬���캯��
        /// </summary>
        static DataAccessConfigurationMangement()
		{
            _cachedConfig = new Dictionary<string, DataAccessConfiguration>();
            Initialize();
		}

        /// <summary>
        /// ��ȡĬ������
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultConfigName()
        {
            string strDefaultInstanceName;
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigFile);

            XmlNode objNode = doc.SelectSingleNode("configuration/instances");
            strDefaultInstanceName = objNode.Attributes["defaultInstance"].Value.ToString();
            
            return strDefaultInstanceName;
        }

        /// <summary>
        /// ������������ȡ������Ϣ
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static DataAccessConfiguration GetDataAccessConfiguration(string configName)
		{
            if (!_cachedConfig.ContainsKey(configName))
            {
                string factConfigName = configName;
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);

                XmlNode objNode = doc.SelectSingleNode("configuration/instances");
                if (factConfigName.Length == 0)//����������Ϊ�������Ĭ������
                {
                    factConfigName = objNode.Attributes["defaultInstance"].Value.ToString();
                }

                XmlNodeList objNodeList = objNode.SelectNodes("instance");
                int iCount = objNodeList.Count;

                XmlNode objDefaultNode = null;
                for (int i = 0; i < iCount; i++)//�����������Ʊ���instance�����нڵ�
                {
                    if (String.Compare(objNodeList[i].Attributes["name"].Value.ToString(), factConfigName, false) == 0)
                    {
                        objDefaultNode = objNodeList[i];
                        break;
                    }
                }
                if (null == objDefaultNode)
                {
                    throw new Exception("Can't find the instance configure information.");
                }
                string strConnName = objDefaultNode.Attributes["connectionString"].Value.ToString();//��ȡ��������


                XmlNode objConnNode = null;
                objNodeList = doc.SelectNodes("configuration/connectionStrings/connectionString");
                iCount = objNodeList.Count;
                for (int i = 0; i < iCount; i++)//�����������Ʊ���connectionStrings�����нڵ�
                {
                    if (String.Compare(objNodeList[i].Attributes["name"].Value.ToString(), strConnName, false) == 0)
                    {
                        objConnNode = objNodeList[i];
                        break;
                    }
                }
                if (null == objConnNode)
                {
                    throw new Exception("Can't find the instance configure information.");
                }

                DataAccessConfiguration config = new DataAccessConfiguration();
                config.ConfigName = factConfigName;
                config.DBType = objDefaultNode.Attributes["type"].Value.ToString();

                objNodeList = objConnNode.SelectNodes("parameters/parameter");
                iCount = objNodeList.Count;
                for (int i = 0; i < iCount; i++)
                {
                    config.Parameters[objNodeList[i].Attributes["name"].Value.Trim()] = objNodeList[i].Attributes["value"].Value.Trim();
                }
                _cachedConfig[configName] = config;
            }
            return _cachedConfig[configName];
		}
	}
}
