using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalDAL;
using LocalEntity;
using LocalEntity.Entities;

namespace QueryLib
{
    class PointTaskService
    {
        private bool isOnline;
        private QueryProxy.PointTargetManage.PointTaskManageClient online;
        private BaseQuery query;
        private BaseService service;

        public bool IsOnline
        {
            get { return isOnline; }
            set { isOnline = value; }
        }

        public PointTaskService()
        {
            online = new QueryProxy.PointTargetManage.PointTaskManageClient();
            service = new BaseService();
            query = new BaseQuery();
        }

        public void savePointTask(string targetcode, double longtitude, double latitude, int priority, TimeSpan DetectTime, float maxangle)
        {
            if(IsOnline)
            {
                online.savePointTask(targetcode, longtitude, latitude, priority, DetectTime, maxangle);
            }
            else
            {
                POINTTARGET target = new POINTTARGET() 
                {
                    TARGETCODE =targetcode,
                    LONGTITUDE=longtitude.ToString(),
                    LATITUDE=latitude.ToString(),
                    PRIORITY=priority.ToString(),
                    DETECTTIME=DetectTime.ToString(),
                    ALLOWABLEVIRATION=maxangle.ToString()
                };
                service.Save(target);
            }
        }

        public void deletePointTask(string tartgetcode)
        {
            if(IsOnline)
            {
                online.deletePointTask(tartgetcode);

            }else
            {
                POINTTARGET point = service.FindByProperty<POINTTARGET>("TARGETCODE", tartgetcode);
                service.Remove(point);
            }
        }


        public List<POINTTARGET> queryPointTask()
        {
            List<POINTTARGET> result = new List<POINTTARGET>();
            if(IsOnline)
            {
                List<QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET> list = new List<QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET>();
                list = online.queryPointTask();
                if(list!=null)
                {
                    foreach(QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET target in list)
                    {
                        result.Add(Helper.ServerTarget2LocalTarget(target));
                    }
                }
            }
            else
            {
                List<POINTTARGET> targetlists = query.Query<POINTTARGET>("From POINTTARGET pointtarget Order by pointtarget.ID").ToList();
                if(targetlists!=null)
                {
                    result = targetlists;
                }
            }
            return result;
        }

        public int queryLastItem_ID()
        {
            if(IsOnline)
            {
                return online.queryLastItem_ID();
            }
            else
            {
                IList<POINTTARGET> list = query.Query<POINTTARGET>("From OINTTARGET where ID=(SELECT MAX(ID) From POINTTARGET)");
                int ID = 0;
                if (list.Count > 0)
                {
                    ID = list[0].ID;
                }
                return ID;
            }
        }

        public void updatePoint(POINTTARGET point)
        {
           if(IsOnline)
           {
               online.updatePoint(Helper.LPT2SPT(point));
           }
            else
           {
               service.Update(point);
           }
        }
    }
}
