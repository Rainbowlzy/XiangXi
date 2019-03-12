
/* ------------------------------------------------------------ *
 * 此文件由生成器引擎根据既有规则生成，所有手工的更改将会被覆盖
 * 生成时间：03/12/2019 13:34:31
 * 生成版本：03/12/2019 13:33:51 
 * 作者：路正遥
 * ------------------------------------------------------------ */

using XiangXiENtities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiangXi.Models;
using Newtonsoft.Json;
using System.Data.Entity.Migrations;
using static System.Data.Objects.EntityFunctions;
using static System.DateTime;
using static System.Linq.Enumerable;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Evaluators
{

    /// <summary>
    /// 【菜单配置】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class MenuConfigurationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.MenuConfiguration.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【菜单配置】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【菜单配置】
    /// </summary>
    public partial class DeleteMenuConfigurationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<MenuConfiguration>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.MenuConfiguration.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.MenuConfiguration.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条菜单配置记录";
    }
	
    /// <summary>
    /// 保存【菜单配置】
    /// </summary>
    public partial class SaveMenuConfigurationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<MenuConfiguration>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.MenuConfiguration.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.MenuConfiguration.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.MCTitle = HttpUtility.UrlDecode(entity.MCTitle);
					// NVARCHAR(4000)
				entity.MCLink = HttpUtility.UrlDecode(entity.MCLink);
					// NVARCHAR(4000)
				entity.MCPicture = HttpUtility.UrlDecode(entity.MCPicture);
					// NVARCHAR(4000)
				entity.MCParentTitle = HttpUtility.UrlDecode(entity.MCParentTitle);
					// NVARCHAR(50)
				entity.MCMenuType = HttpUtility.UrlDecode(entity.MCMenuType);
					// NVARCHAR(50)
				entity.MCDisplayName = HttpUtility.UrlDecode(entity.MCDisplayName);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.MenuConfiguration.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条MenuConfiguration记录";
    }
	
    /// <summary>
    /// 查询空的【菜单配置】
    /// </summary>
    public partial class GetMenuConfigurationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new MenuConfiguration();
        }
        public override string Comments=> "获取空的菜单配置记录";
    }
	
    /// <summary>
    /// 查询【菜单配置】列表
    /// </summary>
    public partial class GetMenuConfigurationListEvaluator : Evaluator
    {
        public override string Comments=> "获取MenuConfiguration列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<MenuConfigurationSearchModel>() ?? new MenuConfigurationSearchModel();
                var query = ctx.MenuConfiguration.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// MCTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.MCTitle)) query = query.Where(t=>t.MCTitle.Contains(searchModel.MCTitle));
                if(sort=="MCTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MCTitle):query.OrderByDescending(t=>t.MCTitle);
                    isordered = true;
                }
				// MCLink NVARCHAR(4000) 链接 
                if(!string.IsNullOrEmpty(searchModel.MCLink)) query = query.Where(t=>t.MCLink.Contains(searchModel.MCLink));
                if(sort=="MCLink")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MCLink):query.OrderByDescending(t=>t.MCLink);
                    isordered = true;
                }
				// MCPicture NVARCHAR(4000) 图片 
                if(!string.IsNullOrEmpty(searchModel.MCPicture)) query = query.Where(t=>t.MCPicture.Contains(searchModel.MCPicture));
                if(sort=="MCPicture")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MCPicture):query.OrderByDescending(t=>t.MCPicture);
                    isordered = true;
                }
				// MCParentTitle NVARCHAR(4000) 父级标题 
                if(!string.IsNullOrEmpty(searchModel.MCParentTitle)) query = query.Where(t=>t.MCParentTitle.Contains(searchModel.MCParentTitle));
                if(sort=="MCParentTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MCParentTitle):query.OrderByDescending(t=>t.MCParentTitle);
                    isordered = true;
                }
				// MCMenuType NVARCHAR(50) 菜单类型 
                if(!string.IsNullOrEmpty(searchModel.MCMenuType)) query = query.Where(t=>t.MCMenuType.Contains(searchModel.MCMenuType));
                if(sort=="MCMenuType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MCMenuType):query.OrderByDescending(t=>t.MCMenuType);
                    isordered = true;
                }
				// MCOrder INT 顺序 
                if(searchModel.MinMCOrder!=null) query = query.Where(t=>t.MCOrder>=searchModel.MinMCOrder);
                if(searchModel.MaxMCOrder!=null) query = query.Where(t=>t.MCOrder<=searchModel.MaxMCOrder);
                if(sort=="MCOrder")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MCOrder):query.OrderByDescending(t=>t.MCOrder);
                    isordered = true;
                }
				// MCDisplayName NVARCHAR(50) 显示名称 
                if(!string.IsNullOrEmpty(searchModel.MCDisplayName)) query = query.Where(t=>t.MCDisplayName.Contains(searchModel.MCDisplayName));
                if(sort=="MCDisplayName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MCDisplayName):query.OrderByDescending(t=>t.MCDisplayName);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.MCTitle.Contains(search)||t.MCLink.Contains(search)||t.MCPicture.Contains(search)||t.MCParentTitle.Contains(search)||t.MCMenuType.Contains(search)||t.MCDisplayName.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<MenuConfiguration>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【角色菜单】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class RoleMenuCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.RoleMenu.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【角色菜单】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【角色菜单】
    /// </summary>
    public partial class DeleteRoleMenuEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<RoleMenu>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.RoleMenu.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.RoleMenu.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条角色菜单记录";
    }
	
    /// <summary>
    /// 保存【角色菜单】
    /// </summary>
    public partial class SaveRoleMenuEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<RoleMenu>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.RoleMenu.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.RoleMenu.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.RMRoleName = HttpUtility.UrlDecode(entity.RMRoleName);
					// NVARCHAR(4000)
				entity.RMMenuTitle = HttpUtility.UrlDecode(entity.RMMenuTitle);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.RoleMenu.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条RoleMenu记录";
    }
	
    /// <summary>
    /// 查询空的【角色菜单】
    /// </summary>
    public partial class GetRoleMenuEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new RoleMenu();
        }
        public override string Comments=> "获取空的角色菜单记录";
    }
	
    /// <summary>
    /// 查询【角色菜单】列表
    /// </summary>
    public partial class GetRoleMenuListEvaluator : Evaluator
    {
        public override string Comments=> "获取RoleMenu列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<RoleMenuSearchModel>() ?? new RoleMenuSearchModel();
                var query = ctx.RoleMenu.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// RMRoleName NVARCHAR(50) 角色名称 
                if(!string.IsNullOrEmpty(searchModel.RMRoleName)) query = query.Where(t=>t.RMRoleName.Contains(searchModel.RMRoleName));
                if(sort=="RMRoleName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMRoleName):query.OrderByDescending(t=>t.RMRoleName);
                    isordered = true;
                }
				// RMMenuTitle NVARCHAR(4000) 菜单标题 
                if(!string.IsNullOrEmpty(searchModel.RMMenuTitle)) query = query.Where(t=>t.RMMenuTitle.Contains(searchModel.RMMenuTitle));
                if(sort=="RMMenuTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMMenuTitle):query.OrderByDescending(t=>t.RMMenuTitle);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.RMRoleName.Contains(search)||t.RMMenuTitle.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<RoleMenu>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【用户角色】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class UserRolesCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.UserRoles.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【用户角色】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【用户角色】
    /// </summary>
    public partial class DeleteUserRolesEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<UserRoles>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.UserRoles.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.UserRoles.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条用户角色记录";
    }
	
    /// <summary>
    /// 保存【用户角色】
    /// </summary>
    public partial class SaveUserRolesEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<UserRoles>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.UserRoles.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.UserRoles.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.URRoleName = HttpUtility.UrlDecode(entity.URRoleName);
					// NVARCHAR(50)
				entity.URLoginName = HttpUtility.UrlDecode(entity.URLoginName);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.UserRoles.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条UserRoles记录";
    }
	
    /// <summary>
    /// 查询空的【用户角色】
    /// </summary>
    public partial class GetUserRolesEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new UserRoles();
        }
        public override string Comments=> "获取空的用户角色记录";
    }
	
    /// <summary>
    /// 查询【用户角色】列表
    /// </summary>
    public partial class GetUserRolesListEvaluator : Evaluator
    {
        public override string Comments=> "获取UserRoles列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<UserRolesSearchModel>() ?? new UserRolesSearchModel();
                var query = ctx.UserRoles.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// URRoleName NVARCHAR(50) 角色名称 
                if(!string.IsNullOrEmpty(searchModel.URRoleName)) query = query.Where(t=>t.URRoleName.Contains(searchModel.URRoleName));
                if(sort=="URRoleName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.URRoleName):query.OrderByDescending(t=>t.URRoleName);
                    isordered = true;
                }
				// URLoginName NVARCHAR(50) 登录名 
                if(!string.IsNullOrEmpty(searchModel.URLoginName)) query = query.Where(t=>t.URLoginName.Contains(searchModel.URLoginName));
                if(sort=="URLoginName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.URLoginName):query.OrderByDescending(t=>t.URLoginName);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.URRoleName.Contains(search)||t.URLoginName.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<UserRoles>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【角色配置】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class RoleConfigurationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.RoleConfiguration.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【角色配置】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【角色配置】
    /// </summary>
    public partial class DeleteRoleConfigurationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<RoleConfiguration>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.RoleConfiguration.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.RoleConfiguration.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条角色配置记录";
    }
	
    /// <summary>
    /// 保存【角色配置】
    /// </summary>
    public partial class SaveRoleConfigurationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<RoleConfiguration>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.RoleConfiguration.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.RoleConfiguration.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.RCRoleName = HttpUtility.UrlDecode(entity.RCRoleName);
					// NVARCHAR(50)
				entity.RCAffiliatedOrganization = HttpUtility.UrlDecode(entity.RCAffiliatedOrganization);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.RoleConfiguration.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条RoleConfiguration记录";
    }
	
    /// <summary>
    /// 查询空的【角色配置】
    /// </summary>
    public partial class GetRoleConfigurationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new RoleConfiguration();
        }
        public override string Comments=> "获取空的角色配置记录";
    }
	
    /// <summary>
    /// 查询【角色配置】列表
    /// </summary>
    public partial class GetRoleConfigurationListEvaluator : Evaluator
    {
        public override string Comments=> "获取RoleConfiguration列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<RoleConfigurationSearchModel>() ?? new RoleConfigurationSearchModel();
                var query = ctx.RoleConfiguration.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// RCRoleName NVARCHAR(50) 角色名称 
                if(!string.IsNullOrEmpty(searchModel.RCRoleName)) query = query.Where(t=>t.RCRoleName.Contains(searchModel.RCRoleName));
                if(sort=="RCRoleName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRoleName):query.OrderByDescending(t=>t.RCRoleName);
                    isordered = true;
                }
				// RCAffiliatedOrganization NVARCHAR(50) 所属组织 
                if(!string.IsNullOrEmpty(searchModel.RCAffiliatedOrganization)) query = query.Where(t=>t.RCAffiliatedOrganization.Contains(searchModel.RCAffiliatedOrganization));
                if(sort=="RCAffiliatedOrganization")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCAffiliatedOrganization):query.OrderByDescending(t=>t.RCAffiliatedOrganization);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.RCRoleName.Contains(search)||t.RCAffiliatedOrganization.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<RoleConfiguration>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【用户信息】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class UserInformationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.UserInformation.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【用户信息】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【用户信息】
    /// </summary>
    public partial class DeleteUserInformationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<UserInformation>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.UserInformation.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.UserInformation.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条用户信息记录";
    }
	
    /// <summary>
    /// 保存【用户信息】
    /// </summary>
    public partial class SaveUserInformationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<UserInformation>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.UserInformation.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.UserInformation.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.UILoginName = HttpUtility.UrlDecode(entity.UILoginName);
					// NVARCHAR(50)
				entity.UIPassword = HttpUtility.UrlDecode(entity.UIPassword);
					// NVARCHAR(50)
				entity.UICustomerType = HttpUtility.UrlDecode(entity.UICustomerType);
					// NVARCHAR(50)
				entity.UIUserLevel = HttpUtility.UrlDecode(entity.UIUserLevel);
					// NVARCHAR(50)
				entity.UIState = HttpUtility.UrlDecode(entity.UIState);
					// NVARCHAR(50)
				entity.UINickname = HttpUtility.UrlDecode(entity.UINickname);
					// NVARCHAR(50)
				entity.UIRealName = HttpUtility.UrlDecode(entity.UIRealName);
					// NVARCHAR(4000)
				entity.UIHeadPortrait = HttpUtility.UrlDecode(entity.UIHeadPortrait);
					// NVARCHAR(50)
				entity.UISubordinateDepartments = HttpUtility.UrlDecode(entity.UISubordinateDepartments);
					// NVARCHAR(50)
				entity.UITelephone = HttpUtility.UrlDecode(entity.UITelephone);
					// NVARCHAR(4000)
				entity.UIPhoto = HttpUtility.UrlDecode(entity.UIPhoto);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.UserInformation.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条UserInformation记录";
    }
	
    /// <summary>
    /// 查询空的【用户信息】
    /// </summary>
    public partial class GetUserInformationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new UserInformation();
        }
        public override string Comments=> "获取空的用户信息记录";
    }
	
    /// <summary>
    /// 查询【用户信息】列表
    /// </summary>
    public partial class GetUserInformationListEvaluator : Evaluator
    {
        public override string Comments=> "获取UserInformation列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<UserInformationSearchModel>() ?? new UserInformationSearchModel();
                var query = ctx.UserInformation.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// UILoginName NVARCHAR(50) 登录名 
                if(!string.IsNullOrEmpty(searchModel.UILoginName)) query = query.Where(t=>t.UILoginName.Contains(searchModel.UILoginName));
                if(sort=="UILoginName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UILoginName):query.OrderByDescending(t=>t.UILoginName);
                    isordered = true;
                }
				// UIPassword NVARCHAR(50) 密码 
                if(!string.IsNullOrEmpty(searchModel.UIPassword)) query = query.Where(t=>t.UIPassword.Contains(searchModel.UIPassword));
                if(sort=="UIPassword")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UIPassword):query.OrderByDescending(t=>t.UIPassword);
                    isordered = true;
                }
				// UICustomerType NVARCHAR(50) 用户类型 
                if(!string.IsNullOrEmpty(searchModel.UICustomerType)) query = query.Where(t=>t.UICustomerType.Contains(searchModel.UICustomerType));
                if(sort=="UICustomerType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UICustomerType):query.OrderByDescending(t=>t.UICustomerType);
                    isordered = true;
                }
				// UIUserLevel NVARCHAR(50) 用户级别 
                if(!string.IsNullOrEmpty(searchModel.UIUserLevel)) query = query.Where(t=>t.UIUserLevel.Contains(searchModel.UIUserLevel));
                if(sort=="UIUserLevel")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UIUserLevel):query.OrderByDescending(t=>t.UIUserLevel);
                    isordered = true;
                }
				// UIState NVARCHAR(50) 状态 
                if(searchModel.UIState!=null && searchModel.UIState.Length!=0) query = query.Where(t=>searchModel.UIState.Contains(t.UIState));
                if(sort=="UIState")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UIState):query.OrderByDescending(t=>t.UIState);
                    isordered = true;
                }
				// UINickname NVARCHAR(50) 昵称 
                if(!string.IsNullOrEmpty(searchModel.UINickname)) query = query.Where(t=>t.UINickname.Contains(searchModel.UINickname));
                if(sort=="UINickname")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UINickname):query.OrderByDescending(t=>t.UINickname);
                    isordered = true;
                }
				// UIRealName NVARCHAR(50) 真实姓名 
                if(!string.IsNullOrEmpty(searchModel.UIRealName)) query = query.Where(t=>t.UIRealName.Contains(searchModel.UIRealName));
                if(sort=="UIRealName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UIRealName):query.OrderByDescending(t=>t.UIRealName);
                    isordered = true;
                }
				// UIHeadPortrait NVARCHAR(4000) 头像 
                if(!string.IsNullOrEmpty(searchModel.UIHeadPortrait)) query = query.Where(t=>t.UIHeadPortrait.Contains(searchModel.UIHeadPortrait));
                if(sort=="UIHeadPortrait")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UIHeadPortrait):query.OrderByDescending(t=>t.UIHeadPortrait);
                    isordered = true;
                }
				// UISubordinateDepartments NVARCHAR(50) 所属部门 
                if(!string.IsNullOrEmpty(searchModel.UISubordinateDepartments)) query = query.Where(t=>t.UISubordinateDepartments.Contains(searchModel.UISubordinateDepartments));
                if(sort=="UISubordinateDepartments")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UISubordinateDepartments):query.OrderByDescending(t=>t.UISubordinateDepartments);
                    isordered = true;
                }
				// UITelephone NVARCHAR(50) 电话 
                if(!string.IsNullOrEmpty(searchModel.UITelephone)) query = query.Where(t=>t.UITelephone.Contains(searchModel.UITelephone));
                if(sort=="UITelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UITelephone):query.OrderByDescending(t=>t.UITelephone);
                    isordered = true;
                }
				// UIPhoto NVARCHAR(4000) 照片 
                if(!string.IsNullOrEmpty(searchModel.UIPhoto)) query = query.Where(t=>t.UIPhoto.Contains(searchModel.UIPhoto));
                if(sort=="UIPhoto")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UIPhoto):query.OrderByDescending(t=>t.UIPhoto);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.UILoginName.Contains(search)||t.UIPassword.Contains(search)||t.UICustomerType.Contains(search)||t.UIUserLevel.Contains(search)||t.UIState.Contains(search)||t.UINickname.Contains(search)||t.UIRealName.Contains(search)||t.UIHeadPortrait.Contains(search)||t.UISubordinateDepartments.Contains(search)||t.UITelephone.Contains(search)||t.UIPhoto.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<UserInformation>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【登录记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class LoginRecordCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.LoginRecord.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【登录记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【登录记录】
    /// </summary>
    public partial class DeleteLoginRecordEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<LoginRecord>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.LoginRecord.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.LoginRecord.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条登录记录记录";
    }
	
    /// <summary>
    /// 保存【登录记录】
    /// </summary>
    public partial class SaveLoginRecordEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<LoginRecord>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.LoginRecord.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.LoginRecord.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.LRLoginName = HttpUtility.UrlDecode(entity.LRLoginName);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.LoginRecord.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条LoginRecord记录";
    }
	
    /// <summary>
    /// 查询空的【登录记录】
    /// </summary>
    public partial class GetLoginRecordEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new LoginRecord();
        }
        public override string Comments=> "获取空的登录记录记录";
    }
	
    /// <summary>
    /// 查询【登录记录】列表
    /// </summary>
    public partial class GetLoginRecordListEvaluator : Evaluator
    {
        public override string Comments=> "获取LoginRecord列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<LoginRecordSearchModel>() ?? new LoginRecordSearchModel();
                var query = ctx.LoginRecord.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// LRLoginName NVARCHAR(50) 登录名 
                if(!string.IsNullOrEmpty(searchModel.LRLoginName)) query = query.Where(t=>t.LRLoginName.Contains(searchModel.LRLoginName));
                if(sort=="LRLoginName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LRLoginName):query.OrderByDescending(t=>t.LRLoginName);
                    isordered = true;
                }
				// LRLoginTime DATETIME 登录时间 
                if(searchModel.FromLRLoginTime!=null) query = query.Where(t=>t.LRLoginTime>=searchModel.FromLRLoginTime);
                if(searchModel.ToLRLoginTime!=null) query = query.Where(t=>t.LRLoginTime<=searchModel.ToLRLoginTime);
                if(sort=="LRLoginTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LRLoginTime):query.OrderByDescending(t=>t.LRLoginTime);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.LRLoginName.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<LoginRecord>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【用户菜单】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class UserMenuCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.UserMenu.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【用户菜单】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【用户菜单】
    /// </summary>
    public partial class DeleteUserMenuEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<UserMenu>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.UserMenu.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.UserMenu.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条用户菜单记录";
    }
	
    /// <summary>
    /// 保存【用户菜单】
    /// </summary>
    public partial class SaveUserMenuEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<UserMenu>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.UserMenu.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.UserMenu.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.UMLoginName = HttpUtility.UrlDecode(entity.UMLoginName);
					// NVARCHAR(4000)
				entity.UMTitle = HttpUtility.UrlDecode(entity.UMTitle);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.UserMenu.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条UserMenu记录";
    }
	
    /// <summary>
    /// 查询空的【用户菜单】
    /// </summary>
    public partial class GetUserMenuEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new UserMenu();
        }
        public override string Comments=> "获取空的用户菜单记录";
    }
	
    /// <summary>
    /// 查询【用户菜单】列表
    /// </summary>
    public partial class GetUserMenuListEvaluator : Evaluator
    {
        public override string Comments=> "获取UserMenu列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<UserMenuSearchModel>() ?? new UserMenuSearchModel();
                var query = ctx.UserMenu.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// UMLoginName NVARCHAR(50) 登录名 
                if(!string.IsNullOrEmpty(searchModel.UMLoginName)) query = query.Where(t=>t.UMLoginName.Contains(searchModel.UMLoginName));
                if(sort=="UMLoginName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UMLoginName):query.OrderByDescending(t=>t.UMLoginName);
                    isordered = true;
                }
				// UMTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.UMTitle)) query = query.Where(t=>t.UMTitle.Contains(searchModel.UMTitle));
                if(sort=="UMTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UMTitle):query.OrderByDescending(t=>t.UMTitle);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.UMLoginName.Contains(search)||t.UMTitle.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<UserMenu>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党员信息管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class InformationManagementOfPartyMembersCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.InformationManagementOfPartyMembers.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党员信息管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党员信息管理】
    /// </summary>
    public partial class DeleteInformationManagementOfPartyMembersEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<InformationManagementOfPartyMembers>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.InformationManagementOfPartyMembers.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.InformationManagementOfPartyMembers.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党员信息管理记录";
    }
	
    /// <summary>
    /// 保存【党员信息管理】
    /// </summary>
    public partial class SaveInformationManagementOfPartyMembersEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<InformationManagementOfPartyMembers>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.InformationManagementOfPartyMembers.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.InformationManagementOfPartyMembers.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.IMOPMFullName = HttpUtility.UrlDecode(entity.IMOPMFullName);
					// NVARCHAR(4000)
				entity.IMOPMIdNumber = HttpUtility.UrlDecode(entity.IMOPMIdNumber);
					// NVARCHAR(50)
				entity.IMOPMGender = HttpUtility.UrlDecode(entity.IMOPMGender);
					// NVARCHAR(50)
				entity.IMOPMNation = HttpUtility.UrlDecode(entity.IMOPMNation);
					// NVARCHAR(50)
				entity.IMOPMEducation = HttpUtility.UrlDecode(entity.IMOPMEducation);
					// NVARCHAR(50)
				entity.IMOPMCategory = HttpUtility.UrlDecode(entity.IMOPMCategory);
					// NVARCHAR(50)
				entity.IMOPMPartyBranch = HttpUtility.UrlDecode(entity.IMOPMPartyBranch);
					// NVARCHAR(50)
				entity.IMOPMPost = HttpUtility.UrlDecode(entity.IMOPMPost);
					// NVARCHAR(50)
				entity.IMOPMContactNumber = HttpUtility.UrlDecode(entity.IMOPMContactNumber);
					// NVARCHAR(50)
				entity.IMOPMFamilyAddress = HttpUtility.UrlDecode(entity.IMOPMFamilyAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.InformationManagementOfPartyMembers.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条InformationManagementOfPartyMembers记录";
    }
	
    /// <summary>
    /// 查询空的【党员信息管理】
    /// </summary>
    public partial class GetInformationManagementOfPartyMembersEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new InformationManagementOfPartyMembers();
        }
        public override string Comments=> "获取空的党员信息管理记录";
    }
	
    /// <summary>
    /// 查询【党员信息管理】列表
    /// </summary>
    public partial class GetInformationManagementOfPartyMembersListEvaluator : Evaluator
    {
        public override string Comments=> "获取InformationManagementOfPartyMembers列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<InformationManagementOfPartyMembersSearchModel>() ?? new InformationManagementOfPartyMembersSearchModel();
                var query = ctx.InformationManagementOfPartyMembers.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// IMOPMFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.IMOPMFullName)) query = query.Where(t=>t.IMOPMFullName.Contains(searchModel.IMOPMFullName));
                if(sort=="IMOPMFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMFullName):query.OrderByDescending(t=>t.IMOPMFullName);
                    isordered = true;
                }
				// IMOPMIdNumber NVARCHAR(4000) 身份证号 
                if(!string.IsNullOrEmpty(searchModel.IMOPMIdNumber)) query = query.Where(t=>t.IMOPMIdNumber.Contains(searchModel.IMOPMIdNumber));
                if(sort=="IMOPMIdNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMIdNumber):query.OrderByDescending(t=>t.IMOPMIdNumber);
                    isordered = true;
                }
				// IMOPMDateOfBirth DATETIME 出生日期 
                if(searchModel.FromIMOPMDateOfBirth!=null) query = query.Where(t=>t.IMOPMDateOfBirth>=searchModel.FromIMOPMDateOfBirth);
                if(searchModel.ToIMOPMDateOfBirth!=null) query = query.Where(t=>t.IMOPMDateOfBirth<=searchModel.ToIMOPMDateOfBirth);
                if(sort=="IMOPMDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMDateOfBirth):query.OrderByDescending(t=>t.IMOPMDateOfBirth);
                    isordered = true;
                }
				// IMOPMGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.IMOPMGender)) query = query.Where(t=>t.IMOPMGender.Contains(searchModel.IMOPMGender));
                if(sort=="IMOPMGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMGender):query.OrderByDescending(t=>t.IMOPMGender);
                    isordered = true;
                }
				// IMOPMNation NVARCHAR(50) 民族 
                if(!string.IsNullOrEmpty(searchModel.IMOPMNation)) query = query.Where(t=>t.IMOPMNation.Contains(searchModel.IMOPMNation));
                if(sort=="IMOPMNation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMNation):query.OrderByDescending(t=>t.IMOPMNation);
                    isordered = true;
                }
				// IMOPMEducation NVARCHAR(50) 学历 
                if(!string.IsNullOrEmpty(searchModel.IMOPMEducation)) query = query.Where(t=>t.IMOPMEducation.Contains(searchModel.IMOPMEducation));
                if(sort=="IMOPMEducation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMEducation):query.OrderByDescending(t=>t.IMOPMEducation);
                    isordered = true;
                }
				// IMOPMCategory NVARCHAR(50) 类别 
                if(!string.IsNullOrEmpty(searchModel.IMOPMCategory)) query = query.Where(t=>t.IMOPMCategory.Contains(searchModel.IMOPMCategory));
                if(sort=="IMOPMCategory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMCategory):query.OrderByDescending(t=>t.IMOPMCategory);
                    isordered = true;
                }
				// IMOPMPartyBranch NVARCHAR(50) 所在党支部 
                if(!string.IsNullOrEmpty(searchModel.IMOPMPartyBranch)) query = query.Where(t=>t.IMOPMPartyBranch.Contains(searchModel.IMOPMPartyBranch));
                if(sort=="IMOPMPartyBranch")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMPartyBranch):query.OrderByDescending(t=>t.IMOPMPartyBranch);
                    isordered = true;
                }
				// IMOPMDateOfJoiningTheParty DATETIME 入党日期 
                if(searchModel.FromIMOPMDateOfJoiningTheParty!=null) query = query.Where(t=>t.IMOPMDateOfJoiningTheParty>=searchModel.FromIMOPMDateOfJoiningTheParty);
                if(searchModel.ToIMOPMDateOfJoiningTheParty!=null) query = query.Where(t=>t.IMOPMDateOfJoiningTheParty<=searchModel.ToIMOPMDateOfJoiningTheParty);
                if(sort=="IMOPMDateOfJoiningTheParty")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMDateOfJoiningTheParty):query.OrderByDescending(t=>t.IMOPMDateOfJoiningTheParty);
                    isordered = true;
                }
				// IMOPMDateOfCorrection DATETIME 转正日期 
                if(searchModel.FromIMOPMDateOfCorrection!=null) query = query.Where(t=>t.IMOPMDateOfCorrection>=searchModel.FromIMOPMDateOfCorrection);
                if(searchModel.ToIMOPMDateOfCorrection!=null) query = query.Where(t=>t.IMOPMDateOfCorrection<=searchModel.ToIMOPMDateOfCorrection);
                if(sort=="IMOPMDateOfCorrection")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMDateOfCorrection):query.OrderByDescending(t=>t.IMOPMDateOfCorrection);
                    isordered = true;
                }
				// IMOPMPost NVARCHAR(50) 工作岗位 
                if(!string.IsNullOrEmpty(searchModel.IMOPMPost)) query = query.Where(t=>t.IMOPMPost.Contains(searchModel.IMOPMPost));
                if(sort=="IMOPMPost")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMPost):query.OrderByDescending(t=>t.IMOPMPost);
                    isordered = true;
                }
				// IMOPMContactNumber NVARCHAR(50) 联系电话 
                if(!string.IsNullOrEmpty(searchModel.IMOPMContactNumber)) query = query.Where(t=>t.IMOPMContactNumber.Contains(searchModel.IMOPMContactNumber));
                if(sort=="IMOPMContactNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMContactNumber):query.OrderByDescending(t=>t.IMOPMContactNumber);
                    isordered = true;
                }
				// IMOPMFamilyAddress NVARCHAR(50) 家庭住址 
                if(!string.IsNullOrEmpty(searchModel.IMOPMFamilyAddress)) query = query.Where(t=>t.IMOPMFamilyAddress.Contains(searchModel.IMOPMFamilyAddress));
                if(sort=="IMOPMFamilyAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPMFamilyAddress):query.OrderByDescending(t=>t.IMOPMFamilyAddress);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.IMOPMFullName.Contains(search)||t.IMOPMIdNumber.Contains(search)||t.IMOPMGender.Contains(search)||t.IMOPMNation.Contains(search)||t.IMOPMEducation.Contains(search)||t.IMOPMCategory.Contains(search)||t.IMOPMPartyBranch.Contains(search)||t.IMOPMPost.Contains(search)||t.IMOPMContactNumber.Contains(search)||t.IMOPMFamilyAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<InformationManagementOfPartyMembers>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党费管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PartyFeeManagementCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.PartyFeeManagement.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党费管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党费管理】
    /// </summary>
    public partial class DeletePartyFeeManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<PartyFeeManagement>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.PartyFeeManagement.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.PartyFeeManagement.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党费管理记录";
    }
	
    /// <summary>
    /// 保存【党费管理】
    /// </summary>
    public partial class SavePartyFeeManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<PartyFeeManagement>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.PartyFeeManagement.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.PartyFeeManagement.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.PFMFullName = HttpUtility.UrlDecode(entity.PFMFullName);
					// NVARCHAR(4000)
				entity.PFMIdNumber = HttpUtility.UrlDecode(entity.PFMIdNumber);
					// NVARCHAR(50)
				entity.PFMPartyBranch = HttpUtility.UrlDecode(entity.PFMPartyBranch);
					// NVARCHAR(50)
				entity.PFMMonthlyIncome = HttpUtility.UrlDecode(entity.PFMMonthlyIncome);
					// NVARCHAR(50)
				entity.PFMMonthlyPartyMembershipFee = HttpUtility.UrlDecode(entity.PFMMonthlyPartyMembershipFee);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.PartyFeeManagement.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条PartyFeeManagement记录";
    }
	
    /// <summary>
    /// 查询空的【党费管理】
    /// </summary>
    public partial class GetPartyFeeManagementEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new PartyFeeManagement();
        }
        public override string Comments=> "获取空的党费管理记录";
    }
	
    /// <summary>
    /// 查询【党费管理】列表
    /// </summary>
    public partial class GetPartyFeeManagementListEvaluator : Evaluator
    {
        public override string Comments=> "获取PartyFeeManagement列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PartyFeeManagementSearchModel>() ?? new PartyFeeManagementSearchModel();
                var query = ctx.PartyFeeManagement.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PFMFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.PFMFullName)) query = query.Where(t=>t.PFMFullName.Contains(searchModel.PFMFullName));
                if(sort=="PFMFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PFMFullName):query.OrderByDescending(t=>t.PFMFullName);
                    isordered = true;
                }
				// PFMIdNumber NVARCHAR(4000) 身份证号 
                if(!string.IsNullOrEmpty(searchModel.PFMIdNumber)) query = query.Where(t=>t.PFMIdNumber.Contains(searchModel.PFMIdNumber));
                if(sort=="PFMIdNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PFMIdNumber):query.OrderByDescending(t=>t.PFMIdNumber);
                    isordered = true;
                }
				// PFMAge INT 年龄 
                if(searchModel.MinPFMAge!=null) query = query.Where(t=>t.PFMAge>=searchModel.MinPFMAge);
                if(searchModel.MaxPFMAge!=null) query = query.Where(t=>t.PFMAge<=searchModel.MaxPFMAge);
                if(sort=="PFMAge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PFMAge):query.OrderByDescending(t=>t.PFMAge);
                    isordered = true;
                }
				// PFMPartyBranch NVARCHAR(50) 所在党支部 
                if(!string.IsNullOrEmpty(searchModel.PFMPartyBranch)) query = query.Where(t=>t.PFMPartyBranch.Contains(searchModel.PFMPartyBranch));
                if(sort=="PFMPartyBranch")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PFMPartyBranch):query.OrderByDescending(t=>t.PFMPartyBranch);
                    isordered = true;
                }
				// PFMMonthlyIncome NVARCHAR(50) 月收入 
                if(!string.IsNullOrEmpty(searchModel.PFMMonthlyIncome)) query = query.Where(t=>t.PFMMonthlyIncome.Contains(searchModel.PFMMonthlyIncome));
                if(sort=="PFMMonthlyIncome")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PFMMonthlyIncome):query.OrderByDescending(t=>t.PFMMonthlyIncome);
                    isordered = true;
                }
				// PFMMonthlyPartyMembershipFee NVARCHAR(50) 月党费 
                if(!string.IsNullOrEmpty(searchModel.PFMMonthlyPartyMembershipFee)) query = query.Where(t=>t.PFMMonthlyPartyMembershipFee.Contains(searchModel.PFMMonthlyPartyMembershipFee));
                if(sort=="PFMMonthlyPartyMembershipFee")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PFMMonthlyPartyMembershipFee):query.OrderByDescending(t=>t.PFMMonthlyPartyMembershipFee);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PFMFullName.Contains(search)||t.PFMIdNumber.Contains(search)||t.PFMPartyBranch.Contains(search)||t.PFMMonthlyIncome.Contains(search)||t.PFMMonthlyPartyMembershipFee.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<PartyFeeManagement>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党课记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PartyRecordCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.PartyRecord.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党课记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党课记录】
    /// </summary>
    public partial class DeletePartyRecordEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<PartyRecord>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.PartyRecord.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.PartyRecord.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党课记录记录";
    }
	
    /// <summary>
    /// 保存【党课记录】
    /// </summary>
    public partial class SavePartyRecordEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<PartyRecord>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.PartyRecord.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.PartyRecord.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.PRFullName = HttpUtility.UrlDecode(entity.PRFullName);
					// NVARCHAR(4000)
				entity.PRIdCardNo = HttpUtility.UrlDecode(entity.PRIdCardNo);
					// NVARCHAR(50)
				entity.PRCourseTitle = HttpUtility.UrlDecode(entity.PRCourseTitle);
					// NVARCHAR(4000)
				entity.PRCourseSummary = HttpUtility.UrlDecode(entity.PRCourseSummary);
					// NVARCHAR(50)
				entity.PRLearningSituation = HttpUtility.UrlDecode(entity.PRLearningSituation);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.PartyRecord.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条PartyRecord记录";
    }
	
    /// <summary>
    /// 查询空的【党课记录】
    /// </summary>
    public partial class GetPartyRecordEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new PartyRecord();
        }
        public override string Comments=> "获取空的党课记录记录";
    }
	
    /// <summary>
    /// 查询【党课记录】列表
    /// </summary>
    public partial class GetPartyRecordListEvaluator : Evaluator
    {
        public override string Comments=> "获取PartyRecord列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PartyRecordSearchModel>() ?? new PartyRecordSearchModel();
                var query = ctx.PartyRecord.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PRFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.PRFullName)) query = query.Where(t=>t.PRFullName.Contains(searchModel.PRFullName));
                if(sort=="PRFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PRFullName):query.OrderByDescending(t=>t.PRFullName);
                    isordered = true;
                }
				// PRIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.PRIdCardNo)) query = query.Where(t=>t.PRIdCardNo.Contains(searchModel.PRIdCardNo));
                if(sort=="PRIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PRIdCardNo):query.OrderByDescending(t=>t.PRIdCardNo);
                    isordered = true;
                }
				// PRCourseTitle NVARCHAR(50) 课程名称 
                if(!string.IsNullOrEmpty(searchModel.PRCourseTitle)) query = query.Where(t=>t.PRCourseTitle.Contains(searchModel.PRCourseTitle));
                if(sort=="PRCourseTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PRCourseTitle):query.OrderByDescending(t=>t.PRCourseTitle);
                    isordered = true;
                }
				// PRCourseSummary NVARCHAR(4000) 课程摘要 
                if(!string.IsNullOrEmpty(searchModel.PRCourseSummary)) query = query.Where(t=>t.PRCourseSummary.Contains(searchModel.PRCourseSummary));
                if(sort=="PRCourseSummary")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PRCourseSummary):query.OrderByDescending(t=>t.PRCourseSummary);
                    isordered = true;
                }
				// PRLearningSituation NVARCHAR(50) 学习情况 
                if(!string.IsNullOrEmpty(searchModel.PRLearningSituation)) query = query.Where(t=>t.PRLearningSituation.Contains(searchModel.PRLearningSituation));
                if(sort=="PRLearningSituation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PRLearningSituation):query.OrderByDescending(t=>t.PRLearningSituation);
                    isordered = true;
                }
				// PRCourseTime DATETIME 课程时间 
                if(searchModel.FromPRCourseTime!=null) query = query.Where(t=>t.PRCourseTime>=searchModel.FromPRCourseTime);
                if(searchModel.ToPRCourseTime!=null) query = query.Where(t=>t.PRCourseTime<=searchModel.ToPRCourseTime);
                if(sort=="PRCourseTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PRCourseTime):query.OrderByDescending(t=>t.PRCourseTime);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PRFullName.Contains(search)||t.PRIdCardNo.Contains(search)||t.PRCourseTitle.Contains(search)||t.PRCourseSummary.Contains(search)||t.PRLearningSituation.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<PartyRecord>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【三会一课】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ThreeSessionsCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ThreeSessions.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【三会一课】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【三会一课】
    /// </summary>
    public partial class DeleteThreeSessionsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ThreeSessions>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ThreeSessions.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ThreeSessions.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条三会一课记录";
    }
	
    /// <summary>
    /// 保存【三会一课】
    /// </summary>
    public partial class SaveThreeSessionsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ThreeSessions>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ThreeSessions.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ThreeSessions.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.TSTheme = HttpUtility.UrlDecode(entity.TSTheme);
					// NVARCHAR(50)
				entity.TSParticipant = HttpUtility.UrlDecode(entity.TSParticipant);
					// NVARCHAR(50)
				entity.TSNumberOfParticipants = HttpUtility.UrlDecode(entity.TSNumberOfParticipants);
					// NVARCHAR(50)
				entity.TSHost = HttpUtility.UrlDecode(entity.TSHost);
					// NVARCHAR(4000)
				entity.TSContent = HttpUtility.UrlDecode(entity.TSContent);
					// NVARCHAR(50)
				entity.TSType = HttpUtility.UrlDecode(entity.TSType);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ThreeSessions.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ThreeSessions记录";
    }
	
    /// <summary>
    /// 查询空的【三会一课】
    /// </summary>
    public partial class GetThreeSessionsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ThreeSessions();
        }
        public override string Comments=> "获取空的三会一课记录";
    }
	
    /// <summary>
    /// 查询【三会一课】列表
    /// </summary>
    public partial class GetThreeSessionsListEvaluator : Evaluator
    {
        public override string Comments=> "获取ThreeSessions列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ThreeSessionsSearchModel>() ?? new ThreeSessionsSearchModel();
                var query = ctx.ThreeSessions.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// TSDate DATETIME 日期 
                if(searchModel.FromTSDate!=null) query = query.Where(t=>t.TSDate>=searchModel.FromTSDate);
                if(searchModel.ToTSDate!=null) query = query.Where(t=>t.TSDate<=searchModel.ToTSDate);
                if(sort=="TSDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TSDate):query.OrderByDescending(t=>t.TSDate);
                    isordered = true;
                }
				// TSTheme NVARCHAR(50) 主题 
                if(!string.IsNullOrEmpty(searchModel.TSTheme)) query = query.Where(t=>t.TSTheme.Contains(searchModel.TSTheme));
                if(sort=="TSTheme")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TSTheme):query.OrderByDescending(t=>t.TSTheme);
                    isordered = true;
                }
				// TSParticipant NVARCHAR(50) 参与人员 
                if(!string.IsNullOrEmpty(searchModel.TSParticipant)) query = query.Where(t=>t.TSParticipant.Contains(searchModel.TSParticipant));
                if(sort=="TSParticipant")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TSParticipant):query.OrderByDescending(t=>t.TSParticipant);
                    isordered = true;
                }
				// TSNumberOfParticipants NVARCHAR(50) 与会人数 
                if(!string.IsNullOrEmpty(searchModel.TSNumberOfParticipants)) query = query.Where(t=>t.TSNumberOfParticipants.Contains(searchModel.TSNumberOfParticipants));
                if(sort=="TSNumberOfParticipants")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TSNumberOfParticipants):query.OrderByDescending(t=>t.TSNumberOfParticipants);
                    isordered = true;
                }
				// TSHost NVARCHAR(50) 主持人 
                if(!string.IsNullOrEmpty(searchModel.TSHost)) query = query.Where(t=>t.TSHost.Contains(searchModel.TSHost));
                if(sort=="TSHost")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TSHost):query.OrderByDescending(t=>t.TSHost);
                    isordered = true;
                }
				// TSContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.TSContent)) query = query.Where(t=>t.TSContent.Contains(searchModel.TSContent));
                if(sort=="TSContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TSContent):query.OrderByDescending(t=>t.TSContent);
                    isordered = true;
                }
				// TSType NVARCHAR(50) 类型 
                if(!string.IsNullOrEmpty(searchModel.TSType)) query = query.Where(t=>t.TSType.Contains(searchModel.TSType));
                if(sort=="TSType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TSType):query.OrderByDescending(t=>t.TSType);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.TSTheme.Contains(search)||t.TSParticipant.Contains(search)||t.TSNumberOfParticipants.Contains(search)||t.TSHost.Contains(search)||t.TSContent.Contains(search)||t.TSType.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ThreeSessions>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【专题学习】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ThematicLearningCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ThematicLearning.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【专题学习】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【专题学习】
    /// </summary>
    public partial class DeleteThematicLearningEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ThematicLearning>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ThematicLearning.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ThematicLearning.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条专题学习记录";
    }
	
    /// <summary>
    /// 保存【专题学习】
    /// </summary>
    public partial class SaveThematicLearningEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ThematicLearning>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ThematicLearning.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ThematicLearning.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.TLThematicContent = HttpUtility.UrlDecode(entity.TLThematicContent);
					// NVARCHAR(50)
				entity.TLParticipant = HttpUtility.UrlDecode(entity.TLParticipant);
					// NVARCHAR(50)
				entity.TLNumberOfParticipants = HttpUtility.UrlDecode(entity.TLNumberOfParticipants);
					// NVARCHAR(50)
				entity.TLHost = HttpUtility.UrlDecode(entity.TLHost);
					// NVARCHAR(4000)
				entity.TLContent = HttpUtility.UrlDecode(entity.TLContent);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ThematicLearning.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ThematicLearning记录";
    }
	
    /// <summary>
    /// 查询空的【专题学习】
    /// </summary>
    public partial class GetThematicLearningEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ThematicLearning();
        }
        public override string Comments=> "获取空的专题学习记录";
    }
	
    /// <summary>
    /// 查询【专题学习】列表
    /// </summary>
    public partial class GetThematicLearningListEvaluator : Evaluator
    {
        public override string Comments=> "获取ThematicLearning列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ThematicLearningSearchModel>() ?? new ThematicLearningSearchModel();
                var query = ctx.ThematicLearning.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// TLDate DATETIME 日期 
                if(searchModel.FromTLDate!=null) query = query.Where(t=>t.TLDate>=searchModel.FromTLDate);
                if(searchModel.ToTLDate!=null) query = query.Where(t=>t.TLDate<=searchModel.ToTLDate);
                if(sort=="TLDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TLDate):query.OrderByDescending(t=>t.TLDate);
                    isordered = true;
                }
				// TLThematicContent NVARCHAR(4000) 专题内容 
                if(!string.IsNullOrEmpty(searchModel.TLThematicContent)) query = query.Where(t=>t.TLThematicContent.Contains(searchModel.TLThematicContent));
                if(sort=="TLThematicContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TLThematicContent):query.OrderByDescending(t=>t.TLThematicContent);
                    isordered = true;
                }
				// TLParticipant NVARCHAR(50) 参与人员 
                if(!string.IsNullOrEmpty(searchModel.TLParticipant)) query = query.Where(t=>t.TLParticipant.Contains(searchModel.TLParticipant));
                if(sort=="TLParticipant")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TLParticipant):query.OrderByDescending(t=>t.TLParticipant);
                    isordered = true;
                }
				// TLNumberOfParticipants NVARCHAR(50) 与会人数 
                if(!string.IsNullOrEmpty(searchModel.TLNumberOfParticipants)) query = query.Where(t=>t.TLNumberOfParticipants.Contains(searchModel.TLNumberOfParticipants));
                if(sort=="TLNumberOfParticipants")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TLNumberOfParticipants):query.OrderByDescending(t=>t.TLNumberOfParticipants);
                    isordered = true;
                }
				// TLHost NVARCHAR(50) 主持人 
                if(!string.IsNullOrEmpty(searchModel.TLHost)) query = query.Where(t=>t.TLHost.Contains(searchModel.TLHost));
                if(sort=="TLHost")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TLHost):query.OrderByDescending(t=>t.TLHost);
                    isordered = true;
                }
				// TLContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.TLContent)) query = query.Where(t=>t.TLContent.Contains(searchModel.TLContent));
                if(sort=="TLContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TLContent):query.OrderByDescending(t=>t.TLContent);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.TLThematicContent.Contains(search)||t.TLParticipant.Contains(search)||t.TLNumberOfParticipants.Contains(search)||t.TLHost.Contains(search)||t.TLContent.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ThematicLearning>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【政策文件】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PolicyDocumentCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.PolicyDocument.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【政策文件】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【政策文件】
    /// </summary>
    public partial class DeletePolicyDocumentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<PolicyDocument>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.PolicyDocument.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.PolicyDocument.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条政策文件记录";
    }
	
    /// <summary>
    /// 保存【政策文件】
    /// </summary>
    public partial class SavePolicyDocumentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<PolicyDocument>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.PolicyDocument.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.PolicyDocument.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.PDFileNumber = HttpUtility.UrlDecode(entity.PDFileNumber);
					// NVARCHAR(50)
				entity.PDCategoriesOfPolicyDocuments = HttpUtility.UrlDecode(entity.PDCategoriesOfPolicyDocuments);
					// NVARCHAR(50)
				entity.PDThemeOfSpecialDocument = HttpUtility.UrlDecode(entity.PDThemeOfSpecialDocument);
					// NVARCHAR(4000)
				entity.PDContent = HttpUtility.UrlDecode(entity.PDContent);
					// NVARCHAR(4000)
				entity.PDUploadFiles = HttpUtility.UrlDecode(entity.PDUploadFiles);
					// NVARCHAR(50)
				entity.PDParticularYear = HttpUtility.UrlDecode(entity.PDParticularYear);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.PolicyDocument.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条PolicyDocument记录";
    }
	
    /// <summary>
    /// 查询空的【政策文件】
    /// </summary>
    public partial class GetPolicyDocumentEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new PolicyDocument();
        }
        public override string Comments=> "获取空的政策文件记录";
    }
	
    /// <summary>
    /// 查询【政策文件】列表
    /// </summary>
    public partial class GetPolicyDocumentListEvaluator : Evaluator
    {
        public override string Comments=> "获取PolicyDocument列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PolicyDocumentSearchModel>() ?? new PolicyDocumentSearchModel();
                var query = ctx.PolicyDocument.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PDFileNumber NVARCHAR(50) 文件号 
                if(!string.IsNullOrEmpty(searchModel.PDFileNumber)) query = query.Where(t=>t.PDFileNumber.Contains(searchModel.PDFileNumber));
                if(sort=="PDFileNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PDFileNumber):query.OrderByDescending(t=>t.PDFileNumber);
                    isordered = true;
                }
				// PDCategoriesOfPolicyDocuments NVARCHAR(50) @政策文件类别 
                if(!string.IsNullOrEmpty(searchModel.PDCategoriesOfPolicyDocuments)) query = query.Where(t=>t.PDCategoriesOfPolicyDocuments.Contains(searchModel.PDCategoriesOfPolicyDocuments));
                if(sort=="PDCategoriesOfPolicyDocuments")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PDCategoriesOfPolicyDocuments):query.OrderByDescending(t=>t.PDCategoriesOfPolicyDocuments);
                    isordered = true;
                }
				// PDThemeOfSpecialDocument NVARCHAR(50) 专文件主题 
                if(!string.IsNullOrEmpty(searchModel.PDThemeOfSpecialDocument)) query = query.Where(t=>t.PDThemeOfSpecialDocument.Contains(searchModel.PDThemeOfSpecialDocument));
                if(sort=="PDThemeOfSpecialDocument")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PDThemeOfSpecialDocument):query.OrderByDescending(t=>t.PDThemeOfSpecialDocument);
                    isordered = true;
                }
				// PDContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.PDContent)) query = query.Where(t=>t.PDContent.Contains(searchModel.PDContent));
                if(sort=="PDContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PDContent):query.OrderByDescending(t=>t.PDContent);
                    isordered = true;
                }
				// PDUploadFiles NVARCHAR(4000) 上传文件 
                if(!string.IsNullOrEmpty(searchModel.PDUploadFiles)) query = query.Where(t=>t.PDUploadFiles.Contains(searchModel.PDUploadFiles));
                if(sort=="PDUploadFiles")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PDUploadFiles):query.OrderByDescending(t=>t.PDUploadFiles);
                    isordered = true;
                }
				// PDParticularYear NVARCHAR(50) 年份 
                if(!string.IsNullOrEmpty(searchModel.PDParticularYear)) query = query.Where(t=>t.PDParticularYear.Contains(searchModel.PDParticularYear));
                if(sort=="PDParticularYear")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PDParticularYear):query.OrderByDescending(t=>t.PDParticularYear);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PDFileNumber.Contains(search)||t.PDCategoriesOfPolicyDocuments.Contains(search)||t.PDThemeOfSpecialDocument.Contains(search)||t.PDContent.Contains(search)||t.PDUploadFiles.Contains(search)||t.PDParticularYear.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<PolicyDocument>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【政策文件类别】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class CategoriesOfPolicyDocumentsCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.CategoriesOfPolicyDocuments.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【政策文件类别】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【政策文件类别】
    /// </summary>
    public partial class DeleteCategoriesOfPolicyDocumentsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<CategoriesOfPolicyDocuments>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.CategoriesOfPolicyDocuments.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.CategoriesOfPolicyDocuments.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条政策文件类别记录";
    }
	
    /// <summary>
    /// 保存【政策文件类别】
    /// </summary>
    public partial class SaveCategoriesOfPolicyDocumentsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<CategoriesOfPolicyDocuments>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.CategoriesOfPolicyDocuments.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.CategoriesOfPolicyDocuments.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.COPDCategoryName = HttpUtility.UrlDecode(entity.COPDCategoryName);
					// NVARCHAR(50)
				entity.COPDDescribe = HttpUtility.UrlDecode(entity.COPDDescribe);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.CategoriesOfPolicyDocuments.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条CategoriesOfPolicyDocuments记录";
    }
	
    /// <summary>
    /// 查询空的【政策文件类别】
    /// </summary>
    public partial class GetCategoriesOfPolicyDocumentsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new CategoriesOfPolicyDocuments();
        }
        public override string Comments=> "获取空的政策文件类别记录";
    }
	
    /// <summary>
    /// 查询【政策文件类别】列表
    /// </summary>
    public partial class GetCategoriesOfPolicyDocumentsListEvaluator : Evaluator
    {
        public override string Comments=> "获取CategoriesOfPolicyDocuments列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<CategoriesOfPolicyDocumentsSearchModel>() ?? new CategoriesOfPolicyDocumentsSearchModel();
                var query = ctx.CategoriesOfPolicyDocuments.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// COPDCategoryName NVARCHAR(50) 类别名称 
                if(!string.IsNullOrEmpty(searchModel.COPDCategoryName)) query = query.Where(t=>t.COPDCategoryName.Contains(searchModel.COPDCategoryName));
                if(sort=="COPDCategoryName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.COPDCategoryName):query.OrderByDescending(t=>t.COPDCategoryName);
                    isordered = true;
                }
				// COPDDescribe NVARCHAR(50) 描述 
                if(!string.IsNullOrEmpty(searchModel.COPDDescribe)) query = query.Where(t=>t.COPDDescribe.Contains(searchModel.COPDDescribe));
                if(sort=="COPDDescribe")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.COPDDescribe):query.OrderByDescending(t=>t.COPDDescribe);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.COPDCategoryName.Contains(search)||t.COPDDescribe.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<CategoriesOfPolicyDocuments>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【现役军人名单】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ListOfActiveServicemenCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ListOfActiveServicemen.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【现役军人名单】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【现役军人名单】
    /// </summary>
    public partial class DeleteListOfActiveServicemenEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ListOfActiveServicemen>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ListOfActiveServicemen.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ListOfActiveServicemen.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条现役军人名单记录";
    }
	
    /// <summary>
    /// 保存【现役军人名单】
    /// </summary>
    public partial class SaveListOfActiveServicemenEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ListOfActiveServicemen>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ListOfActiveServicemen.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ListOfActiveServicemen.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.LOASFullName = HttpUtility.UrlDecode(entity.LOASFullName);
					// NVARCHAR(50)
				entity.LOASNation = HttpUtility.UrlDecode(entity.LOASNation);
					// NVARCHAR(50)
				entity.LOASFamilyAddress = HttpUtility.UrlDecode(entity.LOASFamilyAddress);
					// NVARCHAR(4000)
				entity.LOASIdCardNo = HttpUtility.UrlDecode(entity.LOASIdCardNo);
					// NVARCHAR(50)
				entity.LOASContactInformation = HttpUtility.UrlDecode(entity.LOASContactInformation);
					// NVARCHAR(50)
				entity.LOASFamilySituation = HttpUtility.UrlDecode(entity.LOASFamilySituation);
					// NVARCHAR(4000)
				entity.LOASRemarks = HttpUtility.UrlDecode(entity.LOASRemarks);
					// NVARCHAR(50)
				entity.LOASGender = HttpUtility.UrlDecode(entity.LOASGender);
					// NVARCHAR(50)
				entity.LOASDateOfBirth = HttpUtility.UrlDecode(entity.LOASDateOfBirth);
					// NVARCHAR(50)
				entity.LOASDegreeOfEducation = HttpUtility.UrlDecode(entity.LOASDegreeOfEducation);
					// NVARCHAR(50)
				entity.LOASRegisteredResidence = HttpUtility.UrlDecode(entity.LOASRegisteredResidence);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ListOfActiveServicemen.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ListOfActiveServicemen记录";
    }
	
    /// <summary>
    /// 查询空的【现役军人名单】
    /// </summary>
    public partial class GetListOfActiveServicemenEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ListOfActiveServicemen();
        }
        public override string Comments=> "获取空的现役军人名单记录";
    }
	
    /// <summary>
    /// 查询【现役军人名单】列表
    /// </summary>
    public partial class GetListOfActiveServicemenListEvaluator : Evaluator
    {
        public override string Comments=> "获取ListOfActiveServicemen列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ListOfActiveServicemenSearchModel>() ?? new ListOfActiveServicemenSearchModel();
                var query = ctx.ListOfActiveServicemen.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// LOASFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.LOASFullName)) query = query.Where(t=>t.LOASFullName.Contains(searchModel.LOASFullName));
                if(sort=="LOASFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASFullName):query.OrderByDescending(t=>t.LOASFullName);
                    isordered = true;
                }
				// LOASNation NVARCHAR(50) 民族 
                if(!string.IsNullOrEmpty(searchModel.LOASNation)) query = query.Where(t=>t.LOASNation.Contains(searchModel.LOASNation));
                if(sort=="LOASNation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASNation):query.OrderByDescending(t=>t.LOASNation);
                    isordered = true;
                }
				// LOASFamilyAddress NVARCHAR(50) 家庭住址 
                if(!string.IsNullOrEmpty(searchModel.LOASFamilyAddress)) query = query.Where(t=>t.LOASFamilyAddress.Contains(searchModel.LOASFamilyAddress));
                if(sort=="LOASFamilyAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASFamilyAddress):query.OrderByDescending(t=>t.LOASFamilyAddress);
                    isordered = true;
                }
				// LOASIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.LOASIdCardNo)) query = query.Where(t=>t.LOASIdCardNo.Contains(searchModel.LOASIdCardNo));
                if(sort=="LOASIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASIdCardNo):query.OrderByDescending(t=>t.LOASIdCardNo);
                    isordered = true;
                }
				// LOASContactInformation NVARCHAR(50) 联系方式 
                if(!string.IsNullOrEmpty(searchModel.LOASContactInformation)) query = query.Where(t=>t.LOASContactInformation.Contains(searchModel.LOASContactInformation));
                if(sort=="LOASContactInformation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASContactInformation):query.OrderByDescending(t=>t.LOASContactInformation);
                    isordered = true;
                }
				// LOASFamilySituation NVARCHAR(50) 家庭情况 
                if(!string.IsNullOrEmpty(searchModel.LOASFamilySituation)) query = query.Where(t=>t.LOASFamilySituation.Contains(searchModel.LOASFamilySituation));
                if(sort=="LOASFamilySituation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASFamilySituation):query.OrderByDescending(t=>t.LOASFamilySituation);
                    isordered = true;
                }
				// LOASRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.LOASRemarks)) query = query.Where(t=>t.LOASRemarks.Contains(searchModel.LOASRemarks));
                if(sort=="LOASRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASRemarks):query.OrderByDescending(t=>t.LOASRemarks);
                    isordered = true;
                }
				// LOASGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.LOASGender)) query = query.Where(t=>t.LOASGender.Contains(searchModel.LOASGender));
                if(sort=="LOASGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASGender):query.OrderByDescending(t=>t.LOASGender);
                    isordered = true;
                }
				// LOASDateOfBirth NVARCHAR(50) 出生年月 
                if(!string.IsNullOrEmpty(searchModel.LOASDateOfBirth)) query = query.Where(t=>t.LOASDateOfBirth.Contains(searchModel.LOASDateOfBirth));
                if(sort=="LOASDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASDateOfBirth):query.OrderByDescending(t=>t.LOASDateOfBirth);
                    isordered = true;
                }
				// LOASDegreeOfEducation NVARCHAR(50) 文化程度 
                if(!string.IsNullOrEmpty(searchModel.LOASDegreeOfEducation)) query = query.Where(t=>t.LOASDegreeOfEducation.Contains(searchModel.LOASDegreeOfEducation));
                if(sort=="LOASDegreeOfEducation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASDegreeOfEducation):query.OrderByDescending(t=>t.LOASDegreeOfEducation);
                    isordered = true;
                }
				// LOASRegisteredResidence NVARCHAR(50) 户口所在地 
                if(!string.IsNullOrEmpty(searchModel.LOASRegisteredResidence)) query = query.Where(t=>t.LOASRegisteredResidence.Contains(searchModel.LOASRegisteredResidence));
                if(sort=="LOASRegisteredResidence")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOASRegisteredResidence):query.OrderByDescending(t=>t.LOASRegisteredResidence);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.LOASFullName.Contains(search)||t.LOASNation.Contains(search)||t.LOASFamilyAddress.Contains(search)||t.LOASIdCardNo.Contains(search)||t.LOASContactInformation.Contains(search)||t.LOASFamilySituation.Contains(search)||t.LOASRemarks.Contains(search)||t.LOASGender.Contains(search)||t.LOASDateOfBirth.Contains(search)||t.LOASDegreeOfEducation.Contains(search)||t.LOASRegisteredResidence.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ListOfActiveServicemen>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【征兵对象名单】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ListOfConscriptsCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ListOfConscripts.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【征兵对象名单】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【征兵对象名单】
    /// </summary>
    public partial class DeleteListOfConscriptsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ListOfConscripts>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ListOfConscripts.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ListOfConscripts.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条征兵对象名单记录";
    }
	
    /// <summary>
    /// 保存【征兵对象名单】
    /// </summary>
    public partial class SaveListOfConscriptsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ListOfConscripts>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ListOfConscripts.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ListOfConscripts.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.LOCFullName = HttpUtility.UrlDecode(entity.LOCFullName);
					// NVARCHAR(50)
				entity.LOCDateOfBirth = HttpUtility.UrlDecode(entity.LOCDateOfBirth);
					// NVARCHAR(50)
				entity.LOCDegreeOfEducation = HttpUtility.UrlDecode(entity.LOCDegreeOfEducation);
					// NVARCHAR(50)
				entity.LOCPoliticalOutlook = HttpUtility.UrlDecode(entity.LOCPoliticalOutlook);
					// NVARCHAR(50)
				entity.LOCAccountCharacter = HttpUtility.UrlDecode(entity.LOCAccountCharacter);
					// NVARCHAR(50)
				entity.LOCUniversityOneIsGraduatedFrom = HttpUtility.UrlDecode(entity.LOCUniversityOneIsGraduatedFrom);
					// NVARCHAR(50)
				entity.LOCContactInformation = HttpUtility.UrlDecode(entity.LOCContactInformation);
					// NVARCHAR(4000)
				entity.LOCIdCardNo = HttpUtility.UrlDecode(entity.LOCIdCardNo);
					// NVARCHAR(4000)
				entity.LOCRemarks = HttpUtility.UrlDecode(entity.LOCRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ListOfConscripts.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ListOfConscripts记录";
    }
	
    /// <summary>
    /// 查询空的【征兵对象名单】
    /// </summary>
    public partial class GetListOfConscriptsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ListOfConscripts();
        }
        public override string Comments=> "获取空的征兵对象名单记录";
    }
	
    /// <summary>
    /// 查询【征兵对象名单】列表
    /// </summary>
    public partial class GetListOfConscriptsListEvaluator : Evaluator
    {
        public override string Comments=> "获取ListOfConscripts列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ListOfConscriptsSearchModel>() ?? new ListOfConscriptsSearchModel();
                var query = ctx.ListOfConscripts.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// LOCFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.LOCFullName)) query = query.Where(t=>t.LOCFullName.Contains(searchModel.LOCFullName));
                if(sort=="LOCFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOCFullName):query.OrderByDescending(t=>t.LOCFullName);
                    isordered = true;
                }
				// LOCDateOfBirth NVARCHAR(50) 出生年月 
                if(!string.IsNullOrEmpty(searchModel.LOCDateOfBirth)) query = query.Where(t=>t.LOCDateOfBirth.Contains(searchModel.LOCDateOfBirth));
                if(sort=="LOCDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOCDateOfBirth):query.OrderByDescending(t=>t.LOCDateOfBirth);
                    isordered = true;
                }
				// LOCDegreeOfEducation NVARCHAR(50) 文化程度 
                if(!string.IsNullOrEmpty(searchModel.LOCDegreeOfEducation)) query = query.Where(t=>t.LOCDegreeOfEducation.Contains(searchModel.LOCDegreeOfEducation));
                if(sort=="LOCDegreeOfEducation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOCDegreeOfEducation):query.OrderByDescending(t=>t.LOCDegreeOfEducation);
                    isordered = true;
                }
				// LOCPoliticalOutlook NVARCHAR(50) 政治面貌 
                if(!string.IsNullOrEmpty(searchModel.LOCPoliticalOutlook)) query = query.Where(t=>t.LOCPoliticalOutlook.Contains(searchModel.LOCPoliticalOutlook));
                if(sort=="LOCPoliticalOutlook")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOCPoliticalOutlook):query.OrderByDescending(t=>t.LOCPoliticalOutlook);
                    isordered = true;
                }
				// LOCAccountCharacter NVARCHAR(50) 户口性质 
                if(!string.IsNullOrEmpty(searchModel.LOCAccountCharacter)) query = query.Where(t=>t.LOCAccountCharacter.Contains(searchModel.LOCAccountCharacter));
                if(sort=="LOCAccountCharacter")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOCAccountCharacter):query.OrderByDescending(t=>t.LOCAccountCharacter);
                    isordered = true;
                }
				// LOCUniversityOneIsGraduatedFrom NVARCHAR(50) 毕业院校 
                if(!string.IsNullOrEmpty(searchModel.LOCUniversityOneIsGraduatedFrom)) query = query.Where(t=>t.LOCUniversityOneIsGraduatedFrom.Contains(searchModel.LOCUniversityOneIsGraduatedFrom));
                if(sort=="LOCUniversityOneIsGraduatedFrom")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOCUniversityOneIsGraduatedFrom):query.OrderByDescending(t=>t.LOCUniversityOneIsGraduatedFrom);
                    isordered = true;
                }
				// LOCContactInformation NVARCHAR(50) 联系方式 
                if(!string.IsNullOrEmpty(searchModel.LOCContactInformation)) query = query.Where(t=>t.LOCContactInformation.Contains(searchModel.LOCContactInformation));
                if(sort=="LOCContactInformation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOCContactInformation):query.OrderByDescending(t=>t.LOCContactInformation);
                    isordered = true;
                }
				// LOCIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.LOCIdCardNo)) query = query.Where(t=>t.LOCIdCardNo.Contains(searchModel.LOCIdCardNo));
                if(sort=="LOCIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOCIdCardNo):query.OrderByDescending(t=>t.LOCIdCardNo);
                    isordered = true;
                }
				// LOCRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.LOCRemarks)) query = query.Where(t=>t.LOCRemarks.Contains(searchModel.LOCRemarks));
                if(sort=="LOCRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOCRemarks):query.OrderByDescending(t=>t.LOCRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.LOCFullName.Contains(search)||t.LOCDateOfBirth.Contains(search)||t.LOCDegreeOfEducation.Contains(search)||t.LOCPoliticalOutlook.Contains(search)||t.LOCAccountCharacter.Contains(search)||t.LOCUniversityOneIsGraduatedFrom.Contains(search)||t.LOCContactInformation.Contains(search)||t.LOCIdCardNo.Contains(search)||t.LOCRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ListOfConscripts>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【共青团】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class CommunistYouthLeagueCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.CommunistYouthLeague.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【共青团】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【共青团】
    /// </summary>
    public partial class DeleteCommunistYouthLeagueEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<CommunistYouthLeague>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.CommunistYouthLeague.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.CommunistYouthLeague.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条共青团记录";
    }
	
    /// <summary>
    /// 保存【共青团】
    /// </summary>
    public partial class SaveCommunistYouthLeagueEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<CommunistYouthLeague>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.CommunistYouthLeague.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.CommunistYouthLeague.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.CYLSerialNumber = HttpUtility.UrlDecode(entity.CYLSerialNumber);
					// NVARCHAR(50)
				entity.CYLFullName = HttpUtility.UrlDecode(entity.CYLFullName);
					// NVARCHAR(50)
				entity.CYLGender = HttpUtility.UrlDecode(entity.CYLGender);
					// NVARCHAR(50)
				entity.CYLDateOfBirth = HttpUtility.UrlDecode(entity.CYLDateOfBirth);
					// NVARCHAR(50)
				entity.CYLNativePlace = HttpUtility.UrlDecode(entity.CYLNativePlace);
					// NVARCHAR(50)
				entity.CYLEducation = HttpUtility.UrlDecode(entity.CYLEducation);
					// NVARCHAR(50)
				entity.CYLJoiningTheLeagueYear = HttpUtility.UrlDecode(entity.CYLJoiningTheLeagueYear);
					// NVARCHAR(4000)
				entity.CYLRemarks = HttpUtility.UrlDecode(entity.CYLRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.CommunistYouthLeague.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条CommunistYouthLeague记录";
    }
	
    /// <summary>
    /// 查询空的【共青团】
    /// </summary>
    public partial class GetCommunistYouthLeagueEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new CommunistYouthLeague();
        }
        public override string Comments=> "获取空的共青团记录";
    }
	
    /// <summary>
    /// 查询【共青团】列表
    /// </summary>
    public partial class GetCommunistYouthLeagueListEvaluator : Evaluator
    {
        public override string Comments=> "获取CommunistYouthLeague列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<CommunistYouthLeagueSearchModel>() ?? new CommunistYouthLeagueSearchModel();
                var query = ctx.CommunistYouthLeague.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// CYLSerialNumber NVARCHAR(50) 序号 
                if(!string.IsNullOrEmpty(searchModel.CYLSerialNumber)) query = query.Where(t=>t.CYLSerialNumber.Contains(searchModel.CYLSerialNumber));
                if(sort=="CYLSerialNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CYLSerialNumber):query.OrderByDescending(t=>t.CYLSerialNumber);
                    isordered = true;
                }
				// CYLFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.CYLFullName)) query = query.Where(t=>t.CYLFullName.Contains(searchModel.CYLFullName));
                if(sort=="CYLFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CYLFullName):query.OrderByDescending(t=>t.CYLFullName);
                    isordered = true;
                }
				// CYLGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.CYLGender)) query = query.Where(t=>t.CYLGender.Contains(searchModel.CYLGender));
                if(sort=="CYLGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CYLGender):query.OrderByDescending(t=>t.CYLGender);
                    isordered = true;
                }
				// CYLDateOfBirth NVARCHAR(50) 出生年月 
                if(!string.IsNullOrEmpty(searchModel.CYLDateOfBirth)) query = query.Where(t=>t.CYLDateOfBirth.Contains(searchModel.CYLDateOfBirth));
                if(sort=="CYLDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CYLDateOfBirth):query.OrderByDescending(t=>t.CYLDateOfBirth);
                    isordered = true;
                }
				// CYLVolunteerTime DATETIME 志愿时间 
                if(searchModel.FromCYLVolunteerTime!=null) query = query.Where(t=>t.CYLVolunteerTime>=searchModel.FromCYLVolunteerTime);
                if(searchModel.ToCYLVolunteerTime!=null) query = query.Where(t=>t.CYLVolunteerTime<=searchModel.ToCYLVolunteerTime);
                if(sort=="CYLVolunteerTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CYLVolunteerTime):query.OrderByDescending(t=>t.CYLVolunteerTime);
                    isordered = true;
                }
				// CYLNativePlace NVARCHAR(50) 籍贯 
                if(!string.IsNullOrEmpty(searchModel.CYLNativePlace)) query = query.Where(t=>t.CYLNativePlace.Contains(searchModel.CYLNativePlace));
                if(sort=="CYLNativePlace")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CYLNativePlace):query.OrderByDescending(t=>t.CYLNativePlace);
                    isordered = true;
                }
				// CYLEducation NVARCHAR(50) 学历 
                if(!string.IsNullOrEmpty(searchModel.CYLEducation)) query = query.Where(t=>t.CYLEducation.Contains(searchModel.CYLEducation));
                if(sort=="CYLEducation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CYLEducation):query.OrderByDescending(t=>t.CYLEducation);
                    isordered = true;
                }
				// CYLJoiningTheLeagueYear NVARCHAR(50) 入团年月 
                if(!string.IsNullOrEmpty(searchModel.CYLJoiningTheLeagueYear)) query = query.Where(t=>t.CYLJoiningTheLeagueYear.Contains(searchModel.CYLJoiningTheLeagueYear));
                if(sort=="CYLJoiningTheLeagueYear")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CYLJoiningTheLeagueYear):query.OrderByDescending(t=>t.CYLJoiningTheLeagueYear);
                    isordered = true;
                }
				// CYLRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.CYLRemarks)) query = query.Where(t=>t.CYLRemarks.Contains(searchModel.CYLRemarks));
                if(sort=="CYLRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CYLRemarks):query.OrderByDescending(t=>t.CYLRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.CYLSerialNumber.Contains(search)||t.CYLFullName.Contains(search)||t.CYLGender.Contains(search)||t.CYLDateOfBirth.Contains(search)||t.CYLNativePlace.Contains(search)||t.CYLEducation.Contains(search)||t.CYLJoiningTheLeagueYear.Contains(search)||t.CYLRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<CommunistYouthLeague>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【重点人员】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class KeyPersonnelCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.KeyPersonnel.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【重点人员】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【重点人员】
    /// </summary>
    public partial class DeleteKeyPersonnelEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<KeyPersonnel>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.KeyPersonnel.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.KeyPersonnel.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条重点人员记录";
    }
	
    /// <summary>
    /// 保存【重点人员】
    /// </summary>
    public partial class SaveKeyPersonnelEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<KeyPersonnel>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.KeyPersonnel.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.KeyPersonnel.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.KPSerialNumber = HttpUtility.UrlDecode(entity.KPSerialNumber);
					// NVARCHAR(50)
				entity.KPFullName = HttpUtility.UrlDecode(entity.KPFullName);
					// NVARCHAR(50)
				entity.KPGender = HttpUtility.UrlDecode(entity.KPGender);
					// NVARCHAR(50)
				entity.KPPlaceOfResidence = HttpUtility.UrlDecode(entity.KPPlaceOfResidence);
					// NVARCHAR(50)
				entity.KPDomicile = HttpUtility.UrlDecode(entity.KPDomicile);
					// NVARCHAR(50)
				entity.KPCause = HttpUtility.UrlDecode(entity.KPCause);
					// NVARCHAR(50)
				entity.KPCurrentState = HttpUtility.UrlDecode(entity.KPCurrentState);
					// NVARCHAR(50)
				entity.KPContactNumber = HttpUtility.UrlDecode(entity.KPContactNumber);
					// NVARCHAR(4000)
				entity.KPRemarks = HttpUtility.UrlDecode(entity.KPRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.KeyPersonnel.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条KeyPersonnel记录";
    }
	
    /// <summary>
    /// 查询空的【重点人员】
    /// </summary>
    public partial class GetKeyPersonnelEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new KeyPersonnel();
        }
        public override string Comments=> "获取空的重点人员记录";
    }
	
    /// <summary>
    /// 查询【重点人员】列表
    /// </summary>
    public partial class GetKeyPersonnelListEvaluator : Evaluator
    {
        public override string Comments=> "获取KeyPersonnel列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<KeyPersonnelSearchModel>() ?? new KeyPersonnelSearchModel();
                var query = ctx.KeyPersonnel.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// KPSerialNumber NVARCHAR(50) 序号 
                if(!string.IsNullOrEmpty(searchModel.KPSerialNumber)) query = query.Where(t=>t.KPSerialNumber.Contains(searchModel.KPSerialNumber));
                if(sort=="KPSerialNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.KPSerialNumber):query.OrderByDescending(t=>t.KPSerialNumber);
                    isordered = true;
                }
				// KPFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.KPFullName)) query = query.Where(t=>t.KPFullName.Contains(searchModel.KPFullName));
                if(sort=="KPFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.KPFullName):query.OrderByDescending(t=>t.KPFullName);
                    isordered = true;
                }
				// KPGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.KPGender)) query = query.Where(t=>t.KPGender.Contains(searchModel.KPGender));
                if(sort=="KPGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.KPGender):query.OrderByDescending(t=>t.KPGender);
                    isordered = true;
                }
				// KPPlaceOfResidence NVARCHAR(50) 居住地 
                if(!string.IsNullOrEmpty(searchModel.KPPlaceOfResidence)) query = query.Where(t=>t.KPPlaceOfResidence.Contains(searchModel.KPPlaceOfResidence));
                if(sort=="KPPlaceOfResidence")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.KPPlaceOfResidence):query.OrderByDescending(t=>t.KPPlaceOfResidence);
                    isordered = true;
                }
				// KPDomicile NVARCHAR(50) 户籍地 
                if(!string.IsNullOrEmpty(searchModel.KPDomicile)) query = query.Where(t=>t.KPDomicile.Contains(searchModel.KPDomicile));
                if(sort=="KPDomicile")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.KPDomicile):query.OrderByDescending(t=>t.KPDomicile);
                    isordered = true;
                }
				// KPCause NVARCHAR(50) 事由 
                if(!string.IsNullOrEmpty(searchModel.KPCause)) query = query.Where(t=>t.KPCause.Contains(searchModel.KPCause));
                if(sort=="KPCause")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.KPCause):query.OrderByDescending(t=>t.KPCause);
                    isordered = true;
                }
				// KPCurrentState NVARCHAR(50) 目前状态 
                if(searchModel.KPCurrentState!=null && searchModel.KPCurrentState.Length!=0) query = query.Where(t=>searchModel.KPCurrentState.Contains(t.KPCurrentState));
                if(sort=="KPCurrentState")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.KPCurrentState):query.OrderByDescending(t=>t.KPCurrentState);
                    isordered = true;
                }
				// KPContactNumber NVARCHAR(50) 联系电话 
                if(!string.IsNullOrEmpty(searchModel.KPContactNumber)) query = query.Where(t=>t.KPContactNumber.Contains(searchModel.KPContactNumber));
                if(sort=="KPContactNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.KPContactNumber):query.OrderByDescending(t=>t.KPContactNumber);
                    isordered = true;
                }
				// KPRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.KPRemarks)) query = query.Where(t=>t.KPRemarks.Contains(searchModel.KPRemarks));
                if(sort=="KPRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.KPRemarks):query.OrderByDescending(t=>t.KPRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.KPSerialNumber.Contains(search)||t.KPFullName.Contains(search)||t.KPGender.Contains(search)||t.KPPlaceOfResidence.Contains(search)||t.KPDomicile.Contains(search)||t.KPCause.Contains(search)||t.KPCurrentState.Contains(search)||t.KPContactNumber.Contains(search)||t.KPRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<KeyPersonnel>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【信访】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class LettersAndVisitsCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.LettersAndVisits.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【信访】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【信访】
    /// </summary>
    public partial class DeleteLettersAndVisitsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<LettersAndVisits>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.LettersAndVisits.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.LettersAndVisits.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条信访记录";
    }
	
    /// <summary>
    /// 保存【信访】
    /// </summary>
    public partial class SaveLettersAndVisitsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<LettersAndVisits>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.LettersAndVisits.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.LettersAndVisits.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.LAVSerialNumber = HttpUtility.UrlDecode(entity.LAVSerialNumber);
					// NVARCHAR(50)
				entity.LAVComplaints = HttpUtility.UrlDecode(entity.LAVComplaints);
					// NVARCHAR(50)
				entity.LAVPlaceOfComplaint = HttpUtility.UrlDecode(entity.LAVPlaceOfComplaint);
					// NVARCHAR(50)
				entity.LAVHandlingResult = HttpUtility.UrlDecode(entity.LAVHandlingResult);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.LettersAndVisits.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条LettersAndVisits记录";
    }
	
    /// <summary>
    /// 查询空的【信访】
    /// </summary>
    public partial class GetLettersAndVisitsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new LettersAndVisits();
        }
        public override string Comments=> "获取空的信访记录";
    }
	
    /// <summary>
    /// 查询【信访】列表
    /// </summary>
    public partial class GetLettersAndVisitsListEvaluator : Evaluator
    {
        public override string Comments=> "获取LettersAndVisits列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<LettersAndVisitsSearchModel>() ?? new LettersAndVisitsSearchModel();
                var query = ctx.LettersAndVisits.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// LAVSerialNumber NVARCHAR(50) 序号 
                if(!string.IsNullOrEmpty(searchModel.LAVSerialNumber)) query = query.Where(t=>t.LAVSerialNumber.Contains(searchModel.LAVSerialNumber));
                if(sort=="LAVSerialNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LAVSerialNumber):query.OrderByDescending(t=>t.LAVSerialNumber);
                    isordered = true;
                }
				// LAVComplaints NVARCHAR(50) 投诉事件 
                if(!string.IsNullOrEmpty(searchModel.LAVComplaints)) query = query.Where(t=>t.LAVComplaints.Contains(searchModel.LAVComplaints));
                if(sort=="LAVComplaints")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LAVComplaints):query.OrderByDescending(t=>t.LAVComplaints);
                    isordered = true;
                }
				// LAVPlaceOfComplaint NVARCHAR(50) 投诉地点 
                if(!string.IsNullOrEmpty(searchModel.LAVPlaceOfComplaint)) query = query.Where(t=>t.LAVPlaceOfComplaint.Contains(searchModel.LAVPlaceOfComplaint));
                if(sort=="LAVPlaceOfComplaint")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LAVPlaceOfComplaint):query.OrderByDescending(t=>t.LAVPlaceOfComplaint);
                    isordered = true;
                }
				// LAVHandlingResult NVARCHAR(50) 办理结果 
                if(!string.IsNullOrEmpty(searchModel.LAVHandlingResult)) query = query.Where(t=>t.LAVHandlingResult.Contains(searchModel.LAVHandlingResult));
                if(sort=="LAVHandlingResult")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LAVHandlingResult):query.OrderByDescending(t=>t.LAVHandlingResult);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.LAVSerialNumber.Contains(search)||t.LAVComplaints.Contains(search)||t.LAVPlaceOfComplaint.Contains(search)||t.LAVHandlingResult.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<LettersAndVisits>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【两类人员】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class TheTwoCategoryOfPersonnelCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.TheTwoCategoryOfPersonnel.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【两类人员】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【两类人员】
    /// </summary>
    public partial class DeleteTheTwoCategoryOfPersonnelEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<TheTwoCategoryOfPersonnel>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.TheTwoCategoryOfPersonnel.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.TheTwoCategoryOfPersonnel.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条两类人员记录";
    }
	
    /// <summary>
    /// 保存【两类人员】
    /// </summary>
    public partial class SaveTheTwoCategoryOfPersonnelEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<TheTwoCategoryOfPersonnel>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.TheTwoCategoryOfPersonnel.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.TheTwoCategoryOfPersonnel.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.TTCOPLocalCommunity = HttpUtility.UrlDecode(entity.TTCOPLocalCommunity);
					// NVARCHAR(50)
				entity.TTCOPFullName = HttpUtility.UrlDecode(entity.TTCOPFullName);
					// NVARCHAR(50)
				entity.TTCOPGender = HttpUtility.UrlDecode(entity.TTCOPGender);
					// NVARCHAR(4000)
				entity.TTCOPIdCardNo = HttpUtility.UrlDecode(entity.TTCOPIdCardNo);
					// NVARCHAR(50)
				entity.TTCOPCharge = HttpUtility.UrlDecode(entity.TTCOPCharge);
					// NVARCHAR(50)
				entity.TTCOPFamilyAddress = HttpUtility.UrlDecode(entity.TTCOPFamilyAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.TheTwoCategoryOfPersonnel.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条TheTwoCategoryOfPersonnel记录";
    }
	
    /// <summary>
    /// 查询空的【两类人员】
    /// </summary>
    public partial class GetTheTwoCategoryOfPersonnelEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new TheTwoCategoryOfPersonnel();
        }
        public override string Comments=> "获取空的两类人员记录";
    }
	
    /// <summary>
    /// 查询【两类人员】列表
    /// </summary>
    public partial class GetTheTwoCategoryOfPersonnelListEvaluator : Evaluator
    {
        public override string Comments=> "获取TheTwoCategoryOfPersonnel列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<TheTwoCategoryOfPersonnelSearchModel>() ?? new TheTwoCategoryOfPersonnelSearchModel();
                var query = ctx.TheTwoCategoryOfPersonnel.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// TTCOPLocalCommunity NVARCHAR(50) 所在社区 
                if(!string.IsNullOrEmpty(searchModel.TTCOPLocalCommunity)) query = query.Where(t=>t.TTCOPLocalCommunity.Contains(searchModel.TTCOPLocalCommunity));
                if(sort=="TTCOPLocalCommunity")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TTCOPLocalCommunity):query.OrderByDescending(t=>t.TTCOPLocalCommunity);
                    isordered = true;
                }
				// TTCOPFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.TTCOPFullName)) query = query.Where(t=>t.TTCOPFullName.Contains(searchModel.TTCOPFullName));
                if(sort=="TTCOPFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TTCOPFullName):query.OrderByDescending(t=>t.TTCOPFullName);
                    isordered = true;
                }
				// TTCOPGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.TTCOPGender)) query = query.Where(t=>t.TTCOPGender.Contains(searchModel.TTCOPGender));
                if(sort=="TTCOPGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TTCOPGender):query.OrderByDescending(t=>t.TTCOPGender);
                    isordered = true;
                }
				// TTCOPIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.TTCOPIdCardNo)) query = query.Where(t=>t.TTCOPIdCardNo.Contains(searchModel.TTCOPIdCardNo));
                if(sort=="TTCOPIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TTCOPIdCardNo):query.OrderByDescending(t=>t.TTCOPIdCardNo);
                    isordered = true;
                }
				// TTCOPCharge NVARCHAR(50) 罪名 
                if(!string.IsNullOrEmpty(searchModel.TTCOPCharge)) query = query.Where(t=>t.TTCOPCharge.Contains(searchModel.TTCOPCharge));
                if(sort=="TTCOPCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TTCOPCharge):query.OrderByDescending(t=>t.TTCOPCharge);
                    isordered = true;
                }
				// TTCOPFamilyAddress NVARCHAR(50) 家庭住址 
                if(!string.IsNullOrEmpty(searchModel.TTCOPFamilyAddress)) query = query.Where(t=>t.TTCOPFamilyAddress.Contains(searchModel.TTCOPFamilyAddress));
                if(sort=="TTCOPFamilyAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TTCOPFamilyAddress):query.OrderByDescending(t=>t.TTCOPFamilyAddress);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.TTCOPLocalCommunity.Contains(search)||t.TTCOPFullName.Contains(search)||t.TTCOPGender.Contains(search)||t.TTCOPIdCardNo.Contains(search)||t.TTCOPCharge.Contains(search)||t.TTCOPFamilyAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<TheTwoCategoryOfPersonnel>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【家庭】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class FamilyCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Family.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【家庭】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【家庭】
    /// </summary>
    public partial class DeleteFamilyEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Family>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Family.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Family.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条家庭记录";
    }
	
    /// <summary>
    /// 保存【家庭】
    /// </summary>
    public partial class SaveFamilyEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Family>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Family.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Family.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.FNameOfFamilyOrganization = HttpUtility.UrlDecode(entity.FNameOfFamilyOrganization);
					// NVARCHAR(50)
				entity.FFullName = HttpUtility.UrlDecode(entity.FFullName);
					// NVARCHAR(4000)
				entity.FIdCardNo = HttpUtility.UrlDecode(entity.FIdCardNo);
					// NVARCHAR(50)
				entity.FNameOfNewborn = HttpUtility.UrlDecode(entity.FNameOfNewborn);
					// NVARCHAR(50)
				entity.FDeathCertificate = HttpUtility.UrlDecode(entity.FDeathCertificate);
					// NVARCHAR(50)
				entity.FPlaceOfResidence = HttpUtility.UrlDecode(entity.FPlaceOfResidence);
					// NVARCHAR(50)
				entity.FContactInformation = HttpUtility.UrlDecode(entity.FContactInformation);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Family.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Family记录";
    }
	
    /// <summary>
    /// 查询空的【家庭】
    /// </summary>
    public partial class GetFamilyEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Family();
        }
        public override string Comments=> "获取空的家庭记录";
    }
	
    /// <summary>
    /// 查询【家庭】列表
    /// </summary>
    public partial class GetFamilyListEvaluator : Evaluator
    {
        public override string Comments=> "获取Family列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<FamilySearchModel>() ?? new FamilySearchModel();
                var query = ctx.Family.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// FNameOfFamilyOrganization NVARCHAR(50) 家庭组织名称 
                if(!string.IsNullOrEmpty(searchModel.FNameOfFamilyOrganization)) query = query.Where(t=>t.FNameOfFamilyOrganization.Contains(searchModel.FNameOfFamilyOrganization));
                if(sort=="FNameOfFamilyOrganization")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FNameOfFamilyOrganization):query.OrderByDescending(t=>t.FNameOfFamilyOrganization);
                    isordered = true;
                }
				// FFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.FFullName)) query = query.Where(t=>t.FFullName.Contains(searchModel.FFullName));
                if(sort=="FFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FFullName):query.OrderByDescending(t=>t.FFullName);
                    isordered = true;
                }
				// FIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.FIdCardNo)) query = query.Where(t=>t.FIdCardNo.Contains(searchModel.FIdCardNo));
                if(sort=="FIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FIdCardNo):query.OrderByDescending(t=>t.FIdCardNo);
                    isordered = true;
                }
				// FNameOfNewborn NVARCHAR(50) 新生儿姓名 
                if(!string.IsNullOrEmpty(searchModel.FNameOfNewborn)) query = query.Where(t=>t.FNameOfNewborn.Contains(searchModel.FNameOfNewborn));
                if(sort=="FNameOfNewborn")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FNameOfNewborn):query.OrderByDescending(t=>t.FNameOfNewborn);
                    isordered = true;
                }
				// FDeathCertificate NVARCHAR(50) 死亡证明 
                if(!string.IsNullOrEmpty(searchModel.FDeathCertificate)) query = query.Where(t=>t.FDeathCertificate.Contains(searchModel.FDeathCertificate));
                if(sort=="FDeathCertificate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FDeathCertificate):query.OrderByDescending(t=>t.FDeathCertificate);
                    isordered = true;
                }
				// FPlaceOfResidence NVARCHAR(50) 居住地 
                if(!string.IsNullOrEmpty(searchModel.FPlaceOfResidence)) query = query.Where(t=>t.FPlaceOfResidence.Contains(searchModel.FPlaceOfResidence));
                if(sort=="FPlaceOfResidence")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FPlaceOfResidence):query.OrderByDescending(t=>t.FPlaceOfResidence);
                    isordered = true;
                }
				// FContactInformation NVARCHAR(50) 联系方式 
                if(!string.IsNullOrEmpty(searchModel.FContactInformation)) query = query.Where(t=>t.FContactInformation.Contains(searchModel.FContactInformation));
                if(sort=="FContactInformation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FContactInformation):query.OrderByDescending(t=>t.FContactInformation);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.FNameOfFamilyOrganization.Contains(search)||t.FFullName.Contains(search)||t.FIdCardNo.Contains(search)||t.FNameOfNewborn.Contains(search)||t.FDeathCertificate.Contains(search)||t.FPlaceOfResidence.Contains(search)||t.FContactInformation.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Family>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【股民】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class InvestorsCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Investors.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【股民】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【股民】
    /// </summary>
    public partial class DeleteInvestorsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Investors>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Investors.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Investors.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条股民记录";
    }
	
    /// <summary>
    /// 保存【股民】
    /// </summary>
    public partial class SaveInvestorsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Investors>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Investors.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Investors.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.ISerialNumber = HttpUtility.UrlDecode(entity.ISerialNumber);
					// NVARCHAR(50)
				entity.IHouseholdNumber = HttpUtility.UrlDecode(entity.IHouseholdNumber);
					// NVARCHAR(50)
				entity.IEquityCertificateNumber = HttpUtility.UrlDecode(entity.IEquityCertificateNumber);
					// NVARCHAR(4000)
				entity.IIdCardNo = HttpUtility.UrlDecode(entity.IIdCardNo);
					// NVARCHAR(50)
				entity.IaHouseholder = HttpUtility.UrlDecode(entity.IaHouseholder);
					// NVARCHAR(50)
				entity.IFullName = HttpUtility.UrlDecode(entity.IFullName);
					// NVARCHAR(50)
				entity.IGender = HttpUtility.UrlDecode(entity.IGender);
					// NVARCHAR(50)
				entity.IDateOfBirth = HttpUtility.UrlDecode(entity.IDateOfBirth);
					// NVARCHAR(50)
				entity.IOneYearOld = HttpUtility.UrlDecode(entity.IOneYearOld);
					// NVARCHAR(50)
				entity.IBasicStock = HttpUtility.UrlDecode(entity.IBasicStock);
					// NVARCHAR(50)
				entity.IDeservedShare = HttpUtility.UrlDecode(entity.IDeservedShare);
					// NVARCHAR(50)
				entity.ITotalNumberOfSharesInaHousehold = HttpUtility.UrlDecode(entity.ITotalNumberOfSharesInaHousehold);
					// NVARCHAR(50)
				entity.IWitnessing = HttpUtility.UrlDecode(entity.IWitnessing);
					// NVARCHAR(4000)
				entity.IRightsIssue = HttpUtility.UrlDecode(entity.IRightsIssue);
					// NVARCHAR(50)
				entity.IStatisticalTopic1 = HttpUtility.UrlDecode(entity.IStatisticalTopic1);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Investors.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Investors记录";
    }
	
    /// <summary>
    /// 查询空的【股民】
    /// </summary>
    public partial class GetInvestorsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Investors();
        }
        public override string Comments=> "获取空的股民记录";
    }
	
    /// <summary>
    /// 查询【股民】列表
    /// </summary>
    public partial class GetInvestorsListEvaluator : Evaluator
    {
        public override string Comments=> "获取Investors列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<InvestorsSearchModel>() ?? new InvestorsSearchModel();
                var query = ctx.Investors.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// ISerialNumber NVARCHAR(50) 序号 
                if(!string.IsNullOrEmpty(searchModel.ISerialNumber)) query = query.Where(t=>t.ISerialNumber.Contains(searchModel.ISerialNumber));
                if(sort=="ISerialNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ISerialNumber):query.OrderByDescending(t=>t.ISerialNumber);
                    isordered = true;
                }
				// IHouseholdNumber NVARCHAR(50) 户编号 
                if(!string.IsNullOrEmpty(searchModel.IHouseholdNumber)) query = query.Where(t=>t.IHouseholdNumber.Contains(searchModel.IHouseholdNumber));
                if(sort=="IHouseholdNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IHouseholdNumber):query.OrderByDescending(t=>t.IHouseholdNumber);
                    isordered = true;
                }
				// IEquityCertificateNumber NVARCHAR(50) 股权证编号 
                if(!string.IsNullOrEmpty(searchModel.IEquityCertificateNumber)) query = query.Where(t=>t.IEquityCertificateNumber.Contains(searchModel.IEquityCertificateNumber));
                if(sort=="IEquityCertificateNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IEquityCertificateNumber):query.OrderByDescending(t=>t.IEquityCertificateNumber);
                    isordered = true;
                }
				// IIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.IIdCardNo)) query = query.Where(t=>t.IIdCardNo.Contains(searchModel.IIdCardNo));
                if(sort=="IIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IIdCardNo):query.OrderByDescending(t=>t.IIdCardNo);
                    isordered = true;
                }
				// IaHouseholder NVARCHAR(50) 户主 
                if(!string.IsNullOrEmpty(searchModel.IaHouseholder)) query = query.Where(t=>t.IaHouseholder.Contains(searchModel.IaHouseholder));
                if(sort=="IaHouseholder")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IaHouseholder):query.OrderByDescending(t=>t.IaHouseholder);
                    isordered = true;
                }
				// IFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.IFullName)) query = query.Where(t=>t.IFullName.Contains(searchModel.IFullName));
                if(sort=="IFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IFullName):query.OrderByDescending(t=>t.IFullName);
                    isordered = true;
                }
				// IGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.IGender)) query = query.Where(t=>t.IGender.Contains(searchModel.IGender));
                if(sort=="IGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IGender):query.OrderByDescending(t=>t.IGender);
                    isordered = true;
                }
				// IDateOfBirth NVARCHAR(50) 出生年月 
                if(!string.IsNullOrEmpty(searchModel.IDateOfBirth)) query = query.Where(t=>t.IDateOfBirth.Contains(searchModel.IDateOfBirth));
                if(sort=="IDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IDateOfBirth):query.OrderByDescending(t=>t.IDateOfBirth);
                    isordered = true;
                }
				// IOneYearOld NVARCHAR(50) 周岁 
                if(!string.IsNullOrEmpty(searchModel.IOneYearOld)) query = query.Where(t=>t.IOneYearOld.Contains(searchModel.IOneYearOld));
                if(sort=="IOneYearOld")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IOneYearOld):query.OrderByDescending(t=>t.IOneYearOld);
                    isordered = true;
                }
				// IBasicStock NVARCHAR(50) 基本股 
                if(!string.IsNullOrEmpty(searchModel.IBasicStock)) query = query.Where(t=>t.IBasicStock.Contains(searchModel.IBasicStock));
                if(sort=="IBasicStock")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IBasicStock):query.OrderByDescending(t=>t.IBasicStock);
                    isordered = true;
                }
				// IDeservedShare NVARCHAR(50) 应得股份股 
                if(!string.IsNullOrEmpty(searchModel.IDeservedShare)) query = query.Where(t=>t.IDeservedShare.Contains(searchModel.IDeservedShare));
                if(sort=="IDeservedShare")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IDeservedShare):query.OrderByDescending(t=>t.IDeservedShare);
                    isordered = true;
                }
				// ITotalNumberOfSharesInaHousehold NVARCHAR(50) 户合计股数 
                if(!string.IsNullOrEmpty(searchModel.ITotalNumberOfSharesInaHousehold)) query = query.Where(t=>t.ITotalNumberOfSharesInaHousehold.Contains(searchModel.ITotalNumberOfSharesInaHousehold));
                if(sort=="ITotalNumberOfSharesInaHousehold")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ITotalNumberOfSharesInaHousehold):query.OrderByDescending(t=>t.ITotalNumberOfSharesInaHousehold);
                    isordered = true;
                }
				// IWitnessing NVARCHAR(50) 确认签名 
                if(!string.IsNullOrEmpty(searchModel.IWitnessing)) query = query.Where(t=>t.IWitnessing.Contains(searchModel.IWitnessing));
                if(sort=="IWitnessing")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IWitnessing):query.OrderByDescending(t=>t.IWitnessing);
                    isordered = true;
                }
				// IRightsIssue NVARCHAR(4000) 配股说明 
                if(!string.IsNullOrEmpty(searchModel.IRightsIssue)) query = query.Where(t=>t.IRightsIssue.Contains(searchModel.IRightsIssue));
                if(sort=="IRightsIssue")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IRightsIssue):query.OrderByDescending(t=>t.IRightsIssue);
                    isordered = true;
                }
				// IStatisticalTopic1 NVARCHAR(50) 统计主题1 
                if(!string.IsNullOrEmpty(searchModel.IStatisticalTopic1)) query = query.Where(t=>t.IStatisticalTopic1.Contains(searchModel.IStatisticalTopic1));
                if(sort=="IStatisticalTopic1")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IStatisticalTopic1):query.OrderByDescending(t=>t.IStatisticalTopic1);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.ISerialNumber.Contains(search)||t.IHouseholdNumber.Contains(search)||t.IEquityCertificateNumber.Contains(search)||t.IIdCardNo.Contains(search)||t.IaHouseholder.Contains(search)||t.IFullName.Contains(search)||t.IGender.Contains(search)||t.IDateOfBirth.Contains(search)||t.IOneYearOld.Contains(search)||t.IBasicStock.Contains(search)||t.IDeservedShare.Contains(search)||t.ITotalNumberOfSharesInaHousehold.Contains(search)||t.IWitnessing.Contains(search)||t.IRightsIssue.Contains(search)||t.IStatisticalTopic1.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Investors>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【分红记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class BonusRecordCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.BonusRecord.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【分红记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【分红记录】
    /// </summary>
    public partial class DeleteBonusRecordEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<BonusRecord>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.BonusRecord.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.BonusRecord.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条分红记录记录";
    }
	
    /// <summary>
    /// 保存【分红记录】
    /// </summary>
    public partial class SaveBonusRecordEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<BonusRecord>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.BonusRecord.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.BonusRecord.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.BRFullName = HttpUtility.UrlDecode(entity.BRFullName);
					// NVARCHAR(4000)
				entity.BRIdCardNo = HttpUtility.UrlDecode(entity.BRIdCardNo);
					// NVARCHAR(50)
				entity.BRShareType = HttpUtility.UrlDecode(entity.BRShareType);
					// NVARCHAR(50)
				entity.BRShareRatio = HttpUtility.UrlDecode(entity.BRShareRatio);
					// NVARCHAR(50)
				entity.BRPersonInCharge = HttpUtility.UrlDecode(entity.BRPersonInCharge);
					// NVARCHAR(50)
				entity.BRContactInformationOfPersonInCharge = HttpUtility.UrlDecode(entity.BRContactInformationOfPersonInCharge);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.BonusRecord.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条BonusRecord记录";
    }
	
    /// <summary>
    /// 查询空的【分红记录】
    /// </summary>
    public partial class GetBonusRecordEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new BonusRecord();
        }
        public override string Comments=> "获取空的分红记录记录";
    }
	
    /// <summary>
    /// 查询【分红记录】列表
    /// </summary>
    public partial class GetBonusRecordListEvaluator : Evaluator
    {
        public override string Comments=> "获取BonusRecord列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<BonusRecordSearchModel>() ?? new BonusRecordSearchModel();
                var query = ctx.BonusRecord.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// BRFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.BRFullName)) query = query.Where(t=>t.BRFullName.Contains(searchModel.BRFullName));
                if(sort=="BRFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BRFullName):query.OrderByDescending(t=>t.BRFullName);
                    isordered = true;
                }
				// BRIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.BRIdCardNo)) query = query.Where(t=>t.BRIdCardNo.Contains(searchModel.BRIdCardNo));
                if(sort=="BRIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BRIdCardNo):query.OrderByDescending(t=>t.BRIdCardNo);
                    isordered = true;
                }
				// BRShareType NVARCHAR(50) 股份类型 
                if(!string.IsNullOrEmpty(searchModel.BRShareType)) query = query.Where(t=>t.BRShareType.Contains(searchModel.BRShareType));
                if(sort=="BRShareType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BRShareType):query.OrderByDescending(t=>t.BRShareType);
                    isordered = true;
                }
				// BRShareRatio NVARCHAR(50) 股票占比 
                if(!string.IsNullOrEmpty(searchModel.BRShareRatio)) query = query.Where(t=>t.BRShareRatio.Contains(searchModel.BRShareRatio));
                if(sort=="BRShareRatio")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BRShareRatio):query.OrderByDescending(t=>t.BRShareRatio);
                    isordered = true;
                }
				// BRPaymentAmount MONEY 发放金额 
                if(searchModel.MinBRPaymentAmount!=null) query = query.Where(t=>t.BRPaymentAmount>=searchModel.MinBRPaymentAmount);
                if(searchModel.MaxBRPaymentAmount!=null) query = query.Where(t=>t.BRPaymentAmount<=searchModel.MaxBRPaymentAmount);
                if(sort=="BRPaymentAmount")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BRPaymentAmount):query.OrderByDescending(t=>t.BRPaymentAmount);
                    isordered = true;
                }
				// BRPaymentTime DATETIME 发放时间 
                if(searchModel.FromBRPaymentTime!=null) query = query.Where(t=>t.BRPaymentTime>=searchModel.FromBRPaymentTime);
                if(searchModel.ToBRPaymentTime!=null) query = query.Where(t=>t.BRPaymentTime<=searchModel.ToBRPaymentTime);
                if(sort=="BRPaymentTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BRPaymentTime):query.OrderByDescending(t=>t.BRPaymentTime);
                    isordered = true;
                }
				// BRPersonInCharge NVARCHAR(50) 负责人 
                if(!string.IsNullOrEmpty(searchModel.BRPersonInCharge)) query = query.Where(t=>t.BRPersonInCharge.Contains(searchModel.BRPersonInCharge));
                if(sort=="BRPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BRPersonInCharge):query.OrderByDescending(t=>t.BRPersonInCharge);
                    isordered = true;
                }
				// BRContactInformationOfPersonInCharge NVARCHAR(50) 负责人联系方式 
                if(!string.IsNullOrEmpty(searchModel.BRContactInformationOfPersonInCharge)) query = query.Where(t=>t.BRContactInformationOfPersonInCharge.Contains(searchModel.BRContactInformationOfPersonInCharge));
                if(sort=="BRContactInformationOfPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BRContactInformationOfPersonInCharge):query.OrderByDescending(t=>t.BRContactInformationOfPersonInCharge);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.BRFullName.Contains(search)||t.BRIdCardNo.Contains(search)||t.BRShareType.Contains(search)||t.BRShareRatio.Contains(search)||t.BRPersonInCharge.Contains(search)||t.BRContactInformationOfPersonInCharge.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<BonusRecord>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【干部】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class CadreCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Cadre.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【干部】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【干部】
    /// </summary>
    public partial class DeleteCadreEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Cadre>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Cadre.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Cadre.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条干部记录";
    }
	
    /// <summary>
    /// 保存【干部】
    /// </summary>
    public partial class SaveCadreEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Cadre>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Cadre.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Cadre.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.CFullName = HttpUtility.UrlDecode(entity.CFullName);
					// NVARCHAR(4000)
				entity.CIdCardNo = HttpUtility.UrlDecode(entity.CIdCardNo);
					// NVARCHAR(50)
				entity.CSuperiorLeader = HttpUtility.UrlDecode(entity.CSuperiorLeader);
					// NVARCHAR(50)
				entity.CSubordinateBranch = HttpUtility.UrlDecode(entity.CSubordinateBranch);
					// NVARCHAR(50)
				entity.CModelWorker = HttpUtility.UrlDecode(entity.CModelWorker);
					// NVARCHAR(50)
				entity.CTypesOfCadres = HttpUtility.UrlDecode(entity.CTypesOfCadres);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Cadre.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Cadre记录";
    }
	
    /// <summary>
    /// 查询空的【干部】
    /// </summary>
    public partial class GetCadreEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Cadre();
        }
        public override string Comments=> "获取空的干部记录";
    }
	
    /// <summary>
    /// 查询【干部】列表
    /// </summary>
    public partial class GetCadreListEvaluator : Evaluator
    {
        public override string Comments=> "获取Cadre列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<CadreSearchModel>() ?? new CadreSearchModel();
                var query = ctx.Cadre.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// CFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.CFullName)) query = query.Where(t=>t.CFullName.Contains(searchModel.CFullName));
                if(sort=="CFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFullName):query.OrderByDescending(t=>t.CFullName);
                    isordered = true;
                }
				// CIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.CIdCardNo)) query = query.Where(t=>t.CIdCardNo.Contains(searchModel.CIdCardNo));
                if(sort=="CIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CIdCardNo):query.OrderByDescending(t=>t.CIdCardNo);
                    isordered = true;
                }
				// CSuperiorLeader NVARCHAR(50) 上级领导 
                if(!string.IsNullOrEmpty(searchModel.CSuperiorLeader)) query = query.Where(t=>t.CSuperiorLeader.Contains(searchModel.CSuperiorLeader));
                if(sort=="CSuperiorLeader")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CSuperiorLeader):query.OrderByDescending(t=>t.CSuperiorLeader);
                    isordered = true;
                }
				// CSubordinateBranch NVARCHAR(50) 所属支部 
                if(!string.IsNullOrEmpty(searchModel.CSubordinateBranch)) query = query.Where(t=>t.CSubordinateBranch.Contains(searchModel.CSubordinateBranch));
                if(sort=="CSubordinateBranch")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CSubordinateBranch):query.OrderByDescending(t=>t.CSubordinateBranch);
                    isordered = true;
                }
				// CModelWorker NVARCHAR(50) 劳模 
                if(!string.IsNullOrEmpty(searchModel.CModelWorker)) query = query.Where(t=>t.CModelWorker.Contains(searchModel.CModelWorker));
                if(sort=="CModelWorker")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CModelWorker):query.OrderByDescending(t=>t.CModelWorker);
                    isordered = true;
                }
				// CTypesOfCadres NVARCHAR(50) 干部类型 
                if(!string.IsNullOrEmpty(searchModel.CTypesOfCadres)) query = query.Where(t=>t.CTypesOfCadres.Contains(searchModel.CTypesOfCadres));
                if(sort=="CTypesOfCadres")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CTypesOfCadres):query.OrderByDescending(t=>t.CTypesOfCadres);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.CFullName.Contains(search)||t.CIdCardNo.Contains(search)||t.CSuperiorLeader.Contains(search)||t.CSubordinateBranch.Contains(search)||t.CModelWorker.Contains(search)||t.CTypesOfCadres.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Cadre>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【民兵】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class MilitiaCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Militia.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【民兵】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【民兵】
    /// </summary>
    public partial class DeleteMilitiaEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Militia>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Militia.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Militia.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条民兵记录";
    }
	
    /// <summary>
    /// 保存【民兵】
    /// </summary>
    public partial class SaveMilitiaEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Militia>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Militia.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Militia.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.MFullName = HttpUtility.UrlDecode(entity.MFullName);
					// NVARCHAR(4000)
				entity.MIdCardNo = HttpUtility.UrlDecode(entity.MIdCardNo);
					// NVARCHAR(50)
				entity.MSuperiorLeader = HttpUtility.UrlDecode(entity.MSuperiorLeader);
					// NVARCHAR(50)
				entity.MDesignation = HttpUtility.UrlDecode(entity.MDesignation);
					// NVARCHAR(50)
				entity.MMilitiaType = HttpUtility.UrlDecode(entity.MMilitiaType);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Militia.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Militia记录";
    }
	
    /// <summary>
    /// 查询空的【民兵】
    /// </summary>
    public partial class GetMilitiaEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Militia();
        }
        public override string Comments=> "获取空的民兵记录";
    }
	
    /// <summary>
    /// 查询【民兵】列表
    /// </summary>
    public partial class GetMilitiaListEvaluator : Evaluator
    {
        public override string Comments=> "获取Militia列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<MilitiaSearchModel>() ?? new MilitiaSearchModel();
                var query = ctx.Militia.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// MFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.MFullName)) query = query.Where(t=>t.MFullName.Contains(searchModel.MFullName));
                if(sort=="MFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MFullName):query.OrderByDescending(t=>t.MFullName);
                    isordered = true;
                }
				// MIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.MIdCardNo)) query = query.Where(t=>t.MIdCardNo.Contains(searchModel.MIdCardNo));
                if(sort=="MIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MIdCardNo):query.OrderByDescending(t=>t.MIdCardNo);
                    isordered = true;
                }
				// MSuperiorLeader NVARCHAR(50) 上级领导 
                if(!string.IsNullOrEmpty(searchModel.MSuperiorLeader)) query = query.Where(t=>t.MSuperiorLeader.Contains(searchModel.MSuperiorLeader));
                if(sort=="MSuperiorLeader")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MSuperiorLeader):query.OrderByDescending(t=>t.MSuperiorLeader);
                    isordered = true;
                }
				// MDesignation NVARCHAR(50) 所属番号 
                if(!string.IsNullOrEmpty(searchModel.MDesignation)) query = query.Where(t=>t.MDesignation.Contains(searchModel.MDesignation));
                if(sort=="MDesignation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MDesignation):query.OrderByDescending(t=>t.MDesignation);
                    isordered = true;
                }
				// MMilitiaType NVARCHAR(50) 民兵类型 
                if(!string.IsNullOrEmpty(searchModel.MMilitiaType)) query = query.Where(t=>t.MMilitiaType.Contains(searchModel.MMilitiaType));
                if(sort=="MMilitiaType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MMilitiaType):query.OrderByDescending(t=>t.MMilitiaType);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.MFullName.Contains(search)||t.MIdCardNo.Contains(search)||t.MSuperiorLeader.Contains(search)||t.MDesignation.Contains(search)||t.MMilitiaType.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Militia>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【统战民兵】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class UnitedFrontMilitiaCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.UnitedFrontMilitia.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【统战民兵】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【统战民兵】
    /// </summary>
    public partial class DeleteUnitedFrontMilitiaEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<UnitedFrontMilitia>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.UnitedFrontMilitia.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.UnitedFrontMilitia.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条统战民兵记录";
    }
	
    /// <summary>
    /// 保存【统战民兵】
    /// </summary>
    public partial class SaveUnitedFrontMilitiaEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<UnitedFrontMilitia>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.UnitedFrontMilitia.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.UnitedFrontMilitia.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.UFMFullName = HttpUtility.UrlDecode(entity.UFMFullName);
					// NVARCHAR(4000)
				entity.UFMIdCardNo = HttpUtility.UrlDecode(entity.UFMIdCardNo);
					// NVARCHAR(50)
				entity.UFMSuperiorLeader = HttpUtility.UrlDecode(entity.UFMSuperiorLeader);
					// NVARCHAR(50)
				entity.UFMDesignation = HttpUtility.UrlDecode(entity.UFMDesignation);
					// NVARCHAR(50)
				entity.UFMMilitiaType = HttpUtility.UrlDecode(entity.UFMMilitiaType);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.UnitedFrontMilitia.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条UnitedFrontMilitia记录";
    }
	
    /// <summary>
    /// 查询空的【统战民兵】
    /// </summary>
    public partial class GetUnitedFrontMilitiaEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new UnitedFrontMilitia();
        }
        public override string Comments=> "获取空的统战民兵记录";
    }
	
    /// <summary>
    /// 查询【统战民兵】列表
    /// </summary>
    public partial class GetUnitedFrontMilitiaListEvaluator : Evaluator
    {
        public override string Comments=> "获取UnitedFrontMilitia列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<UnitedFrontMilitiaSearchModel>() ?? new UnitedFrontMilitiaSearchModel();
                var query = ctx.UnitedFrontMilitia.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// UFMFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.UFMFullName)) query = query.Where(t=>t.UFMFullName.Contains(searchModel.UFMFullName));
                if(sort=="UFMFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UFMFullName):query.OrderByDescending(t=>t.UFMFullName);
                    isordered = true;
                }
				// UFMIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.UFMIdCardNo)) query = query.Where(t=>t.UFMIdCardNo.Contains(searchModel.UFMIdCardNo));
                if(sort=="UFMIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UFMIdCardNo):query.OrderByDescending(t=>t.UFMIdCardNo);
                    isordered = true;
                }
				// UFMSuperiorLeader NVARCHAR(50) 上级领导 
                if(!string.IsNullOrEmpty(searchModel.UFMSuperiorLeader)) query = query.Where(t=>t.UFMSuperiorLeader.Contains(searchModel.UFMSuperiorLeader));
                if(sort=="UFMSuperiorLeader")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UFMSuperiorLeader):query.OrderByDescending(t=>t.UFMSuperiorLeader);
                    isordered = true;
                }
				// UFMDesignation NVARCHAR(50) 所属番号 
                if(!string.IsNullOrEmpty(searchModel.UFMDesignation)) query = query.Where(t=>t.UFMDesignation.Contains(searchModel.UFMDesignation));
                if(sort=="UFMDesignation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UFMDesignation):query.OrderByDescending(t=>t.UFMDesignation);
                    isordered = true;
                }
				// UFMMilitiaType NVARCHAR(50) 民兵类型 
                if(!string.IsNullOrEmpty(searchModel.UFMMilitiaType)) query = query.Where(t=>t.UFMMilitiaType.Contains(searchModel.UFMMilitiaType));
                if(sort=="UFMMilitiaType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.UFMMilitiaType):query.OrderByDescending(t=>t.UFMMilitiaType);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.UFMFullName.Contains(search)||t.UFMIdCardNo.Contains(search)||t.UFMSuperiorLeader.Contains(search)||t.UFMDesignation.Contains(search)||t.UFMMilitiaType.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<UnitedFrontMilitia>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【厂房楼栋】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class FactoryBuildingCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.FactoryBuilding.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【厂房楼栋】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【厂房楼栋】
    /// </summary>
    public partial class DeleteFactoryBuildingEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<FactoryBuilding>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.FactoryBuilding.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.FactoryBuilding.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条厂房楼栋记录";
    }
	
    /// <summary>
    /// 保存【厂房楼栋】
    /// </summary>
    public partial class SaveFactoryBuildingEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<FactoryBuilding>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.FactoryBuilding.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.FactoryBuilding.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.FBNameOfIndustrialPark = HttpUtility.UrlDecode(entity.FBNameOfIndustrialPark);
					// NVARCHAR(50)
				entity.FBSerialNumber = HttpUtility.UrlDecode(entity.FBSerialNumber);
					// NVARCHAR(50)
				entity.FBTenant = HttpUtility.UrlDecode(entity.FBTenant);
					// NVARCHAR(50)
				entity.FBStartStop = HttpUtility.UrlDecode(entity.FBStartStop);
					// NVARCHAR(50)
				entity.FBDeposit = HttpUtility.UrlDecode(entity.FBDeposit);
					// NVARCHAR(50)
				entity.FBUnitPrice = HttpUtility.UrlDecode(entity.FBUnitPrice);
					// NVARCHAR(50)
				entity.FBMonthlyRent = HttpUtility.UrlDecode(entity.FBMonthlyRent);
					// NVARCHAR(50)
				entity.FBAnnualRent = HttpUtility.UrlDecode(entity.FBAnnualRent);
					// NVARCHAR(50)
				entity.FBCharteredUnitNature = HttpUtility.UrlDecode(entity.FBCharteredUnitNature);
					// NVARCHAR(50)
				entity.FBEnvironmentalProtectionProcedures = HttpUtility.UrlDecode(entity.FBEnvironmentalProtectionProcedures);
					// NVARCHAR(50)
				entity.FBContacts = HttpUtility.UrlDecode(entity.FBContacts);
					// NVARCHAR(50)
				entity.FBContactNumber = HttpUtility.UrlDecode(entity.FBContactNumber);
					// NVARCHAR(50)
				entity.FBApprovalDocument = HttpUtility.UrlDecode(entity.FBApprovalDocument);
					// NVARCHAR(50)
				entity.FBBuildingNumber = HttpUtility.UrlDecode(entity.FBBuildingNumber);
					// NVARCHAR(50)
				entity.FBUnitNumber = HttpUtility.UrlDecode(entity.FBUnitNumber);
					// NVARCHAR(50)
				entity.FBHouseNumber = HttpUtility.UrlDecode(entity.FBHouseNumber);
					// NVARCHAR(50)
				entity.FBPersonInCharge = HttpUtility.UrlDecode(entity.FBPersonInCharge);
					// NVARCHAR(50)
				entity.FBContactInformationOfPersonInCharge = HttpUtility.UrlDecode(entity.FBContactInformationOfPersonInCharge);
					// NVARCHAR(50)
				entity.FBRange = HttpUtility.UrlDecode(entity.FBRange);
					// NVARCHAR(4000)
				entity.FBRemarks = HttpUtility.UrlDecode(entity.FBRemarks);
					// NVARCHAR(4000)
				entity.FBAddress = HttpUtility.UrlDecode(entity.FBAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.FactoryBuilding.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条FactoryBuilding记录";
    }
	
    /// <summary>
    /// 查询空的【厂房楼栋】
    /// </summary>
    public partial class GetFactoryBuildingEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new FactoryBuilding();
        }
        public override string Comments=> "获取空的厂房楼栋记录";
    }
	
    /// <summary>
    /// 查询【厂房楼栋】列表
    /// </summary>
    public partial class GetFactoryBuildingListEvaluator : Evaluator
    {
        public override string Comments=> "获取FactoryBuilding列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<FactoryBuildingSearchModel>() ?? new FactoryBuildingSearchModel();
                var query = ctx.FactoryBuilding.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// FBNameOfIndustrialPark NVARCHAR(50) 工业园名称 
                if(!string.IsNullOrEmpty(searchModel.FBNameOfIndustrialPark)) query = query.Where(t=>t.FBNameOfIndustrialPark.Contains(searchModel.FBNameOfIndustrialPark));
                if(sort=="FBNameOfIndustrialPark")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBNameOfIndustrialPark):query.OrderByDescending(t=>t.FBNameOfIndustrialPark);
                    isordered = true;
                }
				// FBSerialNumber NVARCHAR(50) 序号 
                if(!string.IsNullOrEmpty(searchModel.FBSerialNumber)) query = query.Where(t=>t.FBSerialNumber.Contains(searchModel.FBSerialNumber));
                if(sort=="FBSerialNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBSerialNumber):query.OrderByDescending(t=>t.FBSerialNumber);
                    isordered = true;
                }
				// FBTenant NVARCHAR(50) 承租户 
                if(!string.IsNullOrEmpty(searchModel.FBTenant)) query = query.Where(t=>t.FBTenant.Contains(searchModel.FBTenant));
                if(sort=="FBTenant")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBTenant):query.OrderByDescending(t=>t.FBTenant);
                    isordered = true;
                }
				// FBStartStop NVARCHAR(50) 起止 
                if(!string.IsNullOrEmpty(searchModel.FBStartStop)) query = query.Where(t=>t.FBStartStop.Contains(searchModel.FBStartStop));
                if(sort=="FBStartStop")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBStartStop):query.OrderByDescending(t=>t.FBStartStop);
                    isordered = true;
                }
				// FBLesseeArea REAL 承租面积 
                if(searchModel.MinFBLesseeArea!=null) query = query.Where(t=>t.FBLesseeArea>=searchModel.MinFBLesseeArea);
                if(searchModel.MaxFBLesseeArea!=null) query = query.Where(t=>t.FBLesseeArea<=searchModel.MaxFBLesseeArea);
                if(sort=="FBLesseeArea")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBLesseeArea):query.OrderByDescending(t=>t.FBLesseeArea);
                    isordered = true;
                }
				// FBDeposit NVARCHAR(50) 押金 
                if(!string.IsNullOrEmpty(searchModel.FBDeposit)) query = query.Where(t=>t.FBDeposit.Contains(searchModel.FBDeposit));
                if(sort=="FBDeposit")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBDeposit):query.OrderByDescending(t=>t.FBDeposit);
                    isordered = true;
                }
				// FBUnitPrice NVARCHAR(50) 单价 
                if(!string.IsNullOrEmpty(searchModel.FBUnitPrice)) query = query.Where(t=>t.FBUnitPrice.Contains(searchModel.FBUnitPrice));
                if(sort=="FBUnitPrice")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBUnitPrice):query.OrderByDescending(t=>t.FBUnitPrice);
                    isordered = true;
                }
				// FBMonthlyRent NVARCHAR(50) 月租金 
                if(!string.IsNullOrEmpty(searchModel.FBMonthlyRent)) query = query.Where(t=>t.FBMonthlyRent.Contains(searchModel.FBMonthlyRent));
                if(sort=="FBMonthlyRent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBMonthlyRent):query.OrderByDescending(t=>t.FBMonthlyRent);
                    isordered = true;
                }
				// FBAnnualRent NVARCHAR(50) 年租金 
                if(!string.IsNullOrEmpty(searchModel.FBAnnualRent)) query = query.Where(t=>t.FBAnnualRent.Contains(searchModel.FBAnnualRent));
                if(sort=="FBAnnualRent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBAnnualRent):query.OrderByDescending(t=>t.FBAnnualRent);
                    isordered = true;
                }
				// FBCharteredUnitNature NVARCHAR(50) 租凭单位性质 
                if(!string.IsNullOrEmpty(searchModel.FBCharteredUnitNature)) query = query.Where(t=>t.FBCharteredUnitNature.Contains(searchModel.FBCharteredUnitNature));
                if(sort=="FBCharteredUnitNature")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBCharteredUnitNature):query.OrderByDescending(t=>t.FBCharteredUnitNature);
                    isordered = true;
                }
				// FBEnvironmentalProtectionProcedures NVARCHAR(50) 环保手续 
                if(!string.IsNullOrEmpty(searchModel.FBEnvironmentalProtectionProcedures)) query = query.Where(t=>t.FBEnvironmentalProtectionProcedures.Contains(searchModel.FBEnvironmentalProtectionProcedures));
                if(sort=="FBEnvironmentalProtectionProcedures")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBEnvironmentalProtectionProcedures):query.OrderByDescending(t=>t.FBEnvironmentalProtectionProcedures);
                    isordered = true;
                }
				// FBBuiltupArea REAL 建筑面积 
                if(searchModel.MinFBBuiltupArea!=null) query = query.Where(t=>t.FBBuiltupArea>=searchModel.MinFBBuiltupArea);
                if(searchModel.MaxFBBuiltupArea!=null) query = query.Where(t=>t.FBBuiltupArea<=searchModel.MaxFBBuiltupArea);
                if(sort=="FBBuiltupArea")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBBuiltupArea):query.OrderByDescending(t=>t.FBBuiltupArea);
                    isordered = true;
                }
				// FBStartTime DATETIME 开始时间 
                if(searchModel.FromFBStartTime!=null) query = query.Where(t=>t.FBStartTime>=searchModel.FromFBStartTime);
                if(searchModel.ToFBStartTime!=null) query = query.Where(t=>t.FBStartTime<=searchModel.ToFBStartTime);
                if(sort=="FBStartTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBStartTime):query.OrderByDescending(t=>t.FBStartTime);
                    isordered = true;
                }
				// FBEndingTime DATETIME 结束时间 
                if(searchModel.FromFBEndingTime!=null) query = query.Where(t=>t.FBEndingTime>=searchModel.FromFBEndingTime);
                if(searchModel.ToFBEndingTime!=null) query = query.Where(t=>t.FBEndingTime<=searchModel.ToFBEndingTime);
                if(sort=="FBEndingTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBEndingTime):query.OrderByDescending(t=>t.FBEndingTime);
                    isordered = true;
                }
				// FBContacts NVARCHAR(50) 联系人 
                if(!string.IsNullOrEmpty(searchModel.FBContacts)) query = query.Where(t=>t.FBContacts.Contains(searchModel.FBContacts));
                if(sort=="FBContacts")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBContacts):query.OrderByDescending(t=>t.FBContacts);
                    isordered = true;
                }
				// FBContactNumber NVARCHAR(50) 联系电话 
                if(!string.IsNullOrEmpty(searchModel.FBContactNumber)) query = query.Where(t=>t.FBContactNumber.Contains(searchModel.FBContactNumber));
                if(sort=="FBContactNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBContactNumber):query.OrderByDescending(t=>t.FBContactNumber);
                    isordered = true;
                }
				// FBApprovalDocument NVARCHAR(50) 审批文件 
                if(!string.IsNullOrEmpty(searchModel.FBApprovalDocument)) query = query.Where(t=>t.FBApprovalDocument.Contains(searchModel.FBApprovalDocument));
                if(sort=="FBApprovalDocument")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBApprovalDocument):query.OrderByDescending(t=>t.FBApprovalDocument);
                    isordered = true;
                }
				// FBBuildingNumber NVARCHAR(50) 楼号 
                if(!string.IsNullOrEmpty(searchModel.FBBuildingNumber)) query = query.Where(t=>t.FBBuildingNumber.Contains(searchModel.FBBuildingNumber));
                if(sort=="FBBuildingNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBBuildingNumber):query.OrderByDescending(t=>t.FBBuildingNumber);
                    isordered = true;
                }
				// FBUnitNumber NVARCHAR(50) 单元号 
                if(!string.IsNullOrEmpty(searchModel.FBUnitNumber)) query = query.Where(t=>t.FBUnitNumber.Contains(searchModel.FBUnitNumber));
                if(sort=="FBUnitNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBUnitNumber):query.OrderByDescending(t=>t.FBUnitNumber);
                    isordered = true;
                }
				// FBHouseNumber NVARCHAR(50) 门牌号 
                if(!string.IsNullOrEmpty(searchModel.FBHouseNumber)) query = query.Where(t=>t.FBHouseNumber.Contains(searchModel.FBHouseNumber));
                if(sort=="FBHouseNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBHouseNumber):query.OrderByDescending(t=>t.FBHouseNumber);
                    isordered = true;
                }
				// FBPersonInCharge NVARCHAR(50) 负责人 
                if(!string.IsNullOrEmpty(searchModel.FBPersonInCharge)) query = query.Where(t=>t.FBPersonInCharge.Contains(searchModel.FBPersonInCharge));
                if(sort=="FBPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBPersonInCharge):query.OrderByDescending(t=>t.FBPersonInCharge);
                    isordered = true;
                }
				// FBContactInformationOfPersonInCharge NVARCHAR(50) 负责人联系方式 
                if(!string.IsNullOrEmpty(searchModel.FBContactInformationOfPersonInCharge)) query = query.Where(t=>t.FBContactInformationOfPersonInCharge.Contains(searchModel.FBContactInformationOfPersonInCharge));
                if(sort=="FBContactInformationOfPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBContactInformationOfPersonInCharge):query.OrderByDescending(t=>t.FBContactInformationOfPersonInCharge);
                    isordered = true;
                }
				// FBRange NVARCHAR(50) 范围 
                if(!string.IsNullOrEmpty(searchModel.FBRange)) query = query.Where(t=>t.FBRange.Contains(searchModel.FBRange));
                if(sort=="FBRange")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBRange):query.OrderByDescending(t=>t.FBRange);
                    isordered = true;
                }
				// FBRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.FBRemarks)) query = query.Where(t=>t.FBRemarks.Contains(searchModel.FBRemarks));
                if(sort=="FBRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBRemarks):query.OrderByDescending(t=>t.FBRemarks);
                    isordered = true;
                }
				// FBAddress NVARCHAR(4000) 地址 
                if(!string.IsNullOrEmpty(searchModel.FBAddress)) query = query.Where(t=>t.FBAddress.Contains(searchModel.FBAddress));
                if(sort=="FBAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FBAddress):query.OrderByDescending(t=>t.FBAddress);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.FBNameOfIndustrialPark.Contains(search)||t.FBSerialNumber.Contains(search)||t.FBTenant.Contains(search)||t.FBStartStop.Contains(search)||t.FBDeposit.Contains(search)||t.FBUnitPrice.Contains(search)||t.FBMonthlyRent.Contains(search)||t.FBAnnualRent.Contains(search)||t.FBCharteredUnitNature.Contains(search)||t.FBEnvironmentalProtectionProcedures.Contains(search)||t.FBContacts.Contains(search)||t.FBContactNumber.Contains(search)||t.FBApprovalDocument.Contains(search)||t.FBBuildingNumber.Contains(search)||t.FBUnitNumber.Contains(search)||t.FBHouseNumber.Contains(search)||t.FBPersonInCharge.Contains(search)||t.FBContactInformationOfPersonInCharge.Contains(search)||t.FBRange.Contains(search)||t.FBRemarks.Contains(search)||t.FBAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<FactoryBuilding>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【收租记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class RentCollectionRecordsCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.RentCollectionRecords.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【收租记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【收租记录】
    /// </summary>
    public partial class DeleteRentCollectionRecordsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<RentCollectionRecords>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.RentCollectionRecords.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.RentCollectionRecords.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条收租记录记录";
    }
	
    /// <summary>
    /// 保存【收租记录】
    /// </summary>
    public partial class SaveRentCollectionRecordsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<RentCollectionRecords>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.RentCollectionRecords.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.RentCollectionRecords.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.RCREnterpriseName = HttpUtility.UrlDecode(entity.RCREnterpriseName);
					// NVARCHAR(50)
				entity.RCRPersonInCharge = HttpUtility.UrlDecode(entity.RCRPersonInCharge);
					// NVARCHAR(50)
				entity.RCRTelephoneCallsFromThePersonInCharge = HttpUtility.UrlDecode(entity.RCRTelephoneCallsFromThePersonInCharge);
					// NVARCHAR(50)
				entity.RCRPayee = HttpUtility.UrlDecode(entity.RCRPayee);
					// NVARCHAR(50)
				entity.RCRCashiersTelephone = HttpUtility.UrlDecode(entity.RCRCashiersTelephone);
					// NVARCHAR(4000)
				entity.RCRRemarks = HttpUtility.UrlDecode(entity.RCRRemarks);
					// NVARCHAR(50)
				entity.RCRNameOfIndustrialPark = HttpUtility.UrlDecode(entity.RCRNameOfIndustrialPark);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.RentCollectionRecords.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条RentCollectionRecords记录";
    }
	
    /// <summary>
    /// 查询空的【收租记录】
    /// </summary>
    public partial class GetRentCollectionRecordsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new RentCollectionRecords();
        }
        public override string Comments=> "获取空的收租记录记录";
    }
	
    /// <summary>
    /// 查询【收租记录】列表
    /// </summary>
    public partial class GetRentCollectionRecordsListEvaluator : Evaluator
    {
        public override string Comments=> "获取RentCollectionRecords列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<RentCollectionRecordsSearchModel>() ?? new RentCollectionRecordsSearchModel();
                var query = ctx.RentCollectionRecords.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// RCREnterpriseName NVARCHAR(4000) 企业名称 
                if(!string.IsNullOrEmpty(searchModel.RCREnterpriseName)) query = query.Where(t=>t.RCREnterpriseName.Contains(searchModel.RCREnterpriseName));
                if(sort=="RCREnterpriseName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCREnterpriseName):query.OrderByDescending(t=>t.RCREnterpriseName);
                    isordered = true;
                }
				// RCRPersonInCharge NVARCHAR(50) 负责人 
                if(!string.IsNullOrEmpty(searchModel.RCRPersonInCharge)) query = query.Where(t=>t.RCRPersonInCharge.Contains(searchModel.RCRPersonInCharge));
                if(sort=="RCRPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRPersonInCharge):query.OrderByDescending(t=>t.RCRPersonInCharge);
                    isordered = true;
                }
				// RCRTelephoneCallsFromThePersonInCharge NVARCHAR(50) 负责人电话 
                if(!string.IsNullOrEmpty(searchModel.RCRTelephoneCallsFromThePersonInCharge)) query = query.Where(t=>t.RCRTelephoneCallsFromThePersonInCharge.Contains(searchModel.RCRTelephoneCallsFromThePersonInCharge));
                if(sort=="RCRTelephoneCallsFromThePersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRTelephoneCallsFromThePersonInCharge):query.OrderByDescending(t=>t.RCRTelephoneCallsFromThePersonInCharge);
                    isordered = true;
                }
				// RCRPaymentAmount MONEY 付款金额 
                if(searchModel.MinRCRPaymentAmount!=null) query = query.Where(t=>t.RCRPaymentAmount>=searchModel.MinRCRPaymentAmount);
                if(searchModel.MaxRCRPaymentAmount!=null) query = query.Where(t=>t.RCRPaymentAmount<=searchModel.MaxRCRPaymentAmount);
                if(sort=="RCRPaymentAmount")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRPaymentAmount):query.OrderByDescending(t=>t.RCRPaymentAmount);
                    isordered = true;
                }
				// RCRPayee NVARCHAR(50) 收款人 
                if(!string.IsNullOrEmpty(searchModel.RCRPayee)) query = query.Where(t=>t.RCRPayee.Contains(searchModel.RCRPayee));
                if(sort=="RCRPayee")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRPayee):query.OrderByDescending(t=>t.RCRPayee);
                    isordered = true;
                }
				// RCRCashiersTelephone NVARCHAR(50) 收款人电话 
                if(!string.IsNullOrEmpty(searchModel.RCRCashiersTelephone)) query = query.Where(t=>t.RCRCashiersTelephone.Contains(searchModel.RCRCashiersTelephone));
                if(sort=="RCRCashiersTelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRCashiersTelephone):query.OrderByDescending(t=>t.RCRCashiersTelephone);
                    isordered = true;
                }
				// RCRAmountCollected MONEY 收款金额 
                if(searchModel.MinRCRAmountCollected!=null) query = query.Where(t=>t.RCRAmountCollected>=searchModel.MinRCRAmountCollected);
                if(searchModel.MaxRCRAmountCollected!=null) query = query.Where(t=>t.RCRAmountCollected<=searchModel.MaxRCRAmountCollected);
                if(sort=="RCRAmountCollected")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRAmountCollected):query.OrderByDescending(t=>t.RCRAmountCollected);
                    isordered = true;
                }
				// RCRCollectionTime DATETIME 收款时间 
                if(searchModel.FromRCRCollectionTime!=null) query = query.Where(t=>t.RCRCollectionTime>=searchModel.FromRCRCollectionTime);
                if(searchModel.ToRCRCollectionTime!=null) query = query.Where(t=>t.RCRCollectionTime<=searchModel.ToRCRCollectionTime);
                if(sort=="RCRCollectionTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRCollectionTime):query.OrderByDescending(t=>t.RCRCollectionTime);
                    isordered = true;
                }
				// RCRTimeOfReceivables DATETIME 应收款时间 
                if(searchModel.FromRCRTimeOfReceivables!=null) query = query.Where(t=>t.RCRTimeOfReceivables>=searchModel.FromRCRTimeOfReceivables);
                if(searchModel.ToRCRTimeOfReceivables!=null) query = query.Where(t=>t.RCRTimeOfReceivables<=searchModel.ToRCRTimeOfReceivables);
                if(sort=="RCRTimeOfReceivables")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRTimeOfReceivables):query.OrderByDescending(t=>t.RCRTimeOfReceivables);
                    isordered = true;
                }
				// RCRRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.RCRRemarks)) query = query.Where(t=>t.RCRRemarks.Contains(searchModel.RCRRemarks));
                if(sort=="RCRRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRRemarks):query.OrderByDescending(t=>t.RCRRemarks);
                    isordered = true;
                }
				// RCRNameOfIndustrialPark NVARCHAR(50) 工业园名称 
                if(!string.IsNullOrEmpty(searchModel.RCRNameOfIndustrialPark)) query = query.Where(t=>t.RCRNameOfIndustrialPark.Contains(searchModel.RCRNameOfIndustrialPark));
                if(sort=="RCRNameOfIndustrialPark")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RCRNameOfIndustrialPark):query.OrderByDescending(t=>t.RCRNameOfIndustrialPark);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.RCREnterpriseName.Contains(search)||t.RCRPersonInCharge.Contains(search)||t.RCRTelephoneCallsFromThePersonInCharge.Contains(search)||t.RCRPayee.Contains(search)||t.RCRCashiersTelephone.Contains(search)||t.RCRRemarks.Contains(search)||t.RCRNameOfIndustrialPark.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<RentCollectionRecords>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【电费缴纳记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ElectricityChargePaymentRecordCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ElectricityChargePaymentRecord.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【电费缴纳记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【电费缴纳记录】
    /// </summary>
    public partial class DeleteElectricityChargePaymentRecordEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ElectricityChargePaymentRecord>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ElectricityChargePaymentRecord.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ElectricityChargePaymentRecord.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条电费缴纳记录记录";
    }
	
    /// <summary>
    /// 保存【电费缴纳记录】
    /// </summary>
    public partial class SaveElectricityChargePaymentRecordEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ElectricityChargePaymentRecord>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ElectricityChargePaymentRecord.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ElectricityChargePaymentRecord.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.ECPREnterpriseName = HttpUtility.UrlDecode(entity.ECPREnterpriseName);
					// NVARCHAR(50)
				entity.ECPRPersonInCharge = HttpUtility.UrlDecode(entity.ECPRPersonInCharge);
					// NVARCHAR(50)
				entity.ECPRTelephoneCallsFromThePersonInCharge = HttpUtility.UrlDecode(entity.ECPRTelephoneCallsFromThePersonInCharge);
					// NVARCHAR(50)
				entity.ECPRPayee = HttpUtility.UrlDecode(entity.ECPRPayee);
					// NVARCHAR(50)
				entity.ECPRCashiersTelephone = HttpUtility.UrlDecode(entity.ECPRCashiersTelephone);
					// NVARCHAR(4000)
				entity.ECPRRemarks = HttpUtility.UrlDecode(entity.ECPRRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ElectricityChargePaymentRecord.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ElectricityChargePaymentRecord记录";
    }
	
    /// <summary>
    /// 查询空的【电费缴纳记录】
    /// </summary>
    public partial class GetElectricityChargePaymentRecordEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ElectricityChargePaymentRecord();
        }
        public override string Comments=> "获取空的电费缴纳记录记录";
    }
	
    /// <summary>
    /// 查询【电费缴纳记录】列表
    /// </summary>
    public partial class GetElectricityChargePaymentRecordListEvaluator : Evaluator
    {
        public override string Comments=> "获取ElectricityChargePaymentRecord列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ElectricityChargePaymentRecordSearchModel>() ?? new ElectricityChargePaymentRecordSearchModel();
                var query = ctx.ElectricityChargePaymentRecord.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// ECPREnterpriseName NVARCHAR(4000) 企业名称 
                if(!string.IsNullOrEmpty(searchModel.ECPREnterpriseName)) query = query.Where(t=>t.ECPREnterpriseName.Contains(searchModel.ECPREnterpriseName));
                if(sort=="ECPREnterpriseName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ECPREnterpriseName):query.OrderByDescending(t=>t.ECPREnterpriseName);
                    isordered = true;
                }
				// ECPRPersonInCharge NVARCHAR(50) 负责人 
                if(!string.IsNullOrEmpty(searchModel.ECPRPersonInCharge)) query = query.Where(t=>t.ECPRPersonInCharge.Contains(searchModel.ECPRPersonInCharge));
                if(sort=="ECPRPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ECPRPersonInCharge):query.OrderByDescending(t=>t.ECPRPersonInCharge);
                    isordered = true;
                }
				// ECPRTelephoneCallsFromThePersonInCharge NVARCHAR(50) 负责人电话 
                if(!string.IsNullOrEmpty(searchModel.ECPRTelephoneCallsFromThePersonInCharge)) query = query.Where(t=>t.ECPRTelephoneCallsFromThePersonInCharge.Contains(searchModel.ECPRTelephoneCallsFromThePersonInCharge));
                if(sort=="ECPRTelephoneCallsFromThePersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ECPRTelephoneCallsFromThePersonInCharge):query.OrderByDescending(t=>t.ECPRTelephoneCallsFromThePersonInCharge);
                    isordered = true;
                }
				// ECPRPaymentAmount MONEY 付款金额 
                if(searchModel.MinECPRPaymentAmount!=null) query = query.Where(t=>t.ECPRPaymentAmount>=searchModel.MinECPRPaymentAmount);
                if(searchModel.MaxECPRPaymentAmount!=null) query = query.Where(t=>t.ECPRPaymentAmount<=searchModel.MaxECPRPaymentAmount);
                if(sort=="ECPRPaymentAmount")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ECPRPaymentAmount):query.OrderByDescending(t=>t.ECPRPaymentAmount);
                    isordered = true;
                }
				// ECPRPayee NVARCHAR(50) 收款人 
                if(!string.IsNullOrEmpty(searchModel.ECPRPayee)) query = query.Where(t=>t.ECPRPayee.Contains(searchModel.ECPRPayee));
                if(sort=="ECPRPayee")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ECPRPayee):query.OrderByDescending(t=>t.ECPRPayee);
                    isordered = true;
                }
				// ECPRCashiersTelephone NVARCHAR(50) 收款人电话 
                if(!string.IsNullOrEmpty(searchModel.ECPRCashiersTelephone)) query = query.Where(t=>t.ECPRCashiersTelephone.Contains(searchModel.ECPRCashiersTelephone));
                if(sort=="ECPRCashiersTelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ECPRCashiersTelephone):query.OrderByDescending(t=>t.ECPRCashiersTelephone);
                    isordered = true;
                }
				// ECPRAmountCollected MONEY 收款金额 
                if(searchModel.MinECPRAmountCollected!=null) query = query.Where(t=>t.ECPRAmountCollected>=searchModel.MinECPRAmountCollected);
                if(searchModel.MaxECPRAmountCollected!=null) query = query.Where(t=>t.ECPRAmountCollected<=searchModel.MaxECPRAmountCollected);
                if(sort=="ECPRAmountCollected")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ECPRAmountCollected):query.OrderByDescending(t=>t.ECPRAmountCollected);
                    isordered = true;
                }
				// ECPRCollectionTime DATETIME 收款时间 
                if(searchModel.FromECPRCollectionTime!=null) query = query.Where(t=>t.ECPRCollectionTime>=searchModel.FromECPRCollectionTime);
                if(searchModel.ToECPRCollectionTime!=null) query = query.Where(t=>t.ECPRCollectionTime<=searchModel.ToECPRCollectionTime);
                if(sort=="ECPRCollectionTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ECPRCollectionTime):query.OrderByDescending(t=>t.ECPRCollectionTime);
                    isordered = true;
                }
				// ECPRTimeOfReceivables DATETIME 应收款时间 
                if(searchModel.FromECPRTimeOfReceivables!=null) query = query.Where(t=>t.ECPRTimeOfReceivables>=searchModel.FromECPRTimeOfReceivables);
                if(searchModel.ToECPRTimeOfReceivables!=null) query = query.Where(t=>t.ECPRTimeOfReceivables<=searchModel.ToECPRTimeOfReceivables);
                if(sort=="ECPRTimeOfReceivables")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ECPRTimeOfReceivables):query.OrderByDescending(t=>t.ECPRTimeOfReceivables);
                    isordered = true;
                }
				// ECPRRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.ECPRRemarks)) query = query.Where(t=>t.ECPRRemarks.Contains(searchModel.ECPRRemarks));
                if(sort=="ECPRRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ECPRRemarks):query.OrderByDescending(t=>t.ECPRRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.ECPREnterpriseName.Contains(search)||t.ECPRPersonInCharge.Contains(search)||t.ECPRTelephoneCallsFromThePersonInCharge.Contains(search)||t.ECPRPayee.Contains(search)||t.ECPRCashiersTelephone.Contains(search)||t.ECPRRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ElectricityChargePaymentRecord>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【工作日志】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class JobDiaryCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.JobDiary.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【工作日志】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【工作日志】
    /// </summary>
    public partial class DeleteJobDiaryEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<JobDiary>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.JobDiary.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.JobDiary.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条工作日志记录";
    }
	
    /// <summary>
    /// 保存【工作日志】
    /// </summary>
    public partial class SaveJobDiaryEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<JobDiary>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.JobDiary.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.JobDiary.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.JDSerialNumber = HttpUtility.UrlDecode(entity.JDSerialNumber);
					// NVARCHAR(50)
				entity.JDStripe = HttpUtility.UrlDecode(entity.JDStripe);
					// NVARCHAR(50)
				entity.JDPersonInCharge = HttpUtility.UrlDecode(entity.JDPersonInCharge);
					// NVARCHAR(50)
				entity.JDProcessingMatters = HttpUtility.UrlDecode(entity.JDProcessingMatters);
					// NVARCHAR(50)
				entity.JDIsItFinished = HttpUtility.UrlDecode(entity.JDIsItFinished);
					// NVARCHAR(4000)
				entity.JDRemarks = HttpUtility.UrlDecode(entity.JDRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.JobDiary.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条JobDiary记录";
    }
	
    /// <summary>
    /// 查询空的【工作日志】
    /// </summary>
    public partial class GetJobDiaryEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new JobDiary();
        }
        public override string Comments=> "获取空的工作日志记录";
    }
	
    /// <summary>
    /// 查询【工作日志】列表
    /// </summary>
    public partial class GetJobDiaryListEvaluator : Evaluator
    {
        public override string Comments=> "获取JobDiary列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<JobDiarySearchModel>() ?? new JobDiarySearchModel();
                var query = ctx.JobDiary.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// JDSerialNumber NVARCHAR(50) 序号 
                if(!string.IsNullOrEmpty(searchModel.JDSerialNumber)) query = query.Where(t=>t.JDSerialNumber.Contains(searchModel.JDSerialNumber));
                if(sort=="JDSerialNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.JDSerialNumber):query.OrderByDescending(t=>t.JDSerialNumber);
                    isordered = true;
                }
				// JDStripe NVARCHAR(50) 条线 
                if(!string.IsNullOrEmpty(searchModel.JDStripe)) query = query.Where(t=>t.JDStripe.Contains(searchModel.JDStripe));
                if(sort=="JDStripe")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.JDStripe):query.OrderByDescending(t=>t.JDStripe);
                    isordered = true;
                }
				// JDPersonInCharge NVARCHAR(50) 负责人 
                if(!string.IsNullOrEmpty(searchModel.JDPersonInCharge)) query = query.Where(t=>t.JDPersonInCharge.Contains(searchModel.JDPersonInCharge));
                if(sort=="JDPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.JDPersonInCharge):query.OrderByDescending(t=>t.JDPersonInCharge);
                    isordered = true;
                }
				// JDDate DATETIME 日期 
                if(searchModel.FromJDDate!=null) query = query.Where(t=>t.JDDate>=searchModel.FromJDDate);
                if(searchModel.ToJDDate!=null) query = query.Where(t=>t.JDDate<=searchModel.ToJDDate);
                if(sort=="JDDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.JDDate):query.OrderByDescending(t=>t.JDDate);
                    isordered = true;
                }
				// JDProcessingMatters NVARCHAR(50) 办理事项 
                if(!string.IsNullOrEmpty(searchModel.JDProcessingMatters)) query = query.Where(t=>t.JDProcessingMatters.Contains(searchModel.JDProcessingMatters));
                if(sort=="JDProcessingMatters")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.JDProcessingMatters):query.OrderByDescending(t=>t.JDProcessingMatters);
                    isordered = true;
                }
				// JDIsItFinished NVARCHAR(50) 是否完成 
                if(!string.IsNullOrEmpty(searchModel.JDIsItFinished)) query = query.Where(t=>t.JDIsItFinished.Contains(searchModel.JDIsItFinished));
                if(sort=="JDIsItFinished")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.JDIsItFinished):query.OrderByDescending(t=>t.JDIsItFinished);
                    isordered = true;
                }
				// JDCompletionTime DATETIME 完成时间 
                if(searchModel.FromJDCompletionTime!=null) query = query.Where(t=>t.JDCompletionTime>=searchModel.FromJDCompletionTime);
                if(searchModel.ToJDCompletionTime!=null) query = query.Where(t=>t.JDCompletionTime<=searchModel.ToJDCompletionTime);
                if(sort=="JDCompletionTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.JDCompletionTime):query.OrderByDescending(t=>t.JDCompletionTime);
                    isordered = true;
                }
				// JDRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.JDRemarks)) query = query.Where(t=>t.JDRemarks.Contains(searchModel.JDRemarks));
                if(sort=="JDRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.JDRemarks):query.OrderByDescending(t=>t.JDRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.JDSerialNumber.Contains(search)||t.JDStripe.Contains(search)||t.JDPersonInCharge.Contains(search)||t.JDProcessingMatters.Contains(search)||t.JDIsItFinished.Contains(search)||t.JDRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<JobDiary>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【通知】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class NoticeCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Notice.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【通知】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【通知】
    /// </summary>
    public partial class DeleteNoticeEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Notice>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Notice.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Notice.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条通知记录";
    }
	
    /// <summary>
    /// 保存【通知】
    /// </summary>
    public partial class SaveNoticeEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Notice>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Notice.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Notice.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.NTitle = HttpUtility.UrlDecode(entity.NTitle);
					// NVARCHAR(4000)
				entity.NContent = HttpUtility.UrlDecode(entity.NContent);
					// NVARCHAR(50)
				entity.NAuthor = HttpUtility.UrlDecode(entity.NAuthor);
					// NVARCHAR(50)
				entity.NNotificationSenderObject = HttpUtility.UrlDecode(entity.NNotificationSenderObject);
					// NVARCHAR(4000)
				entity.NRemarks = HttpUtility.UrlDecode(entity.NRemarks);
					// NVARCHAR(4000)
				entity.NAbstract = HttpUtility.UrlDecode(entity.NAbstract);
					// NVARCHAR(4000)
				entity.NPicture = HttpUtility.UrlDecode(entity.NPicture);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Notice.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Notice记录";
    }
	
    /// <summary>
    /// 查询空的【通知】
    /// </summary>
    public partial class GetNoticeEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Notice();
        }
        public override string Comments=> "获取空的通知记录";
    }
	
    /// <summary>
    /// 查询【通知】列表
    /// </summary>
    public partial class GetNoticeListEvaluator : Evaluator
    {
        public override string Comments=> "获取Notice列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<NoticeSearchModel>() ?? new NoticeSearchModel();
                var query = ctx.Notice.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// NTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.NTitle)) query = query.Where(t=>t.NTitle.Contains(searchModel.NTitle));
                if(sort=="NTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NTitle):query.OrderByDescending(t=>t.NTitle);
                    isordered = true;
                }
				// NContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.NContent)) query = query.Where(t=>t.NContent.Contains(searchModel.NContent));
                if(sort=="NContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NContent):query.OrderByDescending(t=>t.NContent);
                    isordered = true;
                }
				// NAuthor NVARCHAR(50) 作者 
                if(!string.IsNullOrEmpty(searchModel.NAuthor)) query = query.Where(t=>t.NAuthor.Contains(searchModel.NAuthor));
                if(sort=="NAuthor")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NAuthor):query.OrderByDescending(t=>t.NAuthor);
                    isordered = true;
                }
				// NNotificationOfDateOfDispatch DATETIME 通知发送日期 
                if(searchModel.FromNNotificationOfDateOfDispatch!=null) query = query.Where(t=>t.NNotificationOfDateOfDispatch>=searchModel.FromNNotificationOfDateOfDispatch);
                if(searchModel.ToNNotificationOfDateOfDispatch!=null) query = query.Where(t=>t.NNotificationOfDateOfDispatch<=searchModel.ToNNotificationOfDateOfDispatch);
                if(sort=="NNotificationOfDateOfDispatch")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NNotificationOfDateOfDispatch):query.OrderByDescending(t=>t.NNotificationOfDateOfDispatch);
                    isordered = true;
                }
				// NNotificationSenderObject NVARCHAR(50) 通知发送对象 
                if(!string.IsNullOrEmpty(searchModel.NNotificationSenderObject)) query = query.Where(t=>t.NNotificationSenderObject.Contains(searchModel.NNotificationSenderObject));
                if(sort=="NNotificationSenderObject")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NNotificationSenderObject):query.OrderByDescending(t=>t.NNotificationSenderObject);
                    isordered = true;
                }
				// NRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.NRemarks)) query = query.Where(t=>t.NRemarks.Contains(searchModel.NRemarks));
                if(sort=="NRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NRemarks):query.OrderByDescending(t=>t.NRemarks);
                    isordered = true;
                }
				// NAbstract NVARCHAR(4000) 摘要 
                if(!string.IsNullOrEmpty(searchModel.NAbstract)) query = query.Where(t=>t.NAbstract.Contains(searchModel.NAbstract));
                if(sort=="NAbstract")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NAbstract):query.OrderByDescending(t=>t.NAbstract);
                    isordered = true;
                }
				// NPicture NVARCHAR(4000) 图片 
                if(!string.IsNullOrEmpty(searchModel.NPicture)) query = query.Where(t=>t.NPicture.Contains(searchModel.NPicture));
                if(sort=="NPicture")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NPicture):query.OrderByDescending(t=>t.NPicture);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.NTitle.Contains(search)||t.NContent.Contains(search)||t.NAuthor.Contains(search)||t.NNotificationSenderObject.Contains(search)||t.NRemarks.Contains(search)||t.NAbstract.Contains(search)||t.NPicture.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Notice>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【文档管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class DocumentManagementCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.DocumentManagement.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【文档管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【文档管理】
    /// </summary>
    public partial class DeleteDocumentManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<DocumentManagement>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.DocumentManagement.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.DocumentManagement.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条文档管理记录";
    }
	
    /// <summary>
    /// 保存【文档管理】
    /// </summary>
    public partial class SaveDocumentManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<DocumentManagement>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.DocumentManagement.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.DocumentManagement.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.DMTitle = HttpUtility.UrlDecode(entity.DMTitle);
					// NVARCHAR(4000)
				entity.DMContent = HttpUtility.UrlDecode(entity.DMContent);
					// NVARCHAR(50)
				entity.DMAuthor = HttpUtility.UrlDecode(entity.DMAuthor);
					// NVARCHAR(4000)
				entity.DMOriginalPicture = HttpUtility.UrlDecode(entity.DMOriginalPicture);
					// NVARCHAR(4000)
				entity.DMRemarks = HttpUtility.UrlDecode(entity.DMRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.DocumentManagement.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条DocumentManagement记录";
    }
	
    /// <summary>
    /// 查询空的【文档管理】
    /// </summary>
    public partial class GetDocumentManagementEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new DocumentManagement();
        }
        public override string Comments=> "获取空的文档管理记录";
    }
	
    /// <summary>
    /// 查询【文档管理】列表
    /// </summary>
    public partial class GetDocumentManagementListEvaluator : Evaluator
    {
        public override string Comments=> "获取DocumentManagement列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<DocumentManagementSearchModel>() ?? new DocumentManagementSearchModel();
                var query = ctx.DocumentManagement.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// DMTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.DMTitle)) query = query.Where(t=>t.DMTitle.Contains(searchModel.DMTitle));
                if(sort=="DMTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DMTitle):query.OrderByDescending(t=>t.DMTitle);
                    isordered = true;
                }
				// DMContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.DMContent)) query = query.Where(t=>t.DMContent.Contains(searchModel.DMContent));
                if(sort=="DMContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DMContent):query.OrderByDescending(t=>t.DMContent);
                    isordered = true;
                }
				// DMAuthor NVARCHAR(50) 作者 
                if(!string.IsNullOrEmpty(searchModel.DMAuthor)) query = query.Where(t=>t.DMAuthor.Contains(searchModel.DMAuthor));
                if(sort=="DMAuthor")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DMAuthor):query.OrderByDescending(t=>t.DMAuthor);
                    isordered = true;
                }
				// DMOriginalPicture NVARCHAR(4000) 原件图片 
                if(!string.IsNullOrEmpty(searchModel.DMOriginalPicture)) query = query.Where(t=>t.DMOriginalPicture.Contains(searchModel.DMOriginalPicture));
                if(sort=="DMOriginalPicture")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DMOriginalPicture):query.OrderByDescending(t=>t.DMOriginalPicture);
                    isordered = true;
                }
				// DMRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.DMRemarks)) query = query.Where(t=>t.DMRemarks.Contains(searchModel.DMRemarks));
                if(sort=="DMRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DMRemarks):query.OrderByDescending(t=>t.DMRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.DMTitle.Contains(search)||t.DMContent.Contains(search)||t.DMAuthor.Contains(search)||t.DMOriginalPicture.Contains(search)||t.DMRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<DocumentManagement>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【人口】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PopulationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Population.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【人口】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【人口】
    /// </summary>
    public partial class DeletePopulationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Population>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Population.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Population.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条人口记录";
    }
	
    /// <summary>
    /// 保存【人口】
    /// </summary>
    public partial class SavePopulationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Population>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Population.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Population.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.PCitizenshipNumber = HttpUtility.UrlDecode(entity.PCitizenshipNumber);
					// NVARCHAR(50)
				entity.PFullName = HttpUtility.UrlDecode(entity.PFullName);
					// NVARCHAR(50)
				entity.PGender = HttpUtility.UrlDecode(entity.PGender);
					// NVARCHAR(50)
				entity.PNeighborhoodVillageCommittee = HttpUtility.UrlDecode(entity.PNeighborhoodVillageCommittee);
					// NVARCHAR(50)
				entity.PAddress = HttpUtility.UrlDecode(entity.PAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Population.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Population记录";
    }
	
    /// <summary>
    /// 查询空的【人口】
    /// </summary>
    public partial class GetPopulationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Population();
        }
        public override string Comments=> "获取空的人口记录";
    }
	
    /// <summary>
    /// 查询【人口】列表
    /// </summary>
    public partial class GetPopulationListEvaluator : Evaluator
    {
        public override string Comments=> "获取Population列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PopulationSearchModel>() ?? new PopulationSearchModel();
                var query = ctx.Population.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PCitizenshipNumber NVARCHAR(50) 公民身份号码 
                if(!string.IsNullOrEmpty(searchModel.PCitizenshipNumber)) query = query.Where(t=>t.PCitizenshipNumber.Contains(searchModel.PCitizenshipNumber));
                if(sort=="PCitizenshipNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PCitizenshipNumber):query.OrderByDescending(t=>t.PCitizenshipNumber);
                    isordered = true;
                }
				// PFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.PFullName)) query = query.Where(t=>t.PFullName.Contains(searchModel.PFullName));
                if(sort=="PFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PFullName):query.OrderByDescending(t=>t.PFullName);
                    isordered = true;
                }
				// PGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.PGender)) query = query.Where(t=>t.PGender.Contains(searchModel.PGender));
                if(sort=="PGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PGender):query.OrderByDescending(t=>t.PGender);
                    isordered = true;
                }
				// PDateOfBirth DATETIME 出生日期 
                if(searchModel.FromPDateOfBirth!=null) query = query.Where(t=>t.PDateOfBirth>=searchModel.FromPDateOfBirth);
                if(searchModel.ToPDateOfBirth!=null) query = query.Where(t=>t.PDateOfBirth<=searchModel.ToPDateOfBirth);
                if(sort=="PDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PDateOfBirth):query.OrderByDescending(t=>t.PDateOfBirth);
                    isordered = true;
                }
				// PNeighborhoodVillageCommittee NVARCHAR(50) 居村委会 
                if(!string.IsNullOrEmpty(searchModel.PNeighborhoodVillageCommittee)) query = query.Where(t=>t.PNeighborhoodVillageCommittee.Contains(searchModel.PNeighborhoodVillageCommittee));
                if(sort=="PNeighborhoodVillageCommittee")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PNeighborhoodVillageCommittee):query.OrderByDescending(t=>t.PNeighborhoodVillageCommittee);
                    isordered = true;
                }
				// PAddress NVARCHAR(50) 住址 
                if(!string.IsNullOrEmpty(searchModel.PAddress)) query = query.Where(t=>t.PAddress.Contains(searchModel.PAddress));
                if(sort=="PAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAddress):query.OrderByDescending(t=>t.PAddress);
                    isordered = true;
                }
				// PAge INT 年龄 
                if(searchModel.MinPAge!=null) query = query.Where(t=>t.PAge>=searchModel.MinPAge);
                if(searchModel.MaxPAge!=null) query = query.Where(t=>t.PAge<=searchModel.MaxPAge);
                if(sort=="PAge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAge):query.OrderByDescending(t=>t.PAge);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PCitizenshipNumber.Contains(search)||t.PFullName.Contains(search)||t.PGender.Contains(search)||t.PNeighborhoodVillageCommittee.Contains(search)||t.PAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Population>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【新生儿】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class NewbornCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Newborn.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【新生儿】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【新生儿】
    /// </summary>
    public partial class DeleteNewbornEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Newborn>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Newborn.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Newborn.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条新生儿记录";
    }
	
    /// <summary>
    /// 保存【新生儿】
    /// </summary>
    public partial class SaveNewbornEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Newborn>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Newborn.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Newborn.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.NCitizenshipNumber = HttpUtility.UrlDecode(entity.NCitizenshipNumber);
					// NVARCHAR(50)
				entity.NFullName = HttpUtility.UrlDecode(entity.NFullName);
					// NVARCHAR(50)
				entity.NGender = HttpUtility.UrlDecode(entity.NGender);
					// NVARCHAR(50)
				entity.NNeighborhoodVillageCommittee = HttpUtility.UrlDecode(entity.NNeighborhoodVillageCommittee);
					// NVARCHAR(50)
				entity.NAddress = HttpUtility.UrlDecode(entity.NAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Newborn.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Newborn记录";
    }
	
    /// <summary>
    /// 查询空的【新生儿】
    /// </summary>
    public partial class GetNewbornEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Newborn();
        }
        public override string Comments=> "获取空的新生儿记录";
    }
	
    /// <summary>
    /// 查询【新生儿】列表
    /// </summary>
    public partial class GetNewbornListEvaluator : Evaluator
    {
        public override string Comments=> "获取Newborn列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<NewbornSearchModel>() ?? new NewbornSearchModel();
                var query = ctx.Newborn.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// NCitizenshipNumber NVARCHAR(50) 公民身份号码 
                if(!string.IsNullOrEmpty(searchModel.NCitizenshipNumber)) query = query.Where(t=>t.NCitizenshipNumber.Contains(searchModel.NCitizenshipNumber));
                if(sort=="NCitizenshipNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NCitizenshipNumber):query.OrderByDescending(t=>t.NCitizenshipNumber);
                    isordered = true;
                }
				// NFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.NFullName)) query = query.Where(t=>t.NFullName.Contains(searchModel.NFullName));
                if(sort=="NFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NFullName):query.OrderByDescending(t=>t.NFullName);
                    isordered = true;
                }
				// NGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.NGender)) query = query.Where(t=>t.NGender.Contains(searchModel.NGender));
                if(sort=="NGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NGender):query.OrderByDescending(t=>t.NGender);
                    isordered = true;
                }
				// NDateOfBirth DATETIME 出生日期 
                if(searchModel.FromNDateOfBirth!=null) query = query.Where(t=>t.NDateOfBirth>=searchModel.FromNDateOfBirth);
                if(searchModel.ToNDateOfBirth!=null) query = query.Where(t=>t.NDateOfBirth<=searchModel.ToNDateOfBirth);
                if(sort=="NDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NDateOfBirth):query.OrderByDescending(t=>t.NDateOfBirth);
                    isordered = true;
                }
				// NNeighborhoodVillageCommittee NVARCHAR(50) 居村委会 
                if(!string.IsNullOrEmpty(searchModel.NNeighborhoodVillageCommittee)) query = query.Where(t=>t.NNeighborhoodVillageCommittee.Contains(searchModel.NNeighborhoodVillageCommittee));
                if(sort=="NNeighborhoodVillageCommittee")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NNeighborhoodVillageCommittee):query.OrderByDescending(t=>t.NNeighborhoodVillageCommittee);
                    isordered = true;
                }
				// NAddress NVARCHAR(50) 住址 
                if(!string.IsNullOrEmpty(searchModel.NAddress)) query = query.Where(t=>t.NAddress.Contains(searchModel.NAddress));
                if(sort=="NAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NAddress):query.OrderByDescending(t=>t.NAddress);
                    isordered = true;
                }
				// NAge INT 年龄 
                if(searchModel.MinNAge!=null) query = query.Where(t=>t.NAge>=searchModel.MinNAge);
                if(searchModel.MaxNAge!=null) query = query.Where(t=>t.NAge<=searchModel.MaxNAge);
                if(sort=="NAge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.NAge):query.OrderByDescending(t=>t.NAge);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.NCitizenshipNumber.Contains(search)||t.NFullName.Contains(search)||t.NGender.Contains(search)||t.NNeighborhoodVillageCommittee.Contains(search)||t.NAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Newborn>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【房产】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class HousePropertyCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.HouseProperty.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【房产】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【房产】
    /// </summary>
    public partial class DeleteHousePropertyEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<HouseProperty>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.HouseProperty.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.HouseProperty.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条房产记录";
    }
	
    /// <summary>
    /// 保存【房产】
    /// </summary>
    public partial class SaveHousePropertyEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<HouseProperty>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.HouseProperty.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.HouseProperty.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.HPId = HttpUtility.UrlDecode(entity.HPId);
					// NVARCHAR(4000)
				entity.HPAddress = HttpUtility.UrlDecode(entity.HPAddress);
					// NVARCHAR(50)
				entity.HPBuildingNumber = HttpUtility.UrlDecode(entity.HPBuildingNumber);
					// NVARCHAR(50)
				entity.HPUnitNumber = HttpUtility.UrlDecode(entity.HPUnitNumber);
					// NVARCHAR(50)
				entity.HPHouseNumber = HttpUtility.UrlDecode(entity.HPHouseNumber);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.HouseProperty.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条HouseProperty记录";
    }
	
    /// <summary>
    /// 查询空的【房产】
    /// </summary>
    public partial class GetHousePropertyEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new HouseProperty();
        }
        public override string Comments=> "获取空的房产记录";
    }
	
    /// <summary>
    /// 查询【房产】列表
    /// </summary>
    public partial class GetHousePropertyListEvaluator : Evaluator
    {
        public override string Comments=> "获取HouseProperty列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<HousePropertySearchModel>() ?? new HousePropertySearchModel();
                var query = ctx.HouseProperty.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// HPId NVARCHAR(4000) 身份证 
                if(!string.IsNullOrEmpty(searchModel.HPId)) query = query.Where(t=>t.HPId.Contains(searchModel.HPId));
                if(sort=="HPId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HPId):query.OrderByDescending(t=>t.HPId);
                    isordered = true;
                }
				// HPAddress NVARCHAR(4000) 地址 
                if(!string.IsNullOrEmpty(searchModel.HPAddress)) query = query.Where(t=>t.HPAddress.Contains(searchModel.HPAddress));
                if(sort=="HPAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HPAddress):query.OrderByDescending(t=>t.HPAddress);
                    isordered = true;
                }
				// HPBuildingNumber NVARCHAR(50) 楼栋号 
                if(!string.IsNullOrEmpty(searchModel.HPBuildingNumber)) query = query.Where(t=>t.HPBuildingNumber.Contains(searchModel.HPBuildingNumber));
                if(sort=="HPBuildingNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HPBuildingNumber):query.OrderByDescending(t=>t.HPBuildingNumber);
                    isordered = true;
                }
				// HPUnitNumber NVARCHAR(50) 单元号 
                if(!string.IsNullOrEmpty(searchModel.HPUnitNumber)) query = query.Where(t=>t.HPUnitNumber.Contains(searchModel.HPUnitNumber));
                if(sort=="HPUnitNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HPUnitNumber):query.OrderByDescending(t=>t.HPUnitNumber);
                    isordered = true;
                }
				// HPHouseNumber NVARCHAR(50) 门牌号 
                if(!string.IsNullOrEmpty(searchModel.HPHouseNumber)) query = query.Where(t=>t.HPHouseNumber.Contains(searchModel.HPHouseNumber));
                if(sort=="HPHouseNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HPHouseNumber):query.OrderByDescending(t=>t.HPHouseNumber);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.HPId.Contains(search)||t.HPAddress.Contains(search)||t.HPBuildingNumber.Contains(search)||t.HPUnitNumber.Contains(search)||t.HPHouseNumber.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<HouseProperty>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【报销清单】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ReimbursementListCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ReimbursementList.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【报销清单】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【报销清单】
    /// </summary>
    public partial class DeleteReimbursementListEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ReimbursementList>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ReimbursementList.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ReimbursementList.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条报销清单记录";
    }
	
    /// <summary>
    /// 保存【报销清单】
    /// </summary>
    public partial class SaveReimbursementListEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ReimbursementList>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ReimbursementList.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ReimbursementList.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.RLFullName = HttpUtility.UrlDecode(entity.RLFullName);
					// NVARCHAR(50)
				entity.RLStartingPosition = HttpUtility.UrlDecode(entity.RLStartingPosition);
					// NVARCHAR(50)
				entity.RLDestinationLocation = HttpUtility.UrlDecode(entity.RLDestinationLocation);
					// NVARCHAR(50)
				entity.RLTrafficExpense = HttpUtility.UrlDecode(entity.RLTrafficExpense);
					// NVARCHAR(50)
				entity.RLHotelExpense = HttpUtility.UrlDecode(entity.RLHotelExpense);
					// NVARCHAR(50)
				entity.RLAccommodationAllowance = HttpUtility.UrlDecode(entity.RLAccommodationAllowance);
					// NVARCHAR(50)
				entity.RLBusFare = HttpUtility.UrlDecode(entity.RLBusFare);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ReimbursementList.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ReimbursementList记录";
    }
	
    /// <summary>
    /// 查询空的【报销清单】
    /// </summary>
    public partial class GetReimbursementListEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ReimbursementList();
        }
        public override string Comments=> "获取空的报销清单记录";
    }
	
    /// <summary>
    /// 查询【报销清单】列表
    /// </summary>
    public partial class GetReimbursementListListEvaluator : Evaluator
    {
        public override string Comments=> "获取ReimbursementList列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ReimbursementListSearchModel>() ?? new ReimbursementListSearchModel();
                var query = ctx.ReimbursementList.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// RLFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.RLFullName)) query = query.Where(t=>t.RLFullName.Contains(searchModel.RLFullName));
                if(sort=="RLFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RLFullName):query.OrderByDescending(t=>t.RLFullName);
                    isordered = true;
                }
				// RLStartingPosition NVARCHAR(50) 出发位置 
                if(!string.IsNullOrEmpty(searchModel.RLStartingPosition)) query = query.Where(t=>t.RLStartingPosition.Contains(searchModel.RLStartingPosition));
                if(sort=="RLStartingPosition")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RLStartingPosition):query.OrderByDescending(t=>t.RLStartingPosition);
                    isordered = true;
                }
				// RLDestinationLocation NVARCHAR(50) 目的地位置 
                if(!string.IsNullOrEmpty(searchModel.RLDestinationLocation)) query = query.Where(t=>t.RLDestinationLocation.Contains(searchModel.RLDestinationLocation));
                if(sort=="RLDestinationLocation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RLDestinationLocation):query.OrderByDescending(t=>t.RLDestinationLocation);
                    isordered = true;
                }
				// RLTrafficExpense NVARCHAR(50) 交通费 
                if(!string.IsNullOrEmpty(searchModel.RLTrafficExpense)) query = query.Where(t=>t.RLTrafficExpense.Contains(searchModel.RLTrafficExpense));
                if(sort=="RLTrafficExpense")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RLTrafficExpense):query.OrderByDescending(t=>t.RLTrafficExpense);
                    isordered = true;
                }
				// RLHotelExpense NVARCHAR(50) 住宿费 
                if(!string.IsNullOrEmpty(searchModel.RLHotelExpense)) query = query.Where(t=>t.RLHotelExpense.Contains(searchModel.RLHotelExpense));
                if(sort=="RLHotelExpense")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RLHotelExpense):query.OrderByDescending(t=>t.RLHotelExpense);
                    isordered = true;
                }
				// RLAccommodationAllowance NVARCHAR(50) 住勤补贴 
                if(!string.IsNullOrEmpty(searchModel.RLAccommodationAllowance)) query = query.Where(t=>t.RLAccommodationAllowance.Contains(searchModel.RLAccommodationAllowance));
                if(sort=="RLAccommodationAllowance")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RLAccommodationAllowance):query.OrderByDescending(t=>t.RLAccommodationAllowance);
                    isordered = true;
                }
				// RLBusFare NVARCHAR(50) 公交费 
                if(!string.IsNullOrEmpty(searchModel.RLBusFare)) query = query.Where(t=>t.RLBusFare.Contains(searchModel.RLBusFare));
                if(sort=="RLBusFare")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RLBusFare):query.OrderByDescending(t=>t.RLBusFare);
                    isordered = true;
                }
				// RLDateOfReimbursement DATETIME 报销日期 
                if(searchModel.FromRLDateOfReimbursement!=null) query = query.Where(t=>t.RLDateOfReimbursement>=searchModel.FromRLDateOfReimbursement);
                if(searchModel.ToRLDateOfReimbursement!=null) query = query.Where(t=>t.RLDateOfReimbursement<=searchModel.ToRLDateOfReimbursement);
                if(sort=="RLDateOfReimbursement")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RLDateOfReimbursement):query.OrderByDescending(t=>t.RLDateOfReimbursement);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.RLFullName.Contains(search)||t.RLStartingPosition.Contains(search)||t.RLDestinationLocation.Contains(search)||t.RLTrafficExpense.Contains(search)||t.RLHotelExpense.Contains(search)||t.RLAccommodationAllowance.Contains(search)||t.RLBusFare.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ReimbursementList>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【通讯录】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class MailListCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.MailList.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【通讯录】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【通讯录】
    /// </summary>
    public partial class DeleteMailListEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<MailList>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.MailList.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.MailList.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条通讯录记录";
    }
	
    /// <summary>
    /// 保存【通讯录】
    /// </summary>
    public partial class SaveMailListEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<MailList>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.MailList.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.MailList.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.MLOrganizationName = HttpUtility.UrlDecode(entity.MLOrganizationName);
					// NVARCHAR(50)
				entity.MLPersonnelName = HttpUtility.UrlDecode(entity.MLPersonnelName);
					// NVARCHAR(4000)
				entity.MLId = HttpUtility.UrlDecode(entity.MLId);
					// NVARCHAR(50)
				entity.MLGender = HttpUtility.UrlDecode(entity.MLGender);
					// NVARCHAR(50)
				entity.MLTelephone = HttpUtility.UrlDecode(entity.MLTelephone);
					// NVARCHAR(50)
				entity.MLMobilePhone = HttpUtility.UrlDecode(entity.MLMobilePhone);
					// NVARCHAR(50)
				entity.MLMailbox = HttpUtility.UrlDecode(entity.MLMailbox);
					// NVARCHAR(50)
				entity.MLPosition = HttpUtility.UrlDecode(entity.MLPosition);
					// NVARCHAR(50)
				entity.MLSuperiorLeader = HttpUtility.UrlDecode(entity.MLSuperiorLeader);
					// NVARCHAR(50)
				entity.MLQq = HttpUtility.UrlDecode(entity.MLQq);
					// NVARCHAR(50)
				entity.MLWechat = HttpUtility.UrlDecode(entity.MLWechat);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.MailList.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条MailList记录";
    }
	
    /// <summary>
    /// 查询空的【通讯录】
    /// </summary>
    public partial class GetMailListEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new MailList();
        }
        public override string Comments=> "获取空的通讯录记录";
    }
	
    /// <summary>
    /// 查询【通讯录】列表
    /// </summary>
    public partial class GetMailListListEvaluator : Evaluator
    {
        public override string Comments=> "获取MailList列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<MailListSearchModel>() ?? new MailListSearchModel();
                var query = ctx.MailList.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// MLOrganizationName NVARCHAR(50) 机构名称 
                if(!string.IsNullOrEmpty(searchModel.MLOrganizationName)) query = query.Where(t=>t.MLOrganizationName.Contains(searchModel.MLOrganizationName));
                if(sort=="MLOrganizationName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLOrganizationName):query.OrderByDescending(t=>t.MLOrganizationName);
                    isordered = true;
                }
				// MLPersonnelName NVARCHAR(50) 人员姓名 
                if(!string.IsNullOrEmpty(searchModel.MLPersonnelName)) query = query.Where(t=>t.MLPersonnelName.Contains(searchModel.MLPersonnelName));
                if(sort=="MLPersonnelName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLPersonnelName):query.OrderByDescending(t=>t.MLPersonnelName);
                    isordered = true;
                }
				// MLId NVARCHAR(4000) 身份证 
                if(!string.IsNullOrEmpty(searchModel.MLId)) query = query.Where(t=>t.MLId.Contains(searchModel.MLId));
                if(sort=="MLId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLId):query.OrderByDescending(t=>t.MLId);
                    isordered = true;
                }
				// MLGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.MLGender)) query = query.Where(t=>t.MLGender.Contains(searchModel.MLGender));
                if(sort=="MLGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLGender):query.OrderByDescending(t=>t.MLGender);
                    isordered = true;
                }
				// MLTelephone NVARCHAR(50) 电话 
                if(!string.IsNullOrEmpty(searchModel.MLTelephone)) query = query.Where(t=>t.MLTelephone.Contains(searchModel.MLTelephone));
                if(sort=="MLTelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLTelephone):query.OrderByDescending(t=>t.MLTelephone);
                    isordered = true;
                }
				// MLMobilePhone NVARCHAR(50) 手机 
                if(!string.IsNullOrEmpty(searchModel.MLMobilePhone)) query = query.Where(t=>t.MLMobilePhone.Contains(searchModel.MLMobilePhone));
                if(sort=="MLMobilePhone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLMobilePhone):query.OrderByDescending(t=>t.MLMobilePhone);
                    isordered = true;
                }
				// MLMailbox NVARCHAR(50) 邮箱 
                if(!string.IsNullOrEmpty(searchModel.MLMailbox)) query = query.Where(t=>t.MLMailbox.Contains(searchModel.MLMailbox));
                if(sort=="MLMailbox")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLMailbox):query.OrderByDescending(t=>t.MLMailbox);
                    isordered = true;
                }
				// MLPosition NVARCHAR(50) 职位 
                if(!string.IsNullOrEmpty(searchModel.MLPosition)) query = query.Where(t=>t.MLPosition.Contains(searchModel.MLPosition));
                if(sort=="MLPosition")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLPosition):query.OrderByDescending(t=>t.MLPosition);
                    isordered = true;
                }
				// MLSuperiorLeader NVARCHAR(50) 上级领导 
                if(!string.IsNullOrEmpty(searchModel.MLSuperiorLeader)) query = query.Where(t=>t.MLSuperiorLeader.Contains(searchModel.MLSuperiorLeader));
                if(sort=="MLSuperiorLeader")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLSuperiorLeader):query.OrderByDescending(t=>t.MLSuperiorLeader);
                    isordered = true;
                }
				// MLQq NVARCHAR(50) QQ 
                if(!string.IsNullOrEmpty(searchModel.MLQq)) query = query.Where(t=>t.MLQq.Contains(searchModel.MLQq));
                if(sort=="MLQq")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLQq):query.OrderByDescending(t=>t.MLQq);
                    isordered = true;
                }
				// MLWechat NVARCHAR(50) 微信 
                if(!string.IsNullOrEmpty(searchModel.MLWechat)) query = query.Where(t=>t.MLWechat.Contains(searchModel.MLWechat));
                if(sort=="MLWechat")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MLWechat):query.OrderByDescending(t=>t.MLWechat);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.MLOrganizationName.Contains(search)||t.MLPersonnelName.Contains(search)||t.MLId.Contains(search)||t.MLGender.Contains(search)||t.MLTelephone.Contains(search)||t.MLMobilePhone.Contains(search)||t.MLMailbox.Contains(search)||t.MLPosition.Contains(search)||t.MLSuperiorLeader.Contains(search)||t.MLQq.Contains(search)||t.MLWechat.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<MailList>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【Poi】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PoiCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Poi.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【Poi】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【Poi】
    /// </summary>
    public partial class DeletePoiEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Poi>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Poi.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Poi.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条Poi记录";
    }
	
    /// <summary>
    /// 保存【Poi】
    /// </summary>
    public partial class SavePoiEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Poi>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Poi.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Poi.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.PAddress = HttpUtility.UrlDecode(entity.PAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Poi.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Poi记录";
    }
	
    /// <summary>
    /// 查询空的【Poi】
    /// </summary>
    public partial class GetPoiEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Poi();
        }
        public override string Comments=> "获取空的Poi记录";
    }
	
    /// <summary>
    /// 查询【Poi】列表
    /// </summary>
    public partial class GetPoiListEvaluator : Evaluator
    {
        public override string Comments=> "获取Poi列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PoiSearchModel>() ?? new PoiSearchModel();
                var query = ctx.Poi.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PAddress NVARCHAR(4000) 地址 
                if(!string.IsNullOrEmpty(searchModel.PAddress)) query = query.Where(t=>t.PAddress.Contains(searchModel.PAddress));
                if(sort=="PAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAddress):query.OrderByDescending(t=>t.PAddress);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Poi>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党建要闻管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ManagementOfPartyBuildingNewsCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ManagementOfPartyBuildingNews.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党建要闻管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党建要闻管理】
    /// </summary>
    public partial class DeleteManagementOfPartyBuildingNewsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ManagementOfPartyBuildingNews>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ManagementOfPartyBuildingNews.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ManagementOfPartyBuildingNews.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党建要闻管理记录";
    }
	
    /// <summary>
    /// 保存【党建要闻管理】
    /// </summary>
    public partial class SaveManagementOfPartyBuildingNewsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ManagementOfPartyBuildingNews>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ManagementOfPartyBuildingNews.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ManagementOfPartyBuildingNews.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.MOPBNTitle = HttpUtility.UrlDecode(entity.MOPBNTitle);
					// NVARCHAR(4000)
				entity.MOPBNContent = HttpUtility.UrlDecode(entity.MOPBNContent);
					// NVARCHAR(50)
				entity.MOPBNAuthor = HttpUtility.UrlDecode(entity.MOPBNAuthor);
					// NVARCHAR(50)
				entity.MOPBNCategory = HttpUtility.UrlDecode(entity.MOPBNCategory);
					// NVARCHAR(4000)
				entity.MOPBNPicture = HttpUtility.UrlDecode(entity.MOPBNPicture);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ManagementOfPartyBuildingNews.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ManagementOfPartyBuildingNews记录";
    }
	
    /// <summary>
    /// 查询空的【党建要闻管理】
    /// </summary>
    public partial class GetManagementOfPartyBuildingNewsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ManagementOfPartyBuildingNews();
        }
        public override string Comments=> "获取空的党建要闻管理记录";
    }
	
    /// <summary>
    /// 查询【党建要闻管理】列表
    /// </summary>
    public partial class GetManagementOfPartyBuildingNewsListEvaluator : Evaluator
    {
        public override string Comments=> "获取ManagementOfPartyBuildingNews列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ManagementOfPartyBuildingNewsSearchModel>() ?? new ManagementOfPartyBuildingNewsSearchModel();
                var query = ctx.ManagementOfPartyBuildingNews.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// MOPBNTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.MOPBNTitle)) query = query.Where(t=>t.MOPBNTitle.Contains(searchModel.MOPBNTitle));
                if(sort=="MOPBNTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPBNTitle):query.OrderByDescending(t=>t.MOPBNTitle);
                    isordered = true;
                }
				// MOPBNContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.MOPBNContent)) query = query.Where(t=>t.MOPBNContent.Contains(searchModel.MOPBNContent));
                if(sort=="MOPBNContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPBNContent):query.OrderByDescending(t=>t.MOPBNContent);
                    isordered = true;
                }
				// MOPBNAuthor NVARCHAR(50) 作者 
                if(!string.IsNullOrEmpty(searchModel.MOPBNAuthor)) query = query.Where(t=>t.MOPBNAuthor.Contains(searchModel.MOPBNAuthor));
                if(sort=="MOPBNAuthor")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPBNAuthor):query.OrderByDescending(t=>t.MOPBNAuthor);
                    isordered = true;
                }
				// MOPBNReleaseTime DATETIME 发布时间 
                if(searchModel.FromMOPBNReleaseTime!=null) query = query.Where(t=>t.MOPBNReleaseTime>=searchModel.FromMOPBNReleaseTime);
                if(searchModel.ToMOPBNReleaseTime!=null) query = query.Where(t=>t.MOPBNReleaseTime<=searchModel.ToMOPBNReleaseTime);
                if(sort=="MOPBNReleaseTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPBNReleaseTime):query.OrderByDescending(t=>t.MOPBNReleaseTime);
                    isordered = true;
                }
				// MOPBNCategory NVARCHAR(50) 类别 
                if(!string.IsNullOrEmpty(searchModel.MOPBNCategory)) query = query.Where(t=>t.MOPBNCategory.Contains(searchModel.MOPBNCategory));
                if(sort=="MOPBNCategory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPBNCategory):query.OrderByDescending(t=>t.MOPBNCategory);
                    isordered = true;
                }
				// MOPBNPicture NVARCHAR(4000) 图片 
                if(!string.IsNullOrEmpty(searchModel.MOPBNPicture)) query = query.Where(t=>t.MOPBNPicture.Contains(searchModel.MOPBNPicture));
                if(sort=="MOPBNPicture")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPBNPicture):query.OrderByDescending(t=>t.MOPBNPicture);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.MOPBNTitle.Contains(search)||t.MOPBNContent.Contains(search)||t.MOPBNAuthor.Contains(search)||t.MOPBNCategory.Contains(search)||t.MOPBNPicture.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ManagementOfPartyBuildingNews>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【随手拍】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class FreeToShootCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.FreeToShoot.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【随手拍】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【随手拍】
    /// </summary>
    public partial class DeleteFreeToShootEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<FreeToShoot>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.FreeToShoot.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.FreeToShoot.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条随手拍记录";
    }
	
    /// <summary>
    /// 保存【随手拍】
    /// </summary>
    public partial class SaveFreeToShootEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<FreeToShoot>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.FreeToShoot.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.FreeToShoot.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.FTSContent = HttpUtility.UrlDecode(entity.FTSContent);
					// NVARCHAR(50)
				entity.FTSEquipment = HttpUtility.UrlDecode(entity.FTSEquipment);
					// NVARCHAR(50)
				entity.FTSUserId = HttpUtility.UrlDecode(entity.FTSUserId);
					// NVARCHAR(4000)
				entity.FTSPhoto = HttpUtility.UrlDecode(entity.FTSPhoto);
					// NVARCHAR(50)
				entity.FTSPosition = HttpUtility.UrlDecode(entity.FTSPosition);
					// NVARCHAR(50)
				entity.FTSFullName = HttpUtility.UrlDecode(entity.FTSFullName);
					// NVARCHAR(50)
				entity.FTSTelephone = HttpUtility.UrlDecode(entity.FTSTelephone);
					// NVARCHAR(50)
				entity.FTSRegion = HttpUtility.UrlDecode(entity.FTSRegion);
					// NVARCHAR(50)
				entity.FTSNumberOfPoints = HttpUtility.UrlDecode(entity.FTSNumberOfPoints);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.FreeToShoot.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条FreeToShoot记录";
    }
	
    /// <summary>
    /// 查询空的【随手拍】
    /// </summary>
    public partial class GetFreeToShootEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new FreeToShoot();
        }
        public override string Comments=> "获取空的随手拍记录";
    }
	
    /// <summary>
    /// 查询【随手拍】列表
    /// </summary>
    public partial class GetFreeToShootListEvaluator : Evaluator
    {
        public override string Comments=> "获取FreeToShoot列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<FreeToShootSearchModel>() ?? new FreeToShootSearchModel();
                var query = ctx.FreeToShoot.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// FTSContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.FTSContent)) query = query.Where(t=>t.FTSContent.Contains(searchModel.FTSContent));
                if(sort=="FTSContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FTSContent):query.OrderByDescending(t=>t.FTSContent);
                    isordered = true;
                }
				// FTSEquipment NVARCHAR(50) 设备 
                if(!string.IsNullOrEmpty(searchModel.FTSEquipment)) query = query.Where(t=>t.FTSEquipment.Contains(searchModel.FTSEquipment));
                if(sort=="FTSEquipment")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FTSEquipment):query.OrderByDescending(t=>t.FTSEquipment);
                    isordered = true;
                }
				// FTSUserId NVARCHAR(50) 用户ID 
                if(!string.IsNullOrEmpty(searchModel.FTSUserId)) query = query.Where(t=>t.FTSUserId.Contains(searchModel.FTSUserId));
                if(sort=="FTSUserId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FTSUserId):query.OrderByDescending(t=>t.FTSUserId);
                    isordered = true;
                }
				// FTSPhoto NVARCHAR(4000) 照片 
                if(!string.IsNullOrEmpty(searchModel.FTSPhoto)) query = query.Where(t=>t.FTSPhoto.Contains(searchModel.FTSPhoto));
                if(sort=="FTSPhoto")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FTSPhoto):query.OrderByDescending(t=>t.FTSPhoto);
                    isordered = true;
                }
				// FTSPhotoop DATETIME 拍照时间 
                if(searchModel.FromFTSPhotoop!=null) query = query.Where(t=>t.FTSPhotoop>=searchModel.FromFTSPhotoop);
                if(searchModel.ToFTSPhotoop!=null) query = query.Where(t=>t.FTSPhotoop<=searchModel.ToFTSPhotoop);
                if(sort=="FTSPhotoop")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FTSPhotoop):query.OrderByDescending(t=>t.FTSPhotoop);
                    isordered = true;
                }
				// FTSPosition NVARCHAR(50) 位置 
                if(!string.IsNullOrEmpty(searchModel.FTSPosition)) query = query.Where(t=>t.FTSPosition.Contains(searchModel.FTSPosition));
                if(sort=="FTSPosition")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FTSPosition):query.OrderByDescending(t=>t.FTSPosition);
                    isordered = true;
                }
				// FTSFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.FTSFullName)) query = query.Where(t=>t.FTSFullName.Contains(searchModel.FTSFullName));
                if(sort=="FTSFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FTSFullName):query.OrderByDescending(t=>t.FTSFullName);
                    isordered = true;
                }
				// FTSTelephone NVARCHAR(50) 电话 
                if(!string.IsNullOrEmpty(searchModel.FTSTelephone)) query = query.Where(t=>t.FTSTelephone.Contains(searchModel.FTSTelephone));
                if(sort=="FTSTelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FTSTelephone):query.OrderByDescending(t=>t.FTSTelephone);
                    isordered = true;
                }
				// FTSRegion NVARCHAR(50) 区域 
                if(!string.IsNullOrEmpty(searchModel.FTSRegion)) query = query.Where(t=>t.FTSRegion.Contains(searchModel.FTSRegion));
                if(sort=="FTSRegion")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FTSRegion):query.OrderByDescending(t=>t.FTSRegion);
                    isordered = true;
                }
				// FTSNumberOfPoints NVARCHAR(50) 点赞数目 
                if(!string.IsNullOrEmpty(searchModel.FTSNumberOfPoints)) query = query.Where(t=>t.FTSNumberOfPoints.Contains(searchModel.FTSNumberOfPoints));
                if(sort=="FTSNumberOfPoints")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FTSNumberOfPoints):query.OrderByDescending(t=>t.FTSNumberOfPoints);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.FTSContent.Contains(search)||t.FTSEquipment.Contains(search)||t.FTSUserId.Contains(search)||t.FTSPhoto.Contains(search)||t.FTSPosition.Contains(search)||t.FTSFullName.Contains(search)||t.FTSTelephone.Contains(search)||t.FTSRegion.Contains(search)||t.FTSNumberOfPoints.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<FreeToShoot>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【主动巡检】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ActiveInspectionCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ActiveInspection.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【主动巡检】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【主动巡检】
    /// </summary>
    public partial class DeleteActiveInspectionEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ActiveInspection>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ActiveInspection.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ActiveInspection.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条主动巡检记录";
    }
	
    /// <summary>
    /// 保存【主动巡检】
    /// </summary>
    public partial class SaveActiveInspectionEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ActiveInspection>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ActiveInspection.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ActiveInspection.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.AIInspectionProblem = HttpUtility.UrlDecode(entity.AIInspectionProblem);
					// NVARCHAR(50)
				entity.AIState = HttpUtility.UrlDecode(entity.AIState);
					// NVARCHAR(50)
				entity.AIUser = HttpUtility.UrlDecode(entity.AIUser);
					// NVARCHAR(50)
				entity.AIRegion = HttpUtility.UrlDecode(entity.AIRegion);
					// NVARCHAR(4000)
				entity.AIPicture = HttpUtility.UrlDecode(entity.AIPicture);
					// NVARCHAR(50)
				entity.AIPosition = HttpUtility.UrlDecode(entity.AIPosition);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ActiveInspection.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ActiveInspection记录";
    }
	
    /// <summary>
    /// 查询空的【主动巡检】
    /// </summary>
    public partial class GetActiveInspectionEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ActiveInspection();
        }
        public override string Comments=> "获取空的主动巡检记录";
    }
	
    /// <summary>
    /// 查询【主动巡检】列表
    /// </summary>
    public partial class GetActiveInspectionListEvaluator : Evaluator
    {
        public override string Comments=> "获取ActiveInspection列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ActiveInspectionSearchModel>() ?? new ActiveInspectionSearchModel();
                var query = ctx.ActiveInspection.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// AIInspectionProblem NVARCHAR(50) 巡检问题 
                if(!string.IsNullOrEmpty(searchModel.AIInspectionProblem)) query = query.Where(t=>t.AIInspectionProblem.Contains(searchModel.AIInspectionProblem));
                if(sort=="AIInspectionProblem")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AIInspectionProblem):query.OrderByDescending(t=>t.AIInspectionProblem);
                    isordered = true;
                }
				// AICreationTime DATETIME 创建时间 
                if(searchModel.FromAICreationTime!=null) query = query.Where(t=>t.AICreationTime>=searchModel.FromAICreationTime);
                if(searchModel.ToAICreationTime!=null) query = query.Where(t=>t.AICreationTime<=searchModel.ToAICreationTime);
                if(sort=="AICreationTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AICreationTime):query.OrderByDescending(t=>t.AICreationTime);
                    isordered = true;
                }
				// AIState NVARCHAR(50) 状态 
                if(searchModel.AIState!=null && searchModel.AIState.Length!=0) query = query.Where(t=>searchModel.AIState.Contains(t.AIState));
                if(sort=="AIState")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AIState):query.OrderByDescending(t=>t.AIState);
                    isordered = true;
                }
				// AIUser NVARCHAR(50) 用户 
                if(!string.IsNullOrEmpty(searchModel.AIUser)) query = query.Where(t=>t.AIUser.Contains(searchModel.AIUser));
                if(sort=="AIUser")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AIUser):query.OrderByDescending(t=>t.AIUser);
                    isordered = true;
                }
				// AIRegion NVARCHAR(50) 区域 
                if(!string.IsNullOrEmpty(searchModel.AIRegion)) query = query.Where(t=>t.AIRegion.Contains(searchModel.AIRegion));
                if(sort=="AIRegion")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AIRegion):query.OrderByDescending(t=>t.AIRegion);
                    isordered = true;
                }
				// AIPicture NVARCHAR(4000) 图片 
                if(!string.IsNullOrEmpty(searchModel.AIPicture)) query = query.Where(t=>t.AIPicture.Contains(searchModel.AIPicture));
                if(sort=="AIPicture")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AIPicture):query.OrderByDescending(t=>t.AIPicture);
                    isordered = true;
                }
				// AIPosition NVARCHAR(50) 位置 
                if(!string.IsNullOrEmpty(searchModel.AIPosition)) query = query.Where(t=>t.AIPosition.Contains(searchModel.AIPosition));
                if(sort=="AIPosition")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AIPosition):query.OrderByDescending(t=>t.AIPosition);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.AIInspectionProblem.Contains(search)||t.AIState.Contains(search)||t.AIUser.Contains(search)||t.AIRegion.Contains(search)||t.AIPicture.Contains(search)||t.AIPosition.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ActiveInspection>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【业务预约】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class BusinessAppointmentCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.BusinessAppointment.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【业务预约】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【业务预约】
    /// </summary>
    public partial class DeleteBusinessAppointmentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<BusinessAppointment>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.BusinessAppointment.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.BusinessAppointment.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条业务预约记录";
    }
	
    /// <summary>
    /// 保存【业务预约】
    /// </summary>
    public partial class SaveBusinessAppointmentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<BusinessAppointment>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.BusinessAppointment.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.BusinessAppointment.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.BABusiness = HttpUtility.UrlDecode(entity.BABusiness);
					// NVARCHAR(50)
				entity.BAService = HttpUtility.UrlDecode(entity.BAService);
					// NVARCHAR(50)
				entity.BAFullName = HttpUtility.UrlDecode(entity.BAFullName);
					// NVARCHAR(4000)
				entity.BAId = HttpUtility.UrlDecode(entity.BAId);
					// NVARCHAR(50)
				entity.BATelephone = HttpUtility.UrlDecode(entity.BATelephone);
					// NVARCHAR(50)
				entity.BAState = HttpUtility.UrlDecode(entity.BAState);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.BusinessAppointment.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条BusinessAppointment记录";
    }
	
    /// <summary>
    /// 查询空的【业务预约】
    /// </summary>
    public partial class GetBusinessAppointmentEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new BusinessAppointment();
        }
        public override string Comments=> "获取空的业务预约记录";
    }
	
    /// <summary>
    /// 查询【业务预约】列表
    /// </summary>
    public partial class GetBusinessAppointmentListEvaluator : Evaluator
    {
        public override string Comments=> "获取BusinessAppointment列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<BusinessAppointmentSearchModel>() ?? new BusinessAppointmentSearchModel();
                var query = ctx.BusinessAppointment.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// BABusiness NVARCHAR(50) 业务 
                if(!string.IsNullOrEmpty(searchModel.BABusiness)) query = query.Where(t=>t.BABusiness.Contains(searchModel.BABusiness));
                if(sort=="BABusiness")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BABusiness):query.OrderByDescending(t=>t.BABusiness);
                    isordered = true;
                }
				// BAService NVARCHAR(50) 服务 
                if(!string.IsNullOrEmpty(searchModel.BAService)) query = query.Where(t=>t.BAService.Contains(searchModel.BAService));
                if(sort=="BAService")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BAService):query.OrderByDescending(t=>t.BAService);
                    isordered = true;
                }
				// BAFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.BAFullName)) query = query.Where(t=>t.BAFullName.Contains(searchModel.BAFullName));
                if(sort=="BAFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BAFullName):query.OrderByDescending(t=>t.BAFullName);
                    isordered = true;
                }
				// BAId NVARCHAR(4000) 身份证 
                if(!string.IsNullOrEmpty(searchModel.BAId)) query = query.Where(t=>t.BAId.Contains(searchModel.BAId));
                if(sort=="BAId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BAId):query.OrderByDescending(t=>t.BAId);
                    isordered = true;
                }
				// BATelephone NVARCHAR(50) 电话 
                if(!string.IsNullOrEmpty(searchModel.BATelephone)) query = query.Where(t=>t.BATelephone.Contains(searchModel.BATelephone));
                if(sort=="BATelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BATelephone):query.OrderByDescending(t=>t.BATelephone);
                    isordered = true;
                }
				// BACreationTime DATETIME 创建时间 
                if(searchModel.FromBACreationTime!=null) query = query.Where(t=>t.BACreationTime>=searchModel.FromBACreationTime);
                if(searchModel.ToBACreationTime!=null) query = query.Where(t=>t.BACreationTime<=searchModel.ToBACreationTime);
                if(sort=="BACreationTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BACreationTime):query.OrderByDescending(t=>t.BACreationTime);
                    isordered = true;
                }
				// BAAcceptanceTime DATETIME 受理时间 
                if(searchModel.FromBAAcceptanceTime!=null) query = query.Where(t=>t.BAAcceptanceTime>=searchModel.FromBAAcceptanceTime);
                if(searchModel.ToBAAcceptanceTime!=null) query = query.Where(t=>t.BAAcceptanceTime<=searchModel.ToBAAcceptanceTime);
                if(sort=="BAAcceptanceTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BAAcceptanceTime):query.OrderByDescending(t=>t.BAAcceptanceTime);
                    isordered = true;
                }
				// BAState NVARCHAR(50) 状态 
                if(searchModel.BAState!=null && searchModel.BAState.Length!=0) query = query.Where(t=>searchModel.BAState.Contains(t.BAState));
                if(sort=="BAState")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BAState):query.OrderByDescending(t=>t.BAState);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.BABusiness.Contains(search)||t.BAService.Contains(search)||t.BAFullName.Contains(search)||t.BAId.Contains(search)||t.BATelephone.Contains(search)||t.BAState.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<BusinessAppointment>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【提建议记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class RecordOfRecommendationsCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.RecordOfRecommendations.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【提建议记录】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【提建议记录】
    /// </summary>
    public partial class DeleteRecordOfRecommendationsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<RecordOfRecommendations>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.RecordOfRecommendations.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.RecordOfRecommendations.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条提建议记录记录";
    }
	
    /// <summary>
    /// 保存【提建议记录】
    /// </summary>
    public partial class SaveRecordOfRecommendationsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<RecordOfRecommendations>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.RecordOfRecommendations.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.RecordOfRecommendations.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.RORTitle = HttpUtility.UrlDecode(entity.RORTitle);
					// NVARCHAR(4000)
				entity.RORContent = HttpUtility.UrlDecode(entity.RORContent);
					// NVARCHAR(50)
				entity.RORObject = HttpUtility.UrlDecode(entity.RORObject);
					// NVARCHAR(50)
				entity.RORDealingWithPeople = HttpUtility.UrlDecode(entity.RORDealingWithPeople);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.RecordOfRecommendations.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条RecordOfRecommendations记录";
    }
	
    /// <summary>
    /// 查询空的【提建议记录】
    /// </summary>
    public partial class GetRecordOfRecommendationsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new RecordOfRecommendations();
        }
        public override string Comments=> "获取空的提建议记录记录";
    }
	
    /// <summary>
    /// 查询【提建议记录】列表
    /// </summary>
    public partial class GetRecordOfRecommendationsListEvaluator : Evaluator
    {
        public override string Comments=> "获取RecordOfRecommendations列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<RecordOfRecommendationsSearchModel>() ?? new RecordOfRecommendationsSearchModel();
                var query = ctx.RecordOfRecommendations.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// RORTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.RORTitle)) query = query.Where(t=>t.RORTitle.Contains(searchModel.RORTitle));
                if(sort=="RORTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RORTitle):query.OrderByDescending(t=>t.RORTitle);
                    isordered = true;
                }
				// RORContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.RORContent)) query = query.Where(t=>t.RORContent.Contains(searchModel.RORContent));
                if(sort=="RORContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RORContent):query.OrderByDescending(t=>t.RORContent);
                    isordered = true;
                }
				// RORObject NVARCHAR(50) 对象 
                if(!string.IsNullOrEmpty(searchModel.RORObject)) query = query.Where(t=>t.RORObject.Contains(searchModel.RORObject));
                if(sort=="RORObject")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RORObject):query.OrderByDescending(t=>t.RORObject);
                    isordered = true;
                }
				// RORDealingWithPeople NVARCHAR(50) 处理人 
                if(!string.IsNullOrEmpty(searchModel.RORDealingWithPeople)) query = query.Where(t=>t.RORDealingWithPeople.Contains(searchModel.RORDealingWithPeople));
                if(sort=="RORDealingWithPeople")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RORDealingWithPeople):query.OrderByDescending(t=>t.RORDealingWithPeople);
                    isordered = true;
                }
				// RORDateOfProcessing DATETIME 处理日期 
                if(searchModel.FromRORDateOfProcessing!=null) query = query.Where(t=>t.RORDateOfProcessing>=searchModel.FromRORDateOfProcessing);
                if(searchModel.ToRORDateOfProcessing!=null) query = query.Where(t=>t.RORDateOfProcessing<=searchModel.ToRORDateOfProcessing);
                if(sort=="RORDateOfProcessing")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RORDateOfProcessing):query.OrderByDescending(t=>t.RORDateOfProcessing);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.RORTitle.Contains(search)||t.RORContent.Contains(search)||t.RORObject.Contains(search)||t.RORDealingWithPeople.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<RecordOfRecommendations>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党风廉政学习】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class StudyOnPartyStyleAndCleanGovernmentCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.StudyOnPartyStyleAndCleanGovernment.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党风廉政学习】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党风廉政学习】
    /// </summary>
    public partial class DeleteStudyOnPartyStyleAndCleanGovernmentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<StudyOnPartyStyleAndCleanGovernment>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.StudyOnPartyStyleAndCleanGovernment.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.StudyOnPartyStyleAndCleanGovernment.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党风廉政学习记录";
    }
	
    /// <summary>
    /// 保存【党风廉政学习】
    /// </summary>
    public partial class SaveStudyOnPartyStyleAndCleanGovernmentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<StudyOnPartyStyleAndCleanGovernment>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.StudyOnPartyStyleAndCleanGovernment.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.StudyOnPartyStyleAndCleanGovernment.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.SOPSACGTitle = HttpUtility.UrlDecode(entity.SOPSACGTitle);
					// NVARCHAR(4000)
				entity.SOPSACGContent = HttpUtility.UrlDecode(entity.SOPSACGContent);
					// NVARCHAR(50)
				entity.SOPSACGLearningObject = HttpUtility.UrlDecode(entity.SOPSACGLearningObject);
					// NVARCHAR(4000)
				entity.SOPSACGRemarks = HttpUtility.UrlDecode(entity.SOPSACGRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.StudyOnPartyStyleAndCleanGovernment.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条StudyOnPartyStyleAndCleanGovernment记录";
    }
	
    /// <summary>
    /// 查询空的【党风廉政学习】
    /// </summary>
    public partial class GetStudyOnPartyStyleAndCleanGovernmentEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new StudyOnPartyStyleAndCleanGovernment();
        }
        public override string Comments=> "获取空的党风廉政学习记录";
    }
	
    /// <summary>
    /// 查询【党风廉政学习】列表
    /// </summary>
    public partial class GetStudyOnPartyStyleAndCleanGovernmentListEvaluator : Evaluator
    {
        public override string Comments=> "获取StudyOnPartyStyleAndCleanGovernment列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<StudyOnPartyStyleAndCleanGovernmentSearchModel>() ?? new StudyOnPartyStyleAndCleanGovernmentSearchModel();
                var query = ctx.StudyOnPartyStyleAndCleanGovernment.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// SOPSACGTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.SOPSACGTitle)) query = query.Where(t=>t.SOPSACGTitle.Contains(searchModel.SOPSACGTitle));
                if(sort=="SOPSACGTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SOPSACGTitle):query.OrderByDescending(t=>t.SOPSACGTitle);
                    isordered = true;
                }
				// SOPSACGContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.SOPSACGContent)) query = query.Where(t=>t.SOPSACGContent.Contains(searchModel.SOPSACGContent));
                if(sort=="SOPSACGContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SOPSACGContent):query.OrderByDescending(t=>t.SOPSACGContent);
                    isordered = true;
                }
				// SOPSACGLearningObject NVARCHAR(50) 学习对象 
                if(!string.IsNullOrEmpty(searchModel.SOPSACGLearningObject)) query = query.Where(t=>t.SOPSACGLearningObject.Contains(searchModel.SOPSACGLearningObject));
                if(sort=="SOPSACGLearningObject")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SOPSACGLearningObject):query.OrderByDescending(t=>t.SOPSACGLearningObject);
                    isordered = true;
                }
				// SOPSACGLearningDate DATETIME 学习日期 
                if(searchModel.FromSOPSACGLearningDate!=null) query = query.Where(t=>t.SOPSACGLearningDate>=searchModel.FromSOPSACGLearningDate);
                if(searchModel.ToSOPSACGLearningDate!=null) query = query.Where(t=>t.SOPSACGLearningDate<=searchModel.ToSOPSACGLearningDate);
                if(sort=="SOPSACGLearningDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SOPSACGLearningDate):query.OrderByDescending(t=>t.SOPSACGLearningDate);
                    isordered = true;
                }
				// SOPSACGRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.SOPSACGRemarks)) query = query.Where(t=>t.SOPSACGRemarks.Contains(searchModel.SOPSACGRemarks));
                if(sort=="SOPSACGRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SOPSACGRemarks):query.OrderByDescending(t=>t.SOPSACGRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.SOPSACGTitle.Contains(search)||t.SOPSACGContent.Contains(search)||t.SOPSACGLearningObject.Contains(search)||t.SOPSACGRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<StudyOnPartyStyleAndCleanGovernment>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【公共设施】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class CommunalFacilitiesCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.CommunalFacilities.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【公共设施】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【公共设施】
    /// </summary>
    public partial class DeleteCommunalFacilitiesEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<CommunalFacilities>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.CommunalFacilities.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.CommunalFacilities.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条公共设施记录";
    }
	
    /// <summary>
    /// 保存【公共设施】
    /// </summary>
    public partial class SaveCommunalFacilitiesEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<CommunalFacilities>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.CommunalFacilities.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.CommunalFacilities.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.CFName = HttpUtility.UrlDecode(entity.CFName);
					// NVARCHAR(50)
				entity.CFPosition = HttpUtility.UrlDecode(entity.CFPosition);
					// NVARCHAR(50)
				entity.CFType = HttpUtility.UrlDecode(entity.CFType);
					// NVARCHAR(50)
				entity.CFAscription = HttpUtility.UrlDecode(entity.CFAscription);
					// NVARCHAR(50)
				entity.CFIsItDamaged = HttpUtility.UrlDecode(entity.CFIsItDamaged);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.CommunalFacilities.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条CommunalFacilities记录";
    }
	
    /// <summary>
    /// 查询空的【公共设施】
    /// </summary>
    public partial class GetCommunalFacilitiesEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new CommunalFacilities();
        }
        public override string Comments=> "获取空的公共设施记录";
    }
	
    /// <summary>
    /// 查询【公共设施】列表
    /// </summary>
    public partial class GetCommunalFacilitiesListEvaluator : Evaluator
    {
        public override string Comments=> "获取CommunalFacilities列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<CommunalFacilitiesSearchModel>() ?? new CommunalFacilitiesSearchModel();
                var query = ctx.CommunalFacilities.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// CFName NVARCHAR(50) 名称 
                if(!string.IsNullOrEmpty(searchModel.CFName)) query = query.Where(t=>t.CFName.Contains(searchModel.CFName));
                if(sort=="CFName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFName):query.OrderByDescending(t=>t.CFName);
                    isordered = true;
                }
				// CFPosition NVARCHAR(50) 位置 
                if(!string.IsNullOrEmpty(searchModel.CFPosition)) query = query.Where(t=>t.CFPosition.Contains(searchModel.CFPosition));
                if(sort=="CFPosition")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFPosition):query.OrderByDescending(t=>t.CFPosition);
                    isordered = true;
                }
				// CFType NVARCHAR(50) 类型 
                if(!string.IsNullOrEmpty(searchModel.CFType)) query = query.Where(t=>t.CFType.Contains(searchModel.CFType));
                if(sort=="CFType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFType):query.OrderByDescending(t=>t.CFType);
                    isordered = true;
                }
				// CFAscription NVARCHAR(50) 归属 
                if(!string.IsNullOrEmpty(searchModel.CFAscription)) query = query.Where(t=>t.CFAscription.Contains(searchModel.CFAscription));
                if(sort=="CFAscription")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFAscription):query.OrderByDescending(t=>t.CFAscription);
                    isordered = true;
                }
				// CFRenewalDate DATETIME 换新日期 
                if(searchModel.FromCFRenewalDate!=null) query = query.Where(t=>t.CFRenewalDate>=searchModel.FromCFRenewalDate);
                if(searchModel.ToCFRenewalDate!=null) query = query.Where(t=>t.CFRenewalDate<=searchModel.ToCFRenewalDate);
                if(sort=="CFRenewalDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFRenewalDate):query.OrderByDescending(t=>t.CFRenewalDate);
                    isordered = true;
                }
				// CFIsItDamaged NVARCHAR(50) 是否损坏 
                if(!string.IsNullOrEmpty(searchModel.CFIsItDamaged)) query = query.Where(t=>t.CFIsItDamaged.Contains(searchModel.CFIsItDamaged));
                if(sort=="CFIsItDamaged")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFIsItDamaged):query.OrderByDescending(t=>t.CFIsItDamaged);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.CFName.Contains(search)||t.CFPosition.Contains(search)||t.CFType.Contains(search)||t.CFAscription.Contains(search)||t.CFIsItDamaged.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<CommunalFacilities>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【系统配置】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class SystemConfigurationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.SystemConfiguration.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【系统配置】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【系统配置】
    /// </summary>
    public partial class DeleteSystemConfigurationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<SystemConfiguration>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.SystemConfiguration.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.SystemConfiguration.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条系统配置记录";
    }
	
    /// <summary>
    /// 保存【系统配置】
    /// </summary>
    public partial class SaveSystemConfigurationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<SystemConfiguration>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.SystemConfiguration.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.SystemConfiguration.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.SCTitle = HttpUtility.UrlDecode(entity.SCTitle);
					// NVARCHAR(50)
				entity.SCClassification = HttpUtility.UrlDecode(entity.SCClassification);
					// NVARCHAR(50)
				entity.SCSubClassification = HttpUtility.UrlDecode(entity.SCSubClassification);
					// NVARCHAR(4000)
				entity.SCContent = HttpUtility.UrlDecode(entity.SCContent);
					// NVARCHAR(50)
				entity.SCIsItEffective = HttpUtility.UrlDecode(entity.SCIsItEffective);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.SystemConfiguration.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条SystemConfiguration记录";
    }
	
    /// <summary>
    /// 查询空的【系统配置】
    /// </summary>
    public partial class GetSystemConfigurationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new SystemConfiguration();
        }
        public override string Comments=> "获取空的系统配置记录";
    }
	
    /// <summary>
    /// 查询【系统配置】列表
    /// </summary>
    public partial class GetSystemConfigurationListEvaluator : Evaluator
    {
        public override string Comments=> "获取SystemConfiguration列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<SystemConfigurationSearchModel>() ?? new SystemConfigurationSearchModel();
                var query = ctx.SystemConfiguration.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// SCTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.SCTitle)) query = query.Where(t=>t.SCTitle.Contains(searchModel.SCTitle));
                if(sort=="SCTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SCTitle):query.OrderByDescending(t=>t.SCTitle);
                    isordered = true;
                }
				// SCClassification NVARCHAR(50) 分类 
                if(!string.IsNullOrEmpty(searchModel.SCClassification)) query = query.Where(t=>t.SCClassification.Contains(searchModel.SCClassification));
                if(sort=="SCClassification")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SCClassification):query.OrderByDescending(t=>t.SCClassification);
                    isordered = true;
                }
				// SCSubClassification NVARCHAR(50) 子分类 
                if(!string.IsNullOrEmpty(searchModel.SCSubClassification)) query = query.Where(t=>t.SCSubClassification.Contains(searchModel.SCSubClassification));
                if(sort=="SCSubClassification")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SCSubClassification):query.OrderByDescending(t=>t.SCSubClassification);
                    isordered = true;
                }
				// SCContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.SCContent)) query = query.Where(t=>t.SCContent.Contains(searchModel.SCContent));
                if(sort=="SCContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SCContent):query.OrderByDescending(t=>t.SCContent);
                    isordered = true;
                }
				// SCIsItEffective NVARCHAR(50) 是否生效 
                if(!string.IsNullOrEmpty(searchModel.SCIsItEffective)) query = query.Where(t=>t.SCIsItEffective.Contains(searchModel.SCIsItEffective));
                if(sort=="SCIsItEffective")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SCIsItEffective):query.OrderByDescending(t=>t.SCIsItEffective);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.SCTitle.Contains(search)||t.SCClassification.Contains(search)||t.SCSubClassification.Contains(search)||t.SCContent.Contains(search)||t.SCIsItEffective.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<SystemConfiguration>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党建】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PartyBuildingCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.PartyBuilding.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党建】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党建】
    /// </summary>
    public partial class DeletePartyBuildingEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<PartyBuilding>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.PartyBuilding.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.PartyBuilding.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党建记录";
    }
	
    /// <summary>
    /// 保存【党建】
    /// </summary>
    public partial class SavePartyBuildingEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<PartyBuilding>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.PartyBuilding.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.PartyBuilding.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.PBTitle = HttpUtility.UrlDecode(entity.PBTitle);
					// NVARCHAR(4000)
				entity.PBContent = HttpUtility.UrlDecode(entity.PBContent);
					// NVARCHAR(4000)
				entity.PBRemarks = HttpUtility.UrlDecode(entity.PBRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.PartyBuilding.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条PartyBuilding记录";
    }
	
    /// <summary>
    /// 查询空的【党建】
    /// </summary>
    public partial class GetPartyBuildingEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new PartyBuilding();
        }
        public override string Comments=> "获取空的党建记录";
    }
	
    /// <summary>
    /// 查询【党建】列表
    /// </summary>
    public partial class GetPartyBuildingListEvaluator : Evaluator
    {
        public override string Comments=> "获取PartyBuilding列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PartyBuildingSearchModel>() ?? new PartyBuildingSearchModel();
                var query = ctx.PartyBuilding.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PBTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.PBTitle)) query = query.Where(t=>t.PBTitle.Contains(searchModel.PBTitle));
                if(sort=="PBTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PBTitle):query.OrderByDescending(t=>t.PBTitle);
                    isordered = true;
                }
				// PBContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.PBContent)) query = query.Where(t=>t.PBContent.Contains(searchModel.PBContent));
                if(sort=="PBContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PBContent):query.OrderByDescending(t=>t.PBContent);
                    isordered = true;
                }
				// PBReleaseTime DATETIME 发布时间 
                if(searchModel.FromPBReleaseTime!=null) query = query.Where(t=>t.PBReleaseTime>=searchModel.FromPBReleaseTime);
                if(searchModel.ToPBReleaseTime!=null) query = query.Where(t=>t.PBReleaseTime<=searchModel.ToPBReleaseTime);
                if(sort=="PBReleaseTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PBReleaseTime):query.OrderByDescending(t=>t.PBReleaseTime);
                    isordered = true;
                }
				// PBRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.PBRemarks)) query = query.Where(t=>t.PBRemarks.Contains(searchModel.PBRemarks));
                if(sort=="PBRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PBRemarks):query.OrderByDescending(t=>t.PBRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PBTitle.Contains(search)||t.PBContent.Contains(search)||t.PBRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<PartyBuilding>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党费缴纳管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ManagementOfPartyFeePaymentCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ManagementOfPartyFeePayment.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党费缴纳管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党费缴纳管理】
    /// </summary>
    public partial class DeleteManagementOfPartyFeePaymentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ManagementOfPartyFeePayment>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ManagementOfPartyFeePayment.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ManagementOfPartyFeePayment.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党费缴纳管理记录";
    }
	
    /// <summary>
    /// 保存【党费缴纳管理】
    /// </summary>
    public partial class SaveManagementOfPartyFeePaymentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ManagementOfPartyFeePayment>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ManagementOfPartyFeePayment.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ManagementOfPartyFeePayment.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.MOPFPFullName = HttpUtility.UrlDecode(entity.MOPFPFullName);
					// NVARCHAR(50)
				entity.MOPFPTelephone = HttpUtility.UrlDecode(entity.MOPFPTelephone);
					// NVARCHAR(50)
				entity.MOPFPPayee = HttpUtility.UrlDecode(entity.MOPFPPayee);
					// NVARCHAR(50)
				entity.MOPFPSubordinateBranch = HttpUtility.UrlDecode(entity.MOPFPSubordinateBranch);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ManagementOfPartyFeePayment.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ManagementOfPartyFeePayment记录";
    }
	
    /// <summary>
    /// 查询空的【党费缴纳管理】
    /// </summary>
    public partial class GetManagementOfPartyFeePaymentEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ManagementOfPartyFeePayment();
        }
        public override string Comments=> "获取空的党费缴纳管理记录";
    }
	
    /// <summary>
    /// 查询【党费缴纳管理】列表
    /// </summary>
    public partial class GetManagementOfPartyFeePaymentListEvaluator : Evaluator
    {
        public override string Comments=> "获取ManagementOfPartyFeePayment列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ManagementOfPartyFeePaymentSearchModel>() ?? new ManagementOfPartyFeePaymentSearchModel();
                var query = ctx.ManagementOfPartyFeePayment.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// MOPFPFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.MOPFPFullName)) query = query.Where(t=>t.MOPFPFullName.Contains(searchModel.MOPFPFullName));
                if(sort=="MOPFPFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPFPFullName):query.OrderByDescending(t=>t.MOPFPFullName);
                    isordered = true;
                }
				// MOPFPTelephone NVARCHAR(50) 电话 
                if(!string.IsNullOrEmpty(searchModel.MOPFPTelephone)) query = query.Where(t=>t.MOPFPTelephone.Contains(searchModel.MOPFPTelephone));
                if(sort=="MOPFPTelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPFPTelephone):query.OrderByDescending(t=>t.MOPFPTelephone);
                    isordered = true;
                }
				// MOPFPAmountOfMoney MONEY 金额 
                if(searchModel.MinMOPFPAmountOfMoney!=null) query = query.Where(t=>t.MOPFPAmountOfMoney>=searchModel.MinMOPFPAmountOfMoney);
                if(searchModel.MaxMOPFPAmountOfMoney!=null) query = query.Where(t=>t.MOPFPAmountOfMoney<=searchModel.MaxMOPFPAmountOfMoney);
                if(sort=="MOPFPAmountOfMoney")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPFPAmountOfMoney):query.OrderByDescending(t=>t.MOPFPAmountOfMoney);
                    isordered = true;
                }
				// MOPFPDate DATETIME 日期 
                if(searchModel.FromMOPFPDate!=null) query = query.Where(t=>t.MOPFPDate>=searchModel.FromMOPFPDate);
                if(searchModel.ToMOPFPDate!=null) query = query.Where(t=>t.MOPFPDate<=searchModel.ToMOPFPDate);
                if(sort=="MOPFPDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPFPDate):query.OrderByDescending(t=>t.MOPFPDate);
                    isordered = true;
                }
				// MOPFPPayee NVARCHAR(50) 收款人 
                if(!string.IsNullOrEmpty(searchModel.MOPFPPayee)) query = query.Where(t=>t.MOPFPPayee.Contains(searchModel.MOPFPPayee));
                if(sort=="MOPFPPayee")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPFPPayee):query.OrderByDescending(t=>t.MOPFPPayee);
                    isordered = true;
                }
				// MOPFPSubordinateBranch NVARCHAR(50) 所属支部 
                if(!string.IsNullOrEmpty(searchModel.MOPFPSubordinateBranch)) query = query.Where(t=>t.MOPFPSubordinateBranch.Contains(searchModel.MOPFPSubordinateBranch));
                if(sort=="MOPFPSubordinateBranch")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MOPFPSubordinateBranch):query.OrderByDescending(t=>t.MOPFPSubordinateBranch);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.MOPFPFullName.Contains(search)||t.MOPFPTelephone.Contains(search)||t.MOPFPPayee.Contains(search)||t.MOPFPSubordinateBranch.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ManagementOfPartyFeePayment>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【合同管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ContractManagementCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ContractManagement.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【合同管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【合同管理】
    /// </summary>
    public partial class DeleteContractManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ContractManagement>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ContractManagement.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ContractManagement.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条合同管理记录";
    }
	
    /// <summary>
    /// 保存【合同管理】
    /// </summary>
    public partial class SaveContractManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ContractManagement>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ContractManagement.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ContractManagement.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.CMContractNumber = HttpUtility.UrlDecode(entity.CMContractNumber);
					// NVARCHAR(50)
				entity.CMContractName = HttpUtility.UrlDecode(entity.CMContractName);
					// NVARCHAR(50)
				entity.CMEntryName = HttpUtility.UrlDecode(entity.CMEntryName);
					// NVARCHAR(50)
				entity.CMSignatureOfPartya = HttpUtility.UrlDecode(entity.CMSignatureOfPartya);
					// NVARCHAR(50)
				entity.CMSignatureOfPartyb = HttpUtility.UrlDecode(entity.CMSignatureOfPartyb);
					// NVARCHAR(50)
				entity.CMSignatureOfPartyc = HttpUtility.UrlDecode(entity.CMSignatureOfPartyc);
					// NVARCHAR(50)
				entity.CMSignatory = HttpUtility.UrlDecode(entity.CMSignatory);
					// NVARCHAR(4000)
				entity.CMUploadContractDocuments = HttpUtility.UrlDecode(entity.CMUploadContractDocuments);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ContractManagement.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ContractManagement记录";
    }
	
    /// <summary>
    /// 查询空的【合同管理】
    /// </summary>
    public partial class GetContractManagementEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ContractManagement();
        }
        public override string Comments=> "获取空的合同管理记录";
    }
	
    /// <summary>
    /// 查询【合同管理】列表
    /// </summary>
    public partial class GetContractManagementListEvaluator : Evaluator
    {
        public override string Comments=> "获取ContractManagement列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ContractManagementSearchModel>() ?? new ContractManagementSearchModel();
                var query = ctx.ContractManagement.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// CMContractNumber NVARCHAR(50) 合同编号 
                if(!string.IsNullOrEmpty(searchModel.CMContractNumber)) query = query.Where(t=>t.CMContractNumber.Contains(searchModel.CMContractNumber));
                if(sort=="CMContractNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CMContractNumber):query.OrderByDescending(t=>t.CMContractNumber);
                    isordered = true;
                }
				// CMContractName NVARCHAR(50) 合同名称 
                if(!string.IsNullOrEmpty(searchModel.CMContractName)) query = query.Where(t=>t.CMContractName.Contains(searchModel.CMContractName));
                if(sort=="CMContractName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CMContractName):query.OrderByDescending(t=>t.CMContractName);
                    isordered = true;
                }
				// CMEntryName NVARCHAR(50) 项目名称 
                if(!string.IsNullOrEmpty(searchModel.CMEntryName)) query = query.Where(t=>t.CMEntryName.Contains(searchModel.CMEntryName));
                if(sort=="CMEntryName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CMEntryName):query.OrderByDescending(t=>t.CMEntryName);
                    isordered = true;
                }
				// CMSignatureOfPartya NVARCHAR(50) 甲方签名 
                if(!string.IsNullOrEmpty(searchModel.CMSignatureOfPartya)) query = query.Where(t=>t.CMSignatureOfPartya.Contains(searchModel.CMSignatureOfPartya));
                if(sort=="CMSignatureOfPartya")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CMSignatureOfPartya):query.OrderByDescending(t=>t.CMSignatureOfPartya);
                    isordered = true;
                }
				// CMSignatureOfPartyb NVARCHAR(50) 乙方签名 
                if(!string.IsNullOrEmpty(searchModel.CMSignatureOfPartyb)) query = query.Where(t=>t.CMSignatureOfPartyb.Contains(searchModel.CMSignatureOfPartyb));
                if(sort=="CMSignatureOfPartyb")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CMSignatureOfPartyb):query.OrderByDescending(t=>t.CMSignatureOfPartyb);
                    isordered = true;
                }
				// CMSignatureOfPartyc NVARCHAR(50) 丙方签名 
                if(!string.IsNullOrEmpty(searchModel.CMSignatureOfPartyc)) query = query.Where(t=>t.CMSignatureOfPartyc.Contains(searchModel.CMSignatureOfPartyc));
                if(sort=="CMSignatureOfPartyc")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CMSignatureOfPartyc):query.OrderByDescending(t=>t.CMSignatureOfPartyc);
                    isordered = true;
                }
				// CMSigningDate DATETIME 签署日期 
                if(searchModel.FromCMSigningDate!=null) query = query.Where(t=>t.CMSigningDate>=searchModel.FromCMSigningDate);
                if(searchModel.ToCMSigningDate!=null) query = query.Where(t=>t.CMSigningDate<=searchModel.ToCMSigningDate);
                if(sort=="CMSigningDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CMSigningDate):query.OrderByDescending(t=>t.CMSigningDate);
                    isordered = true;
                }
				// CMSignatory NVARCHAR(50) 签署机构 
                if(!string.IsNullOrEmpty(searchModel.CMSignatory)) query = query.Where(t=>t.CMSignatory.Contains(searchModel.CMSignatory));
                if(sort=="CMSignatory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CMSignatory):query.OrderByDescending(t=>t.CMSignatory);
                    isordered = true;
                }
				// CMUploadContractDocuments NVARCHAR(4000) 合同文件上传 
                if(!string.IsNullOrEmpty(searchModel.CMUploadContractDocuments)) query = query.Where(t=>t.CMUploadContractDocuments.Contains(searchModel.CMUploadContractDocuments));
                if(sort=="CMUploadContractDocuments")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CMUploadContractDocuments):query.OrderByDescending(t=>t.CMUploadContractDocuments);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.CMContractNumber.Contains(search)||t.CMContractName.Contains(search)||t.CMEntryName.Contains(search)||t.CMSignatureOfPartya.Contains(search)||t.CMSignatureOfPartyb.Contains(search)||t.CMSignatureOfPartyc.Contains(search)||t.CMSignatory.Contains(search)||t.CMUploadContractDocuments.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ContractManagement>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【个人信息】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PersonalInformationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.PersonalInformation.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【个人信息】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【个人信息】
    /// </summary>
    public partial class DeletePersonalInformationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<PersonalInformation>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.PersonalInformation.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.PersonalInformation.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条个人信息记录";
    }
	
    /// <summary>
    /// 保存【个人信息】
    /// </summary>
    public partial class SavePersonalInformationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<PersonalInformation>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.PersonalInformation.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.PersonalInformation.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.PILoginName = HttpUtility.UrlDecode(entity.PILoginName);
					// NVARCHAR(50)
				entity.PINickname = HttpUtility.UrlDecode(entity.PINickname);
					// NVARCHAR(50)
				entity.PIRealName = HttpUtility.UrlDecode(entity.PIRealName);
					// NVARCHAR(50)
				entity.PIPassword = HttpUtility.UrlDecode(entity.PIPassword);
					// NVARCHAR(4000)
				entity.PIHeadPortrait = HttpUtility.UrlDecode(entity.PIHeadPortrait);
					// NVARCHAR(50)
				entity.PISubordinateDepartments = HttpUtility.UrlDecode(entity.PISubordinateDepartments);
					// NVARCHAR(50)
				entity.PITelephone = HttpUtility.UrlDecode(entity.PITelephone);
					// NVARCHAR(4000)
				entity.PIPhoto = HttpUtility.UrlDecode(entity.PIPhoto);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.PersonalInformation.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条PersonalInformation记录";
    }
	
    /// <summary>
    /// 查询空的【个人信息】
    /// </summary>
    public partial class GetPersonalInformationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new PersonalInformation();
        }
        public override string Comments=> "获取空的个人信息记录";
    }
	
    /// <summary>
    /// 查询【个人信息】列表
    /// </summary>
    public partial class GetPersonalInformationListEvaluator : Evaluator
    {
        public override string Comments=> "获取PersonalInformation列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PersonalInformationSearchModel>() ?? new PersonalInformationSearchModel();
                var query = ctx.PersonalInformation.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PILoginName NVARCHAR(50) 登录名 
                if(!string.IsNullOrEmpty(searchModel.PILoginName)) query = query.Where(t=>t.PILoginName.Contains(searchModel.PILoginName));
                if(sort=="PILoginName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PILoginName):query.OrderByDescending(t=>t.PILoginName);
                    isordered = true;
                }
				// PINickname NVARCHAR(50) 昵称 
                if(!string.IsNullOrEmpty(searchModel.PINickname)) query = query.Where(t=>t.PINickname.Contains(searchModel.PINickname));
                if(sort=="PINickname")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PINickname):query.OrderByDescending(t=>t.PINickname);
                    isordered = true;
                }
				// PIRealName NVARCHAR(50) 真实姓名 
                if(!string.IsNullOrEmpty(searchModel.PIRealName)) query = query.Where(t=>t.PIRealName.Contains(searchModel.PIRealName));
                if(sort=="PIRealName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PIRealName):query.OrderByDescending(t=>t.PIRealName);
                    isordered = true;
                }
				// PIPassword NVARCHAR(50) 密码 
                if(!string.IsNullOrEmpty(searchModel.PIPassword)) query = query.Where(t=>t.PIPassword.Contains(searchModel.PIPassword));
                if(sort=="PIPassword")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PIPassword):query.OrderByDescending(t=>t.PIPassword);
                    isordered = true;
                }
				// PIHeadPortrait NVARCHAR(4000) 头像 
                if(!string.IsNullOrEmpty(searchModel.PIHeadPortrait)) query = query.Where(t=>t.PIHeadPortrait.Contains(searchModel.PIHeadPortrait));
                if(sort=="PIHeadPortrait")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PIHeadPortrait):query.OrderByDescending(t=>t.PIHeadPortrait);
                    isordered = true;
                }
				// PILastLogonTime DATETIME 上次登录时间 
                if(searchModel.FromPILastLogonTime!=null) query = query.Where(t=>t.PILastLogonTime>=searchModel.FromPILastLogonTime);
                if(searchModel.ToPILastLogonTime!=null) query = query.Where(t=>t.PILastLogonTime<=searchModel.ToPILastLogonTime);
                if(sort=="PILastLogonTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PILastLogonTime):query.OrderByDescending(t=>t.PILastLogonTime);
                    isordered = true;
                }
				// PISubordinateDepartments NVARCHAR(50) 所属部门 
                if(!string.IsNullOrEmpty(searchModel.PISubordinateDepartments)) query = query.Where(t=>t.PISubordinateDepartments.Contains(searchModel.PISubordinateDepartments));
                if(sort=="PISubordinateDepartments")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PISubordinateDepartments):query.OrderByDescending(t=>t.PISubordinateDepartments);
                    isordered = true;
                }
				// PITelephone NVARCHAR(50) 电话 
                if(!string.IsNullOrEmpty(searchModel.PITelephone)) query = query.Where(t=>t.PITelephone.Contains(searchModel.PITelephone));
                if(sort=="PITelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PITelephone):query.OrderByDescending(t=>t.PITelephone);
                    isordered = true;
                }
				// PIPhoto NVARCHAR(4000) 照片 
                if(!string.IsNullOrEmpty(searchModel.PIPhoto)) query = query.Where(t=>t.PIPhoto.Contains(searchModel.PIPhoto));
                if(sort=="PIPhoto")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PIPhoto):query.OrderByDescending(t=>t.PIPhoto);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PILoginName.Contains(search)||t.PINickname.Contains(search)||t.PIRealName.Contains(search)||t.PIPassword.Contains(search)||t.PIHeadPortrait.Contains(search)||t.PISubordinateDepartments.Contains(search)||t.PITelephone.Contains(search)||t.PIPhoto.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<PersonalInformation>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【日程工作】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ScheduleWorkCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ScheduleWork.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【日程工作】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【日程工作】
    /// </summary>
    public partial class DeleteScheduleWorkEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ScheduleWork>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ScheduleWork.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ScheduleWork.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条日程工作记录";
    }
	
    /// <summary>
    /// 保存【日程工作】
    /// </summary>
    public partial class SaveScheduleWorkEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ScheduleWork>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ScheduleWork.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ScheduleWork.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.SWTitle = HttpUtility.UrlDecode(entity.SWTitle);
					// NVARCHAR(4000)
				entity.SWContent = HttpUtility.UrlDecode(entity.SWContent);
					// NVARCHAR(50)
				entity.SWPlace = HttpUtility.UrlDecode(entity.SWPlace);
					// NVARCHAR(50)
				entity.SWPersonInCharge = HttpUtility.UrlDecode(entity.SWPersonInCharge);
					// NVARCHAR(50)
				entity.SWTelephone = HttpUtility.UrlDecode(entity.SWTelephone);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ScheduleWork.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ScheduleWork记录";
    }
	
    /// <summary>
    /// 查询空的【日程工作】
    /// </summary>
    public partial class GetScheduleWorkEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ScheduleWork();
        }
        public override string Comments=> "获取空的日程工作记录";
    }
	
    /// <summary>
    /// 查询【日程工作】列表
    /// </summary>
    public partial class GetScheduleWorkListEvaluator : Evaluator
    {
        public override string Comments=> "获取ScheduleWork列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ScheduleWorkSearchModel>() ?? new ScheduleWorkSearchModel();
                var query = ctx.ScheduleWork.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// SWTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.SWTitle)) query = query.Where(t=>t.SWTitle.Contains(searchModel.SWTitle));
                if(sort=="SWTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWTitle):query.OrderByDescending(t=>t.SWTitle);
                    isordered = true;
                }
				// SWContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.SWContent)) query = query.Where(t=>t.SWContent.Contains(searchModel.SWContent));
                if(sort=="SWContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWContent):query.OrderByDescending(t=>t.SWContent);
                    isordered = true;
                }
				// SWPlace NVARCHAR(50) 地点 
                if(!string.IsNullOrEmpty(searchModel.SWPlace)) query = query.Where(t=>t.SWPlace.Contains(searchModel.SWPlace));
                if(sort=="SWPlace")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWPlace):query.OrderByDescending(t=>t.SWPlace);
                    isordered = true;
                }
				// SWPersonInCharge NVARCHAR(50) 负责人 
                if(!string.IsNullOrEmpty(searchModel.SWPersonInCharge)) query = query.Where(t=>t.SWPersonInCharge.Contains(searchModel.SWPersonInCharge));
                if(sort=="SWPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWPersonInCharge):query.OrderByDescending(t=>t.SWPersonInCharge);
                    isordered = true;
                }
				// SWTelephone NVARCHAR(50) 电话 
                if(!string.IsNullOrEmpty(searchModel.SWTelephone)) query = query.Where(t=>t.SWTelephone.Contains(searchModel.SWTelephone));
                if(sort=="SWTelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWTelephone):query.OrderByDescending(t=>t.SWTelephone);
                    isordered = true;
                }
				// SWStartTime DATETIME 开始时间 
                if(searchModel.FromSWStartTime!=null) query = query.Where(t=>t.SWStartTime>=searchModel.FromSWStartTime);
                if(searchModel.ToSWStartTime!=null) query = query.Where(t=>t.SWStartTime<=searchModel.ToSWStartTime);
                if(sort=="SWStartTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWStartTime):query.OrderByDescending(t=>t.SWStartTime);
                    isordered = true;
                }
				// SWEndingTime DATETIME 结束时间 
                if(searchModel.FromSWEndingTime!=null) query = query.Where(t=>t.SWEndingTime>=searchModel.FromSWEndingTime);
                if(searchModel.ToSWEndingTime!=null) query = query.Where(t=>t.SWEndingTime<=searchModel.ToSWEndingTime);
                if(sort=="SWEndingTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWEndingTime):query.OrderByDescending(t=>t.SWEndingTime);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.SWTitle.Contains(search)||t.SWContent.Contains(search)||t.SWPlace.Contains(search)||t.SWPersonInCharge.Contains(search)||t.SWTelephone.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ScheduleWork>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党建专题】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class SpecialTopicOnPartyBuildingCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.SpecialTopicOnPartyBuilding.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党建专题】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党建专题】
    /// </summary>
    public partial class DeleteSpecialTopicOnPartyBuildingEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<SpecialTopicOnPartyBuilding>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.SpecialTopicOnPartyBuilding.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.SpecialTopicOnPartyBuilding.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党建专题记录";
    }
	
    /// <summary>
    /// 保存【党建专题】
    /// </summary>
    public partial class SaveSpecialTopicOnPartyBuildingEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<SpecialTopicOnPartyBuilding>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.SpecialTopicOnPartyBuilding.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.SpecialTopicOnPartyBuilding.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.STOPBTitle = HttpUtility.UrlDecode(entity.STOPBTitle);
					// NVARCHAR(50)
				entity.STOPBPreview = HttpUtility.UrlDecode(entity.STOPBPreview);
					// NVARCHAR(50)
				entity.STOPBSee = HttpUtility.UrlDecode(entity.STOPBSee);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.SpecialTopicOnPartyBuilding.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条SpecialTopicOnPartyBuilding记录";
    }
	
    /// <summary>
    /// 查询空的【党建专题】
    /// </summary>
    public partial class GetSpecialTopicOnPartyBuildingEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new SpecialTopicOnPartyBuilding();
        }
        public override string Comments=> "获取空的党建专题记录";
    }
	
    /// <summary>
    /// 查询【党建专题】列表
    /// </summary>
    public partial class GetSpecialTopicOnPartyBuildingListEvaluator : Evaluator
    {
        public override string Comments=> "获取SpecialTopicOnPartyBuilding列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<SpecialTopicOnPartyBuildingSearchModel>() ?? new SpecialTopicOnPartyBuildingSearchModel();
                var query = ctx.SpecialTopicOnPartyBuilding.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// STOPBTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.STOPBTitle)) query = query.Where(t=>t.STOPBTitle.Contains(searchModel.STOPBTitle));
                if(sort=="STOPBTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.STOPBTitle):query.OrderByDescending(t=>t.STOPBTitle);
                    isordered = true;
                }
				// STOPBPreview NVARCHAR(50) 预览 
                if(!string.IsNullOrEmpty(searchModel.STOPBPreview)) query = query.Where(t=>t.STOPBPreview.Contains(searchModel.STOPBPreview));
                if(sort=="STOPBPreview")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.STOPBPreview):query.OrderByDescending(t=>t.STOPBPreview);
                    isordered = true;
                }
				// STOPBReleaseTime DATETIME 发布时间 
                if(searchModel.FromSTOPBReleaseTime!=null) query = query.Where(t=>t.STOPBReleaseTime>=searchModel.FromSTOPBReleaseTime);
                if(searchModel.ToSTOPBReleaseTime!=null) query = query.Where(t=>t.STOPBReleaseTime<=searchModel.ToSTOPBReleaseTime);
                if(sort=="STOPBReleaseTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.STOPBReleaseTime):query.OrderByDescending(t=>t.STOPBReleaseTime);
                    isordered = true;
                }
				// STOPBSee NVARCHAR(50) 查看 
                if(!string.IsNullOrEmpty(searchModel.STOPBSee)) query = query.Where(t=>t.STOPBSee.Contains(searchModel.STOPBSee));
                if(sort=="STOPBSee")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.STOPBSee):query.OrderByDescending(t=>t.STOPBSee);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.STOPBTitle.Contains(search)||t.STOPBPreview.Contains(search)||t.STOPBSee.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<SpecialTopicOnPartyBuilding>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【办事指南】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class BusinessGuideCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.BusinessGuide.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【办事指南】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【办事指南】
    /// </summary>
    public partial class DeleteBusinessGuideEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<BusinessGuide>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.BusinessGuide.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.BusinessGuide.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条办事指南记录";
    }
	
    /// <summary>
    /// 保存【办事指南】
    /// </summary>
    public partial class SaveBusinessGuideEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<BusinessGuide>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.BusinessGuide.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.BusinessGuide.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.BGCategory = HttpUtility.UrlDecode(entity.BGCategory);
					// NVARCHAR(4000)
				entity.BGContentOfWork = HttpUtility.UrlDecode(entity.BGContentOfWork);
					// NVARCHAR(50)
				entity.BGRequiredMaterials = HttpUtility.UrlDecode(entity.BGRequiredMaterials);
					// NVARCHAR(50)
				entity.BGProcedure = HttpUtility.UrlDecode(entity.BGProcedure);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.BusinessGuide.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条BusinessGuide记录";
    }
	
    /// <summary>
    /// 查询空的【办事指南】
    /// </summary>
    public partial class GetBusinessGuideEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new BusinessGuide();
        }
        public override string Comments=> "获取空的办事指南记录";
    }
	
    /// <summary>
    /// 查询【办事指南】列表
    /// </summary>
    public partial class GetBusinessGuideListEvaluator : Evaluator
    {
        public override string Comments=> "获取BusinessGuide列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<BusinessGuideSearchModel>() ?? new BusinessGuideSearchModel();
                var query = ctx.BusinessGuide.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// BGCategory NVARCHAR(50) 类别 
                if(!string.IsNullOrEmpty(searchModel.BGCategory)) query = query.Where(t=>t.BGCategory.Contains(searchModel.BGCategory));
                if(sort=="BGCategory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BGCategory):query.OrderByDescending(t=>t.BGCategory);
                    isordered = true;
                }
				// BGContentOfWork NVARCHAR(4000) 办事内容 
                if(!string.IsNullOrEmpty(searchModel.BGContentOfWork)) query = query.Where(t=>t.BGContentOfWork.Contains(searchModel.BGContentOfWork));
                if(sort=="BGContentOfWork")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BGContentOfWork):query.OrderByDescending(t=>t.BGContentOfWork);
                    isordered = true;
                }
				// BGRequiredMaterials NVARCHAR(50) 所需材料 
                if(!string.IsNullOrEmpty(searchModel.BGRequiredMaterials)) query = query.Where(t=>t.BGRequiredMaterials.Contains(searchModel.BGRequiredMaterials));
                if(sort=="BGRequiredMaterials")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BGRequiredMaterials):query.OrderByDescending(t=>t.BGRequiredMaterials);
                    isordered = true;
                }
				// BGProcedure NVARCHAR(50) 办事程序 
                if(!string.IsNullOrEmpty(searchModel.BGProcedure)) query = query.Where(t=>t.BGProcedure.Contains(searchModel.BGProcedure));
                if(sort=="BGProcedure")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BGProcedure):query.OrderByDescending(t=>t.BGProcedure);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.BGCategory.Contains(search)||t.BGContentOfWork.Contains(search)||t.BGRequiredMaterials.Contains(search)||t.BGProcedure.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<BusinessGuide>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党务指南】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PartyAffairsGuideCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.PartyAffairsGuide.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党务指南】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党务指南】
    /// </summary>
    public partial class DeletePartyAffairsGuideEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<PartyAffairsGuide>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.PartyAffairsGuide.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.PartyAffairsGuide.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党务指南记录";
    }
	
    /// <summary>
    /// 保存【党务指南】
    /// </summary>
    public partial class SavePartyAffairsGuideEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<PartyAffairsGuide>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.PartyAffairsGuide.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.PartyAffairsGuide.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.PAGTitle = HttpUtility.UrlDecode(entity.PAGTitle);
					// NVARCHAR(4000)
				entity.PAGContent = HttpUtility.UrlDecode(entity.PAGContent);
					// NVARCHAR(50)
				entity.PAGCategory = HttpUtility.UrlDecode(entity.PAGCategory);
					// NVARCHAR(50)
				entity.PAGScopeOfApplication = HttpUtility.UrlDecode(entity.PAGScopeOfApplication);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.PartyAffairsGuide.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条PartyAffairsGuide记录";
    }
	
    /// <summary>
    /// 查询空的【党务指南】
    /// </summary>
    public partial class GetPartyAffairsGuideEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new PartyAffairsGuide();
        }
        public override string Comments=> "获取空的党务指南记录";
    }
	
    /// <summary>
    /// 查询【党务指南】列表
    /// </summary>
    public partial class GetPartyAffairsGuideListEvaluator : Evaluator
    {
        public override string Comments=> "获取PartyAffairsGuide列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PartyAffairsGuideSearchModel>() ?? new PartyAffairsGuideSearchModel();
                var query = ctx.PartyAffairsGuide.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PAGTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.PAGTitle)) query = query.Where(t=>t.PAGTitle.Contains(searchModel.PAGTitle));
                if(sort=="PAGTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAGTitle):query.OrderByDescending(t=>t.PAGTitle);
                    isordered = true;
                }
				// PAGContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.PAGContent)) query = query.Where(t=>t.PAGContent.Contains(searchModel.PAGContent));
                if(sort=="PAGContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAGContent):query.OrderByDescending(t=>t.PAGContent);
                    isordered = true;
                }
				// PAGCategory NVARCHAR(50) 类别 
                if(!string.IsNullOrEmpty(searchModel.PAGCategory)) query = query.Where(t=>t.PAGCategory.Contains(searchModel.PAGCategory));
                if(sort=="PAGCategory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAGCategory):query.OrderByDescending(t=>t.PAGCategory);
                    isordered = true;
                }
				// PAGScopeOfApplication NVARCHAR(50) 适用范围 
                if(!string.IsNullOrEmpty(searchModel.PAGScopeOfApplication)) query = query.Where(t=>t.PAGScopeOfApplication.Contains(searchModel.PAGScopeOfApplication));
                if(sort=="PAGScopeOfApplication")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAGScopeOfApplication):query.OrderByDescending(t=>t.PAGScopeOfApplication);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PAGTitle.Contains(search)||t.PAGContent.Contains(search)||t.PAGCategory.Contains(search)||t.PAGScopeOfApplication.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<PartyAffairsGuide>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【业务管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class BusinessManagementCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.BusinessManagement.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【业务管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【业务管理】
    /// </summary>
    public partial class DeleteBusinessManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<BusinessManagement>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.BusinessManagement.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.BusinessManagement.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条业务管理记录";
    }
	
    /// <summary>
    /// 保存【业务管理】
    /// </summary>
    public partial class SaveBusinessManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<BusinessManagement>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.BusinessManagement.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.BusinessManagement.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.BMBusinessType = HttpUtility.UrlDecode(entity.BMBusinessType);
					// NVARCHAR(50)
				entity.BMServiceType = HttpUtility.UrlDecode(entity.BMServiceType);
					// NVARCHAR(50)
				entity.BMApplicant = HttpUtility.UrlDecode(entity.BMApplicant);
					// NVARCHAR(4000)
				entity.BMId = HttpUtility.UrlDecode(entity.BMId);
					// NVARCHAR(50)
				entity.BMGender = HttpUtility.UrlDecode(entity.BMGender);
					// NVARCHAR(50)
				entity.BMAgent = HttpUtility.UrlDecode(entity.BMAgent);
					// NVARCHAR(50)
				entity.BMState = HttpUtility.UrlDecode(entity.BMState);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.BusinessManagement.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条BusinessManagement记录";
    }
	
    /// <summary>
    /// 查询空的【业务管理】
    /// </summary>
    public partial class GetBusinessManagementEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new BusinessManagement();
        }
        public override string Comments=> "获取空的业务管理记录";
    }
	
    /// <summary>
    /// 查询【业务管理】列表
    /// </summary>
    public partial class GetBusinessManagementListEvaluator : Evaluator
    {
        public override string Comments=> "获取BusinessManagement列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<BusinessManagementSearchModel>() ?? new BusinessManagementSearchModel();
                var query = ctx.BusinessManagement.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// BMBusinessType NVARCHAR(50) 业务类型 
                if(!string.IsNullOrEmpty(searchModel.BMBusinessType)) query = query.Where(t=>t.BMBusinessType.Contains(searchModel.BMBusinessType));
                if(sort=="BMBusinessType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BMBusinessType):query.OrderByDescending(t=>t.BMBusinessType);
                    isordered = true;
                }
				// BMServiceType NVARCHAR(50) 服务类型 
                if(!string.IsNullOrEmpty(searchModel.BMServiceType)) query = query.Where(t=>t.BMServiceType.Contains(searchModel.BMServiceType));
                if(sort=="BMServiceType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BMServiceType):query.OrderByDescending(t=>t.BMServiceType);
                    isordered = true;
                }
				// BMApplicant NVARCHAR(50) 申请人 
                if(!string.IsNullOrEmpty(searchModel.BMApplicant)) query = query.Where(t=>t.BMApplicant.Contains(searchModel.BMApplicant));
                if(sort=="BMApplicant")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BMApplicant):query.OrderByDescending(t=>t.BMApplicant);
                    isordered = true;
                }
				// BMId NVARCHAR(4000) 身份证 
                if(!string.IsNullOrEmpty(searchModel.BMId)) query = query.Where(t=>t.BMId.Contains(searchModel.BMId));
                if(sort=="BMId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BMId):query.OrderByDescending(t=>t.BMId);
                    isordered = true;
                }
				// BMGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.BMGender)) query = query.Where(t=>t.BMGender.Contains(searchModel.BMGender));
                if(sort=="BMGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BMGender):query.OrderByDescending(t=>t.BMGender);
                    isordered = true;
                }
				// BMHallAcceptanceTime DATETIME 大厅受理时间 
                if(searchModel.FromBMHallAcceptanceTime!=null) query = query.Where(t=>t.BMHallAcceptanceTime>=searchModel.FromBMHallAcceptanceTime);
                if(searchModel.ToBMHallAcceptanceTime!=null) query = query.Where(t=>t.BMHallAcceptanceTime<=searchModel.ToBMHallAcceptanceTime);
                if(sort=="BMHallAcceptanceTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BMHallAcceptanceTime):query.OrderByDescending(t=>t.BMHallAcceptanceTime);
                    isordered = true;
                }
				// BMAgent NVARCHAR(50) 经办人 
                if(!string.IsNullOrEmpty(searchModel.BMAgent)) query = query.Where(t=>t.BMAgent.Contains(searchModel.BMAgent));
                if(sort=="BMAgent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BMAgent):query.OrderByDescending(t=>t.BMAgent);
                    isordered = true;
                }
				// BMCreationTime DATETIME 创建时间 
                if(searchModel.FromBMCreationTime!=null) query = query.Where(t=>t.BMCreationTime>=searchModel.FromBMCreationTime);
                if(searchModel.ToBMCreationTime!=null) query = query.Where(t=>t.BMCreationTime<=searchModel.ToBMCreationTime);
                if(sort=="BMCreationTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BMCreationTime):query.OrderByDescending(t=>t.BMCreationTime);
                    isordered = true;
                }
				// BMState NVARCHAR(50) 状态 
                if(searchModel.BMState!=null && searchModel.BMState.Length!=0) query = query.Where(t=>searchModel.BMState.Contains(t.BMState));
                if(sort=="BMState")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BMState):query.OrderByDescending(t=>t.BMState);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.BMBusinessType.Contains(search)||t.BMServiceType.Contains(search)||t.BMApplicant.Contains(search)||t.BMId.Contains(search)||t.BMGender.Contains(search)||t.BMAgent.Contains(search)||t.BMState.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<BusinessManagement>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【少儿医保】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class MedicalInsuranceForChildrenCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.MedicalInsuranceForChildren.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【少儿医保】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【少儿医保】
    /// </summary>
    public partial class DeleteMedicalInsuranceForChildrenEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<MedicalInsuranceForChildren>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.MedicalInsuranceForChildren.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.MedicalInsuranceForChildren.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条少儿医保记录";
    }
	
    /// <summary>
    /// 保存【少儿医保】
    /// </summary>
    public partial class SaveMedicalInsuranceForChildrenEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<MedicalInsuranceForChildren>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.MedicalInsuranceForChildren.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.MedicalInsuranceForChildren.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.MIFCUnitNumber = HttpUtility.UrlDecode(entity.MIFCUnitNumber);
					// NVARCHAR(50)
				entity.MIFCPersonnelNumber = HttpUtility.UrlDecode(entity.MIFCPersonnelNumber);
					// NVARCHAR(50)
				entity.MIFCFullName = HttpUtility.UrlDecode(entity.MIFCFullName);
					// NVARCHAR(4000)
				entity.MIFCId = HttpUtility.UrlDecode(entity.MIFCId);
					// NVARCHAR(50)
				entity.MIFCExemptionCategory = HttpUtility.UrlDecode(entity.MIFCExemptionCategory);
					// NVARCHAR(50)
				entity.MIFCExemptionNumber = HttpUtility.UrlDecode(entity.MIFCExemptionNumber);
					// NVARCHAR(50)
				entity.MIFCContacts = HttpUtility.UrlDecode(entity.MIFCContacts);
					// NVARCHAR(50)
				entity.MIFCContactNumber = HttpUtility.UrlDecode(entity.MIFCContactNumber);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.MedicalInsuranceForChildren.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条MedicalInsuranceForChildren记录";
    }
	
    /// <summary>
    /// 查询空的【少儿医保】
    /// </summary>
    public partial class GetMedicalInsuranceForChildrenEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new MedicalInsuranceForChildren();
        }
        public override string Comments=> "获取空的少儿医保记录";
    }
	
    /// <summary>
    /// 查询【少儿医保】列表
    /// </summary>
    public partial class GetMedicalInsuranceForChildrenListEvaluator : Evaluator
    {
        public override string Comments=> "获取MedicalInsuranceForChildren列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<MedicalInsuranceForChildrenSearchModel>() ?? new MedicalInsuranceForChildrenSearchModel();
                var query = ctx.MedicalInsuranceForChildren.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// MIFCUnitNumber NVARCHAR(50) 单位编号 
                if(!string.IsNullOrEmpty(searchModel.MIFCUnitNumber)) query = query.Where(t=>t.MIFCUnitNumber.Contains(searchModel.MIFCUnitNumber));
                if(sort=="MIFCUnitNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MIFCUnitNumber):query.OrderByDescending(t=>t.MIFCUnitNumber);
                    isordered = true;
                }
				// MIFCPersonnelNumber NVARCHAR(50) 人员编号 
                if(!string.IsNullOrEmpty(searchModel.MIFCPersonnelNumber)) query = query.Where(t=>t.MIFCPersonnelNumber.Contains(searchModel.MIFCPersonnelNumber));
                if(sort=="MIFCPersonnelNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MIFCPersonnelNumber):query.OrderByDescending(t=>t.MIFCPersonnelNumber);
                    isordered = true;
                }
				// MIFCFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.MIFCFullName)) query = query.Where(t=>t.MIFCFullName.Contains(searchModel.MIFCFullName));
                if(sort=="MIFCFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MIFCFullName):query.OrderByDescending(t=>t.MIFCFullName);
                    isordered = true;
                }
				// MIFCId NVARCHAR(4000) 身份证 
                if(!string.IsNullOrEmpty(searchModel.MIFCId)) query = query.Where(t=>t.MIFCId.Contains(searchModel.MIFCId));
                if(sort=="MIFCId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MIFCId):query.OrderByDescending(t=>t.MIFCId);
                    isordered = true;
                }
				// MIFCDateOfBirth DATETIME 出生日期 
                if(searchModel.FromMIFCDateOfBirth!=null) query = query.Where(t=>t.MIFCDateOfBirth>=searchModel.FromMIFCDateOfBirth);
                if(searchModel.ToMIFCDateOfBirth!=null) query = query.Where(t=>t.MIFCDateOfBirth<=searchModel.ToMIFCDateOfBirth);
                if(sort=="MIFCDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MIFCDateOfBirth):query.OrderByDescending(t=>t.MIFCDateOfBirth);
                    isordered = true;
                }
				// MIFCExemptionCategory NVARCHAR(50) 免缴种类 
                if(!string.IsNullOrEmpty(searchModel.MIFCExemptionCategory)) query = query.Where(t=>t.MIFCExemptionCategory.Contains(searchModel.MIFCExemptionCategory));
                if(sort=="MIFCExemptionCategory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MIFCExemptionCategory):query.OrderByDescending(t=>t.MIFCExemptionCategory);
                    isordered = true;
                }
				// MIFCExemptionNumber NVARCHAR(50) 免缴号码 
                if(!string.IsNullOrEmpty(searchModel.MIFCExemptionNumber)) query = query.Where(t=>t.MIFCExemptionNumber.Contains(searchModel.MIFCExemptionNumber));
                if(sort=="MIFCExemptionNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MIFCExemptionNumber):query.OrderByDescending(t=>t.MIFCExemptionNumber);
                    isordered = true;
                }
				// MIFCContacts NVARCHAR(50) 联系人 
                if(!string.IsNullOrEmpty(searchModel.MIFCContacts)) query = query.Where(t=>t.MIFCContacts.Contains(searchModel.MIFCContacts));
                if(sort=="MIFCContacts")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MIFCContacts):query.OrderByDescending(t=>t.MIFCContacts);
                    isordered = true;
                }
				// MIFCContactNumber NVARCHAR(50) 联系电话 
                if(!string.IsNullOrEmpty(searchModel.MIFCContactNumber)) query = query.Where(t=>t.MIFCContactNumber.Contains(searchModel.MIFCContactNumber));
                if(sort=="MIFCContactNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.MIFCContactNumber):query.OrderByDescending(t=>t.MIFCContactNumber);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.MIFCUnitNumber.Contains(search)||t.MIFCPersonnelNumber.Contains(search)||t.MIFCFullName.Contains(search)||t.MIFCId.Contains(search)||t.MIFCExemptionCategory.Contains(search)||t.MIFCExemptionNumber.Contains(search)||t.MIFCContacts.Contains(search)||t.MIFCContactNumber.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<MedicalInsuranceForChildren>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【农村医疗】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class RuralMedicalTreatmentCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.RuralMedicalTreatment.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【农村医疗】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【农村医疗】
    /// </summary>
    public partial class DeleteRuralMedicalTreatmentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<RuralMedicalTreatment>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.RuralMedicalTreatment.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.RuralMedicalTreatment.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条农村医疗记录";
    }
	
    /// <summary>
    /// 保存【农村医疗】
    /// </summary>
    public partial class SaveRuralMedicalTreatmentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<RuralMedicalTreatment>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.RuralMedicalTreatment.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.RuralMedicalTreatment.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.RMTPersonnelNumber = HttpUtility.UrlDecode(entity.RMTPersonnelNumber);
					// NVARCHAR(50)
				entity.RMTFullName = HttpUtility.UrlDecode(entity.RMTFullName);
					// NVARCHAR(4000)
				entity.RMTId = HttpUtility.UrlDecode(entity.RMTId);
					// NVARCHAR(50)
				entity.RMTExemptionCategory = HttpUtility.UrlDecode(entity.RMTExemptionCategory);
					// NVARCHAR(50)
				entity.RMTExemptionNumber = HttpUtility.UrlDecode(entity.RMTExemptionNumber);
					// NVARCHAR(50)
				entity.RMTContacts = HttpUtility.UrlDecode(entity.RMTContacts);
					// NVARCHAR(50)
				entity.RMTContactNumber = HttpUtility.UrlDecode(entity.RMTContactNumber);
					// NVARCHAR(50)
				entity.RMTRegion = HttpUtility.UrlDecode(entity.RMTRegion);
					// NVARCHAR(50)
				entity.RMTOperation = HttpUtility.UrlDecode(entity.RMTOperation);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.RuralMedicalTreatment.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条RuralMedicalTreatment记录";
    }
	
    /// <summary>
    /// 查询空的【农村医疗】
    /// </summary>
    public partial class GetRuralMedicalTreatmentEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new RuralMedicalTreatment();
        }
        public override string Comments=> "获取空的农村医疗记录";
    }
	
    /// <summary>
    /// 查询【农村医疗】列表
    /// </summary>
    public partial class GetRuralMedicalTreatmentListEvaluator : Evaluator
    {
        public override string Comments=> "获取RuralMedicalTreatment列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<RuralMedicalTreatmentSearchModel>() ?? new RuralMedicalTreatmentSearchModel();
                var query = ctx.RuralMedicalTreatment.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// RMTPersonnelNumber NVARCHAR(50) 人员编号 
                if(!string.IsNullOrEmpty(searchModel.RMTPersonnelNumber)) query = query.Where(t=>t.RMTPersonnelNumber.Contains(searchModel.RMTPersonnelNumber));
                if(sort=="RMTPersonnelNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMTPersonnelNumber):query.OrderByDescending(t=>t.RMTPersonnelNumber);
                    isordered = true;
                }
				// RMTFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.RMTFullName)) query = query.Where(t=>t.RMTFullName.Contains(searchModel.RMTFullName));
                if(sort=="RMTFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMTFullName):query.OrderByDescending(t=>t.RMTFullName);
                    isordered = true;
                }
				// RMTId NVARCHAR(4000) 身份证 
                if(!string.IsNullOrEmpty(searchModel.RMTId)) query = query.Where(t=>t.RMTId.Contains(searchModel.RMTId));
                if(sort=="RMTId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMTId):query.OrderByDescending(t=>t.RMTId);
                    isordered = true;
                }
				// RMTExemptionCategory NVARCHAR(50) 免缴种类 
                if(!string.IsNullOrEmpty(searchModel.RMTExemptionCategory)) query = query.Where(t=>t.RMTExemptionCategory.Contains(searchModel.RMTExemptionCategory));
                if(sort=="RMTExemptionCategory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMTExemptionCategory):query.OrderByDescending(t=>t.RMTExemptionCategory);
                    isordered = true;
                }
				// RMTExemptionNumber NVARCHAR(50) 免缴号码 
                if(!string.IsNullOrEmpty(searchModel.RMTExemptionNumber)) query = query.Where(t=>t.RMTExemptionNumber.Contains(searchModel.RMTExemptionNumber));
                if(sort=="RMTExemptionNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMTExemptionNumber):query.OrderByDescending(t=>t.RMTExemptionNumber);
                    isordered = true;
                }
				// RMTContacts NVARCHAR(50) 联系人 
                if(!string.IsNullOrEmpty(searchModel.RMTContacts)) query = query.Where(t=>t.RMTContacts.Contains(searchModel.RMTContacts));
                if(sort=="RMTContacts")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMTContacts):query.OrderByDescending(t=>t.RMTContacts);
                    isordered = true;
                }
				// RMTContactNumber NVARCHAR(50) 联系电话 
                if(!string.IsNullOrEmpty(searchModel.RMTContactNumber)) query = query.Where(t=>t.RMTContactNumber.Contains(searchModel.RMTContactNumber));
                if(sort=="RMTContactNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMTContactNumber):query.OrderByDescending(t=>t.RMTContactNumber);
                    isordered = true;
                }
				// RMTRegion NVARCHAR(50) 区域 
                if(!string.IsNullOrEmpty(searchModel.RMTRegion)) query = query.Where(t=>t.RMTRegion.Contains(searchModel.RMTRegion));
                if(sort=="RMTRegion")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMTRegion):query.OrderByDescending(t=>t.RMTRegion);
                    isordered = true;
                }
				// RMTOperation NVARCHAR(50) 操作 
                if(!string.IsNullOrEmpty(searchModel.RMTOperation)) query = query.Where(t=>t.RMTOperation.Contains(searchModel.RMTOperation));
                if(sort=="RMTOperation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RMTOperation):query.OrderByDescending(t=>t.RMTOperation);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.RMTPersonnelNumber.Contains(search)||t.RMTFullName.Contains(search)||t.RMTId.Contains(search)||t.RMTExemptionCategory.Contains(search)||t.RMTExemptionNumber.Contains(search)||t.RMTContacts.Contains(search)||t.RMTContactNumber.Contains(search)||t.RMTRegion.Contains(search)||t.RMTOperation.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<RuralMedicalTreatment>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【福利发放】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class WelfarePaymentCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.WelfarePayment.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【福利发放】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【福利发放】
    /// </summary>
    public partial class DeleteWelfarePaymentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<WelfarePayment>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.WelfarePayment.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.WelfarePayment.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条福利发放记录";
    }
	
    /// <summary>
    /// 保存【福利发放】
    /// </summary>
    public partial class SaveWelfarePaymentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<WelfarePayment>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.WelfarePayment.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.WelfarePayment.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.WPFullName = HttpUtility.UrlDecode(entity.WPFullName);
					// NVARCHAR(50)
				entity.WPGender = HttpUtility.UrlDecode(entity.WPGender);
					// NVARCHAR(4000)
				entity.WPIdNumber = HttpUtility.UrlDecode(entity.WPIdNumber);
					// NVARCHAR(50)
				entity.WPWelfareType = HttpUtility.UrlDecode(entity.WPWelfareType);
					// NVARCHAR(50)
				entity.WPInsuredId = HttpUtility.UrlDecode(entity.WPInsuredId);
					// NVARCHAR(50)
				entity.WPAddress = HttpUtility.UrlDecode(entity.WPAddress);
					// NVARCHAR(50)
				entity.WPRegion = HttpUtility.UrlDecode(entity.WPRegion);
					// NVARCHAR(50)
				entity.WPOperation = HttpUtility.UrlDecode(entity.WPOperation);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.WelfarePayment.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条WelfarePayment记录";
    }
	
    /// <summary>
    /// 查询空的【福利发放】
    /// </summary>
    public partial class GetWelfarePaymentEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new WelfarePayment();
        }
        public override string Comments=> "获取空的福利发放记录";
    }
	
    /// <summary>
    /// 查询【福利发放】列表
    /// </summary>
    public partial class GetWelfarePaymentListEvaluator : Evaluator
    {
        public override string Comments=> "获取WelfarePayment列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<WelfarePaymentSearchModel>() ?? new WelfarePaymentSearchModel();
                var query = ctx.WelfarePayment.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// WPFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.WPFullName)) query = query.Where(t=>t.WPFullName.Contains(searchModel.WPFullName));
                if(sort=="WPFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPFullName):query.OrderByDescending(t=>t.WPFullName);
                    isordered = true;
                }
				// WPGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.WPGender)) query = query.Where(t=>t.WPGender.Contains(searchModel.WPGender));
                if(sort=="WPGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPGender):query.OrderByDescending(t=>t.WPGender);
                    isordered = true;
                }
				// WPAge INT 年龄 
                if(searchModel.MinWPAge!=null) query = query.Where(t=>t.WPAge>=searchModel.MinWPAge);
                if(searchModel.MaxWPAge!=null) query = query.Where(t=>t.WPAge<=searchModel.MaxWPAge);
                if(sort=="WPAge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPAge):query.OrderByDescending(t=>t.WPAge);
                    isordered = true;
                }
				// WPIdNumber NVARCHAR(4000) 身份证号 
                if(!string.IsNullOrEmpty(searchModel.WPIdNumber)) query = query.Where(t=>t.WPIdNumber.Contains(searchModel.WPIdNumber));
                if(sort=="WPIdNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPIdNumber):query.OrderByDescending(t=>t.WPIdNumber);
                    isordered = true;
                }
				// WPWelfareType NVARCHAR(50) 福利类型 
                if(!string.IsNullOrEmpty(searchModel.WPWelfareType)) query = query.Where(t=>t.WPWelfareType.Contains(searchModel.WPWelfareType));
                if(sort=="WPWelfareType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPWelfareType):query.OrderByDescending(t=>t.WPWelfareType);
                    isordered = true;
                }
				// WPPaymentAmount MONEY 发放金额 
                if(searchModel.MinWPPaymentAmount!=null) query = query.Where(t=>t.WPPaymentAmount>=searchModel.MinWPPaymentAmount);
                if(searchModel.MaxWPPaymentAmount!=null) query = query.Where(t=>t.WPPaymentAmount<=searchModel.MaxWPPaymentAmount);
                if(sort=="WPPaymentAmount")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPPaymentAmount):query.OrderByDescending(t=>t.WPPaymentAmount);
                    isordered = true;
                }
				// WPDateOfIssue DATETIME 发放日期 
                if(searchModel.FromWPDateOfIssue!=null) query = query.Where(t=>t.WPDateOfIssue>=searchModel.FromWPDateOfIssue);
                if(searchModel.ToWPDateOfIssue!=null) query = query.Where(t=>t.WPDateOfIssue<=searchModel.ToWPDateOfIssue);
                if(sort=="WPDateOfIssue")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPDateOfIssue):query.OrderByDescending(t=>t.WPDateOfIssue);
                    isordered = true;
                }
				// WPInsuredId NVARCHAR(50) 被保人id 
                if(!string.IsNullOrEmpty(searchModel.WPInsuredId)) query = query.Where(t=>t.WPInsuredId.Contains(searchModel.WPInsuredId));
                if(sort=="WPInsuredId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPInsuredId):query.OrderByDescending(t=>t.WPInsuredId);
                    isordered = true;
                }
				// WPAddress NVARCHAR(50) 住址 
                if(!string.IsNullOrEmpty(searchModel.WPAddress)) query = query.Where(t=>t.WPAddress.Contains(searchModel.WPAddress));
                if(sort=="WPAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPAddress):query.OrderByDescending(t=>t.WPAddress);
                    isordered = true;
                }
				// WPRegion NVARCHAR(50) 区域 
                if(!string.IsNullOrEmpty(searchModel.WPRegion)) query = query.Where(t=>t.WPRegion.Contains(searchModel.WPRegion));
                if(sort=="WPRegion")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPRegion):query.OrderByDescending(t=>t.WPRegion);
                    isordered = true;
                }
				// WPOperation NVARCHAR(50) 操作 
                if(!string.IsNullOrEmpty(searchModel.WPOperation)) query = query.Where(t=>t.WPOperation.Contains(searchModel.WPOperation));
                if(sort=="WPOperation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.WPOperation):query.OrderByDescending(t=>t.WPOperation);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.WPFullName.Contains(search)||t.WPGender.Contains(search)||t.WPIdNumber.Contains(search)||t.WPWelfareType.Contains(search)||t.WPInsuredId.Contains(search)||t.WPAddress.Contains(search)||t.WPRegion.Contains(search)||t.WPOperation.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<WelfarePayment>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【服务预约】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ServiceAppointmentCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ServiceAppointment.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【服务预约】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【服务预约】
    /// </summary>
    public partial class DeleteServiceAppointmentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ServiceAppointment>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ServiceAppointment.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ServiceAppointment.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条服务预约记录";
    }
	
    /// <summary>
    /// 保存【服务预约】
    /// </summary>
    public partial class SaveServiceAppointmentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ServiceAppointment>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ServiceAppointment.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ServiceAppointment.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.SAServiceType = HttpUtility.UrlDecode(entity.SAServiceType);
					// NVARCHAR(50)
				entity.SAAppointments = HttpUtility.UrlDecode(entity.SAAppointments);
					// NVARCHAR(4000)
				entity.SAId = HttpUtility.UrlDecode(entity.SAId);
					// NVARCHAR(50)
				entity.SAState = HttpUtility.UrlDecode(entity.SAState);
					// NVARCHAR(50)
				entity.SAAuditRegistration = HttpUtility.UrlDecode(entity.SAAuditRegistration);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ServiceAppointment.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ServiceAppointment记录";
    }
	
    /// <summary>
    /// 查询空的【服务预约】
    /// </summary>
    public partial class GetServiceAppointmentEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ServiceAppointment();
        }
        public override string Comments=> "获取空的服务预约记录";
    }
	
    /// <summary>
    /// 查询【服务预约】列表
    /// </summary>
    public partial class GetServiceAppointmentListEvaluator : Evaluator
    {
        public override string Comments=> "获取ServiceAppointment列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ServiceAppointmentSearchModel>() ?? new ServiceAppointmentSearchModel();
                var query = ctx.ServiceAppointment.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// SAServiceType NVARCHAR(50) 服务类型 
                if(!string.IsNullOrEmpty(searchModel.SAServiceType)) query = query.Where(t=>t.SAServiceType.Contains(searchModel.SAServiceType));
                if(sort=="SAServiceType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SAServiceType):query.OrderByDescending(t=>t.SAServiceType);
                    isordered = true;
                }
				// SAAppointments NVARCHAR(50) 预约人 
                if(!string.IsNullOrEmpty(searchModel.SAAppointments)) query = query.Where(t=>t.SAAppointments.Contains(searchModel.SAAppointments));
                if(sort=="SAAppointments")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SAAppointments):query.OrderByDescending(t=>t.SAAppointments);
                    isordered = true;
                }
				// SATimeOfAppointment DATETIME 预约时间 
                if(searchModel.FromSATimeOfAppointment!=null) query = query.Where(t=>t.SATimeOfAppointment>=searchModel.FromSATimeOfAppointment);
                if(searchModel.ToSATimeOfAppointment!=null) query = query.Where(t=>t.SATimeOfAppointment<=searchModel.ToSATimeOfAppointment);
                if(sort=="SATimeOfAppointment")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SATimeOfAppointment):query.OrderByDescending(t=>t.SATimeOfAppointment);
                    isordered = true;
                }
				// SAId NVARCHAR(4000) 身份证 
                if(!string.IsNullOrEmpty(searchModel.SAId)) query = query.Where(t=>t.SAId.Contains(searchModel.SAId));
                if(sort=="SAId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SAId):query.OrderByDescending(t=>t.SAId);
                    isordered = true;
                }
				// SACreationTime DATETIME 创建时间 
                if(searchModel.FromSACreationTime!=null) query = query.Where(t=>t.SACreationTime>=searchModel.FromSACreationTime);
                if(searchModel.ToSACreationTime!=null) query = query.Where(t=>t.SACreationTime<=searchModel.ToSACreationTime);
                if(sort=="SACreationTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SACreationTime):query.OrderByDescending(t=>t.SACreationTime);
                    isordered = true;
                }
				// SAAuditTime DATETIME 审核时间 
                if(searchModel.FromSAAuditTime!=null) query = query.Where(t=>t.SAAuditTime>=searchModel.FromSAAuditTime);
                if(searchModel.ToSAAuditTime!=null) query = query.Where(t=>t.SAAuditTime<=searchModel.ToSAAuditTime);
                if(sort=="SAAuditTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SAAuditTime):query.OrderByDescending(t=>t.SAAuditTime);
                    isordered = true;
                }
				// SAState NVARCHAR(50) 状态 
                if(searchModel.SAState!=null && searchModel.SAState.Length!=0) query = query.Where(t=>searchModel.SAState.Contains(t.SAState));
                if(sort=="SAState")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SAState):query.OrderByDescending(t=>t.SAState);
                    isordered = true;
                }
				// SAAuditRegistration NVARCHAR(50) 审核登记 
                if(!string.IsNullOrEmpty(searchModel.SAAuditRegistration)) query = query.Where(t=>t.SAAuditRegistration.Contains(searchModel.SAAuditRegistration));
                if(sort=="SAAuditRegistration")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SAAuditRegistration):query.OrderByDescending(t=>t.SAAuditRegistration);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.SAServiceType.Contains(search)||t.SAAppointments.Contains(search)||t.SAId.Contains(search)||t.SAState.Contains(search)||t.SAAuditRegistration.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ServiceAppointment>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【日程管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ScheduleManagementCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ScheduleManagement.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【日程管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【日程管理】
    /// </summary>
    public partial class DeleteScheduleManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ScheduleManagement>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ScheduleManagement.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ScheduleManagement.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条日程管理记录";
    }
	
    /// <summary>
    /// 保存【日程管理】
    /// </summary>
    public partial class SaveScheduleManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ScheduleManagement>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ScheduleManagement.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ScheduleManagement.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.SMActivityType = HttpUtility.UrlDecode(entity.SMActivityType);
					// NVARCHAR(4000)
				entity.SMContent = HttpUtility.UrlDecode(entity.SMContent);
					// NVARCHAR(50)
				entity.SMPlace = HttpUtility.UrlDecode(entity.SMPlace);
					// NVARCHAR(50)
				entity.SMPersonInCharge = HttpUtility.UrlDecode(entity.SMPersonInCharge);
					// NVARCHAR(50)
				entity.SMTelephone = HttpUtility.UrlDecode(entity.SMTelephone);
					// NVARCHAR(4000)
				entity.SMRemarks = HttpUtility.UrlDecode(entity.SMRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ScheduleManagement.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ScheduleManagement记录";
    }
	
    /// <summary>
    /// 查询空的【日程管理】
    /// </summary>
    public partial class GetScheduleManagementEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ScheduleManagement();
        }
        public override string Comments=> "获取空的日程管理记录";
    }
	
    /// <summary>
    /// 查询【日程管理】列表
    /// </summary>
    public partial class GetScheduleManagementListEvaluator : Evaluator
    {
        public override string Comments=> "获取ScheduleManagement列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ScheduleManagementSearchModel>() ?? new ScheduleManagementSearchModel();
                var query = ctx.ScheduleManagement.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// SMActivityType NVARCHAR(50) 活动类型 
                if(!string.IsNullOrEmpty(searchModel.SMActivityType)) query = query.Where(t=>t.SMActivityType.Contains(searchModel.SMActivityType));
                if(sort=="SMActivityType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SMActivityType):query.OrderByDescending(t=>t.SMActivityType);
                    isordered = true;
                }
				// SMStartDate DATETIME 开始日期 
                if(searchModel.FromSMStartDate!=null) query = query.Where(t=>t.SMStartDate>=searchModel.FromSMStartDate);
                if(searchModel.ToSMStartDate!=null) query = query.Where(t=>t.SMStartDate<=searchModel.ToSMStartDate);
                if(sort=="SMStartDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SMStartDate):query.OrderByDescending(t=>t.SMStartDate);
                    isordered = true;
                }
				// SMEndDate DATETIME 结束日期 
                if(searchModel.FromSMEndDate!=null) query = query.Where(t=>t.SMEndDate>=searchModel.FromSMEndDate);
                if(searchModel.ToSMEndDate!=null) query = query.Where(t=>t.SMEndDate<=searchModel.ToSMEndDate);
                if(sort=="SMEndDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SMEndDate):query.OrderByDescending(t=>t.SMEndDate);
                    isordered = true;
                }
				// SMContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.SMContent)) query = query.Where(t=>t.SMContent.Contains(searchModel.SMContent));
                if(sort=="SMContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SMContent):query.OrderByDescending(t=>t.SMContent);
                    isordered = true;
                }
				// SMPlace NVARCHAR(50) 地点 
                if(!string.IsNullOrEmpty(searchModel.SMPlace)) query = query.Where(t=>t.SMPlace.Contains(searchModel.SMPlace));
                if(sort=="SMPlace")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SMPlace):query.OrderByDescending(t=>t.SMPlace);
                    isordered = true;
                }
				// SMPersonInCharge NVARCHAR(50) 负责人 
                if(!string.IsNullOrEmpty(searchModel.SMPersonInCharge)) query = query.Where(t=>t.SMPersonInCharge.Contains(searchModel.SMPersonInCharge));
                if(sort=="SMPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SMPersonInCharge):query.OrderByDescending(t=>t.SMPersonInCharge);
                    isordered = true;
                }
				// SMTelephone NVARCHAR(50) 电话 
                if(!string.IsNullOrEmpty(searchModel.SMTelephone)) query = query.Where(t=>t.SMTelephone.Contains(searchModel.SMTelephone));
                if(sort=="SMTelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SMTelephone):query.OrderByDescending(t=>t.SMTelephone);
                    isordered = true;
                }
				// SMRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.SMRemarks)) query = query.Where(t=>t.SMRemarks.Contains(searchModel.SMRemarks));
                if(sort=="SMRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SMRemarks):query.OrderByDescending(t=>t.SMRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.SMActivityType.Contains(search)||t.SMContent.Contains(search)||t.SMPlace.Contains(search)||t.SMPersonInCharge.Contains(search)||t.SMTelephone.Contains(search)||t.SMRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ScheduleManagement>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【专家管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ExpertManagementCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ExpertManagement.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【专家管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【专家管理】
    /// </summary>
    public partial class DeleteExpertManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ExpertManagement>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ExpertManagement.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ExpertManagement.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条专家管理记录";
    }
	
    /// <summary>
    /// 保存【专家管理】
    /// </summary>
    public partial class SaveExpertManagementEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ExpertManagement>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ExpertManagement.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ExpertManagement.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.EMTechnicalExpertise = HttpUtility.UrlDecode(entity.EMTechnicalExpertise);
					// NVARCHAR(50)
				entity.EMFullName = HttpUtility.UrlDecode(entity.EMFullName);
					// NVARCHAR(50)
				entity.EMGender = HttpUtility.UrlDecode(entity.EMGender);
					// NVARCHAR(4000)
				entity.EMId = HttpUtility.UrlDecode(entity.EMId);
					// NVARCHAR(4000)
				entity.EMAddress = HttpUtility.UrlDecode(entity.EMAddress);
					// NVARCHAR(50)
				entity.EMContactNumber = HttpUtility.UrlDecode(entity.EMContactNumber);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ExpertManagement.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ExpertManagement记录";
    }
	
    /// <summary>
    /// 查询空的【专家管理】
    /// </summary>
    public partial class GetExpertManagementEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ExpertManagement();
        }
        public override string Comments=> "获取空的专家管理记录";
    }
	
    /// <summary>
    /// 查询【专家管理】列表
    /// </summary>
    public partial class GetExpertManagementListEvaluator : Evaluator
    {
        public override string Comments=> "获取ExpertManagement列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ExpertManagementSearchModel>() ?? new ExpertManagementSearchModel();
                var query = ctx.ExpertManagement.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// EMTechnicalExpertise NVARCHAR(50) 技术特长 
                if(!string.IsNullOrEmpty(searchModel.EMTechnicalExpertise)) query = query.Where(t=>t.EMTechnicalExpertise.Contains(searchModel.EMTechnicalExpertise));
                if(sort=="EMTechnicalExpertise")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EMTechnicalExpertise):query.OrderByDescending(t=>t.EMTechnicalExpertise);
                    isordered = true;
                }
				// EMFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.EMFullName)) query = query.Where(t=>t.EMFullName.Contains(searchModel.EMFullName));
                if(sort=="EMFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EMFullName):query.OrderByDescending(t=>t.EMFullName);
                    isordered = true;
                }
				// EMGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.EMGender)) query = query.Where(t=>t.EMGender.Contains(searchModel.EMGender));
                if(sort=="EMGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EMGender):query.OrderByDescending(t=>t.EMGender);
                    isordered = true;
                }
				// EMDateOfBirth DATETIME 出生日期 
                if(searchModel.FromEMDateOfBirth!=null) query = query.Where(t=>t.EMDateOfBirth>=searchModel.FromEMDateOfBirth);
                if(searchModel.ToEMDateOfBirth!=null) query = query.Where(t=>t.EMDateOfBirth<=searchModel.ToEMDateOfBirth);
                if(sort=="EMDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EMDateOfBirth):query.OrderByDescending(t=>t.EMDateOfBirth);
                    isordered = true;
                }
				// EMId NVARCHAR(4000) 身份证 
                if(!string.IsNullOrEmpty(searchModel.EMId)) query = query.Where(t=>t.EMId.Contains(searchModel.EMId));
                if(sort=="EMId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EMId):query.OrderByDescending(t=>t.EMId);
                    isordered = true;
                }
				// EMAddress NVARCHAR(4000) 地址 
                if(!string.IsNullOrEmpty(searchModel.EMAddress)) query = query.Where(t=>t.EMAddress.Contains(searchModel.EMAddress));
                if(sort=="EMAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EMAddress):query.OrderByDescending(t=>t.EMAddress);
                    isordered = true;
                }
				// EMContactNumber NVARCHAR(50) 联系电话 
                if(!string.IsNullOrEmpty(searchModel.EMContactNumber)) query = query.Where(t=>t.EMContactNumber.Contains(searchModel.EMContactNumber));
                if(sort=="EMContactNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EMContactNumber):query.OrderByDescending(t=>t.EMContactNumber);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.EMTechnicalExpertise.Contains(search)||t.EMFullName.Contains(search)||t.EMGender.Contains(search)||t.EMId.Contains(search)||t.EMAddress.Contains(search)||t.EMContactNumber.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ExpertManagement>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【权限访问】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PermissionAccessCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.PermissionAccess.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【权限访问】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【权限访问】
    /// </summary>
    public partial class DeletePermissionAccessEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<PermissionAccess>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.PermissionAccess.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.PermissionAccess.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条权限访问记录";
    }
	
    /// <summary>
    /// 保存【权限访问】
    /// </summary>
    public partial class SavePermissionAccessEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<PermissionAccess>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.PermissionAccess.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.PermissionAccess.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.PAFullName = HttpUtility.UrlDecode(entity.PAFullName);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.PermissionAccess.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条PermissionAccess记录";
    }
	
    /// <summary>
    /// 查询空的【权限访问】
    /// </summary>
    public partial class GetPermissionAccessEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new PermissionAccess();
        }
        public override string Comments=> "获取空的权限访问记录";
    }
	
    /// <summary>
    /// 查询【权限访问】列表
    /// </summary>
    public partial class GetPermissionAccessListEvaluator : Evaluator
    {
        public override string Comments=> "获取PermissionAccess列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PermissionAccessSearchModel>() ?? new PermissionAccessSearchModel();
                var query = ctx.PermissionAccess.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PAFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.PAFullName)) query = query.Where(t=>t.PAFullName.Contains(searchModel.PAFullName));
                if(sort=="PAFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAFullName):query.OrderByDescending(t=>t.PAFullName);
                    isordered = true;
                }
				// PAAccessTime DATETIME 访问时间 
                if(searchModel.FromPAAccessTime!=null) query = query.Where(t=>t.PAAccessTime>=searchModel.FromPAAccessTime);
                if(searchModel.ToPAAccessTime!=null) query = query.Where(t=>t.PAAccessTime<=searchModel.ToPAAccessTime);
                if(sort=="PAAccessTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAAccessTime):query.OrderByDescending(t=>t.PAAccessTime);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PAFullName.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<PermissionAccess>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【便民指南】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ConvenienceGuideCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ConvenienceGuide.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【便民指南】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【便民指南】
    /// </summary>
    public partial class DeleteConvenienceGuideEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ConvenienceGuide>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ConvenienceGuide.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ConvenienceGuide.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条便民指南记录";
    }
	
    /// <summary>
    /// 保存【便民指南】
    /// </summary>
    public partial class SaveConvenienceGuideEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ConvenienceGuide>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ConvenienceGuide.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ConvenienceGuide.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.CGTitle = HttpUtility.UrlDecode(entity.CGTitle);
					// NVARCHAR(4000)
				entity.CGPicture = HttpUtility.UrlDecode(entity.CGPicture);
					// NVARCHAR(4000)
				entity.CGContent = HttpUtility.UrlDecode(entity.CGContent);
					// NVARCHAR(4000)
				entity.CGAbstract = HttpUtility.UrlDecode(entity.CGAbstract);
					// NVARCHAR(4000)
				entity.CGRemarks = HttpUtility.UrlDecode(entity.CGRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ConvenienceGuide.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ConvenienceGuide记录";
    }
	
    /// <summary>
    /// 查询空的【便民指南】
    /// </summary>
    public partial class GetConvenienceGuideEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ConvenienceGuide();
        }
        public override string Comments=> "获取空的便民指南记录";
    }
	
    /// <summary>
    /// 查询【便民指南】列表
    /// </summary>
    public partial class GetConvenienceGuideListEvaluator : Evaluator
    {
        public override string Comments=> "获取ConvenienceGuide列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ConvenienceGuideSearchModel>() ?? new ConvenienceGuideSearchModel();
                var query = ctx.ConvenienceGuide.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// CGTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.CGTitle)) query = query.Where(t=>t.CGTitle.Contains(searchModel.CGTitle));
                if(sort=="CGTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CGTitle):query.OrderByDescending(t=>t.CGTitle);
                    isordered = true;
                }
				// CGReleaseTime DATETIME 发布时间 
                if(searchModel.FromCGReleaseTime!=null) query = query.Where(t=>t.CGReleaseTime>=searchModel.FromCGReleaseTime);
                if(searchModel.ToCGReleaseTime!=null) query = query.Where(t=>t.CGReleaseTime<=searchModel.ToCGReleaseTime);
                if(sort=="CGReleaseTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CGReleaseTime):query.OrderByDescending(t=>t.CGReleaseTime);
                    isordered = true;
                }
				// CGPicture NVARCHAR(4000) 图片 
                if(!string.IsNullOrEmpty(searchModel.CGPicture)) query = query.Where(t=>t.CGPicture.Contains(searchModel.CGPicture));
                if(sort=="CGPicture")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CGPicture):query.OrderByDescending(t=>t.CGPicture);
                    isordered = true;
                }
				// CGContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.CGContent)) query = query.Where(t=>t.CGContent.Contains(searchModel.CGContent));
                if(sort=="CGContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CGContent):query.OrderByDescending(t=>t.CGContent);
                    isordered = true;
                }
				// CGAbstract NVARCHAR(4000) 摘要 
                if(!string.IsNullOrEmpty(searchModel.CGAbstract)) query = query.Where(t=>t.CGAbstract.Contains(searchModel.CGAbstract));
                if(sort=="CGAbstract")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CGAbstract):query.OrderByDescending(t=>t.CGAbstract);
                    isordered = true;
                }
				// CGRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.CGRemarks)) query = query.Where(t=>t.CGRemarks.Contains(searchModel.CGRemarks));
                if(sort=="CGRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CGRemarks):query.OrderByDescending(t=>t.CGRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.CGTitle.Contains(search)||t.CGPicture.Contains(search)||t.CGContent.Contains(search)||t.CGAbstract.Contains(search)||t.CGRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ConvenienceGuide>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【便民生活】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ConvenientLifeCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ConvenientLife.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【便民生活】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【便民生活】
    /// </summary>
    public partial class DeleteConvenientLifeEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ConvenientLife>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ConvenientLife.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ConvenientLife.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条便民生活记录";
    }
	
    /// <summary>
    /// 保存【便民生活】
    /// </summary>
    public partial class SaveConvenientLifeEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ConvenientLife>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ConvenientLife.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ConvenientLife.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.CLTitle = HttpUtility.UrlDecode(entity.CLTitle);
					// NVARCHAR(4000)
				entity.CLPicture = HttpUtility.UrlDecode(entity.CLPicture);
					// NVARCHAR(4000)
				entity.CLContent = HttpUtility.UrlDecode(entity.CLContent);
					// NVARCHAR(4000)
				entity.CLAbstract = HttpUtility.UrlDecode(entity.CLAbstract);
					// NVARCHAR(4000)
				entity.CLRemarks = HttpUtility.UrlDecode(entity.CLRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ConvenientLife.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ConvenientLife记录";
    }
	
    /// <summary>
    /// 查询空的【便民生活】
    /// </summary>
    public partial class GetConvenientLifeEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ConvenientLife();
        }
        public override string Comments=> "获取空的便民生活记录";
    }
	
    /// <summary>
    /// 查询【便民生活】列表
    /// </summary>
    public partial class GetConvenientLifeListEvaluator : Evaluator
    {
        public override string Comments=> "获取ConvenientLife列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ConvenientLifeSearchModel>() ?? new ConvenientLifeSearchModel();
                var query = ctx.ConvenientLife.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// CLTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.CLTitle)) query = query.Where(t=>t.CLTitle.Contains(searchModel.CLTitle));
                if(sort=="CLTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CLTitle):query.OrderByDescending(t=>t.CLTitle);
                    isordered = true;
                }
				// CLReleaseTime DATETIME 发布时间 
                if(searchModel.FromCLReleaseTime!=null) query = query.Where(t=>t.CLReleaseTime>=searchModel.FromCLReleaseTime);
                if(searchModel.ToCLReleaseTime!=null) query = query.Where(t=>t.CLReleaseTime<=searchModel.ToCLReleaseTime);
                if(sort=="CLReleaseTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CLReleaseTime):query.OrderByDescending(t=>t.CLReleaseTime);
                    isordered = true;
                }
				// CLPicture NVARCHAR(4000) 图片 
                if(!string.IsNullOrEmpty(searchModel.CLPicture)) query = query.Where(t=>t.CLPicture.Contains(searchModel.CLPicture));
                if(sort=="CLPicture")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CLPicture):query.OrderByDescending(t=>t.CLPicture);
                    isordered = true;
                }
				// CLContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.CLContent)) query = query.Where(t=>t.CLContent.Contains(searchModel.CLContent));
                if(sort=="CLContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CLContent):query.OrderByDescending(t=>t.CLContent);
                    isordered = true;
                }
				// CLAbstract NVARCHAR(4000) 摘要 
                if(!string.IsNullOrEmpty(searchModel.CLAbstract)) query = query.Where(t=>t.CLAbstract.Contains(searchModel.CLAbstract));
                if(sort=="CLAbstract")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CLAbstract):query.OrderByDescending(t=>t.CLAbstract);
                    isordered = true;
                }
				// CLRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.CLRemarks)) query = query.Where(t=>t.CLRemarks.Contains(searchModel.CLRemarks));
                if(sort=="CLRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CLRemarks):query.OrderByDescending(t=>t.CLRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.CLTitle.Contains(search)||t.CLPicture.Contains(search)||t.CLContent.Contains(search)||t.CLAbstract.Contains(search)||t.CLRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ConvenientLife>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【香溪特色】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class CharacteristicOfXiangxiCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.CharacteristicOfXiangxi.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【香溪特色】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【香溪特色】
    /// </summary>
    public partial class DeleteCharacteristicOfXiangxiEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<CharacteristicOfXiangxi>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.CharacteristicOfXiangxi.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.CharacteristicOfXiangxi.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条香溪特色记录";
    }
	
    /// <summary>
    /// 保存【香溪特色】
    /// </summary>
    public partial class SaveCharacteristicOfXiangxiEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<CharacteristicOfXiangxi>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.CharacteristicOfXiangxi.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.CharacteristicOfXiangxi.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.COXTitle = HttpUtility.UrlDecode(entity.COXTitle);
					// NVARCHAR(4000)
				entity.COXPicture = HttpUtility.UrlDecode(entity.COXPicture);
					// NVARCHAR(4000)
				entity.COXContent = HttpUtility.UrlDecode(entity.COXContent);
					// NVARCHAR(4000)
				entity.COXAbstract = HttpUtility.UrlDecode(entity.COXAbstract);
					// NVARCHAR(4000)
				entity.COXRemarks = HttpUtility.UrlDecode(entity.COXRemarks);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.CharacteristicOfXiangxi.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条CharacteristicOfXiangxi记录";
    }
	
    /// <summary>
    /// 查询空的【香溪特色】
    /// </summary>
    public partial class GetCharacteristicOfXiangxiEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new CharacteristicOfXiangxi();
        }
        public override string Comments=> "获取空的香溪特色记录";
    }
	
    /// <summary>
    /// 查询【香溪特色】列表
    /// </summary>
    public partial class GetCharacteristicOfXiangxiListEvaluator : Evaluator
    {
        public override string Comments=> "获取CharacteristicOfXiangxi列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<CharacteristicOfXiangxiSearchModel>() ?? new CharacteristicOfXiangxiSearchModel();
                var query = ctx.CharacteristicOfXiangxi.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// COXTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.COXTitle)) query = query.Where(t=>t.COXTitle.Contains(searchModel.COXTitle));
                if(sort=="COXTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.COXTitle):query.OrderByDescending(t=>t.COXTitle);
                    isordered = true;
                }
				// COXReleaseTime DATETIME 发布时间 
                if(searchModel.FromCOXReleaseTime!=null) query = query.Where(t=>t.COXReleaseTime>=searchModel.FromCOXReleaseTime);
                if(searchModel.ToCOXReleaseTime!=null) query = query.Where(t=>t.COXReleaseTime<=searchModel.ToCOXReleaseTime);
                if(sort=="COXReleaseTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.COXReleaseTime):query.OrderByDescending(t=>t.COXReleaseTime);
                    isordered = true;
                }
				// COXPicture NVARCHAR(4000) 图片 
                if(!string.IsNullOrEmpty(searchModel.COXPicture)) query = query.Where(t=>t.COXPicture.Contains(searchModel.COXPicture));
                if(sort=="COXPicture")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.COXPicture):query.OrderByDescending(t=>t.COXPicture);
                    isordered = true;
                }
				// COXContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.COXContent)) query = query.Where(t=>t.COXContent.Contains(searchModel.COXContent));
                if(sort=="COXContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.COXContent):query.OrderByDescending(t=>t.COXContent);
                    isordered = true;
                }
				// COXAbstract NVARCHAR(4000) 摘要 
                if(!string.IsNullOrEmpty(searchModel.COXAbstract)) query = query.Where(t=>t.COXAbstract.Contains(searchModel.COXAbstract));
                if(sort=="COXAbstract")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.COXAbstract):query.OrderByDescending(t=>t.COXAbstract);
                    isordered = true;
                }
				// COXRemarks NVARCHAR(4000) 备注 
                if(!string.IsNullOrEmpty(searchModel.COXRemarks)) query = query.Where(t=>t.COXRemarks.Contains(searchModel.COXRemarks));
                if(sort=="COXRemarks")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.COXRemarks):query.OrderByDescending(t=>t.COXRemarks);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.COXTitle.Contains(search)||t.COXPicture.Contains(search)||t.COXContent.Contains(search)||t.COXAbstract.Contains(search)||t.COXRemarks.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<CharacteristicOfXiangxi>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【建议处理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ProposedTreatmentCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ProposedTreatment.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【建议处理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【建议处理】
    /// </summary>
    public partial class DeleteProposedTreatmentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ProposedTreatment>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ProposedTreatment.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ProposedTreatment.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条建议处理记录";
    }
	
    /// <summary>
    /// 保存【建议处理】
    /// </summary>
    public partial class SaveProposedTreatmentEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ProposedTreatment>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ProposedTreatment.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ProposedTreatment.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.PTTitle = HttpUtility.UrlDecode(entity.PTTitle);
					// NVARCHAR(4000)
				entity.PTContent = HttpUtility.UrlDecode(entity.PTContent);
					// NVARCHAR(50)
				entity.PTObject = HttpUtility.UrlDecode(entity.PTObject);
					// NVARCHAR(50)
				entity.PTDealingWithPeople = HttpUtility.UrlDecode(entity.PTDealingWithPeople);
					// NVARCHAR(50)
				entity.PTFullName = HttpUtility.UrlDecode(entity.PTFullName);
					// NVARCHAR(4000)
				entity.PTId = HttpUtility.UrlDecode(entity.PTId);
					// NVARCHAR(50)
				entity.PTTelephone = HttpUtility.UrlDecode(entity.PTTelephone);
					// NVARCHAR(50)
				entity.PTState = HttpUtility.UrlDecode(entity.PTState);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ProposedTreatment.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ProposedTreatment记录";
    }
	
    /// <summary>
    /// 查询空的【建议处理】
    /// </summary>
    public partial class GetProposedTreatmentEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ProposedTreatment();
        }
        public override string Comments=> "获取空的建议处理记录";
    }
	
    /// <summary>
    /// 查询【建议处理】列表
    /// </summary>
    public partial class GetProposedTreatmentListEvaluator : Evaluator
    {
        public override string Comments=> "获取ProposedTreatment列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ProposedTreatmentSearchModel>() ?? new ProposedTreatmentSearchModel();
                var query = ctx.ProposedTreatment.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PTTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.PTTitle)) query = query.Where(t=>t.PTTitle.Contains(searchModel.PTTitle));
                if(sort=="PTTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTTitle):query.OrderByDescending(t=>t.PTTitle);
                    isordered = true;
                }
				// PTContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.PTContent)) query = query.Where(t=>t.PTContent.Contains(searchModel.PTContent));
                if(sort=="PTContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTContent):query.OrderByDescending(t=>t.PTContent);
                    isordered = true;
                }
				// PTObject NVARCHAR(50) 对象 
                if(!string.IsNullOrEmpty(searchModel.PTObject)) query = query.Where(t=>t.PTObject.Contains(searchModel.PTObject));
                if(sort=="PTObject")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTObject):query.OrderByDescending(t=>t.PTObject);
                    isordered = true;
                }
				// PTDealingWithPeople NVARCHAR(50) 处理人 
                if(!string.IsNullOrEmpty(searchModel.PTDealingWithPeople)) query = query.Where(t=>t.PTDealingWithPeople.Contains(searchModel.PTDealingWithPeople));
                if(sort=="PTDealingWithPeople")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTDealingWithPeople):query.OrderByDescending(t=>t.PTDealingWithPeople);
                    isordered = true;
                }
				// PTDateOfProcessing DATETIME 处理日期 
                if(searchModel.FromPTDateOfProcessing!=null) query = query.Where(t=>t.PTDateOfProcessing>=searchModel.FromPTDateOfProcessing);
                if(searchModel.ToPTDateOfProcessing!=null) query = query.Where(t=>t.PTDateOfProcessing<=searchModel.ToPTDateOfProcessing);
                if(sort=="PTDateOfProcessing")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTDateOfProcessing):query.OrderByDescending(t=>t.PTDateOfProcessing);
                    isordered = true;
                }
				// PTFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.PTFullName)) query = query.Where(t=>t.PTFullName.Contains(searchModel.PTFullName));
                if(sort=="PTFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTFullName):query.OrderByDescending(t=>t.PTFullName);
                    isordered = true;
                }
				// PTId NVARCHAR(4000) 身份证 
                if(!string.IsNullOrEmpty(searchModel.PTId)) query = query.Where(t=>t.PTId.Contains(searchModel.PTId));
                if(sort=="PTId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTId):query.OrderByDescending(t=>t.PTId);
                    isordered = true;
                }
				// PTTelephone NVARCHAR(50) 电话 
                if(!string.IsNullOrEmpty(searchModel.PTTelephone)) query = query.Where(t=>t.PTTelephone.Contains(searchModel.PTTelephone));
                if(sort=="PTTelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTTelephone):query.OrderByDescending(t=>t.PTTelephone);
                    isordered = true;
                }
				// PTCreationTime DATETIME 创建时间 
                if(searchModel.FromPTCreationTime!=null) query = query.Where(t=>t.PTCreationTime>=searchModel.FromPTCreationTime);
                if(searchModel.ToPTCreationTime!=null) query = query.Where(t=>t.PTCreationTime<=searchModel.ToPTCreationTime);
                if(sort=="PTCreationTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTCreationTime):query.OrderByDescending(t=>t.PTCreationTime);
                    isordered = true;
                }
				// PTState NVARCHAR(50) 状态 
                if(searchModel.PTState!=null && searchModel.PTState.Length!=0) query = query.Where(t=>searchModel.PTState.Contains(t.PTState));
                if(sort=="PTState")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTState):query.OrderByDescending(t=>t.PTState);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PTTitle.Contains(search)||t.PTContent.Contains(search)||t.PTObject.Contains(search)||t.PTDealingWithPeople.Contains(search)||t.PTFullName.Contains(search)||t.PTId.Contains(search)||t.PTTelephone.Contains(search)||t.PTState.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ProposedTreatment>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【村史】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class VillageHistoryCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.VillageHistory.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【村史】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【村史】
    /// </summary>
    public partial class DeleteVillageHistoryEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<VillageHistory>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.VillageHistory.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.VillageHistory.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条村史记录";
    }
	
    /// <summary>
    /// 保存【村史】
    /// </summary>
    public partial class SaveVillageHistoryEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<VillageHistory>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.VillageHistory.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.VillageHistory.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.VHMenuItem = HttpUtility.UrlDecode(entity.VHMenuItem);
					// NVARCHAR(4000)
				entity.VHMainTitle = HttpUtility.UrlDecode(entity.VHMainTitle);
					// NVARCHAR(4000)
				entity.VHSubheading = HttpUtility.UrlDecode(entity.VHSubheading);
					// NVARCHAR(4000)
				entity.VHPicture = HttpUtility.UrlDecode(entity.VHPicture);
					// NVARCHAR(4000)
				entity.VHAbstract = HttpUtility.UrlDecode(entity.VHAbstract);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.VillageHistory.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条VillageHistory记录";
    }
	
    /// <summary>
    /// 查询空的【村史】
    /// </summary>
    public partial class GetVillageHistoryEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new VillageHistory();
        }
        public override string Comments=> "获取空的村史记录";
    }
	
    /// <summary>
    /// 查询【村史】列表
    /// </summary>
    public partial class GetVillageHistoryListEvaluator : Evaluator
    {
        public override string Comments=> "获取VillageHistory列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<VillageHistorySearchModel>() ?? new VillageHistorySearchModel();
                var query = ctx.VillageHistory.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// VHMenuItem NVARCHAR(50) 菜单项 
                if(!string.IsNullOrEmpty(searchModel.VHMenuItem)) query = query.Where(t=>t.VHMenuItem.Contains(searchModel.VHMenuItem));
                if(sort=="VHMenuItem")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VHMenuItem):query.OrderByDescending(t=>t.VHMenuItem);
                    isordered = true;
                }
				// VHMainTitle NVARCHAR(4000) 主标题 
                if(!string.IsNullOrEmpty(searchModel.VHMainTitle)) query = query.Where(t=>t.VHMainTitle.Contains(searchModel.VHMainTitle));
                if(sort=="VHMainTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VHMainTitle):query.OrderByDescending(t=>t.VHMainTitle);
                    isordered = true;
                }
				// VHSubheading NVARCHAR(4000) 副标题 
                if(!string.IsNullOrEmpty(searchModel.VHSubheading)) query = query.Where(t=>t.VHSubheading.Contains(searchModel.VHSubheading));
                if(sort=="VHSubheading")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VHSubheading):query.OrderByDescending(t=>t.VHSubheading);
                    isordered = true;
                }
				// VHPicture NVARCHAR(4000) 图片 
                if(!string.IsNullOrEmpty(searchModel.VHPicture)) query = query.Where(t=>t.VHPicture.Contains(searchModel.VHPicture));
                if(sort=="VHPicture")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VHPicture):query.OrderByDescending(t=>t.VHPicture);
                    isordered = true;
                }
				// VHAbstract NVARCHAR(4000) 摘要 
                if(!string.IsNullOrEmpty(searchModel.VHAbstract)) query = query.Where(t=>t.VHAbstract.Contains(searchModel.VHAbstract));
                if(sort=="VHAbstract")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VHAbstract):query.OrderByDescending(t=>t.VHAbstract);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.VHMenuItem.Contains(search)||t.VHMainTitle.Contains(search)||t.VHSubheading.Contains(search)||t.VHPicture.Contains(search)||t.VHAbstract.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<VillageHistory>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【专项工作】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class SpecialWorkCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.SpecialWork.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【专项工作】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【专项工作】
    /// </summary>
    public partial class DeleteSpecialWorkEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<SpecialWork>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.SpecialWork.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.SpecialWork.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条专项工作记录";
    }
	
    /// <summary>
    /// 保存【专项工作】
    /// </summary>
    public partial class SaveSpecialWorkEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<SpecialWork>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.SpecialWork.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.SpecialWork.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.SWWorkTheme = HttpUtility.UrlDecode(entity.SWWorkTheme);
					// NVARCHAR(4000)
				entity.SWJobContent = HttpUtility.UrlDecode(entity.SWJobContent);
					// NVARCHAR(50)
				entity.SWState = HttpUtility.UrlDecode(entity.SWState);
					// NVARCHAR(4000)
				entity.SWPhoto = HttpUtility.UrlDecode(entity.SWPhoto);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.SpecialWork.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条SpecialWork记录";
    }
	
    /// <summary>
    /// 查询空的【专项工作】
    /// </summary>
    public partial class GetSpecialWorkEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new SpecialWork();
        }
        public override string Comments=> "获取空的专项工作记录";
    }
	
    /// <summary>
    /// 查询【专项工作】列表
    /// </summary>
    public partial class GetSpecialWorkListEvaluator : Evaluator
    {
        public override string Comments=> "获取SpecialWork列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<SpecialWorkSearchModel>() ?? new SpecialWorkSearchModel();
                var query = ctx.SpecialWork.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// SWWorkTheme NVARCHAR(50) 工作主题 
                if(!string.IsNullOrEmpty(searchModel.SWWorkTheme)) query = query.Where(t=>t.SWWorkTheme.Contains(searchModel.SWWorkTheme));
                if(sort=="SWWorkTheme")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWWorkTheme):query.OrderByDescending(t=>t.SWWorkTheme);
                    isordered = true;
                }
				// SWJobContent NVARCHAR(4000) 工作内容 
                if(!string.IsNullOrEmpty(searchModel.SWJobContent)) query = query.Where(t=>t.SWJobContent.Contains(searchModel.SWJobContent));
                if(sort=="SWJobContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWJobContent):query.OrderByDescending(t=>t.SWJobContent);
                    isordered = true;
                }
				// SWStartDate DATETIME 开始日期 
                if(searchModel.FromSWStartDate!=null) query = query.Where(t=>t.SWStartDate>=searchModel.FromSWStartDate);
                if(searchModel.ToSWStartDate!=null) query = query.Where(t=>t.SWStartDate<=searchModel.ToSWStartDate);
                if(sort=="SWStartDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWStartDate):query.OrderByDescending(t=>t.SWStartDate);
                    isordered = true;
                }
				// SWEndDate DATETIME 结束日期 
                if(searchModel.FromSWEndDate!=null) query = query.Where(t=>t.SWEndDate>=searchModel.FromSWEndDate);
                if(searchModel.ToSWEndDate!=null) query = query.Where(t=>t.SWEndDate<=searchModel.ToSWEndDate);
                if(sort=="SWEndDate")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWEndDate):query.OrderByDescending(t=>t.SWEndDate);
                    isordered = true;
                }
				// SWState NVARCHAR(50) 状态 
                if(searchModel.SWState!=null && searchModel.SWState.Length!=0) query = query.Where(t=>searchModel.SWState.Contains(t.SWState));
                if(sort=="SWState")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWState):query.OrderByDescending(t=>t.SWState);
                    isordered = true;
                }
				// SWPhoto NVARCHAR(4000) 照片 
                if(!string.IsNullOrEmpty(searchModel.SWPhoto)) query = query.Where(t=>t.SWPhoto.Contains(searchModel.SWPhoto));
                if(sort=="SWPhoto")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.SWPhoto):query.OrderByDescending(t=>t.SWPhoto);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.SWWorkTheme.Contains(search)||t.SWJobContent.Contains(search)||t.SWState.Contains(search)||t.SWPhoto.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<SpecialWork>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【视频点位信息】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class VideoPointInformationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.VideoPointInformation.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【视频点位信息】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【视频点位信息】
    /// </summary>
    public partial class DeleteVideoPointInformationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<VideoPointInformation>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.VideoPointInformation.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.VideoPointInformation.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条视频点位信息记录";
    }
	
    /// <summary>
    /// 保存【视频点位信息】
    /// </summary>
    public partial class SaveVideoPointInformationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<VideoPointInformation>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.VideoPointInformation.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.VideoPointInformation.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.VPISerialNumber = HttpUtility.UrlDecode(entity.VPISerialNumber);
					// NVARCHAR(50)
				entity.VPIMonitoringPointName = HttpUtility.UrlDecode(entity.VPIMonitoringPointName);
					// NVARCHAR(50)
				entity.VPIMonitoringPointNumber = HttpUtility.UrlDecode(entity.VPIMonitoringPointNumber);
					// NVARCHAR(50)
				entity.VPIAffiliatedOrganization = HttpUtility.UrlDecode(entity.VPIAffiliatedOrganization);
					// NVARCHAR(50)
				entity.VPIAreasToWhichTheyBelong = HttpUtility.UrlDecode(entity.VPIAreasToWhichTheyBelong);
					// NVARCHAR(50)
				entity.VPISubordinatePlatform = HttpUtility.UrlDecode(entity.VPISubordinatePlatform);
					// NVARCHAR(50)
				entity.VPILongitude = HttpUtility.UrlDecode(entity.VPILongitude);
					// NVARCHAR(50)
				entity.VPILatitude = HttpUtility.UrlDecode(entity.VPILatitude);
					// NVARCHAR(4000)
				entity.VPIAddress = HttpUtility.UrlDecode(entity.VPIAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.VideoPointInformation.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条VideoPointInformation记录";
    }
	
    /// <summary>
    /// 查询空的【视频点位信息】
    /// </summary>
    public partial class GetVideoPointInformationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new VideoPointInformation();
        }
        public override string Comments=> "获取空的视频点位信息记录";
    }
	
    /// <summary>
    /// 查询【视频点位信息】列表
    /// </summary>
    public partial class GetVideoPointInformationListEvaluator : Evaluator
    {
        public override string Comments=> "获取VideoPointInformation列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<VideoPointInformationSearchModel>() ?? new VideoPointInformationSearchModel();
                var query = ctx.VideoPointInformation.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// VPISerialNumber NVARCHAR(50) 序号 
                if(!string.IsNullOrEmpty(searchModel.VPISerialNumber)) query = query.Where(t=>t.VPISerialNumber.Contains(searchModel.VPISerialNumber));
                if(sort=="VPISerialNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VPISerialNumber):query.OrderByDescending(t=>t.VPISerialNumber);
                    isordered = true;
                }
				// VPIMonitoringPointName NVARCHAR(50) 监控点名称 
                if(!string.IsNullOrEmpty(searchModel.VPIMonitoringPointName)) query = query.Where(t=>t.VPIMonitoringPointName.Contains(searchModel.VPIMonitoringPointName));
                if(sort=="VPIMonitoringPointName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VPIMonitoringPointName):query.OrderByDescending(t=>t.VPIMonitoringPointName);
                    isordered = true;
                }
				// VPIMonitoringPointNumber NVARCHAR(50) 监控点编号 
                if(!string.IsNullOrEmpty(searchModel.VPIMonitoringPointNumber)) query = query.Where(t=>t.VPIMonitoringPointNumber.Contains(searchModel.VPIMonitoringPointNumber));
                if(sort=="VPIMonitoringPointNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VPIMonitoringPointNumber):query.OrderByDescending(t=>t.VPIMonitoringPointNumber);
                    isordered = true;
                }
				// VPIAffiliatedOrganization NVARCHAR(50) 所属组织 
                if(!string.IsNullOrEmpty(searchModel.VPIAffiliatedOrganization)) query = query.Where(t=>t.VPIAffiliatedOrganization.Contains(searchModel.VPIAffiliatedOrganization));
                if(sort=="VPIAffiliatedOrganization")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VPIAffiliatedOrganization):query.OrderByDescending(t=>t.VPIAffiliatedOrganization);
                    isordered = true;
                }
				// VPIAreasToWhichTheyBelong NVARCHAR(50) 所属区域 
                if(!string.IsNullOrEmpty(searchModel.VPIAreasToWhichTheyBelong)) query = query.Where(t=>t.VPIAreasToWhichTheyBelong.Contains(searchModel.VPIAreasToWhichTheyBelong));
                if(sort=="VPIAreasToWhichTheyBelong")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VPIAreasToWhichTheyBelong):query.OrderByDescending(t=>t.VPIAreasToWhichTheyBelong);
                    isordered = true;
                }
				// VPISubordinatePlatform NVARCHAR(50) 所属平台 
                if(!string.IsNullOrEmpty(searchModel.VPISubordinatePlatform)) query = query.Where(t=>t.VPISubordinatePlatform.Contains(searchModel.VPISubordinatePlatform));
                if(sort=="VPISubordinatePlatform")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VPISubordinatePlatform):query.OrderByDescending(t=>t.VPISubordinatePlatform);
                    isordered = true;
                }
				// VPILongitude NVARCHAR(50) 经度 
                if(!string.IsNullOrEmpty(searchModel.VPILongitude)) query = query.Where(t=>t.VPILongitude.Contains(searchModel.VPILongitude));
                if(sort=="VPILongitude")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VPILongitude):query.OrderByDescending(t=>t.VPILongitude);
                    isordered = true;
                }
				// VPILatitude NVARCHAR(50) 纬度 
                if(!string.IsNullOrEmpty(searchModel.VPILatitude)) query = query.Where(t=>t.VPILatitude.Contains(searchModel.VPILatitude));
                if(sort=="VPILatitude")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VPILatitude):query.OrderByDescending(t=>t.VPILatitude);
                    isordered = true;
                }
				// VPIAddress NVARCHAR(4000) 地址 
                if(!string.IsNullOrEmpty(searchModel.VPIAddress)) query = query.Where(t=>t.VPIAddress.Contains(searchModel.VPIAddress));
                if(sort=="VPIAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.VPIAddress):query.OrderByDescending(t=>t.VPIAddress);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.VPISerialNumber.Contains(search)||t.VPIMonitoringPointName.Contains(search)||t.VPIMonitoringPointNumber.Contains(search)||t.VPIAffiliatedOrganization.Contains(search)||t.VPIAreasToWhichTheyBelong.Contains(search)||t.VPISubordinatePlatform.Contains(search)||t.VPILongitude.Contains(search)||t.VPILatitude.Contains(search)||t.VPIAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<VideoPointInformation>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【就业援助】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class EmploymentAssistanceCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.EmploymentAssistance.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【就业援助】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【就业援助】
    /// </summary>
    public partial class DeleteEmploymentAssistanceEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<EmploymentAssistance>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.EmploymentAssistance.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.EmploymentAssistance.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条就业援助记录";
    }
	
    /// <summary>
    /// 保存【就业援助】
    /// </summary>
    public partial class SaveEmploymentAssistanceEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<EmploymentAssistance>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.EmploymentAssistance.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.EmploymentAssistance.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.EAPersonalNumber = HttpUtility.UrlDecode(entity.EAPersonalNumber);
					// NVARCHAR(50)
				entity.EAFullName = HttpUtility.UrlDecode(entity.EAFullName);
					// NVARCHAR(4000)
				entity.EAIdCardNo = HttpUtility.UrlDecode(entity.EAIdCardNo);
					// NVARCHAR(50)
				entity.EAGender = HttpUtility.UrlDecode(entity.EAGender);
					// NVARCHAR(50)
				entity.EANation = HttpUtility.UrlDecode(entity.EANation);
					// NVARCHAR(50)
				entity.EADegreeOfEducation = HttpUtility.UrlDecode(entity.EADegreeOfEducation);
					// NVARCHAR(50)
				entity.EAAccountCharacter = HttpUtility.UrlDecode(entity.EAAccountCharacter);
					// NVARCHAR(50)
				entity.EAIsItDisabled = HttpUtility.UrlDecode(entity.EAIsItDisabled);
					// NVARCHAR(50)
				entity.EATrainingIntention = HttpUtility.UrlDecode(entity.EATrainingIntention);
					// NVARCHAR(50)
				entity.EAContactInformation = HttpUtility.UrlDecode(entity.EAContactInformation);
					// NVARCHAR(50)
				entity.EAPersonnelType = HttpUtility.UrlDecode(entity.EAPersonnelType);
					// NVARCHAR(50)
				entity.EAFormOfEmployment = HttpUtility.UrlDecode(entity.EAFormOfEmployment);
					// NVARCHAR(4000)
				entity.EAContent1 = HttpUtility.UrlDecode(entity.EAContent1);
					// NVARCHAR(4000)
				entity.EAContent2 = HttpUtility.UrlDecode(entity.EAContent2);
					// NVARCHAR(4000)
				entity.EAContent3 = HttpUtility.UrlDecode(entity.EAContent3);
					// NVARCHAR(4000)
				entity.EAContent4 = HttpUtility.UrlDecode(entity.EAContent4);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.EmploymentAssistance.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条EmploymentAssistance记录";
    }
	
    /// <summary>
    /// 查询空的【就业援助】
    /// </summary>
    public partial class GetEmploymentAssistanceEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new EmploymentAssistance();
        }
        public override string Comments=> "获取空的就业援助记录";
    }
	
    /// <summary>
    /// 查询【就业援助】列表
    /// </summary>
    public partial class GetEmploymentAssistanceListEvaluator : Evaluator
    {
        public override string Comments=> "获取EmploymentAssistance列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<EmploymentAssistanceSearchModel>() ?? new EmploymentAssistanceSearchModel();
                var query = ctx.EmploymentAssistance.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// EAPersonalNumber NVARCHAR(50) 个人编号 
                if(!string.IsNullOrEmpty(searchModel.EAPersonalNumber)) query = query.Where(t=>t.EAPersonalNumber.Contains(searchModel.EAPersonalNumber));
                if(sort=="EAPersonalNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAPersonalNumber):query.OrderByDescending(t=>t.EAPersonalNumber);
                    isordered = true;
                }
				// EAFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.EAFullName)) query = query.Where(t=>t.EAFullName.Contains(searchModel.EAFullName));
                if(sort=="EAFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAFullName):query.OrderByDescending(t=>t.EAFullName);
                    isordered = true;
                }
				// EAIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.EAIdCardNo)) query = query.Where(t=>t.EAIdCardNo.Contains(searchModel.EAIdCardNo));
                if(sort=="EAIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAIdCardNo):query.OrderByDescending(t=>t.EAIdCardNo);
                    isordered = true;
                }
				// EAGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.EAGender)) query = query.Where(t=>t.EAGender.Contains(searchModel.EAGender));
                if(sort=="EAGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAGender):query.OrderByDescending(t=>t.EAGender);
                    isordered = true;
                }
				// EANation NVARCHAR(50) 民族 
                if(!string.IsNullOrEmpty(searchModel.EANation)) query = query.Where(t=>t.EANation.Contains(searchModel.EANation));
                if(sort=="EANation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EANation):query.OrderByDescending(t=>t.EANation);
                    isordered = true;
                }
				// EAAge INT 年龄 
                if(searchModel.MinEAAge!=null) query = query.Where(t=>t.EAAge>=searchModel.MinEAAge);
                if(searchModel.MaxEAAge!=null) query = query.Where(t=>t.EAAge<=searchModel.MaxEAAge);
                if(sort=="EAAge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAAge):query.OrderByDescending(t=>t.EAAge);
                    isordered = true;
                }
				// EADegreeOfEducation NVARCHAR(50) 文化程度 
                if(!string.IsNullOrEmpty(searchModel.EADegreeOfEducation)) query = query.Where(t=>t.EADegreeOfEducation.Contains(searchModel.EADegreeOfEducation));
                if(sort=="EADegreeOfEducation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EADegreeOfEducation):query.OrderByDescending(t=>t.EADegreeOfEducation);
                    isordered = true;
                }
				// EAAccountCharacter NVARCHAR(50) 户口性质 
                if(!string.IsNullOrEmpty(searchModel.EAAccountCharacter)) query = query.Where(t=>t.EAAccountCharacter.Contains(searchModel.EAAccountCharacter));
                if(sort=="EAAccountCharacter")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAAccountCharacter):query.OrderByDescending(t=>t.EAAccountCharacter);
                    isordered = true;
                }
				// EAIsItDisabled NVARCHAR(50) 是否残疾 
                if(!string.IsNullOrEmpty(searchModel.EAIsItDisabled)) query = query.Where(t=>t.EAIsItDisabled.Contains(searchModel.EAIsItDisabled));
                if(sort=="EAIsItDisabled")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAIsItDisabled):query.OrderByDescending(t=>t.EAIsItDisabled);
                    isordered = true;
                }
				// EATrainingIntention NVARCHAR(50) 培训意愿 
                if(!string.IsNullOrEmpty(searchModel.EATrainingIntention)) query = query.Where(t=>t.EATrainingIntention.Contains(searchModel.EATrainingIntention));
                if(sort=="EATrainingIntention")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EATrainingIntention):query.OrderByDescending(t=>t.EATrainingIntention);
                    isordered = true;
                }
				// EAContactInformation NVARCHAR(50) 联系方式 
                if(!string.IsNullOrEmpty(searchModel.EAContactInformation)) query = query.Where(t=>t.EAContactInformation.Contains(searchModel.EAContactInformation));
                if(sort=="EAContactInformation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAContactInformation):query.OrderByDescending(t=>t.EAContactInformation);
                    isordered = true;
                }
				// EAPersonnelType NVARCHAR(50) 人员类型 
                if(!string.IsNullOrEmpty(searchModel.EAPersonnelType)) query = query.Where(t=>t.EAPersonnelType.Contains(searchModel.EAPersonnelType));
                if(sort=="EAPersonnelType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAPersonnelType):query.OrderByDescending(t=>t.EAPersonnelType);
                    isordered = true;
                }
				// EAFormOfEmployment NVARCHAR(50) 就业形式 
                if(!string.IsNullOrEmpty(searchModel.EAFormOfEmployment)) query = query.Where(t=>t.EAFormOfEmployment.Contains(searchModel.EAFormOfEmployment));
                if(sort=="EAFormOfEmployment")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAFormOfEmployment):query.OrderByDescending(t=>t.EAFormOfEmployment);
                    isordered = true;
                }
				// EAContent1 NVARCHAR(4000) 内容1 
                if(!string.IsNullOrEmpty(searchModel.EAContent1)) query = query.Where(t=>t.EAContent1.Contains(searchModel.EAContent1));
                if(sort=="EAContent1")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAContent1):query.OrderByDescending(t=>t.EAContent1);
                    isordered = true;
                }
				// EAContent2 NVARCHAR(4000) 内容2 
                if(!string.IsNullOrEmpty(searchModel.EAContent2)) query = query.Where(t=>t.EAContent2.Contains(searchModel.EAContent2));
                if(sort=="EAContent2")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAContent2):query.OrderByDescending(t=>t.EAContent2);
                    isordered = true;
                }
				// EAContent3 NVARCHAR(4000) 内容3 
                if(!string.IsNullOrEmpty(searchModel.EAContent3)) query = query.Where(t=>t.EAContent3.Contains(searchModel.EAContent3));
                if(sort=="EAContent3")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAContent3):query.OrderByDescending(t=>t.EAContent3);
                    isordered = true;
                }
				// EAContent4 NVARCHAR(4000) 内容4 
                if(!string.IsNullOrEmpty(searchModel.EAContent4)) query = query.Where(t=>t.EAContent4.Contains(searchModel.EAContent4));
                if(sort=="EAContent4")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.EAContent4):query.OrderByDescending(t=>t.EAContent4);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.EAPersonalNumber.Contains(search)||t.EAFullName.Contains(search)||t.EAIdCardNo.Contains(search)||t.EAGender.Contains(search)||t.EANation.Contains(search)||t.EADegreeOfEducation.Contains(search)||t.EAAccountCharacter.Contains(search)||t.EAIsItDisabled.Contains(search)||t.EATrainingIntention.Contains(search)||t.EAContactInformation.Contains(search)||t.EAPersonnelType.Contains(search)||t.EAFormOfEmployment.Contains(search)||t.EAContent1.Contains(search)||t.EAContent2.Contains(search)||t.EAContent3.Contains(search)||t.EAContent4.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<EmploymentAssistance>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【危房解危】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class DangerousHousingCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.DangerousHousing.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【危房解危】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【危房解危】
    /// </summary>
    public partial class DeleteDangerousHousingEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<DangerousHousing>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.DangerousHousing.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.DangerousHousing.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条危房解危记录";
    }
	
    /// <summary>
    /// 保存【危房解危】
    /// </summary>
    public partial class SaveDangerousHousingEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<DangerousHousing>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.DangerousHousing.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.DangerousHousing.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.DHOwner = HttpUtility.UrlDecode(entity.DHOwner);
					// NVARCHAR(50)
				entity.DHHousingLocation = HttpUtility.UrlDecode(entity.DHHousingLocation);
					// NVARCHAR(50)
				entity.DHContactNumber = HttpUtility.UrlDecode(entity.DHContactNumber);
					// NVARCHAR(4000)
				entity.DHCurrentResidentialAddress = HttpUtility.UrlDecode(entity.DHCurrentResidentialAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.DangerousHousing.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条DangerousHousing记录";
    }
	
    /// <summary>
    /// 查询空的【危房解危】
    /// </summary>
    public partial class GetDangerousHousingEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new DangerousHousing();
        }
        public override string Comments=> "获取空的危房解危记录";
    }
	
    /// <summary>
    /// 查询【危房解危】列表
    /// </summary>
    public partial class GetDangerousHousingListEvaluator : Evaluator
    {
        public override string Comments=> "获取DangerousHousing列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<DangerousHousingSearchModel>() ?? new DangerousHousingSearchModel();
                var query = ctx.DangerousHousing.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// DHOwner NVARCHAR(50) 所有权人 
                if(!string.IsNullOrEmpty(searchModel.DHOwner)) query = query.Where(t=>t.DHOwner.Contains(searchModel.DHOwner));
                if(sort=="DHOwner")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHOwner):query.OrderByDescending(t=>t.DHOwner);
                    isordered = true;
                }
				// DHHousingLocation NVARCHAR(50) 房屋座落 
                if(!string.IsNullOrEmpty(searchModel.DHHousingLocation)) query = query.Where(t=>t.DHHousingLocation.Contains(searchModel.DHHousingLocation));
                if(sort=="DHHousingLocation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHHousingLocation):query.OrderByDescending(t=>t.DHHousingLocation);
                    isordered = true;
                }
				// DHRealEstateCertificateArea REAL 房产证面积 
                if(searchModel.MinDHRealEstateCertificateArea!=null) query = query.Where(t=>t.DHRealEstateCertificateArea>=searchModel.MinDHRealEstateCertificateArea);
                if(searchModel.MaxDHRealEstateCertificateArea!=null) query = query.Where(t=>t.DHRealEstateCertificateArea<=searchModel.MaxDHRealEstateCertificateArea);
                if(sort=="DHRealEstateCertificateArea")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHRealEstateCertificateArea):query.OrderByDescending(t=>t.DHRealEstateCertificateArea);
                    isordered = true;
                }
				// DHLandCertificateArea REAL 土地证面积 
                if(searchModel.MinDHLandCertificateArea!=null) query = query.Where(t=>t.DHLandCertificateArea>=searchModel.MinDHLandCertificateArea);
                if(searchModel.MaxDHLandCertificateArea!=null) query = query.Where(t=>t.DHLandCertificateArea<=searchModel.MaxDHLandCertificateArea);
                if(sort=="DHLandCertificateArea")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHLandCertificateArea):query.OrderByDescending(t=>t.DHLandCertificateArea);
                    isordered = true;
                }
				// DHMappingArea REAL 测绘面积 
                if(searchModel.MinDHMappingArea!=null) query = query.Where(t=>t.DHMappingArea>=searchModel.MinDHMappingArea);
                if(searchModel.MaxDHMappingArea!=null) query = query.Where(t=>t.DHMappingArea<=searchModel.MaxDHMappingArea);
                if(sort=="DHMappingArea")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHMappingArea):query.OrderByDescending(t=>t.DHMappingArea);
                    isordered = true;
                }
				// DHSupplementaryAreaOfSurveyingAndMapping REAL 测绘增补面积 
                if(searchModel.MinDHSupplementaryAreaOfSurveyingAndMapping!=null) query = query.Where(t=>t.DHSupplementaryAreaOfSurveyingAndMapping>=searchModel.MinDHSupplementaryAreaOfSurveyingAndMapping);
                if(searchModel.MaxDHSupplementaryAreaOfSurveyingAndMapping!=null) query = query.Where(t=>t.DHSupplementaryAreaOfSurveyingAndMapping<=searchModel.MaxDHSupplementaryAreaOfSurveyingAndMapping);
                if(sort=="DHSupplementaryAreaOfSurveyingAndMapping")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHSupplementaryAreaOfSurveyingAndMapping):query.OrderByDescending(t=>t.DHSupplementaryAreaOfSurveyingAndMapping);
                    isordered = true;
                }
				// DHResettlementArea REAL 安置面积 
                if(searchModel.MinDHResettlementArea!=null) query = query.Where(t=>t.DHResettlementArea>=searchModel.MinDHResettlementArea);
                if(searchModel.MaxDHResettlementArea!=null) query = query.Where(t=>t.DHResettlementArea<=searchModel.MaxDHResettlementArea);
                if(sort=="DHResettlementArea")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHResettlementArea):query.OrderByDescending(t=>t.DHResettlementArea);
                    isordered = true;
                }
				// DHSignatureTime DATETIME 签字时间 
                if(searchModel.FromDHSignatureTime!=null) query = query.Where(t=>t.DHSignatureTime>=searchModel.FromDHSignatureTime);
                if(searchModel.ToDHSignatureTime!=null) query = query.Where(t=>t.DHSignatureTime<=searchModel.ToDHSignatureTime);
                if(sort=="DHSignatureTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHSignatureTime):query.OrderByDescending(t=>t.DHSignatureTime);
                    isordered = true;
                }
				// DHTimeOfDelivery DATETIME 交房时间 
                if(searchModel.FromDHTimeOfDelivery!=null) query = query.Where(t=>t.DHTimeOfDelivery>=searchModel.FromDHTimeOfDelivery);
                if(searchModel.ToDHTimeOfDelivery!=null) query = query.Where(t=>t.DHTimeOfDelivery<=searchModel.ToDHTimeOfDelivery);
                if(sort=="DHTimeOfDelivery")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHTimeOfDelivery):query.OrderByDescending(t=>t.DHTimeOfDelivery);
                    isordered = true;
                }
				// DHCompensationAmount MONEY 补偿金额 
                if(searchModel.MinDHCompensationAmount!=null) query = query.Where(t=>t.DHCompensationAmount>=searchModel.MinDHCompensationAmount);
                if(searchModel.MaxDHCompensationAmount!=null) query = query.Where(t=>t.DHCompensationAmount<=searchModel.MaxDHCompensationAmount);
                if(sort=="DHCompensationAmount")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHCompensationAmount):query.OrderByDescending(t=>t.DHCompensationAmount);
                    isordered = true;
                }
				// DHContactNumber NVARCHAR(50) 联系电话 
                if(!string.IsNullOrEmpty(searchModel.DHContactNumber)) query = query.Where(t=>t.DHContactNumber.Contains(searchModel.DHContactNumber));
                if(sort=="DHContactNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHContactNumber):query.OrderByDescending(t=>t.DHContactNumber);
                    isordered = true;
                }
				// DHCurrentResidentialAddress NVARCHAR(4000) 现居住地址 
                if(!string.IsNullOrEmpty(searchModel.DHCurrentResidentialAddress)) query = query.Where(t=>t.DHCurrentResidentialAddress.Contains(searchModel.DHCurrentResidentialAddress));
                if(sort=="DHCurrentResidentialAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DHCurrentResidentialAddress):query.OrderByDescending(t=>t.DHCurrentResidentialAddress);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.DHOwner.Contains(search)||t.DHHousingLocation.Contains(search)||t.DHContactNumber.Contains(search)||t.DHCurrentResidentialAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<DangerousHousing>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【工业园房屋收款】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class IndustrialParkHousingReceiptCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.IndustrialParkHousingReceipt.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【工业园房屋收款】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【工业园房屋收款】
    /// </summary>
    public partial class DeleteIndustrialParkHousingReceiptEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<IndustrialParkHousingReceipt>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.IndustrialParkHousingReceipt.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.IndustrialParkHousingReceipt.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条工业园房屋收款记录";
    }
	
    /// <summary>
    /// 保存【工业园房屋收款】
    /// </summary>
    public partial class SaveIndustrialParkHousingReceiptEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<IndustrialParkHousingReceipt>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.IndustrialParkHousingReceipt.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.IndustrialParkHousingReceipt.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.IPHRFactoryBuilding = HttpUtility.UrlDecode(entity.IPHRFactoryBuilding);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.IndustrialParkHousingReceipt.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条IndustrialParkHousingReceipt记录";
    }
	
    /// <summary>
    /// 查询空的【工业园房屋收款】
    /// </summary>
    public partial class GetIndustrialParkHousingReceiptEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new IndustrialParkHousingReceipt();
        }
        public override string Comments=> "获取空的工业园房屋收款记录";
    }
	
    /// <summary>
    /// 查询【工业园房屋收款】列表
    /// </summary>
    public partial class GetIndustrialParkHousingReceiptListEvaluator : Evaluator
    {
        public override string Comments=> "获取IndustrialParkHousingReceipt列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<IndustrialParkHousingReceiptSearchModel>() ?? new IndustrialParkHousingReceiptSearchModel();
                var query = ctx.IndustrialParkHousingReceipt.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// IPHRFactoryBuilding NVARCHAR(50) @厂房楼栋 
                if(!string.IsNullOrEmpty(searchModel.IPHRFactoryBuilding)) query = query.Where(t=>t.IPHRFactoryBuilding.Contains(searchModel.IPHRFactoryBuilding));
                if(sort=="IPHRFactoryBuilding")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IPHRFactoryBuilding):query.OrderByDescending(t=>t.IPHRFactoryBuilding);
                    isordered = true;
                }
				// IPHRStartTime DATETIME 开始时间 
                if(searchModel.FromIPHRStartTime!=null) query = query.Where(t=>t.IPHRStartTime>=searchModel.FromIPHRStartTime);
                if(searchModel.ToIPHRStartTime!=null) query = query.Where(t=>t.IPHRStartTime<=searchModel.ToIPHRStartTime);
                if(sort=="IPHRStartTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IPHRStartTime):query.OrderByDescending(t=>t.IPHRStartTime);
                    isordered = true;
                }
				// IPHREndingTime DATETIME 结束时间 
                if(searchModel.FromIPHREndingTime!=null) query = query.Where(t=>t.IPHREndingTime>=searchModel.FromIPHREndingTime);
                if(searchModel.ToIPHREndingTime!=null) query = query.Where(t=>t.IPHREndingTime<=searchModel.ToIPHREndingTime);
                if(sort=="IPHREndingTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IPHREndingTime):query.OrderByDescending(t=>t.IPHREndingTime);
                    isordered = true;
                }
				// IPHRPaymentAmount MONEY 付款金额 
                if(searchModel.MinIPHRPaymentAmount!=null) query = query.Where(t=>t.IPHRPaymentAmount>=searchModel.MinIPHRPaymentAmount);
                if(searchModel.MaxIPHRPaymentAmount!=null) query = query.Where(t=>t.IPHRPaymentAmount<=searchModel.MaxIPHRPaymentAmount);
                if(sort=="IPHRPaymentAmount")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IPHRPaymentAmount):query.OrderByDescending(t=>t.IPHRPaymentAmount);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.IPHRFactoryBuilding.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<IndustrialParkHousingReceipt>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【需求收集】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class DemandCollectionCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.DemandCollection.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【需求收集】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【需求收集】
    /// </summary>
    public partial class DeleteDemandCollectionEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<DemandCollection>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.DemandCollection.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.DemandCollection.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条需求收集记录";
    }
	
    /// <summary>
    /// 保存【需求收集】
    /// </summary>
    public partial class SaveDemandCollectionEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<DemandCollection>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.DemandCollection.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.DemandCollection.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.DCWhatDoYouNeed = HttpUtility.UrlDecode(entity.DCWhatDoYouNeed);
					// NVARCHAR(50)
				entity.DCYourName = HttpUtility.UrlDecode(entity.DCYourName);
					// NVARCHAR(50)
				entity.DCYourContactInformation = HttpUtility.UrlDecode(entity.DCYourContactInformation);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.DemandCollection.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条DemandCollection记录";
    }
	
    /// <summary>
    /// 查询空的【需求收集】
    /// </summary>
    public partial class GetDemandCollectionEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new DemandCollection();
        }
        public override string Comments=> "获取空的需求收集记录";
    }
	
    /// <summary>
    /// 查询【需求收集】列表
    /// </summary>
    public partial class GetDemandCollectionListEvaluator : Evaluator
    {
        public override string Comments=> "获取DemandCollection列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<DemandCollectionSearchModel>() ?? new DemandCollectionSearchModel();
                var query = ctx.DemandCollection.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// DCWhatDoYouNeed NVARCHAR(4000) 您需要什么内容 
                if(!string.IsNullOrEmpty(searchModel.DCWhatDoYouNeed)) query = query.Where(t=>t.DCWhatDoYouNeed.Contains(searchModel.DCWhatDoYouNeed));
                if(sort=="DCWhatDoYouNeed")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DCWhatDoYouNeed):query.OrderByDescending(t=>t.DCWhatDoYouNeed);
                    isordered = true;
                }
				// DCExpectedDeliveryTime DATETIME 期望交付时间 
                if(searchModel.FromDCExpectedDeliveryTime!=null) query = query.Where(t=>t.DCExpectedDeliveryTime>=searchModel.FromDCExpectedDeliveryTime);
                if(searchModel.ToDCExpectedDeliveryTime!=null) query = query.Where(t=>t.DCExpectedDeliveryTime<=searchModel.ToDCExpectedDeliveryTime);
                if(sort=="DCExpectedDeliveryTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DCExpectedDeliveryTime):query.OrderByDescending(t=>t.DCExpectedDeliveryTime);
                    isordered = true;
                }
				// DCYourName NVARCHAR(50) 您的姓名 
                if(!string.IsNullOrEmpty(searchModel.DCYourName)) query = query.Where(t=>t.DCYourName.Contains(searchModel.DCYourName));
                if(sort=="DCYourName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DCYourName):query.OrderByDescending(t=>t.DCYourName);
                    isordered = true;
                }
				// DCYourContactInformation NVARCHAR(50) 您的联系方式 
                if(!string.IsNullOrEmpty(searchModel.DCYourContactInformation)) query = query.Where(t=>t.DCYourContactInformation.Contains(searchModel.DCYourContactInformation));
                if(sort=="DCYourContactInformation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DCYourContactInformation):query.OrderByDescending(t=>t.DCYourContactInformation);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.DCWhatDoYouNeed.Contains(search)||t.DCYourName.Contains(search)||t.DCYourContactInformation.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<DemandCollection>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党组织信息管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class InformationManagementOfPartyOrganizationsCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.InformationManagementOfPartyOrganizations.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党组织信息管理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党组织信息管理】
    /// </summary>
    public partial class DeleteInformationManagementOfPartyOrganizationsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<InformationManagementOfPartyOrganizations>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.InformationManagementOfPartyOrganizations.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.InformationManagementOfPartyOrganizations.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党组织信息管理记录";
    }
	
    /// <summary>
    /// 保存【党组织信息管理】
    /// </summary>
    public partial class SaveInformationManagementOfPartyOrganizationsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<InformationManagementOfPartyOrganizations>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.InformationManagementOfPartyOrganizations.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.InformationManagementOfPartyOrganizations.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.IMOPONameOfPartyOrganization = HttpUtility.UrlDecode(entity.IMOPONameOfPartyOrganization);
					// NVARCHAR(50)
				entity.IMOPOSecretaryOfPartyOrganization = HttpUtility.UrlDecode(entity.IMOPOSecretaryOfPartyOrganization);
					// NVARCHAR(50)
				entity.IMOPOPartyOrganizationContacts = HttpUtility.UrlDecode(entity.IMOPOPartyOrganizationContacts);
					// NVARCHAR(50)
				entity.IMOPOPartyOrganizationContactTelephone = HttpUtility.UrlDecode(entity.IMOPOPartyOrganizationContactTelephone);
					// NVARCHAR(50)
				entity.IMOPOOrganizationCategory = HttpUtility.UrlDecode(entity.IMOPOOrganizationCategory);
					// NVARCHAR(50)
				entity.IMOPONameOfPartyOrganizationAtHigherLevel = HttpUtility.UrlDecode(entity.IMOPONameOfPartyOrganizationAtHigherLevel);
					// NVARCHAR(50)
				entity.IMOPOCitizenshipNumberOfPartyOrganizationSecretary = HttpUtility.UrlDecode(entity.IMOPOCitizenshipNumberOfPartyOrganizationSecretary);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.InformationManagementOfPartyOrganizations.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条InformationManagementOfPartyOrganizations记录";
    }
	
    /// <summary>
    /// 查询空的【党组织信息管理】
    /// </summary>
    public partial class GetInformationManagementOfPartyOrganizationsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new InformationManagementOfPartyOrganizations();
        }
        public override string Comments=> "获取空的党组织信息管理记录";
    }
	
    /// <summary>
    /// 查询【党组织信息管理】列表
    /// </summary>
    public partial class GetInformationManagementOfPartyOrganizationsListEvaluator : Evaluator
    {
        public override string Comments=> "获取InformationManagementOfPartyOrganizations列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<InformationManagementOfPartyOrganizationsSearchModel>() ?? new InformationManagementOfPartyOrganizationsSearchModel();
                var query = ctx.InformationManagementOfPartyOrganizations.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// IMOPONameOfPartyOrganization NVARCHAR(50) 党组织名称 
                if(!string.IsNullOrEmpty(searchModel.IMOPONameOfPartyOrganization)) query = query.Where(t=>t.IMOPONameOfPartyOrganization.Contains(searchModel.IMOPONameOfPartyOrganization));
                if(sort=="IMOPONameOfPartyOrganization")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPONameOfPartyOrganization):query.OrderByDescending(t=>t.IMOPONameOfPartyOrganization);
                    isordered = true;
                }
				// IMOPOSecretaryOfPartyOrganization NVARCHAR(50) 党组织书记 
                if(!string.IsNullOrEmpty(searchModel.IMOPOSecretaryOfPartyOrganization)) query = query.Where(t=>t.IMOPOSecretaryOfPartyOrganization.Contains(searchModel.IMOPOSecretaryOfPartyOrganization));
                if(sort=="IMOPOSecretaryOfPartyOrganization")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPOSecretaryOfPartyOrganization):query.OrderByDescending(t=>t.IMOPOSecretaryOfPartyOrganization);
                    isordered = true;
                }
				// IMOPOPartyOrganizationContacts NVARCHAR(50) 党组织联系人 
                if(!string.IsNullOrEmpty(searchModel.IMOPOPartyOrganizationContacts)) query = query.Where(t=>t.IMOPOPartyOrganizationContacts.Contains(searchModel.IMOPOPartyOrganizationContacts));
                if(sort=="IMOPOPartyOrganizationContacts")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPOPartyOrganizationContacts):query.OrderByDescending(t=>t.IMOPOPartyOrganizationContacts);
                    isordered = true;
                }
				// IMOPOPartyOrganizationContactTelephone NVARCHAR(50) 党组织联系电话 
                if(!string.IsNullOrEmpty(searchModel.IMOPOPartyOrganizationContactTelephone)) query = query.Where(t=>t.IMOPOPartyOrganizationContactTelephone.Contains(searchModel.IMOPOPartyOrganizationContactTelephone));
                if(sort=="IMOPOPartyOrganizationContactTelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPOPartyOrganizationContactTelephone):query.OrderByDescending(t=>t.IMOPOPartyOrganizationContactTelephone);
                    isordered = true;
                }
				// IMOPOOrganizationCategory NVARCHAR(50) 组织类别 
                if(!string.IsNullOrEmpty(searchModel.IMOPOOrganizationCategory)) query = query.Where(t=>t.IMOPOOrganizationCategory.Contains(searchModel.IMOPOOrganizationCategory));
                if(sort=="IMOPOOrganizationCategory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPOOrganizationCategory):query.OrderByDescending(t=>t.IMOPOOrganizationCategory);
                    isordered = true;
                }
				// IMOPONameOfPartyOrganizationAtHigherLevel NVARCHAR(50) 上级党组织名称 
                if(!string.IsNullOrEmpty(searchModel.IMOPONameOfPartyOrganizationAtHigherLevel)) query = query.Where(t=>t.IMOPONameOfPartyOrganizationAtHigherLevel.Contains(searchModel.IMOPONameOfPartyOrganizationAtHigherLevel));
                if(sort=="IMOPONameOfPartyOrganizationAtHigherLevel")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPONameOfPartyOrganizationAtHigherLevel):query.OrderByDescending(t=>t.IMOPONameOfPartyOrganizationAtHigherLevel);
                    isordered = true;
                }
				// IMOPOCitizenshipNumberOfPartyOrganizationSecretary NVARCHAR(50) 党组织书记公民身份号码 
                if(!string.IsNullOrEmpty(searchModel.IMOPOCitizenshipNumberOfPartyOrganizationSecretary)) query = query.Where(t=>t.IMOPOCitizenshipNumberOfPartyOrganizationSecretary.Contains(searchModel.IMOPOCitizenshipNumberOfPartyOrganizationSecretary));
                if(sort=="IMOPOCitizenshipNumberOfPartyOrganizationSecretary")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.IMOPOCitizenshipNumberOfPartyOrganizationSecretary):query.OrderByDescending(t=>t.IMOPOCitizenshipNumberOfPartyOrganizationSecretary);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.IMOPONameOfPartyOrganization.Contains(search)||t.IMOPOSecretaryOfPartyOrganization.Contains(search)||t.IMOPOPartyOrganizationContacts.Contains(search)||t.IMOPOPartyOrganizationContactTelephone.Contains(search)||t.IMOPOOrganizationCategory.Contains(search)||t.IMOPONameOfPartyOrganizationAtHigherLevel.Contains(search)||t.IMOPOCitizenshipNumberOfPartyOrganizationSecretary.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<InformationManagementOfPartyOrganizations>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【关爱对象】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class CareForTheObjectCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.CareForTheObject.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【关爱对象】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【关爱对象】
    /// </summary>
    public partial class DeleteCareForTheObjectEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<CareForTheObject>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.CareForTheObject.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.CareForTheObject.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条关爱对象记录";
    }
	
    /// <summary>
    /// 保存【关爱对象】
    /// </summary>
    public partial class SaveCareForTheObjectEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<CareForTheObject>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.CareForTheObject.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.CareForTheObject.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.CFTOFullName = HttpUtility.UrlDecode(entity.CFTOFullName);
					// NVARCHAR(50)
				entity.CFTOGender = HttpUtility.UrlDecode(entity.CFTOGender);
					// NVARCHAR(50)
				entity.CFTOType = HttpUtility.UrlDecode(entity.CFTOType);
					// NVARCHAR(4000)
				entity.CFTOId = HttpUtility.UrlDecode(entity.CFTOId);
					// NVARCHAR(50)
				entity.CFTORegisteredResidence = HttpUtility.UrlDecode(entity.CFTORegisteredResidence);
					// NVARCHAR(50)
				entity.CFTOPermanentResidence = HttpUtility.UrlDecode(entity.CFTOPermanentResidence);
					// NVARCHAR(50)
				entity.CFTOBuildingNumber = HttpUtility.UrlDecode(entity.CFTOBuildingNumber);
					// NVARCHAR(50)
				entity.CFTOUnitNumber = HttpUtility.UrlDecode(entity.CFTOUnitNumber);
					// NVARCHAR(50)
				entity.CFTOHouseNumber = HttpUtility.UrlDecode(entity.CFTOHouseNumber);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.CareForTheObject.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条CareForTheObject记录";
    }
	
    /// <summary>
    /// 查询空的【关爱对象】
    /// </summary>
    public partial class GetCareForTheObjectEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new CareForTheObject();
        }
        public override string Comments=> "获取空的关爱对象记录";
    }
	
    /// <summary>
    /// 查询【关爱对象】列表
    /// </summary>
    public partial class GetCareForTheObjectListEvaluator : Evaluator
    {
        public override string Comments=> "获取CareForTheObject列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<CareForTheObjectSearchModel>() ?? new CareForTheObjectSearchModel();
                var query = ctx.CareForTheObject.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// CFTOFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.CFTOFullName)) query = query.Where(t=>t.CFTOFullName.Contains(searchModel.CFTOFullName));
                if(sort=="CFTOFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFTOFullName):query.OrderByDescending(t=>t.CFTOFullName);
                    isordered = true;
                }
				// CFTOGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.CFTOGender)) query = query.Where(t=>t.CFTOGender.Contains(searchModel.CFTOGender));
                if(sort=="CFTOGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFTOGender):query.OrderByDescending(t=>t.CFTOGender);
                    isordered = true;
                }
				// CFTOType NVARCHAR(50) 类型 
                if(!string.IsNullOrEmpty(searchModel.CFTOType)) query = query.Where(t=>t.CFTOType.Contains(searchModel.CFTOType));
                if(sort=="CFTOType")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFTOType):query.OrderByDescending(t=>t.CFTOType);
                    isordered = true;
                }
				// CFTOId NVARCHAR(4000) 身份证 
                if(!string.IsNullOrEmpty(searchModel.CFTOId)) query = query.Where(t=>t.CFTOId.Contains(searchModel.CFTOId));
                if(sort=="CFTOId")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFTOId):query.OrderByDescending(t=>t.CFTOId);
                    isordered = true;
                }
				// CFTORegisteredResidence NVARCHAR(50) 户口所在地 
                if(!string.IsNullOrEmpty(searchModel.CFTORegisteredResidence)) query = query.Where(t=>t.CFTORegisteredResidence.Contains(searchModel.CFTORegisteredResidence));
                if(sort=="CFTORegisteredResidence")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFTORegisteredResidence):query.OrderByDescending(t=>t.CFTORegisteredResidence);
                    isordered = true;
                }
				// CFTOPermanentResidence NVARCHAR(50) 常住地 
                if(!string.IsNullOrEmpty(searchModel.CFTOPermanentResidence)) query = query.Where(t=>t.CFTOPermanentResidence.Contains(searchModel.CFTOPermanentResidence));
                if(sort=="CFTOPermanentResidence")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFTOPermanentResidence):query.OrderByDescending(t=>t.CFTOPermanentResidence);
                    isordered = true;
                }
				// CFTOBuildingNumber NVARCHAR(50) 楼栋号 
                if(!string.IsNullOrEmpty(searchModel.CFTOBuildingNumber)) query = query.Where(t=>t.CFTOBuildingNumber.Contains(searchModel.CFTOBuildingNumber));
                if(sort=="CFTOBuildingNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFTOBuildingNumber):query.OrderByDescending(t=>t.CFTOBuildingNumber);
                    isordered = true;
                }
				// CFTOUnitNumber NVARCHAR(50) 单元号 
                if(!string.IsNullOrEmpty(searchModel.CFTOUnitNumber)) query = query.Where(t=>t.CFTOUnitNumber.Contains(searchModel.CFTOUnitNumber));
                if(sort=="CFTOUnitNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFTOUnitNumber):query.OrderByDescending(t=>t.CFTOUnitNumber);
                    isordered = true;
                }
				// CFTOHouseNumber NVARCHAR(50) 门牌号 
                if(!string.IsNullOrEmpty(searchModel.CFTOHouseNumber)) query = query.Where(t=>t.CFTOHouseNumber.Contains(searchModel.CFTOHouseNumber));
                if(sort=="CFTOHouseNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.CFTOHouseNumber):query.OrderByDescending(t=>t.CFTOHouseNumber);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.CFTOFullName.Contains(search)||t.CFTOGender.Contains(search)||t.CFTOType.Contains(search)||t.CFTOId.Contains(search)||t.CFTORegisteredResidence.Contains(search)||t.CFTOPermanentResidence.Contains(search)||t.CFTOBuildingNumber.Contains(search)||t.CFTOUnitNumber.Contains(search)||t.CFTOHouseNumber.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<CareForTheObject>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【招聘就业模块】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class RecruitmentAndEmploymentModuleCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.RecruitmentAndEmploymentModule.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【招聘就业模块】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【招聘就业模块】
    /// </summary>
    public partial class DeleteRecruitmentAndEmploymentModuleEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<RecruitmentAndEmploymentModule>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.RecruitmentAndEmploymentModule.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.RecruitmentAndEmploymentModule.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条招聘就业模块记录";
    }
	
    /// <summary>
    /// 保存【招聘就业模块】
    /// </summary>
    public partial class SaveRecruitmentAndEmploymentModuleEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<RecruitmentAndEmploymentModule>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.RecruitmentAndEmploymentModule.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.RecruitmentAndEmploymentModule.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.RAEMEmployingUnit = HttpUtility.UrlDecode(entity.RAEMEmployingUnit);
					// NVARCHAR(50)
				entity.RAEMPosition = HttpUtility.UrlDecode(entity.RAEMPosition);
					// NVARCHAR(50)
				entity.RAEMPublisher = HttpUtility.UrlDecode(entity.RAEMPublisher);
					// NVARCHAR(50)
				entity.RAEMJobDescription = HttpUtility.UrlDecode(entity.RAEMJobDescription);
					// NVARCHAR(4000)
				entity.RAEMJobResponsibilities = HttpUtility.UrlDecode(entity.RAEMJobResponsibilities);
					// NVARCHAR(4000)
				entity.RAEMContentsOfJobRequirements = HttpUtility.UrlDecode(entity.RAEMContentsOfJobRequirements);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.RecruitmentAndEmploymentModule.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条RecruitmentAndEmploymentModule记录";
    }
	
    /// <summary>
    /// 查询空的【招聘就业模块】
    /// </summary>
    public partial class GetRecruitmentAndEmploymentModuleEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new RecruitmentAndEmploymentModule();
        }
        public override string Comments=> "获取空的招聘就业模块记录";
    }
	
    /// <summary>
    /// 查询【招聘就业模块】列表
    /// </summary>
    public partial class GetRecruitmentAndEmploymentModuleListEvaluator : Evaluator
    {
        public override string Comments=> "获取RecruitmentAndEmploymentModule列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<RecruitmentAndEmploymentModuleSearchModel>() ?? new RecruitmentAndEmploymentModuleSearchModel();
                var query = ctx.RecruitmentAndEmploymentModule.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// RAEMEmployingUnit NVARCHAR(50) 用人单位 
                if(!string.IsNullOrEmpty(searchModel.RAEMEmployingUnit)) query = query.Where(t=>t.RAEMEmployingUnit.Contains(searchModel.RAEMEmployingUnit));
                if(sort=="RAEMEmployingUnit")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RAEMEmployingUnit):query.OrderByDescending(t=>t.RAEMEmployingUnit);
                    isordered = true;
                }
				// RAEMPosition NVARCHAR(50) 职位 
                if(!string.IsNullOrEmpty(searchModel.RAEMPosition)) query = query.Where(t=>t.RAEMPosition.Contains(searchModel.RAEMPosition));
                if(sort=="RAEMPosition")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RAEMPosition):query.OrderByDescending(t=>t.RAEMPosition);
                    isordered = true;
                }
				// RAEMPublisher NVARCHAR(50) 发布人 
                if(!string.IsNullOrEmpty(searchModel.RAEMPublisher)) query = query.Where(t=>t.RAEMPublisher.Contains(searchModel.RAEMPublisher));
                if(sort=="RAEMPublisher")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RAEMPublisher):query.OrderByDescending(t=>t.RAEMPublisher);
                    isordered = true;
                }
				// RAEMJobDescription NVARCHAR(50) 职位描述 
                if(!string.IsNullOrEmpty(searchModel.RAEMJobDescription)) query = query.Where(t=>t.RAEMJobDescription.Contains(searchModel.RAEMJobDescription));
                if(sort=="RAEMJobDescription")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RAEMJobDescription):query.OrderByDescending(t=>t.RAEMJobDescription);
                    isordered = true;
                }
				// RAEMJobResponsibilities NVARCHAR(4000) 职位职责内容 
                if(!string.IsNullOrEmpty(searchModel.RAEMJobResponsibilities)) query = query.Where(t=>t.RAEMJobResponsibilities.Contains(searchModel.RAEMJobResponsibilities));
                if(sort=="RAEMJobResponsibilities")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RAEMJobResponsibilities):query.OrderByDescending(t=>t.RAEMJobResponsibilities);
                    isordered = true;
                }
				// RAEMContentsOfJobRequirements NVARCHAR(4000) 职位要求内容 
                if(!string.IsNullOrEmpty(searchModel.RAEMContentsOfJobRequirements)) query = query.Where(t=>t.RAEMContentsOfJobRequirements.Contains(searchModel.RAEMContentsOfJobRequirements));
                if(sort=="RAEMContentsOfJobRequirements")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RAEMContentsOfJobRequirements):query.OrderByDescending(t=>t.RAEMContentsOfJobRequirements);
                    isordered = true;
                }
				// RAEMEntryintoforceTime DATETIME 生效时间 
                if(searchModel.FromRAEMEntryintoforceTime!=null) query = query.Where(t=>t.RAEMEntryintoforceTime>=searchModel.FromRAEMEntryintoforceTime);
                if(searchModel.ToRAEMEntryintoforceTime!=null) query = query.Where(t=>t.RAEMEntryintoforceTime<=searchModel.ToRAEMEntryintoforceTime);
                if(sort=="RAEMEntryintoforceTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RAEMEntryintoforceTime):query.OrderByDescending(t=>t.RAEMEntryintoforceTime);
                    isordered = true;
                }
				// RAEMFailureTime DATETIME 失效时间 
                if(searchModel.FromRAEMFailureTime!=null) query = query.Where(t=>t.RAEMFailureTime>=searchModel.FromRAEMFailureTime);
                if(searchModel.ToRAEMFailureTime!=null) query = query.Where(t=>t.RAEMFailureTime<=searchModel.ToRAEMFailureTime);
                if(sort=="RAEMFailureTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.RAEMFailureTime):query.OrderByDescending(t=>t.RAEMFailureTime);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.RAEMEmployingUnit.Contains(search)||t.RAEMPosition.Contains(search)||t.RAEMPublisher.Contains(search)||t.RAEMJobDescription.Contains(search)||t.RAEMJobResponsibilities.Contains(search)||t.RAEMContentsOfJobRequirements.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<RecruitmentAndEmploymentModule>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党群结队】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PartyAndGroupFormationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.PartyAndGroupFormation.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党群结队】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党群结队】
    /// </summary>
    public partial class DeletePartyAndGroupFormationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<PartyAndGroupFormation>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.PartyAndGroupFormation.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.PartyAndGroupFormation.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党群结队记录";
    }
	
    /// <summary>
    /// 保存【党群结队】
    /// </summary>
    public partial class SavePartyAndGroupFormationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<PartyAndGroupFormation>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.PartyAndGroupFormation.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.PartyAndGroupFormation.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.PAGFPartyOrganizationsAffiliatedToThem = HttpUtility.UrlDecode(entity.PAGFPartyOrganizationsAffiliatedToThem);
					// NVARCHAR(50)
				entity.PAGFNameOfMember = HttpUtility.UrlDecode(entity.PAGFNameOfMember);
					// NVARCHAR(4000)
				entity.PAGFIdCardNo = HttpUtility.UrlDecode(entity.PAGFIdCardNo);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.PartyAndGroupFormation.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条PartyAndGroupFormation记录";
    }
	
    /// <summary>
    /// 查询空的【党群结队】
    /// </summary>
    public partial class GetPartyAndGroupFormationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new PartyAndGroupFormation();
        }
        public override string Comments=> "获取空的党群结队记录";
    }
	
    /// <summary>
    /// 查询【党群结队】列表
    /// </summary>
    public partial class GetPartyAndGroupFormationListEvaluator : Evaluator
    {
        public override string Comments=> "获取PartyAndGroupFormation列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PartyAndGroupFormationSearchModel>() ?? new PartyAndGroupFormationSearchModel();
                var query = ctx.PartyAndGroupFormation.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PAGFPartyOrganizationsAffiliatedToThem NVARCHAR(50) 所属党组织 
                if(!string.IsNullOrEmpty(searchModel.PAGFPartyOrganizationsAffiliatedToThem)) query = query.Where(t=>t.PAGFPartyOrganizationsAffiliatedToThem.Contains(searchModel.PAGFPartyOrganizationsAffiliatedToThem));
                if(sort=="PAGFPartyOrganizationsAffiliatedToThem")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAGFPartyOrganizationsAffiliatedToThem):query.OrderByDescending(t=>t.PAGFPartyOrganizationsAffiliatedToThem);
                    isordered = true;
                }
				// PAGFNameOfMember NVARCHAR(50) 成员姓名 
                if(!string.IsNullOrEmpty(searchModel.PAGFNameOfMember)) query = query.Where(t=>t.PAGFNameOfMember.Contains(searchModel.PAGFNameOfMember));
                if(sort=="PAGFNameOfMember")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAGFNameOfMember):query.OrderByDescending(t=>t.PAGFNameOfMember);
                    isordered = true;
                }
				// PAGFIdCardNo NVARCHAR(4000) 身份证号码 
                if(!string.IsNullOrEmpty(searchModel.PAGFIdCardNo)) query = query.Where(t=>t.PAGFIdCardNo.Contains(searchModel.PAGFIdCardNo));
                if(sort=="PAGFIdCardNo")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAGFIdCardNo):query.OrderByDescending(t=>t.PAGFIdCardNo);
                    isordered = true;
                }
				// PAGFCreationTime DATETIME 创建时间 
                if(searchModel.FromPAGFCreationTime!=null) query = query.Where(t=>t.PAGFCreationTime>=searchModel.FromPAGFCreationTime);
                if(searchModel.ToPAGFCreationTime!=null) query = query.Where(t=>t.PAGFCreationTime<=searchModel.ToPAGFCreationTime);
                if(sort=="PAGFCreationTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAGFCreationTime):query.OrderByDescending(t=>t.PAGFCreationTime);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PAGFPartyOrganizationsAffiliatedToThem.Contains(search)||t.PAGFNameOfMember.Contains(search)||t.PAGFIdCardNo.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<PartyAndGroupFormation>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【党员活动】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PartyMemberActivitiesCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.PartyMemberActivities.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【党员活动】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【党员活动】
    /// </summary>
    public partial class DeletePartyMemberActivitiesEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<PartyMemberActivities>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.PartyMemberActivities.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.PartyMemberActivities.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条党员活动记录";
    }
	
    /// <summary>
    /// 保存【党员活动】
    /// </summary>
    public partial class SavePartyMemberActivitiesEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<PartyMemberActivities>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.PartyMemberActivities.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.PartyMemberActivities.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.PMAActivityName = HttpUtility.UrlDecode(entity.PMAActivityName);
					// NVARCHAR(50)
				entity.PMAActivityBrief = HttpUtility.UrlDecode(entity.PMAActivityBrief);
					// NVARCHAR(50)
				entity.PMACoverageArea = HttpUtility.UrlDecode(entity.PMACoverageArea);
					// NVARCHAR(4000)
				entity.PMAActivePhotos = HttpUtility.UrlDecode(entity.PMAActivePhotos);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.PartyMemberActivities.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条PartyMemberActivities记录";
    }
	
    /// <summary>
    /// 查询空的【党员活动】
    /// </summary>
    public partial class GetPartyMemberActivitiesEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new PartyMemberActivities();
        }
        public override string Comments=> "获取空的党员活动记录";
    }
	
    /// <summary>
    /// 查询【党员活动】列表
    /// </summary>
    public partial class GetPartyMemberActivitiesListEvaluator : Evaluator
    {
        public override string Comments=> "获取PartyMemberActivities列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PartyMemberActivitiesSearchModel>() ?? new PartyMemberActivitiesSearchModel();
                var query = ctx.PartyMemberActivities.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PMAActivityName NVARCHAR(50) 活动名称 
                if(!string.IsNullOrEmpty(searchModel.PMAActivityName)) query = query.Where(t=>t.PMAActivityName.Contains(searchModel.PMAActivityName));
                if(sort=="PMAActivityName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PMAActivityName):query.OrderByDescending(t=>t.PMAActivityName);
                    isordered = true;
                }
				// PMAActivityBrief NVARCHAR(50) 活动简介 
                if(!string.IsNullOrEmpty(searchModel.PMAActivityBrief)) query = query.Where(t=>t.PMAActivityBrief.Contains(searchModel.PMAActivityBrief));
                if(sort=="PMAActivityBrief")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PMAActivityBrief):query.OrderByDescending(t=>t.PMAActivityBrief);
                    isordered = true;
                }
				// PMACoverageArea NVARCHAR(50) 覆盖范围 
                if(!string.IsNullOrEmpty(searchModel.PMACoverageArea)) query = query.Where(t=>t.PMACoverageArea.Contains(searchModel.PMACoverageArea));
                if(sort=="PMACoverageArea")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PMACoverageArea):query.OrderByDescending(t=>t.PMACoverageArea);
                    isordered = true;
                }
				// PMAActivePhotos NVARCHAR(4000) 活动照片 
                if(!string.IsNullOrEmpty(searchModel.PMAActivePhotos)) query = query.Where(t=>t.PMAActivePhotos.Contains(searchModel.PMAActivePhotos));
                if(sort=="PMAActivePhotos")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PMAActivePhotos):query.OrderByDescending(t=>t.PMAActivePhotos);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PMAActivityName.Contains(search)||t.PMAActivityBrief.Contains(search)||t.PMACoverageArea.Contains(search)||t.PMAActivePhotos.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<PartyMemberActivities>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【美丽乡村】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class BeautifulCountrysideCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.BeautifulCountryside.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【美丽乡村】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【美丽乡村】
    /// </summary>
    public partial class DeleteBeautifulCountrysideEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<BeautifulCountryside>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.BeautifulCountryside.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.BeautifulCountryside.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条美丽乡村记录";
    }
	
    /// <summary>
    /// 保存【美丽乡村】
    /// </summary>
    public partial class SaveBeautifulCountrysideEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<BeautifulCountryside>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.BeautifulCountryside.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.BeautifulCountryside.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.BCParticularYear = HttpUtility.UrlDecode(entity.BCParticularYear);
					// NVARCHAR(50)
				entity.BCMonth = HttpUtility.UrlDecode(entity.BCMonth);
					// NVARCHAR(4000)
				entity.BCTitle = HttpUtility.UrlDecode(entity.BCTitle);
					// NVARCHAR(4000)
				entity.BCPhoto = HttpUtility.UrlDecode(entity.BCPhoto);
					// NVARCHAR(50)
				entity.BCAchievementsInConstruction = HttpUtility.UrlDecode(entity.BCAchievementsInConstruction);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.BeautifulCountryside.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条BeautifulCountryside记录";
    }
	
    /// <summary>
    /// 查询空的【美丽乡村】
    /// </summary>
    public partial class GetBeautifulCountrysideEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new BeautifulCountryside();
        }
        public override string Comments=> "获取空的美丽乡村记录";
    }
	
    /// <summary>
    /// 查询【美丽乡村】列表
    /// </summary>
    public partial class GetBeautifulCountrysideListEvaluator : Evaluator
    {
        public override string Comments=> "获取BeautifulCountryside列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<BeautifulCountrysideSearchModel>() ?? new BeautifulCountrysideSearchModel();
                var query = ctx.BeautifulCountryside.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// BCParticularYear NVARCHAR(50) 年份 
                if(!string.IsNullOrEmpty(searchModel.BCParticularYear)) query = query.Where(t=>t.BCParticularYear.Contains(searchModel.BCParticularYear));
                if(sort=="BCParticularYear")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BCParticularYear):query.OrderByDescending(t=>t.BCParticularYear);
                    isordered = true;
                }
				// BCMonth NVARCHAR(50) 月份 
                if(!string.IsNullOrEmpty(searchModel.BCMonth)) query = query.Where(t=>t.BCMonth.Contains(searchModel.BCMonth));
                if(sort=="BCMonth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BCMonth):query.OrderByDescending(t=>t.BCMonth);
                    isordered = true;
                }
				// BCTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.BCTitle)) query = query.Where(t=>t.BCTitle.Contains(searchModel.BCTitle));
                if(sort=="BCTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BCTitle):query.OrderByDescending(t=>t.BCTitle);
                    isordered = true;
                }
				// BCPhoto NVARCHAR(4000) 照片 
                if(!string.IsNullOrEmpty(searchModel.BCPhoto)) query = query.Where(t=>t.BCPhoto.Contains(searchModel.BCPhoto));
                if(sort=="BCPhoto")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BCPhoto):query.OrderByDescending(t=>t.BCPhoto);
                    isordered = true;
                }
				// BCAchievementsInConstruction NVARCHAR(50) 建设成果 
                if(!string.IsNullOrEmpty(searchModel.BCAchievementsInConstruction)) query = query.Where(t=>t.BCAchievementsInConstruction.Contains(searchModel.BCAchievementsInConstruction));
                if(sort=="BCAchievementsInConstruction")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.BCAchievementsInConstruction):query.OrderByDescending(t=>t.BCAchievementsInConstruction);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.BCParticularYear.Contains(search)||t.BCMonth.Contains(search)||t.BCTitle.Contains(search)||t.BCPhoto.Contains(search)||t.BCAchievementsInConstruction.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<BeautifulCountryside>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【引水上山】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class DrawWaterUpaHillCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.DrawWaterUpaHill.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【引水上山】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【引水上山】
    /// </summary>
    public partial class DeleteDrawWaterUpaHillEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<DrawWaterUpaHill>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.DrawWaterUpaHill.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.DrawWaterUpaHill.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条引水上山记录";
    }
	
    /// <summary>
    /// 保存【引水上山】
    /// </summary>
    public partial class SaveDrawWaterUpaHillEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<DrawWaterUpaHill>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.DrawWaterUpaHill.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.DrawWaterUpaHill.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.DWUHParticularYear = HttpUtility.UrlDecode(entity.DWUHParticularYear);
					// NVARCHAR(50)
				entity.DWUHMonth = HttpUtility.UrlDecode(entity.DWUHMonth);
					// NVARCHAR(4000)
				entity.DWUHTitle = HttpUtility.UrlDecode(entity.DWUHTitle);
					// NVARCHAR(4000)
				entity.DWUHPhoto = HttpUtility.UrlDecode(entity.DWUHPhoto);
					// NVARCHAR(50)
				entity.DWUHAchievementsInConstruction = HttpUtility.UrlDecode(entity.DWUHAchievementsInConstruction);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.DrawWaterUpaHill.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条DrawWaterUpaHill记录";
    }
	
    /// <summary>
    /// 查询空的【引水上山】
    /// </summary>
    public partial class GetDrawWaterUpaHillEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new DrawWaterUpaHill();
        }
        public override string Comments=> "获取空的引水上山记录";
    }
	
    /// <summary>
    /// 查询【引水上山】列表
    /// </summary>
    public partial class GetDrawWaterUpaHillListEvaluator : Evaluator
    {
        public override string Comments=> "获取DrawWaterUpaHill列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<DrawWaterUpaHillSearchModel>() ?? new DrawWaterUpaHillSearchModel();
                var query = ctx.DrawWaterUpaHill.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// DWUHParticularYear NVARCHAR(50) 年份 
                if(!string.IsNullOrEmpty(searchModel.DWUHParticularYear)) query = query.Where(t=>t.DWUHParticularYear.Contains(searchModel.DWUHParticularYear));
                if(sort=="DWUHParticularYear")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DWUHParticularYear):query.OrderByDescending(t=>t.DWUHParticularYear);
                    isordered = true;
                }
				// DWUHMonth NVARCHAR(50) 月份 
                if(!string.IsNullOrEmpty(searchModel.DWUHMonth)) query = query.Where(t=>t.DWUHMonth.Contains(searchModel.DWUHMonth));
                if(sort=="DWUHMonth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DWUHMonth):query.OrderByDescending(t=>t.DWUHMonth);
                    isordered = true;
                }
				// DWUHTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.DWUHTitle)) query = query.Where(t=>t.DWUHTitle.Contains(searchModel.DWUHTitle));
                if(sort=="DWUHTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DWUHTitle):query.OrderByDescending(t=>t.DWUHTitle);
                    isordered = true;
                }
				// DWUHPhoto NVARCHAR(4000) 照片 
                if(!string.IsNullOrEmpty(searchModel.DWUHPhoto)) query = query.Where(t=>t.DWUHPhoto.Contains(searchModel.DWUHPhoto));
                if(sort=="DWUHPhoto")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DWUHPhoto):query.OrderByDescending(t=>t.DWUHPhoto);
                    isordered = true;
                }
				// DWUHAchievementsInConstruction NVARCHAR(50) 建设成果 
                if(!string.IsNullOrEmpty(searchModel.DWUHAchievementsInConstruction)) query = query.Where(t=>t.DWUHAchievementsInConstruction.Contains(searchModel.DWUHAchievementsInConstruction));
                if(sort=="DWUHAchievementsInConstruction")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.DWUHAchievementsInConstruction):query.OrderByDescending(t=>t.DWUHAchievementsInConstruction);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.DWUHParticularYear.Contains(search)||t.DWUHMonth.Contains(search)||t.DWUHTitle.Contains(search)||t.DWUHPhoto.Contains(search)||t.DWUHAchievementsInConstruction.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<DrawWaterUpaHill>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【宣传】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PropagandaCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Propaganda.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【宣传】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【宣传】
    /// </summary>
    public partial class DeletePropagandaEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Propaganda>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Propaganda.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Propaganda.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条宣传记录";
    }
	
    /// <summary>
    /// 保存【宣传】
    /// </summary>
    public partial class SavePropagandaEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Propaganda>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Propaganda.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Propaganda.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(4000)
				entity.PTitle = HttpUtility.UrlDecode(entity.PTitle);
					// NVARCHAR(50)
				entity.PCategory = HttpUtility.UrlDecode(entity.PCategory);
					// NVARCHAR(50)
				entity.PSubcategory = HttpUtility.UrlDecode(entity.PSubcategory);
					// NVARCHAR(4000)
				entity.PContent = HttpUtility.UrlDecode(entity.PContent);
					// NVARCHAR(4000)
				entity.PAddress = HttpUtility.UrlDecode(entity.PAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Propaganda.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Propaganda记录";
    }
	
    /// <summary>
    /// 查询空的【宣传】
    /// </summary>
    public partial class GetPropagandaEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Propaganda();
        }
        public override string Comments=> "获取空的宣传记录";
    }
	
    /// <summary>
    /// 查询【宣传】列表
    /// </summary>
    public partial class GetPropagandaListEvaluator : Evaluator
    {
        public override string Comments=> "获取Propaganda列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PropagandaSearchModel>() ?? new PropagandaSearchModel();
                var query = ctx.Propaganda.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PTitle NVARCHAR(4000) 标题 
                if(!string.IsNullOrEmpty(searchModel.PTitle)) query = query.Where(t=>t.PTitle.Contains(searchModel.PTitle));
                if(sort=="PTitle")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTitle):query.OrderByDescending(t=>t.PTitle);
                    isordered = true;
                }
				// PCategory NVARCHAR(50) 类别 
                if(!string.IsNullOrEmpty(searchModel.PCategory)) query = query.Where(t=>t.PCategory.Contains(searchModel.PCategory));
                if(sort=="PCategory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PCategory):query.OrderByDescending(t=>t.PCategory);
                    isordered = true;
                }
				// PSubcategory NVARCHAR(50) 子类别 
                if(!string.IsNullOrEmpty(searchModel.PSubcategory)) query = query.Where(t=>t.PSubcategory.Contains(searchModel.PSubcategory));
                if(sort=="PSubcategory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PSubcategory):query.OrderByDescending(t=>t.PSubcategory);
                    isordered = true;
                }
				// PContent NVARCHAR(4000) 内容 
                if(!string.IsNullOrEmpty(searchModel.PContent)) query = query.Where(t=>t.PContent.Contains(searchModel.PContent));
                if(sort=="PContent")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PContent):query.OrderByDescending(t=>t.PContent);
                    isordered = true;
                }
				// PAddress NVARCHAR(4000) 地址 
                if(!string.IsNullOrEmpty(searchModel.PAddress)) query = query.Where(t=>t.PAddress.Contains(searchModel.PAddress));
                if(sort=="PAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAddress):query.OrderByDescending(t=>t.PAddress);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PTitle.Contains(search)||t.PCategory.Contains(search)||t.PSubcategory.Contains(search)||t.PContent.Contains(search)||t.PAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Propaganda>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【组织】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class OrganizationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Organization.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【组织】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【组织】
    /// </summary>
    public partial class DeleteOrganizationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Organization>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Organization.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Organization.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条组织记录";
    }
	
    /// <summary>
    /// 保存【组织】
    /// </summary>
    public partial class SaveOrganizationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Organization>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Organization.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Organization.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.OMembershipNumber = HttpUtility.UrlDecode(entity.OMembershipNumber);
					// NVARCHAR(50)
				entity.OFullName = HttpUtility.UrlDecode(entity.OFullName);
					// NVARCHAR(50)
				entity.OSuperior = HttpUtility.UrlDecode(entity.OSuperior);
					// NVARCHAR(50)
				entity.OOrganizationName = HttpUtility.UrlDecode(entity.OOrganizationName);
					// NVARCHAR(50)
				entity.OSubordinateBranch = HttpUtility.UrlDecode(entity.OSubordinateBranch);
					// NVARCHAR(4000)
				entity.OAddress = HttpUtility.UrlDecode(entity.OAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Organization.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Organization记录";
    }
	
    /// <summary>
    /// 查询空的【组织】
    /// </summary>
    public partial class GetOrganizationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Organization();
        }
        public override string Comments=> "获取空的组织记录";
    }
	
    /// <summary>
    /// 查询【组织】列表
    /// </summary>
    public partial class GetOrganizationListEvaluator : Evaluator
    {
        public override string Comments=> "获取Organization列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<OrganizationSearchModel>() ?? new OrganizationSearchModel();
                var query = ctx.Organization.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// OMembershipNumber NVARCHAR(50) 成员编号 
                if(!string.IsNullOrEmpty(searchModel.OMembershipNumber)) query = query.Where(t=>t.OMembershipNumber.Contains(searchModel.OMembershipNumber));
                if(sort=="OMembershipNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.OMembershipNumber):query.OrderByDescending(t=>t.OMembershipNumber);
                    isordered = true;
                }
				// OFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.OFullName)) query = query.Where(t=>t.OFullName.Contains(searchModel.OFullName));
                if(sort=="OFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.OFullName):query.OrderByDescending(t=>t.OFullName);
                    isordered = true;
                }
				// OSuperior NVARCHAR(50) 上级 
                if(!string.IsNullOrEmpty(searchModel.OSuperior)) query = query.Where(t=>t.OSuperior.Contains(searchModel.OSuperior));
                if(sort=="OSuperior")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.OSuperior):query.OrderByDescending(t=>t.OSuperior);
                    isordered = true;
                }
				// OOrganizationName NVARCHAR(50) 组织名称 
                if(!string.IsNullOrEmpty(searchModel.OOrganizationName)) query = query.Where(t=>t.OOrganizationName.Contains(searchModel.OOrganizationName));
                if(sort=="OOrganizationName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.OOrganizationName):query.OrderByDescending(t=>t.OOrganizationName);
                    isordered = true;
                }
				// OSubordinateBranch NVARCHAR(50) 所属支部 
                if(!string.IsNullOrEmpty(searchModel.OSubordinateBranch)) query = query.Where(t=>t.OSubordinateBranch.Contains(searchModel.OSubordinateBranch));
                if(sort=="OSubordinateBranch")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.OSubordinateBranch):query.OrderByDescending(t=>t.OSubordinateBranch);
                    isordered = true;
                }
				// OAddress NVARCHAR(4000) 地址 
                if(!string.IsNullOrEmpty(searchModel.OAddress)) query = query.Where(t=>t.OAddress.Contains(searchModel.OAddress));
                if(sort=="OAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.OAddress):query.OrderByDescending(t=>t.OAddress);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.OMembershipNumber.Contains(search)||t.OFullName.Contains(search)||t.OSuperior.Contains(search)||t.OOrganizationName.Contains(search)||t.OSubordinateBranch.Contains(search)||t.OAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Organization>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【工会】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class LabourUnionCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.LabourUnion.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【工会】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【工会】
    /// </summary>
    public partial class DeleteLabourUnionEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<LabourUnion>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.LabourUnion.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.LabourUnion.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条工会记录";
    }
	
    /// <summary>
    /// 保存【工会】
    /// </summary>
    public partial class SaveLabourUnionEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<LabourUnion>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.LabourUnion.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.LabourUnion.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.LUUnitOrganizationCode = HttpUtility.UrlDecode(entity.LUUnitOrganizationCode);
					// NVARCHAR(50)
				entity.LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit = HttpUtility.UrlDecode(entity.LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit);
					// NVARCHAR(50)
				entity.LUClassificationOfUnitsOrSubjectsOfUnits = HttpUtility.UrlDecode(entity.LUClassificationOfUnitsOrSubjectsOfUnits);
					// NVARCHAR(4000)
				entity.LUUnitAddress = HttpUtility.UrlDecode(entity.LUUnitAddress);
					// NVARCHAR(50)
				entity.LUHigherLevelTradeUnion = HttpUtility.UrlDecode(entity.LUHigherLevelTradeUnion);
					// NVARCHAR(50)
				entity.LUUnitTradeUnionName = HttpUtility.UrlDecode(entity.LUUnitTradeUnionName);
					// NVARCHAR(50)
				entity.LUTheHeadOfTheTradeUnion = HttpUtility.UrlDecode(entity.LUTheHeadOfTheTradeUnion);
					// NVARCHAR(50)
				entity.LUTelephoneCallsFromTradeUnionLeaders = HttpUtility.UrlDecode(entity.LUTelephoneCallsFromTradeUnionLeaders);
					// NVARCHAR(50)
				entity.LUTradeUnionOfficeTelephone = HttpUtility.UrlDecode(entity.LUTradeUnionOfficeTelephone);
					// NVARCHAR(4000)
				entity.LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou = HttpUtility.UrlDecode(entity.LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou);
					// NVARCHAR(50)
				entity.LUTotalNumberOfEmployeesInaUnit = HttpUtility.UrlDecode(entity.LUTotalNumberOfEmployeesInaUnit);
					// NVARCHAR(50)
				entity.LUNumberOfUnitMembers = HttpUtility.UrlDecode(entity.LUNumberOfUnitMembers);
					// NVARCHAR(50)
				entity.LUNumberOfFemaleEmployeesInaUnit = HttpUtility.UrlDecode(entity.LUNumberOfFemaleEmployeesInaUnit);
					// NVARCHAR(50)
				entity.LUNumberOfFemaleMembersInaUnit = HttpUtility.UrlDecode(entity.LUNumberOfFemaleMembersInaUnit);
					// NVARCHAR(50)
				entity.LUStatisticalTopic1 = HttpUtility.UrlDecode(entity.LUStatisticalTopic1);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.LabourUnion.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条LabourUnion记录";
    }
	
    /// <summary>
    /// 查询空的【工会】
    /// </summary>
    public partial class GetLabourUnionEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new LabourUnion();
        }
        public override string Comments=> "获取空的工会记录";
    }
	
    /// <summary>
    /// 查询【工会】列表
    /// </summary>
    public partial class GetLabourUnionListEvaluator : Evaluator
    {
        public override string Comments=> "获取LabourUnion列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<LabourUnionSearchModel>() ?? new LabourUnionSearchModel();
                var query = ctx.LabourUnion.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// LUUnitOrganizationCode NVARCHAR(50) 单位组织机构代码 
                if(!string.IsNullOrEmpty(searchModel.LUUnitOrganizationCode)) query = query.Where(t=>t.LUUnitOrganizationCode.Contains(searchModel.LUUnitOrganizationCode));
                if(sort=="LUUnitOrganizationCode")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUUnitOrganizationCode):query.OrderByDescending(t=>t.LUUnitOrganizationCode);
                    isordered = true;
                }
				// LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit NVARCHAR(50) 单位或单位主体的国民经济行业分类代码 
                if(!string.IsNullOrEmpty(searchModel.LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit)) query = query.Where(t=>t.LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit.Contains(searchModel.LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit));
                if(sort=="LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit):query.OrderByDescending(t=>t.LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit);
                    isordered = true;
                }
				// LUClassificationOfUnitsOrSubjectsOfUnits NVARCHAR(50) 单位或单位主体的单位类别 
                if(!string.IsNullOrEmpty(searchModel.LUClassificationOfUnitsOrSubjectsOfUnits)) query = query.Where(t=>t.LUClassificationOfUnitsOrSubjectsOfUnits.Contains(searchModel.LUClassificationOfUnitsOrSubjectsOfUnits));
                if(sort=="LUClassificationOfUnitsOrSubjectsOfUnits")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUClassificationOfUnitsOrSubjectsOfUnits):query.OrderByDescending(t=>t.LUClassificationOfUnitsOrSubjectsOfUnits);
                    isordered = true;
                }
				// LUUnitAddress NVARCHAR(4000) 单位地址 
                if(!string.IsNullOrEmpty(searchModel.LUUnitAddress)) query = query.Where(t=>t.LUUnitAddress.Contains(searchModel.LUUnitAddress));
                if(sort=="LUUnitAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUUnitAddress):query.OrderByDescending(t=>t.LUUnitAddress);
                    isordered = true;
                }
				// LUHigherLevelTradeUnion NVARCHAR(50) 上级工会 
                if(!string.IsNullOrEmpty(searchModel.LUHigherLevelTradeUnion)) query = query.Where(t=>t.LUHigherLevelTradeUnion.Contains(searchModel.LUHigherLevelTradeUnion));
                if(sort=="LUHigherLevelTradeUnion")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUHigherLevelTradeUnion):query.OrderByDescending(t=>t.LUHigherLevelTradeUnion);
                    isordered = true;
                }
				// LUUnitTradeUnionName NVARCHAR(50) 单位工会名称 
                if(!string.IsNullOrEmpty(searchModel.LUUnitTradeUnionName)) query = query.Where(t=>t.LUUnitTradeUnionName.Contains(searchModel.LUUnitTradeUnionName));
                if(sort=="LUUnitTradeUnionName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUUnitTradeUnionName):query.OrderByDescending(t=>t.LUUnitTradeUnionName);
                    isordered = true;
                }
				// LUBuildingTime DATETIME 建会时间 
                if(searchModel.FromLUBuildingTime!=null) query = query.Where(t=>t.LUBuildingTime>=searchModel.FromLUBuildingTime);
                if(searchModel.ToLUBuildingTime!=null) query = query.Where(t=>t.LUBuildingTime<=searchModel.ToLUBuildingTime);
                if(sort=="LUBuildingTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUBuildingTime):query.OrderByDescending(t=>t.LUBuildingTime);
                    isordered = true;
                }
				// LUTheHeadOfTheTradeUnion NVARCHAR(50) 工会负责人 
                if(!string.IsNullOrEmpty(searchModel.LUTheHeadOfTheTradeUnion)) query = query.Where(t=>t.LUTheHeadOfTheTradeUnion.Contains(searchModel.LUTheHeadOfTheTradeUnion));
                if(sort=="LUTheHeadOfTheTradeUnion")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUTheHeadOfTheTradeUnion):query.OrderByDescending(t=>t.LUTheHeadOfTheTradeUnion);
                    isordered = true;
                }
				// LUTelephoneCallsFromTradeUnionLeaders NVARCHAR(50) 工会负责人联系电话 
                if(!string.IsNullOrEmpty(searchModel.LUTelephoneCallsFromTradeUnionLeaders)) query = query.Where(t=>t.LUTelephoneCallsFromTradeUnionLeaders.Contains(searchModel.LUTelephoneCallsFromTradeUnionLeaders));
                if(sort=="LUTelephoneCallsFromTradeUnionLeaders")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUTelephoneCallsFromTradeUnionLeaders):query.OrderByDescending(t=>t.LUTelephoneCallsFromTradeUnionLeaders);
                    isordered = true;
                }
				// LUTradeUnionOfficeTelephone NVARCHAR(50) 工会办公电话 
                if(!string.IsNullOrEmpty(searchModel.LUTradeUnionOfficeTelephone)) query = query.Where(t=>t.LUTradeUnionOfficeTelephone.Contains(searchModel.LUTradeUnionOfficeTelephone));
                if(sort=="LUTradeUnionOfficeTelephone")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUTradeUnionOfficeTelephone):query.OrderByDescending(t=>t.LUTradeUnionOfficeTelephone);
                    isordered = true;
                }
				// LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou NVARCHAR(4000) 本单位已交至苏州银行的会员身份证复印件数量 
                if(!string.IsNullOrEmpty(searchModel.LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou)) query = query.Where(t=>t.LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou.Contains(searchModel.LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou));
                if(sort=="LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou):query.OrderByDescending(t=>t.LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou);
                    isordered = true;
                }
				// LUTotalNumberOfEmployeesInaUnit NVARCHAR(50) 单位职工总数人 
                if(!string.IsNullOrEmpty(searchModel.LUTotalNumberOfEmployeesInaUnit)) query = query.Where(t=>t.LUTotalNumberOfEmployeesInaUnit.Contains(searchModel.LUTotalNumberOfEmployeesInaUnit));
                if(sort=="LUTotalNumberOfEmployeesInaUnit")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUTotalNumberOfEmployeesInaUnit):query.OrderByDescending(t=>t.LUTotalNumberOfEmployeesInaUnit);
                    isordered = true;
                }
				// LUNumberOfUnitMembers NVARCHAR(50) 单位会员数人 
                if(!string.IsNullOrEmpty(searchModel.LUNumberOfUnitMembers)) query = query.Where(t=>t.LUNumberOfUnitMembers.Contains(searchModel.LUNumberOfUnitMembers));
                if(sort=="LUNumberOfUnitMembers")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUNumberOfUnitMembers):query.OrderByDescending(t=>t.LUNumberOfUnitMembers);
                    isordered = true;
                }
				// LUNumberOfFemaleEmployeesInaUnit NVARCHAR(50) 单位女职工数人 
                if(!string.IsNullOrEmpty(searchModel.LUNumberOfFemaleEmployeesInaUnit)) query = query.Where(t=>t.LUNumberOfFemaleEmployeesInaUnit.Contains(searchModel.LUNumberOfFemaleEmployeesInaUnit));
                if(sort=="LUNumberOfFemaleEmployeesInaUnit")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUNumberOfFemaleEmployeesInaUnit):query.OrderByDescending(t=>t.LUNumberOfFemaleEmployeesInaUnit);
                    isordered = true;
                }
				// LUNumberOfFemaleMembersInaUnit NVARCHAR(50) 单位女会员数人 
                if(!string.IsNullOrEmpty(searchModel.LUNumberOfFemaleMembersInaUnit)) query = query.Where(t=>t.LUNumberOfFemaleMembersInaUnit.Contains(searchModel.LUNumberOfFemaleMembersInaUnit));
                if(sort=="LUNumberOfFemaleMembersInaUnit")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUNumberOfFemaleMembersInaUnit):query.OrderByDescending(t=>t.LUNumberOfFemaleMembersInaUnit);
                    isordered = true;
                }
				// LUStatisticalTopic1 NVARCHAR(50) 统计主题1 
                if(!string.IsNullOrEmpty(searchModel.LUStatisticalTopic1)) query = query.Where(t=>t.LUStatisticalTopic1.Contains(searchModel.LUStatisticalTopic1));
                if(sort=="LUStatisticalTopic1")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LUStatisticalTopic1):query.OrderByDescending(t=>t.LUStatisticalTopic1);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.LUUnitOrganizationCode.Contains(search)||t.LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit.Contains(search)||t.LUClassificationOfUnitsOrSubjectsOfUnits.Contains(search)||t.LUUnitAddress.Contains(search)||t.LUHigherLevelTradeUnion.Contains(search)||t.LUUnitTradeUnionName.Contains(search)||t.LUTheHeadOfTheTradeUnion.Contains(search)||t.LUTelephoneCallsFromTradeUnionLeaders.Contains(search)||t.LUTradeUnionOfficeTelephone.Contains(search)||t.LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou.Contains(search)||t.LUTotalNumberOfEmployeesInaUnit.Contains(search)||t.LUNumberOfUnitMembers.Contains(search)||t.LUNumberOfFemaleEmployeesInaUnit.Contains(search)||t.LUNumberOfFemaleMembersInaUnit.Contains(search)||t.LUStatisticalTopic1.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<LabourUnion>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【工会成员】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class TradeUnionMembersCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.TradeUnionMembers.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【工会成员】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【工会成员】
    /// </summary>
    public partial class DeleteTradeUnionMembersEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<TradeUnionMembers>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.TradeUnionMembers.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.TradeUnionMembers.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条工会成员记录";
    }
	
    /// <summary>
    /// 保存【工会成员】
    /// </summary>
    public partial class SaveTradeUnionMembersEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<TradeUnionMembers>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.TradeUnionMembers.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.TradeUnionMembers.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.TUMFullName = HttpUtility.UrlDecode(entity.TUMFullName);
					// NVARCHAR(50)
				entity.TUMGender = HttpUtility.UrlDecode(entity.TUMGender);
					// NVARCHAR(50)
				entity.TUMNation = HttpUtility.UrlDecode(entity.TUMNation);
					// NVARCHAR(50)
				entity.TUMDateOfBirth = HttpUtility.UrlDecode(entity.TUMDateOfBirth);
					// NVARCHAR(50)
				entity.TUMPoliticalOutlook = HttpUtility.UrlDecode(entity.TUMPoliticalOutlook);
					// NVARCHAR(50)
				entity.TUMEducation = HttpUtility.UrlDecode(entity.TUMEducation);
					// NVARCHAR(50)
				entity.TUMXxCityXxProvince = HttpUtility.UrlDecode(entity.TUMXxCityXxProvince);
					// NVARCHAR(4000)
				entity.TUMIdNumber = HttpUtility.UrlDecode(entity.TUMIdNumber);
					// NVARCHAR(4000)
				entity.TUMAddressUnitAddress = HttpUtility.UrlDecode(entity.TUMAddressUnitAddress);
					// NVARCHAR(50)
				entity.TUMPhoneNumber = HttpUtility.UrlDecode(entity.TUMPhoneNumber);
					// NVARCHAR(4000)
				entity.TUMLimitOfValidityOfIdentityCard = HttpUtility.UrlDecode(entity.TUMLimitOfValidityOfIdentityCard);
					// NVARCHAR(50)
				entity.TUMWhetherToEngageInToxicAndHarmfulWorkOrNot = HttpUtility.UrlDecode(entity.TUMWhetherToEngageInToxicAndHarmfulWorkOrNot);
					// NVARCHAR(4000)
				entity.TUMRemarks1 = HttpUtility.UrlDecode(entity.TUMRemarks1);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.TradeUnionMembers.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条TradeUnionMembers记录";
    }
	
    /// <summary>
    /// 查询空的【工会成员】
    /// </summary>
    public partial class GetTradeUnionMembersEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new TradeUnionMembers();
        }
        public override string Comments=> "获取空的工会成员记录";
    }
	
    /// <summary>
    /// 查询【工会成员】列表
    /// </summary>
    public partial class GetTradeUnionMembersListEvaluator : Evaluator
    {
        public override string Comments=> "获取TradeUnionMembers列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<TradeUnionMembersSearchModel>() ?? new TradeUnionMembersSearchModel();
                var query = ctx.TradeUnionMembers.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// TUMFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.TUMFullName)) query = query.Where(t=>t.TUMFullName.Contains(searchModel.TUMFullName));
                if(sort=="TUMFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMFullName):query.OrderByDescending(t=>t.TUMFullName);
                    isordered = true;
                }
				// TUMGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.TUMGender)) query = query.Where(t=>t.TUMGender.Contains(searchModel.TUMGender));
                if(sort=="TUMGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMGender):query.OrderByDescending(t=>t.TUMGender);
                    isordered = true;
                }
				// TUMNation NVARCHAR(50) 民族 
                if(!string.IsNullOrEmpty(searchModel.TUMNation)) query = query.Where(t=>t.TUMNation.Contains(searchModel.TUMNation));
                if(sort=="TUMNation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMNation):query.OrderByDescending(t=>t.TUMNation);
                    isordered = true;
                }
				// TUMDateOfBirth NVARCHAR(50) 出生年月 
                if(!string.IsNullOrEmpty(searchModel.TUMDateOfBirth)) query = query.Where(t=>t.TUMDateOfBirth.Contains(searchModel.TUMDateOfBirth));
                if(sort=="TUMDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMDateOfBirth):query.OrderByDescending(t=>t.TUMDateOfBirth);
                    isordered = true;
                }
				// TUMPoliticalOutlook NVARCHAR(50) 政治面貌 
                if(!string.IsNullOrEmpty(searchModel.TUMPoliticalOutlook)) query = query.Where(t=>t.TUMPoliticalOutlook.Contains(searchModel.TUMPoliticalOutlook));
                if(sort=="TUMPoliticalOutlook")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMPoliticalOutlook):query.OrderByDescending(t=>t.TUMPoliticalOutlook);
                    isordered = true;
                }
				// TUMEducation NVARCHAR(50) 学历 
                if(!string.IsNullOrEmpty(searchModel.TUMEducation)) query = query.Where(t=>t.TUMEducation.Contains(searchModel.TUMEducation));
                if(sort=="TUMEducation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMEducation):query.OrderByDescending(t=>t.TUMEducation);
                    isordered = true;
                }
				// TUMXxCityXxProvince NVARCHAR(50) 籍贯XX省XX市 
                if(!string.IsNullOrEmpty(searchModel.TUMXxCityXxProvince)) query = query.Where(t=>t.TUMXxCityXxProvince.Contains(searchModel.TUMXxCityXxProvince));
                if(sort=="TUMXxCityXxProvince")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMXxCityXxProvince):query.OrderByDescending(t=>t.TUMXxCityXxProvince);
                    isordered = true;
                }
				// TUMAdmissionTime DATETIME 入会时间 
                if(searchModel.FromTUMAdmissionTime!=null) query = query.Where(t=>t.TUMAdmissionTime>=searchModel.FromTUMAdmissionTime);
                if(searchModel.ToTUMAdmissionTime!=null) query = query.Where(t=>t.TUMAdmissionTime<=searchModel.ToTUMAdmissionTime);
                if(sort=="TUMAdmissionTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMAdmissionTime):query.OrderByDescending(t=>t.TUMAdmissionTime);
                    isordered = true;
                }
				// TUMIdNumber NVARCHAR(4000) 身份证号 
                if(!string.IsNullOrEmpty(searchModel.TUMIdNumber)) query = query.Where(t=>t.TUMIdNumber.Contains(searchModel.TUMIdNumber));
                if(sort=="TUMIdNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMIdNumber):query.OrderByDescending(t=>t.TUMIdNumber);
                    isordered = true;
                }
				// TUMAddressUnitAddress NVARCHAR(4000) 地址单位地址 
                if(!string.IsNullOrEmpty(searchModel.TUMAddressUnitAddress)) query = query.Where(t=>t.TUMAddressUnitAddress.Contains(searchModel.TUMAddressUnitAddress));
                if(sort=="TUMAddressUnitAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMAddressUnitAddress):query.OrderByDescending(t=>t.TUMAddressUnitAddress);
                    isordered = true;
                }
				// TUMPhoneNumber NVARCHAR(50) 手机号码 
                if(!string.IsNullOrEmpty(searchModel.TUMPhoneNumber)) query = query.Where(t=>t.TUMPhoneNumber.Contains(searchModel.TUMPhoneNumber));
                if(sort=="TUMPhoneNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMPhoneNumber):query.OrderByDescending(t=>t.TUMPhoneNumber);
                    isordered = true;
                }
				// TUMLimitOfValidityOfIdentityCard NVARCHAR(4000) 身份证有效期限 
                if(!string.IsNullOrEmpty(searchModel.TUMLimitOfValidityOfIdentityCard)) query = query.Where(t=>t.TUMLimitOfValidityOfIdentityCard.Contains(searchModel.TUMLimitOfValidityOfIdentityCard));
                if(sort=="TUMLimitOfValidityOfIdentityCard")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMLimitOfValidityOfIdentityCard):query.OrderByDescending(t=>t.TUMLimitOfValidityOfIdentityCard);
                    isordered = true;
                }
				// TUMWhetherToEngageInToxicAndHarmfulWorkOrNot NVARCHAR(50) 是否从事有毒有害工作是否 
                if(!string.IsNullOrEmpty(searchModel.TUMWhetherToEngageInToxicAndHarmfulWorkOrNot)) query = query.Where(t=>t.TUMWhetherToEngageInToxicAndHarmfulWorkOrNot.Contains(searchModel.TUMWhetherToEngageInToxicAndHarmfulWorkOrNot));
                if(sort=="TUMWhetherToEngageInToxicAndHarmfulWorkOrNot")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMWhetherToEngageInToxicAndHarmfulWorkOrNot):query.OrderByDescending(t=>t.TUMWhetherToEngageInToxicAndHarmfulWorkOrNot);
                    isordered = true;
                }
				// TUMRemarks1 NVARCHAR(4000) 备注1 
                if(!string.IsNullOrEmpty(searchModel.TUMRemarks1)) query = query.Where(t=>t.TUMRemarks1.Contains(searchModel.TUMRemarks1));
                if(sort=="TUMRemarks1")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.TUMRemarks1):query.OrderByDescending(t=>t.TUMRemarks1);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.TUMFullName.Contains(search)||t.TUMGender.Contains(search)||t.TUMNation.Contains(search)||t.TUMDateOfBirth.Contains(search)||t.TUMPoliticalOutlook.Contains(search)||t.TUMEducation.Contains(search)||t.TUMXxCityXxProvince.Contains(search)||t.TUMIdNumber.Contains(search)||t.TUMAddressUnitAddress.Contains(search)||t.TUMPhoneNumber.Contains(search)||t.TUMLimitOfValidityOfIdentityCard.Contains(search)||t.TUMWhetherToEngageInToxicAndHarmfulWorkOrNot.Contains(search)||t.TUMRemarks1.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<TradeUnionMembers>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【工作人员】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PersonnelCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Personnel.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【工作人员】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【工作人员】
    /// </summary>
    public partial class DeletePersonnelEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Personnel>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Personnel.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Personnel.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条工作人员记录";
    }
	
    /// <summary>
    /// 保存【工作人员】
    /// </summary>
    public partial class SavePersonnelEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Personnel>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Personnel.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Personnel.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.PEmployeeNumber = HttpUtility.UrlDecode(entity.PEmployeeNumber);
					// NVARCHAR(50)
				entity.PSuperior = HttpUtility.UrlDecode(entity.PSuperior);
					// NVARCHAR(50)
				entity.PResponsibleArea = HttpUtility.UrlDecode(entity.PResponsibleArea);
					// NVARCHAR(50)
				entity.PSubordinateLine = HttpUtility.UrlDecode(entity.PSubordinateLine);
					// NVARCHAR(4000)
				entity.PAddress = HttpUtility.UrlDecode(entity.PAddress);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Personnel.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Personnel记录";
    }
	
    /// <summary>
    /// 查询空的【工作人员】
    /// </summary>
    public partial class GetPersonnelEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Personnel();
        }
        public override string Comments=> "获取空的工作人员记录";
    }
	
    /// <summary>
    /// 查询【工作人员】列表
    /// </summary>
    public partial class GetPersonnelListEvaluator : Evaluator
    {
        public override string Comments=> "获取Personnel列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PersonnelSearchModel>() ?? new PersonnelSearchModel();
                var query = ctx.Personnel.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PEmployeeNumber NVARCHAR(50) 员工编号 
                if(!string.IsNullOrEmpty(searchModel.PEmployeeNumber)) query = query.Where(t=>t.PEmployeeNumber.Contains(searchModel.PEmployeeNumber));
                if(sort=="PEmployeeNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PEmployeeNumber):query.OrderByDescending(t=>t.PEmployeeNumber);
                    isordered = true;
                }
				// PSuperior NVARCHAR(50) 上级 
                if(!string.IsNullOrEmpty(searchModel.PSuperior)) query = query.Where(t=>t.PSuperior.Contains(searchModel.PSuperior));
                if(sort=="PSuperior")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PSuperior):query.OrderByDescending(t=>t.PSuperior);
                    isordered = true;
                }
				// PResponsibleArea NVARCHAR(50) 负责区域 
                if(!string.IsNullOrEmpty(searchModel.PResponsibleArea)) query = query.Where(t=>t.PResponsibleArea.Contains(searchModel.PResponsibleArea));
                if(sort=="PResponsibleArea")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PResponsibleArea):query.OrderByDescending(t=>t.PResponsibleArea);
                    isordered = true;
                }
				// PSubordinateLine NVARCHAR(50) 所属条线 
                if(!string.IsNullOrEmpty(searchModel.PSubordinateLine)) query = query.Where(t=>t.PSubordinateLine.Contains(searchModel.PSubordinateLine));
                if(sort=="PSubordinateLine")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PSubordinateLine):query.OrderByDescending(t=>t.PSubordinateLine);
                    isordered = true;
                }
				// PAddress NVARCHAR(4000) 地址 
                if(!string.IsNullOrEmpty(searchModel.PAddress)) query = query.Where(t=>t.PAddress.Contains(searchModel.PAddress));
                if(sort=="PAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PAddress):query.OrderByDescending(t=>t.PAddress);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PEmployeeNumber.Contains(search)||t.PSuperior.Contains(search)||t.PResponsibleArea.Contains(search)||t.PSubordinateLine.Contains(search)||t.PAddress.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Personnel>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【姑苏村问题处理】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class HandlingOfGusuVillageProblemCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.HandlingOfGusuVillageProblem.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【姑苏村问题处理】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【姑苏村问题处理】
    /// </summary>
    public partial class DeleteHandlingOfGusuVillageProblemEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<HandlingOfGusuVillageProblem>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.HandlingOfGusuVillageProblem.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.HandlingOfGusuVillageProblem.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条姑苏村问题处理记录";
    }
	
    /// <summary>
    /// 保存【姑苏村问题处理】
    /// </summary>
    public partial class SaveHandlingOfGusuVillageProblemEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<HandlingOfGusuVillageProblem>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.HandlingOfGusuVillageProblem.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.HandlingOfGusuVillageProblem.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.HOGVPQuestionNumber = HttpUtility.UrlDecode(entity.HOGVPQuestionNumber);
					// NVARCHAR(50)
				entity.HOGVPProblemDescription = HttpUtility.UrlDecode(entity.HOGVPProblemDescription);
					// NVARCHAR(50)
				entity.HOGVPQuestionCategories = HttpUtility.UrlDecode(entity.HOGVPQuestionCategories);
					// NVARCHAR(4000)
				entity.HOGVPPhoto = HttpUtility.UrlDecode(entity.HOGVPPhoto);
					// NVARCHAR(50)
				entity.HOGVPPersonInCharge = HttpUtility.UrlDecode(entity.HOGVPPersonInCharge);
					// NVARCHAR(50)
				entity.HOGVPProblemState = HttpUtility.UrlDecode(entity.HOGVPProblemState);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.HandlingOfGusuVillageProblem.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条HandlingOfGusuVillageProblem记录";
    }
	
    /// <summary>
    /// 查询空的【姑苏村问题处理】
    /// </summary>
    public partial class GetHandlingOfGusuVillageProblemEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new HandlingOfGusuVillageProblem();
        }
        public override string Comments=> "获取空的姑苏村问题处理记录";
    }
	
    /// <summary>
    /// 查询【姑苏村问题处理】列表
    /// </summary>
    public partial class GetHandlingOfGusuVillageProblemListEvaluator : Evaluator
    {
        public override string Comments=> "获取HandlingOfGusuVillageProblem列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<HandlingOfGusuVillageProblemSearchModel>() ?? new HandlingOfGusuVillageProblemSearchModel();
                var query = ctx.HandlingOfGusuVillageProblem.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// HOGVPQuestionNumber NVARCHAR(50) 问题编号 
                if(!string.IsNullOrEmpty(searchModel.HOGVPQuestionNumber)) query = query.Where(t=>t.HOGVPQuestionNumber.Contains(searchModel.HOGVPQuestionNumber));
                if(sort=="HOGVPQuestionNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HOGVPQuestionNumber):query.OrderByDescending(t=>t.HOGVPQuestionNumber);
                    isordered = true;
                }
				// HOGVPProblemDescription NVARCHAR(50) 问题描述 
                if(!string.IsNullOrEmpty(searchModel.HOGVPProblemDescription)) query = query.Where(t=>t.HOGVPProblemDescription.Contains(searchModel.HOGVPProblemDescription));
                if(sort=="HOGVPProblemDescription")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HOGVPProblemDescription):query.OrderByDescending(t=>t.HOGVPProblemDescription);
                    isordered = true;
                }
				// HOGVPQuestionCategories NVARCHAR(50) 问题类别 
                if(!string.IsNullOrEmpty(searchModel.HOGVPQuestionCategories)) query = query.Where(t=>t.HOGVPQuestionCategories.Contains(searchModel.HOGVPQuestionCategories));
                if(sort=="HOGVPQuestionCategories")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HOGVPQuestionCategories):query.OrderByDescending(t=>t.HOGVPQuestionCategories);
                    isordered = true;
                }
				// HOGVPPhoto NVARCHAR(4000) 照片 
                if(!string.IsNullOrEmpty(searchModel.HOGVPPhoto)) query = query.Where(t=>t.HOGVPPhoto.Contains(searchModel.HOGVPPhoto));
                if(sort=="HOGVPPhoto")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HOGVPPhoto):query.OrderByDescending(t=>t.HOGVPPhoto);
                    isordered = true;
                }
				// HOGVPPersonInCharge NVARCHAR(50) 负责人 
                if(!string.IsNullOrEmpty(searchModel.HOGVPPersonInCharge)) query = query.Where(t=>t.HOGVPPersonInCharge.Contains(searchModel.HOGVPPersonInCharge));
                if(sort=="HOGVPPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HOGVPPersonInCharge):query.OrderByDescending(t=>t.HOGVPPersonInCharge);
                    isordered = true;
                }
				// HOGVPProblemState NVARCHAR(50) 问题状态 
                if(searchModel.HOGVPProblemState!=null && searchModel.HOGVPProblemState.Length!=0) query = query.Where(t=>searchModel.HOGVPProblemState.Contains(t.HOGVPProblemState));
                if(sort=="HOGVPProblemState")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HOGVPProblemState):query.OrderByDescending(t=>t.HOGVPProblemState);
                    isordered = true;
                }
				// HOGVPConfirmationTime DATETIME 确认时间 
                if(searchModel.FromHOGVPConfirmationTime!=null) query = query.Where(t=>t.HOGVPConfirmationTime>=searchModel.FromHOGVPConfirmationTime);
                if(searchModel.ToHOGVPConfirmationTime!=null) query = query.Where(t=>t.HOGVPConfirmationTime<=searchModel.ToHOGVPConfirmationTime);
                if(sort=="HOGVPConfirmationTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HOGVPConfirmationTime):query.OrderByDescending(t=>t.HOGVPConfirmationTime);
                    isordered = true;
                }
				// HOGVPProcessingTime DATETIME 处理时间 
                if(searchModel.FromHOGVPProcessingTime!=null) query = query.Where(t=>t.HOGVPProcessingTime>=searchModel.FromHOGVPProcessingTime);
                if(searchModel.ToHOGVPProcessingTime!=null) query = query.Where(t=>t.HOGVPProcessingTime<=searchModel.ToHOGVPProcessingTime);
                if(sort=="HOGVPProcessingTime")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HOGVPProcessingTime):query.OrderByDescending(t=>t.HOGVPProcessingTime);
                    isordered = true;
                }
				// HOGVPRevisitDays DATETIME 回访时间 
                if(searchModel.FromHOGVPRevisitDays!=null) query = query.Where(t=>t.HOGVPRevisitDays>=searchModel.FromHOGVPRevisitDays);
                if(searchModel.ToHOGVPRevisitDays!=null) query = query.Where(t=>t.HOGVPRevisitDays<=searchModel.ToHOGVPRevisitDays);
                if(sort=="HOGVPRevisitDays")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.HOGVPRevisitDays):query.OrderByDescending(t=>t.HOGVPRevisitDays);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.HOGVPQuestionNumber.Contains(search)||t.HOGVPProblemDescription.Contains(search)||t.HOGVPQuestionCategories.Contains(search)||t.HOGVPPhoto.Contains(search)||t.HOGVPPersonInCharge.Contains(search)||t.HOGVPProblemState.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<HandlingOfGusuVillageProblem>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【渔政】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class FisheryAdministrationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.FisheryAdministration.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【渔政】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【渔政】
    /// </summary>
    public partial class DeleteFisheryAdministrationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<FisheryAdministration>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.FisheryAdministration.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.FisheryAdministration.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条渔政记录";
    }
	
    /// <summary>
    /// 保存【渔政】
    /// </summary>
    public partial class SaveFisheryAdministrationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<FisheryAdministration>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.FisheryAdministration.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.FisheryAdministration.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.FAFishingPermitNumber = HttpUtility.UrlDecode(entity.FAFishingPermitNumber);
					// NVARCHAR(50)
				entity.FANameOfTheHolder = HttpUtility.UrlDecode(entity.FANameOfTheHolder);
					// NVARCHAR(50)
				entity.FAPersonInCharge = HttpUtility.UrlDecode(entity.FAPersonInCharge);
					// NVARCHAR(4000)
				entity.FAAddress = HttpUtility.UrlDecode(entity.FAAddress);
					// NVARCHAR(50)
				entity.FAIsItEffective = HttpUtility.UrlDecode(entity.FAIsItEffective);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.FisheryAdministration.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条FisheryAdministration记录";
    }
	
    /// <summary>
    /// 查询空的【渔政】
    /// </summary>
    public partial class GetFisheryAdministrationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new FisheryAdministration();
        }
        public override string Comments=> "获取空的渔政记录";
    }
	
    /// <summary>
    /// 查询【渔政】列表
    /// </summary>
    public partial class GetFisheryAdministrationListEvaluator : Evaluator
    {
        public override string Comments=> "获取FisheryAdministration列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<FisheryAdministrationSearchModel>() ?? new FisheryAdministrationSearchModel();
                var query = ctx.FisheryAdministration.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// FAFishingPermitNumber NVARCHAR(50) 渔证编号 
                if(!string.IsNullOrEmpty(searchModel.FAFishingPermitNumber)) query = query.Where(t=>t.FAFishingPermitNumber.Contains(searchModel.FAFishingPermitNumber));
                if(sort=="FAFishingPermitNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FAFishingPermitNumber):query.OrderByDescending(t=>t.FAFishingPermitNumber);
                    isordered = true;
                }
				// FANameOfTheHolder NVARCHAR(50) 持证人姓名 
                if(!string.IsNullOrEmpty(searchModel.FANameOfTheHolder)) query = query.Where(t=>t.FANameOfTheHolder.Contains(searchModel.FANameOfTheHolder));
                if(sort=="FANameOfTheHolder")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FANameOfTheHolder):query.OrderByDescending(t=>t.FANameOfTheHolder);
                    isordered = true;
                }
				// FADateOfIssue DATETIME 发证日期 
                if(searchModel.FromFADateOfIssue!=null) query = query.Where(t=>t.FADateOfIssue>=searchModel.FromFADateOfIssue);
                if(searchModel.ToFADateOfIssue!=null) query = query.Where(t=>t.FADateOfIssue<=searchModel.ToFADateOfIssue);
                if(sort=="FADateOfIssue")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FADateOfIssue):query.OrderByDescending(t=>t.FADateOfIssue);
                    isordered = true;
                }
				// FADateOfNextRenewal DATETIME 下次换证日期 
                if(searchModel.FromFADateOfNextRenewal!=null) query = query.Where(t=>t.FADateOfNextRenewal>=searchModel.FromFADateOfNextRenewal);
                if(searchModel.ToFADateOfNextRenewal!=null) query = query.Where(t=>t.FADateOfNextRenewal<=searchModel.ToFADateOfNextRenewal);
                if(sort=="FADateOfNextRenewal")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FADateOfNextRenewal):query.OrderByDescending(t=>t.FADateOfNextRenewal);
                    isordered = true;
                }
				// FAPersonInCharge NVARCHAR(50) 负责人 
                if(!string.IsNullOrEmpty(searchModel.FAPersonInCharge)) query = query.Where(t=>t.FAPersonInCharge.Contains(searchModel.FAPersonInCharge));
                if(sort=="FAPersonInCharge")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FAPersonInCharge):query.OrderByDescending(t=>t.FAPersonInCharge);
                    isordered = true;
                }
				// FAAddress NVARCHAR(4000) 地址 
                if(!string.IsNullOrEmpty(searchModel.FAAddress)) query = query.Where(t=>t.FAAddress.Contains(searchModel.FAAddress));
                if(sort=="FAAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FAAddress):query.OrderByDescending(t=>t.FAAddress);
                    isordered = true;
                }
				// FAIsItEffective NVARCHAR(50) 是否有效 
                if(!string.IsNullOrEmpty(searchModel.FAIsItEffective)) query = query.Where(t=>t.FAIsItEffective.Contains(searchModel.FAIsItEffective));
                if(sort=="FAIsItEffective")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.FAIsItEffective):query.OrderByDescending(t=>t.FAIsItEffective);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.FAFishingPermitNumber.Contains(search)||t.FANameOfTheHolder.Contains(search)||t.FAPersonInCharge.Contains(search)||t.FAAddress.Contains(search)||t.FAIsItEffective.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<FisheryAdministration>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【妇联执委名单】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class ListOfExecutiveCommitteesOfWomensFederationCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.ListOfExecutiveCommitteesOfWomensFederation.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【妇联执委名单】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【妇联执委名单】
    /// </summary>
    public partial class DeleteListOfExecutiveCommitteesOfWomensFederationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<ListOfExecutiveCommitteesOfWomensFederation>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.ListOfExecutiveCommitteesOfWomensFederation.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.ListOfExecutiveCommitteesOfWomensFederation.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条妇联执委名单记录";
    }
	
    /// <summary>
    /// 保存【妇联执委名单】
    /// </summary>
    public partial class SaveListOfExecutiveCommitteesOfWomensFederationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<ListOfExecutiveCommitteesOfWomensFederation>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.ListOfExecutiveCommitteesOfWomensFederation.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.ListOfExecutiveCommitteesOfWomensFederation.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.LOECOWFSerialNumber = HttpUtility.UrlDecode(entity.LOECOWFSerialNumber);
					// NVARCHAR(50)
				entity.LOECOWFFullName = HttpUtility.UrlDecode(entity.LOECOWFFullName);
					// NVARCHAR(50)
				entity.LOECOWFDateOfBirth = HttpUtility.UrlDecode(entity.LOECOWFDateOfBirth);
					// NVARCHAR(50)
				entity.LOECOWFPost = HttpUtility.UrlDecode(entity.LOECOWFPost);
					// NVARCHAR(50)
				entity.LOECOWFNature = HttpUtility.UrlDecode(entity.LOECOWFNature);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.ListOfExecutiveCommitteesOfWomensFederation.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条ListOfExecutiveCommitteesOfWomensFederation记录";
    }
	
    /// <summary>
    /// 查询空的【妇联执委名单】
    /// </summary>
    public partial class GetListOfExecutiveCommitteesOfWomensFederationEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new ListOfExecutiveCommitteesOfWomensFederation();
        }
        public override string Comments=> "获取空的妇联执委名单记录";
    }
	
    /// <summary>
    /// 查询【妇联执委名单】列表
    /// </summary>
    public partial class GetListOfExecutiveCommitteesOfWomensFederationListEvaluator : Evaluator
    {
        public override string Comments=> "获取ListOfExecutiveCommitteesOfWomensFederation列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<ListOfExecutiveCommitteesOfWomensFederationSearchModel>() ?? new ListOfExecutiveCommitteesOfWomensFederationSearchModel();
                var query = ctx.ListOfExecutiveCommitteesOfWomensFederation.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// LOECOWFSerialNumber NVARCHAR(50) 序号 
                if(!string.IsNullOrEmpty(searchModel.LOECOWFSerialNumber)) query = query.Where(t=>t.LOECOWFSerialNumber.Contains(searchModel.LOECOWFSerialNumber));
                if(sort=="LOECOWFSerialNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOECOWFSerialNumber):query.OrderByDescending(t=>t.LOECOWFSerialNumber);
                    isordered = true;
                }
				// LOECOWFFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.LOECOWFFullName)) query = query.Where(t=>t.LOECOWFFullName.Contains(searchModel.LOECOWFFullName));
                if(sort=="LOECOWFFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOECOWFFullName):query.OrderByDescending(t=>t.LOECOWFFullName);
                    isordered = true;
                }
				// LOECOWFDateOfBirth NVARCHAR(50) 出生年月 
                if(!string.IsNullOrEmpty(searchModel.LOECOWFDateOfBirth)) query = query.Where(t=>t.LOECOWFDateOfBirth.Contains(searchModel.LOECOWFDateOfBirth));
                if(sort=="LOECOWFDateOfBirth")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOECOWFDateOfBirth):query.OrderByDescending(t=>t.LOECOWFDateOfBirth);
                    isordered = true;
                }
				// LOECOWFPost NVARCHAR(50) 职务 
                if(!string.IsNullOrEmpty(searchModel.LOECOWFPost)) query = query.Where(t=>t.LOECOWFPost.Contains(searchModel.LOECOWFPost));
                if(sort=="LOECOWFPost")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOECOWFPost):query.OrderByDescending(t=>t.LOECOWFPost);
                    isordered = true;
                }
				// LOECOWFNature NVARCHAR(50) 性质 
                if(!string.IsNullOrEmpty(searchModel.LOECOWFNature)) query = query.Where(t=>t.LOECOWFNature.Contains(searchModel.LOECOWFNature));
                if(sort=="LOECOWFNature")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.LOECOWFNature):query.OrderByDescending(t=>t.LOECOWFNature);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.LOECOWFSerialNumber.Contains(search)||t.LOECOWFFullName.Contains(search)||t.LOECOWFDateOfBirth.Contains(search)||t.LOECOWFPost.Contains(search)||t.LOECOWFNature.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<ListOfExecutiveCommitteesOfWomensFederation>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【资产】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class AssetsCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Assets.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【资产】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【资产】
    /// </summary>
    public partial class DeleteAssetsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Assets>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Assets.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Assets.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条资产记录";
    }
	
    /// <summary>
    /// 保存【资产】
    /// </summary>
    public partial class SaveAssetsEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Assets>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Assets.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Assets.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.AAssetNumber = HttpUtility.UrlDecode(entity.AAssetNumber);
					// NVARCHAR(50)
				entity.AAssetName = HttpUtility.UrlDecode(entity.AAssetName);
					// NVARCHAR(50)
				entity.AAssetClass = HttpUtility.UrlDecode(entity.AAssetClass);
					// NVARCHAR(50)
				entity.AAccountingSubjects = HttpUtility.UrlDecode(entity.AAccountingSubjects);
					// NVARCHAR(50)
				entity.ASubordinateUnit = HttpUtility.UrlDecode(entity.ASubordinateUnit);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Assets.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Assets记录";
    }
	
    /// <summary>
    /// 查询空的【资产】
    /// </summary>
    public partial class GetAssetsEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Assets();
        }
        public override string Comments=> "获取空的资产记录";
    }
	
    /// <summary>
    /// 查询【资产】列表
    /// </summary>
    public partial class GetAssetsListEvaluator : Evaluator
    {
        public override string Comments=> "获取Assets列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<AssetsSearchModel>() ?? new AssetsSearchModel();
                var query = ctx.Assets.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// AAssetNumber NVARCHAR(50) 资产编号 
                if(!string.IsNullOrEmpty(searchModel.AAssetNumber)) query = query.Where(t=>t.AAssetNumber.Contains(searchModel.AAssetNumber));
                if(sort=="AAssetNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AAssetNumber):query.OrderByDescending(t=>t.AAssetNumber);
                    isordered = true;
                }
				// AAssetName NVARCHAR(50) 资产名称 
                if(!string.IsNullOrEmpty(searchModel.AAssetName)) query = query.Where(t=>t.AAssetName.Contains(searchModel.AAssetName));
                if(sort=="AAssetName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AAssetName):query.OrderByDescending(t=>t.AAssetName);
                    isordered = true;
                }
				// AAssetClass NVARCHAR(50) 资产类别 
                if(!string.IsNullOrEmpty(searchModel.AAssetClass)) query = query.Where(t=>t.AAssetClass.Contains(searchModel.AAssetClass));
                if(sort=="AAssetClass")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AAssetClass):query.OrderByDescending(t=>t.AAssetClass);
                    isordered = true;
                }
				// AAccountingSubjects NVARCHAR(50) 会计科目 
                if(!string.IsNullOrEmpty(searchModel.AAccountingSubjects)) query = query.Where(t=>t.AAccountingSubjects.Contains(searchModel.AAccountingSubjects));
                if(sort=="AAccountingSubjects")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.AAccountingSubjects):query.OrderByDescending(t=>t.AAccountingSubjects);
                    isordered = true;
                }
				// ASubordinateUnit NVARCHAR(50) 所属单位 
                if(!string.IsNullOrEmpty(searchModel.ASubordinateUnit)) query = query.Where(t=>t.ASubordinateUnit.Contains(searchModel.ASubordinateUnit));
                if(sort=="ASubordinateUnit")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ASubordinateUnit):query.OrderByDescending(t=>t.ASubordinateUnit);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.AAssetNumber.Contains(search)||t.AAssetName.Contains(search)||t.AAssetClass.Contains(search)||t.AAccountingSubjects.Contains(search)||t.ASubordinateUnit.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Assets>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【监护人】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class GuardianCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Guardian.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【监护人】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【监护人】
    /// </summary>
    public partial class DeleteGuardianEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Guardian>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Guardian.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Guardian.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条监护人记录";
    }
	
    /// <summary>
    /// 保存【监护人】
    /// </summary>
    public partial class SaveGuardianEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Guardian>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Guardian.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Guardian.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.GFullName = HttpUtility.UrlDecode(entity.GFullName);
					// NVARCHAR(50)
				entity.GGender = HttpUtility.UrlDecode(entity.GGender);
					// NVARCHAR(50)
				entity.GContactNumber = HttpUtility.UrlDecode(entity.GContactNumber);
					// NVARCHAR(50)
				entity.GLocationOfHouseholdRegistration = HttpUtility.UrlDecode(entity.GLocationOfHouseholdRegistration);
					// NVARCHAR(50)
				entity.GLocation = HttpUtility.UrlDecode(entity.GLocation);
					// NVARCHAR(4000)
				entity.GDetailedAddress = HttpUtility.UrlDecode(entity.GDetailedAddress);
					// NVARCHAR(50)
				entity.GPlaceOfResidence = HttpUtility.UrlDecode(entity.GPlaceOfResidence);
					// NVARCHAR(50)
				entity.GSubmitter = HttpUtility.UrlDecode(entity.GSubmitter);
					// NVARCHAR(50)
				entity.GAuthorsTelephoneNumber = HttpUtility.UrlDecode(entity.GAuthorsTelephoneNumber);
					// NVARCHAR(50)
				entity.GPositiveAndNegativeSideOfSocialSecurityCard = HttpUtility.UrlDecode(entity.GPositiveAndNegativeSideOfSocialSecurityCard);
					// NVARCHAR(4000)
				entity.GThePositiveAndNegativeSidesOfGuardiansIdentityCard = HttpUtility.UrlDecode(entity.GThePositiveAndNegativeSidesOfGuardiansIdentityCard);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Guardian.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Guardian记录";
    }
	
    /// <summary>
    /// 查询空的【监护人】
    /// </summary>
    public partial class GetGuardianEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Guardian();
        }
        public override string Comments=> "获取空的监护人记录";
    }
	
    /// <summary>
    /// 查询【监护人】列表
    /// </summary>
    public partial class GetGuardianListEvaluator : Evaluator
    {
        public override string Comments=> "获取Guardian列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<GuardianSearchModel>() ?? new GuardianSearchModel();
                var query = ctx.Guardian.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// GFullName NVARCHAR(50) 姓名 
                if(!string.IsNullOrEmpty(searchModel.GFullName)) query = query.Where(t=>t.GFullName.Contains(searchModel.GFullName));
                if(sort=="GFullName")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GFullName):query.OrderByDescending(t=>t.GFullName);
                    isordered = true;
                }
				// GGender NVARCHAR(50) 性别 
                if(!string.IsNullOrEmpty(searchModel.GGender)) query = query.Where(t=>t.GGender.Contains(searchModel.GGender));
                if(sort=="GGender")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GGender):query.OrderByDescending(t=>t.GGender);
                    isordered = true;
                }
				// GContactNumber NVARCHAR(50) 联系电话 
                if(!string.IsNullOrEmpty(searchModel.GContactNumber)) query = query.Where(t=>t.GContactNumber.Contains(searchModel.GContactNumber));
                if(sort=="GContactNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GContactNumber):query.OrderByDescending(t=>t.GContactNumber);
                    isordered = true;
                }
				// GLocationOfHouseholdRegistration NVARCHAR(50) 户籍所在地 
                if(!string.IsNullOrEmpty(searchModel.GLocationOfHouseholdRegistration)) query = query.Where(t=>t.GLocationOfHouseholdRegistration.Contains(searchModel.GLocationOfHouseholdRegistration));
                if(sort=="GLocationOfHouseholdRegistration")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GLocationOfHouseholdRegistration):query.OrderByDescending(t=>t.GLocationOfHouseholdRegistration);
                    isordered = true;
                }
				// GLocation NVARCHAR(50) 所在地区 
                if(!string.IsNullOrEmpty(searchModel.GLocation)) query = query.Where(t=>t.GLocation.Contains(searchModel.GLocation));
                if(sort=="GLocation")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GLocation):query.OrderByDescending(t=>t.GLocation);
                    isordered = true;
                }
				// GDetailedAddress NVARCHAR(4000) 详细地址 
                if(!string.IsNullOrEmpty(searchModel.GDetailedAddress)) query = query.Where(t=>t.GDetailedAddress.Contains(searchModel.GDetailedAddress));
                if(sort=="GDetailedAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GDetailedAddress):query.OrderByDescending(t=>t.GDetailedAddress);
                    isordered = true;
                }
				// GPlaceOfResidence NVARCHAR(50) 居住地 
                if(!string.IsNullOrEmpty(searchModel.GPlaceOfResidence)) query = query.Where(t=>t.GPlaceOfResidence.Contains(searchModel.GPlaceOfResidence));
                if(sort=="GPlaceOfResidence")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GPlaceOfResidence):query.OrderByDescending(t=>t.GPlaceOfResidence);
                    isordered = true;
                }
				// GSubmitter NVARCHAR(50) 提交人 
                if(!string.IsNullOrEmpty(searchModel.GSubmitter)) query = query.Where(t=>t.GSubmitter.Contains(searchModel.GSubmitter));
                if(sort=="GSubmitter")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GSubmitter):query.OrderByDescending(t=>t.GSubmitter);
                    isordered = true;
                }
				// GAuthorsTelephoneNumber NVARCHAR(50) 提交人电话 
                if(!string.IsNullOrEmpty(searchModel.GAuthorsTelephoneNumber)) query = query.Where(t=>t.GAuthorsTelephoneNumber.Contains(searchModel.GAuthorsTelephoneNumber));
                if(sort=="GAuthorsTelephoneNumber")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GAuthorsTelephoneNumber):query.OrderByDescending(t=>t.GAuthorsTelephoneNumber);
                    isordered = true;
                }
				// GPositiveAndNegativeSideOfSocialSecurityCard NVARCHAR(50) 社保卡正反面 
                if(!string.IsNullOrEmpty(searchModel.GPositiveAndNegativeSideOfSocialSecurityCard)) query = query.Where(t=>t.GPositiveAndNegativeSideOfSocialSecurityCard.Contains(searchModel.GPositiveAndNegativeSideOfSocialSecurityCard));
                if(sort=="GPositiveAndNegativeSideOfSocialSecurityCard")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GPositiveAndNegativeSideOfSocialSecurityCard):query.OrderByDescending(t=>t.GPositiveAndNegativeSideOfSocialSecurityCard);
                    isordered = true;
                }
				// GThePositiveAndNegativeSidesOfGuardiansIdentityCard NVARCHAR(4000) 监护人身份证正反面 
                if(!string.IsNullOrEmpty(searchModel.GThePositiveAndNegativeSidesOfGuardiansIdentityCard)) query = query.Where(t=>t.GThePositiveAndNegativeSidesOfGuardiansIdentityCard.Contains(searchModel.GThePositiveAndNegativeSidesOfGuardiansIdentityCard));
                if(sort=="GThePositiveAndNegativeSidesOfGuardiansIdentityCard")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.GThePositiveAndNegativeSidesOfGuardiansIdentityCard):query.OrderByDescending(t=>t.GThePositiveAndNegativeSidesOfGuardiansIdentityCard);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.GFullName.Contains(search)||t.GGender.Contains(search)||t.GContactNumber.Contains(search)||t.GLocationOfHouseholdRegistration.Contains(search)||t.GLocation.Contains(search)||t.GDetailedAddress.Contains(search)||t.GPlaceOfResidence.Contains(search)||t.GSubmitter.Contains(search)||t.GAuthorsTelephoneNumber.Contains(search)||t.GPositiveAndNegativeSideOfSocialSecurityCard.Contains(search)||t.GThePositiveAndNegativeSidesOfGuardiansIdentityCard.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Guardian>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }


    /// <summary>
    /// 【照片】7次查询分别得到七天内记录的条数，形成柱状图，折线图
    /// </summary>
    public partial class PhotoCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var now = Parse(request.context.Request.Params["date"] ?? Now.ToString("yyyy-MM-dd"));
                var dates = Range(1, 7).Select(p => now.AddDays(-1 * p)).ToList();
                var list = dates.Select(p => ctx.Photo.Count(m => m.CreateOn==p)).ToList();
                return new
                {
                    sum = list.Sum(),
                    xaxis = dates.Select(p => p.ToString("yyyy-MM-dd")).ToList(),
                    series = list
                };
            }
        }
        public override string Comments=> "【照片】7次查询分别得到七天内记录的条数，形成柱状图，折线图";
    }
	
    /// <summary>
    /// 删除【照片】
    /// </summary>
    public partial class DeletePhotoEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<Photo>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除成功"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.Photo.Find(data.id);
				if(one==null){
					return new CommonOutputT<string>
					{
						success = false,
						message = "未找到需要删除的数据"
					};
				}
                one.IsDeleted = 1;
				ctx.Photo.AddOrUpdate(one);
				ctx.SaveChanges();
				return new CommonOutputT<string>
				{
					success = true,
					message = "删除成功"
				};
            }
			
        }
        public override string Comments=> "删除一条照片记录";
    }
	
    /// <summary>
    /// 保存【照片】
    /// </summary>
    public partial class SavePhotoEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            if (user==null)
            {
                return new
                {
                    success = false,
                    message = "请登录"
                };
            }
            using (var ctx = new DefaultContext())
            {
				var s = request.data;
				var entity = JsonConvert.DeserializeObject<Photo>(s);
				// 行级排他锁开始
                var transactionId = Guid.NewGuid().ToString();
                var isnew = entity.id == null;
                if (!isnew)
                {
                    var one = ctx.Photo.FirstOrDefault(p=>p.id==entity.id);
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
					ctx.Photo.AddOrUpdate(one);
                    ctx.SaveChanges();
                    entity.VersionNo = one.VersionNo;
                }
				

								// NVARCHAR(50)
				entity.PCategory = HttpUtility.UrlDecode(entity.PCategory);
					// NVARCHAR(50)
				entity.PUrl = HttpUtility.UrlDecode(entity.PUrl);
					// NVARCHAR(4000)
				entity.PPhysicalAddress = HttpUtility.UrlDecode(entity.PPhysicalAddress);
					// NVARCHAR(50)
				entity.PTheReverseSideOfSocialSecurityCard = HttpUtility.UrlDecode(entity.PTheReverseSideOfSocialSecurityCard);
					// NVARCHAR(50)
				entity.PFrontOfSocialSecurityCard = HttpUtility.UrlDecode(entity.PFrontOfSocialSecurityCard);
					// NVARCHAR(4000)
				entity.PTheFrontOfGuardiansIdCard = HttpUtility.UrlDecode(entity.PTheFrontOfGuardiansIdCard);
					// NVARCHAR(4000)
				entity.PTheReverseOfGuardiansIdentityCard = HttpUtility.UrlDecode(entity.PTheReverseOfGuardiansIdentityCard);
					// NVARCHAR(50)
				entity.POther = HttpUtility.UrlDecode(entity.POther);
	
                entity.id = entity.id ?? Guid.NewGuid().ToString();
                entity.CreateBy = entity.CreateBy ?? user?.UILoginName ?? "未登录用户";
                entity.UpdateBy = user?.UILoginName ?? "未登录用户";
                entity.CreateOn = entity.CreateOn ?? Now;
                entity.TransactionID = transactionId;
                entity.UpdateOn = Now;
                entity.IsDeleted = 0;
                entity.DataLevel = user?.DataLevel ?? "01";
				ctx.Photo.AddOrUpdate(entity);
                ctx.SaveChanges();
				// 行级排他锁结束
                return new
                {
                    success = true,
                    message = "操作成功"
                };
            }
        }
        public override string Comments=> "保存一条Photo记录";
    }
	
    /// <summary>
    /// 查询空的【照片】
    /// </summary>
    public partial class GetPhotoEmptyEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new Photo();
        }
        public override string Comments=> "获取空的照片记录";
    }
	
    /// <summary>
    /// 查询【照片】列表
    /// </summary>
    public partial class GetPhotoListEvaluator : Evaluator
    {
        public override string Comments=> "获取Photo列表 ";
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
				var datalevel = CurrentUserInformation?.DataLevel;
                var searchModel = request.data.Deserialize<PhotoSearchModel>() ?? new PhotoSearchModel();
                var query = ctx.Photo.Where(t=>t.IsDeleted==0 && t.DataLevel.StartsWith(datalevel));
                var @params = request.context.Request.Params;
                searchModel.PageSize = (@params["limit"] ?? searchModel.PageSize.ToString()).ToInt();
				searchModel.PageSize = searchModel.PageSize==0?4000:searchModel.PageSize;
                searchModel.PageIndex = (@params["offset"]).ToInt()/ searchModel.PageSize;
                var isordered = false;
                var search = searchModel.SearchKey ?? @params["search"];
                var sort = searchModel.Sort ?? @params["sort"];
				// PCategory NVARCHAR(50) 类别 
                if(!string.IsNullOrEmpty(searchModel.PCategory)) query = query.Where(t=>t.PCategory.Contains(searchModel.PCategory));
                if(sort=="PCategory")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PCategory):query.OrderByDescending(t=>t.PCategory);
                    isordered = true;
                }
				// PUrl NVARCHAR(50) url 
                if(!string.IsNullOrEmpty(searchModel.PUrl)) query = query.Where(t=>t.PUrl.Contains(searchModel.PUrl));
                if(sort=="PUrl")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PUrl):query.OrderByDescending(t=>t.PUrl);
                    isordered = true;
                }
				// PPhysicalAddress NVARCHAR(4000) 物理地址 
                if(!string.IsNullOrEmpty(searchModel.PPhysicalAddress)) query = query.Where(t=>t.PPhysicalAddress.Contains(searchModel.PPhysicalAddress));
                if(sort=="PPhysicalAddress")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PPhysicalAddress):query.OrderByDescending(t=>t.PPhysicalAddress);
                    isordered = true;
                }
				// PTheReverseSideOfSocialSecurityCard NVARCHAR(50) 社保卡反面 
                if(!string.IsNullOrEmpty(searchModel.PTheReverseSideOfSocialSecurityCard)) query = query.Where(t=>t.PTheReverseSideOfSocialSecurityCard.Contains(searchModel.PTheReverseSideOfSocialSecurityCard));
                if(sort=="PTheReverseSideOfSocialSecurityCard")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTheReverseSideOfSocialSecurityCard):query.OrderByDescending(t=>t.PTheReverseSideOfSocialSecurityCard);
                    isordered = true;
                }
				// PFrontOfSocialSecurityCard NVARCHAR(50) 社保卡正面 
                if(!string.IsNullOrEmpty(searchModel.PFrontOfSocialSecurityCard)) query = query.Where(t=>t.PFrontOfSocialSecurityCard.Contains(searchModel.PFrontOfSocialSecurityCard));
                if(sort=="PFrontOfSocialSecurityCard")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PFrontOfSocialSecurityCard):query.OrderByDescending(t=>t.PFrontOfSocialSecurityCard);
                    isordered = true;
                }
				// PTheFrontOfGuardiansIdCard NVARCHAR(4000) 监护人身份证正面 
                if(!string.IsNullOrEmpty(searchModel.PTheFrontOfGuardiansIdCard)) query = query.Where(t=>t.PTheFrontOfGuardiansIdCard.Contains(searchModel.PTheFrontOfGuardiansIdCard));
                if(sort=="PTheFrontOfGuardiansIdCard")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTheFrontOfGuardiansIdCard):query.OrderByDescending(t=>t.PTheFrontOfGuardiansIdCard);
                    isordered = true;
                }
				// PTheReverseOfGuardiansIdentityCard NVARCHAR(4000) 监护人身份证反面 
                if(!string.IsNullOrEmpty(searchModel.PTheReverseOfGuardiansIdentityCard)) query = query.Where(t=>t.PTheReverseOfGuardiansIdentityCard.Contains(searchModel.PTheReverseOfGuardiansIdentityCard));
                if(sort=="PTheReverseOfGuardiansIdentityCard")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.PTheReverseOfGuardiansIdentityCard):query.OrderByDescending(t=>t.PTheReverseOfGuardiansIdentityCard);
                    isordered = true;
                }
				// POther NVARCHAR(50) 其他 
                if(!string.IsNullOrEmpty(searchModel.POther)) query = query.Where(t=>t.POther.Contains(searchModel.POther));
                if(sort=="POther")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.POther):query.OrderByDescending(t=>t.POther);
                    isordered = true;
                }
				if(!string.IsNullOrEmpty(search)){
					query = query.Where(t=>t.id.Contains(search)||t.PCategory.Contains(search)||t.PUrl.Contains(search)||t.PPhysicalAddress.Contains(search)||t.PTheReverseSideOfSocialSecurityCard.Contains(search)||t.PFrontOfSocialSecurityCard.Contains(search)||t.PTheFrontOfGuardiansIdCard.Contains(search)||t.PTheReverseOfGuardiansIdentityCard.Contains(search)||t.POther.Contains(search));
				}
                if(sort=="ord")
                {
					query = @params["order"]=="asc"?query.OrderBy(t=>t.ord):query.OrderByDescending(t=>t.ord);
                    isordered = true;
                }

                if(!isordered) query = query.OrderByDescending(t=>t.UpdateOn);
                var rows = query.Skip((searchModel.PageIndex)*searchModel.PageSize).Take(searchModel.PageSize).ToList();
                var total = query.Count();
                var sql = query.ToString();
                return new CommonOutputList<Photo>
                {
                    success = true, rows = rows, total = total, message="查询成功"
                };
            }
        }
    }

}
