using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LocalDAL
{
    public class PageInfo
    {
        public PageInfo() { }

        public PageInfo(Type entityType, int pageIndex)
        {
            this._entityType = entityType;
            this._pageIndex = pageIndex;
        }

        public PageInfo(Type entityType, int pageIndex, params NCondition[] conditions)
        {
            this._entityType = entityType;
            this._pageIndex = pageIndex;
            this._conditions = conditions;
        }

        public PageInfo(Type entityType, int pageIndex, NCondition[] conditions, NOrder[] orders)
        {
            this._entityType = entityType;
            this._pageIndex = pageIndex;
            this._conditions = conditions;
            this._orderFields = orders;
        }

        private Type _entityType;//类

        public Type EntityType
        {
            get { return _entityType; }
            set { _entityType = value; }
        }
        private int _pageIndex = 1;//页号

        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        private NCondition[] _conditions;//条件

        public NCondition[] Conditions
        {
            get { return _conditions; }
            set { _conditions = value; }
        }
        private NOrder[] _orderFields;//排序

        public NOrder[] OrderFields
        {
            get { return _orderFields; }
            set { _orderFields = value; }
        }
        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }


        private int _recordCount;

        public int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }
        private int pageCount;

        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; }
        }
        private System.Collections.IList list;

        public IList List
        {
            get { return list; }
            set { list = value; }
        }
    }
}
