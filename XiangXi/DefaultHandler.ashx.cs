using System;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using XiangXi.Evaluators;
using XiangXi.Interfaces;
using XiangXi.Models;
using Validation = Microsoft.Practices.EnterpriseLibrary.Validation.Validation;
using ValidationResult = Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResult;

namespace XiangXi
{
    /// <summary>
    /// DefaultHandler 的摘要说明
    /// </summary>
    public class DefaultHandler : IHttpHandler
    {
        private const string MANAGER_EMAIL_ADDRESS = "zhengyao.lu@qq.com";

        /// <summary>
        /// 处理机构
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;
            
            //浏览器应当在cookie中身份验证，APP可以使用http参数
            var authUser = request.Cookies["auth_user"];
            var auth = authUser == null ? "" : HttpUtility.UrlDecode(authUser.Value);
            if (string.IsNullOrEmpty(auth)) auth = request.Params["auth_user"] ?? "";
            if (!string.IsNullOrEmpty(auth)) auth = auth.Split(',').FirstOrDefault();
            var method = request.Params["method"];
            var qmethod = request.QueryString["method"];
            var data = HttpUtility.UrlDecode(request.Params["data"]);
            var qdata = request.QueryString["data"];
            var crequest = new CommonRequest
            {
                auth = auth,
                method = method ?? qmethod ?? "",
                data = data ?? qdata ?? "",
                context = context
            };

            response.AddHeader("Access-Control-Allow-Origin", "*");
            var validationResults = Validation.Validate(crequest);
            foreach (ValidationResult result in validationResults)
            {
                crequest.context = null;
                response.ContentType = "text/plain";
                error(result.Message);
                response.Write(result.Message);
                return;
            }
            var evaluator = "evaluator";
            crequest.method = crequest.method.ToLower();
            if (crequest.method.Contains(evaluator))
                crequest.method = crequest.method.Substring(0, crequest.method.IndexOf(evaluator, StringComparison.Ordinal));
            crequest.method += evaluator;
            response.ContentType = "application/json";
            using (IEvaluator ieval = Evaluator.Make(crequest))
            {
                try
                {
                    var val = ieval.Eval(crequest);
                    var json = val.ToJson();
                    response.Write(json);
                }
                catch (DbEntityValidationException exception)
                {
                    crequest.context = null;
                    response.ContentType = "text/plain";
                    string newLine = Environment.NewLine;
                    string message = $"{exception.Message}" +
                                   $"\n\n" +
#if DEBUG
                                $"{string.Join(newLine, exception.EntityValidationErrors.SelectMany(p => p.ValidationErrors).Select(p => $"{p.PropertyName} {p.ErrorMessage}"))}" +
                                    newLine +
                                    $"{exception.StackTrace}" +
#endif
                               $"";
                    error(message);
                    response.Write(message);
                }
                catch (Exception exception)
                {
                    crequest.context = null;
                    response.ContentType = "text/plain";
                    string message = $"{exception.Message}" +
                                   $"\n\n" +
#if DEBUG
                                $"{exception.StackTrace} \r\n{JsonConvert.SerializeObject(exception)}" +
#endif
                               $"";
                    error(message);
                    response.Write(message);
                    return;
                }
            }
        }

        public void error(string message)
        {
            try
            {
                File.WriteAllText($"{@"D:\errors\"}{DateTime.Now.Ticks}.log", message);
                var address = new MailAddress(MANAGER_EMAIL_ADDRESS, "路正遥", Encoding.UTF8);
                var mail = new MailMessage(MANAGER_EMAIL_ADDRESS, MANAGER_EMAIL_ADDRESS, "香溪系统线上异常", message);
                var client = new SmtpClient("smtp.qq.com", 993);
                client.ClientCertificates.Add(new System.Security.Cryptography.X509Certificates.X509Certificate());
                client.Credentials = new NetworkCredential("user", "password");
                client.Send(mail);
            }
            catch (Exception)
            {
                return;
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}