using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Compute.Types
{
    interface IType<T>
    {
        string TypeName { get; }
        Color TypeColor { get; }
        T Value { get; set; }
    }
}
