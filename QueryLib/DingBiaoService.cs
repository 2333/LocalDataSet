using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalEntity;
using LocalEntity.Entities;
using LocalDAL;

namespace QueryLib
{
    class DingBiaoService
    {
        private bool isOnline;
        private QueryProxy.DingBiaoManage.DingBiaoManageClient online;//在线用的查询服务
        private BaseService service;//离线用的查询服务
        private BaseQuery query;

        public bool IsOnline
        {
            get { return isOnline; }
            set { isOnline = value; }
        }

        public DingBiaoService()
        {
            online = new QueryProxy.DingBiaoManage.DingBiaoManageClient();
            service = new BaseService();
            query = new BaseQuery();
        }
        /// <summary>
        /// 插入或更新对象
        /// </summary>
        /// <param name="dingbiao"></param>
        public void insertOrUpdateDingBiao(DingBiao dingbiao)
        {
            if (IsOnline)
            {
                online.insertOrUpdateDingBiao(Helper.LDingBiao2SDingBiao(dingbiao));
            }
            else
            {
                service.SaveOrUpdate(dingbiao);
            }
        }
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="dingbiao"></param>
        public void deleteDingBiao(DingBiao dingbiao)
        {
            if (IsOnline)
            {
                online.deleteDingBiao(Helper.LDingBiao2SDingBiao(dingbiao));
            }
            else
            {
                service.Remove(dingbiao);
            }
        }
        /// <summary>
        /// 查询对象ID
        /// </summary>
        /// <param name="planid"></param>
        /// <returns></returns>
        public List<DingBiao> queryDingBiaobyPlanID(int planid)
        {
            List<DingBiao> result = new List<DingBiao>();
            
            if (IsOnline)
            {
                List<QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK> list = online.queryDingBiaobyPlanID(planid);
                if(list!=null)
                {
                    foreach(QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK dingbiao in list)
                    {
                        result.Add(Helper.ServerDingBiao2LocalDingBiao(dingbiao));
                    }
                }
            }
            else
            {
                DingBiao db = new DingBiao();
                result= service.FindAllByProperty<DingBiao>(db.PLANID, planid).ToList<DingBiao>();

            }
            return result;
        }
    }
}
