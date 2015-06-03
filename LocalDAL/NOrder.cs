using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalDAL
{
    public class NOrder
    {
        public enum OrderDirection
        {
            ASC,
            DESC
        }

        private String _propertyName;

        public String PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
        private OrderDirection _orderType;

        public OrderDirection OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        public NOrder() { }

        public NOrder(String propertyName, OrderDirection orderType)
        {
            this._propertyName = propertyName;
            this._orderType = orderType;
        }

    }
}
