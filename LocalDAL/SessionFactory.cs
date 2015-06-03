using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace LocalDAL
{
    public class SessionFactory
    {
        static Configuration config = null;
        static ISessionFactory sessionFactory = null;
     
        /// <summary>
        /// 构造方法(相当于Java的静态代码块)
        /// </summary>
        static SessionFactory()
        {
            config = new Configuration().Configure();
            sessionFactory = config.BuildSessionFactory();  
        }

        /// <summary>
        /// 得到SessionFactory
        /// </summary>
        /// <returns></returns>
        public static ISessionFactory GetSessionFactory()
        {
            return sessionFactory;
        }

        /// <summary>
        /// 获得Session
        /// </summary>
        /// <returns></returns>
        public static ISession GetSession()
        {
            return sessionFactory.OpenSession();
        }

        public static void DisposeCurrentSession()
        {
            ISession currentSession = CurrentSessionContext.Unbind(GetSessionFactory());

            currentSession.Close();
            currentSession.Dispose();
        }
    }
}
