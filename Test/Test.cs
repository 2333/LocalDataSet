using LocalDAL;
using LocalEntity.Entities;
using QueryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Test
    {
       
        public static void Main()
        {
            BaseService service = new BaseService();
            List<PLAN> list = service.FindAll<PLAN>().ToList();
            Console.WriteLine(list.Count);
            Console.Read();
            QueryService qservice = new QueryService();
        }
    }
}
