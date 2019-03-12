using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// ��ȡ��ǰ�û����ճ�
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