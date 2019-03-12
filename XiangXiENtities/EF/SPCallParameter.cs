using System;

namespace XiangXi.Evaluators
{
    public class SPCallParameter
    {
        public string districtID { get; set; }
        public string type { get; set; }
        public string search { get; set; }
        public string view { get; set; }
        public string order { get; set; }
        public string asc { get; set; }
        public Nullable<int> offset { get; set; }
        public Nullable<int> limit { get; set; }
        public Nullable<int> total { get; set; }
        public string condition { get; set; }
    }
}
