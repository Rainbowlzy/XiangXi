using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using XiangXi.Interfaces;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 远程请求处理机
    /// </summary>
    public class RemoteEvaluator : Evaluator
    {

        private static List<string> Handlers = new List<string>(new[]
        {
            //"http://localhost:8091/XiangXi/DefaultHandler.ashx",
            "http://localhost/XiangXi/DefaultHandler.ashx"
        });
        public static Dictionary<string, List<CommonRequest>> GetEvaluator()
        {
            List<string> handlers = Handlers;
            var not_empty_handler = handlers?.Where(t => !string.IsNullOrEmpty(t));
            var post_responses = not_empty_handler?.SelectMany(ParseHosts);
            return post_responses?.GroupBy(k => k?.method)?.ToDictionary(k => k?.Key, k => k?.ToList());
        }

        private static IEnumerable<CommonRequest> ParseHosts(string t)
        {
            string reponse_list = HttpPostWebService($"{t}?method=list_all_of_evaluators", string.Empty);
            var deserialized_reponse_list = reponse_list?.Deserialize<List<CommonRequest>>();
            var not_null_response_list = deserialized_reponse_list?.Where(r => r != null && !string.IsNullOrEmpty(r.method));
            return not_null_response_list?.Select(r => r.SetUrl($"{t}"));
        }


        /// <summary>
        /// 远程接口注册机
        /// </summary>
        private static Dictionary<string, string> registration = new Dictionary<string, string>
        {
            {"baidu", "http://www.baidu.com"},
            {"translate", "http://localhost/Translator/api/Main?key=apple"}
        };

        /// <summary>
        /// 执行远程接口
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns>返回</returns>
        protected override object Evaluate(CommonRequest request)
        {
            var evaluators = GetEvaluator();
            if (evaluators == null) throw new Exception("初始化错误");
            if (!evaluators.ContainsKey(request.method)) throw new Exception("不知所云");
            List<CommonRequest> requests = evaluators[request.method];
            string data = request.data;
            IEnumerable<string> responses = requests?.Select(t => HttpPostWebService($"{t.url}?method={request.method}&data={request.data}&past_nodes={request.past_nodes}&auth_user={request.auth}", data));
            return Merge(request.method, responses);
        }

        private object Merge(string method, IEnumerable<string> enumerable)
        {
            return enumerable;
        }

        /// <summary>  
        /// Model对象转换为uri网址参数形式  
        /// </summary>  
        /// <param name="obj">Model对象</param>  
        /// <param name="url">前部分网址</param>  
        /// <returns></returns>  
        public static string ModelToUriParam(object obj)
        {
            PropertyInfo[] propertis = obj.GetType().GetProperties();
            StringBuilder sb = new StringBuilder();
            foreach (var p in propertis)
            {
                var v = p.GetValue(obj, null);
                if (v == null)
                    continue;
                sb.Append(p.Name);
                sb.Append("=");
                sb.Append(HttpUtility.UrlEncode(v.ToString()));
                sb.Append("&");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// 发送一个HTTP POST请求
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="data">数据</param>
        /// <returns>返回</returns>
        private static string HttpPostWebService(string url, string data)
        {
            string param = string.Empty;
            byte[] bytes = null;

            bytes = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;

            using (var writer = request.GetRequestStream())
            {
                writer.Write(bytes, 0, bytes.Length); //把参数数据写入请求数据流
            }

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                return exception.ToJson();
            }
        }
    }
}