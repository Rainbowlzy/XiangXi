using System;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Newtonsoft.Json;

namespace XiangXi.Evaluators
{
    public static class StringExtension
    {
        public static T Deserialize<T>(this string obj) where T : class, new()
        {
            try
            {
                if (string.IsNullOrEmpty(obj)) return new T();
                return JsonConvert.DeserializeObject<T>(obj);
            }
            catch (Exception exception)
            {
                File.WriteAllText(@"D:\log\" + DateTime.Now.Ticks + ".log", string.Format("{0} json format fault {1}", exception.Message, obj));
                return null;
            }
        }

        public static int ToInt(this string s)
        {
            int i;
            int.TryParse(s, out i);
            return i;
        }

        public static DateTime ToDate(this string s)
        {
            var date = DateTime.Now;
            DateTime.TryParse(s, out date);
            return date;
        }
    }
}