using System;
using System.Data.Entity.Validation;
using System.Linq;
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
    public class Version : IHttpHandler
    {
        /// <summary>
        /// 处理机构
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;
            response.ContentType = "text/plain";
            response.Write($"1.0");
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