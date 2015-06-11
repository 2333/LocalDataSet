using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalEntity;
using LocalEntity.Entities;
using LocalDAL;
using QueryProxy.OrbitQueryService;
using LocalEntity.Entities;

namespace QueryLib
{
    public class OrbitQuery
    {
        private BaseService service;
        private BaseQuery query;

        public OrbitQuery()
        {
            service = new BaseService();
            query = new BaseQuery();
        }

        private Comparison<OrbitalElemet> myComparison = new Comparison<OrbitalElemet>(MyCompare);
        private static int MyCompare(OrbitalElemet orbitalElemet, OrbitalElemet elemet)
        {
            if (orbitalElemet.LYSJ > elemet.LYSJ)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public int GetOrbitalTimesInfo(DateTime time,string WXDH)
        {
            LocalEntity.Entities.OrbitTimeInfo orbitalTime = new LocalEntity.Entities.OrbitTimeInfo();
            try{
                orbitalTime = query.Query<LocalEntity.Entities.OrbitTimeInfo>(
                    "from OrbitTimeInfo where WXDH = '" + WXDH + "' KSSJ<=TO_DATE('" + time.ToString("yyyy-MM-dd HH:mm:ss") 
                    + "' , 'YYYY-MM-DD HH24:MI:SS') and JSSJ>=TO_DATE('" + time.ToString("yyyy-MM-dd HH:mm:ss")
                    + "' , 'YYYY-MM-DD HH24:MI:SS')").ToList<LocalEntity.Entities.OrbitTimeInfo>()[0];
                if (orbitalTime==null)
                {
                    return 0;
                }
                else
                {
                    return (int)orbitalTime.GDQH;
                }
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.Message);
                return 0;
            }
        }

        public IList<LocalEntity.Entities.OrbitTimeInfo> UpdateLocalObitalTimesInfo(DateTime time, string WXDH)
        {
            IList<LocalEntity.Entities.OrbitTimeInfo> list = new List<LocalEntity.Entities.OrbitTimeInfo>();
            try
            {
                list = query.Query<LocalEntity.Entities.OrbitTimeInfo>("from OrbitTimeInfo where WXDH= '" + WXDH + "' RKSJ > TO_DATE('" + time.ToString("yyyy-MM-dd HH:mm:ss") + "' , 'YYYY-MM-DD HH24:MI:SS')");

            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
            return list;
        }

        #region 轨道根数
        public OrbitalElemet GetLastestSSGDGS(string WXDH)
        {
            MomOrbElement ssgdgs = new MomOrbElement();
            OrbitalElemet orbitalelement = new OrbitalElemet();
            try
            {
                BaseQuery query = new BaseQuery();
                IList<MomOrbElement> list = query.Query<MomOrbElement>("from DZY_GGFW_SSGDGS where WXDH='" + WXDH + "' AND LYSJ = (Select MAX(LYSJ) From  DZY_GGFW_SSGDGS Where WXDH='" + WXDH + "')");
                if (list.Count > 0)
                {
                    ssgdgs = list[0];
                }
                orbitalelement = ConvertOrbitalElement(ssgdgs);
                orbitalelement.GDQH = GetOrbitalTimesInfo(orbitalelement.LYSJ, WXDH);
                orbitalelement.LYSJ = orbitalelement.LYSJ.AddHours(8);
                return orbitalelement;
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.Message);
                return orbitalelement;
            }
        }
        public OrbitalElemet GetLastestSSGDGSByTime(DateTime date, string WXDH)
        {
            MomOrbElement ssgdgs = new MomOrbElement();
            OrbitalElemet orbitalelement = new OrbitalElemet();
            try
            {
                BaseQuery query = new BaseQuery();
                ssgdgs = query.Query<MomOrbElement>("from DZY_GGFW_SSGDGS Where WXDH='" + WXDH + "' AND LYSJ = (Select MAX(LYSJ) From  DZY_GGFW_SSGDGS Where WXDH='" + WXDH + "' AND LYSJ<=TO_DATE('" + date.ToString("yyyy-MM-dd HH:mm:ss") + "' , 'YYYY-MM-DD HH24:MI:SS'))")[0];
                orbitalelement = ConvertOrbitalElement(ssgdgs);
                orbitalelement.GDQH = GetOrbitalTimesInfo(orbitalelement.LYSJ, WXDH);
                orbitalelement.LYSJ = orbitalelement.LYSJ.AddHours(8);
                return orbitalelement;
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.Message);
                return orbitalelement;
            }
        }

        public List<OrbitalElemet> GetSSGDGS(DateTime KSSJ, DateTime JSSJ, string WXDH)
        {
            IList<MomOrbElement> list = new List<MomOrbElement>();
            List<OrbitalElemet> oelist = new List<OrbitalElemet>();
            try
            {
                //luoyunfeng fixed 2014.7.7
                BaseQuery query = new BaseQuery();
                list = query.Query<MomOrbElement>("from DZY_GGFW_SSGDGS Where WXDH = '" + WXDH + "' AND LYSJ>=TO_DATE('" + KSSJ.ToString("yyyy-MM-dd HH:mm:ss") + "' , 'YYYY-MM-DD HH24:MI:SS') AND LYSJ<TO_DATE('" + JSSJ.ToString("yyyy-MM-dd HH:mm:ss") + "' , 'YYYY-MM-DD HH24:MI:SS')");
                foreach (MomOrbElement gdgs in list)
                {
                    OrbitalElemet oe = new OrbitalElemet();
                    oe = ConvertOrbitalElement(gdgs);
                    oe.GDQH = GetOrbitalTimesInfo(DateTime.Parse(gdgs.LYSJ), WXDH);
                    oe.LYSJ = oe.LYSJ.AddHours(8);
                    oelist.Add(oe);
                }
                oelist.Sort(myComparison);
                if (oelist.Count > 0)
                {
                    if (oelist[0].LYSJ > KSSJ.AddHours(8))
                    {
                        OrbitalElemet orbitalelement = GetLastestSSGDGSByTime(KSSJ, WXDH);
                        if (orbitalelement != null)
                        {
                            oelist.Insert(0, orbitalelement);
                        }
                    }
                }
                else
                {
                    OrbitalElemet orbitalelement = GetLastestSSGDGSByTime(KSSJ, WXDH);
                    if (orbitalelement != null)
                    {
                        oelist.Insert(0, orbitalelement);
                    }
                }

                return oelist;
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.Message);
                return oelist;
            }
        }

        public OrbitalElemet GetLastestPJGDGS(string WXDH)
        {
            AvgOrbElement pjgdgs = new AvgOrbElement();
            OrbitalElemet orbitalelement = new OrbitalElemet();
            try
            {
                BaseQuery query = new BaseQuery();
                pjgdgs = query.Query<AvgOrbElement>("from DZY_GGFW_PJGDGS Where WXDH='" + WXDH + "' AND LYSJ = (Select MAX(LYSJ) From DZY_GGFW_PJGDGS Where WXDH='" + WXDH + "')")[0];
                orbitalelement = ConvertOrbitalElement(pjgdgs);
                orbitalelement.GDQH = GetOrbitalTimesInfo(orbitalelement.LYSJ, WXDH);
                orbitalelement.LYSJ = orbitalelement.LYSJ.AddHours(8);
                return orbitalelement;
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.Message);
                return orbitalelement;
            }
        }

        public OrbitalElemet GetLastestPJGDGSByTime(DateTime date, string WXDH)
        {
            AvgOrbElement pjgdgs = new AvgOrbElement();
            OrbitalElemet orbitalelement = new OrbitalElemet();
            try
            {
                BaseQuery query = new BaseQuery();
                pjgdgs = query.Query<AvgOrbElement>("from DZY_GGFW_PJGDGS Where WXDH='" + WXDH + "' AND LYSJ = (Select MAX(LYSJ) From  DZY_GGFW_PJGDGS Where WXDH='" + WXDH + "' AND LYSJ<=TO_DATE('" + date.ToString("yyyy-MM-dd HH:mm:ss") + "' , 'YYYY-MM-DD HH24:MI:SS'))")[0];
                orbitalelement = ConvertOrbitalElement(pjgdgs);
                orbitalelement.GDQH = GetOrbitalTimesInfo(orbitalelement.LYSJ, WXDH);
                orbitalelement.LYSJ = orbitalelement.LYSJ.AddHours(8);
                return orbitalelement;
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.Message);
                return orbitalelement;
            }
        }

        public List<OrbitalElemet> GetPJGDGS(DateTime KSSJ, DateTime JSSJ, string WXDH)
        {
            IList<AvgOrbElement> list = new List<AvgOrbElement>();
            List<OrbitalElemet> oelist = new List<OrbitalElemet>();
            try
            {
                BaseQuery query = new BaseQuery();
                list = query.Query<AvgOrbElement>("from DZY_GGFW_PJGDGS Where WXDH = '" + WXDH + "' AND LYSJ>=TO_DATE('" + KSSJ.ToString("yyyy-MM-dd HH:mm:ss") + "' , 'YYYY-MM-DD HH24:MI:SS') AND LYSJ<TO_DATE('" + JSSJ.ToString("yyyy-MM-dd HH:mm:ss") + "' , 'YYYY-MM-DD HH24:MI:SS')");
                foreach (AvgOrbElement gdgs in list)
                {
                    OrbitalElemet oe = new OrbitalElemet();
                    oe = ConvertOrbitalElement(gdgs);
                    oe.GDQH = GetOrbitalTimesInfo(DateTime.Parse(gdgs.LYSJ), WXDH);
                    oe.LYSJ = oe.LYSJ.AddHours(8);
                    oelist.Add(oe);
                }
                oelist.Sort(myComparison);
                if (oelist.Count > 0)
                {
                    if (oelist[0].LYSJ > KSSJ.AddHours(8))
                    {
                        OrbitalElemet orbitalelement = GetLastestPJGDGSByTime(KSSJ, WXDH);
                        if (orbitalelement != null)
                        {
                            oelist.Insert(0, orbitalelement);
                        }
                    }
                }
                else
                {
                    OrbitalElemet orbitalelement = GetLastestPJGDGSByTime(KSSJ, WXDH);
                    if (orbitalelement != null)
                    {
                        oelist.Insert(0, orbitalelement);
                    }
                }
                return oelist;
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex.Message);
                return oelist;
            }
        }
        #endregion



        private OrbitalElemet ConvertOrbitalElement(MomOrbElement gdgs)
        {
            OrbitalElemet item = new OrbitalElemet();
            item.BCZ = (decimal)gdgs.BCZ;
            item.CKZBX =int.Parse(gdgs.CKZBX);
            item.DQZNXS = gdgs.DQZNXS;
            item.GDQH = 0;
            item.GSBH = gdgs.GSBH;
            item.GYFSXS = gdgs.GYFSXS;
            item.JDDFJ = (decimal)gdgs.JDDFJ;
            item.LYSJ = DateTime.Parse(gdgs.LYSJ);
            item.PJDJ = (decimal)gdgs.PJDJ;
            item.PXL = (decimal)gdgs.PXL;
            item.QJ = (decimal)gdgs.QJ;
            item.RKSJ = DateTime.Parse(gdgs.RKSJ);
            item.SJDCJ = (decimal)gdgs.SJDCJ;
            item.SJLY = decimal.Parse(gdgs.SJLY);
            item.SJXT = decimal.Parse(gdgs.SJXT);
            item.WXDH = gdgs.WXDH;
            item.YLXS = gdgs.YLXS;
            item.ZBXYD = decimal.Parse(gdgs.ZBXYD);
            return item;
        }
        private OrbitalElemet ConvertOrbitalElement(AvgOrbElement gdgs)
        {
            OrbitalElemet item = new OrbitalElemet();
            item.BCZ = (decimal)gdgs.BCZ;
            item.CKZBX = decimal.Parse(gdgs.CKZBX);
            item.DQZNXS = gdgs.DQZNXS;
            item.GDQH = 0;
            item.GSBH = gdgs.GSBH;
            item.GYFSXS = item.GYFSXS;
            item.JDDFJ = (decimal)gdgs.JDDFJ;
            item.LYSJ = DateTime.Parse(gdgs.LYSJ);
            item.PJDJ = (decimal)gdgs.PJDJ;
            item.PXL = (decimal)gdgs.PXL;
            item.QJ = (decimal)gdgs.QJ;
            item.RKSJ = DateTime.Parse(gdgs.RKSJ);
            item.SJDCJ = (decimal)gdgs.SJDCJ;
            item.SJLY = decimal.Parse(gdgs.SJLY);
            item.SJXT = decimal.Parse(gdgs.SJXT);
            item.WXDH = gdgs.WXDH;
            item.YLXS = gdgs.YLXS;
            item.ZBXYD = decimal.Parse(gdgs.ZBXYD);
            return item;
        }

    }
}
