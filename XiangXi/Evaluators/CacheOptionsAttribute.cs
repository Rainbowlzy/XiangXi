using System;

namespace XiangXi.Evaluators
{
    public class CacheOptionsAttribute : Attribute
    {
        public int Timeout { get; set; }
    }
}