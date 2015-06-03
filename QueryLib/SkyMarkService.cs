using Common;
using LocalDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryLib
{
    public class SkyMarkService
    {
        private bool isOnline;


        private QueryProxy.OrbitQueryService.QueryService_onlineClient client;//在线用的查询服务
        private BaseService service;//离线用的查询服务
        private BaseQuery query;
        static readonly SkyMarkService _service = new SkyMarkService();
        public static SkyMarkService Instance
        {
            get
            {
                return _service;
            }
        }

        public bool IsOnline
        {
            get { return isOnline; }
            set { isOnline = value; }
        }

        private SkyMarkService()
        {
            service = new BaseService();
            query = new BaseQuery();
            client = new QueryProxy.OrbitQueryService.QueryService_onlineClient();
        }

        public bool AddSkyMark(SkyMark mark)
        {
            if(IsOnline)
            {
                return client.AddSkyMark(mark);
            }
            else
            {

                LocalEntity.Entities.SkyMark bzxx = Helper.SToLSkyMark(mark);
                try
                {
                    service.Save(bzxx);
                    return true;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    return false;
                }
            }
        }

        public bool AddSkyMarks(List<SkyMark> marks)
        {
            if (IsOnline)
            {
                return client.AddSkyMarks(marks);
            }
            else
            {
                bool result = true;
                foreach (SkyMark mark in marks)
                {
                    result = AddSkyMark(mark);
                    if (!result)
                    {
                        return result;
                    }
                }
                return result;
            }
           
        }

        public List<SkyMark> GetSkyMarks()
        {
            if (IsOnline)
            {
                return client.GetSkyMarks();
            }
            else
            {
              
                List<SkyMark> marks = new List<SkyMark>();
                try
                {
                    IList<LocalEntity.Entities.SkyMark> list = service.FindAll<LocalEntity.Entities.SkyMark>();

                    foreach (LocalEntity.Entities.SkyMark bzxx in list)
                    {
                        marks.Add(Helper.LToSSkyMark(bzxx));
                    }
                    return marks;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    return marks;
                }
            }
      
        }

        public SkyMark GetSkyMarkByName(string name)
        {
            if (IsOnline)
            {
                return client.GetSkyMarkByName(name);
            }
            else
            {
                SkyMark mark = new SkyMark();
                BaseService service = new BaseService();
                try
                {
                    mark = Helper.LToSSkyMark(service.FindByProperty<LocalEntity.Entities.SkyMark>("MC", name));
                    return mark;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    return mark;
                }
            }
        }

        public List<SkyMark> GetSkyMarkByCatlog(string catlog)
        {
            if (IsOnline)
            {
                client.GetSkyMarkByCatlog(catlog);
            }
            else
            {
                List<SkyMark> marks = new List<SkyMark>();
                BaseService service = new BaseService();
                try
                {
                    IList<LocalEntity.Entities.SkyMark> list = service.FindAllByProperty<LocalEntity.Entities.SkyMark>("FL", catlog);
                    foreach (LocalEntity.Entities.SkyMark bzxx in list)
                    {
                        marks.Add(Helper.LToSSkyMark(bzxx));
                    }
                    return marks;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    return marks;
                }
            }
            return null;
        }

        public bool DelSkyMark(SkyMark mark)
        {
            if (IsOnline)
            {
                return client.DelSkyMark(mark);
            }
            else
            {
                LocalEntity.Entities.SkyMark bzxx = Helper.SToLSkyMark(mark);
                BaseService service = new BaseService();
                try
                {
                    service.Remove(bzxx);
                    return true;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    return false;
                }

            }
            //return false;
        }

        public bool DelSkyMarks(List<SkyMark> marks)
        {
            if (IsOnline)
            {
                return client.DelSkyMarks(marks);
            }
            else
            {
                bool result = true;
                foreach (SkyMark mark in marks)
                {
                    result = DelSkyMark(mark);
                    if (!result)
                    {
                        return result;
                    }
                }
                return result;         
            }
            //return false;
        }
    }
}
