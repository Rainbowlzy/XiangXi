using System;
using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    public class OccupancyRatePieEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = GetUserInformation();
            if (user == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    data = null,
                    message = "请登录"
                };
            using (var ctx = new DefaultContext())
            {
                // TODO 入驻率统计
                return null;
            }
        }
    }

    /// <summary>
    /// 获取当前用户的消息列表
    /// </summary>
    public class GetNoticeListByUserEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = GetUserInformation();
            if(user==null)
                return new CommonOutputT<string>
                {
                    success = false,
                    data = null,
                    message = "请登录"
                };
            using (var ctx = new DefaultContext())
            {
                var conferenceNoticeList = ctx.ConferenceNotice
                    .Where(p => p.CNParticipant.Contains(user.UILoginName))
                    .ToList()
                    .Select(p => new Notice
                    {
                        NCaption = p.CNTitleOfTheConference,
                        NNotifyingTheSendingObject = p.CNParticipant
                    });
                var lastWeek = DateTime.Now.AddDays(-7);
                var outdatedenterprise = ctx.Enterprise
                    .Where(p => p.EContractDate > lastWeek)
                    .ToList()
                    .Select(p => new Notice
                    {
                        NCaption = $"公司企业 ： {p.EEnterpriseName} 合同即将到期",
                        NContent = $"公司 : {p.EEnterpriseName} 合同期至 {p.EContractDate.Value.ToString("yyyy年MM月dd日")}"
                    });
                var lastMonth = DateTime.Now.AddMonths(-1);
                var outdatedelectricity = ctx.RecordOfElectricityPayment
                    .GroupBy(p => p.ROEPEnterpriseName)
                    .Where(p => p.Max(s => s.ROEPCollectionTime) < lastMonth)
                    .ToList()
                    .Select(p => new Notice
                    {
                        NCaption = p.Key,
                        NContent = $"公司 {p.Key} 电费逾期"
                    });
                var outdatedrent = ctx.RecordOfRentCollection
                    .GroupBy(p => p.RORCEnterpriseName)
                    .Where(p => p.Max(s => s.RORCCollectionTime) < lastMonth)
                    .ToList()
                    .Select(p => new Notice
                    {
                        NCaption = p.Key,
                        NContent = $"公司 {p.Key} 租金逾期"
                    });
                var notices = ctx.Notice
                    .Where(p => p.NNotifyingTheSendingObject.Contains(user.UILoginName))
                    .ToList()
                    .Union(outdatedenterprise)
                    .Union(outdatedelectricity)
                    .Union(conferenceNoticeList).ToList();

                return new
                {
                    success = true,
                    rows =
                        notices,
                    message = "success"
                };
            }
        }
    }
}