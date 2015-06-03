using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace LocalDAL
{
    public class LogHelper
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("LocalDB");

        /// <summary>  
        /// 记录 调式信息日志  
        /// </summary>  
        /// <param name="strLog">调试日志的内容</param>  
        public static void Debug(string strLog)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(strLog);
            }
        }

        /// <summary>  
        /// 记录 错误消息日志  
        /// </summary>  
        /// <param name="strLog">错误消息的内容</param>  
        public static void Error(string strLog)
        {
            if (log.IsErrorEnabled)
            {
                log.Error(strLog);
            }
        }

        /// <summary>  
        /// 记录 普通信息日志  
        /// </summary>  
        /// <param name="strLog">普通消息的内容</param>  
        public static void Info(string strLog)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(strLog);
            }
        }

        /// <summary>  
        /// 记录 警告信息日志  
        /// </summary>  
        /// <param name="strLog">警告消息的内容</param>  
        public static void Warn(string strLog)
        {
            if (log.IsWarnEnabled)
            {
                log.Warn(strLog);
            }
        }
    }  
}
