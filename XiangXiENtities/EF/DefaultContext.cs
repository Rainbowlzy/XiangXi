

  
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultContext, Configuration>());
        }

		public void BuildMenu()
		{
		
            var TransactionID = Guid.NewGuid().ToString();
            var CreateBy = "Initialization Job";

			
			if (!MenuConfiguration.Any(t => t.MCCaption == "社情民意"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "社情民意",
					MCLink = "/XiangXi/gen/SocialConditionsAndPublicOpinionsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "社情民意统计",
					MCLink = "/XiangXi/gen/SocialConditionsAndPublicOpinionsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var socialconditionsandpublicopinions = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "社情民意");
			if(socialconditionsandpublicopinions!=null)
			{
				socialconditionsandpublicopinions.MCLink = "/XiangXi/gen/SocialConditionsAndPublicOpinionsList.html";
				MenuConfiguration.AddOrUpdate(socialconditionsandpublicopinions);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "菜单配置"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "菜单配置",
					MCLink = "/XiangXi/gen/MenuConfigurationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "菜单配置统计",
					MCLink = "/XiangXi/gen/MenuConfigurationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var menuconfiguration = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "菜单配置");
			if(menuconfiguration!=null)
			{
				menuconfiguration.MCLink = "/XiangXi/gen/MenuConfigurationList.html";
				MenuConfiguration.AddOrUpdate(menuconfiguration);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "角色菜单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "角色菜单",
					MCLink = "/XiangXi/gen/RoleMenuList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "角色菜单统计",
					MCLink = "/XiangXi/gen/RoleMenuAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var rolemenu = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "角色菜单");
			if(rolemenu!=null)
			{
				rolemenu.MCLink = "/XiangXi/gen/RoleMenuList.html";
				MenuConfiguration.AddOrUpdate(rolemenu);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "用户角色"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "用户角色",
					MCLink = "/XiangXi/gen/UserRoleList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "用户角色统计",
					MCLink = "/XiangXi/gen/UserRoleAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var userrole = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "用户角色");
			if(userrole!=null)
			{
				userrole.MCLink = "/XiangXi/gen/UserRoleList.html";
				MenuConfiguration.AddOrUpdate(userrole);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "角色配置"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "角色配置",
					MCLink = "/XiangXi/gen/RoleConfigurationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "角色配置统计",
					MCLink = "/XiangXi/gen/RoleConfigurationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var roleconfiguration = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "角色配置");
			if(roleconfiguration!=null)
			{
				roleconfiguration.MCLink = "/XiangXi/gen/RoleConfigurationList.html";
				MenuConfiguration.AddOrUpdate(roleconfiguration);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "用户信息"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "用户信息",
					MCLink = "/XiangXi/gen/UserInformationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "用户信息统计",
					MCLink = "/XiangXi/gen/UserInformationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var userinformation = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "用户信息");
			if(userinformation!=null)
			{
				userinformation.MCLink = "/XiangXi/gen/UserInformationList.html";
				MenuConfiguration.AddOrUpdate(userinformation);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "登录记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "登录记录",
					MCLink = "/XiangXi/gen/LogonRecordList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "登录记录统计",
					MCLink = "/XiangXi/gen/LogonRecordAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var logonrecord = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "登录记录");
			if(logonrecord!=null)
			{
				logonrecord.MCLink = "/XiangXi/gen/LogonRecordList.html";
				MenuConfiguration.AddOrUpdate(logonrecord);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "用户菜单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "用户菜单",
					MCLink = "/XiangXi/gen/UserMenuList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "用户菜单统计",
					MCLink = "/XiangXi/gen/UserMenuAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var usermenu = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "用户菜单");
			if(usermenu!=null)
			{
				usermenu.MCLink = "/XiangXi/gen/UserMenuList.html";
				MenuConfiguration.AddOrUpdate(usermenu);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党员信息管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党员信息管理",
					MCLink = "/XiangXi/gen/InformationManagementOfPartyMembersList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党员信息管理统计",
					MCLink = "/XiangXi/gen/InformationManagementOfPartyMembersAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var informationmanagementofpartymembers = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党员信息管理");
			if(informationmanagementofpartymembers!=null)
			{
				informationmanagementofpartymembers.MCLink = "/XiangXi/gen/InformationManagementOfPartyMembersList.html";
				MenuConfiguration.AddOrUpdate(informationmanagementofpartymembers);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党费管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党费管理",
					MCLink = "/XiangXi/gen/PartyFeeManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党费管理统计",
					MCLink = "/XiangXi/gen/PartyFeeManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var partyfeemanagement = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党费管理");
			if(partyfeemanagement!=null)
			{
				partyfeemanagement.MCLink = "/XiangXi/gen/PartyFeeManagementList.html";
				MenuConfiguration.AddOrUpdate(partyfeemanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党课记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党课记录",
					MCLink = "/XiangXi/gen/RecordingLecturesList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党课记录统计",
					MCLink = "/XiangXi/gen/RecordingLecturesAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var recordinglectures = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党课记录");
			if(recordinglectures!=null)
			{
				recordinglectures.MCLink = "/XiangXi/gen/RecordingLecturesList.html";
				MenuConfiguration.AddOrUpdate(recordinglectures);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "三会一课"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "三会一课",
					MCLink = "/XiangXi/gen/ThreeSessionsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "三会一课统计",
					MCLink = "/XiangXi/gen/ThreeSessionsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var threesessions = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "三会一课");
			if(threesessions!=null)
			{
				threesessions.MCLink = "/XiangXi/gen/ThreeSessionsList.html";
				MenuConfiguration.AddOrUpdate(threesessions);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "专题学习"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "专题学习",
					MCLink = "/XiangXi/gen/ThematicStudyList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "专题学习统计",
					MCLink = "/XiangXi/gen/ThematicStudyAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var thematicstudy = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "专题学习");
			if(thematicstudy!=null)
			{
				thematicstudy.MCLink = "/XiangXi/gen/ThematicStudyList.html";
				MenuConfiguration.AddOrUpdate(thematicstudy);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "政策文件"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "政策文件",
					MCLink = "/XiangXi/gen/PolicyDocumentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "政策文件统计",
					MCLink = "/XiangXi/gen/PolicyDocumentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var policydocument = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "政策文件");
			if(policydocument!=null)
			{
				policydocument.MCLink = "/XiangXi/gen/PolicyDocumentList.html";
				MenuConfiguration.AddOrUpdate(policydocument);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "政策文件类别"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "政策文件类别",
					MCLink = "/XiangXi/gen/PolicyDocumentCategoryList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "政策文件类别统计",
					MCLink = "/XiangXi/gen/PolicyDocumentCategoryAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var policydocumentcategory = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "政策文件类别");
			if(policydocumentcategory!=null)
			{
				policydocumentcategory.MCLink = "/XiangXi/gen/PolicyDocumentCategoryList.html";
				MenuConfiguration.AddOrUpdate(policydocumentcategory);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "统战对象明细"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "统战对象明细",
					MCLink = "/XiangXi/gen/UnitedFrontObjectDetailsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "统战对象明细统计",
					MCLink = "/XiangXi/gen/UnitedFrontObjectDetailsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var unitedfrontobjectdetails = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "统战对象明细");
			if(unitedfrontobjectdetails!=null)
			{
				unitedfrontobjectdetails.MCLink = "/XiangXi/gen/UnitedFrontObjectDetailsList.html";
				MenuConfiguration.AddOrUpdate(unitedfrontobjectdetails);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "回民清真饮食补贴发放"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "回民清真饮食补贴发放",
					MCLink = "/XiangXi/gen/MuslimFoodSubsidiesList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "回民清真饮食补贴发放统计",
					MCLink = "/XiangXi/gen/MuslimFoodSubsidiesAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var muslimfoodsubsidies = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "回民清真饮食补贴发放");
			if(muslimfoodsubsidies!=null)
			{
				muslimfoodsubsidies.MCLink = "/XiangXi/gen/MuslimFoodSubsidiesList.html";
				MenuConfiguration.AddOrUpdate(muslimfoodsubsidies);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "现役军人名单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "现役军人名单",
					MCLink = "/XiangXi/gen/ListOfActiveServicemenList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "现役军人名单统计",
					MCLink = "/XiangXi/gen/ListOfActiveServicemenAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var listofactiveservicemen = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "现役军人名单");
			if(listofactiveservicemen!=null)
			{
				listofactiveservicemen.MCLink = "/XiangXi/gen/ListOfActiveServicemenList.html";
				MenuConfiguration.AddOrUpdate(listofactiveservicemen);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "征兵对象名单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "征兵对象名单",
					MCLink = "/XiangXi/gen/ListOfRecruitsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "征兵对象名单统计",
					MCLink = "/XiangXi/gen/ListOfRecruitsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var listofrecruits = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "征兵对象名单");
			if(listofrecruits!=null)
			{
				listofrecruits.MCLink = "/XiangXi/gen/ListOfRecruitsList.html";
				MenuConfiguration.AddOrUpdate(listofrecruits);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "共青团"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "共青团",
					MCLink = "/XiangXi/gen/TheCommunistYouthLeagueList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "共青团统计",
					MCLink = "/XiangXi/gen/TheCommunistYouthLeagueAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var thecommunistyouthleague = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "共青团");
			if(thecommunistyouthleague!=null)
			{
				thecommunistyouthleague.MCLink = "/XiangXi/gen/TheCommunistYouthLeagueList.html";
				MenuConfiguration.AddOrUpdate(thecommunistyouthleague);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "重点人员"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "重点人员",
					MCLink = "/XiangXi/gen/KeyPersonnelList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "重点人员统计",
					MCLink = "/XiangXi/gen/KeyPersonnelAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var keypersonnel = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "重点人员");
			if(keypersonnel!=null)
			{
				keypersonnel.MCLink = "/XiangXi/gen/KeyPersonnelList.html";
				MenuConfiguration.AddOrUpdate(keypersonnel);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "信访"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "信访",
					MCLink = "/XiangXi/gen/LetterAndVisitList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "信访统计",
					MCLink = "/XiangXi/gen/LetterAndVisitAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var letterandvisit = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "信访");
			if(letterandvisit!=null)
			{
				letterandvisit.MCLink = "/XiangXi/gen/LetterAndVisitList.html";
				MenuConfiguration.AddOrUpdate(letterandvisit);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "两类人员"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "两类人员",
					MCLink = "/XiangXi/gen/TwoCategoriesOfPersonnelList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "两类人员统计",
					MCLink = "/XiangXi/gen/TwoCategoriesOfPersonnelAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var twocategoriesofpersonnel = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "两类人员");
			if(twocategoriesofpersonnel!=null)
			{
				twocategoriesofpersonnel.MCLink = "/XiangXi/gen/TwoCategoriesOfPersonnelList.html";
				MenuConfiguration.AddOrUpdate(twocategoriesofpersonnel);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "家庭"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "家庭",
					MCLink = "/XiangXi/gen/FamilyList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "家庭统计",
					MCLink = "/XiangXi/gen/FamilyAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var family = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "家庭");
			if(family!=null)
			{
				family.MCLink = "/XiangXi/gen/FamilyList.html";
				MenuConfiguration.AddOrUpdate(family);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "股民"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "股民",
					MCLink = "/XiangXi/gen/InvestorsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "股民统计",
					MCLink = "/XiangXi/gen/InvestorsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var investors = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "股民");
			if(investors!=null)
			{
				investors.MCLink = "/XiangXi/gen/InvestorsList.html";
				MenuConfiguration.AddOrUpdate(investors);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "分红记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "分红记录",
					MCLink = "/XiangXi/gen/BonusRecordList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "分红记录统计",
					MCLink = "/XiangXi/gen/BonusRecordAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var bonusrecord = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "分红记录");
			if(bonusrecord!=null)
			{
				bonusrecord.MCLink = "/XiangXi/gen/BonusRecordList.html";
				MenuConfiguration.AddOrUpdate(bonusrecord);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "干部"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "干部",
					MCLink = "/XiangXi/gen/CadreList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "干部统计",
					MCLink = "/XiangXi/gen/CadreAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var cadre = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "干部");
			if(cadre!=null)
			{
				cadre.MCLink = "/XiangXi/gen/CadreList.html";
				MenuConfiguration.AddOrUpdate(cadre);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "民兵"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "民兵",
					MCLink = "/XiangXi/gen/MilitiaList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "民兵统计",
					MCLink = "/XiangXi/gen/MilitiaAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var militia = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "民兵");
			if(militia!=null)
			{
				militia.MCLink = "/XiangXi/gen/MilitiaList.html";
				MenuConfiguration.AddOrUpdate(militia);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "三产楼栋"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "三产楼栋",
					MCLink = "/XiangXi/gen/ThreeProductionBuildingList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "三产楼栋统计",
					MCLink = "/XiangXi/gen/ThreeProductionBuildingAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var threeproductionbuilding = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "三产楼栋");
			if(threeproductionbuilding!=null)
			{
				threeproductionbuilding.MCLink = "/XiangXi/gen/ThreeProductionBuildingList.html";
				MenuConfiguration.AddOrUpdate(threeproductionbuilding);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "厂房楼栋"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "厂房楼栋",
					MCLink = "/XiangXi/gen/BuildingList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "厂房楼栋统计",
					MCLink = "/XiangXi/gen/BuildingAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var building = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "厂房楼栋");
			if(building!=null)
			{
				building.MCLink = "/XiangXi/gen/BuildingList.html";
				MenuConfiguration.AddOrUpdate(building);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "收租记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "收租记录",
					MCLink = "/XiangXi/gen/RentRecordList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "收租记录统计",
					MCLink = "/XiangXi/gen/RentRecordAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var rentrecord = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "收租记录");
			if(rentrecord!=null)
			{
				rentrecord.MCLink = "/XiangXi/gen/RentRecordList.html";
				MenuConfiguration.AddOrUpdate(rentrecord);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "电费缴纳记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "电费缴纳记录",
					MCLink = "/XiangXi/gen/RecordOfElectricityPaymentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "电费缴纳记录统计",
					MCLink = "/XiangXi/gen/RecordOfElectricityPaymentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var recordofelectricitypayment = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "电费缴纳记录");
			if(recordofelectricitypayment!=null)
			{
				recordofelectricitypayment.MCLink = "/XiangXi/gen/RecordOfElectricityPaymentList.html";
				MenuConfiguration.AddOrUpdate(recordofelectricitypayment);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "工作日志"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "工作日志",
					MCLink = "/XiangXi/gen/WorkLogList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "工作日志统计",
					MCLink = "/XiangXi/gen/WorkLogAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var worklog = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "工作日志");
			if(worklog!=null)
			{
				worklog.MCLink = "/XiangXi/gen/WorkLogList.html";
				MenuConfiguration.AddOrUpdate(worklog);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "通知"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "通知",
					MCLink = "/XiangXi/gen/AdviseList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "通知统计",
					MCLink = "/XiangXi/gen/AdviseAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var advise = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "通知");
			if(advise!=null)
			{
				advise.MCLink = "/XiangXi/gen/AdviseList.html";
				MenuConfiguration.AddOrUpdate(advise);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "文档管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "文档管理",
					MCLink = "/XiangXi/gen/DocumentManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "文档管理统计",
					MCLink = "/XiangXi/gen/DocumentManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var documentmanagement = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "文档管理");
			if(documentmanagement!=null)
			{
				documentmanagement.MCLink = "/XiangXi/gen/DocumentManagementList.html";
				MenuConfiguration.AddOrUpdate(documentmanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "人口"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "人口",
					MCLink = "/XiangXi/gen/PopulationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "人口统计",
					MCLink = "/XiangXi/gen/PopulationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var population = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "人口");
			if(population!=null)
			{
				population.MCLink = "/XiangXi/gen/PopulationList.html";
				MenuConfiguration.AddOrUpdate(population);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "房产"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "房产",
					MCLink = "/XiangXi/gen/HousePropertyList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "房产统计",
					MCLink = "/XiangXi/gen/HousePropertyAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var houseproperty = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "房产");
			if(houseproperty!=null)
			{
				houseproperty.MCLink = "/XiangXi/gen/HousePropertyList.html";
				MenuConfiguration.AddOrUpdate(houseproperty);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "报销清单"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "报销清单",
					MCLink = "/XiangXi/gen/ReimbursementListList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "报销清单统计",
					MCLink = "/XiangXi/gen/ReimbursementListAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var reimbursementlist = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "报销清单");
			if(reimbursementlist!=null)
			{
				reimbursementlist.MCLink = "/XiangXi/gen/ReimbursementListList.html";
				MenuConfiguration.AddOrUpdate(reimbursementlist);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "通讯录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "通讯录",
					MCLink = "/XiangXi/gen/MailListList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "通讯录统计",
					MCLink = "/XiangXi/gen/MailListAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var maillist = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "通讯录");
			if(maillist!=null)
			{
				maillist.MCLink = "/XiangXi/gen/MailListList.html";
				MenuConfiguration.AddOrUpdate(maillist);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "POI"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "POI",
					MCLink = "/XiangXi/gen/POIList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "POI统计",
					MCLink = "/XiangXi/gen/POIAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var poi = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "POI");
			if(poi!=null)
			{
				poi.MCLink = "/XiangXi/gen/POIList.html";
				MenuConfiguration.AddOrUpdate(poi);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党建要闻管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党建要闻管理",
					MCLink = "/XiangXi/gen/PartyNewsManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党建要闻管理统计",
					MCLink = "/XiangXi/gen/PartyNewsManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var partynewsmanagement = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党建要闻管理");
			if(partynewsmanagement!=null)
			{
				partynewsmanagement.MCLink = "/XiangXi/gen/PartyNewsManagementList.html";
				MenuConfiguration.AddOrUpdate(partynewsmanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "随手拍"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "随手拍",
					MCLink = "/XiangXi/gen/PatList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "随手拍统计",
					MCLink = "/XiangXi/gen/PatAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var pat = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "随手拍");
			if(pat!=null)
			{
				pat.MCLink = "/XiangXi/gen/PatList.html";
				MenuConfiguration.AddOrUpdate(pat);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "主动巡检"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "主动巡检",
					MCLink = "/XiangXi/gen/ActiveInspectionList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "主动巡检统计",
					MCLink = "/XiangXi/gen/ActiveInspectionAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var activeinspection = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "主动巡检");
			if(activeinspection!=null)
			{
				activeinspection.MCLink = "/XiangXi/gen/ActiveInspectionList.html";
				MenuConfiguration.AddOrUpdate(activeinspection);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "业务预约"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "业务预约",
					MCLink = "/XiangXi/gen/BusinessReservationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "业务预约统计",
					MCLink = "/XiangXi/gen/BusinessReservationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var businessreservation = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "业务预约");
			if(businessreservation!=null)
			{
				businessreservation.MCLink = "/XiangXi/gen/BusinessReservationList.html";
				MenuConfiguration.AddOrUpdate(businessreservation);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "提建议记录"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "提建议记录",
					MCLink = "/XiangXi/gen/SuggestionRecordList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "提建议记录统计",
					MCLink = "/XiangXi/gen/SuggestionRecordAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var suggestionrecord = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "提建议记录");
			if(suggestionrecord!=null)
			{
				suggestionrecord.MCLink = "/XiangXi/gen/SuggestionRecordList.html";
				MenuConfiguration.AddOrUpdate(suggestionrecord);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党风廉政学习"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党风廉政学习",
					MCLink = "/XiangXi/gen/TheStudyOfPartyStyleAndCleanGovernmentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党风廉政学习统计",
					MCLink = "/XiangXi/gen/TheStudyOfPartyStyleAndCleanGovernmentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var thestudyofpartystyleandcleangovernment = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党风廉政学习");
			if(thestudyofpartystyleandcleangovernment!=null)
			{
				thestudyofpartystyleandcleangovernment.MCLink = "/XiangXi/gen/TheStudyOfPartyStyleAndCleanGovernmentList.html";
				MenuConfiguration.AddOrUpdate(thestudyofpartystyleandcleangovernment);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "公共设施"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "公共设施",
					MCLink = "/XiangXi/gen/ServiceList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "公共设施统计",
					MCLink = "/XiangXi/gen/ServiceAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var service = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "公共设施");
			if(service!=null)
			{
				service.MCLink = "/XiangXi/gen/ServiceList.html";
				MenuConfiguration.AddOrUpdate(service);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "系统配置"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "系统配置",
					MCLink = "/XiangXi/gen/SystemConfigurationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "系统配置统计",
					MCLink = "/XiangXi/gen/SystemConfigurationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var systemconfiguration = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "系统配置");
			if(systemconfiguration!=null)
			{
				systemconfiguration.MCLink = "/XiangXi/gen/SystemConfigurationList.html";
				MenuConfiguration.AddOrUpdate(systemconfiguration);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党建"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党建",
					MCLink = "/XiangXi/gen/PartyBuildingList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党建统计",
					MCLink = "/XiangXi/gen/PartyBuildingAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var partybuilding = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党建");
			if(partybuilding!=null)
			{
				partybuilding.MCLink = "/XiangXi/gen/PartyBuildingList.html";
				MenuConfiguration.AddOrUpdate(partybuilding);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党费缴纳管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党费缴纳管理",
					MCLink = "/XiangXi/gen/MembershipDuesPaymentManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党费缴纳管理统计",
					MCLink = "/XiangXi/gen/MembershipDuesPaymentManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var membershipduespaymentmanagement = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党费缴纳管理");
			if(membershipduespaymentmanagement!=null)
			{
				membershipduespaymentmanagement.MCLink = "/XiangXi/gen/MembershipDuesPaymentManagementList.html";
				MenuConfiguration.AddOrUpdate(membershipduespaymentmanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "合同管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "合同管理",
					MCLink = "/XiangXi/gen/ContractManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "合同管理统计",
					MCLink = "/XiangXi/gen/ContractManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var contractmanagement = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "合同管理");
			if(contractmanagement!=null)
			{
				contractmanagement.MCLink = "/XiangXi/gen/ContractManagementList.html";
				MenuConfiguration.AddOrUpdate(contractmanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "个人信息"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "个人信息",
					MCLink = "/XiangXi/gen/PersonalInformationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "个人信息统计",
					MCLink = "/XiangXi/gen/PersonalInformationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var personalinformation = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "个人信息");
			if(personalinformation!=null)
			{
				personalinformation.MCLink = "/XiangXi/gen/PersonalInformationList.html";
				MenuConfiguration.AddOrUpdate(personalinformation);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "日程工作"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "日程工作",
					MCLink = "/XiangXi/gen/ScheduleWorkList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "日程工作统计",
					MCLink = "/XiangXi/gen/ScheduleWorkAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var schedulework = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "日程工作");
			if(schedulework!=null)
			{
				schedulework.MCLink = "/XiangXi/gen/ScheduleWorkList.html";
				MenuConfiguration.AddOrUpdate(schedulework);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党建专题"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党建专题",
					MCLink = "/XiangXi/gen/PartyBuildingProjectList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党建专题统计",
					MCLink = "/XiangXi/gen/PartyBuildingProjectAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var partybuildingproject = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党建专题");
			if(partybuildingproject!=null)
			{
				partybuildingproject.MCLink = "/XiangXi/gen/PartyBuildingProjectList.html";
				MenuConfiguration.AddOrUpdate(partybuildingproject);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "办事指南"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "办事指南",
					MCLink = "/XiangXi/gen/GuideToAffairsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "办事指南统计",
					MCLink = "/XiangXi/gen/GuideToAffairsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var guidetoaffairs = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "办事指南");
			if(guidetoaffairs!=null)
			{
				guidetoaffairs.MCLink = "/XiangXi/gen/GuideToAffairsList.html";
				MenuConfiguration.AddOrUpdate(guidetoaffairs);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党务指南"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党务指南",
					MCLink = "/XiangXi/gen/GuideToPartyAffairsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党务指南统计",
					MCLink = "/XiangXi/gen/GuideToPartyAffairsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var guidetopartyaffairs = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党务指南");
			if(guidetopartyaffairs!=null)
			{
				guidetopartyaffairs.MCLink = "/XiangXi/gen/GuideToPartyAffairsList.html";
				MenuConfiguration.AddOrUpdate(guidetopartyaffairs);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "业务管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "业务管理",
					MCLink = "/XiangXi/gen/BusinessManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "业务管理统计",
					MCLink = "/XiangXi/gen/BusinessManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var businessmanagement = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "业务管理");
			if(businessmanagement!=null)
			{
				businessmanagement.MCLink = "/XiangXi/gen/BusinessManagementList.html";
				MenuConfiguration.AddOrUpdate(businessmanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "少儿医保"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "少儿医保",
					MCLink = "/XiangXi/gen/ChildrensMedicalInsuranceRegistrationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "少儿医保统计",
					MCLink = "/XiangXi/gen/ChildrensMedicalInsuranceRegistrationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var childrensmedicalinsuranceregistration = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "少儿医保");
			if(childrensmedicalinsuranceregistration!=null)
			{
				childrensmedicalinsuranceregistration.MCLink = "/XiangXi/gen/ChildrensMedicalInsuranceRegistrationList.html";
				MenuConfiguration.AddOrUpdate(childrensmedicalinsuranceregistration);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "农村医疗"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "农村医疗",
					MCLink = "/XiangXi/gen/RuralMedicalTreatmentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "农村医疗统计",
					MCLink = "/XiangXi/gen/RuralMedicalTreatmentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var ruralmedicaltreatment = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "农村医疗");
			if(ruralmedicaltreatment!=null)
			{
				ruralmedicaltreatment.MCLink = "/XiangXi/gen/RuralMedicalTreatmentList.html";
				MenuConfiguration.AddOrUpdate(ruralmedicaltreatment);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "福利发放"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "福利发放",
					MCLink = "/XiangXi/gen/WelfareGrantList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "福利发放统计",
					MCLink = "/XiangXi/gen/WelfareGrantAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var welfaregrant = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "福利发放");
			if(welfaregrant!=null)
			{
				welfaregrant.MCLink = "/XiangXi/gen/WelfareGrantList.html";
				MenuConfiguration.AddOrUpdate(welfaregrant);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "服务预约"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "服务预约",
					MCLink = "/XiangXi/gen/ServiceReservationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "服务预约统计",
					MCLink = "/XiangXi/gen/ServiceReservationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var servicereservation = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "服务预约");
			if(servicereservation!=null)
			{
				servicereservation.MCLink = "/XiangXi/gen/ServiceReservationList.html";
				MenuConfiguration.AddOrUpdate(servicereservation);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "日程管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "日程管理",
					MCLink = "/XiangXi/gen/ScheduleManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "日程管理统计",
					MCLink = "/XiangXi/gen/ScheduleManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var schedulemanagement = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "日程管理");
			if(schedulemanagement!=null)
			{
				schedulemanagement.MCLink = "/XiangXi/gen/ScheduleManagementList.html";
				MenuConfiguration.AddOrUpdate(schedulemanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "专家管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "专家管理",
					MCLink = "/XiangXi/gen/ExpertManagementList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "专家管理统计",
					MCLink = "/XiangXi/gen/ExpertManagementAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var expertmanagement = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "专家管理");
			if(expertmanagement!=null)
			{
				expertmanagement.MCLink = "/XiangXi/gen/ExpertManagementList.html";
				MenuConfiguration.AddOrUpdate(expertmanagement);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "权限访问"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "权限访问",
					MCLink = "/XiangXi/gen/AccessList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "权限访问统计",
					MCLink = "/XiangXi/gen/AccessAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var access = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "权限访问");
			if(access!=null)
			{
				access.MCLink = "/XiangXi/gen/AccessList.html";
				MenuConfiguration.AddOrUpdate(access);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "便民指南"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "便民指南",
					MCLink = "/XiangXi/gen/aGuideToTheConvenienceOfPeopleList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "便民指南统计",
					MCLink = "/XiangXi/gen/aGuideToTheConvenienceOfPeopleAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var aguidetotheconvenienceofpeople = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "便民指南");
			if(aguidetotheconvenienceofpeople!=null)
			{
				aguidetotheconvenienceofpeople.MCLink = "/XiangXi/gen/aGuideToTheConvenienceOfPeopleList.html";
				MenuConfiguration.AddOrUpdate(aguidetotheconvenienceofpeople);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "香溪特色"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "香溪特色",
					MCLink = "/XiangXi/gen/FeaturesOfXiangxiList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "香溪特色统计",
					MCLink = "/XiangXi/gen/FeaturesOfXiangxiAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var featuresofxiangxi = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "香溪特色");
			if(featuresofxiangxi!=null)
			{
				featuresofxiangxi.MCLink = "/XiangXi/gen/FeaturesOfXiangxiList.html";
				MenuConfiguration.AddOrUpdate(featuresofxiangxi);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "建议处理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "建议处理",
					MCLink = "/XiangXi/gen/RecommendedTreatmentList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "建议处理统计",
					MCLink = "/XiangXi/gen/RecommendedTreatmentAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var recommendedtreatment = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "建议处理");
			if(recommendedtreatment!=null)
			{
				recommendedtreatment.MCLink = "/XiangXi/gen/RecommendedTreatmentList.html";
				MenuConfiguration.AddOrUpdate(recommendedtreatment);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "村史"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "村史",
					MCLink = "/XiangXi/gen/VillageHistoryList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "村史统计",
					MCLink = "/XiangXi/gen/VillageHistoryAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var villagehistory = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "村史");
			if(villagehistory!=null)
			{
				villagehistory.MCLink = "/XiangXi/gen/VillageHistoryList.html";
				MenuConfiguration.AddOrUpdate(villagehistory);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "专项工作"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "专项工作",
					MCLink = "/XiangXi/gen/SpecialWorkList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "专项工作统计",
					MCLink = "/XiangXi/gen/SpecialWorkAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var specialwork = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "专项工作");
			if(specialwork!=null)
			{
				specialwork.MCLink = "/XiangXi/gen/SpecialWorkList.html";
				MenuConfiguration.AddOrUpdate(specialwork);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "视频点位信息"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "视频点位信息",
					MCLink = "/XiangXi/gen/VideoPointBitInformationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "视频点位信息统计",
					MCLink = "/XiangXi/gen/VideoPointBitInformationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var videopointbitinformation = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "视频点位信息");
			if(videopointbitinformation!=null)
			{
				videopointbitinformation.MCLink = "/XiangXi/gen/VideoPointBitInformationList.html";
				MenuConfiguration.AddOrUpdate(videopointbitinformation);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "就业援助"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "就业援助",
					MCLink = "/XiangXi/gen/EmploymentAssistanceList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "就业援助统计",
					MCLink = "/XiangXi/gen/EmploymentAssistanceAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var employmentassistance = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "就业援助");
			if(employmentassistance!=null)
			{
				employmentassistance.MCLink = "/XiangXi/gen/EmploymentAssistanceList.html";
				MenuConfiguration.AddOrUpdate(employmentassistance);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "危房解危"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "危房解危",
					MCLink = "/XiangXi/gen/CriticalHousingCrisisList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "危房解危统计",
					MCLink = "/XiangXi/gen/CriticalHousingCrisisAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var criticalhousingcrisis = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "危房解危");
			if(criticalhousingcrisis!=null)
			{
				criticalhousingcrisis.MCLink = "/XiangXi/gen/CriticalHousingCrisisList.html";
				MenuConfiguration.AddOrUpdate(criticalhousingcrisis);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "工业园房屋收款"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "工业园房屋收款",
					MCLink = "/XiangXi/gen/IndustrialParkHousingReceiptsList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "工业园房屋收款统计",
					MCLink = "/XiangXi/gen/IndustrialParkHousingReceiptsAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var industrialparkhousingreceipts = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "工业园房屋收款");
			if(industrialparkhousingreceipts!=null)
			{
				industrialparkhousingreceipts.MCLink = "/XiangXi/gen/IndustrialParkHousingReceiptsList.html";
				MenuConfiguration.AddOrUpdate(industrialparkhousingreceipts);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "需求收集"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "需求收集",
					MCLink = "/XiangXi/gen/DemandCollectionList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "需求收集统计",
					MCLink = "/XiangXi/gen/DemandCollectionAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var demandcollection = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "需求收集");
			if(demandcollection!=null)
			{
				demandcollection.MCLink = "/XiangXi/gen/DemandCollectionList.html";
				MenuConfiguration.AddOrUpdate(demandcollection);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党组织信息管理"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党组织信息管理",
					MCLink = "/XiangXi/gen/InformationManagementOfPartyOrganizationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党组织信息管理统计",
					MCLink = "/XiangXi/gen/InformationManagementOfPartyOrganizationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var informationmanagementofpartyorganization = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党组织信息管理");
			if(informationmanagementofpartyorganization!=null)
			{
				informationmanagementofpartyorganization.MCLink = "/XiangXi/gen/InformationManagementOfPartyOrganizationList.html";
				MenuConfiguration.AddOrUpdate(informationmanagementofpartyorganization);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "关爱对象"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "关爱对象",
					MCLink = "/XiangXi/gen/TheObjectOfCareList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "关爱对象统计",
					MCLink = "/XiangXi/gen/TheObjectOfCareAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var theobjectofcare = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "关爱对象");
			if(theobjectofcare!=null)
			{
				theobjectofcare.MCLink = "/XiangXi/gen/TheObjectOfCareList.html";
				MenuConfiguration.AddOrUpdate(theobjectofcare);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "招聘就业模块"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "招聘就业模块",
					MCLink = "/XiangXi/gen/EmploymentModuleList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "招聘就业模块统计",
					MCLink = "/XiangXi/gen/EmploymentModuleAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var employmentmodule = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "招聘就业模块");
			if(employmentmodule!=null)
			{
				employmentmodule.MCLink = "/XiangXi/gen/EmploymentModuleList.html";
				MenuConfiguration.AddOrUpdate(employmentmodule);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党群结队"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党群结队",
					MCLink = "/XiangXi/gen/PartyGroupFormationList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党群结队统计",
					MCLink = "/XiangXi/gen/PartyGroupFormationAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var partygroupformation = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党群结队");
			if(partygroupformation!=null)
			{
				partygroupformation.MCLink = "/XiangXi/gen/PartyGroupFormationList.html";
				MenuConfiguration.AddOrUpdate(partygroupformation);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "党员活动"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党员活动",
					MCLink = "/XiangXi/gen/PartyMembersActivitiesList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "党员活动统计",
					MCLink = "/XiangXi/gen/PartyMembersActivitiesAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var partymembersactivities = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "党员活动");
			if(partymembersactivities!=null)
			{
				partymembersactivities.MCLink = "/XiangXi/gen/PartyMembersActivitiesList.html";
				MenuConfiguration.AddOrUpdate(partymembersactivities);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "美丽乡村"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "美丽乡村",
					MCLink = "/XiangXi/gen/BeautifulCountrysideList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "美丽乡村统计",
					MCLink = "/XiangXi/gen/BeautifulCountrysideAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var beautifulcountryside = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "美丽乡村");
			if(beautifulcountryside!=null)
			{
				beautifulcountryside.MCLink = "/XiangXi/gen/BeautifulCountrysideList.html";
				MenuConfiguration.AddOrUpdate(beautifulcountryside);
			}

			if (!MenuConfiguration.Any(t => t.MCCaption == "引水上山"))
			{
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "引水上山",
					MCLink = "/XiangXi/gen/DrawWaterUpaHillList.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
				MenuConfiguration.Add(new XiangXiENtities.EF.NewEntities.MenuConfiguration
				{
					id = Guid.NewGuid().ToString(),
					MCCaption = "引水上山统计",
					MCLink = "/XiangXi/gen/DrawWaterUpaHillAnalysis.html",
					CreateBy = CreateBy,
					TransactionID = TransactionID,
					IsDeleted = 0,
					DataLevel = "01",
				});
			}
			var drawwaterupahill = MenuConfiguration.FirstOrDefault(t => t.MCCaption == "引水上山");
			if(drawwaterupahill!=null)
			{
				drawwaterupahill.MCLink = "/XiangXi/gen/DrawWaterUpaHillList.html";
				MenuConfiguration.AddOrUpdate(drawwaterupahill);
			}
            
		}

        /// <summary>
        ///  社情民意 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.SocialConditionsAndPublicOpinions> SocialConditionsAndPublicOpinions { get; set; }

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
        public virtual DbSet<XiangXiENtities.EF.NewEntities.UserRole> UserRole { get; set; }

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
        public virtual DbSet<XiangXiENtities.EF.NewEntities.LogonRecord> LogonRecord { get; set; }

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
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RecordingLectures> RecordingLectures { get; set; }

        /// <summary>
        ///  三会一课 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ThreeSessions> ThreeSessions { get; set; }

        /// <summary>
        ///  专题学习 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ThematicStudy> ThematicStudy { get; set; }

        /// <summary>
        ///  政策文件 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PolicyDocument> PolicyDocument { get; set; }

        /// <summary>
        ///  政策文件类别 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PolicyDocumentCategory> PolicyDocumentCategory { get; set; }

        /// <summary>
        ///  统战对象明细 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.UnitedFrontObjectDetails> UnitedFrontObjectDetails { get; set; }

        /// <summary>
        ///  回民清真饮食补贴发放 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.MuslimFoodSubsidies> MuslimFoodSubsidies { get; set; }

        /// <summary>
        ///  现役军人名单 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ListOfActiveServicemen> ListOfActiveServicemen { get; set; }

        /// <summary>
        ///  征兵对象名单 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ListOfRecruits> ListOfRecruits { get; set; }

        /// <summary>
        ///  共青团 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.TheCommunistYouthLeague> TheCommunistYouthLeague { get; set; }

        /// <summary>
        ///  重点人员 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.KeyPersonnel> KeyPersonnel { get; set; }

        /// <summary>
        ///  信访 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.LetterAndVisit> LetterAndVisit { get; set; }

        /// <summary>
        ///  两类人员 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.TwoCategoriesOfPersonnel> TwoCategoriesOfPersonnel { get; set; }

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
        ///  三产楼栋 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ThreeProductionBuilding> ThreeProductionBuilding { get; set; }

        /// <summary>
        ///  厂房楼栋 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Building> Building { get; set; }

        /// <summary>
        ///  收租记录 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RentRecord> RentRecord { get; set; }

        /// <summary>
        ///  电费缴纳记录 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RecordOfElectricityPayment> RecordOfElectricityPayment { get; set; }

        /// <summary>
        ///  工作日志 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.WorkLog> WorkLog { get; set; }

        /// <summary>
        ///  通知 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Advise> Advise { get; set; }

        /// <summary>
        ///  文档管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.DocumentManagement> DocumentManagement { get; set; }

        /// <summary>
        ///  人口 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Population> Population { get; set; }

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
        ///  POI 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.POI> POI { get; set; }

        /// <summary>
        ///  党建要闻管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PartyNewsManagement> PartyNewsManagement { get; set; }

        /// <summary>
        ///  随手拍 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Pat> Pat { get; set; }

        /// <summary>
        ///  主动巡检 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ActiveInspection> ActiveInspection { get; set; }

        /// <summary>
        ///  业务预约 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.BusinessReservation> BusinessReservation { get; set; }

        /// <summary>
        ///  提建议记录 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.SuggestionRecord> SuggestionRecord { get; set; }

        /// <summary>
        ///  党风廉政学习 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.TheStudyOfPartyStyleAndCleanGovernment> TheStudyOfPartyStyleAndCleanGovernment { get; set; }

        /// <summary>
        ///  公共设施 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Service> Service { get; set; }

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
        public virtual DbSet<XiangXiENtities.EF.NewEntities.MembershipDuesPaymentManagement> MembershipDuesPaymentManagement { get; set; }

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
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PartyBuildingProject> PartyBuildingProject { get; set; }

        /// <summary>
        ///  办事指南 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.GuideToAffairs> GuideToAffairs { get; set; }

        /// <summary>
        ///  党务指南 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.GuideToPartyAffairs> GuideToPartyAffairs { get; set; }

        /// <summary>
        ///  业务管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.BusinessManagement> BusinessManagement { get; set; }

        /// <summary>
        ///  少儿医保 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ChildrensMedicalInsuranceRegistration> ChildrensMedicalInsuranceRegistration { get; set; }

        /// <summary>
        ///  农村医疗 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RuralMedicalTreatment> RuralMedicalTreatment { get; set; }

        /// <summary>
        ///  福利发放 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.WelfareGrant> WelfareGrant { get; set; }

        /// <summary>
        ///  服务预约 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.ServiceReservation> ServiceReservation { get; set; }

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
        public virtual DbSet<XiangXiENtities.EF.NewEntities.Access> Access { get; set; }

        /// <summary>
        ///  便民指南 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.aGuideToTheConvenienceOfPeople> aGuideToTheConvenienceOfPeople { get; set; }

        /// <summary>
        ///  香溪特色 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.FeaturesOfXiangxi> FeaturesOfXiangxi { get; set; }

        /// <summary>
        ///  建议处理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.RecommendedTreatment> RecommendedTreatment { get; set; }

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
        public virtual DbSet<XiangXiENtities.EF.NewEntities.VideoPointBitInformation> VideoPointBitInformation { get; set; }

        /// <summary>
        ///  就业援助 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.EmploymentAssistance> EmploymentAssistance { get; set; }

        /// <summary>
        ///  危房解危 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.CriticalHousingCrisis> CriticalHousingCrisis { get; set; }

        /// <summary>
        ///  工业园房屋收款 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.IndustrialParkHousingReceipts> IndustrialParkHousingReceipts { get; set; }

        /// <summary>
        ///  需求收集 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.DemandCollection> DemandCollection { get; set; }

        /// <summary>
        ///  党组织信息管理 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.InformationManagementOfPartyOrganization> InformationManagementOfPartyOrganization { get; set; }

        /// <summary>
        ///  关爱对象 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.TheObjectOfCare> TheObjectOfCare { get; set; }

        /// <summary>
        ///  招聘就业模块 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.EmploymentModule> EmploymentModule { get; set; }

        /// <summary>
        ///  党群结队 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PartyGroupFormation> PartyGroupFormation { get; set; }

        /// <summary>
        ///  党员活动 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.PartyMembersActivities> PartyMembersActivities { get; set; }

        /// <summary>
        ///  美丽乡村 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.BeautifulCountryside> BeautifulCountryside { get; set; }

        /// <summary>
        ///  引水上山 
        /// </summary>
        public virtual DbSet<XiangXiENtities.EF.NewEntities.DrawWaterUpaHill> DrawWaterUpaHill { get; set; }
    }
}
namespace XiangXiENtities.EF.NewEntities
{
	
    /// <summary>
    ///  社情民意 
    /// </summary>
	[Table("SocialConditionsAndPublicOpinions")]
    public class SocialConditionsAndPublicOpinions 
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
        ///  类型 
        /// </summary>
        public string SCAPOForm { get; set; }
			
        /// <summary>
        ///  发布人 
        /// </summary>
        public string SCAPOPublisher { get; set; }
			
        /// <summary>
        ///  区域 
        /// </summary>
        public string SCAPODistrict { get; set; }
			
        /// <summary>
        ///  详情 
        /// </summary>
        public string SCAPODetailsOfTheCase { get; set; }
			
        /// <summary>
        ///  上传文件 
        /// </summary>
        public string SCAPOUploadingFiles { get; set; }
	}

	
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
        public string MCCaption { get; set; }
			
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
        public Nullable<int> MCSequence { get; set; }
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
	[Table("UserRole")]
    public class UserRole 
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
        public string UICode { get; set; }
			
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
        public string UIBackwardness { get; set; }
			
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
        public string UISubordinateDepartment { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string UIBooth { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string UIPhoto { get; set; }
	}

	
    /// <summary>
    ///  登录记录 
    /// </summary>
	[Table("LogonRecord")]
    public class LogonRecord 
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
        public string UMCaption { get; set; }
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
        public string IMOPMName { get; set; }
			
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
        public string IMOPMChairperson { get; set; }
			
        /// <summary>
        ///  民族 
        /// </summary>
        public string IMOPMCivilization { get; set; }
			
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
        public Nullable<DateTime> IMOPMDateOfAdmissionToTheParty { get; set; }
			
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
        public string IMOPMHomeAddress { get; set; }
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
        public string PFMName { get; set; }
			
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
        public string PFMMonthlyPartyFee { get; set; }
	}

	
    /// <summary>
    ///  党课记录 
    /// </summary>
	[Table("RecordingLectures")]
    public class RecordingLectures 
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
        public string RLName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string RLIdCard { get; set; }
			
        /// <summary>
        ///  课程名称 
        /// </summary>
        public string RLCourseName { get; set; }
			
        /// <summary>
        ///  课程摘要 
        /// </summary>
        public string RLCourseSummary { get; set; }
			
        /// <summary>
        ///  学习情况 
        /// </summary>
        public string RLLearningSituation { get; set; }
			
        /// <summary>
        ///  课程时间 
        /// </summary>
        public Nullable<DateTime> RLCourseTime { get; set; }
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
        public string TSParticipants { get; set; }
			
        /// <summary>
        ///  与会人数 
        /// </summary>
        public string TSNumberOfParticipants { get; set; }
			
        /// <summary>
        ///  主持人 
        /// </summary>
        public string TSHostess { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string TSContent { get; set; }
			
        /// <summary>
        ///  类型 
        /// </summary>
        public string TSForm { get; set; }
	}

	
    /// <summary>
    ///  专题学习 
    /// </summary>
	[Table("ThematicStudy")]
    public class ThematicStudy 
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
        ///  专题内容 
        /// </summary>
        public string TSThematicContent { get; set; }
			
        /// <summary>
        ///  参与人员 
        /// </summary>
        public string TSParticipants { get; set; }
			
        /// <summary>
        ///  与会人数 
        /// </summary>
        public string TSNumberOfParticipants { get; set; }
			
        /// <summary>
        ///  主持人 
        /// </summary>
        public string TSHostess { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string TSContent { get; set; }
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
        public string PDPolicyDocumentCategory { get; set; }
			
        /// <summary>
        ///  专文件主题 
        /// </summary>
        public string PDDedicatedDocumentTopics { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string PDContent { get; set; }
			
        /// <summary>
        ///  上传文件 
        /// </summary>
        public string PDUploadingFiles { get; set; }
			
        /// <summary>
        ///  年份 
        /// </summary>
        public string PDParticularYear { get; set; }
	}

	
    /// <summary>
    ///  政策文件类别 
    /// </summary>
	[Table("PolicyDocumentCategory")]
    public class PolicyDocumentCategory 
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
        public string PDCCategoryName { get; set; }
			
        /// <summary>
        ///  描述 
        /// </summary>
        public string PDCDepict { get; set; }
			
        /// <summary>
        ///  政策文件 
        /// </summary>
        // public List<PolicyDocument> PolicyDocument { get; set; }
	}

	
    /// <summary>
    ///  统战对象明细 
    /// </summary>
	[Table("UnitedFrontObjectDetails")]
    public class UnitedFrontObjectDetails 
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
        public string UFODName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string UFODChairperson { get; set; }
			
        /// <summary>
        ///  民族 
        /// </summary>
        public string UFODCivilization { get; set; }
			
        /// <summary>
        ///  家庭住址 
        /// </summary>
        public string UFODHomeAddress { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string UFODIdCard { get; set; }
			
        /// <summary>
        ///  联系方式 
        /// </summary>
        public string UFODCommonModeOfContact { get; set; }
			
        /// <summary>
        ///  类型 
        /// </summary>
        public string UFODForm { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string UFODRemarks { get; set; }
	}

	
    /// <summary>
    ///  回民清真饮食补贴发放 
    /// </summary>
	[Table("MuslimFoodSubsidies")]
    public class MuslimFoodSubsidies 
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
        public string MFSName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string MFSChairperson { get; set; }
			
        /// <summary>
        ///  民族 
        /// </summary>
        public string MFSCivilization { get; set; }
			
        /// <summary>
        ///  家庭住址 
        /// </summary>
        public string MFSHomeAddress { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string MFSIdCard { get; set; }
			
        /// <summary>
        ///  联系方式 
        /// </summary>
        public string MFSCommonModeOfContact { get; set; }
			
        /// <summary>
        ///  补贴标准 
        /// </summary>
        public string MFSStandardOfSubsidy { get; set; }
			
        /// <summary>
        ///  实发金额 
        /// </summary>
        public Nullable<decimal> MFSRealAmountOfMoney { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string MFSRemarks { get; set; }
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
        public string LOASName { get; set; }
			
        /// <summary>
        ///  民族 
        /// </summary>
        public string LOASCivilization { get; set; }
			
        /// <summary>
        ///  家庭住址 
        /// </summary>
        public string LOASHomeAddress { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string LOASIdCard { get; set; }
			
        /// <summary>
        ///  联系方式 
        /// </summary>
        public string LOASCommonModeOfContact { get; set; }
			
        /// <summary>
        ///  家庭情况 
        /// </summary>
        public string LOASFamilySituation { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string LOASRemarks { get; set; }
	}

	
    /// <summary>
    ///  征兵对象名单 
    /// </summary>
	[Table("ListOfRecruits")]
    public class ListOfRecruits 
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
        public string LORName { get; set; }
			
        /// <summary>
        ///  出生年月 
        /// </summary>
        public string LORDateOfBirth { get; set; }
			
        /// <summary>
        ///  文化程度 
        /// </summary>
        public string LORDegreeOfEducation { get; set; }
			
        /// <summary>
        ///  政治面貌 
        /// </summary>
        public string LORPoliticalOutlook { get; set; }
			
        /// <summary>
        ///  户口性质 
        /// </summary>
        public string LORNatureOfHouseholdRegistration { get; set; }
			
        /// <summary>
        ///  毕业院校 
        /// </summary>
        public string LORUniversityOneIsGraduatedFrom { get; set; }
			
        /// <summary>
        ///  联系方式 
        /// </summary>
        public string LORCommonModeOfContact { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string LORIdCard { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string LORRemarks { get; set; }
	}

	
    /// <summary>
    ///  共青团 
    /// </summary>
	[Table("TheCommunistYouthLeague")]
    public class TheCommunistYouthLeague 
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
        public string TCYLSerialNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string TCYLName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string TCYLChairperson { get; set; }
			
        /// <summary>
        ///  出生日期 
        /// </summary>
        public Nullable<DateTime> TCYLDateOfBirth { get; set; }
			
        /// <summary>
        ///  志愿时间 
        /// </summary>
        public Nullable<DateTime> TCYLVolunteerTime { get; set; }
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
        public string KPName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string KPChairperson { get; set; }
			
        /// <summary>
        ///  居住地 
        /// </summary>
        public string KPPlaceOfResidence { get; set; }
			
        /// <summary>
        ///  户籍地 
        /// </summary>
        public string KPDomicilePlace { get; set; }
			
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
	[Table("LetterAndVisit")]
    public class LetterAndVisit 
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
        public string LAVDealWithTheResults { get; set; }
	}

	
    /// <summary>
    ///  两类人员 
    /// </summary>
	[Table("TwoCategoriesOfPersonnel")]
    public class TwoCategoriesOfPersonnel 
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
        public string TCOPTheCommunityInWhichItIsLocated { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string TCOPName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string TCOPChairperson { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string TCOPIdCard { get; set; }
			
        /// <summary>
        ///  罪名 
        /// </summary>
        public string TCOPCharge { get; set; }
			
        /// <summary>
        ///  家庭住址 
        /// </summary>
        public string TCOPHomeAddress { get; set; }
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
        public string FFamilyOrganizationName { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string FName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string FIdCard { get; set; }
			
        /// <summary>
        ///  新生儿姓名 
        /// </summary>
        public string FNameOfTheNewborn { get; set; }
			
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
        public string FCommonModeOfContact { get; set; }
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
        ///  姓名 
        /// </summary>
        public string IName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string IIdCard { get; set; }
			
        /// <summary>
        ///  产业名称 
        /// </summary>
        public string IIndustryName { get; set; }
			
        /// <summary>
        ///  物业股占比 
        /// </summary>
        public string IPropertyShareRatio { get; set; }
			
        /// <summary>
        ///  资产股占比 
        /// </summary>
        public string IAssetShareRatio { get; set; }
			
        /// <summary>
        ///  投资股占比 
        /// </summary>
        public string IInvestmentShareRatio { get; set; }
			
        /// <summary>
        ///  继承自 
        /// </summary>
        public string IInherit { get; set; }
			
        /// <summary>
        ///  是否有效 
        /// </summary>
        public string IIsItValid { get; set; }
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
        public string BRName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string BRIdCard { get; set; }
			
        /// <summary>
        ///  股份类型 
        /// </summary>
        public string BRTypesOfShares { get; set; }
			
        /// <summary>
        ///  股票占比 
        /// </summary>
        public string BRShareRatio { get; set; }
			
        /// <summary>
        ///  发放金额 
        /// </summary>
        public Nullable<decimal> BRAmountOfPayment { get; set; }
			
        /// <summary>
        ///  发放时间 
        /// </summary>
        public Nullable<DateTime> BRReleaseTime { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string BRSuperinrtendent { get; set; }
			
        /// <summary>
        ///  负责人联系方式 
        /// </summary>
        public string BRContactModeOfThePersonInCharge { get; set; }
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
        public string CName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string CIdCard { get; set; }
			
        /// <summary>
        ///  上级领导 
        /// </summary>
        public string CSuperiorLeadership { get; set; }
			
        /// <summary>
        ///  所属支部 
        /// </summary>
        public string CBranch { get; set; }
			
        /// <summary>
        ///  劳模 
        /// </summary>
        public string CModelWorker { get; set; }
			
        /// <summary>
        ///  干部类型 
        /// </summary>
        public string CTypeOfCadre { get; set; }
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
        public string MName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string MIdCard { get; set; }
			
        /// <summary>
        ///  上级领导 
        /// </summary>
        public string MSuperiorLeadership { get; set; }
			
        /// <summary>
        ///  所属番号 
        /// </summary>
        public string MTheDesignation { get; set; }
			
        /// <summary>
        ///  民兵类型 
        /// </summary>
        public string MTypeOfMilitia { get; set; }
	}

	
    /// <summary>
    ///  三产楼栋 
    /// </summary>
	[Table("ThreeProductionBuilding")]
    public class ThreeProductionBuilding 
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
        public string TPBName { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string TPBAddress { get; set; }
			
        /// <summary>
        ///  楼号 
        /// </summary>
        public string TPBBuildingNumber { get; set; }
			
        /// <summary>
        ///  单元号 
        /// </summary>
        public string TPBUnitNumber { get; set; }
			
        /// <summary>
        ///  门牌号 
        /// </summary>
        public string TPBDoorNumber { get; set; }
			
        /// <summary>
        ///  入驻企业名称 
        /// </summary>
        public string TPBTheNameOfEnterprise { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string TPBSuperinrtendent { get; set; }
			
        /// <summary>
        ///  负责人联系方式 
        /// </summary>
        public string TPBContactModeOfThePersonInCharge { get; set; }
			
        /// <summary>
        ///  范围 
        /// </summary>
        public string TPBExtent { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string TPBRemarks { get; set; }
	}

	
    /// <summary>
    ///  厂房楼栋 
    /// </summary>
	[Table("Building")]
    public class Building 
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
        public string BIndustrialParkName { get; set; }
			
        /// <summary>
        ///  序号 
        /// </summary>
        public string BSerialNumber { get; set; }
			
        /// <summary>
        ///  承租户 
        /// </summary>
        public string BTenant { get; set; }
			
        /// <summary>
        ///  起止 
        /// </summary>
        public string BStartAndStop { get; set; }
			
        /// <summary>
        ///  承租面积 
        /// </summary>
        public Nullable<Single> BRentingArea { get; set; }
			
        /// <summary>
        ///  押金 
        /// </summary>
        public string BDeposit { get; set; }
			
        /// <summary>
        ///  单价 
        /// </summary>
        public string BUnitPrice { get; set; }
			
        /// <summary>
        ///  月租金 
        /// </summary>
        public string BMonthlyRent { get; set; }
			
        /// <summary>
        ///  年租金 
        /// </summary>
        public string BAnnualRent { get; set; }
			
        /// <summary>
        ///  租凭单位性质 
        /// </summary>
        public string BPropertyOfRentingUnits { get; set; }
			
        /// <summary>
        ///  环保手续 
        /// </summary>
        public string BEnvironmentalProtectionFormalities { get; set; }
			
        /// <summary>
        ///  建筑面积 
        /// </summary>
        public Nullable<Single> BBuiltUpArea { get; set; }
			
        /// <summary>
        ///  开始时间 
        /// </summary>
        public Nullable<DateTime> BStartTime { get; set; }
			
        /// <summary>
        ///  结束时间 
        /// </summary>
        public Nullable<DateTime> BEndTime { get; set; }
			
        /// <summary>
        ///  联系人 
        /// </summary>
        public string BContacts { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string BContactNumber { get; set; }
			
        /// <summary>
        ///  审批文件 
        /// </summary>
        public string BApprovalDocument { get; set; }
			
        /// <summary>
        ///  楼号 
        /// </summary>
        public string BBuildingNumber { get; set; }
			
        /// <summary>
        ///  单元号 
        /// </summary>
        public string BUnitNumber { get; set; }
			
        /// <summary>
        ///  门牌号 
        /// </summary>
        public string BDoorNumber { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string BSuperinrtendent { get; set; }
			
        /// <summary>
        ///  负责人联系方式 
        /// </summary>
        public string BContactModeOfThePersonInCharge { get; set; }
			
        /// <summary>
        ///  范围 
        /// </summary>
        public string BExtent { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string BRemarks { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string BAddress { get; set; }
			
        /// <summary>
        ///  工业园房屋收款 
        /// </summary>
        // public List<IndustrialParkHousingReceipts> IndustrialParkHousingReceipts { get; set; }
	}

	
    /// <summary>
    ///  收租记录 
    /// </summary>
	[Table("RentRecord")]
    public class RentRecord 
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
        public string RREnterpriseName { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string RRSuperinrtendent { get; set; }
			
        /// <summary>
        ///  负责人电话 
        /// </summary>
        public string RREnterpriseLeaderPhone { get; set; }
			
        /// <summary>
        ///  付款金额 
        /// </summary>
        public Nullable<decimal> RRAmountOfPayment { get; set; }
			
        /// <summary>
        ///  收款人 
        /// </summary>
        public string RRPayee { get; set; }
			
        /// <summary>
        ///  收款人电话 
        /// </summary>
        public string RRPayeePhone { get; set; }
			
        /// <summary>
        ///  收款金额 
        /// </summary>
        public Nullable<decimal> RRAmountCollected { get; set; }
			
        /// <summary>
        ///  收款时间 
        /// </summary>
        public Nullable<DateTime> RRCollectionTime { get; set; }
			
        /// <summary>
        ///  应收款时间 
        /// </summary>
        public Nullable<DateTime> RRTimeOfReceivables { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string RRRemarks { get; set; }
			
        /// <summary>
        ///  工业园名称 
        /// </summary>
        public string RRIndustrialParkName { get; set; }
	}

	
    /// <summary>
    ///  电费缴纳记录 
    /// </summary>
	[Table("RecordOfElectricityPayment")]
    public class RecordOfElectricityPayment 
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
        public string ROEPEnterpriseName { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string ROEPSuperinrtendent { get; set; }
			
        /// <summary>
        ///  负责人电话 
        /// </summary>
        public string ROEPEnterpriseLeaderPhone { get; set; }
			
        /// <summary>
        ///  付款金额 
        /// </summary>
        public Nullable<decimal> ROEPAmountOfPayment { get; set; }
			
        /// <summary>
        ///  收款人 
        /// </summary>
        public string ROEPPayee { get; set; }
			
        /// <summary>
        ///  收款人电话 
        /// </summary>
        public string ROEPPayeePhone { get; set; }
			
        /// <summary>
        ///  收款金额 
        /// </summary>
        public Nullable<decimal> ROEPAmountCollected { get; set; }
			
        /// <summary>
        ///  收款时间 
        /// </summary>
        public Nullable<DateTime> ROEPCollectionTime { get; set; }
			
        /// <summary>
        ///  应收款时间 
        /// </summary>
        public Nullable<DateTime> ROEPTimeOfReceivables { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string ROEPRemarks { get; set; }
	}

	
    /// <summary>
    ///  工作日志 
    /// </summary>
	[Table("WorkLog")]
    public class WorkLog 
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
        public string WLSerialNumber { get; set; }
			
        /// <summary>
        ///  条线 
        /// </summary>
        public string WLLine { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string WLSuperinrtendent { get; set; }
			
        /// <summary>
        ///  日期 
        /// </summary>
        public Nullable<DateTime> WLDate { get; set; }
			
        /// <summary>
        ///  办理事项 
        /// </summary>
        public string WLHandlingMatters { get; set; }
			
        /// <summary>
        ///  是否完成 
        /// </summary>
        public string WLIsItDone { get; set; }
			
        /// <summary>
        ///  完成时间 
        /// </summary>
        public Nullable<DateTime> WLCompletionTime { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string WLRemarks { get; set; }
	}

	
    /// <summary>
    ///  通知 
    /// </summary>
	[Table("Advise")]
    public class Advise 
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
        public string ACaption { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string AContent { get; set; }
			
        /// <summary>
        ///  作者 
        /// </summary>
        public string AAuthor { get; set; }
			
        /// <summary>
        ///  通知发送日期 
        /// </summary>
        public Nullable<DateTime> ANotificationDeliveryDate { get; set; }
			
        /// <summary>
        ///  通知发送对象 
        /// </summary>
        public string ANotifyingTheSendingObject { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string ARemarks { get; set; }
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
        public string DMCaption { get; set; }
			
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
        public string PName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string PChairperson { get; set; }
			
        /// <summary>
        ///  出生日期 
        /// </summary>
        public Nullable<DateTime> PDateOfBirth { get; set; }
			
        /// <summary>
        ///  居村委会 
        /// </summary>
        public string PVillageCommittee { get; set; }
			
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
        public string HPIdNumber { get; set; }
			
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
        public string HPDoorNumber { get; set; }
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
        public string RLName { get; set; }
			
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
        public string RLBusFee { get; set; }
			
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
        public string MLNameOfPersonnel { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string MLIdNumber { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string MLChairperson { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string MLBooth { get; set; }
			
        /// <summary>
        ///  手机 
        /// </summary>
        public string ML { get; set; }
			
        /// <summary>
        ///  邮箱 
        /// </summary>
        public string MLMailbox { get; set; }
			
        /// <summary>
        ///  职位 
        /// </summary>
        public string MLPost { get; set; }
			
        /// <summary>
        ///  上级领导 
        /// </summary>
        public string MLSuperiorLeadership { get; set; }
			
        /// <summary>
        ///  QQ 
        /// </summary>
        public string MLQQ { get; set; }
			
        /// <summary>
        ///  微信 
        /// </summary>
        public string MLWechat { get; set; }
	}

	
    /// <summary>
    ///  POI 
    /// </summary>
	[Table("POI")]
    public class POI 
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
        public string POIAddress { get; set; }
	}

	
    /// <summary>
    ///  党建要闻管理 
    /// </summary>
	[Table("PartyNewsManagement")]
    public class PartyNewsManagement 
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
        public string PNMCaption { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string PNMContent { get; set; }
			
        /// <summary>
        ///  作者 
        /// </summary>
        public string PNMAuthor { get; set; }
			
        /// <summary>
        ///  发布时间 
        /// </summary>
        public Nullable<DateTime> PNMReleaseTime { get; set; }
			
        /// <summary>
        ///  类别 
        /// </summary>
        public string PNMCategory { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string PNMPicture { get; set; }
	}

	
    /// <summary>
    ///  随手拍 
    /// </summary>
	[Table("Pat")]
    public class Pat 
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
        public string PContent { get; set; }
			
        /// <summary>
        ///  设备 
        /// </summary>
        public string PApparatus { get; set; }
			
        /// <summary>
        ///  用户ID 
        /// </summary>
        public string PUserId { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string PPhoto { get; set; }
			
        /// <summary>
        ///  拍照时间 
        /// </summary>
        public Nullable<DateTime> PPhotoOp { get; set; }
			
        /// <summary>
        ///  位置 
        /// </summary>
        public string PLocation { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string PName { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string PBooth { get; set; }
			
        /// <summary>
        ///  区域 
        /// </summary>
        public string PDistrict { get; set; }
			
        /// <summary>
        ///  点赞数目 
        /// </summary>
        public string PNumberOfPointsPraise { get; set; }
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
        public string AIBackwardness { get; set; }
			
        /// <summary>
        ///  用户 
        /// </summary>
        public string AIClient { get; set; }
			
        /// <summary>
        ///  区域 
        /// </summary>
        public string AIDistrict { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string AIPicture { get; set; }
			
        /// <summary>
        ///  位置 
        /// </summary>
        public string AILocation { get; set; }
	}

	
    /// <summary>
    ///  业务预约 
    /// </summary>
	[Table("BusinessReservation")]
    public class BusinessReservation 
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
        public string BRBanking { get; set; }
			
        /// <summary>
        ///  服务 
        /// </summary>
        public string BRAttendant { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string BRName { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string BRIdNumber { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string BRBooth { get; set; }
			
        /// <summary>
        ///  创建时间 
        /// </summary>
        public Nullable<DateTime> BRCreationTime { get; set; }
			
        /// <summary>
        ///  受理时间 
        /// </summary>
        public Nullable<DateTime> BRHallAcceptanceTime { get; set; }
			
        /// <summary>
        ///  状态 
        /// </summary>
        public string BRBackwardness { get; set; }
	}

	
    /// <summary>
    ///  提建议记录 
    /// </summary>
	[Table("SuggestionRecord")]
    public class SuggestionRecord 
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
        public string SRCaption { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string SRContent { get; set; }
			
        /// <summary>
        ///  对象 
        /// </summary>
        public string SRTarget { get; set; }
			
        /// <summary>
        ///  处理人 
        /// </summary>
        public string SRProcessingPerson { get; set; }
			
        /// <summary>
        ///  处理日期 
        /// </summary>
        public Nullable<DateTime> SRProcessingDate { get; set; }
	}

	
    /// <summary>
    ///  党风廉政学习 
    /// </summary>
	[Table("TheStudyOfPartyStyleAndCleanGovernment")]
    public class TheStudyOfPartyStyleAndCleanGovernment 
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
        public string TSOPSACGCaption { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string TSOPSACGContent { get; set; }
			
        /// <summary>
        ///  学习对象 
        /// </summary>
        public string TSOPSACGLearningObject { get; set; }
			
        /// <summary>
        ///  学习日期 
        /// </summary>
        public Nullable<DateTime> TSOPSACGLearningDate { get; set; }
			
        /// <summary>
        ///  备注 
        /// </summary>
        public string TSOPSACGRemarks { get; set; }
	}

	
    /// <summary>
    ///  公共设施 
    /// </summary>
	[Table("Service")]
    public class Service 
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
        public string SName { get; set; }
			
        /// <summary>
        ///  位置 
        /// </summary>
        public string SLocation { get; set; }
			
        /// <summary>
        ///  类型 
        /// </summary>
        public string SForm { get; set; }
			
        /// <summary>
        ///  归属 
        /// </summary>
        public string SAscription { get; set; }
			
        /// <summary>
        ///  换新日期 
        /// </summary>
        public Nullable<DateTime> SNewDate { get; set; }
			
        /// <summary>
        ///  是否损坏 
        /// </summary>
        public string SIsItDamaged { get; set; }
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
        public string SCCaption { get; set; }
			
        /// <summary>
        ///  分类 
        /// </summary>
        public string SCClassification { get; set; }
			
        /// <summary>
        ///  子分类 
        /// </summary>
        public string SCSubclassification { get; set; }
			
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
        public string PBCaption { get; set; }
			
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
	[Table("MembershipDuesPaymentManagement")]
    public class MembershipDuesPaymentManagement 
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
        public string MDPMName { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string MDPMBooth { get; set; }
			
        /// <summary>
        ///  金额 
        /// </summary>
        public Nullable<decimal> MDPMConsolationAmount { get; set; }
			
        /// <summary>
        ///  日期 
        /// </summary>
        public Nullable<DateTime> MDPMDate { get; set; }
			
        /// <summary>
        ///  收款人 
        /// </summary>
        public string MDPMPayee { get; set; }
			
        /// <summary>
        ///  所属支部 
        /// </summary>
        public string MDPMBranch { get; set; }
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
        public string CMSignaturesOfPartyb { get; set; }
			
        /// <summary>
        ///  丙方签名 
        /// </summary>
        public string CMPartycSignature { get; set; }
			
        /// <summary>
        ///  签署日期 
        /// </summary>
        public Nullable<DateTime> CMDateOfSigning { get; set; }
			
        /// <summary>
        ///  签署机构 
        /// </summary>
        public string CMSigningAgency { get; set; }
			
        /// <summary>
        ///  合同文件上传 
        /// </summary>
        public string CMContractFileUpload { get; set; }
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
        public string PICode { get; set; }
			
        /// <summary>
        ///  头像 
        /// </summary>
        public string PIHeadPortrait { get; set; }
			
        /// <summary>
        ///  上次登录时间 
        /// </summary>
        public Nullable<DateTime> PILastLoginTime { get; set; }
			
        /// <summary>
        ///  所属部门 
        /// </summary>
        public string PISubordinateDepartment { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string PIBooth { get; set; }
			
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
        public string SWCaption { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string SWContent { get; set; }
			
        /// <summary>
        ///  地点 
        /// </summary>
        public string SWLocality { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string SWSuperinrtendent { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string SWBooth { get; set; }
			
        /// <summary>
        ///  开始时间 
        /// </summary>
        public Nullable<DateTime> SWStartTime { get; set; }
			
        /// <summary>
        ///  结束时间 
        /// </summary>
        public Nullable<DateTime> SWEndTime { get; set; }
	}

	
    /// <summary>
    ///  党建专题 
    /// </summary>
	[Table("PartyBuildingProject")]
    public class PartyBuildingProject 
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
        public string PBPCaption { get; set; }
			
        /// <summary>
        ///  预览 
        /// </summary>
        public string PBPPreview { get; set; }
			
        /// <summary>
        ///  发布时间 
        /// </summary>
        public Nullable<DateTime> PBPReleaseTime { get; set; }
			
        /// <summary>
        ///  查看 
        /// </summary>
        public string PBPSee { get; set; }
	}

	
    /// <summary>
    ///  办事指南 
    /// </summary>
	[Table("GuideToAffairs")]
    public class GuideToAffairs 
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
        public string GTACategory { get; set; }
			
        /// <summary>
        ///  办事内容 
        /// </summary>
        public string GTAWorkContent { get; set; }
			
        /// <summary>
        ///  所需材料 
        /// </summary>
        public string GTARequiredMaterials { get; set; }
			
        /// <summary>
        ///  办事程序 
        /// </summary>
        public string GTAProceduralProcedure { get; set; }
	}

	
    /// <summary>
    ///  党务指南 
    /// </summary>
	[Table("GuideToPartyAffairs")]
    public class GuideToPartyAffairs 
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
        public string GTPACaption { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string GTPAContent { get; set; }
			
        /// <summary>
        ///  类别 
        /// </summary>
        public string GTPACategory { get; set; }
			
        /// <summary>
        ///  适用范围 
        /// </summary>
        public string GTPAScopeOfApplication { get; set; }
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
        public string BMIdNumber { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string BMChairperson { get; set; }
			
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
        public string BMBackwardness { get; set; }
	}

	
    /// <summary>
    ///  少儿医保 
    /// </summary>
	[Table("ChildrensMedicalInsuranceRegistration")]
    public class ChildrensMedicalInsuranceRegistration 
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
        public string CMIRUnitNumber { get; set; }
			
        /// <summary>
        ///  人员编号 
        /// </summary>
        public string CMIRPersonnelNumber { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string CMIRName { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string CMIRIdNumber { get; set; }
			
        /// <summary>
        ///  出生日期 
        /// </summary>
        public Nullable<DateTime> CMIRDateOfBirth { get; set; }
			
        /// <summary>
        ///  免缴种类 
        /// </summary>
        public string CMIRExemptedSpecies { get; set; }
			
        /// <summary>
        ///  免缴号码 
        /// </summary>
        public string CMIRExemptionNumber { get; set; }
			
        /// <summary>
        ///  联系人 
        /// </summary>
        public string CMIRContacts { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string CMIRContactNumber { get; set; }
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
        public string RMTName { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string RMTIdNumber { get; set; }
			
        /// <summary>
        ///  免缴种类 
        /// </summary>
        public string RMTExemptedSpecies { get; set; }
			
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
        public string RMTDistrict { get; set; }
			
        /// <summary>
        ///  操作 
        /// </summary>
        public string RMTDiscern { get; set; }
	}

	
    /// <summary>
    ///  福利发放 
    /// </summary>
	[Table("WelfareGrant")]
    public class WelfareGrant 
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
        public string WGName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string WGChairperson { get; set; }
			
        /// <summary>
        ///  年龄 
        /// </summary>
        public Nullable<int> WGAge { get; set; }
			
        /// <summary>
        ///  身份证号 
        /// </summary>
        public string WGIdNumber { get; set; }
			
        /// <summary>
        ///  福利类型 
        /// </summary>
        public string WGWelfareType { get; set; }
			
        /// <summary>
        ///  发放金额 
        /// </summary>
        public Nullable<decimal> WGAmountOfPayment { get; set; }
			
        /// <summary>
        ///  发放日期 
        /// </summary>
        public Nullable<DateTime> WGDateOfIssuance { get; set; }
			
        /// <summary>
        ///  被保人id 
        /// </summary>
        public string WGTheInsuredId { get; set; }
			
        /// <summary>
        ///  住址 
        /// </summary>
        public string WGAddress { get; set; }
			
        /// <summary>
        ///  区域 
        /// </summary>
        public string WGDistrict { get; set; }
			
        /// <summary>
        ///  操作 
        /// </summary>
        public string WGDiscern { get; set; }
	}

	
    /// <summary>
    ///  服务预约 
    /// </summary>
	[Table("ServiceReservation")]
    public class ServiceReservation 
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
        public string SRServiceType { get; set; }
			
        /// <summary>
        ///  预约人 
        /// </summary>
        public string SRReservations { get; set; }
			
        /// <summary>
        ///  预约时间 
        /// </summary>
        public Nullable<DateTime> SRTimeOfAppointment { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string SRIdNumber { get; set; }
			
        /// <summary>
        ///  创建时间 
        /// </summary>
        public Nullable<DateTime> SRCreationTime { get; set; }
			
        /// <summary>
        ///  审核时间 
        /// </summary>
        public Nullable<DateTime> SRAuditTime { get; set; }
			
        /// <summary>
        ///  状态 
        /// </summary>
        public string SRBackwardness { get; set; }
			
        /// <summary>
        ///  审核登记 
        /// </summary>
        public string SRAuditRegistration { get; set; }
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
        public string SMLocality { get; set; }
			
        /// <summary>
        ///  负责人 
        /// </summary>
        public string SMSuperinrtendent { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string SMBooth { get; set; }
			
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
        public string EMName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string EMChairperson { get; set; }
			
        /// <summary>
        ///  出生日期 
        /// </summary>
        public Nullable<DateTime> EMDateOfBirth { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string EMIdNumber { get; set; }
			
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
	[Table("Access")]
    public class Access 
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
        public string AName { get; set; }
			
        /// <summary>
        ///  访问时间 
        /// </summary>
        public Nullable<DateTime> AAccessTime { get; set; }
	}

	
    /// <summary>
    ///  便民指南 
    /// </summary>
	[Table("aGuideToTheConvenienceOfPeople")]
    public class aGuideToTheConvenienceOfPeople 
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
        public string GTTCOPCaption { get; set; }
			
        /// <summary>
        ///  发布时间 
        /// </summary>
        public Nullable<DateTime> GTTCOPReleaseTime { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string GTTCOPPicture { get; set; }
	}

	
    /// <summary>
    ///  香溪特色 
    /// </summary>
	[Table("FeaturesOfXiangxi")]
    public class FeaturesOfXiangxi 
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
        public string FOXCaption { get; set; }
			
        /// <summary>
        ///  发布时间 
        /// </summary>
        public Nullable<DateTime> FOXReleaseTime { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string FOXPicture { get; set; }
	}

	
    /// <summary>
    ///  建议处理 
    /// </summary>
	[Table("RecommendedTreatment")]
    public class RecommendedTreatment 
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
        public string RTCaption { get; set; }
			
        /// <summary>
        ///  内容 
        /// </summary>
        public string RTContent { get; set; }
			
        /// <summary>
        ///  对象 
        /// </summary>
        public string RTTarget { get; set; }
			
        /// <summary>
        ///  处理人 
        /// </summary>
        public string RTProcessingPerson { get; set; }
			
        /// <summary>
        ///  处理日期 
        /// </summary>
        public Nullable<DateTime> RTProcessingDate { get; set; }
			
        /// <summary>
        ///  姓名 
        /// </summary>
        public string RTName { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string RTIdNumber { get; set; }
			
        /// <summary>
        ///  电话 
        /// </summary>
        public string RTBooth { get; set; }
			
        /// <summary>
        ///  创建时间 
        /// </summary>
        public Nullable<DateTime> RTCreationTime { get; set; }
			
        /// <summary>
        ///  状态 
        /// </summary>
        public string RTBackwardness { get; set; }
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
        public string VHSubtitle { get; set; }
			
        /// <summary>
        ///  图片 
        /// </summary>
        public string VHPicture { get; set; }
			
        /// <summary>
        ///  摘要 
        /// </summary>
        public string VHAbridge { get; set; }
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
        public string SWBackwardness { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string SWPhoto { get; set; }
	}

	
    /// <summary>
    ///  视频点位信息 
    /// </summary>
	[Table("VideoPointBitInformation")]
    public class VideoPointBitInformation 
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
        public string VPBISerialNumber { get; set; }
			
        /// <summary>
        ///  监控点名称 
        /// </summary>
        public string VPBIMonitorPointName { get; set; }
			
        /// <summary>
        ///  监控点编号 
        /// </summary>
        public string VPBIMonitoringPointNumber { get; set; }
			
        /// <summary>
        ///  所属组织 
        /// </summary>
        public string VPBIAffiliatedOrganization { get; set; }
			
        /// <summary>
        ///  所属区域 
        /// </summary>
        public string VPBIBelongToTheRegion { get; set; }
			
        /// <summary>
        ///  所属平台 
        /// </summary>
        public string VPBIPlatform { get; set; }
			
        /// <summary>
        ///  经度 
        /// </summary>
        public string VPBILongitude { get; set; }
			
        /// <summary>
        ///  纬度 
        /// </summary>
        public string VPBILatitude { get; set; }
			
        /// <summary>
        ///  地址 
        /// </summary>
        public string VPBIAddress { get; set; }
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
        public string EAName { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string EAIdCard { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string EAChairperson { get; set; }
			
        /// <summary>
        ///  民族 
        /// </summary>
        public string EACivilization { get; set; }
			
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
        public string EANatureOfHouseholdRegistration { get; set; }
			
        /// <summary>
        ///  是否残疾 
        /// </summary>
        public string EAWhetherOrNotDisability { get; set; }
			
        /// <summary>
        ///  培训意愿 
        /// </summary>
        public string EATrainingWill { get; set; }
			
        /// <summary>
        ///  联系方式 
        /// </summary>
        public string EACommonModeOfContact { get; set; }
			
        /// <summary>
        ///  人员类型 
        /// </summary>
        public string EATypeOfPersonnel { get; set; }
			
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
	[Table("CriticalHousingCrisis")]
    public class CriticalHousingCrisis 
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
        public string CHCOwner { get; set; }
			
        /// <summary>
        ///  房屋座落 
        /// </summary>
        public string CHCHouseSeat { get; set; }
			
        /// <summary>
        ///  房产证面积 
        /// </summary>
        public Nullable<Single> CHCRealEstateCertificateArea { get; set; }
			
        /// <summary>
        ///  土地证面积 
        /// </summary>
        public Nullable<Single> CHCLandCertificateArea { get; set; }
			
        /// <summary>
        ///  测绘面积 
        /// </summary>
        public Nullable<Single> CHCSurveyingArea { get; set; }
			
        /// <summary>
        ///  测绘增补面积 
        /// </summary>
        public Nullable<Single> CHCMappingArea { get; set; }
			
        /// <summary>
        ///  安置面积 
        /// </summary>
        public Nullable<Single> CHCResettlementArea { get; set; }
			
        /// <summary>
        ///  签字时间 
        /// </summary>
        public Nullable<DateTime> CHCSignatureTime { get; set; }
			
        /// <summary>
        ///  交房时间 
        /// </summary>
        public Nullable<DateTime> CHCRoomTime { get; set; }
			
        /// <summary>
        ///  补偿金额 
        /// </summary>
        public Nullable<decimal> CHCAmountOfCompensation { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string CHCContactNumber { get; set; }
			
        /// <summary>
        ///  现居住地址 
        /// </summary>
        public string CHCCurrentAddress { get; set; }
	}

	
    /// <summary>
    ///  工业园房屋收款 
    /// </summary>
	[Table("IndustrialParkHousingReceipts")]
    public class IndustrialParkHousingReceipts 
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
        public string IPHRBuilding { get; set; }
			
        /// <summary>
        ///  开始时间 
        /// </summary>
        public Nullable<DateTime> IPHRStartTime { get; set; }
			
        /// <summary>
        ///  结束时间 
        /// </summary>
        public Nullable<DateTime> IPHREndTime { get; set; }
			
        /// <summary>
        ///  付款金额 
        /// </summary>
        public Nullable<decimal> IPHRAmountOfPayment { get; set; }
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
	[Table("InformationManagementOfPartyOrganization")]
    public class InformationManagementOfPartyOrganization 
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
        public string IMOPOPartyOrganizationSecretary { get; set; }
			
        /// <summary>
        ///  党组织联系人 
        /// </summary>
        public string IMOPOPartyOrganizationContacts { get; set; }
			
        /// <summary>
        ///  联系电话 
        /// </summary>
        public string IMOPOContactNumber { get; set; }
			
        /// <summary>
        ///  组织类别 
        /// </summary>
        public string IMOPOOrganizationCategory { get; set; }
			
        /// <summary>
        ///  上级党组织名称 
        /// </summary>
        public string IMOPONameOfHigherLevelPartyOrganization { get; set; }
	}

	
    /// <summary>
    ///  关爱对象 
    /// </summary>
	[Table("TheObjectOfCare")]
    public class TheObjectOfCare 
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
        public string TOOCName { get; set; }
			
        /// <summary>
        ///  性别 
        /// </summary>
        public string TOOCChairperson { get; set; }
			
        /// <summary>
        ///  类型 
        /// </summary>
        public string TOOCForm { get; set; }
			
        /// <summary>
        ///  身份证 
        /// </summary>
        public string TOOCIdNumber { get; set; }
			
        /// <summary>
        ///  户口所在地 
        /// </summary>
        public string TOOCRegisteredResidence { get; set; }
			
        /// <summary>
        ///  常住地 
        /// </summary>
        public string TOOCPermanentResidence { get; set; }
			
        /// <summary>
        ///  楼栋号 
        /// </summary>
        public string TOOCBuildingNumber { get; set; }
			
        /// <summary>
        ///  单元号 
        /// </summary>
        public string TOOCUnitNumber { get; set; }
			
        /// <summary>
        ///  门牌号 
        /// </summary>
        public string TOOCDoorNumber { get; set; }
	}

	
    /// <summary>
    ///  招聘就业模块 
    /// </summary>
	[Table("EmploymentModule")]
    public class EmploymentModule 
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
        public string EMEmployers { get; set; }
			
        /// <summary>
        ///  职位 
        /// </summary>
        public string EMPost { get; set; }
			
        /// <summary>
        ///  发布人 
        /// </summary>
        public string EMPublisher { get; set; }
			
        /// <summary>
        ///  职位描述 
        /// </summary>
        public string EMJobDescription { get; set; }
			
        /// <summary>
        ///  职位职责内容 
        /// </summary>
        public string EMJobResponsibilities { get; set; }
			
        /// <summary>
        ///  职位要求内容 
        /// </summary>
        public string EMJobRequirements { get; set; }
			
        /// <summary>
        ///  生效时间 
        /// </summary>
        public Nullable<DateTime> EMEntryIntoForceTime { get; set; }
			
        /// <summary>
        ///  失效时间 
        /// </summary>
        public Nullable<DateTime> EMFailureTime { get; set; }
	}

	
    /// <summary>
    ///  党群结队 
    /// </summary>
	[Table("PartyGroupFormation")]
    public class PartyGroupFormation 
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
        public string PGFPartyOrganization { get; set; }
			
        /// <summary>
        ///  成员姓名 
        /// </summary>
        public string PGFNameOfaMember { get; set; }
			
        /// <summary>
        ///  身份证号码 
        /// </summary>
        public string PGFIdCard { get; set; }
			
        /// <summary>
        ///  创建时间 
        /// </summary>
        public Nullable<DateTime> PGFCreationTime { get; set; }
	}

	
    /// <summary>
    ///  党员活动 
    /// </summary>
	[Table("PartyMembersActivities")]
    public class PartyMembersActivities 
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
        public string PMABriefIntroductionOfActivities { get; set; }
			
        /// <summary>
        ///  覆盖范围 
        /// </summary>
        public string PMACoverageRange { get; set; }
			
        /// <summary>
        ///  活动照片 
        /// </summary>
        public string PMAActivePhoto { get; set; }
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
        public string BCCaption { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string BCPhoto { get; set; }
			
        /// <summary>
        ///  建设成果 
        /// </summary>
        public string BCConstructionResults { get; set; }
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
        public string DWUHCaption { get; set; }
			
        /// <summary>
        ///  照片 
        /// </summary>
        public string DWUHPhoto { get; set; }
			
        /// <summary>
        ///  建设成果 
        /// </summary>
        public string DWUHConstructionResults { get; set; }
	}

}
