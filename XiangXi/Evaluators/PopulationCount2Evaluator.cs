using System;
using System.Collections.Generic;
using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    [CacheOptions(Timeout = 5000)]
    public partial class PopulationCount2Evaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                //var now = DateTime.Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                //var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                //var list = dates.Select(p => ctx.Population.Count(m => m.CreateOn==p)).ToList();
                List<string> ranges = new List<string>();
                ranges.Add("1~20");
                ranges.Add("21~40");
                ranges.Add("41~60");
                ranges.Add("61~80");
                ranges.Add("81~100");
                ranges.Add("101~150");
                ranges.Add("151~200");
                var num = new List<int>();
                for (int i = 0; i < ranges.Count(); i++)
                {
                    if (ranges[i].Contains("~"))
                    {
                        var arr = ranges[i].Split('~');
                        int[] ar = new int[2];
                        for (int j = 0; j < arr.Length; j++)
                        {
                            ar[j] = Convert.ToInt32(arr[j]);
                        }
                        int min = ar[0];
                        int max = ar[1];
                        int n = ctx.Population.Where(p => p.PAge >= min && p.PAge <= max && p.PAge != null).Count();
                        num.Add(n);
                    }
                }
                for (int i = 0; i < ranges.Count; i++)
                {
                    ranges[i] += "岁";
                }
                return new
                {
                    //sum = list.Sum(),
                    //xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    //series = list
                    sum = num.Sum(),
                    xaxis = ranges.ToList(),
                    series = num
                };
            }
        }
    }
}