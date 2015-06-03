using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QueryProxy.TaskManage;
using LocalDAL;
using LocalEntity.Entities;
namespace QueryLib
{
    public class TaskService
    {
        private bool isOnline;
        private QueryProxy.TaskManage.TaskManageClient client;
        private BaseService service;
        private BaseQuery query;
        private PlanService planservice;
        public TaskService()
        {
            client = new TaskManageClient();
            service = new BaseService();
            query = new BaseQuery();
        }

        public bool IsOnline
        {
            get { return isOnline; }
            set { isOnline = value; }
        }

        public void InsertOrUpdateTask(TASK task)
        {
            if(IsOnline)
            {
                client.insertOrUpdateTask(Helper.LTask2STask(task));
            }
            else
            {
                service.SaveOrUpdate(task);
            }
        }

        public void DeleteTask(TASK task)
        {
            if(IsOnline)
            {
                client.deleteTask(Helper.LTask2STask(task));
            }
            else
            {
                service.Remove(task);
            }
        }

        public TASK GetTaskByID(string taskid)
        {
            if(IsOnline)
            {
                return Helper.ServerTask2LocalTask(client.queryTask(taskid));
            }
            else
            {
                return service.FindByProperty<TASK>("TASKID", taskid);
            }
        }

        public List<TASK> queryTask(DateTime starttime, DateTime endtime)
        {
            if (planservice == null) { planservice = new PlanService(); }
            List<string> planid = planservice.QueryPlanID(starttime, endtime);
            if (query == null)
            {
                query = new BaseQuery();
            }
            List<TASK> tasklistssum = new List<TASK>();
            List<TASK> tasklists = new List<TASK>();
            for (int i = 0; i < planid.Count; i++)
            {
                try
                {
                    tasklists = query.Query<TASK>("from TASK where PLANID = '" + planid[i] + "' and STARTTIME >= '" + starttime.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "and ENDTIME <= '" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "'").ToList();
                }
                catch (SystemException ex)
                {
                    LogHelper.Error(ex.Message);
                    throw ex;
                }
                tasklistssum.AddRange(tasklists);
            }

            return tasklistssum;
        }

    }
}
