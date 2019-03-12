using System;
using System.Data.Entity.Migrations;
using Newtonsoft.Json;
using XiangXi.Models;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Evaluators
{
    public class ChangePasswordEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            var requser = JsonConvert.DeserializeObject<UserInformation>(request.data);
            if (user == null)
            {
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "请先登录"
                };
            }
            if (requser == null)
            {
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "请求参数错误"
                };
            }
            if (user.UILoginName != requser.UILoginName)
            {
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "只能更改自己的密码"
                };
            }
            using (var ctx = new DefaultContext())
            {
                requser.TransactionID = Guid.NewGuid().ToString();
                requser.VersionNo++;
                requser.UpdateOn = DateTime.Now;
                requser.UpdateBy = user.UILoginName;
                ctx.UserInformation.AddOrUpdate(requser);
                ctx.SaveChanges();
            }

            return new CommonOutputT<string>
            {
                success = true,
                message = "操作成功"
            };
        }
    }
    public class UserInfoEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return CurrentUserInformation;
        }
    }
}