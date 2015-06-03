using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalDAL;
using LocalEntity;
using LocalEntity.Entities;

namespace QueryLib
{
    internal class PlanService
    {
        private bool isOnline;
        private QueryProxy.PlanManage.PlanManageClient online;
        private BaseService service;
        private BaseQuery query;

        public PlanService()
        {
            online = new QueryProxy.PlanManage.PlanManageClient();
            service = new BaseService();
            query = new BaseQuery();
        }

        public bool IsOnline
        {
            get { return isOnline; }
            set { isOnline = value; }
        }
        private void insertOrUpdatePlan(PLAN plan)
        {
            if (IsOnline)
            {
                online.insertOrUpdatePlan(Helper.LPlan2SPlan(plan));
            }
            else
            {
                service.SaveOrUpdate(plan);
            }
        }

        public void deletePlan(PLAN plan)
        {
            if (IsOnline)
            {
                online.deletePlan(Helper.LPlan2SPlan(plan));
            }
            else
            {
                service.Remove(plan);
            }
        }

        public PLAN queryPlan(string planid)
        {
            PLAN plan = null;
            if (IsOnline)
            {
                plan = Helper.ServerPlan2LocalPlan(online.queryPlan(planid));
            }
            else
            {
                plan = service.findById<PLAN>(planid);
            }
            return plan;
        }

        public List<string> queryPlanID(DateTime starttime, DateTime endtime)
        {
            List<string> strs = new List<string>();
            if (IsOnline)
            {
                strs = online.queryPlanID(starttime, endtime);
            }
            else
            {
                
               List<PLAN> list = query.Query<PLAN>("from PLAN where PLANTYPE = 'LO'").ToList();
                if(list!= null)
                {
                    foreach(PLAN plan in list)
                    {
                        strs.Add(plan.PLANID);
                    }
                }
                /*service.FindAllByProperty*/
                //没找到好44方法
            }
            return strs;
        }
    }
}
