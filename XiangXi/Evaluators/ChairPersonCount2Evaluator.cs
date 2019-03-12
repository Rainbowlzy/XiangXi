using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    public partial class ChairPersonCount2Evaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var sexList = ctx.Population.GroupBy(x => x.PNeighborhoodVillageCommittee).Select(x => new { value = x.Count(), name = x.Key }).ToList()
                    ;                    //Database.SqlQuery<Population>(@"select PChairperson as 'name',COUNT(*) as 'value' from Population group by PChairperson").ToList();

                return new
                {
                    sum = sexList.Count(),
                    //xaxis = ranges.ToList(),
                    series = sexList
                };
            }
        }
    }
}