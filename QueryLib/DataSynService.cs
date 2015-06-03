using LocalDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using QueryProxy.OrbitQueryService;

namespace QueryLib
{
    public class DataSynService
    {
        private QueryProxy.OrbitQueryService.QueryService_onlineClient client;//在线用的查询服务

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
            throw new NotImplementedException();
        }

        private void SynPointTarget(object obj)
        {
            throw new NotImplementedException();
        }

        private void SynDingBiao(object obj)
        {
            throw new NotImplementedException();
        }

        private void SynTask(object obj)
        {
            throw new NotImplementedException();
        }

        private void SynSkyMark(object obj)
        {
            throw new NotImplementedException();
        }

        private void SynOrbit(object obj)
        {
            OrbitalElemet orbitElement = obj as OrbitalElemet;
            OrbitQuery orbQuery = new OrbitQuery();
            client = new QueryService_onlineClient();

            try
            {
	            OrbitalElemet orbEle = client.GetLastestPJGDGS(orbitElement.WXDH);
	            service.Save(orbEle);
                orbEle = client.GetLastestSSGDGS(orbitElement.WXDH);
                service.Save(orbEle);
	            
            }
            catch (System.Exception ex)
            {
	            
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
