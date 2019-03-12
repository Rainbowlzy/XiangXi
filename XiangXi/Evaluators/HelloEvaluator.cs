using XiangXi.Models;

namespace XiangXi.Evaluators
{
    public class HelloEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new AppIndex
            {
                config = new AppIndexConfig
                {
                    bannerImage = "http://192.168.1.111/XiangXi/Upload/portrait/R0001.jpg"
                },
                menu = new []
                {
                    new MenuItem
                    {
                        image="http://192.168.1.111/XiangXi/Upload/portrait/R0001.jpg",
                        title="123",
                        url="123"
                    },
                }
            };
        }
    }
}