using System;
using System.Data.Entity.Migrations;
using Newtonsoft.Json;
using XiangXi.Models;
using XiangXiENtities.CodeTemplates;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Evaluators
{
    public class SaveSYS_CodeEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var str = request?.data;
            if (string.IsNullOrEmpty(str))
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "参数错误"
                };
            if (Sessions.Count == 0)
            {
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "请登录"
                };
            }
            var user = Sessions[nameof(UserInformation)] as UserInformation;
            if (user == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "请登录"
                };
            using (var ctx = new DefaultContext())
            {
                var code = JsonConvert.DeserializeObject<SYS_Code>(str);
                if (code == null)
                    return new CommonOutputT<string>
                    {
                        success = false,
                        message = "参数错误"
                    };
                var transactionId = Guid.NewGuid().ToString();
                //code.CreateOn = DateTime.Now;
                //code.UpdateOn = DateTime.Now;
                //code.CreateBy = code.CreateBy ?? user.UILoginName;
                //code.UpdateBy = user.UILoginName;
                //code.VersionNo = 1;
                //code.TransactionID = transactionId;
                //code.IsDeleted = 0;
                //ctx.SYS_Code.AddOrUpdate(code);
                ctx.SaveChanges();
                return new CommonOutputT<string>
                {
                    success = true,
                    message = "保存成功"
                };
            }
        }
    }
}