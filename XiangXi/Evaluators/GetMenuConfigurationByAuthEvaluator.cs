using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    public class GetMenuConfigurationByAuthEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            if (Sessions.Count == 0)
            {
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "请登录",
                    data = null
                };
            }

            var user = CurrentUserInformation;
            if (user == null)
            {
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "请登录",
                    data = null
                };
            }

            var key = request.context.Request.Params["key"] ?? "后台首页";
            using (var ctx = new DefaultContext())
            {
                var role = ctx.UserRoles.FirstOrDefault(p => p.URLoginName == user.UILoginName && p.IsDeleted == 0);
                if (role == null)
                {
                    return new CommonOutputT<string>
                    {
                        success = false,
                        message = "该用户未配置任何角色",
                        data = null
                    };
                }

                var mainMenu = ctx.MenuConfiguration.Where(p => p.MCParentTitle == key && p.IsDeleted == 0);
                var roleName = role.URRoleName;
                var topmenu =
                    ctx.RoleMenu.Where(p => p.IsDeleted == 0 && p.RMRoleName == roleName)
                        .GroupBy(p => p.RMMenuTitle)
                        .Select(p => p.Key)
                        .Join(mainMenu, s => s, menu => menu.MCTitle, (s, configuration) => configuration)
                        .OrderBy(p => p.MCOrder)
                        .ToList();
                var allLeftMenu = ctx.MenuConfiguration.Where(p => p.MCParentTitle == "后台首页左侧" && p.IsDeleted == 0);
                var leftmenu =
                    ctx.RoleMenu.Where(p => p.IsDeleted == 0 && p.RMRoleName == roleName)
                        .GroupBy(p => p.RMMenuTitle)
                        .Select(p => p.Key)
                        .Join(allLeftMenu, s => s, menu => menu.MCTitle, (s, configuration) => configuration)
                        .OrderBy(p => p.MCOrder)
                        .ToList();

                //var backgroundimagecode = ctx.SYS_Code.FirstOrDefault(p => p.category == "首页背景图片");
                return new
                {
                    rows = topmenu.ToArray(),
                    topmenu = topmenu.ToArray(),
                    leftmenu = leftmenu.ToArray(),
                    specialwork = ctx.SpecialWork.OrderByDescending(t => t.CreateOn).ToList(),
                    //background = backgroundimagecode?.val,
                    success = true,
                    message = "查询成功"
                };
            }
        }
    }
}