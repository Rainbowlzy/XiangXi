  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiangXi.Models;
using XiangXiENtities.EF;
using Newtonsoft.Json;
using System.Data.Entity.Migrations;

namespace XiangXi.Evaluators
{
    public partial class DeleteTwoTypesOfOrganizationsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<TwoTypesOfOrganizations>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new XiangXiEntities())
            {
                var one = ctx.TwoTypesOfOrganizations.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
				ctx.TwoTypesOfOrganizations.Remove(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
    }
    public partial class SaveTwoTypesOfOrganizationsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            if (Sessions.Count==0)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            var user = Sessions[nameof(UserInformation)] as UserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new XiangXiEntities())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<TwoTypesOfOrganizations>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.TwoTypesOfOrganizations.FirstOrDefault(p=>p.id==entity.id);
                    if(one==null) return new
                    {
                        success = false,
                        message = "编辑错误，未找到ID"
                    };
                    if (one.VersionNo != entity.VersionNo) return new
                    {
                        success = false,
                        message = "发生数据写冲突"
                    };
                    one.VersionNo++;
                    one.TransactionID = transactionId;
					ctx.TwoTypesOfOrganizations.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }

                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                var now = DateTime.Now;
                entity.CreateOn = entity.CreateOn ?? now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = now;
                entity.IsDeleted = 0;
				ctx.TwoTypesOfOrganizations.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
    }

    public partial class GetTwoTypesOfOrganizationsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new TwoTypesOfOrganizations();
        }
    }

    public partial class GetTwoTypesOfOrganizationsListEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new SPCall())
            {
                int? total;
                SPCallParameter sppara = null;
				if(!string.IsNullOrEmpty(request.data)){
					sppara = JsonConvert.DeserializeObject<SPCallParameter>(request.data);
				}
                TwoTypesOfOrganizations[] rows = null;
                if (sppara != null)
                {
                    rows=ctx.SP_GET_ALL_LIST<TwoTypesOfOrganizations>(sppara);
                    return new
                    {
                        success = true,
                        rows = rows,
                        total = sppara.total
                    };
                }
                rows = ctx.SP_GET_ALL_LIST<TwoTypesOfOrganizations>("", "", "", "", "", 0, 10, out total);
                return new
                {
                    success = true,
                    rows = rows,
                    total = total
                };
            }
        }
    }
}
