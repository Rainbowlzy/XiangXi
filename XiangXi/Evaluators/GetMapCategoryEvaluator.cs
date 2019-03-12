using System.Collections.Generic;
using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 地图分类统计数量接口
    /// </summary>
    public class GetMapCategoryEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var context = new DefaultContext())
            {
                var menuConfigurations = context.MenuConfiguration.Where(t => t.MCParentTitle == "地图圆形菜单").ToList();
                return new TreeNode<object>[] {
            new TreeNode<object>
            {
                title = $"人口 ({context.Population.Count()})",
                data = menuConfigurations.FirstOrDefault(t=>t.MCTitle=="地图人口"),
                children = new List<TreeNode<object>>(new[]{
                    new TreeNode<object>
                    {
                        title=$"全部 ({context.Population.Count()})",
                    },
                    new TreeNode<object>
                    {
                        title=$"党员 ({context.InformationManagementOfPartyMembers.Count()})",
                    },
                    new TreeNode<object>
                    {
                        title=$"老年人 ({context.Population.Count(t=>t.PAge>=60)})",
                    },
//                    new TreeNode<object>
//                    {
//                        title=$"残疾人 ({context.TheObjectOfCare.Count()})",
//                    },
//                    new TreeNode<object>
//                    {
//                        title=$"民兵 ({context.Militia.Count()})",
//                    },
//                    new TreeNode<object>
//                    {
//                        title=$"干部 ({context.Cadre.Count()})",
//                    },
                })
            },
            new TreeNode<object>
            {
                title = "产业园",
                data = menuConfigurations.FirstOrDefault(t=>t.MCTitle=="地图产业园"),
                children = new List<TreeNode<object>>(context.FactoryBuilding.Where(t=>t.FBNameOfIndustrialPark.Length>0).GroupBy(t=>t.FBNameOfIndustrialPark).Select(t=>new TreeNode<object>{
                    title = t.Key+" ("+t.Count()+")"
                }))
            },
                    new TreeNode<object>
                    {
                        title = $"摄像头 ({context.VideoPointInformation.Count()})",
                        data = menuConfigurations.FirstOrDefault(t=>t.MCTitle=="地图摄像头"),
                    },
                    new TreeNode<object>
                    {
                        title = $"切换地图 ({context.VideoPointInformation.Count()})",
                        data = menuConfigurations.FirstOrDefault(t=>t.MCTitle=="地图切换地图"),
                    },
            };
            }
        }
    }
}