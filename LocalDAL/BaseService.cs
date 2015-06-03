using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Collections;
using NHibernate.Criterion;

namespace LocalDAL
{
    public class BaseService
    {
        protected ISession GetSession()
        {
            return SessionFactory.GetSession();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="obj"></param>
        public void Persist(Object obj)
        {
            ISession session = null;
            ITransaction tx = null;
            try
            {
                session = SessionFactory.GetSession();
                tx = session.BeginTransaction();

                session.Persist(obj);

                tx.Commit();
            }
            catch(Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
                tx.Rollback();
                throw;
            }
            finally
            {
                session.Close();
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="obj"></param>
        public void Save(Object obj)
        {
            ISession session = null;
            ITransaction tx = null;
            try
            {
                session = SessionFactory.GetSession();
                tx = session.BeginTransaction();

                session.Save(obj);
                tx.Commit();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
                tx.Rollback();
                throw;
            }
            finally
            {
                session.Close();
            }
        }


        /// <summary>
        /// 保存&&更新
        /// </summary>
        /// <param name="obj"></param>
        public void SaveOrUpdate(Object obj)
        {
            ISession session = null;
            ITransaction tx = null;
            try
            {
                session = SessionFactory.GetSession();
                tx = session.BeginTransaction();

                session.SaveOrUpdate(obj);
                session.Flush();
                tx.Commit();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
                tx.Rollback();
                throw;
            }
            finally
            {
                session.Close();
            }
        }

        /// <summary>
        /// 保存并返回ID
        /// </summary>
        /// <param name="obj"></param>
        public object SaveAndReturnID(Object obj)
        {
            ISession session = null;
            ITransaction tx = null;
            object id=null;
            try
            {
                session = SessionFactory.GetSession();
                tx = session.BeginTransaction();

                id=session.Save(obj);
                tx.Commit();
                return id;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
                tx.Rollback();
                throw;
            }
            finally
            {
                session.Close();
            }
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="obj"></param>
        public void Remove(Object obj)
        {
            ISession session = null;
            ITransaction tx = null;
            try
            {
                session = SessionFactory.GetSession();
                tx = session.BeginTransaction();

                session.Delete(obj);

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                session.Close();
            }
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entiyType"></param>
        /// <returns></returns>
        public IList<T> FindAll<T>() where T : new()
        {
           
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession();
                return session.CreateCriteria(typeof(T)).List<T>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                session.Close();
            }
        }

        /// <summary>
        /// 查询所有,并按要求排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entiyType"></param>
        /// <returns></returns>
        public IList<T> findAllwithOrders<T>(params NOrder[] orderFields) where T : new()
        {
            
            if (orderFields == null ||orderFields.Length == 0)
            {
                return null;
            }
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession();
                ICriteria qbc= session.CreateCriteria(typeof(T));
                foreach (NOrder order in orderFields)
                {
                    qbc.AddOrder(
                        order.OrderType == NOrder.OrderDirection.ASC ?
                        Order.Asc(order.PropertyName) :
                        Order.Desc(order.PropertyName)
                    );
                }
                return qbc.List<T>();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                session.Close();
            }

            
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entiyType"></param>
        /// <returns></returns>
        public IList GetAll(Type entityType)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession();
                return session.CreateCriteria(entityType).List();
            }
            catch(Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
                throw;
            }
            finally
            {
                session.Close();
            }
        }

        /// <summary>
        /// 根据对象oid进行查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oid"></param>
        /// <returns></returns>
        public T findById<T>(object oid) where T : new()
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession();
                return session.Get<T>(oid);
            }
            catch(Exception ex)
            {
                LogHelper.Error(ex.Message);
                throw;
            }
            finally
            {
                if (session != null)
                {
                    session.Close();
                }

            }
        }

      

        /// <summary>
        /// 修改对象
        /// </summary>
        /// <param name="obj"></param>
        public void Update(object obj)
        {
            try
            {
                using (ISession session = SessionFactory.GetSession())
                {
                    session.Update(obj);
                    session.Flush();
                    session.Close();
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
           
        }

        


        public void DoPager(PageInfo pi)
        {
            
            if (pi.EntityType == null)
            {
                throw new Exception("分页类名不能为空");
            }

            using (ISession session = SessionFactory.GetSession())
            {

                ICriteria qbc = session.CreateCriteria(pi.EntityType);
                //总条数
                qbc.SetProjection(NHibernate.Criterion.Projections.RowCount());
                prepareConditions(qbc, pi.Conditions);
                pi.RecordCount = qbc
                            .SetMaxResults(1)
                            .UniqueResult<int>();
                //总页数
                pi.PageCount =
                    pi.RecordCount % pi.PageSize == 0 ?
                    pi.RecordCount / pi.PageSize :
                    pi.RecordCount / pi.PageSize + 1;
                //qbc.SetProjection(null);
                //分页结果
                ICriteria _qbc = session.CreateCriteria(pi.EntityType);
                prepareConditions(_qbc, pi.Conditions);
                //设置排序
                prepareOrder(_qbc, pi.OrderFields);
                //分页结果
                pi.List = _qbc
                        .SetFirstResult((pi.PageIndex - 1) * pi.PageSize)
                        .SetMaxResults(pi.PageSize)
                        .List();
            }
        }

        /// <summary>
        /// 处理条件
        /// </summary>
        /// <param name="qbc"></param>
        /// <param name="conditions"></param>
        private void prepareConditions(ICriteria qbc, params NCondition[] conditions)
        {
            if (qbc == null || conditions == null || conditions.Length == 0)
            {
                return;
            }
            foreach (NCondition condition in conditions)
            {
                switch (condition.Operate)
                {
                    case Operation.EQ:
                        qbc.Add(Expression.Eq(condition.PropertyName, condition.PropertyValue));
                        break;
                    case Operation.GT:
                        qbc.Add(Expression.Gt(condition.PropertyName, condition.PropertyValue));
                        break;
                    case Operation.LT:
                        qbc.Add(Expression.Lt(condition.PropertyName, condition.PropertyValue));
                        break;
                    case Operation.GE:
                        qbc.Add(Expression.Ge(condition.PropertyName, condition.PropertyValue));
                        break;
                    case Operation.LE:
                        qbc.Add(Expression.Le(condition.PropertyName, condition.PropertyValue));
                        break;
                    case Operation.NE:
                        qbc.Add(Expression.Not(
                                Expression.Eq(condition.PropertyName, condition.PropertyValue)
                            ));
                        break;
                    case Operation.BETWEEN:
                        qbc.Add(Expression.Between(
                            condition.PropertyName,
                            (condition.PropertyValue as Object[])[0],
                            (condition.PropertyValue as Object[])[1]
                          )
                        );
                        break;
                    case Operation.LIKE:
                        qbc.Add(Expression.Like(
                            condition.PropertyName,
                            condition.PropertyValue.ToString(),
                            MatchMode.Anywhere
                           )
                         );
                        break;
                    case Operation.IN:
                        qbc.Add(Expression.In(condition.PropertyName, condition.PropertyValue as object[]));
                        break;
                }
            }
        }

        /// <summary>
        /// 处理排序
        /// </summary>
        /// <param name="qbc"></param>
        /// <param name="orderFields"></param>
        private void prepareOrder(ICriteria qbc, params NOrder[] orderFields)
        {
            if (qbc == null || orderFields == null ||
                orderFields.Length == 0)
            {
                return;
            }

            foreach (NOrder order in orderFields)
            {
                qbc.AddOrder(
                    order.OrderType == NOrder.OrderDirection.ASC ?
                    Order.Asc(order.PropertyName) :
                    Order.Desc(order.PropertyName)
                );
            }
        }

        /// <summary>
        /// 根据单个属性查询对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        public T FindByProperty<T>(String propertyName, Object propertyValue)
        {
            try
            {
                using (ISession session = SessionFactory.GetSession())
                {
                    return
                        session
                            .CreateCriteria(typeof(T))
                            .Add(Restrictions.Eq(propertyName, propertyValue))
                            .SetMaxResults(1)
                            .UniqueResult<T>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public IList<T> FindAllByProperty<T>(String propertyName,Object propertyValue) where T : new()
        {
            using (ISession session = SessionFactory.GetSession())
            {
                return
                    session
                        .CreateCriteria(typeof(T))
                        .Add(Restrictions.Eq(propertyName, propertyValue)).List<T>(); 
            }
        }


        public IList<T> FindAllWithOrdersByProperty<T>(String propertyName, Object propertyValue, params NOrder[] orderFields) where T : new()
        {
            if (orderFields == null ||
                orderFields.Length == 0)
            {
                return null;
            }
            using (ISession session = SessionFactory.GetSession())
            {
                ICriteria qbc = session.CreateCriteria(typeof(T)).Add(Restrictions.Eq(propertyName, propertyValue));

                foreach (NOrder order in orderFields)
                {
                    qbc.AddOrder(
                        order.OrderType == NOrder.OrderDirection.ASC ?
                        Order.Asc(order.PropertyName) :
                        Order.Desc(order.PropertyName)
                    );
                }

                return qbc.List<T>();
            }
        }


        public T FindByProperty<T>(String[] propertyNames, Object[] propertyValues)
        {
            if (propertyNames == null ||
                propertyValues == null ||
                propertyNames.Length == 0 ||
                propertyValues.Length == 0 ||
                propertyNames.Length != propertyValues.Length)
            {
                return default(T);
            }

            using (ISession session = SessionFactory.GetSession())
            {
                ICriteria qbc = session.CreateCriteria(typeof(T));
                for (int i = 0; i < propertyNames.Length; i++)
                {
                    qbc.Add(Restrictions.Eq(propertyNames[i], propertyValues[i]));
                }

                qbc.SetMaxResults(1);
                return qbc.UniqueResult<T>();
            }
        }
    }
}
