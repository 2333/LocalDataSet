using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using LocalEntity;
using LocalEntity.Entities;
using QueryProxy.OrbitQueryService;

namespace QueryLib
{
    /// <summary>
    /// 用于Server与Local之间实体类型转换
    /// 注意时间类型转换
    /// 注意空值转换为字符串时会出现异常
    /// </summary>
    public class Helper
    {
        public static LocalEntity.Entities.DingBiao ServerDingBiao2LocalDingBiao(QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK dingbiao)
        {
            LocalEntity.Entities.DingBiao item = new LocalEntity.Entities.DingBiao()
            {
                ID = dingbiao.ID,
                STARTTIME =MyToString(dingbiao.STARTTIME),
                ENDTIME = MyToString(dingbiao.ENDTIME),
                PLANID = MyToString(dingbiao.PLANID),
                TYPE = dingbiao.TYPE
            };
            return item;
        }
        public static LocalEntity.Entities.PLAN ServerPlan2LocalPlan(QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN plan)
        {
            LocalEntity.Entities.PLAN item = new LocalEntity.Entities.PLAN()
            {
                ID = plan.ID,
                STARTTIME = MyToString(plan.STARTTIME),
                ENDTIME = MyToString(plan.ENDTIME),
                PROPOSEPERSON = plan.PROPOSEPERSON,
                PROPOSETIME = MyToString(plan.PROPOSETIME),
                ISSIMULATED = plan.ISSIMULATED,
                REMARK = plan.REMARK,
                PLANID = plan.PLANID,
                PLANTYPE = plan.PLANTYPE,           
            };
            return item;
        }

        public static LocalEntity.Entities.POINTTARGET ServerTarget2LocalTarget(QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET target)
        {
            LocalEntity.Entities.POINTTARGET item = new LocalEntity.Entities.POINTTARGET()
            {
                ID = target.ID,
                TARGETCODE = target.TARGETCODE,
                LONGTITUDE = MyToString(target.LONGTITUDE),
                LATITUDE = MyToString(target.LATITUDE),
                PRIORITY = MyToString(target.PRIORITY),
                DETECTNUM = target.DETECTNUM,
                PROPOSEPERSON = target.PROPOSEPERSON,
                PROPOSETIME = MyToString(target.PROPOSETIME),
                DETECTTIME = target.DETECTTIME,
                ALLOWABLEVIRATION = MyToString(target.ALLOWABLEVIRATION)
            };
            return item;
        }

        public static LocalEntity.Entities.TASK ServerTask2LocalTask(QueryProxy.TaskManage.DZY_GGFW_DAMPETask task)
        {
            LocalEntity.Entities.TASK item = new LocalEntity.Entities.TASK()
            {
                ID = task.ID,
                TASKID = task.TASKID,
                STARTTIME = MyToString(task.STARTTIME),
                ENDTIME = MyToString(task.ENDTIME),
                VIEWTYPE = task.VIEWTYPE,
                LONGTITUDE = MyToString(task.LONGTITUDE),
                LATITUDE = MyToString(task.LATITUDE),
                REMARK = task.REMARK,
                PLANID = MyToString(task.PLANID)
            };
            return item;
        }

        public static LocalEntity.Entities.R_T2T ServerR2LocalR(QueryProxy.T2T_RManage.DZY_GGFW_DAMPETASKTARGET_R relation)
        {
            LocalEntity.Entities.R_T2T item = new LocalEntity.Entities.R_T2T()
            {
                ID = relation.ID,
                TASKID = MyToString(relation.TASKID),
                TARGETID = MyToString(relation.TARGETID)
            };

            return item;
        }

        public static QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK LDingBiao2SDingBiao(LocalEntity.Entities.DingBiao item)
        {
            QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK dingbiao = new QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK() 
            {
                ID = item.ID,
                STARTTIME = DateTime.Parse(item.STARTTIME),
                ENDTIME = DateTime.Parse(item.ENDTIME),
                PLANID = int.Parse(item.PLANID),
                TYPE = item.TYPE,
            };
            return dingbiao;
        }

        public static QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN LPlan2SPlan(LocalEntity.Entities.PLAN item)
        {
            QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN plan = new QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN() 
            {
                ID = item.ID,
                STARTTIME = DateTime.Parse(item.STARTTIME),
                ENDTIME = DateTime.Parse(item.ENDTIME),
                PROPOSEPERSON = item.PROPOSEPERSON,
                PROPOSETIME = DateTime.Parse(item.PROPOSETIME),
                ISSIMULATED = item.ISSIMULATED,
                REMARK = item.REMARK,
                PLANID = item.PLANID,
                PLANTYPE = item.PLANTYPE, 
            };
            return plan;
        }

        public static QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET LPT2SPT(LocalEntity.Entities.POINTTARGET item)
        {
            QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET pt = new QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET()
            {
                ID = item.ID,
                TARGETCODE = item.TARGETCODE,
                LONGTITUDE = double.Parse(item.LONGTITUDE),
                LATITUDE = double.Parse(item.LATITUDE),
                PRIORITY = int.Parse(item.PRIORITY),
                DETECTNUM = item.DETECTNUM,
                PROPOSEPERSON = item.PROPOSEPERSON,
                DETECTTIME = item.DETECTTIME,
                ALLOWABLEVIRATION = float.Parse(item.ALLOWABLEVIRATION),
                PROPOSETIME = DateTime.Parse(item.PROPOSETIME)
            };
            //if (item.PROPOSETIME == string.Empty || item.PROPOSETIME == null)
            //{
            //    pt.PROPOSETIME = DateTime.Now;
            //}
            return pt;
        }

        public static QueryProxy.T2T_RManage.DZY_GGFW_DAMPETASKTARGET_R LR2SR(LocalEntity.Entities.R_T2T item)
        {
            QueryProxy.T2T_RManage.DZY_GGFW_DAMPETASKTARGET_R relation = new QueryProxy.T2T_RManage.DZY_GGFW_DAMPETASKTARGET_R()
                {
                    ID = item.ID,
                    TASKID = int.Parse(item.TASKID),
                    TARGETID = int.Parse(item.TARGETID),
                };
            return relation;
        }

        public static QueryProxy.TaskManage.DZY_GGFW_DAMPETask LTask2STask(LocalEntity.Entities.TASK item)
        {
            QueryProxy.TaskManage.DZY_GGFW_DAMPETask task = new QueryProxy.TaskManage.DZY_GGFW_DAMPETask()
            {
                ID = item.ID,
                TASKID = item.TASKID,
                STARTTIME = DateTime.Parse(item.STARTTIME),
                ENDTIME = DateTime.Parse(item.ENDTIME),
                VIEWTYPE = item.VIEWTYPE,
                LONGTITUDE = float.Parse(item.LONGTITUDE),
                LATITUDE = float.Parse(item.LATITUDE),
                REMARK = item.REMARK,
                PLANID = int.Parse(item.PLANID)
            };
            return task;
        }

       private static string MyToString(object obj)
        {
            try
            {
                if (obj == null)
                    return string.Empty;
                else if(obj is DateTime)
                {
                    return ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    return obj.ToString();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

       public static Common.SkyMark LToSSkyMark(LocalEntity.Entities.SkyMark item)
       {
           Common.SkyMark mark=new Common.SkyMark();
           mark.Catlog = item.Cotlog;
           mark.Dec =(float)item.Dec;
           mark.Ra = (float)item.Ra;
           mark.MarkBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(item.Brush));
           mark.Remark = item.Remark;
           mark.Name = item.Name;
           return mark;
       }

        public static LocalEntity.Entities.SkyMark SToLSkyMark(Common.SkyMark item)
        {
            LocalEntity.Entities.SkyMark mark = new LocalEntity.Entities.SkyMark();
            mark.Name = item.Name;
            mark.Cotlog = item.Catlog;
            mark.Remark = item.Remark;
            mark.Ra = (decimal)item.Ra;
            mark.Dec = (decimal)item.Dec;
            mark.Brush = item.MarkBrush.Color.ToString();
            return mark;
        }
    }
}
