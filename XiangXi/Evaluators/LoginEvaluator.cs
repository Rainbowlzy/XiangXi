using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XiangXi.Models;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Evaluators
{
    [CacheOptions(Timeout = 999)]
    public class LoginEvaluator : Evaluator
    {
        private const int MAX_LOGIN_TIMES = 20;

        private static readonly Dictionary<string, int> failedLogin = new Dictionary<string, int>();

        private static bool CheckMultiLogin(string loginName)
        {
            if (!failedLogin.ContainsKey(loginName)) return true;
            return failedLogin[loginName] <= MAX_LOGIN_TIMES;
        }

        private static void FailedLogin(string loginName)
        {
            if (!failedLogin.ContainsKey(loginName))
            {
                failedLogin.Add(loginName, 1);
            }
            else
            {
                failedLogin[loginName]++;
            }
        }

        protected override object Evaluate(CommonRequest request)
        {
            if (string.IsNullOrEmpty(request?.data))
                return new CommonOutputT<string>
                {
                    success = false,
                    data = null,
                    message = "参数错误"
                };
            var user = JsonConvert.DeserializeObject<UserInformation>(request.data);
            if (string.IsNullOrEmpty(user?.UILoginName))
            {
                return new CommonOutputT<string>
                {
                    success = false,
                    data = null,
                    message = "参数错误"
                };
            }
            if (!CheckMultiLogin(user.UILoginName))
            {
                return new CommonOutputT<string>
                {
                    success = false,
                    data = null,
                    message = "非法登录"
                };
            }
            if (Sessions.ContainsKey(nameof(UserInformation)) && Sessions.ContainsKey("token"))
            {
                return new CommonOutputT<string>
                {
                    success = true,
                    data = Sessions["token"].ToString(),
                    message = "登录成功"
                };
            }
            using (var c = new DefaultContext())
            {
                var one = c.UserInformation.FirstOrDefault(u => u.UILoginName == user.UILoginName);
                if (one == null)
                {
                    FailedLogin(user.UILoginName);
                    return new CommonOutputT<string>
                    {
                        success = false,
                        data = null,
                        message = "请注册"
                    };
                }
                if (one.UIPassword != user.UIPassword)
                {
                    FailedLogin(user.UILoginName);
                    return new CommonOutputT<string>
                    {
                        success = false,
                        data = null,
                        message = "非法的用户凭据"
                    };
                }

                var token = Guid.NewGuid().ToString();
                BuildSession(token, one);
                using (var ctx = new DefaultContext())
                {
                    ctx.LoginRecord.Add(new LoginRecord
                    {
                        CreateBy = "LoginEvaluator",
                        UpdateBy = "LoginEvaluator",
                        CreateOn = DateTime.Now,
                        UpdateOn = DateTime.Now,
                        id = Guid.NewGuid().ToString(),
                        IsDeleted = 0,
                        LRLoginName = user.UILoginName,
                        LRLoginTime = DateTime.Now,
                        TransactionID = Guid.NewGuid().ToString(),
                        VersionNo = 0
                    });
                    ctx.SaveChanges();
                }
                return new CommonOutputT<string>
                {
                    success = true,
                    data = token,
                    message = "登录成功"
                };
            }
        }
    }
}