using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QueryProxy;
using QueryLib;
using LocalDAL;
using LocalEntity;
using LocalEntity.Entities;

namespace QueryLib
{
    public class ParaConfiguration
    {
        bool isOnline;
        QueryProxy.ParaConfiguration.ParaConfigurationClient onlineService;
        BaseService service;

        public void insertOrUpdate(DampeParaConfig paraConf)
        {
            if (isOnline == false)
            {
	            if(service == null)
	            {
	                service = new BaseService();
	            }
	            try
	            {
	                service.SaveOrUpdate(paraConf);
	            }
	            catch(Exception ex)
	            {
	                LogHelper.Error(ex.Message);
	                throw ex;
	            }
            }
            else
            {
                if(onlineService == null)
                {
                    onlineService = new QueryProxy.ParaConfiguration.ParaConfigurationClient();
                }
                try
                {
	                onlineService.insertOrUpdate(Helper.LParaToSPara(paraConf));
                }
                catch (System.Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    throw ex;
                }
            }
        }
        public List<DampeParaConfig> queryAllConfig()
        {
            List<DampeParaConfig> lList = new List<DampeParaConfig>();
            List<QueryProxy.ParaConfiguration.DZY_GGFW_DAMPECSPZ> sList = new List<QueryProxy.ParaConfiguration.DZY_GGFW_DAMPECSPZ>();
            if (isOnline == false)
            {
	            if(service == null)
	            {
	                service = new BaseService();
	            }
	            try
	            {
                    lList = service.FindAll<DampeParaConfig>().ToList();
	            }
                catch(System.Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    throw ex;
                }
            } 
            else
            {
                if(onlineService == null)
                {
                    onlineService = new QueryProxy.ParaConfiguration.ParaConfigurationClient();
                }
                try
                {
                    sList = onlineService.queryAllConfig().ToList();
                    foreach(var e in sList)
                    {
                        lList.Add(Helper.SParaToLPara(e));
                    }
                }
                catch(System.Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    throw ex;
                }
            }
            return lList;
        }
    }
}
