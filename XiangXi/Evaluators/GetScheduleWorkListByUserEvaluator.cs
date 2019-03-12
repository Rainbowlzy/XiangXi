using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 获取当前用户的日程
    /// </summary>
    public partial class GetScheduleWorkListByUserEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            using (var ctx = new DefaultContext())
            {
                return new
                {
                    rows = ctx.ScheduleWork.Where(p => p.SWPersonInCharge == user.UIRealName).ToList()
                };
            }
        }
    }
}