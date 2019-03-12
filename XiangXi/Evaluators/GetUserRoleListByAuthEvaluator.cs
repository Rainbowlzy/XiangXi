using System.Collections.Generic;
using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Evaluators
{
    public partial class GetUserRolesListByAuthEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            if (Sessions.Count == 0)
                return new CommonOutputT<string>()
                {
                    success = false,
                    message = "请登录"
                };
            using (var ctx = new DefaultContext())
            {
                var user = Sessions[nameof(UserInformation)] as UserInformation;
                return new CommonOutputT<List<UserRoles>>()
                {
                    success = true,
                    data =
                        ctx.UserRoles.Where(
                            p => p.URLoginName == user.UILoginName && p.IsDeleted == 0).ToList(),
                    message = "查询成功"
                };
            }
        }
    }
}