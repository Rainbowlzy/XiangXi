using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace XiangXi.Evaluators
{
    public class CommonOutputList<T> : CommonOutputT<T>
    {
        public ICollection<T> rows { get; set; }

        public int total { get; internal set; }
    }
}