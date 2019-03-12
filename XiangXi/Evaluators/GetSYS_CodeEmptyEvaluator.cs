using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    public partial class GetSYS_CodeEmptyEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new SYS_Code();
        }
    }
}