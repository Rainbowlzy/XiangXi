using System;
using System.Collections.Generic;
using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Evaluators
{
    public class QueryNavEvaluator : Evaluator
    {
        const int MAX = 20;
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user == null)
            {
                return new string[0];
            }

            var MCTitle = request.data.Trim("\"".ToCharArray());
            using (var ctx = new DefaultContext())
            {
                var list = new List<MenuConfiguration>();
                var cur = ctx.MenuConfiguration.FirstOrDefault(t => t.MCTitle == MCTitle && t.IsDeleted == 0 && t.DataLevel == user.DataLevel && t.MCParentTitle.Length > 0);
                while (cur != null && list.Count < MAX)
                {
                    list.Add(cur);
                    cur = ctx.MenuConfiguration.FirstOrDefault(t => t.MCTitle == cur.MCParentTitle && t.IsDeleted == 0 && t.DataLevel == user.DataLevel);
                }
                list.Reverse();
                return list;
            }
        }
    }
    public class QueryNav2Evaluator : Evaluator
    {
        const int MAX = 20;
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user == null)
            {
                return new string[0];
            }

            var menu = request.data.Deserialize<MenuConfiguration>();
            var datalevel = user.DataLevel;
            var menuid = menu.id;
            using (var ctx = new DefaultContext())
            {
                var list = new List<MenuConfiguration>();
                var cur = ctx.MenuConfiguration.FirstOrDefault(t => t.id == menuid && t.IsDeleted == 0 && t.DataLevel == datalevel && t.MCParentTitle.Length > 0);
                while (cur != null && list.Count < MAX)
                {
                    list.Add(cur);
                    cur = ctx.MenuConfiguration.FirstOrDefault(t => t.MCTitle == cur.MCParentTitle && t.IsDeleted == 0 && t.DataLevel == datalevel);
                }
                list.Reverse();
                return list;
            }
        }
    }

    /// <summary>
    /// 查询党员点位列表
    /// </summary>
    //[CacheOptions(Timeout = 50000)]
    public class MapQueryPartyMemberEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                return
                    ctx.Population.Join(ctx.InformationManagementOfPartyMembers,
                        population => population.PCitizenshipNumber, members => members.IMOPMIdNumber,
                        (population, members) => population)
                        .Join(ctx.Poi, population => population.PAddress,
                            poi => poi.PAddress, (population, poi) => poi).OrderBy(poi => poi.ord).ToList();
            }
        }
    }
}