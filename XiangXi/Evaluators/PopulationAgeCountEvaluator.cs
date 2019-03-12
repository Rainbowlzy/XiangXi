using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 人口年龄统计
    /// </summary>
    [CacheOptions(Timeout = 5000)]
    public class PopulationAgeCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var context = new DefaultContext())
            {
                return new
                {
                    series = context.Population.Where(t => t.PAge > 0).Select(t =>
                      t.PAge <= 15 ? "15岁以下" :
                      t.PAge > 15 && t.PAge <= 20 ? "15到20岁" :
                      t.PAge > 20 && t.PAge <= 30 ? "20到30岁" :
                      t.PAge > 30 && t.PAge <= 40 ? "30到40岁" :
                      t.PAge > 40 && t.PAge <= 50 ? "40到50岁" :
                      t.PAge > 50 && t.PAge <= 60 ? "50到60岁" :
                      t.PAge > 60 && t.PAge <= 70 ? "60到70岁" :
                      t.PAge > 70 && t.PAge <= 80 ? "70到80岁" :
                      t.PAge > 80 && t.PAge <= 90 ? "80到90岁" :
                      t.PAge > 90 && t.PAge <= 100 ? "90到100岁" : "100岁以上"
                ).GroupBy(t => t).Select(t => new
                {
                    name = t.Key,
                    value = t.Count()
                }).ToList()
                };
            }
        }
    }
}