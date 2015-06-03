using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalDAL
{
    public class NCondition
    {
        private String _propertyName;

        public String PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
        private Operation _operate;

        public Operation Operate
        {
            get { return _operate; }
            set { _operate = value; }
        }
        private Object _propertyValue;

        public Object PropertyValue
        {
            get { return _propertyValue; }
            set { _propertyValue = value; }
        }

        public NCondition() { }
        public NCondition(String propertyName, Operation op, object propertyValue)
        {
            this._propertyName = propertyName;
            this._operate = op;
            this._propertyValue = propertyValue;
        }
    }

    public enum Operation
    {
        GT,
        LT,
        GE,
        LE,
        NE,
        EQ,
        LIKE,
        BETWEEN,
        IN
    }
}
