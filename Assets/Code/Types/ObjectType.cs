using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Compute.Types
{
    public class ObjectType : IType<object>
    {
        public string TypeName
        {
            get { return _typeName; }
        }

        public Color TypeColor
        {
            get { return _typeColor; }
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        string _typeName = "object";
        Color _typeColor = new Color(1, 0, 0, 1);

        object _value = null;
    }
}
