using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace XiangXi.Models
{
    public class CommonRequest
    {
        internal object past_nodes;

        /// <summary>
        /// 功能
        /// </summary>
        [NotNullValidator(ErrorMessage = "请求的方法名不存在")]
        public string method { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        [NotNullValidator(ErrorMessage = "无法验证当前身份，请求无效")]
        public string auth { get; set; }

        public HttpContext context { get; set; }

        public string url { get; set; }

        public CommonRequest SetUrl(string url)
        {
            this.url = url;
            return this;
        }
    }
}