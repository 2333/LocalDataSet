
using LocalDAL;
using LocalEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryLib
{
    public class RT2TService
    {
        private bool isOnline;

        private QueryProxy.T2T_RManage.TaskTarget_RManageClient client;
        private BaseService service;
        private BaseQuery query;

        public RT2TService()
        {
            client = new QueryProxy.T2T_RManage.TaskTarget_RManageClient();
            service = new BaseService();
            query = new BaseQuery();
        }

        public bool IsOnline
        {
            get { return isOnline; }
            set { isOnline = value; }
        }

        public void InsertOrUpdateRelation(R_T2T relation)
        {
            if(IsOnline)
            {
                client.insertOrUpdateRelation(Helper.LR2SR(relation));
            }
            else
            {
                service.SaveOrUpdate(relation);
            }
        }

        public void DeleteRelation(R_T2T relation)
        {
            if(IsOnline)
            {
                client.deleteRelation(Helper.LR2SR(relation));
            }
            else
            {
                service.Remove(relation);
            }
        }

        public List<string> GetAllTargetName(int id)
        {
            List<string> result = new List<string>();
            if(IsOnline)
            {
                result = client.queryTargetName(id);
            }
            else
            {
                List<R_T2T> relations = service.FindAllByProperty<R_T2T>("TASKID",id.ToString()).ToList<R_T2T>();
                List<string> taskids = new List<string>();
                if(relations!=null)
                {
                    foreach(R_T2T r in relations)
                    {
                        taskids.Add(r.TARGETID);
                    }
                }
                foreach(string str in taskids)
                {
                    POINTTARGET target = service.FindByProperty<POINTTARGET>("ID", int.Parse(str));
                    if (target != null)
                    {
                        result.Add(target.TARGETCODE);
                    }
                }
            }
            return result;

        }

    }
}
