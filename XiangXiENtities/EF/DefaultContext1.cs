  

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;

namespace XiangXiENtities.EF
{
    public class DefaultContext : DbContext
    {
	
#if DEBUG
        public DefaultContext():base("LocalDefaultContext")
        {
            
        }
#elif RELEASE
        
#endif

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultContext, Configuration>());
        }
        static DefaultContext()
        {
            using (var ctx = new DefaultContext())
            {
                ctx.BuildMenu();
            }
        }

		public void BuildMenu()
		{
            var TransactionID = Guid.NewGuid().ToString();
            var CreateBy = "Initialization Job";
            var UIPassword = "123";
            if(!UserInformation.Any(t => t.UILoginName == "public"))UserInformation.Add(new XiangXiENtities.EF.NewEntities.UserInformation { CreateBy = CreateBy, TransactionID = TransactionID, IsDeleted = 0, id = Guid.NewGuid().ToString(), UILoginName = "public", UISubordinateDepartments = "公众", UIPassword = UIPassword, DataLevel = "019999" });

			
			if (!MenuConfiguration.Any(t => t.MCTitle == "菜单配置"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "菜单配置",
					MCLink = "/XiangXi/gen/MenuConfigurationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "菜单配置统计",
					MCLink = "/XiangXi/gen/MenuConfigurationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var menuconfiguration = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "菜单配置");
			if(menuconfiguration!=null)
			{
				menuconfiguration.MCLink = "/XiangXi/gen/MenuConfigurationList.html";
				MenuConfiguration.AddOrUpdate(menuconfiguration);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "角色菜单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "角色菜单",
					MCLink = "/XiangXi/gen/RoleMenuList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "角色菜单统计",
					MCLink = "/XiangXi/gen/RoleMenuAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var rolemenu = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "角色菜单");
			if(rolemenu!=null)
			{
				rolemenu.MCLink = "/XiangXi/gen/RoleMenuList.html";
				MenuConfiguration.AddOrUpdate(rolemenu);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "用户角色"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "用户角色",
					MCLink = "/XiangXi/gen/UserRolesList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "用户角色统计",
					MCLink = "/XiangXi/gen/UserRolesAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var userroles = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "用户角色");
			if(userroles!=null)
			{
				userroles.MCLink = "/XiangXi/gen/UserRolesList.html";
				MenuConfiguration.AddOrUpdate(userroles);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "角色配置"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "角色配置",
					MCLink = "/XiangXi/gen/RoleConfigurationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "角色配置统计",
					MCLink = "/XiangXi/gen/RoleConfigurationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var roleconfiguration = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "角色配置");
			if(roleconfiguration!=null)
			{
				roleconfiguration.MCLink = "/XiangXi/gen/RoleConfigurationList.html";
				MenuConfiguration.AddOrUpdate(roleconfiguration);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "用户信息"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "用户信息",
					MCLink = "/XiangXi/gen/UserInformationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "用户信息统计",
					MCLink = "/XiangXi/gen/UserInformationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var userinformation = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "用户信息");
			if(userinformation!=null)
			{
				userinformation.MCLink = "/XiangXi/gen/UserInformationList.html";
				MenuConfiguration.AddOrUpdate(userinformation);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "登录记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "登录记录",
					MCLink = "/XiangXi/gen/LoginRecordList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "登录记录统计",
					MCLink = "/XiangXi/gen/LoginRecordAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var loginrecord = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "登录记录");
			if(loginrecord!=null)
			{
				loginrecord.MCLink = "/XiangXi/gen/LoginRecordList.html";
				MenuConfiguration.AddOrUpdate(loginrecord);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "用户菜单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "用户菜单",
					MCLink = "/XiangXi/gen/UserMenuList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "用户菜单统计",
					MCLink = "/XiangXi/gen/UserMenuAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var usermenu = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "用户菜单");
			if(usermenu!=null)
			{
				usermenu.MCLink = "/XiangXi/gen/UserMenuList.html";
				MenuConfiguration.AddOrUpdate(usermenu);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党员信息管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党员信息管理",
					MCLink = "/XiangXi/gen/InformationManagementOfPartyMembersList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党员信息管理统计",
					MCLink = "/XiangXi/gen/InformationManagementOfPartyMembersAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var informationmanagementofpartymembers = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党员信息管理");
			if(informationmanagementofpartymembers!=null)
			{
				informationmanagementofpartymembers.MCLink = "/XiangXi/gen/InformationManagementOfPartyMembersList.html";
				MenuConfiguration.AddOrUpdate(informationmanagementofpartymembers);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党费管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党费管理",
					MCLink = "/XiangXi/gen/PartyFeeManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党费管理统计",
					MCLink = "/XiangXi/gen/PartyFeeManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var partyfeemanagement = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党费管理");
			if(partyfeemanagement!=null)
			{
				partyfeemanagement.MCLink = "/XiangXi/gen/PartyFeeManagementList.html";
				MenuConfiguration.AddOrUpdate(partyfeemanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党课记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党课记录",
					MCLink = "/XiangXi/gen/PartyRecordList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党课记录统计",
					MCLink = "/XiangXi/gen/PartyRecordAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var partyrecord = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党课记录");
			if(partyrecord!=null)
			{
				partyrecord.MCLink = "/XiangXi/gen/PartyRecordList.html";
				MenuConfiguration.AddOrUpdate(partyrecord);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "三会一课"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "三会一课",
					MCLink = "/XiangXi/gen/ThreeSessionsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "三会一课统计",
					MCLink = "/XiangXi/gen/ThreeSessionsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var threesessions = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "三会一课");
			if(threesessions!=null)
			{
				threesessions.MCLink = "/XiangXi/gen/ThreeSessionsList.html";
				MenuConfiguration.AddOrUpdate(threesessions);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "专题学习"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "专题学习",
					MCLink = "/XiangXi/gen/ThematicLearningList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "专题学习统计",
					MCLink = "/XiangXi/gen/ThematicLearningAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var thematiclearning = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "专题学习");
			if(thematiclearning!=null)
			{
				thematiclearning.MCLink = "/XiangXi/gen/ThematicLearningList.html";
				MenuConfiguration.AddOrUpdate(thematiclearning);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "政策文件"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "政策文件",
					MCLink = "/XiangXi/gen/PolicyDocumentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "政策文件统计",
					MCLink = "/XiangXi/gen/PolicyDocumentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var policydocument = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "政策文件");
			if(policydocument!=null)
			{
				policydocument.MCLink = "/XiangXi/gen/PolicyDocumentList.html";
				MenuConfiguration.AddOrUpdate(policydocument);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "政策文件类别"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "政策文件类别",
					MCLink = "/XiangXi/gen/CategoriesOfPolicyDocumentsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "政策文件类别统计",
					MCLink = "/XiangXi/gen/CategoriesOfPolicyDocumentsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var categoriesofpolicydocuments = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "政策文件类别");
			if(categoriesofpolicydocuments!=null)
			{
				categoriesofpolicydocuments.MCLink = "/XiangXi/gen/CategoriesOfPolicyDocumentsList.html";
				MenuConfiguration.AddOrUpdate(categoriesofpolicydocuments);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "现役军人名单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "现役军人名单",
					MCLink = "/XiangXi/gen/ListOfActiveServicemenList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "现役军人名单统计",
					MCLink = "/XiangXi/gen/ListOfActiveServicemenAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var listofactiveservicemen = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "现役军人名单");
			if(listofactiveservicemen!=null)
			{
				listofactiveservicemen.MCLink = "/XiangXi/gen/ListOfActiveServicemenList.html";
				MenuConfiguration.AddOrUpdate(listofactiveservicemen);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "征兵对象名单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "征兵对象名单",
					MCLink = "/XiangXi/gen/ListOfConscriptsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "征兵对象名单统计",
					MCLink = "/XiangXi/gen/ListOfConscriptsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var listofconscripts = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "征兵对象名单");
			if(listofconscripts!=null)
			{
				listofconscripts.MCLink = "/XiangXi/gen/ListOfConscriptsList.html";
				MenuConfiguration.AddOrUpdate(listofconscripts);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "共青团"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "共青团",
					MCLink = "/XiangXi/gen/CommunistYouthLeagueList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "共青团统计",
					MCLink = "/XiangXi/gen/CommunistYouthLeagueAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var communistyouthleague = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "共青团");
			if(communistyouthleague!=null)
			{
				communistyouthleague.MCLink = "/XiangXi/gen/CommunistYouthLeagueList.html";
				MenuConfiguration.AddOrUpdate(communistyouthleague);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "重点人员"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "重点人员",
					MCLink = "/XiangXi/gen/KeyPersonnelList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "重点人员统计",
					MCLink = "/XiangXi/gen/KeyPersonnelAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var keypersonnel = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "重点人员");
			if(keypersonnel!=null)
			{
				keypersonnel.MCLink = "/XiangXi/gen/KeyPersonnelList.html";
				MenuConfiguration.AddOrUpdate(keypersonnel);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "信访"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "信访",
					MCLink = "/XiangXi/gen/LettersAndVisitsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "信访统计",
					MCLink = "/XiangXi/gen/LettersAndVisitsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var lettersandvisits = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "信访");
			if(lettersandvisits!=null)
			{
				lettersandvisits.MCLink = "/XiangXi/gen/LettersAndVisitsList.html";
				MenuConfiguration.AddOrUpdate(lettersandvisits);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "两类人员"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "两类人员",
					MCLink = "/XiangXi/gen/TheTwoCategoryOfPersonnelList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "两类人员统计",
					MCLink = "/XiangXi/gen/TheTwoCategoryOfPersonnelAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var thetwocategoryofpersonnel = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "两类人员");
			if(thetwocategoryofpersonnel!=null)
			{
				thetwocategoryofpersonnel.MCLink = "/XiangXi/gen/TheTwoCategoryOfPersonnelList.html";
				MenuConfiguration.AddOrUpdate(thetwocategoryofpersonnel);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "家庭"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "家庭",
					MCLink = "/XiangXi/gen/FamilyList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "家庭统计",
					MCLink = "/XiangXi/gen/FamilyAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var family = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "家庭");
			if(family!=null)
			{
				family.MCLink = "/XiangXi/gen/FamilyList.html";
				MenuConfiguration.AddOrUpdate(family);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "股民"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "股民",
					MCLink = "/XiangXi/gen/InvestorsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "股民统计",
					MCLink = "/XiangXi/gen/InvestorsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var investors = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "股民");
			if(investors!=null)
			{
				investors.MCLink = "/XiangXi/gen/InvestorsList.html";
				MenuConfiguration.AddOrUpdate(investors);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "分红记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "分红记录",
					MCLink = "/XiangXi/gen/BonusRecordList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "分红记录统计",
					MCLink = "/XiangXi/gen/BonusRecordAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var bonusrecord = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "分红记录");
			if(bonusrecord!=null)
			{
				bonusrecord.MCLink = "/XiangXi/gen/BonusRecordList.html";
				MenuConfiguration.AddOrUpdate(bonusrecord);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "干部"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "干部",
					MCLink = "/XiangXi/gen/CadreList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "干部统计",
					MCLink = "/XiangXi/gen/CadreAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var cadre = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "干部");
			if(cadre!=null)
			{
				cadre.MCLink = "/XiangXi/gen/CadreList.html";
				MenuConfiguration.AddOrUpdate(cadre);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "民兵"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "民兵",
					MCLink = "/XiangXi/gen/MilitiaList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "民兵统计",
					MCLink = "/XiangXi/gen/MilitiaAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var militia = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "民兵");
			if(militia!=null)
			{
				militia.MCLink = "/XiangXi/gen/MilitiaList.html";
				MenuConfiguration.AddOrUpdate(militia);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "统战民兵"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "统战民兵",
					MCLink = "/XiangXi/gen/UnitedFrontMilitiaList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "统战民兵统计",
					MCLink = "/XiangXi/gen/UnitedFrontMilitiaAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var unitedfrontmilitia = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "统战民兵");
			if(unitedfrontmilitia!=null)
			{
				unitedfrontmilitia.MCLink = "/XiangXi/gen/UnitedFrontMilitiaList.html";
				MenuConfiguration.AddOrUpdate(unitedfrontmilitia);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "厂房楼栋"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "厂房楼栋",
					MCLink = "/XiangXi/gen/FactoryBuildingList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "厂房楼栋统计",
					MCLink = "/XiangXi/gen/FactoryBuildingAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var factorybuilding = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "厂房楼栋");
			if(factorybuilding!=null)
			{
				factorybuilding.MCLink = "/XiangXi/gen/FactoryBuildingList.html";
				MenuConfiguration.AddOrUpdate(factorybuilding);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "收租记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "收租记录",
					MCLink = "/XiangXi/gen/RentCollectionRecordsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "收租记录统计",
					MCLink = "/XiangXi/gen/RentCollectionRecordsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var rentcollectionrecords = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "收租记录");
			if(rentcollectionrecords!=null)
			{
				rentcollectionrecords.MCLink = "/XiangXi/gen/RentCollectionRecordsList.html";
				MenuConfiguration.AddOrUpdate(rentcollectionrecords);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "电费缴纳记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "电费缴纳记录",
					MCLink = "/XiangXi/gen/ElectricityChargePaymentRecordList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "电费缴纳记录统计",
					MCLink = "/XiangXi/gen/ElectricityChargePaymentRecordAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var electricitychargepaymentrecord = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "电费缴纳记录");
			if(electricitychargepaymentrecord!=null)
			{
				electricitychargepaymentrecord.MCLink = "/XiangXi/gen/ElectricityChargePaymentRecordList.html";
				MenuConfiguration.AddOrUpdate(electricitychargepaymentrecord);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "工作日志"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "工作日志",
					MCLink = "/XiangXi/gen/JobDiaryList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "工作日志统计",
					MCLink = "/XiangXi/gen/JobDiaryAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var jobdiary = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "工作日志");
			if(jobdiary!=null)
			{
				jobdiary.MCLink = "/XiangXi/gen/JobDiaryList.html";
				MenuConfiguration.AddOrUpdate(jobdiary);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "通知"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "通知",
					MCLink = "/XiangXi/gen/NoticeList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "通知统计",
					MCLink = "/XiangXi/gen/NoticeAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var notice = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "通知");
			if(notice!=null)
			{
				notice.MCLink = "/XiangXi/gen/NoticeList.html";
				MenuConfiguration.AddOrUpdate(notice);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "文档管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "文档管理",
					MCLink = "/XiangXi/gen/DocumentManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "文档管理统计",
					MCLink = "/XiangXi/gen/DocumentManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var documentmanagement = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "文档管理");
			if(documentmanagement!=null)
			{
				documentmanagement.MCLink = "/XiangXi/gen/DocumentManagementList.html";
				MenuConfiguration.AddOrUpdate(documentmanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "人口"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "人口",
					MCLink = "/XiangXi/gen/PopulationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "人口统计",
					MCLink = "/XiangXi/gen/PopulationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var population = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "人口");
			if(population!=null)
			{
				population.MCLink = "/XiangXi/gen/PopulationList.html";
				MenuConfiguration.AddOrUpdate(population);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "新生儿"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "新生儿",
					MCLink = "/XiangXi/gen/NewbornList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "新生儿统计",
					MCLink = "/XiangXi/gen/NewbornAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var newborn = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "新生儿");
			if(newborn!=null)
			{
				newborn.MCLink = "/XiangXi/gen/NewbornList.html";
				MenuConfiguration.AddOrUpdate(newborn);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "房产"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "房产",
					MCLink = "/XiangXi/gen/HousePropertyList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "房产统计",
					MCLink = "/XiangXi/gen/HousePropertyAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var houseproperty = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "房产");
			if(houseproperty!=null)
			{
				houseproperty.MCLink = "/XiangXi/gen/HousePropertyList.html";
				MenuConfiguration.AddOrUpdate(houseproperty);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "报销清单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "报销清单",
					MCLink = "/XiangXi/gen/ReimbursementListList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "报销清单统计",
					MCLink = "/XiangXi/gen/ReimbursementListAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var reimbursementlist = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "报销清单");
			if(reimbursementlist!=null)
			{
				reimbursementlist.MCLink = "/XiangXi/gen/ReimbursementListList.html";
				MenuConfiguration.AddOrUpdate(reimbursementlist);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "通讯录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "通讯录",
					MCLink = "/XiangXi/gen/MailListList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "通讯录统计",
					MCLink = "/XiangXi/gen/MailListAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var maillist = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "通讯录");
			if(maillist!=null)
			{
				maillist.MCLink = "/XiangXi/gen/MailListList.html";
				MenuConfiguration.AddOrUpdate(maillist);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "Poi"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "Poi",
					MCLink = "/XiangXi/gen/PoiList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "Poi统计",
					MCLink = "/XiangXi/gen/PoiAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var poi = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "Poi");
			if(poi!=null)
			{
				poi.MCLink = "/XiangXi/gen/PoiList.html";
				MenuConfiguration.AddOrUpdate(poi);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党建要闻管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党建要闻管理",
					MCLink = "/XiangXi/gen/ManagementOfPartyBuildingNewsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党建要闻管理统计",
					MCLink = "/XiangXi/gen/ManagementOfPartyBuildingNewsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var managementofpartybuildingnews = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党建要闻管理");
			if(managementofpartybuildingnews!=null)
			{
				managementofpartybuildingnews.MCLink = "/XiangXi/gen/ManagementOfPartyBuildingNewsList.html";
				MenuConfiguration.AddOrUpdate(managementofpartybuildingnews);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "随手拍"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "随手拍",
					MCLink = "/XiangXi/gen/FreeToShootList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "随手拍统计",
					MCLink = "/XiangXi/gen/FreeToShootAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var freetoshoot = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "随手拍");
			if(freetoshoot!=null)
			{
				freetoshoot.MCLink = "/XiangXi/gen/FreeToShootList.html";
				MenuConfiguration.AddOrUpdate(freetoshoot);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "主动巡检"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "主动巡检",
					MCLink = "/XiangXi/gen/ActiveInspectionList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "主动巡检统计",
					MCLink = "/XiangXi/gen/ActiveInspectionAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var activeinspection = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "主动巡检");
			if(activeinspection!=null)
			{
				activeinspection.MCLink = "/XiangXi/gen/ActiveInspectionList.html";
				MenuConfiguration.AddOrUpdate(activeinspection);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "业务预约"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "业务预约",
					MCLink = "/XiangXi/gen/BusinessAppointmentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "业务预约统计",
					MCLink = "/XiangXi/gen/BusinessAppointmentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var businessappointment = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "业务预约");
			if(businessappointment!=null)
			{
				businessappointment.MCLink = "/XiangXi/gen/BusinessAppointmentList.html";
				MenuConfiguration.AddOrUpdate(businessappointment);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "提建议记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "提建议记录",
					MCLink = "/XiangXi/gen/RecordOfRecommendationsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "提建议记录统计",
					MCLink = "/XiangXi/gen/RecordOfRecommendationsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var recordofrecommendations = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "提建议记录");
			if(recordofrecommendations!=null)
			{
				recordofrecommendations.MCLink = "/XiangXi/gen/RecordOfRecommendationsList.html";
				MenuConfiguration.AddOrUpdate(recordofrecommendations);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党风廉政学习"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党风廉政学习",
					MCLink = "/XiangXi/gen/StudyOnPartyStyleAndCleanGovernmentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党风廉政学习统计",
					MCLink = "/XiangXi/gen/StudyOnPartyStyleAndCleanGovernmentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var studyonpartystyleandcleangovernment = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党风廉政学习");
			if(studyonpartystyleandcleangovernment!=null)
			{
				studyonpartystyleandcleangovernment.MCLink = "/XiangXi/gen/StudyOnPartyStyleAndCleanGovernmentList.html";
				MenuConfiguration.AddOrUpdate(studyonpartystyleandcleangovernment);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "公共设施"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "公共设施",
					MCLink = "/XiangXi/gen/CommunalFacilitiesList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "公共设施统计",
					MCLink = "/XiangXi/gen/CommunalFacilitiesAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var communalfacilities = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "公共设施");
			if(communalfacilities!=null)
			{
				communalfacilities.MCLink = "/XiangXi/gen/CommunalFacilitiesList.html";
				MenuConfiguration.AddOrUpdate(communalfacilities);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "系统配置"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "系统配置",
					MCLink = "/XiangXi/gen/SystemConfigurationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "系统配置统计",
					MCLink = "/XiangXi/gen/SystemConfigurationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var systemconfiguration = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "系统配置");
			if(systemconfiguration!=null)
			{
				systemconfiguration.MCLink = "/XiangXi/gen/SystemConfigurationList.html";
				MenuConfiguration.AddOrUpdate(systemconfiguration);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党建"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党建",
					MCLink = "/XiangXi/gen/PartyBuildingList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党建统计",
					MCLink = "/XiangXi/gen/PartyBuildingAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var partybuilding = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党建");
			if(partybuilding!=null)
			{
				partybuilding.MCLink = "/XiangXi/gen/PartyBuildingList.html";
				MenuConfiguration.AddOrUpdate(partybuilding);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党费缴纳管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党费缴纳管理",
					MCLink = "/XiangXi/gen/ManagementOfPartyFeePaymentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党费缴纳管理统计",
					MCLink = "/XiangXi/gen/ManagementOfPartyFeePaymentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var managementofpartyfeepayment = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党费缴纳管理");
			if(managementofpartyfeepayment!=null)
			{
				managementofpartyfeepayment.MCLink = "/XiangXi/gen/ManagementOfPartyFeePaymentList.html";
				MenuConfiguration.AddOrUpdate(managementofpartyfeepayment);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "合同管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "合同管理",
					MCLink = "/XiangXi/gen/ContractManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "合同管理统计",
					MCLink = "/XiangXi/gen/ContractManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var contractmanagement = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "合同管理");
			if(contractmanagement!=null)
			{
				contractmanagement.MCLink = "/XiangXi/gen/ContractManagementList.html";
				MenuConfiguration.AddOrUpdate(contractmanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "个人信息"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "个人信息",
					MCLink = "/XiangXi/gen/PersonalInformationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "个人信息统计",
					MCLink = "/XiangXi/gen/PersonalInformationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var personalinformation = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "个人信息");
			if(personalinformation!=null)
			{
				personalinformation.MCLink = "/XiangXi/gen/PersonalInformationList.html";
				MenuConfiguration.AddOrUpdate(personalinformation);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "日程工作"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "日程工作",
					MCLink = "/XiangXi/gen/ScheduleWorkList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "日程工作统计",
					MCLink = "/XiangXi/gen/ScheduleWorkAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var schedulework = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "日程工作");
			if(schedulework!=null)
			{
				schedulework.MCLink = "/XiangXi/gen/ScheduleWorkList.html";
				MenuConfiguration.AddOrUpdate(schedulework);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党建专题"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党建专题",
					MCLink = "/XiangXi/gen/SpecialTopicOnPartyBuildingList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党建专题统计",
					MCLink = "/XiangXi/gen/SpecialTopicOnPartyBuildingAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var specialtopiconpartybuilding = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党建专题");
			if(specialtopiconpartybuilding!=null)
			{
				specialtopiconpartybuilding.MCLink = "/XiangXi/gen/SpecialTopicOnPartyBuildingList.html";
				MenuConfiguration.AddOrUpdate(specialtopiconpartybuilding);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "办事指南"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "办事指南",
					MCLink = "/XiangXi/gen/BusinessGuideList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "办事指南统计",
					MCLink = "/XiangXi/gen/BusinessGuideAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var businessguide = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "办事指南");
			if(businessguide!=null)
			{
				businessguide.MCLink = "/XiangXi/gen/BusinessGuideList.html";
				MenuConfiguration.AddOrUpdate(businessguide);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党务指南"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党务指南",
					MCLink = "/XiangXi/gen/PartyAffairsGuideList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党务指南统计",
					MCLink = "/XiangXi/gen/PartyAffairsGuideAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var partyaffairsguide = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党务指南");
			if(partyaffairsguide!=null)
			{
				partyaffairsguide.MCLink = "/XiangXi/gen/PartyAffairsGuideList.html";
				MenuConfiguration.AddOrUpdate(partyaffairsguide);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "业务管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "业务管理",
					MCLink = "/XiangXi/gen/BusinessManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "业务管理统计",
					MCLink = "/XiangXi/gen/BusinessManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var businessmanagement = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "业务管理");
			if(businessmanagement!=null)
			{
				businessmanagement.MCLink = "/XiangXi/gen/BusinessManagementList.html";
				MenuConfiguration.AddOrUpdate(businessmanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "少儿医保"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "少儿医保",
					MCLink = "/XiangXi/gen/MedicalInsuranceForChildrenList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "少儿医保统计",
					MCLink = "/XiangXi/gen/MedicalInsuranceForChildrenAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var medicalinsuranceforchildren = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "少儿医保");
			if(medicalinsuranceforchildren!=null)
			{
				medicalinsuranceforchildren.MCLink = "/XiangXi/gen/MedicalInsuranceForChildrenList.html";
				MenuConfiguration.AddOrUpdate(medicalinsuranceforchildren);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "农村医疗"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "农村医疗",
					MCLink = "/XiangXi/gen/RuralMedicalTreatmentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "农村医疗统计",
					MCLink = "/XiangXi/gen/RuralMedicalTreatmentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var ruralmedicaltreatment = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "农村医疗");
			if(ruralmedicaltreatment!=null)
			{
				ruralmedicaltreatment.MCLink = "/XiangXi/gen/RuralMedicalTreatmentList.html";
				MenuConfiguration.AddOrUpdate(ruralmedicaltreatment);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "福利发放"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "福利发放",
					MCLink = "/XiangXi/gen/WelfarePaymentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "福利发放统计",
					MCLink = "/XiangXi/gen/WelfarePaymentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var welfarepayment = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "福利发放");
			if(welfarepayment!=null)
			{
				welfarepayment.MCLink = "/XiangXi/gen/WelfarePaymentList.html";
				MenuConfiguration.AddOrUpdate(welfarepayment);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "服务预约"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "服务预约",
					MCLink = "/XiangXi/gen/ServiceAppointmentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "服务预约统计",
					MCLink = "/XiangXi/gen/ServiceAppointmentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var serviceappointment = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "服务预约");
			if(serviceappointment!=null)
			{
				serviceappointment.MCLink = "/XiangXi/gen/ServiceAppointmentList.html";
				MenuConfiguration.AddOrUpdate(serviceappointment);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "日程管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "日程管理",
					MCLink = "/XiangXi/gen/ScheduleManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "日程管理统计",
					MCLink = "/XiangXi/gen/ScheduleManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var schedulemanagement = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "日程管理");
			if(schedulemanagement!=null)
			{
				schedulemanagement.MCLink = "/XiangXi/gen/ScheduleManagementList.html";
				MenuConfiguration.AddOrUpdate(schedulemanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "专家管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "专家管理",
					MCLink = "/XiangXi/gen/ExpertManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "专家管理统计",
					MCLink = "/XiangXi/gen/ExpertManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var expertmanagement = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "专家管理");
			if(expertmanagement!=null)
			{
				expertmanagement.MCLink = "/XiangXi/gen/ExpertManagementList.html";
				MenuConfiguration.AddOrUpdate(expertmanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "权限访问"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "权限访问",
					MCLink = "/XiangXi/gen/PermissionAccessList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "权限访问统计",
					MCLink = "/XiangXi/gen/PermissionAccessAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var permissionaccess = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "权限访问");
			if(permissionaccess!=null)
			{
				permissionaccess.MCLink = "/XiangXi/gen/PermissionAccessList.html";
				MenuConfiguration.AddOrUpdate(permissionaccess);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "便民指南"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "便民指南",
					MCLink = "/XiangXi/gen/ConvenienceGuideList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "便民指南统计",
					MCLink = "/XiangXi/gen/ConvenienceGuideAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var convenienceguide = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "便民指南");
			if(convenienceguide!=null)
			{
				convenienceguide.MCLink = "/XiangXi/gen/ConvenienceGuideList.html";
				MenuConfiguration.AddOrUpdate(convenienceguide);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "便民生活"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "便民生活",
					MCLink = "/XiangXi/gen/ConvenientLifeList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "便民生活统计",
					MCLink = "/XiangXi/gen/ConvenientLifeAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var convenientlife = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "便民生活");
			if(convenientlife!=null)
			{
				convenientlife.MCLink = "/XiangXi/gen/ConvenientLifeList.html";
				MenuConfiguration.AddOrUpdate(convenientlife);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "香溪特色"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "香溪特色",
					MCLink = "/XiangXi/gen/CharacteristicOfXiangxiList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "香溪特色统计",
					MCLink = "/XiangXi/gen/CharacteristicOfXiangxiAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var characteristicofxiangxi = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "香溪特色");
			if(characteristicofxiangxi!=null)
			{
				characteristicofxiangxi.MCLink = "/XiangXi/gen/CharacteristicOfXiangxiList.html";
				MenuConfiguration.AddOrUpdate(characteristicofxiangxi);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "建议处理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "建议处理",
					MCLink = "/XiangXi/gen/ProposedTreatmentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "建议处理统计",
					MCLink = "/XiangXi/gen/ProposedTreatmentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var proposedtreatment = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "建议处理");
			if(proposedtreatment!=null)
			{
				proposedtreatment.MCLink = "/XiangXi/gen/ProposedTreatmentList.html";
				MenuConfiguration.AddOrUpdate(proposedtreatment);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "村史"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "村史",
					MCLink = "/XiangXi/gen/VillageHistoryList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "村史统计",
					MCLink = "/XiangXi/gen/VillageHistoryAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var villagehistory = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "村史");
			if(villagehistory!=null)
			{
				villagehistory.MCLink = "/XiangXi/gen/VillageHistoryList.html";
				MenuConfiguration.AddOrUpdate(villagehistory);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "专项工作"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "专项工作",
					MCLink = "/XiangXi/gen/SpecialWorkList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "专项工作统计",
					MCLink = "/XiangXi/gen/SpecialWorkAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var specialwork = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "专项工作");
			if(specialwork!=null)
			{
				specialwork.MCLink = "/XiangXi/gen/SpecialWorkList.html";
				MenuConfiguration.AddOrUpdate(specialwork);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "视频点位信息"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "视频点位信息",
					MCLink = "/XiangXi/gen/VideoPointInformationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "视频点位信息统计",
					MCLink = "/XiangXi/gen/VideoPointInformationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var videopointinformation = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "视频点位信息");
			if(videopointinformation!=null)
			{
				videopointinformation.MCLink = "/XiangXi/gen/VideoPointInformationList.html";
				MenuConfiguration.AddOrUpdate(videopointinformation);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "就业援助"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "就业援助",
					MCLink = "/XiangXi/gen/EmploymentAssistanceList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "就业援助统计",
					MCLink = "/XiangXi/gen/EmploymentAssistanceAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var employmentassistance = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "就业援助");
			if(employmentassistance!=null)
			{
				employmentassistance.MCLink = "/XiangXi/gen/EmploymentAssistanceList.html";
				MenuConfiguration.AddOrUpdate(employmentassistance);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "危房解危"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "危房解危",
					MCLink = "/XiangXi/gen/DangerousHousingList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "危房解危统计",
					MCLink = "/XiangXi/gen/DangerousHousingAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var dangeroushousing = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "危房解危");
			if(dangeroushousing!=null)
			{
				dangeroushousing.MCLink = "/XiangXi/gen/DangerousHousingList.html";
				MenuConfiguration.AddOrUpdate(dangeroushousing);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "工业园房屋收款"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "工业园房屋收款",
					MCLink = "/XiangXi/gen/IndustrialParkHousingReceiptList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "工业园房屋收款统计",
					MCLink = "/XiangXi/gen/IndustrialParkHousingReceiptAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var industrialparkhousingreceipt = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "工业园房屋收款");
			if(industrialparkhousingreceipt!=null)
			{
				industrialparkhousingreceipt.MCLink = "/XiangXi/gen/IndustrialParkHousingReceiptList.html";
				MenuConfiguration.AddOrUpdate(industrialparkhousingreceipt);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "需求收集"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "需求收集",
					MCLink = "/XiangXi/gen/DemandCollectionList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "需求收集统计",
					MCLink = "/XiangXi/gen/DemandCollectionAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var demandcollection = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "需求收集");
			if(demandcollection!=null)
			{
				demandcollection.MCLink = "/XiangXi/gen/DemandCollectionList.html";
				MenuConfiguration.AddOrUpdate(demandcollection);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党组织信息管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党组织信息管理",
					MCLink = "/XiangXi/gen/InformationManagementOfPartyOrganizationsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党组织信息管理统计",
					MCLink = "/XiangXi/gen/InformationManagementOfPartyOrganizationsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var informationmanagementofpartyorganizations = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党组织信息管理");
			if(informationmanagementofpartyorganizations!=null)
			{
				informationmanagementofpartyorganizations.MCLink = "/XiangXi/gen/InformationManagementOfPartyOrganizationsList.html";
				MenuConfiguration.AddOrUpdate(informationmanagementofpartyorganizations);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "关爱对象"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "关爱对象",
					MCLink = "/XiangXi/gen/CareForTheObjectList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "关爱对象统计",
					MCLink = "/XiangXi/gen/CareForTheObjectAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var carefortheobject = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "关爱对象");
			if(carefortheobject!=null)
			{
				carefortheobject.MCLink = "/XiangXi/gen/CareForTheObjectList.html";
				MenuConfiguration.AddOrUpdate(carefortheobject);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "招聘就业模块"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "招聘就业模块",
					MCLink = "/XiangXi/gen/RecruitmentAndEmploymentModuleList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "招聘就业模块统计",
					MCLink = "/XiangXi/gen/RecruitmentAndEmploymentModuleAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var recruitmentandemploymentmodule = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "招聘就业模块");
			if(recruitmentandemploymentmodule!=null)
			{
				recruitmentandemploymentmodule.MCLink = "/XiangXi/gen/RecruitmentAndEmploymentModuleList.html";
				MenuConfiguration.AddOrUpdate(recruitmentandemploymentmodule);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党群结队"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党群结队",
					MCLink = "/XiangXi/gen/PartyAndGroupFormationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党群结队统计",
					MCLink = "/XiangXi/gen/PartyAndGroupFormationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var partyandgroupformation = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党群结队");
			if(partyandgroupformation!=null)
			{
				partyandgroupformation.MCLink = "/XiangXi/gen/PartyAndGroupFormationList.html";
				MenuConfiguration.AddOrUpdate(partyandgroupformation);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "党员活动"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党员活动",
					MCLink = "/XiangXi/gen/PartyMemberActivitiesList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "党员活动统计",
					MCLink = "/XiangXi/gen/PartyMemberActivitiesAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var partymemberactivities = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "党员活动");
			if(partymemberactivities!=null)
			{
				partymemberactivities.MCLink = "/XiangXi/gen/PartyMemberActivitiesList.html";
				MenuConfiguration.AddOrUpdate(partymemberactivities);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "美丽乡村"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "美丽乡村",
					MCLink = "/XiangXi/gen/BeautifulCountrysideList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "美丽乡村统计",
					MCLink = "/XiangXi/gen/BeautifulCountrysideAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var beautifulcountryside = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "美丽乡村");
			if(beautifulcountryside!=null)
			{
				beautifulcountryside.MCLink = "/XiangXi/gen/BeautifulCountrysideList.html";
				MenuConfiguration.AddOrUpdate(beautifulcountryside);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "引水上山"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "引水上山",
					MCLink = "/XiangXi/gen/DrawWaterUpaHillList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "引水上山统计",
					MCLink = "/XiangXi/gen/DrawWaterUpaHillAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var drawwaterupahill = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "引水上山");
			if(drawwaterupahill!=null)
			{
				drawwaterupahill.MCLink = "/XiangXi/gen/DrawWaterUpaHillList.html";
				MenuConfiguration.AddOrUpdate(drawwaterupahill);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "宣传"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "宣传",
					MCLink = "/XiangXi/gen/PropagandaList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "宣传统计",
					MCLink = "/XiangXi/gen/PropagandaAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var propaganda = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "宣传");
			if(propaganda!=null)
			{
				propaganda.MCLink = "/XiangXi/gen/PropagandaList.html";
				MenuConfiguration.AddOrUpdate(propaganda);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "组织"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "组织",
					MCLink = "/XiangXi/gen/OrganizationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "组织统计",
					MCLink = "/XiangXi/gen/OrganizationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var organization = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "组织");
			if(organization!=null)
			{
				organization.MCLink = "/XiangXi/gen/OrganizationList.html";
				MenuConfiguration.AddOrUpdate(organization);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "工会"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "工会",
					MCLink = "/XiangXi/gen/LabourUnionList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "工会统计",
					MCLink = "/XiangXi/gen/LabourUnionAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var labourunion = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "工会");
			if(labourunion!=null)
			{
				labourunion.MCLink = "/XiangXi/gen/LabourUnionList.html";
				MenuConfiguration.AddOrUpdate(labourunion);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "工会成员"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "工会成员",
					MCLink = "/XiangXi/gen/TradeUnionMembersList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "工会成员统计",
					MCLink = "/XiangXi/gen/TradeUnionMembersAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var tradeunionmembers = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "工会成员");
			if(tradeunionmembers!=null)
			{
				tradeunionmembers.MCLink = "/XiangXi/gen/TradeUnionMembersList.html";
				MenuConfiguration.AddOrUpdate(tradeunionmembers);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "工作人员"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "工作人员",
					MCLink = "/XiangXi/gen/PersonnelList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "工作人员统计",
					MCLink = "/XiangXi/gen/PersonnelAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var personnel = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "工作人员");
			if(personnel!=null)
			{
				personnel.MCLink = "/XiangXi/gen/PersonnelList.html";
				MenuConfiguration.AddOrUpdate(personnel);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "姑苏村问题处理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "姑苏村问题处理",
					MCLink = "/XiangXi/gen/HandlingOfGusuVillageProblemList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "姑苏村问题处理统计",
					MCLink = "/XiangXi/gen/HandlingOfGusuVillageProblemAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var handlingofgusuvillageproblem = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "姑苏村问题处理");
			if(handlingofgusuvillageproblem!=null)
			{
				handlingofgusuvillageproblem.MCLink = "/XiangXi/gen/HandlingOfGusuVillageProblemList.html";
				MenuConfiguration.AddOrUpdate(handlingofgusuvillageproblem);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "渔政"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "渔政",
					MCLink = "/XiangXi/gen/FisheryAdministrationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "渔政统计",
					MCLink = "/XiangXi/gen/FisheryAdministrationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var fisheryadministration = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "渔政");
			if(fisheryadministration!=null)
			{
				fisheryadministration.MCLink = "/XiangXi/gen/FisheryAdministrationList.html";
				MenuConfiguration.AddOrUpdate(fisheryadministration);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "妇联执委名单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "妇联执委名单",
					MCLink = "/XiangXi/gen/ListOfExecutiveCommitteesOfWomensFederationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "妇联执委名单统计",
					MCLink = "/XiangXi/gen/ListOfExecutiveCommitteesOfWomensFederationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var listofexecutivecommitteesofwomensfederation = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "妇联执委名单");
			if(listofexecutivecommitteesofwomensfederation!=null)
			{
				listofexecutivecommitteesofwomensfederation.MCLink = "/XiangXi/gen/ListOfExecutiveCommitteesOfWomensFederationList.html";
				MenuConfiguration.AddOrUpdate(listofexecutivecommitteesofwomensfederation);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "资产"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "资产",
					MCLink = "/XiangXi/gen/AssetsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "资产统计",
					MCLink = "/XiangXi/gen/AssetsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var assets = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "资产");
			if(assets!=null)
			{
				assets.MCLink = "/XiangXi/gen/AssetsList.html";
				MenuConfiguration.AddOrUpdate(assets);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "监护人"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "监护人",
					MCLink = "/XiangXi/gen/GuardianList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "监护人统计",
					MCLink = "/XiangXi/gen/GuardianAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var guardian = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "监护人");
			if(guardian!=null)
			{
				guardian.MCLink = "/XiangXi/gen/GuardianList.html";
				MenuConfiguration.AddOrUpdate(guardian);
			}

			if (!MenuConfiguration.Any(t => t.MCTitle == "照片"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "照片",
					MCLink = "/XiangXi/gen/PhotoList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCTitle = "照片统计",
					MCLink = "/XiangXi/gen/PhotoAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now,
                    UpdateBy = CreateBy
				});
			}
			var photo = MenuConfiguration.FirstOrDefault(t => t.MCTitle == "照片");
			if(photo!=null)
			{
				photo.MCLink = "/XiangXi/gen/PhotoList.html";
				MenuConfiguration.AddOrUpdate(photo);
			}
            

		    SaveChanges();
		}

        /// <summary>
        ///  菜单配置 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.MenuConfiguration> MenuConfiguration { get; set; }

        /// <summary>
        ///  角色菜单 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RoleMenu> RoleMenu { get; set; }

        /// <summary>
        ///  用户角色 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.UserRoles> UserRoles { get; set; }

        /// <summary>
        ///  角色配置 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RoleConfiguration> RoleConfiguration { get; set; }

        /// <summary>
        ///  用户信息 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.UserInformation> UserInformation { get; set; }

        /// <summary>
        ///  登录记录 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.LoginRecord> LoginRecord { get; set; }

        /// <summary>
        ///  用户菜单 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.UserMenu> UserMenu { get; set; }

        /// <summary>
        ///  党员信息管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.InformationManagementOfPartyMembers> InformationManagementOfPartyMembers { get; set; }

        /// <summary>
        ///  党费管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PartyFeeManagement> PartyFeeManagement { get; set; }

        /// <summary>
        ///  党课记录 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PartyRecord> PartyRecord { get; set; }

        /// <summary>
        ///  三会一课 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ThreeSessions> ThreeSessions { get; set; }

        /// <summary>
        ///  专题学习 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ThematicLearning> ThematicLearning { get; set; }

        /// <summary>
        ///  政策文件 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PolicyDocument> PolicyDocument { get; set; }

        /// <summary>
        ///  政策文件类别 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.CategoriesOfPolicyDocuments> CategoriesOfPolicyDocuments { get; set; }

        /// <summary>
        ///  现役军人名单 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ListOfActiveServicemen> ListOfActiveServicemen { get; set; }

        /// <summary>
        ///  征兵对象名单 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ListOfConscripts> ListOfConscripts { get; set; }

        /// <summary>
        ///  共青团 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.CommunistYouthLeague> CommunistYouthLeague { get; set; }

        /// <summary>
        ///  重点人员 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.KeyPersonnel> KeyPersonnel { get; set; }

        /// <summary>
        ///  信访 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.LettersAndVisits> LettersAndVisits { get; set; }

        /// <summary>
        ///  两类人员 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.TheTwoCategoryOfPersonnel> TheTwoCategoryOfPersonnel { get; set; }

        /// <summary>
        ///  家庭 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Family> Family { get; set; }

        /// <summary>
        ///  股民 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Investors> Investors { get; set; }

        /// <summary>
        ///  分红记录 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.BonusRecord> BonusRecord { get; set; }

        /// <summary>
        ///  干部 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Cadre> Cadre { get; set; }

        /// <summary>
        ///  民兵 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Militia> Militia { get; set; }

        /// <summary>
        ///  统战民兵 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.UnitedFrontMilitia> UnitedFrontMilitia { get; set; }

        /// <summary>
        ///  厂房楼栋 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.FactoryBuilding> FactoryBuilding { get; set; }

        /// <summary>
        ///  收租记录 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RentCollectionRecords> RentCollectionRecords { get; set; }

        /// <summary>
        ///  电费缴纳记录 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ElectricityChargePaymentRecord> ElectricityChargePaymentRecord { get; set; }

        /// <summary>
        ///  工作日志 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.JobDiary> JobDiary { get; set; }

        /// <summary>
        ///  通知 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Notice> Notice { get; set; }

        /// <summary>
        ///  文档管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.DocumentManagement> DocumentManagement { get; set; }

        /// <summary>
        ///  人口 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Population> Population { get; set; }

        /// <summary>
        ///  新生儿 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Newborn> Newborn { get; set; }

        /// <summary>
        ///  房产 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.HouseProperty> HouseProperty { get; set; }

        /// <summary>
        ///  报销清单 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ReimbursementList> ReimbursementList { get; set; }

        /// <summary>
        ///  通讯录 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.MailList> MailList { get; set; }

        /// <summary>
        ///  Poi 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Poi> Poi { get; set; }

        /// <summary>
        ///  党建要闻管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ManagementOfPartyBuildingNews> ManagementOfPartyBuildingNews { get; set; }

        /// <summary>
        ///  随手拍 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.FreeToShoot> FreeToShoot { get; set; }

        /// <summary>
        ///  主动巡检 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ActiveInspection> ActiveInspection { get; set; }

        /// <summary>
        ///  业务预约 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.BusinessAppointment> BusinessAppointment { get; set; }

        /// <summary>
        ///  提建议记录 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RecordOfRecommendations> RecordOfRecommendations { get; set; }

        /// <summary>
        ///  党风廉政学习 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.StudyOnPartyStyleAndCleanGovernment> StudyOnPartyStyleAndCleanGovernment { get; set; }

        /// <summary>
        ///  公共设施 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.CommunalFacilities> CommunalFacilities { get; set; }

        /// <summary>
        ///  系统配置 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.SystemConfiguration> SystemConfiguration { get; set; }

        /// <summary>
        ///  党建 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PartyBuilding> PartyBuilding { get; set; }

        /// <summary>
        ///  党费缴纳管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ManagementOfPartyFeePayment> ManagementOfPartyFeePayment { get; set; }

        /// <summary>
        ///  合同管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ContractManagement> ContractManagement { get; set; }

        /// <summary>
        ///  个人信息 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PersonalInformation> PersonalInformation { get; set; }

        /// <summary>
        ///  日程工作 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ScheduleWork> ScheduleWork { get; set; }

        /// <summary>
        ///  党建专题 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.SpecialTopicOnPartyBuilding> SpecialTopicOnPartyBuilding { get; set; }

        /// <summary>
        ///  办事指南 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.BusinessGuide> BusinessGuide { get; set; }

        /// <summary>
        ///  党务指南 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PartyAffairsGuide> PartyAffairsGuide { get; set; }

        /// <summary>
        ///  业务管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.BusinessManagement> BusinessManagement { get; set; }

        /// <summary>
        ///  少儿医保 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.MedicalInsuranceForChildren> MedicalInsuranceForChildren { get; set; }

        /// <summary>
        ///  农村医疗 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RuralMedicalTreatment> RuralMedicalTreatment { get; set; }

        /// <summary>
        ///  福利发放 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.WelfarePayment> WelfarePayment { get; set; }

        /// <summary>
        ///  服务预约 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ServiceAppointment> ServiceAppointment { get; set; }

        /// <summary>
        ///  日程管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ScheduleManagement> ScheduleManagement { get; set; }

        /// <summary>
        ///  专家管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ExpertManagement> ExpertManagement { get; set; }

        /// <summary>
        ///  权限访问 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PermissionAccess> PermissionAccess { get; set; }

        /// <summary>
        ///  便民指南 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ConvenienceGuide> ConvenienceGuide { get; set; }

        /// <summary>
        ///  便民生活 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ConvenientLife> ConvenientLife { get; set; }

        /// <summary>
        ///  香溪特色 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.CharacteristicOfXiangxi> CharacteristicOfXiangxi { get; set; }

        /// <summary>
        ///  建议处理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ProposedTreatment> ProposedTreatment { get; set; }

        /// <summary>
        ///  村史 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.VillageHistory> VillageHistory { get; set; }

        /// <summary>
        ///  专项工作 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.SpecialWork> SpecialWork { get; set; }

        /// <summary>
        ///  视频点位信息 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.VideoPointInformation> VideoPointInformation { get; set; }

        /// <summary>
        ///  就业援助 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.EmploymentAssistance> EmploymentAssistance { get; set; }

        /// <summary>
        ///  危房解危 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.DangerousHousing> DangerousHousing { get; set; }

        /// <summary>
        ///  工业园房屋收款 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.IndustrialParkHousingReceipt> IndustrialParkHousingReceipt { get; set; }

        /// <summary>
        ///  需求收集 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.DemandCollection> DemandCollection { get; set; }

        /// <summary>
        ///  党组织信息管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.InformationManagementOfPartyOrganizations> InformationManagementOfPartyOrganizations { get; set; }

        /// <summary>
        ///  关爱对象 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.CareForTheObject> CareForTheObject { get; set; }

        /// <summary>
        ///  招聘就业模块 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RecruitmentAndEmploymentModule> RecruitmentAndEmploymentModule { get; set; }

        /// <summary>
        ///  党群结队 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PartyAndGroupFormation> PartyAndGroupFormation { get; set; }

        /// <summary>
        ///  党员活动 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PartyMemberActivities> PartyMemberActivities { get; set; }

        /// <summary>
        ///  美丽乡村 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.BeautifulCountryside> BeautifulCountryside { get; set; }

        /// <summary>
        ///  引水上山 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.DrawWaterUpaHill> DrawWaterUpaHill { get; set; }

        /// <summary>
        ///  宣传 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Propaganda> Propaganda { get; set; }

        /// <summary>
        ///  组织 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Organization> Organization { get; set; }

        /// <summary>
        ///  工会 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.LabourUnion> LabourUnion { get; set; }

        /// <summary>
        ///  工会成员 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.TradeUnionMembers> TradeUnionMembers { get; set; }

        /// <summary>
        ///  工作人员 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Personnel> Personnel { get; set; }

        /// <summary>
        ///  姑苏村问题处理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.HandlingOfGusuVillageProblem> HandlingOfGusuVillageProblem { get; set; }

        /// <summary>
        ///  渔政 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.FisheryAdministration> FisheryAdministration { get; set; }

        /// <summary>
        ///  妇联执委名单 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ListOfExecutiveCommitteesOfWomensFederation> ListOfExecutiveCommitteesOfWomensFederation { get; set; }

        /// <summary>
        ///  资产 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Assets> Assets { get; set; }

        /// <summary>
        ///  监护人 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Guardian> Guardian { get; set; }

        /// <summary>
        ///  照片 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Photo> Photo { get; set; }
    }
}
namespace XiangXiENtities.EF.NewEntities
{
	
    /// <summary>
    ///  菜单配置 
    /// </summary>
	[Table("MenuConfiguration")]
    public class MenuConfiguration 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string MCTitle { get; set; }
			
        /// <summary>
        ///  链接 
        /// </summary>
        public string MCLink { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string MCPicture { get; set; }
			
        /// <summary>
        ///  父级标题 
        /// </summary>
        public string MCParentTitle { get; set; }
			
        /// <summary>
        ///  菜单类型 
        /// </summary>
        public string MCMenuType { get; set; }
			
        /// <summary>
        ///  顺序 
        /// </summary>
        public Nullable<int> MCOrder { get; set; }
			
        /// <summary>
        ///  显示名称 
        /// </summary>
        public string MCDisplayName { get; set; }
	}

	
    /// <summary>
    ///  角色菜单 
    /// </summary>
	[Table("RoleMenu")]
    public class RoleMenu 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  角色名称 
        /// </summary>
        public string RMRoleName { get; set; }
			
        /// <summary>
        ///  菜单标题 
        /// </summary>
        public string RMMenuTitle { get; set; }
	}

	
    /// <summary>
    ///  用户角色 
    /// </summary>
	[Table("UserRoles")]
    public class UserRoles 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  角色名称 
        /// </summary>
        public string URRoleName { get; set; }
			
        /// <summary>
        ///  登录名 
        /// </summary>
        public string URLoginName { get; set; }
	}

	
    /// <summary>
    ///  角色配置 
    /// </summary>
	[Table("RoleConfiguration")]
    public class RoleConfiguration 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  角色名称 
        /// </summary>
        public string RCRoleName { get; set; }
			
        /// <summary>
        ///  所属组织 
        /// </summary>
        public string RCAffiliatedOrganization { get; set; }
	}

	
    /// <summary>
    ///  用户信息 
    /// </summary>
	[Table("UserInformation")]
    public class UserInformation 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  登录名 
        /// </summary>
        public string UILoginName { get; set; }
			
        /// <summary>
        ///  密码 
        /// </summary>
        public string UIPassword { get; set; }
			
        /// <summary>
        ///  用户类型 
        /// </summary>
        public string UICustomerType { get; set; }
			
        /// <summary>
        ///  用户级别 
        /// </summary>
        public string UIUserLevel { get; set; }
			
        /// <summary>
        ///  状态 
        /// </summary>
        public string UIState { get; set; }
			
        /// <summary>
        ///  昵称 
        /// </summary>
        public string UINickname { get; set; }
			
        /// <summary>
        ///  真实姓名 
        /// </summary>
        public string UIRealName { get; set; }
			
        /// <summary>
        ///  头像 
        /// </summary>
        public string UIHeadPortrait { get; set; }
			
        /// <summary>
        ///  所属部门 
        /// </summary>
        public string UISubordinateDepartments { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string UITelephone { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string UIPhoto { get; set; }
	}

	
    /// <summary>
    ///  登录记录 
    /// </summary>
	[Table("LoginRecord")]
    public class LoginRecord 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  登录名 
        /// </summary>
        public string LRLoginName { get; set; }
			
        /// <summary>
        ///  登录时间 
        /// </summary>
        public Nullable<DateTime> LRLoginTime { get; set; }
	}

	
    /// <summary>
    ///  用户菜单 
    /// </summary>
	[Table("UserMenu")]
    public class UserMenu 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  登录名 
        /// </summary>
        public string UMLoginName { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string UMTitle { get; set; }
	}

	
    /// <summary>
    ///  党员信息管理 
    /// </summary>
	[Table("InformationManagementOfPartyMembers")]
    public class InformationManagementOfPartyMembers 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string IMOPMFullName { get; set; }
			
        /// <summary>
        ///  身份证号 
        /// </summary>
        public string IMOPMIdNumber { get; set; }
			
        /// <summary>
        ///  出生日期 
        /// </summary>
        public Nullable<DateTime> IMOPMDateOfBirth { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string IMOPMGender { get; set; }
			
        /// <summary>
        ///  民族 
        /// </summary>
        public string IMOPMNation { get; set; }
			
        /// <summary>
        ///  学历 
        /// </summary>
        public string IMOPMEducation { get; set; }
			
        /// <summary>
        ///  类别 
        /// </summary>
        public string IMOPMCategory { get; set; }
			
        /// <summary>
        ///  所在党支部 
        /// </summary>
        public string IMOPMPartyBranch { get; set; }
			
        /// <summary>
        ///  入党日期 
        /// </summary>
        public Nullable<DateTime> IMOPMDateOfJoiningTheParty { get; set; }
			
        /// <summary>
        ///  转正日期 
        /// </summary>
        public Nullable<DateTime> IMOPMDateOfCorrection { get; set; }
			
        /// <summary>
        ///  工作岗位 
        /// </summary>
        public string IMOPMPost { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string IMOPMContactNumber { get; set; }
			
        /// <summary>
        ///  家庭住址 
        /// </summary>
        public string IMOPMFamilyAddress { get; set; }
	}

	
    /// <summary>
    ///  党费管理 
    /// </summary>
	[Table("PartyFeeManagement")]
    public class PartyFeeManagement 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string PFMFullName { get; set; }
			
        /// <summary>
        ///  身份证号 
        /// </summary>
        public string PFMIdNumber { get; set; }
			
        /// <summary>
        ///  年龄 
        /// </summary>
        public Nullable<int> PFMAge { get; set; }
			
        /// <summary>
        ///  所在党支部 
        /// </summary>
        public string PFMPartyBranch { get; set; }
			
        /// <summary>
        ///  月收入 
        /// </summary>
        public string PFMMonthlyIncome { get; set; }
			
        /// <summary>
        ///  月党费 
        /// </summary>
        public string PFMMonthlyPartyMembershipFee { get; set; }
	}

	
    /// <summary>
    ///  党课记录 
    /// </summary>
	[Table("PartyRecord")]
    public class PartyRecord 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string PRFullName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string PRIdCardNo { get; set; }
			
        /// <summary>
        ///  课程名称 
        /// </summary>
        public string PRCourseTitle { get; set; }
			
        /// <summary>
        ///  课程摘要 
        /// </summary>
        public string PRCourseSummary { get; set; }
			
        /// <summary>
        ///  学习情况 
        /// </summary>
        public string PRLearningSituation { get; set; }
			
        /// <summary>
        ///  课程时间 
        /// </summary>
        public Nullable<DateTime> PRCourseTime { get; set; }
	}

	
    /// <summary>
    ///  三会一课 
    /// </summary>
	[Table("ThreeSessions")]
    public class ThreeSessions 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  日期 
        /// </summary>
        public Nullable<DateTime> TSDate { get; set; }
			
        /// <summary>
        ///  主题 
        /// </summary>
        public string TSTheme { get; set; }
			
        /// <summary>
        ///  参与人员 
        /// </summary>
        public string TSParticipant { get; set; }
			
        /// <summary>
        ///  与会人数 
        /// </summary>
        public string TSNumberOfParticipants { get; set; }
			
        /// <summary>
        ///  主持人 
        /// </summary>
        public string TSHost { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string TSContent { get; set; }
			
        /// <summary>
        ///  类型 
        /// </summary>
        public string TSType { get; set; }
	}

	
    /// <summary>
    ///  专题学习 
    /// </summary>
	[Table("ThematicLearning")]
    public class ThematicLearning 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  日期 
        /// </summary>
        public Nullable<DateTime> TLDate { get; set; }
			
        /// <summary>
        ///  专题内容 
        /// </summary>
        public string TLThematicContent { get; set; }
			
        /// <summary>
        ///  参与人员 
        /// </summary>
        public string TLParticipant { get; set; }
			
        /// <summary>
        ///  与会人数 
        /// </summary>
        public string TLNumberOfParticipants { get; set; }
			
        /// <summary>
        ///  主持人 
        /// </summary>
        public string TLHost { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string TLContent { get; set; }
	}

	
    /// <summary>
    ///  政策文件 
    /// </summary>
	[Table("PolicyDocument")]
    public class PolicyDocument 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  文件号 
        /// </summary>
        public string PDFileNumber { get; set; }
			
        /// <summary>
        ///  @政策文件类别 
        /// </summary>
        public string PDCategoriesOfPolicyDocuments { get; set; }
			
        /// <summary>
        ///  专文件主题 
        /// </summary>
        public string PDThemeOfSpecialDocument { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string PDContent { get; set; }
			
        /// <summary>
        ///  上传文件 
        /// </summary>
        public string PDUploadFiles { get; set; }
			
        /// <summary>
        ///  年份 
        /// </summary>
        public string PDParticularYear { get; set; }
	}

	
    /// <summary>
    ///  政策文件类别 
    /// </summary>
	[Table("CategoriesOfPolicyDocuments")]
    public class CategoriesOfPolicyDocuments 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  类别名称 
        /// </summary>
        public string COPDCategoryName { get; set; }
			
        /// <summary>
        ///  描述 
        /// </summary>
        public string COPDDescribe { get; set; }
			
        /// <summary>
        ///  政策文件 
        /// </summary>
        // public List<PolicyDocument> PolicyDocument { get; set; }
	}

	
    /// <summary>
    ///  现役军人名单 
    /// </summary>
	[Table("ListOfActiveServicemen")]
    public class ListOfActiveServicemen 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string LOASFullName { get; set; }
			
        /// <summary>
        ///  民族 
        /// </summary>
        public string LOASNation { get; set; }
			
        /// <summary>
        ///  家庭住址 
        /// </summary>
        public string LOASFamilyAddress { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string LOASIdCardNo { get; set; }
			
        /// <summary>
        ///  联系方式 
        /// </summary>
        public string LOASContactInformation { get; set; }
			
        /// <summary>
        ///  家庭情况 
        /// </summary>
        public string LOASFamilySituation { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string LOASRemarks { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string LOASGender { get; set; }
			
        /// <summary>
        ///  出生年月 
        /// </summary>
        public string LOASDateOfBirth { get; set; }
			
        /// <summary>
        ///  文化程度 
        /// </summary>
        public string LOASDegreeOfEducation { get; set; }
			
        /// <summary>
        ///  户口所在地 
        /// </summary>
        public string LOASRegisteredResidence { get; set; }
	}

	
    /// <summary>
    ///  征兵对象名单 
    /// </summary>
	[Table("ListOfConscripts")]
    public class ListOfConscripts 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string LOCFullName { get; set; }
			
        /// <summary>
        ///  出生年月 
        /// </summary>
        public string LOCDateOfBirth { get; set; }
			
        /// <summary>
        ///  文化程度 
        /// </summary>
        public string LOCDegreeOfEducation { get; set; }
			
        /// <summary>
        ///  政治面貌 
        /// </summary>
        public string LOCPoliticalOutlook { get; set; }
			
        /// <summary>
        ///  户口性质 
        /// </summary>
        public string LOCAccountCharacter { get; set; }
			
        /// <summary>
        ///  毕业院校 
        /// </summary>
        public string LOCUniversityOneIsGraduatedFrom { get; set; }
			
        /// <summary>
        ///  联系方式 
        /// </summary>
        public string LOCContactInformation { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string LOCIdCardNo { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string LOCRemarks { get; set; }
	}

	
    /// <summary>
    ///  共青团 
    /// </summary>
	[Table("CommunistYouthLeague")]
    public class CommunistYouthLeague 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  序号 
        /// </summary>
        public string CYLSerialNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string CYLFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string CYLGender { get; set; }
			
        /// <summary>
        ///  出生年月 
        /// </summary>
        public string CYLDateOfBirth { get; set; }
			
        /// <summary>
        ///  志愿时间 
        /// </summary>
        public Nullable<DateTime> CYLVolunteerTime { get; set; }
			
        /// <summary>
        ///  籍贯 
        /// </summary>
        public string CYLNativePlace { get; set; }
			
        /// <summary>
        ///  学历 
        /// </summary>
        public string CYLEducation { get; set; }
			
        /// <summary>
        ///  入团年月 
        /// </summary>
        public string CYLJoiningTheLeagueYear { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string CYLRemarks { get; set; }
	}

	
    /// <summary>
    ///  重点人员 
    /// </summary>
	[Table("KeyPersonnel")]
    public class KeyPersonnel 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  序号 
        /// </summary>
        public string KPSerialNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string KPFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string KPGender { get; set; }
			
        /// <summary>
        ///  居住地 
        /// </summary>
        public string KPPlaceOfResidence { get; set; }
			
        /// <summary>
        ///  户籍地 
        /// </summary>
        public string KPDomicile { get; set; }
			
        /// <summary>
        ///  事由 
        /// </summary>
        public string KPCause { get; set; }
			
        /// <summary>
        ///  目前状态 
        /// </summary>
        public string KPCurrentState { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string KPContactNumber { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string KPRemarks { get; set; }
	}

	
    /// <summary>
    ///  信访 
    /// </summary>
	[Table("LettersAndVisits")]
    public class LettersAndVisits 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  序号 
        /// </summary>
        public string LAVSerialNumber { get; set; }
			
        /// <summary>
        ///  投诉事件 
        /// </summary>
        public string LAVComplaints { get; set; }
			
        /// <summary>
        ///  投诉地点 
        /// </summary>
        public string LAVPlaceOfComplaint { get; set; }
			
        /// <summary>
        ///  办理结果 
        /// </summary>
        public string LAVHandlingResult { get; set; }
	}

	
    /// <summary>
    ///  两类人员 
    /// </summary>
	[Table("TheTwoCategoryOfPersonnel")]
    public class TheTwoCategoryOfPersonnel 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  所在社区 
        /// </summary>
        public string TTCOPLocalCommunity { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string TTCOPFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string TTCOPGender { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string TTCOPIdCardNo { get; set; }
			
        /// <summary>
        ///  罪名 
        /// </summary>
        public string TTCOPCharge { get; set; }
			
        /// <summary>
        ///  家庭住址 
        /// </summary>
        public string TTCOPFamilyAddress { get; set; }
	}

	
    /// <summary>
    ///  家庭 
    /// </summary>
	[Table("Family")]
    public class Family 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  家庭组织名称 
        /// </summary>
        public string FNameOfFamilyOrganization { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string FFullName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string FIdCardNo { get; set; }
			
        /// <summary>
        ///  新生儿姓名 
        /// </summary>
        public string FNameOfNewborn { get; set; }
			
        /// <summary>
        ///  死亡证明 
        /// </summary>
        public string FDeathCertificate { get; set; }
			
        /// <summary>
        ///  居住地 
        /// </summary>
        public string FPlaceOfResidence { get; set; }
			
        /// <summary>
        ///  联系方式 
        /// </summary>
        public string FContactInformation { get; set; }
	}

	
    /// <summary>
    ///  股民 
    /// </summary>
	[Table("Investors")]
    public class Investors 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  序号 
        /// </summary>
        public string ISerialNumber { get; set; }
			
        /// <summary>
        ///  户编号 
        /// </summary>
        public string IHouseholdNumber { get; set; }
			
        /// <summary>
        ///  股权证编号 
        /// </summary>
        public string IEquityCertificateNumber { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string IIdCardNo { get; set; }
			
        /// <summary>
        ///  户主 
        /// </summary>
        public string IaHouseholder { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string IFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string IGender { get; set; }
			
        /// <summary>
        ///  出生年月 
        /// </summary>
        public string IDateOfBirth { get; set; }
			
        /// <summary>
        ///  周岁 
        /// </summary>
        public string IOneYearOld { get; set; }
			
        /// <summary>
        ///  基本股 
        /// </summary>
        public string IBasicStock { get; set; }
			
        /// <summary>
        ///  应得股份股 
        /// </summary>
        public string IDeservedShare { get; set; }
			
        /// <summary>
        ///  户合计股数 
        /// </summary>
        public string ITotalNumberOfSharesInaHousehold { get; set; }
			
        /// <summary>
        ///  确认签名 
        /// </summary>
        public string IWitnessing { get; set; }
			
        /// <summary>
        ///  配股说明 
        /// </summary>
        public string IRightsIssue { get; set; }
			
        /// <summary>
        ///  统计主题1 
        /// </summary>
        public string IStatisticalTopic1 { get; set; }
	}

	
    /// <summary>
    ///  分红记录 
    /// </summary>
	[Table("BonusRecord")]
    public class BonusRecord 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string BRFullName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string BRIdCardNo { get; set; }
			
        /// <summary>
        ///  股份类型 
        /// </summary>
        public string BRShareType { get; set; }
			
        /// <summary>
        ///  股票占比 
        /// </summary>
        public string BRShareRatio { get; set; }
			
        /// <summary>
        ///  发放金额 
        /// </summary>
        public Nullable<decimal> BRPaymentAmount { get; set; }
			
        /// <summary>
        ///  发放时间 
        /// </summary>
        public Nullable<DateTime> BRPaymentTime { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string BRPersonInCharge { get; set; }
			
        /// <summary>
        ///  负责人联系方式 
        /// </summary>
        public string BRContactInformationOfPersonInCharge { get; set; }
	}

	
    /// <summary>
    ///  干部 
    /// </summary>
	[Table("Cadre")]
    public class Cadre 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string CFullName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string CIdCardNo { get; set; }
			
        /// <summary>
        ///  上级领导 
        /// </summary>
        public string CSuperiorLeader { get; set; }
			
        /// <summary>
        ///  所属支部 
        /// </summary>
        public string CSubordinateBranch { get; set; }
			
        /// <summary>
        ///  劳模 
        /// </summary>
        public string CModelWorker { get; set; }
			
        /// <summary>
        ///  干部类型 
        /// </summary>
        public string CTypesOfCadres { get; set; }
	}

	
    /// <summary>
    ///  民兵 
    /// </summary>
	[Table("Militia")]
    public class Militia 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string MFullName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string MIdCardNo { get; set; }
			
        /// <summary>
        ///  上级领导 
        /// </summary>
        public string MSuperiorLeader { get; set; }
			
        /// <summary>
        ///  所属番号 
        /// </summary>
        public string MDesignation { get; set; }
			
        /// <summary>
        ///  民兵类型 
        /// </summary>
        public string MMilitiaType { get; set; }
	}

	
    /// <summary>
    ///  统战民兵 
    /// </summary>
	[Table("UnitedFrontMilitia")]
    public class UnitedFrontMilitia 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string UFMFullName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string UFMIdCardNo { get; set; }
			
        /// <summary>
        ///  上级领导 
        /// </summary>
        public string UFMSuperiorLeader { get; set; }
			
        /// <summary>
        ///  所属番号 
        /// </summary>
        public string UFMDesignation { get; set; }
			
        /// <summary>
        ///  民兵类型 
        /// </summary>
        public string UFMMilitiaType { get; set; }
	}

	
    /// <summary>
    ///  厂房楼栋 
    /// </summary>
	[Table("FactoryBuilding")]
    public class FactoryBuilding 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  工业园名称 
        /// </summary>
        public string FBNameOfIndustrialPark { get; set; }
			
        /// <summary>
        ///  序号 
        /// </summary>
        public string FBSerialNumber { get; set; }
			
        /// <summary>
        ///  承租户 
        /// </summary>
        public string FBTenant { get; set; }
			
        /// <summary>
        ///  起止 
        /// </summary>
        public string FBStartStop { get; set; }
			
        /// <summary>
        ///  承租面积 
        /// </summary>
        public Nullable<Single> FBLesseeArea { get; set; }
			
        /// <summary>
        ///  押金 
        /// </summary>
        public string FBDeposit { get; set; }
			
        /// <summary>
        ///  单价 
        /// </summary>
        public string FBUnitPrice { get; set; }
			
        /// <summary>
        ///  月租金 
        /// </summary>
        public string FBMonthlyRent { get; set; }
			
        /// <summary>
        ///  年租金 
        /// </summary>
        public string FBAnnualRent { get; set; }
			
        /// <summary>
        ///  租凭单位性质 
        /// </summary>
        public string FBCharteredUnitNature { get; set; }
			
        /// <summary>
        ///  环保手续 
        /// </summary>
        public string FBEnvironmentalProtectionProcedures { get; set; }
			
        /// <summary>
        ///  建筑面积 
        /// </summary>
        public Nullable<Single> FBBuiltupArea { get; set; }
			
        /// <summary>
        ///  开始时间 
        /// </summary>
        public Nullable<DateTime> FBStartTime { get; set; }
			
        /// <summary>
        ///  结束时间 
        /// </summary>
        public Nullable<DateTime> FBEndingTime { get; set; }
			
        /// <summary>
        ///  联系人 
        /// </summary>
        public string FBContacts { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string FBContactNumber { get; set; }
			
        /// <summary>
        ///  审批文件 
        /// </summary>
        public string FBApprovalDocument { get; set; }
			
        /// <summary>
        ///  楼号 
        /// </summary>
        public string FBBuildingNumber { get; set; }
			
        /// <summary>
        ///  单元号 
        /// </summary>
        public string FBUnitNumber { get; set; }
			
        /// <summary>
        ///  门牌号 
        /// </summary>
        public string FBHouseNumber { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string FBPersonInCharge { get; set; }
			
        /// <summary>
        ///  负责人联系方式 
        /// </summary>
        public string FBContactInformationOfPersonInCharge { get; set; }
			
        /// <summary>
        ///  范围 
        /// </summary>
        public string FBRange { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string FBRemarks { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string FBAddress { get; set; }
			
        /// <summary>
        ///  工业园房屋收款 
        /// </summary>
        // public List<IndustrialParkHousingReceipt> IndustrialParkHousingReceipt { get; set; }
	}

	
    /// <summary>
    ///  收租记录 
    /// </summary>
	[Table("RentCollectionRecords")]
    public class RentCollectionRecords 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  企业名称 
        /// </summary>
        public string RCREnterpriseName { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string RCRPersonInCharge { get; set; }
			
        /// <summary>
        ///  负责人电话 
        /// </summary>
        public string RCRTelephoneCallsFromThePersonInCharge { get; set; }
			
        /// <summary>
        ///  付款金额 
        /// </summary>
        public Nullable<decimal> RCRPaymentAmount { get; set; }
			
        /// <summary>
        ///  收款人 
        /// </summary>
        public string RCRPayee { get; set; }
			
        /// <summary>
        ///  收款人电话 
        /// </summary>
        public string RCRCashiersTelephone { get; set; }
			
        /// <summary>
        ///  收款金额 
        /// </summary>
        public Nullable<decimal> RCRAmountCollected { get; set; }
			
        /// <summary>
        ///  收款时间 
        /// </summary>
        public Nullable<DateTime> RCRCollectionTime { get; set; }
			
        /// <summary>
        ///  应收款时间 
        /// </summary>
        public Nullable<DateTime> RCRTimeOfReceivables { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string RCRRemarks { get; set; }
			
        /// <summary>
        ///  工业园名称 
        /// </summary>
        public string RCRNameOfIndustrialPark { get; set; }
	}

	
    /// <summary>
    ///  电费缴纳记录 
    /// </summary>
	[Table("ElectricityChargePaymentRecord")]
    public class ElectricityChargePaymentRecord 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  企业名称 
        /// </summary>
        public string ECPREnterpriseName { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string ECPRPersonInCharge { get; set; }
			
        /// <summary>
        ///  负责人电话 
        /// </summary>
        public string ECPRTelephoneCallsFromThePersonInCharge { get; set; }
			
        /// <summary>
        ///  付款金额 
        /// </summary>
        public Nullable<decimal> ECPRPaymentAmount { get; set; }
			
        /// <summary>
        ///  收款人 
        /// </summary>
        public string ECPRPayee { get; set; }
			
        /// <summary>
        ///  收款人电话 
        /// </summary>
        public string ECPRCashiersTelephone { get; set; }
			
        /// <summary>
        ///  收款金额 
        /// </summary>
        public Nullable<decimal> ECPRAmountCollected { get; set; }
			
        /// <summary>
        ///  收款时间 
        /// </summary>
        public Nullable<DateTime> ECPRCollectionTime { get; set; }
			
        /// <summary>
        ///  应收款时间 
        /// </summary>
        public Nullable<DateTime> ECPRTimeOfReceivables { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string ECPRRemarks { get; set; }
	}

	
    /// <summary>
    ///  工作日志 
    /// </summary>
	[Table("JobDiary")]
    public class JobDiary 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  序号 
        /// </summary>
        public string JDSerialNumber { get; set; }
			
        /// <summary>
        ///  条线 
        /// </summary>
        public string JDStripe { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string JDPersonInCharge { get; set; }
			
        /// <summary>
        ///  日期 
        /// </summary>
        public Nullable<DateTime> JDDate { get; set; }
			
        /// <summary>
        ///  办理事项 
        /// </summary>
        public string JDProcessingMatters { get; set; }
			
        /// <summary>
        ///  是否完成 
        /// </summary>
        public string JDIsItFinished { get; set; }
			
        /// <summary>
        ///  完成时间 
        /// </summary>
        public Nullable<DateTime> JDCompletionTime { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string JDRemarks { get; set; }
	}

	
    /// <summary>
    ///  通知 
    /// </summary>
	[Table("Notice")]
    public class Notice 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string NTitle { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string NContent { get; set; }
			
        /// <summary>
        ///  作者 
        /// </summary>
        public string NAuthor { get; set; }
			
        /// <summary>
        ///  通知发送日期 
        /// </summary>
        public Nullable<DateTime> NNotificationOfDateOfDispatch { get; set; }
			
        /// <summary>
        ///  通知发送对象 
        /// </summary>
        public string NNotificationSenderObject { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string NRemarks { get; set; }
			
        /// <summary>
        ///  摘要 
        /// </summary>
        public string NAbstract { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string NPicture { get; set; }
	}

	
    /// <summary>
    ///  文档管理 
    /// </summary>
	[Table("DocumentManagement")]
    public class DocumentManagement 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string DMTitle { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string DMContent { get; set; }
			
        /// <summary>
        ///  作者 
        /// </summary>
        public string DMAuthor { get; set; }
			
        /// <summary>
        ///  原件图片 
        /// </summary>
        public string DMOriginalPicture { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string DMRemarks { get; set; }
	}

	
    /// <summary>
    ///  人口 
    /// </summary>
	[Table("Population")]
    public class Population 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  公民身份号码 
        /// </summary>
        public string PCitizenshipNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string PFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string PGender { get; set; }
			
        /// <summary>
        ///  出生日期 
        /// </summary>
        public Nullable<DateTime> PDateOfBirth { get; set; }
			
        /// <summary>
        ///  居村委会 
        /// </summary>
        public string PNeighborhoodVillageCommittee { get; set; }
			
        /// <summary>
        ///  住址 
        /// </summary>
        public string PAddress { get; set; }
			
        /// <summary>
        ///  年龄 
        /// </summary>
        public Nullable<int> PAge { get; set; }
	}

	
    /// <summary>
    ///  新生儿 
    /// </summary>
	[Table("Newborn")]
    public class Newborn 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  公民身份号码 
        /// </summary>
        public string NCitizenshipNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string NFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string NGender { get; set; }
			
        /// <summary>
        ///  出生日期 
        /// </summary>
        public Nullable<DateTime> NDateOfBirth { get; set; }
			
        /// <summary>
        ///  居村委会 
        /// </summary>
        public string NNeighborhoodVillageCommittee { get; set; }
			
        /// <summary>
        ///  住址 
        /// </summary>
        public string NAddress { get; set; }
			
        /// <summary>
        ///  年龄 
        /// </summary>
        public Nullable<int> NAge { get; set; }
	}

	
    /// <summary>
    ///  房产 
    /// </summary>
	[Table("HouseProperty")]
    public class HouseProperty 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string HPId { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string HPAddress { get; set; }
			
        /// <summary>
        ///  楼栋号 
        /// </summary>
        public string HPBuildingNumber { get; set; }
			
        /// <summary>
        ///  单元号 
        /// </summary>
        public string HPUnitNumber { get; set; }
			
        /// <summary>
        ///  门牌号 
        /// </summary>
        public string HPHouseNumber { get; set; }
	}

	
    /// <summary>
    ///  报销清单 
    /// </summary>
	[Table("ReimbursementList")]
    public class ReimbursementList 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string RLFullName { get; set; }
			
        /// <summary>
        ///  出发位置 
        /// </summary>
        public string RLStartingPosition { get; set; }
			
        /// <summary>
        ///  目的地位置 
        /// </summary>
        public string RLDestinationLocation { get; set; }
			
        /// <summary>
        ///  交通费 
        /// </summary>
        public string RLTrafficExpense { get; set; }
			
        /// <summary>
        ///  住宿费 
        /// </summary>
        public string RLHotelExpense { get; set; }
			
        /// <summary>
        ///  住勤补贴 
        /// </summary>
        public string RLAccommodationAllowance { get; set; }
			
        /// <summary>
        ///  公交费 
        /// </summary>
        public string RLBusFare { get; set; }
			
        /// <summary>
        ///  报销日期 
        /// </summary>
        public Nullable<DateTime> RLDateOfReimbursement { get; set; }
	}

	
    /// <summary>
    ///  通讯录 
    /// </summary>
	[Table("MailList")]
    public class MailList 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  机构名称 
        /// </summary>
        public string MLOrganizationName { get; set; }
			
        /// <summary>
        ///  人员姓名 
        /// </summary>
        public string MLPersonnelName { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string MLId { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string MLGender { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string MLTelephone { get; set; }
			
        /// <summary>
        ///  手机 
        /// </summary>
        public string MLMobilePhone { get; set; }
			
        /// <summary>
        ///  邮箱 
        /// </summary>
        public string MLMailbox { get; set; }
			
        /// <summary>
        ///  职位 
        /// </summary>
        public string MLPosition { get; set; }
			
        /// <summary>
        ///  上级领导 
        /// </summary>
        public string MLSuperiorLeader { get; set; }
			
        /// <summary>
        ///  QQ 
        /// </summary>
        public string MLQq { get; set; }
			
        /// <summary>
        ///  微信 
        /// </summary>
        public string MLWechat { get; set; }
	}

	
    /// <summary>
    ///  Poi 
    /// </summary>
	[Table("Poi")]
    public class Poi 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string PAddress { get; set; }
	}

	
    /// <summary>
    ///  党建要闻管理 
    /// </summary>
	[Table("ManagementOfPartyBuildingNews")]
    public class ManagementOfPartyBuildingNews 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string MOPBNTitle { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string MOPBNContent { get; set; }
			
        /// <summary>
        ///  作者 
        /// </summary>
        public string MOPBNAuthor { get; set; }
			
        /// <summary>
        ///  发布时间 
        /// </summary>
        public Nullable<DateTime> MOPBNReleaseTime { get; set; }
			
        /// <summary>
        ///  类别 
        /// </summary>
        public string MOPBNCategory { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string MOPBNPicture { get; set; }
	}

	
    /// <summary>
    ///  随手拍 
    /// </summary>
	[Table("FreeToShoot")]
    public class FreeToShoot 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string FTSContent { get; set; }
			
        /// <summary>
        ///  设备 
        /// </summary>
        public string FTSEquipment { get; set; }
			
        /// <summary>
        ///  用户ID 
        /// </summary>
        public string FTSUserId { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string FTSPhoto { get; set; }
			
        /// <summary>
        ///  拍照时间 
        /// </summary>
        public Nullable<DateTime> FTSPhotoop { get; set; }
			
        /// <summary>
        ///  位置 
        /// </summary>
        public string FTSPosition { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string FTSFullName { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string FTSTelephone { get; set; }
			
        /// <summary>
        ///  区域 
        /// </summary>
        public string FTSRegion { get; set; }
			
        /// <summary>
        ///  点赞数目 
        /// </summary>
        public string FTSNumberOfPoints { get; set; }
	}

	
    /// <summary>
    ///  主动巡检 
    /// </summary>
	[Table("ActiveInspection")]
    public class ActiveInspection 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  巡检问题 
        /// </summary>
        public string AIInspectionProblem { get; set; }
			
        /// <summary>
        ///  创建时间 
        /// </summary>
        public Nullable<DateTime> AICreationTime { get; set; }
			
        /// <summary>
        ///  状态 
        /// </summary>
        public string AIState { get; set; }
			
        /// <summary>
        ///  用户 
        /// </summary>
        public string AIUser { get; set; }
			
        /// <summary>
        ///  区域 
        /// </summary>
        public string AIRegion { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string AIPicture { get; set; }
			
        /// <summary>
        ///  位置 
        /// </summary>
        public string AIPosition { get; set; }
	}

	
    /// <summary>
    ///  业务预约 
    /// </summary>
	[Table("BusinessAppointment")]
    public class BusinessAppointment 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  业务 
        /// </summary>
        public string BABusiness { get; set; }
			
        /// <summary>
        ///  服务 
        /// </summary>
        public string BAService { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string BAFullName { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string BAId { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string BATelephone { get; set; }
			
        /// <summary>
        ///  创建时间 
        /// </summary>
        public Nullable<DateTime> BACreationTime { get; set; }
			
        /// <summary>
        ///  受理时间 
        /// </summary>
        public Nullable<DateTime> BAAcceptanceTime { get; set; }
			
        /// <summary>
        ///  状态 
        /// </summary>
        public string BAState { get; set; }
	}

	
    /// <summary>
    ///  提建议记录 
    /// </summary>
	[Table("RecordOfRecommendations")]
    public class RecordOfRecommendations 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string RORTitle { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string RORContent { get; set; }
			
        /// <summary>
        ///  对象 
        /// </summary>
        public string RORObject { get; set; }
			
        /// <summary>
        ///  处理人 
        /// </summary>
        public string RORDealingWithPeople { get; set; }
			
        /// <summary>
        ///  处理日期 
        /// </summary>
        public Nullable<DateTime> RORDateOfProcessing { get; set; }
	}

	
    /// <summary>
    ///  党风廉政学习 
    /// </summary>
	[Table("StudyOnPartyStyleAndCleanGovernment")]
    public class StudyOnPartyStyleAndCleanGovernment 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string SOPSACGTitle { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string SOPSACGContent { get; set; }
			
        /// <summary>
        ///  学习对象 
        /// </summary>
        public string SOPSACGLearningObject { get; set; }
			
        /// <summary>
        ///  学习日期 
        /// </summary>
        public Nullable<DateTime> SOPSACGLearningDate { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string SOPSACGRemarks { get; set; }
	}

	
    /// <summary>
    ///  公共设施 
    /// </summary>
	[Table("CommunalFacilities")]
    public class CommunalFacilities 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  名称 
        /// </summary>
        public string CFName { get; set; }
			
        /// <summary>
        ///  位置 
        /// </summary>
        public string CFPosition { get; set; }
			
        /// <summary>
        ///  类型 
        /// </summary>
        public string CFType { get; set; }
			
        /// <summary>
        ///  归属 
        /// </summary>
        public string CFAscription { get; set; }
			
        /// <summary>
        ///  换新日期 
        /// </summary>
        public Nullable<DateTime> CFRenewalDate { get; set; }
			
        /// <summary>
        ///  是否损坏 
        /// </summary>
        public string CFIsItDamaged { get; set; }
	}

	
    /// <summary>
    ///  系统配置 
    /// </summary>
	[Table("SystemConfiguration")]
    public class SystemConfiguration 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string SCTitle { get; set; }
			
        /// <summary>
        ///  分类 
        /// </summary>
        public string SCClassification { get; set; }
			
        /// <summary>
        ///  子分类 
        /// </summary>
        public string SCSubClassification { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string SCContent { get; set; }
			
        /// <summary>
        ///  是否生效 
        /// </summary>
        public string SCIsItEffective { get; set; }
	}

	
    /// <summary>
    ///  党建 
    /// </summary>
	[Table("PartyBuilding")]
    public class PartyBuilding 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string PBTitle { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string PBContent { get; set; }
			
        /// <summary>
        ///  发布时间 
        /// </summary>
        public Nullable<DateTime> PBReleaseTime { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string PBRemarks { get; set; }
	}

	
    /// <summary>
    ///  党费缴纳管理 
    /// </summary>
	[Table("ManagementOfPartyFeePayment")]
    public class ManagementOfPartyFeePayment 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string MOPFPFullName { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string MOPFPTelephone { get; set; }
			
        /// <summary>
        ///  金额 
        /// </summary>
        public Nullable<decimal> MOPFPAmountOfMoney { get; set; }
			
        /// <summary>
        ///  日期 
        /// </summary>
        public Nullable<DateTime> MOPFPDate { get; set; }
			
        /// <summary>
        ///  收款人 
        /// </summary>
        public string MOPFPPayee { get; set; }
			
        /// <summary>
        ///  所属支部 
        /// </summary>
        public string MOPFPSubordinateBranch { get; set; }
	}

	
    /// <summary>
    ///  合同管理 
    /// </summary>
	[Table("ContractManagement")]
    public class ContractManagement 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  合同编号 
        /// </summary>
        public string CMContractNumber { get; set; }
			
        /// <summary>
        ///  合同名称 
        /// </summary>
        public string CMContractName { get; set; }
			
        /// <summary>
        ///  项目名称 
        /// </summary>
        public string CMEntryName { get; set; }
			
        /// <summary>
        ///  甲方签名 
        /// </summary>
        public string CMSignatureOfPartya { get; set; }
			
        /// <summary>
        ///  乙方签名 
        /// </summary>
        public string CMSignatureOfPartyb { get; set; }
			
        /// <summary>
        ///  丙方签名 
        /// </summary>
        public string CMSignatureOfPartyc { get; set; }
			
        /// <summary>
        ///  签署日期 
        /// </summary>
        public Nullable<DateTime> CMSigningDate { get; set; }
			
        /// <summary>
        ///  签署机构 
        /// </summary>
        public string CMSignatory { get; set; }
			
        /// <summary>
        ///  合同文件上传 
        /// </summary>
        public string CMUploadContractDocuments { get; set; }
	}

	
    /// <summary>
    ///  个人信息 
    /// </summary>
	[Table("PersonalInformation")]
    public class PersonalInformation 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  登录名 
        /// </summary>
        public string PILoginName { get; set; }
			
        /// <summary>
        ///  昵称 
        /// </summary>
        public string PINickname { get; set; }
			
        /// <summary>
        ///  真实姓名 
        /// </summary>
        public string PIRealName { get; set; }
			
        /// <summary>
        ///  密码 
        /// </summary>
        public string PIPassword { get; set; }
			
        /// <summary>
        ///  头像 
        /// </summary>
        public string PIHeadPortrait { get; set; }
			
        /// <summary>
        ///  上次登录时间 
        /// </summary>
        public Nullable<DateTime> PILastLogonTime { get; set; }
			
        /// <summary>
        ///  所属部门 
        /// </summary>
        public string PISubordinateDepartments { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string PITelephone { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string PIPhoto { get; set; }
	}

	
    /// <summary>
    ///  日程工作 
    /// </summary>
	[Table("ScheduleWork")]
    public class ScheduleWork 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string SWTitle { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string SWContent { get; set; }
			
        /// <summary>
        ///  地点 
        /// </summary>
        public string SWPlace { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string SWPersonInCharge { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string SWTelephone { get; set; }
			
        /// <summary>
        ///  开始时间 
        /// </summary>
        public Nullable<DateTime> SWStartTime { get; set; }
			
        /// <summary>
        ///  结束时间 
        /// </summary>
        public Nullable<DateTime> SWEndingTime { get; set; }
	}

	
    /// <summary>
    ///  党建专题 
    /// </summary>
	[Table("SpecialTopicOnPartyBuilding")]
    public class SpecialTopicOnPartyBuilding 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string STOPBTitle { get; set; }
			
        /// <summary>
        ///  预览 
        /// </summary>
        public string STOPBPreview { get; set; }
			
        /// <summary>
        ///  发布时间 
        /// </summary>
        public Nullable<DateTime> STOPBReleaseTime { get; set; }
			
        /// <summary>
        ///  查看 
        /// </summary>
        public string STOPBSee { get; set; }
	}

	
    /// <summary>
    ///  办事指南 
    /// </summary>
	[Table("BusinessGuide")]
    public class BusinessGuide 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  类别 
        /// </summary>
        public string BGCategory { get; set; }
			
        /// <summary>
        ///  办事内容 
        /// </summary>
        public string BGContentOfWork { get; set; }
			
        /// <summary>
        ///  所需材料 
        /// </summary>
        public string BGRequiredMaterials { get; set; }
			
        /// <summary>
        ///  办事程序 
        /// </summary>
        public string BGProcedure { get; set; }
	}

	
    /// <summary>
    ///  党务指南 
    /// </summary>
	[Table("PartyAffairsGuide")]
    public class PartyAffairsGuide 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string PAGTitle { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string PAGContent { get; set; }
			
        /// <summary>
        ///  类别 
        /// </summary>
        public string PAGCategory { get; set; }
			
        /// <summary>
        ///  适用范围 
        /// </summary>
        public string PAGScopeOfApplication { get; set; }
	}

	
    /// <summary>
    ///  业务管理 
    /// </summary>
	[Table("BusinessManagement")]
    public class BusinessManagement 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  业务类型 
        /// </summary>
        public string BMBusinessType { get; set; }
			
        /// <summary>
        ///  服务类型 
        /// </summary>
        public string BMServiceType { get; set; }
			
        /// <summary>
        ///  申请人 
        /// </summary>
        public string BMApplicant { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string BMId { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string BMGender { get; set; }
			
        /// <summary>
        ///  大厅受理时间 
        /// </summary>
        public Nullable<DateTime> BMHallAcceptanceTime { get; set; }
			
        /// <summary>
        ///  经办人 
        /// </summary>
        public string BMAgent { get; set; }
			
        /// <summary>
        ///  创建时间 
        /// </summary>
        public Nullable<DateTime> BMCreationTime { get; set; }
			
        /// <summary>
        ///  状态 
        /// </summary>
        public string BMState { get; set; }
	}

	
    /// <summary>
    ///  少儿医保 
    /// </summary>
	[Table("MedicalInsuranceForChildren")]
    public class MedicalInsuranceForChildren 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  单位编号 
        /// </summary>
        public string MIFCUnitNumber { get; set; }
			
        /// <summary>
        ///  人员编号 
        /// </summary>
        public string MIFCPersonnelNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string MIFCFullName { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string MIFCId { get; set; }
			
        /// <summary>
        ///  出生日期 
        /// </summary>
        public Nullable<DateTime> MIFCDateOfBirth { get; set; }
			
        /// <summary>
        ///  免缴种类 
        /// </summary>
        public string MIFCExemptionCategory { get; set; }
			
        /// <summary>
        ///  免缴号码 
        /// </summary>
        public string MIFCExemptionNumber { get; set; }
			
        /// <summary>
        ///  联系人 
        /// </summary>
        public string MIFCContacts { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string MIFCContactNumber { get; set; }
	}

	
    /// <summary>
    ///  农村医疗 
    /// </summary>
	[Table("RuralMedicalTreatment")]
    public class RuralMedicalTreatment 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  人员编号 
        /// </summary>
        public string RMTPersonnelNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string RMTFullName { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string RMTId { get; set; }
			
        /// <summary>
        ///  免缴种类 
        /// </summary>
        public string RMTExemptionCategory { get; set; }
			
        /// <summary>
        ///  免缴号码 
        /// </summary>
        public string RMTExemptionNumber { get; set; }
			
        /// <summary>
        ///  联系人 
        /// </summary>
        public string RMTContacts { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string RMTContactNumber { get; set; }
			
        /// <summary>
        ///  区域 
        /// </summary>
        public string RMTRegion { get; set; }
			
        /// <summary>
        ///  操作 
        /// </summary>
        public string RMTOperation { get; set; }
	}

	
    /// <summary>
    ///  福利发放 
    /// </summary>
	[Table("WelfarePayment")]
    public class WelfarePayment 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string WPFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string WPGender { get; set; }
			
        /// <summary>
        ///  年龄 
        /// </summary>
        public Nullable<int> WPAge { get; set; }
			
        /// <summary>
        ///  身份证号 
        /// </summary>
        public string WPIdNumber { get; set; }
			
        /// <summary>
        ///  福利类型 
        /// </summary>
        public string WPWelfareType { get; set; }
			
        /// <summary>
        ///  发放金额 
        /// </summary>
        public Nullable<decimal> WPPaymentAmount { get; set; }
			
        /// <summary>
        ///  发放日期 
        /// </summary>
        public Nullable<DateTime> WPDateOfIssue { get; set; }
			
        /// <summary>
        ///  被保人id 
        /// </summary>
        public string WPInsuredId { get; set; }
			
        /// <summary>
        ///  住址 
        /// </summary>
        public string WPAddress { get; set; }
			
        /// <summary>
        ///  区域 
        /// </summary>
        public string WPRegion { get; set; }
			
        /// <summary>
        ///  操作 
        /// </summary>
        public string WPOperation { get; set; }
	}

	
    /// <summary>
    ///  服务预约 
    /// </summary>
	[Table("ServiceAppointment")]
    public class ServiceAppointment 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  服务类型 
        /// </summary>
        public string SAServiceType { get; set; }
			
        /// <summary>
        ///  预约人 
        /// </summary>
        public string SAAppointments { get; set; }
			
        /// <summary>
        ///  预约时间 
        /// </summary>
        public Nullable<DateTime> SATimeOfAppointment { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string SAId { get; set; }
			
        /// <summary>
        ///  创建时间 
        /// </summary>
        public Nullable<DateTime> SACreationTime { get; set; }
			
        /// <summary>
        ///  审核时间 
        /// </summary>
        public Nullable<DateTime> SAAuditTime { get; set; }
			
        /// <summary>
        ///  状态 
        /// </summary>
        public string SAState { get; set; }
			
        /// <summary>
        ///  审核登记 
        /// </summary>
        public string SAAuditRegistration { get; set; }
	}

	
    /// <summary>
    ///  日程管理 
    /// </summary>
	[Table("ScheduleManagement")]
    public class ScheduleManagement 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  活动类型 
        /// </summary>
        public string SMActivityType { get; set; }
			
        /// <summary>
        ///  开始日期 
        /// </summary>
        public Nullable<DateTime> SMStartDate { get; set; }
			
        /// <summary>
        ///  结束日期 
        /// </summary>
        public Nullable<DateTime> SMEndDate { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string SMContent { get; set; }
			
        /// <summary>
        ///  地点 
        /// </summary>
        public string SMPlace { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string SMPersonInCharge { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string SMTelephone { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string SMRemarks { get; set; }
	}

	
    /// <summary>
    ///  专家管理 
    /// </summary>
	[Table("ExpertManagement")]
    public class ExpertManagement 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  技术特长 
        /// </summary>
        public string EMTechnicalExpertise { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string EMFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string EMGender { get; set; }
			
        /// <summary>
        ///  出生日期 
        /// </summary>
        public Nullable<DateTime> EMDateOfBirth { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string EMId { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string EMAddress { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string EMContactNumber { get; set; }
	}

	
    /// <summary>
    ///  权限访问 
    /// </summary>
	[Table("PermissionAccess")]
    public class PermissionAccess 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string PAFullName { get; set; }
			
        /// <summary>
        ///  访问时间 
        /// </summary>
        public Nullable<DateTime> PAAccessTime { get; set; }
	}

	
    /// <summary>
    ///  便民指南 
    /// </summary>
	[Table("ConvenienceGuide")]
    public class ConvenienceGuide 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string CGTitle { get; set; }
			
        /// <summary>
        ///  发布时间 
        /// </summary>
        public Nullable<DateTime> CGReleaseTime { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string CGPicture { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string CGContent { get; set; }
			
        /// <summary>
        ///  摘要 
        /// </summary>
        public string CGAbstract { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string CGRemarks { get; set; }
	}

	
    /// <summary>
    ///  便民生活 
    /// </summary>
	[Table("ConvenientLife")]
    public class ConvenientLife 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string CLTitle { get; set; }
			
        /// <summary>
        ///  发布时间 
        /// </summary>
        public Nullable<DateTime> CLReleaseTime { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string CLPicture { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string CLContent { get; set; }
			
        /// <summary>
        ///  摘要 
        /// </summary>
        public string CLAbstract { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string CLRemarks { get; set; }
	}

	
    /// <summary>
    ///  香溪特色 
    /// </summary>
	[Table("CharacteristicOfXiangxi")]
    public class CharacteristicOfXiangxi 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string COXTitle { get; set; }
			
        /// <summary>
        ///  发布时间 
        /// </summary>
        public Nullable<DateTime> COXReleaseTime { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string COXPicture { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string COXContent { get; set; }
			
        /// <summary>
        ///  摘要 
        /// </summary>
        public string COXAbstract { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string COXRemarks { get; set; }
	}

	
    /// <summary>
    ///  建议处理 
    /// </summary>
	[Table("ProposedTreatment")]
    public class ProposedTreatment 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string PTTitle { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string PTContent { get; set; }
			
        /// <summary>
        ///  对象 
        /// </summary>
        public string PTObject { get; set; }
			
        /// <summary>
        ///  处理人 
        /// </summary>
        public string PTDealingWithPeople { get; set; }
			
        /// <summary>
        ///  处理日期 
        /// </summary>
        public Nullable<DateTime> PTDateOfProcessing { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string PTFullName { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string PTId { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string PTTelephone { get; set; }
			
        /// <summary>
        ///  创建时间 
        /// </summary>
        public Nullable<DateTime> PTCreationTime { get; set; }
			
        /// <summary>
        ///  状态 
        /// </summary>
        public string PTState { get; set; }
	}

	
    /// <summary>
    ///  村史 
    /// </summary>
	[Table("VillageHistory")]
    public class VillageHistory 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  菜单项 
        /// </summary>
        public string VHMenuItem { get; set; }
			
        /// <summary>
        ///  主标题 
        /// </summary>
        public string VHMainTitle { get; set; }
			
        /// <summary>
        ///  副标题 
        /// </summary>
        public string VHSubheading { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string VHPicture { get; set; }
			
        /// <summary>
        ///  摘要 
        /// </summary>
        public string VHAbstract { get; set; }
	}

	
    /// <summary>
    ///  专项工作 
    /// </summary>
	[Table("SpecialWork")]
    public class SpecialWork 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  工作主题 
        /// </summary>
        public string SWWorkTheme { get; set; }
			
        /// <summary>
        ///  工作内容 
        /// </summary>
        public string SWJobContent { get; set; }
			
        /// <summary>
        ///  开始日期 
        /// </summary>
        public Nullable<DateTime> SWStartDate { get; set; }
			
        /// <summary>
        ///  结束日期 
        /// </summary>
        public Nullable<DateTime> SWEndDate { get; set; }
			
        /// <summary>
        ///  状态 
        /// </summary>
        public string SWState { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string SWPhoto { get; set; }
	}

	
    /// <summary>
    ///  视频点位信息 
    /// </summary>
	[Table("VideoPointInformation")]
    public class VideoPointInformation 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  序号 
        /// </summary>
        public string VPISerialNumber { get; set; }
			
        /// <summary>
        ///  监控点名称 
        /// </summary>
        public string VPIMonitoringPointName { get; set; }
			
        /// <summary>
        ///  监控点编号 
        /// </summary>
        public string VPIMonitoringPointNumber { get; set; }
			
        /// <summary>
        ///  所属组织 
        /// </summary>
        public string VPIAffiliatedOrganization { get; set; }
			
        /// <summary>
        ///  所属区域 
        /// </summary>
        public string VPIAreasToWhichTheyBelong { get; set; }
			
        /// <summary>
        ///  所属平台 
        /// </summary>
        public string VPISubordinatePlatform { get; set; }
			
        /// <summary>
        ///  经度 
        /// </summary>
        public string VPILongitude { get; set; }
			
        /// <summary>
        ///  纬度 
        /// </summary>
        public string VPILatitude { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string VPIAddress { get; set; }
	}

	
    /// <summary>
    ///  就业援助 
    /// </summary>
	[Table("EmploymentAssistance")]
    public class EmploymentAssistance 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  个人编号 
        /// </summary>
        public string EAPersonalNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string EAFullName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string EAIdCardNo { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string EAGender { get; set; }
			
        /// <summary>
        ///  民族 
        /// </summary>
        public string EANation { get; set; }
			
        /// <summary>
        ///  年龄 
        /// </summary>
        public Nullable<int> EAAge { get; set; }
			
        /// <summary>
        ///  文化程度 
        /// </summary>
        public string EADegreeOfEducation { get; set; }
			
        /// <summary>
        ///  户口性质 
        /// </summary>
        public string EAAccountCharacter { get; set; }
			
        /// <summary>
        ///  是否残疾 
        /// </summary>
        public string EAIsItDisabled { get; set; }
			
        /// <summary>
        ///  培训意愿 
        /// </summary>
        public string EATrainingIntention { get; set; }
			
        /// <summary>
        ///  联系方式 
        /// </summary>
        public string EAContactInformation { get; set; }
			
        /// <summary>
        ///  人员类型 
        /// </summary>
        public string EAPersonnelType { get; set; }
			
        /// <summary>
        ///  就业形式 
        /// </summary>
        public string EAFormOfEmployment { get; set; }
			
        /// <summary>
        ///  内容1 
        /// </summary>
        public string EAContent1 { get; set; }
			
        /// <summary>
        ///  内容2 
        /// </summary>
        public string EAContent2 { get; set; }
			
        /// <summary>
        ///  内容3 
        /// </summary>
        public string EAContent3 { get; set; }
			
        /// <summary>
        ///  内容4 
        /// </summary>
        public string EAContent4 { get; set; }
	}

	
    /// <summary>
    ///  危房解危 
    /// </summary>
	[Table("DangerousHousing")]
    public class DangerousHousing 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  所有权人 
        /// </summary>
        public string DHOwner { get; set; }
			
        /// <summary>
        ///  房屋座落 
        /// </summary>
        public string DHHousingLocation { get; set; }
			
        /// <summary>
        ///  房产证面积 
        /// </summary>
        public Nullable<Single> DHRealEstateCertificateArea { get; set; }
			
        /// <summary>
        ///  土地证面积 
        /// </summary>
        public Nullable<Single> DHLandCertificateArea { get; set; }
			
        /// <summary>
        ///  测绘面积 
        /// </summary>
        public Nullable<Single> DHMappingArea { get; set; }
			
        /// <summary>
        ///  测绘增补面积 
        /// </summary>
        public Nullable<Single> DHSupplementaryAreaOfSurveyingAndMapping { get; set; }
			
        /// <summary>
        ///  安置面积 
        /// </summary>
        public Nullable<Single> DHResettlementArea { get; set; }
			
        /// <summary>
        ///  签字时间 
        /// </summary>
        public Nullable<DateTime> DHSignatureTime { get; set; }
			
        /// <summary>
        ///  交房时间 
        /// </summary>
        public Nullable<DateTime> DHTimeOfDelivery { get; set; }
			
        /// <summary>
        ///  补偿金额 
        /// </summary>
        public Nullable<decimal> DHCompensationAmount { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string DHContactNumber { get; set; }
			
        /// <summary>
        ///  现居住地址 
        /// </summary>
        public string DHCurrentResidentialAddress { get; set; }
	}

	
    /// <summary>
    ///  工业园房屋收款 
    /// </summary>
	[Table("IndustrialParkHousingReceipt")]
    public class IndustrialParkHousingReceipt 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  @厂房楼栋 
        /// </summary>
        public string IPHRFactoryBuilding { get; set; }
			
        /// <summary>
        ///  开始时间 
        /// </summary>
        public Nullable<DateTime> IPHRStartTime { get; set; }
			
        /// <summary>
        ///  结束时间 
        /// </summary>
        public Nullable<DateTime> IPHREndingTime { get; set; }
			
        /// <summary>
        ///  付款金额 
        /// </summary>
        public Nullable<decimal> IPHRPaymentAmount { get; set; }
	}

	
    /// <summary>
    ///  需求收集 
    /// </summary>
	[Table("DemandCollection")]
    public class DemandCollection 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  您需要什么内容 
        /// </summary>
        public string DCWhatDoYouNeed { get; set; }
			
        /// <summary>
        ///  期望交付时间 
        /// </summary>
        public Nullable<DateTime> DCExpectedDeliveryTime { get; set; }
			
        /// <summary>
        ///  您的姓名 
        /// </summary>
        public string DCYourName { get; set; }
			
        /// <summary>
        ///  您的联系方式 
        /// </summary>
        public string DCYourContactInformation { get; set; }
	}

	
    /// <summary>
    ///  党组织信息管理 
    /// </summary>
	[Table("InformationManagementOfPartyOrganizations")]
    public class InformationManagementOfPartyOrganizations 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  党组织名称 
        /// </summary>
        public string IMOPONameOfPartyOrganization { get; set; }
			
        /// <summary>
        ///  党组织书记 
        /// </summary>
        public string IMOPOSecretaryOfPartyOrganization { get; set; }
			
        /// <summary>
        ///  党组织联系人 
        /// </summary>
        public string IMOPOPartyOrganizationContacts { get; set; }
			
        /// <summary>
        ///  党组织联系电话 
        /// </summary>
        public string IMOPOPartyOrganizationContactTelephone { get; set; }
			
        /// <summary>
        ///  组织类别 
        /// </summary>
        public string IMOPOOrganizationCategory { get; set; }
			
        /// <summary>
        ///  上级党组织名称 
        /// </summary>
        public string IMOPONameOfPartyOrganizationAtHigherLevel { get; set; }
			
        /// <summary>
        ///  党组织书记公民身份号码 
        /// </summary>
        public string IMOPOCitizenshipNumberOfPartyOrganizationSecretary { get; set; }
	}

	
    /// <summary>
    ///  关爱对象 
    /// </summary>
	[Table("CareForTheObject")]
    public class CareForTheObject 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string CFTOFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string CFTOGender { get; set; }
			
        /// <summary>
        ///  类型 
        /// </summary>
        public string CFTOType { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string CFTOId { get; set; }
			
        /// <summary>
        ///  户口所在地 
        /// </summary>
        public string CFTORegisteredResidence { get; set; }
			
        /// <summary>
        ///  常住地 
        /// </summary>
        public string CFTOPermanentResidence { get; set; }
			
        /// <summary>
        ///  楼栋号 
        /// </summary>
        public string CFTOBuildingNumber { get; set; }
			
        /// <summary>
        ///  单元号 
        /// </summary>
        public string CFTOUnitNumber { get; set; }
			
        /// <summary>
        ///  门牌号 
        /// </summary>
        public string CFTOHouseNumber { get; set; }
	}

	
    /// <summary>
    ///  招聘就业模块 
    /// </summary>
	[Table("RecruitmentAndEmploymentModule")]
    public class RecruitmentAndEmploymentModule 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  用人单位 
        /// </summary>
        public string RAEMEmployingUnit { get; set; }
			
        /// <summary>
        ///  职位 
        /// </summary>
        public string RAEMPosition { get; set; }
			
        /// <summary>
        ///  发布人 
        /// </summary>
        public string RAEMPublisher { get; set; }
			
        /// <summary>
        ///  职位描述 
        /// </summary>
        public string RAEMJobDescription { get; set; }
			
        /// <summary>
        ///  职位职责内容 
        /// </summary>
        public string RAEMJobResponsibilities { get; set; }
			
        /// <summary>
        ///  职位要求内容 
        /// </summary>
        public string RAEMContentsOfJobRequirements { get; set; }
			
        /// <summary>
        ///  生效时间 
        /// </summary>
        public Nullable<DateTime> RAEMEntryintoforceTime { get; set; }
			
        /// <summary>
        ///  失效时间 
        /// </summary>
        public Nullable<DateTime> RAEMFailureTime { get; set; }
	}

	
    /// <summary>
    ///  党群结队 
    /// </summary>
	[Table("PartyAndGroupFormation")]
    public class PartyAndGroupFormation 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  所属党组织 
        /// </summary>
        public string PAGFPartyOrganizationsAffiliatedToThem { get; set; }
			
        /// <summary>
        ///  成员姓名 
        /// </summary>
        public string PAGFNameOfMember { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string PAGFIdCardNo { get; set; }
			
        /// <summary>
        ///  创建时间 
        /// </summary>
        public Nullable<DateTime> PAGFCreationTime { get; set; }
	}

	
    /// <summary>
    ///  党员活动 
    /// </summary>
	[Table("PartyMemberActivities")]
    public class PartyMemberActivities 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  活动名称 
        /// </summary>
        public string PMAActivityName { get; set; }
			
        /// <summary>
        ///  活动简介 
        /// </summary>
        public string PMAActivityBrief { get; set; }
			
        /// <summary>
        ///  覆盖范围 
        /// </summary>
        public string PMACoverageArea { get; set; }
			
        /// <summary>
        ///  活动照片 
        /// </summary>
        public string PMAActivePhotos { get; set; }
	}

	
    /// <summary>
    ///  美丽乡村 
    /// </summary>
	[Table("BeautifulCountryside")]
    public class BeautifulCountryside 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  年份 
        /// </summary>
        public string BCParticularYear { get; set; }
			
        /// <summary>
        ///  月份 
        /// </summary>
        public string BCMonth { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string BCTitle { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string BCPhoto { get; set; }
			
        /// <summary>
        ///  建设成果 
        /// </summary>
        public string BCAchievementsInConstruction { get; set; }
	}

	
    /// <summary>
    ///  引水上山 
    /// </summary>
	[Table("DrawWaterUpaHill")]
    public class DrawWaterUpaHill 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  年份 
        /// </summary>
        public string DWUHParticularYear { get; set; }
			
        /// <summary>
        ///  月份 
        /// </summary>
        public string DWUHMonth { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string DWUHTitle { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string DWUHPhoto { get; set; }
			
        /// <summary>
        ///  建设成果 
        /// </summary>
        public string DWUHAchievementsInConstruction { get; set; }
	}

	
    /// <summary>
    ///  宣传 
    /// </summary>
	[Table("Propaganda")]
    public class Propaganda 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  标题 
        /// </summary>
        public string PTitle { get; set; }
			
        /// <summary>
        ///  类别 
        /// </summary>
        public string PCategory { get; set; }
			
        /// <summary>
        ///  子类别 
        /// </summary>
        public string PSubcategory { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string PContent { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string PAddress { get; set; }
	}

	
    /// <summary>
    ///  组织 
    /// </summary>
	[Table("Organization")]
    public class Organization 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  成员编号 
        /// </summary>
        public string OMembershipNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string OFullName { get; set; }
			
        /// <summary>
        ///  上级 
        /// </summary>
        public string OSuperior { get; set; }
			
        /// <summary>
        ///  组织名称 
        /// </summary>
        public string OOrganizationName { get; set; }
			
        /// <summary>
        ///  所属支部 
        /// </summary>
        public string OSubordinateBranch { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string OAddress { get; set; }
	}

	
    /// <summary>
    ///  工会 
    /// </summary>
	[Table("LabourUnion")]
    public class LabourUnion 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  单位组织机构代码 
        /// </summary>
        public string LUUnitOrganizationCode { get; set; }
			
        /// <summary>
        ///  单位或单位主体的国民经济行业分类代码 
        /// </summary>
        public string LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit { get; set; }
			
        /// <summary>
        ///  单位或单位主体的单位类别 
        /// </summary>
        public string LUClassificationOfUnitsOrSubjectsOfUnits { get; set; }
			
        /// <summary>
        ///  单位地址 
        /// </summary>
        public string LUUnitAddress { get; set; }
			
        /// <summary>
        ///  上级工会 
        /// </summary>
        public string LUHigherLevelTradeUnion { get; set; }
			
        /// <summary>
        ///  单位工会名称 
        /// </summary>
        public string LUUnitTradeUnionName { get; set; }
			
        /// <summary>
        ///  建会时间 
        /// </summary>
        public Nullable<DateTime> LUBuildingTime { get; set; }
			
        /// <summary>
        ///  工会负责人 
        /// </summary>
        public string LUTheHeadOfTheTradeUnion { get; set; }
			
        /// <summary>
        ///  工会负责人联系电话 
        /// </summary>
        public string LUTelephoneCallsFromTradeUnionLeaders { get; set; }
			
        /// <summary>
        ///  工会办公电话 
        /// </summary>
        public string LUTradeUnionOfficeTelephone { get; set; }
			
        /// <summary>
        ///  本单位已交至苏州银行的会员身份证复印件数量 
        /// </summary>
        public string LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou { get; set; }
			
        /// <summary>
        ///  单位职工总数人 
        /// </summary>
        public string LUTotalNumberOfEmployeesInaUnit { get; set; }
			
        /// <summary>
        ///  单位会员数人 
        /// </summary>
        public string LUNumberOfUnitMembers { get; set; }
			
        /// <summary>
        ///  单位女职工数人 
        /// </summary>
        public string LUNumberOfFemaleEmployeesInaUnit { get; set; }
			
        /// <summary>
        ///  单位女会员数人 
        /// </summary>
        public string LUNumberOfFemaleMembersInaUnit { get; set; }
			
        /// <summary>
        ///  统计主题1 
        /// </summary>
        public string LUStatisticalTopic1 { get; set; }
	}

	
    /// <summary>
    ///  工会成员 
    /// </summary>
	[Table("TradeUnionMembers")]
    public class TradeUnionMembers 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string TUMFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string TUMGender { get; set; }
			
        /// <summary>
        ///  民族 
        /// </summary>
        public string TUMNation { get; set; }
			
        /// <summary>
        ///  出生年月 
        /// </summary>
        public string TUMDateOfBirth { get; set; }
			
        /// <summary>
        ///  政治面貌 
        /// </summary>
        public string TUMPoliticalOutlook { get; set; }
			
        /// <summary>
        ///  学历 
        /// </summary>
        public string TUMEducation { get; set; }
			
        /// <summary>
        ///  籍贯XX省XX市 
        /// </summary>
        public string TUMXxCityXxProvince { get; set; }
			
        /// <summary>
        ///  入会时间 
        /// </summary>
        public Nullable<DateTime> TUMAdmissionTime { get; set; }
			
        /// <summary>
        ///  身份证号 
        /// </summary>
        public string TUMIdNumber { get; set; }
			
        /// <summary>
        ///  地址单位地址 
        /// </summary>
        public string TUMAddressUnitAddress { get; set; }
			
        /// <summary>
        ///  手机号码 
        /// </summary>
        public string TUMPhoneNumber { get; set; }
			
        /// <summary>
        ///  身份证有效期限 
        /// </summary>
        public string TUMLimitOfValidityOfIdentityCard { get; set; }
			
        /// <summary>
        ///  是否从事有毒有害工作是否 
        /// </summary>
        public string TUMWhetherToEngageInToxicAndHarmfulWorkOrNot { get; set; }
			
        /// <summary>
        ///  备注1 
        /// </summary>
        public string TUMRemarks1 { get; set; }
	}

	
    /// <summary>
    ///  工作人员 
    /// </summary>
	[Table("Personnel")]
    public class Personnel 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  员工编号 
        /// </summary>
        public string PEmployeeNumber { get; set; }
			
        /// <summary>
        ///  上级 
        /// </summary>
        public string PSuperior { get; set; }
			
        /// <summary>
        ///  负责区域 
        /// </summary>
        public string PResponsibleArea { get; set; }
			
        /// <summary>
        ///  所属条线 
        /// </summary>
        public string PSubordinateLine { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string PAddress { get; set; }
	}

	
    /// <summary>
    ///  姑苏村问题处理 
    /// </summary>
	[Table("HandlingOfGusuVillageProblem")]
    public class HandlingOfGusuVillageProblem 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  问题编号 
        /// </summary>
        public string HOGVPQuestionNumber { get; set; }
			
        /// <summary>
        ///  问题描述 
        /// </summary>
        public string HOGVPProblemDescription { get; set; }
			
        /// <summary>
        ///  问题类别 
        /// </summary>
        public string HOGVPQuestionCategories { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string HOGVPPhoto { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string HOGVPPersonInCharge { get; set; }
			
        /// <summary>
        ///  问题状态 
        /// </summary>
        public string HOGVPProblemState { get; set; }
			
        /// <summary>
        ///  确认时间 
        /// </summary>
        public Nullable<DateTime> HOGVPConfirmationTime { get; set; }
			
        /// <summary>
        ///  处理时间 
        /// </summary>
        public Nullable<DateTime> HOGVPProcessingTime { get; set; }
			
        /// <summary>
        ///  回访时间 
        /// </summary>
        public Nullable<DateTime> HOGVPRevisitDays { get; set; }
	}

	
    /// <summary>
    ///  渔政 
    /// </summary>
	[Table("FisheryAdministration")]
    public class FisheryAdministration 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  渔证编号 
        /// </summary>
        public string FAFishingPermitNumber { get; set; }
			
        /// <summary>
        ///  持证人姓名 
        /// </summary>
        public string FANameOfTheHolder { get; set; }
			
        /// <summary>
        ///  发证日期 
        /// </summary>
        public Nullable<DateTime> FADateOfIssue { get; set; }
			
        /// <summary>
        ///  下次换证日期 
        /// </summary>
        public Nullable<DateTime> FADateOfNextRenewal { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string FAPersonInCharge { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string FAAddress { get; set; }
			
        /// <summary>
        ///  是否有效 
        /// </summary>
        public string FAIsItEffective { get; set; }
	}

	
    /// <summary>
    ///  妇联执委名单 
    /// </summary>
	[Table("ListOfExecutiveCommitteesOfWomensFederation")]
    public class ListOfExecutiveCommitteesOfWomensFederation 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  序号 
        /// </summary>
        public string LOECOWFSerialNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string LOECOWFFullName { get; set; }
			
        /// <summary>
        ///  出生年月 
        /// </summary>
        public string LOECOWFDateOfBirth { get; set; }
			
        /// <summary>
        ///  职务 
        /// </summary>
        public string LOECOWFPost { get; set; }
			
        /// <summary>
        ///  性质 
        /// </summary>
        public string LOECOWFNature { get; set; }
	}

	
    /// <summary>
    ///  资产 
    /// </summary>
	[Table("Assets")]
    public class Assets 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  资产编号 
        /// </summary>
        public string AAssetNumber { get; set; }
			
        /// <summary>
        ///  资产名称 
        /// </summary>
        public string AAssetName { get; set; }
			
        /// <summary>
        ///  资产类别 
        /// </summary>
        public string AAssetClass { get; set; }
			
        /// <summary>
        ///  会计科目 
        /// </summary>
        public string AAccountingSubjects { get; set; }
			
        /// <summary>
        ///  所属单位 
        /// </summary>
        public string ASubordinateUnit { get; set; }
	}

	
    /// <summary>
    ///  监护人 
    /// </summary>
	[Table("Guardian")]
    public class Guardian 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string GFullName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string GGender { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string GContactNumber { get; set; }
			
        /// <summary>
        ///  户籍所在地 
        /// </summary>
        public string GLocationOfHouseholdRegistration { get; set; }
			
        /// <summary>
        ///  所在地区 
        /// </summary>
        public string GLocation { get; set; }
			
        /// <summary>
        ///  详细地址 
        /// </summary>
        public string GDetailedAddress { get; set; }
			
        /// <summary>
        ///  居住地 
        /// </summary>
        public string GPlaceOfResidence { get; set; }
			
        /// <summary>
        ///  提交人 
        /// </summary>
        public string GSubmitter { get; set; }
			
        /// <summary>
        ///  提交人电话 
        /// </summary>
        public string GAuthorsTelephoneNumber { get; set; }
			
        /// <summary>
        ///  社保卡正反面 
        /// </summary>
        public string GPositiveAndNegativeSideOfSocialSecurityCard { get; set; }
			
        /// <summary>
        ///  监护人身份证正反面 
        /// </summary>
        public string GThePositiveAndNegativeSidesOfGuardiansIdentityCard { get; set; }
	}

	
    /// <summary>
    ///  照片 
    /// </summary>
	[Table("Photo")]
    public class Photo 
    {
			        
        /// <summary>
        ///  唯一编号
        /// </summary>
		[Key]
        public string id { get; set; }
        /// <summary>
        ///  版本号
        /// </summary>
        public int? VersionNo { get; set; }
        /// <summary>
        ///  创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime? CreateOn { get; set; }
        /// <summary>
        ///  更新时间
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        ///  更新人
        /// </summary>
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        ///  事务编号
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        ///  是否删除
        /// </summary>
        public int? IsDeleted { get; set; }
        /// <summary>
        ///  数据级别
        /// </summary>
        public string DataLevel { get; set; }
        /// <summary>
        ///  经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        ///  纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? ord { get; set; }
			
        /// <summary>
        ///  类别 
        /// </summary>
        public string PCategory { get; set; }
			
        /// <summary>
        ///  url 
        /// </summary>
        public string PUrl { get; set; }
			
        /// <summary>
        ///  物理地址 
        /// </summary>
        public string PPhysicalAddress { get; set; }
			
        /// <summary>
        ///  社保卡反面 
        /// </summary>
        public string PTheReverseSideOfSocialSecurityCard { get; set; }
			
        /// <summary>
        ///  社保卡正面 
        /// </summary>
        public string PFrontOfSocialSecurityCard { get; set; }
			
        /// <summary>
        ///  监护人身份证正面 
        /// </summary>
        public string PTheFrontOfGuardiansIdCard { get; set; }
			
        /// <summary>
        ///  监护人身份证反面 
        /// </summary>
        public string PTheReverseOfGuardiansIdentityCard { get; set; }
			
        /// <summary>
        ///  其他 
        /// </summary>
        public string POther { get; set; }
	}

}
