using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XiangXi.Models;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Evaluators
{
    public class SaveMenuRoleDicEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            if (string.IsNullOrEmpty(request?.data)) return new CommonOutputT<string>
            {
                success = false,
                message = "空数据错误"
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
            if (user == null) return new CommonOutputT<string>
            {
                success = false,
                message = "请登录"
            };
            var keypair = JsonConvert.DeserializeObject<List<Dictionary<string,string>>>(request.data);
            using (var c = new DefaultContext())
            {
                var userMenus = c.RoleMenu.ToList().Select(c.RoleMenu.Remove).ToList();
                var transactionId = Guid.NewGuid().ToString();
                foreach (Dictionary<string, string> dic in keypair)
                {
                    var key = dic.Keys.FirstOrDefault();
                    if (key != null)
                    {
                        var val = dic[key];
                        c.RoleMenu.Add(new RoleMenu
                        {
                            id = Guid.NewGuid().ToString(),
                            RMRoleName = val,
                            RMMenuTitle = key,
                            CreateOn = DateTime.Now,
                            UpdateOn = DateTime.Now,
                            CreateBy = user.UILoginName,
                            UpdateBy = user.UILoginName,
                            VersionNo = 1,
                            TransactionID = transactionId,
                            IsDeleted = 0
                        });
                    }
                }
                c.SaveChanges();
            }
            return new CommonOutputT<string>
            {
                success = true,
                message = "操作成功"
            };
        }
    }
}