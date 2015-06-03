using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace LocalDAL
{
    /// <summary>
    /// 自定义的查询方法
    /// </summary>
    public class BaseQuery
    {
        protected ISession GetSession()
        {
            return SessionFactory.GetSession();
        }
        /// <summary>
        /// 通用的查询方法，这个函数可以作为其他查询函数的基础，以此扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public IList<T> Query<T>(String str) where T : new()
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession();
                return session.CreateQuery(str).List<T>();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// 带参数的复杂查询，没有测试过O_o，注意参数值一定要可以ToString 不能的话自己Override吧,不要问我我什么也不知道
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="parameters"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public IList<T> Query<T>(String str,String[] parameters,Object[] values ) where T : new()
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession();
                IQuery query=session.CreateQuery(str);
                for (int i = 0; i < parameters.Length; i++)
                {
                    query.SetString(parameters[i], values[i].ToString());
                }
                return query.List<T>();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        
    }
}
