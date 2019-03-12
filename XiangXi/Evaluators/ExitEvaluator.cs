using XiangXi.Models;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 退出登录
    /// </summary>
    public class ExitEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user == null)
            {
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "请登录"
                };
            }
            Exit();
            return new CommonOutputT<string>
            {
                success = true,
                message = "退出成功"
            };
        }
    }
}