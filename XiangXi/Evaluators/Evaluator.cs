using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XiangXi.Interfaces;
using XiangXi.Models;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Evaluators
{
    public abstract class Evaluator : IEvaluator
    {
        private static Dictionary<string, Dictionary<string, object>> _sessions = new Dictionary<string, Dictionary<string, object>>(10);


        private UserInformation _user;

        private CommonRequest Request { get; set; }

        static Evaluator()
        {
            Process.Start("cmd", "/C net start MSSQLSERVER");
        }
        protected Evaluator()
        {
            _user = CurrentUserInformation;
        }

        public virtual string Comments => "重写此方法给出中文描述";

        protected void BuildSession(string token, UserInformation user)
        {
            if (_sessions.Count == 0 && File.Exists("_session.txt")) _sessions = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(File.ReadAllText("_session.txt"));
            _sessions.Add(token,
                new Dictionary<string, object> { { nameof(UserInformation), user }, { nameof(token), token } });
        }
        public void BuildSession(string token, Population user)
        {
            if (_sessions.Count == 0 && File.Exists("_session.txt")) _sessions = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(File.ReadAllText("_session.txt"));
            _sessions.Add(token,
                new Dictionary<string, object> { { nameof(UserInformation), user }, { nameof(token), token } });
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public UserInformation CurrentUserInformation
        {
            get
            {
                var key = "UserInformation";
                return Sessions == null || !Sessions.ContainsKey(key)
                    ? new UserInformation
                    {
                        UIRealName = "公众",
                        UILoginName = "public",
                        DataLevel = "019999",
                    }
                    : Sessions[key] as UserInformation;
            }
        }

        protected void Exit()
        {
            _sessions.Remove(Request.auth);
        }

        class CachedEntity<T> where T : class
        {
            public T data { get; set; }
            public DateTime createdtime { get; set; }

            public CachedEntity(T t)
            {
                data = t;
                createdtime = DateTime.Now;
            }
        }

        /// <summary>
        /// 暂存类标签属性
        /// </summary>
        private static Dictionary<Type, Dictionary<Type, object>> options = typeof(Evaluator).Assembly.GetTypes()
            .Where(t => t.BaseType == typeof(Evaluator))
            .GroupBy(t => t)
            .ToDictionary(t => t.Key, t =>
            t.FirstOrDefault()?.GetCustomAttributes(true).GroupBy(k => k.GetType()).ToDictionary(k => k.Key, k => k.FirstOrDefault()));

        /// <summary>
        /// 获取当前类标签属性
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private object GetTypeOption(Type type)
        {
            if (options.ContainsKey(GetType()) && options[GetType()].ContainsKey(type))
            {
                return options[GetType()][type];
            }
            return null;
        }

        private T Cache<T>(string key, Func<T> f) where T : class
        {
            CacheOptionsAttribute attr = GetTypeOption(typeof(CacheOptionsAttribute)) as CacheOptionsAttribute;
            int CachePeriod = 5;
            if (attr == null) return f();
            if (attr.Timeout > 0)
            {
                CachePeriod = attr.Timeout;
            }
            if (Sessions == null) return f();

            if (Sessions.Any() && Sessions.ContainsKey(key))
            {
                var entity = Sessions[key] as CachedEntity<T>;
                if (entity == null || entity.createdtime > DateTime.Now.AddMinutes(-CachePeriod))
                {
                    var f1 = f();
                    Sessions[key] = new CachedEntity<T>(f1);
                    return f1;
                }
                return entity.data;
            }
            T t = f();
            if (Sessions.ContainsKey(key)) Sessions[key] = new CachedEntity<T>(t);
            else Sessions.Add(key, new CachedEntity<T>(t));
            return t;
        }

        protected Dictionary<string, object> Sessions
        {
            get
            {
                var session_cache_file = "_session.txt";
                if (_sessions==null && File.Exists(session_cache_file))
                {
                    _sessions = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(File.ReadAllText(session_cache_file));
                }

                var auth = Request?.auth;
                if (_sessions != null && auth != null)
                {
                    return _sessions.ContainsKey(auth)
                        ? _sessions[auth]
                        : _sessions[auth] = new Dictionary<string, object>();
                }
                return null;
            }
        }

        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <returns></returns>  
        private static HttpWebResponse CreateGetHttpResponse(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            return request.GetResponse() as HttpWebResponse;
        }

        private static async Task<WebResponse> CreateGetHttpResponseAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            return await request.GetResponseAsync();
        }

        /// <summary>
        /// 翻译接口
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string Translate(string key)
        {
            return HttpGet($"http://localhost/Translator/api/Main?key={key}");
        }

        public static async Task<T> Call<T>(string method, object data, string auth = "") where T : class, new()
        {
            var result = await HttpGetAsync($"http://localhost/XiangXi/DefaultHandler.ashx?method={method}&data={data}&auth_user={auth}");
            return result.Deserialize<T>();
        }

        /// <summary>
        /// 发送HTTP GET请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string HttpGet(string url)
        {
            Stream responseStream = CreateGetHttpResponse(url).GetResponseStream();
            string buf = string.Empty;
            if (responseStream != null)
            {
                using (StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8")))
                {
                    buf = reader.ReadToEnd();
                }
                responseStream.Close();
            }
            return buf;
        }

        private static async Task<string> HttpGetAsync(string url)
        {
            var resp = await CreateGetHttpResponseAsync(url);
            Stream responseStream = resp.GetResponseStream();
            string buf = string.Empty;
            if (responseStream != null)
            {
                using (StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8")))
                {
                    buf = reader.ReadToEnd();
                }
                responseStream.Close();
            }
            return buf;
        }

        private static readonly Dictionary<string, Type> types = new[] { typeof(Evaluator), typeof(DefaultContext) }.SelectMany(t => t.Assembly.GetTypes())
            .GroupBy(t => t.Name.ToLower())
            .ToDictionary(t => t.Key, t => t.FirstOrDefault());

        /// <summary>
        /// 处理机映射
        /// </summary>
        private static readonly Dictionary<string, IEvaluator> Registrations = typeof(Evaluator).Assembly.GetTypes()
            .Where(t => t.BaseType == typeof(Evaluator))
            .GroupBy(t => t.Name.ToLower())
            .ToDictionary(t => t.Key, t => Activator.CreateInstance(t.FirstOrDefault()) as IEvaluator);

        protected object Redirect(string method)
        {
            Request.method = method;
            var evaluator = Make(Request);
            return evaluator.Eval(Request);
        }

        private static object TryCreateInstance(string typeName)
        {
            typeName = typeName.TrimStart("get".ToCharArray()).TrimStart("save".ToCharArray()).TrimStart("delete".ToCharArray()).TrimEnd("list".ToCharArray()).TrimEnd("count".ToCharArray());
            if (!types.ContainsKey(typeName)) return null;
            return Activator.CreateInstance(types[typeName]);
        }

        public static UserInformation GetUser(string auth_user)
        {
            return (Make(new CommonRequest
            {
                method = nameof(GetUserInformationListEvaluator),
                auth = auth_user,
            }) as GetUserInformationListEvaluator)?.CurrentUserInformation;
        }
        /// <summary>
        /// 创建可以处理数据的处理机
        /// </summary>
        /// <param name="request">待处理数据</param>
        /// <returns>处理机</returns>
        public static IEvaluator Make(CommonRequest request)
        {
            var method = request.method.ToLower().Trim();
            if (string.IsNullOrEmpty(method))
            {
                throw new ArgumentNullException(nameof(method));
            }
            if (!method.EndsWith("evaluator"))
            {
                request.method += "evaluator";
            }
            if (method == "list_all_of_evaluators")
            {
                return
                       new ShowEvaluator(
                           Registrations.Keys
                               .Select(p => p.Replace("evaluator", string.Empty))
                               .Select(p => new
                               {
                                   name = p,
                                   description = string.Join(" ", JsonConvert.DeserializeObject<string[]>(Translate(p))),
                                   uri = $"http://localhost:8091/XiangXi/DefaultHandler.ashx?method={p}&data={{}}",
                                   relateduri = $"/XiangXi/DefaultHandler.ashx?method={p}&data={{}}",
                                   post_body = $"",
                                   contact = "路正遥",
                                   mail = "zhengyao.lu@qq.com",
                                   method = p,
                                   data = TryCreateInstance(p)
                               })
                               .OrderBy(p => p.name));
            }

            //if (!Registrations.ContainsKey(request.method))
            //{
            //    return new RemoteEvaluator();
            //}

            if (!Registrations.ContainsKey(method))
            {
                throw new Exception($"Method not found with {method}");
            }

            var evaluator = Registrations[method];
            var o = evaluator as Evaluator;
            if (o != null) o.Request = request;
            return evaluator;
        }

        public object Eval(CommonRequest request)
        {
            var method = request.method.ToLower();
            if ("save,delete".Split(',').Any(s=>method.StartsWith(s)))
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    foreach (var s in Sessions.Keys.Where(p => p.Contains(method.Substring(3)+",")).AsParallel())
                    {
                        Sessions.Remove(s);
                    }
                });

                return OnAfterEvaluate(Evaluate(OnBeforeEvaluate(request)));
            }
            return Cache($"{request.method},{request.data},{request.auth}", () => OnAfterEvaluate(Evaluate(OnBeforeEvaluate(request))));
        }

        protected abstract object Evaluate(CommonRequest request);

        /// <summary>
        /// 控制方法执行前
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual CommonRequest OnBeforeEvaluate(CommonRequest request)
        {
            return request;
        }

        /// <summary>
        /// 控制方法执行后
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected virtual object OnAfterEvaluate(object obj)
        {
            return obj;
        }

        public void Dispose()
        {
            Request = null;
            _user = null;
        }
    }
}