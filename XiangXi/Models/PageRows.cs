using System.Runtime.Serialization;

namespace XiangXi.Models
{
    [DataContract]
    public class PageRows<T>
    {
        [DataMember]
        public int total
        {
            get;
            set;
        }

        [DataMember]
        public T rows
        {
            get;
            set;
        }

        [DataMember]
        public bool success
        {
            get;
            set;
        }

        [DataMember]
        public string message
        {
            get;
            set;
        }



    }
}

