using LocalDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using QueryProxy.OrbitQueryService;
using LocalEntity;
using LocalEntity.Entities;

namespace QueryLib
{
    public class DataSynService
    {
        private QueryProxy.OrbitQueryService.QueryService_onlineClient client;//在线用的查询服务
        private QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN plan;

        private BaseService service;//离线用的查询服务
        private BaseQuery query;
        static readonly DataSynService _dataSynService = new DataSynService();
        private Thread skyMarkSynThread;
        private Thread taskSynThread;
        private Thread dingBiaoSynThread;
        private Thread pointTargetSynThread;
        private Thread planSynThread;
        private Thread orbitQueryThread;
        
        public static DataSynService Instance
        {
            get { return _dataSynService; }
        }
        
        private DataSynService()
        {
            service = new BaseService();
            query = new BaseQuery();
            skyMarkSynThread=new Thread(SynSkyMark){IsBackground =true};
            taskSynThread = new Thread(SynTask) { IsBackground = true };
            dingBiaoSynThread = new Thread(SynDingBiao) { IsBackground = true };
            pointTargetSynThread = new Thread(SynPointTarget) { IsBackground = true };
            planSynThread = new Thread(SynPlan) { IsBackground = true };
            orbitQueryThread = new Thread(SynOrbit) { IsBackground = true };
        }

        private void SynPlan(object obj)
        {
            try
            {
                IList<PLAN> List = service.FindAllByProperty<PLAN>("FLAG", 1);
	            foreach(var p in List)
	            {
	                service.Save(Helper.LPlan2SPlan(p));
	            }
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
            }
        }

        private void SynPointTarget(object obj)
        {
            try
            {
	            IList<object> List = service.FindAllByProperty<object>("FLAG", 1);
	            foreach(var p in List)
	            {
	                service.Save(Helper.LPT2SPT(p as POINTTARGET));
	            }
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
            }
        }

        private void SynDingBiao(object obj)
        {
            try
            {
                IList<object> List = service.FindAllByProperty<object>("FLAG", 1);
                foreach (var p in List)
                {
                    service.Save(Helper.LDingBiao2SDingBiao(p as DingBiao));
                }
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
            }
        }

        private void SynTask(object obj)
        {
            try
            {
                IList<object> List = service.FindAllByProperty<object>("FLAG", 1);
                foreach (var p in List)
                {
                    service.Save(Helper.LTask2STask(p as TASK));
                }
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
            }
        }

        private void SynSkyMark(object obj)
        {
            try
            {
                IList<object> List = service.FindAllByProperty<object>("FLAG", 1);
                foreach (var p in List)
                {
                    service.Save(Helper.LToSSkyMark(p as LocalEntity.Entities.SkyMark));
                }
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
            }
        }

        private void SynOrbit(object obj)
        {
            OrbitalElemet orbitElement = obj as OrbitalElemet;
            OrbitQuery orbQuery = new OrbitQuery();
            client = new QueryService_onlineClient();
            
            //从服务器查询最新轨道根数，本地数据库中保存
            try
            {
	            OrbitalElemet orbEle = client.GetLastestPJGDGS(orbitElement.WXDH);
	            service.Save(orbEle);
                orbEle = client.GetLastestSSGDGS(orbitElement.WXDH);
                service.Save(orbEle);
	            
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.InnerException.Message);
            }

        }

        public void SynData( )
        {
            skyMarkSynThread.Start();
            dingBiaoSynThread.Start();
            taskSynThread.Start();
            planSynThread.Start();
            pointTargetSynThread.Start();
            orbitQueryThread.Start();
        }
    }
}
