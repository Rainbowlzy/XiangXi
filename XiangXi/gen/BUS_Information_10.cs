using System.Runtime.Serialization;

namespace XiangXi
{
    [DataContract]
    public class BUS_Information_10
    {
        [DataMember]
        public string[] date
        {
            get;
            set;
        }
        [DataMember]
        public int[] series
        {
            get;
            set;
        }
        [DataMember]
        public int[] sum   //sum?
        {
            get;
            set;
        }
    }
}