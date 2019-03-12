

/* ------------------------------------------------------------ *
 * 此文件由生成器引擎根据既有规则生成，所有手工的更改将会被覆盖
 * 生成时间：03/12/2019 13:34:34
 * 生成版本：03/12/2019 13:33:51 
 * 作者：路正遥
 * ------------------------------------------------------------ */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using XiangXi.Evaluators;

using XiangXi.Models;
using System.Text;
using System.Data.Entity.Migrations;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi
{
    public class ImportProc
    {	
        public static string ExportEntities(string title)
        {
            var buf = new StringBuilder();
            using (var tx = new DefaultContext())
            {
				if(string.IsNullOrEmpty(title)) return string.Empty;
											
				else if (title == "MenuConfiguration")
				{
					buf.AppendLine("唯一编号\t标题\t链接\t图片\t父级标题\t菜单类型\t顺序\t显示名称\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (MenuConfiguration);
					foreach (var entity in tx.MenuConfiguration)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.MCTitle);buf.Append("\t");
														
						buf.Append(entity.MCLink);buf.Append("\t");
														
						buf.Append(entity.MCPicture);buf.Append("\t");
														
						buf.Append(entity.MCParentTitle);buf.Append("\t");
														
						buf.Append(entity.MCMenuType);buf.Append("\t");
														
						buf.Append(entity.MCOrder);buf.Append("\t");
														
						buf.Append(entity.MCDisplayName);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "RoleMenu")
				{
					buf.AppendLine("唯一编号\t角色名称\t菜单标题\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (RoleMenu);
					foreach (var entity in tx.RoleMenu)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.RMRoleName);buf.Append("\t");
														
						buf.Append(entity.RMMenuTitle);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "UserRoles")
				{
					buf.AppendLine("唯一编号\t角色名称\t登录名\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (UserRoles);
					foreach (var entity in tx.UserRoles)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.URRoleName);buf.Append("\t");
														
						buf.Append(entity.URLoginName);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "RoleConfiguration")
				{
					buf.AppendLine("唯一编号\t角色名称\t所属组织\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (RoleConfiguration);
					foreach (var entity in tx.RoleConfiguration)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.RCRoleName);buf.Append("\t");
														
						buf.Append(entity.RCAffiliatedOrganization);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "UserInformation")
				{
					buf.AppendLine("唯一编号\t登录名\t密码\t用户类型\t用户级别\t状态\t昵称\t真实姓名\t头像\t所属部门\t电话\t照片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (UserInformation);
					foreach (var entity in tx.UserInformation)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.UILoginName);buf.Append("\t");
														
						buf.Append(entity.UIPassword);buf.Append("\t");
														
						buf.Append(entity.UICustomerType);buf.Append("\t");
														
						buf.Append(entity.UIUserLevel);buf.Append("\t");
														
						buf.Append(entity.UIState);buf.Append("\t");
														
						buf.Append(entity.UINickname);buf.Append("\t");
														
						buf.Append(entity.UIRealName);buf.Append("\t");
														
						buf.Append(entity.UIHeadPortrait);buf.Append("\t");
														
						buf.Append(entity.UISubordinateDepartments);buf.Append("\t");
														
						buf.Append(entity.UITelephone);buf.Append("\t");
														
						buf.Append(entity.UIPhoto);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "LoginRecord")
				{
					buf.AppendLine("唯一编号\t登录名\t登录时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (LoginRecord);
					foreach (var entity in tx.LoginRecord)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.LRLoginName);buf.Append("\t");
														
						buf.Append(entity.LRLoginTime);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "UserMenu")
				{
					buf.AppendLine("唯一编号\t登录名\t标题\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (UserMenu);
					foreach (var entity in tx.UserMenu)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.UMLoginName);buf.Append("\t");
														
						buf.Append(entity.UMTitle);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "InformationManagementOfPartyMembers")
				{
					buf.AppendLine("唯一编号\t姓名\t身份证号\t出生日期\t性别\t民族\t学历\t类别\t所在党支部\t入党日期\t转正日期\t工作岗位\t联系电话\t家庭住址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (InformationManagementOfPartyMembers);
					foreach (var entity in tx.InformationManagementOfPartyMembers)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.IMOPMFullName);buf.Append("\t");
														
						buf.Append(entity.IMOPMIdNumber);buf.Append("\t");
														
						buf.Append(entity.IMOPMDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.IMOPMGender);buf.Append("\t");
														
						buf.Append(entity.IMOPMNation);buf.Append("\t");
														
						buf.Append(entity.IMOPMEducation);buf.Append("\t");
														
						buf.Append(entity.IMOPMCategory);buf.Append("\t");
														
						buf.Append(entity.IMOPMPartyBranch);buf.Append("\t");
														
						buf.Append(entity.IMOPMDateOfJoiningTheParty);buf.Append("\t");
														
						buf.Append(entity.IMOPMDateOfCorrection);buf.Append("\t");
														
						buf.Append(entity.IMOPMPost);buf.Append("\t");
														
						buf.Append(entity.IMOPMContactNumber);buf.Append("\t");
														
						buf.Append(entity.IMOPMFamilyAddress);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "PartyFeeManagement")
				{
					buf.AppendLine("唯一编号\t姓名\t身份证号\t年龄\t所在党支部\t月收入\t月党费\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (PartyFeeManagement);
					foreach (var entity in tx.PartyFeeManagement)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PFMFullName);buf.Append("\t");
														
						buf.Append(entity.PFMIdNumber);buf.Append("\t");
														
						buf.Append(entity.PFMAge);buf.Append("\t");
														
						buf.Append(entity.PFMPartyBranch);buf.Append("\t");
														
						buf.Append(entity.PFMMonthlyIncome);buf.Append("\t");
														
						buf.Append(entity.PFMMonthlyPartyMembershipFee);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "PartyRecord")
				{
					buf.AppendLine("唯一编号\t姓名\t身份证号码\t课程名称\t课程摘要\t学习情况\t课程时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (PartyRecord);
					foreach (var entity in tx.PartyRecord)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PRFullName);buf.Append("\t");
														
						buf.Append(entity.PRIdCardNo);buf.Append("\t");
														
						buf.Append(entity.PRCourseTitle);buf.Append("\t");
														
						buf.Append(entity.PRCourseSummary);buf.Append("\t");
														
						buf.Append(entity.PRLearningSituation);buf.Append("\t");
														
						buf.Append(entity.PRCourseTime);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ThreeSessions")
				{
					buf.AppendLine("唯一编号\t日期\t主题\t参与人员\t与会人数\t主持人\t内容\t类型\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ThreeSessions);
					foreach (var entity in tx.ThreeSessions)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.TSDate);buf.Append("\t");
														
						buf.Append(entity.TSTheme);buf.Append("\t");
														
						buf.Append(entity.TSParticipant);buf.Append("\t");
														
						buf.Append(entity.TSNumberOfParticipants);buf.Append("\t");
														
						buf.Append(entity.TSHost);buf.Append("\t");
														
						buf.Append(entity.TSContent);buf.Append("\t");
														
						buf.Append(entity.TSType);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ThematicLearning")
				{
					buf.AppendLine("唯一编号\t日期\t专题内容\t参与人员\t与会人数\t主持人\t内容\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ThematicLearning);
					foreach (var entity in tx.ThematicLearning)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.TLDate);buf.Append("\t");
														
						buf.Append(entity.TLThematicContent);buf.Append("\t");
														
						buf.Append(entity.TLParticipant);buf.Append("\t");
														
						buf.Append(entity.TLNumberOfParticipants);buf.Append("\t");
														
						buf.Append(entity.TLHost);buf.Append("\t");
														
						buf.Append(entity.TLContent);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "PolicyDocument")
				{
					buf.AppendLine("唯一编号\t文件号\t@政策文件类别\t专文件主题\t内容\t上传文件\t年份\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (PolicyDocument);
					foreach (var entity in tx.PolicyDocument)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PDFileNumber);buf.Append("\t");
														
						buf.Append(entity.PDCategoriesOfPolicyDocuments);buf.Append("\t");
														
						buf.Append(entity.PDThemeOfSpecialDocument);buf.Append("\t");
														
						buf.Append(entity.PDContent);buf.Append("\t");
														
						buf.Append(entity.PDUploadFiles);buf.Append("\t");
														
						buf.Append(entity.PDParticularYear);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "CategoriesOfPolicyDocuments")
				{
					buf.AppendLine("唯一编号\t类别名称\t描述\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (CategoriesOfPolicyDocuments);
					foreach (var entity in tx.CategoriesOfPolicyDocuments)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.COPDCategoryName);buf.Append("\t");
														
						buf.Append(entity.COPDDescribe);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ListOfActiveServicemen")
				{
					buf.AppendLine("唯一编号\t姓名\t民族\t家庭住址\t身份证号码\t联系方式\t家庭情况\t备注\t性别\t出生年月\t文化程度\t户口所在地\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ListOfActiveServicemen);
					foreach (var entity in tx.ListOfActiveServicemen)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.LOASFullName);buf.Append("\t");
														
						buf.Append(entity.LOASNation);buf.Append("\t");
														
						buf.Append(entity.LOASFamilyAddress);buf.Append("\t");
														
						buf.Append(entity.LOASIdCardNo);buf.Append("\t");
														
						buf.Append(entity.LOASContactInformation);buf.Append("\t");
														
						buf.Append(entity.LOASFamilySituation);buf.Append("\t");
														
						buf.Append(entity.LOASRemarks);buf.Append("\t");
														
						buf.Append(entity.LOASGender);buf.Append("\t");
														
						buf.Append(entity.LOASDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.LOASDegreeOfEducation);buf.Append("\t");
														
						buf.Append(entity.LOASRegisteredResidence);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ListOfConscripts")
				{
					buf.AppendLine("唯一编号\t姓名\t出生年月\t文化程度\t政治面貌\t户口性质\t毕业院校\t联系方式\t身份证号码\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ListOfConscripts);
					foreach (var entity in tx.ListOfConscripts)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.LOCFullName);buf.Append("\t");
														
						buf.Append(entity.LOCDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.LOCDegreeOfEducation);buf.Append("\t");
														
						buf.Append(entity.LOCPoliticalOutlook);buf.Append("\t");
														
						buf.Append(entity.LOCAccountCharacter);buf.Append("\t");
														
						buf.Append(entity.LOCUniversityOneIsGraduatedFrom);buf.Append("\t");
														
						buf.Append(entity.LOCContactInformation);buf.Append("\t");
														
						buf.Append(entity.LOCIdCardNo);buf.Append("\t");
														
						buf.Append(entity.LOCRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "CommunistYouthLeague")
				{
					buf.AppendLine("唯一编号\t序号\t姓名\t性别\t出生年月\t志愿时间\t籍贯\t学历\t入团年月\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (CommunistYouthLeague);
					foreach (var entity in tx.CommunistYouthLeague)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.CYLSerialNumber);buf.Append("\t");
														
						buf.Append(entity.CYLFullName);buf.Append("\t");
														
						buf.Append(entity.CYLGender);buf.Append("\t");
														
						buf.Append(entity.CYLDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.CYLVolunteerTime);buf.Append("\t");
														
						buf.Append(entity.CYLNativePlace);buf.Append("\t");
														
						buf.Append(entity.CYLEducation);buf.Append("\t");
														
						buf.Append(entity.CYLJoiningTheLeagueYear);buf.Append("\t");
														
						buf.Append(entity.CYLRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "KeyPersonnel")
				{
					buf.AppendLine("唯一编号\t序号\t姓名\t性别\t居住地\t户籍地\t事由\t目前状态\t联系电话\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (KeyPersonnel);
					foreach (var entity in tx.KeyPersonnel)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.KPSerialNumber);buf.Append("\t");
														
						buf.Append(entity.KPFullName);buf.Append("\t");
														
						buf.Append(entity.KPGender);buf.Append("\t");
														
						buf.Append(entity.KPPlaceOfResidence);buf.Append("\t");
														
						buf.Append(entity.KPDomicile);buf.Append("\t");
														
						buf.Append(entity.KPCause);buf.Append("\t");
														
						buf.Append(entity.KPCurrentState);buf.Append("\t");
														
						buf.Append(entity.KPContactNumber);buf.Append("\t");
														
						buf.Append(entity.KPRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "LettersAndVisits")
				{
					buf.AppendLine("唯一编号\t序号\t投诉事件\t投诉地点\t办理结果\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (LettersAndVisits);
					foreach (var entity in tx.LettersAndVisits)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.LAVSerialNumber);buf.Append("\t");
														
						buf.Append(entity.LAVComplaints);buf.Append("\t");
														
						buf.Append(entity.LAVPlaceOfComplaint);buf.Append("\t");
														
						buf.Append(entity.LAVHandlingResult);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "TheTwoCategoryOfPersonnel")
				{
					buf.AppendLine("唯一编号\t所在社区\t姓名\t性别\t身份证号码\t罪名\t家庭住址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (TheTwoCategoryOfPersonnel);
					foreach (var entity in tx.TheTwoCategoryOfPersonnel)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.TTCOPLocalCommunity);buf.Append("\t");
														
						buf.Append(entity.TTCOPFullName);buf.Append("\t");
														
						buf.Append(entity.TTCOPGender);buf.Append("\t");
														
						buf.Append(entity.TTCOPIdCardNo);buf.Append("\t");
														
						buf.Append(entity.TTCOPCharge);buf.Append("\t");
														
						buf.Append(entity.TTCOPFamilyAddress);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Family")
				{
					buf.AppendLine("唯一编号\t家庭组织名称\t姓名\t身份证号码\t新生儿姓名\t死亡证明\t居住地\t联系方式\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Family);
					foreach (var entity in tx.Family)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.FNameOfFamilyOrganization);buf.Append("\t");
														
						buf.Append(entity.FFullName);buf.Append("\t");
														
						buf.Append(entity.FIdCardNo);buf.Append("\t");
														
						buf.Append(entity.FNameOfNewborn);buf.Append("\t");
														
						buf.Append(entity.FDeathCertificate);buf.Append("\t");
														
						buf.Append(entity.FPlaceOfResidence);buf.Append("\t");
														
						buf.Append(entity.FContactInformation);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Investors")
				{
					buf.AppendLine("唯一编号\t序号\t户编号\t股权证编号\t身份证号码\t户主\t姓名\t性别\t出生年月\t周岁\t基本股\t应得股份股\t户合计股数\t确认签名\t配股说明\t统计主题1\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Investors);
					foreach (var entity in tx.Investors)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.ISerialNumber);buf.Append("\t");
														
						buf.Append(entity.IHouseholdNumber);buf.Append("\t");
														
						buf.Append(entity.IEquityCertificateNumber);buf.Append("\t");
														
						buf.Append(entity.IIdCardNo);buf.Append("\t");
														
						buf.Append(entity.IaHouseholder);buf.Append("\t");
														
						buf.Append(entity.IFullName);buf.Append("\t");
														
						buf.Append(entity.IGender);buf.Append("\t");
														
						buf.Append(entity.IDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.IOneYearOld);buf.Append("\t");
														
						buf.Append(entity.IBasicStock);buf.Append("\t");
														
						buf.Append(entity.IDeservedShare);buf.Append("\t");
														
						buf.Append(entity.ITotalNumberOfSharesInaHousehold);buf.Append("\t");
														
						buf.Append(entity.IWitnessing);buf.Append("\t");
														
						buf.Append(entity.IRightsIssue);buf.Append("\t");
														
						buf.Append(entity.IStatisticalTopic1);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "BonusRecord")
				{
					buf.AppendLine("唯一编号\t姓名\t身份证号码\t股份类型\t股票占比\t发放金额\t发放时间\t负责人\t负责人联系方式\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (BonusRecord);
					foreach (var entity in tx.BonusRecord)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.BRFullName);buf.Append("\t");
														
						buf.Append(entity.BRIdCardNo);buf.Append("\t");
														
						buf.Append(entity.BRShareType);buf.Append("\t");
														
						buf.Append(entity.BRShareRatio);buf.Append("\t");
														
						buf.Append(entity.BRPaymentAmount);buf.Append("\t");
														
						buf.Append(entity.BRPaymentTime);buf.Append("\t");
														
						buf.Append(entity.BRPersonInCharge);buf.Append("\t");
														
						buf.Append(entity.BRContactInformationOfPersonInCharge);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Cadre")
				{
					buf.AppendLine("唯一编号\t姓名\t身份证号码\t上级领导\t所属支部\t劳模\t干部类型\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Cadre);
					foreach (var entity in tx.Cadre)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.CFullName);buf.Append("\t");
														
						buf.Append(entity.CIdCardNo);buf.Append("\t");
														
						buf.Append(entity.CSuperiorLeader);buf.Append("\t");
														
						buf.Append(entity.CSubordinateBranch);buf.Append("\t");
														
						buf.Append(entity.CModelWorker);buf.Append("\t");
														
						buf.Append(entity.CTypesOfCadres);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Militia")
				{
					buf.AppendLine("唯一编号\t姓名\t身份证号码\t上级领导\t所属番号\t民兵类型\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Militia);
					foreach (var entity in tx.Militia)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.MFullName);buf.Append("\t");
														
						buf.Append(entity.MIdCardNo);buf.Append("\t");
														
						buf.Append(entity.MSuperiorLeader);buf.Append("\t");
														
						buf.Append(entity.MDesignation);buf.Append("\t");
														
						buf.Append(entity.MMilitiaType);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "UnitedFrontMilitia")
				{
					buf.AppendLine("唯一编号\t姓名\t身份证号码\t上级领导\t所属番号\t民兵类型\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (UnitedFrontMilitia);
					foreach (var entity in tx.UnitedFrontMilitia)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.UFMFullName);buf.Append("\t");
														
						buf.Append(entity.UFMIdCardNo);buf.Append("\t");
														
						buf.Append(entity.UFMSuperiorLeader);buf.Append("\t");
														
						buf.Append(entity.UFMDesignation);buf.Append("\t");
														
						buf.Append(entity.UFMMilitiaType);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "FactoryBuilding")
				{
					buf.AppendLine("唯一编号\t工业园名称\t序号\t承租户\t起止\t承租面积\t押金\t单价\t月租金\t年租金\t租凭单位性质\t环保手续\t建筑面积\t开始时间\t结束时间\t联系人\t联系电话\t审批文件\t楼号\t单元号\t门牌号\t负责人\t负责人联系方式\t范围\t备注\t地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (FactoryBuilding);
					foreach (var entity in tx.FactoryBuilding)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.FBNameOfIndustrialPark);buf.Append("\t");
														
						buf.Append(entity.FBSerialNumber);buf.Append("\t");
														
						buf.Append(entity.FBTenant);buf.Append("\t");
														
						buf.Append(entity.FBStartStop);buf.Append("\t");
														
						buf.Append(entity.FBLesseeArea);buf.Append("\t");
														
						buf.Append(entity.FBDeposit);buf.Append("\t");
														
						buf.Append(entity.FBUnitPrice);buf.Append("\t");
														
						buf.Append(entity.FBMonthlyRent);buf.Append("\t");
														
						buf.Append(entity.FBAnnualRent);buf.Append("\t");
														
						buf.Append(entity.FBCharteredUnitNature);buf.Append("\t");
														
						buf.Append(entity.FBEnvironmentalProtectionProcedures);buf.Append("\t");
														
						buf.Append(entity.FBBuiltupArea);buf.Append("\t");
														
						buf.Append(entity.FBStartTime);buf.Append("\t");
														
						buf.Append(entity.FBEndingTime);buf.Append("\t");
														
						buf.Append(entity.FBContacts);buf.Append("\t");
														
						buf.Append(entity.FBContactNumber);buf.Append("\t");
														
						buf.Append(entity.FBApprovalDocument);buf.Append("\t");
														
						buf.Append(entity.FBBuildingNumber);buf.Append("\t");
														
						buf.Append(entity.FBUnitNumber);buf.Append("\t");
														
						buf.Append(entity.FBHouseNumber);buf.Append("\t");
														
						buf.Append(entity.FBPersonInCharge);buf.Append("\t");
														
						buf.Append(entity.FBContactInformationOfPersonInCharge);buf.Append("\t");
														
						buf.Append(entity.FBRange);buf.Append("\t");
														
						buf.Append(entity.FBRemarks);buf.Append("\t");
														
						buf.Append(entity.FBAddress);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "RentCollectionRecords")
				{
					buf.AppendLine("唯一编号\t企业名称\t负责人\t负责人电话\t付款金额\t收款人\t收款人电话\t收款金额\t收款时间\t应收款时间\t备注\t工业园名称\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (RentCollectionRecords);
					foreach (var entity in tx.RentCollectionRecords)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.RCREnterpriseName);buf.Append("\t");
														
						buf.Append(entity.RCRPersonInCharge);buf.Append("\t");
														
						buf.Append(entity.RCRTelephoneCallsFromThePersonInCharge);buf.Append("\t");
														
						buf.Append(entity.RCRPaymentAmount);buf.Append("\t");
														
						buf.Append(entity.RCRPayee);buf.Append("\t");
														
						buf.Append(entity.RCRCashiersTelephone);buf.Append("\t");
														
						buf.Append(entity.RCRAmountCollected);buf.Append("\t");
														
						buf.Append(entity.RCRCollectionTime);buf.Append("\t");
														
						buf.Append(entity.RCRTimeOfReceivables);buf.Append("\t");
														
						buf.Append(entity.RCRRemarks);buf.Append("\t");
														
						buf.Append(entity.RCRNameOfIndustrialPark);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ElectricityChargePaymentRecord")
				{
					buf.AppendLine("唯一编号\t企业名称\t负责人\t负责人电话\t付款金额\t收款人\t收款人电话\t收款金额\t收款时间\t应收款时间\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ElectricityChargePaymentRecord);
					foreach (var entity in tx.ElectricityChargePaymentRecord)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.ECPREnterpriseName);buf.Append("\t");
														
						buf.Append(entity.ECPRPersonInCharge);buf.Append("\t");
														
						buf.Append(entity.ECPRTelephoneCallsFromThePersonInCharge);buf.Append("\t");
														
						buf.Append(entity.ECPRPaymentAmount);buf.Append("\t");
														
						buf.Append(entity.ECPRPayee);buf.Append("\t");
														
						buf.Append(entity.ECPRCashiersTelephone);buf.Append("\t");
														
						buf.Append(entity.ECPRAmountCollected);buf.Append("\t");
														
						buf.Append(entity.ECPRCollectionTime);buf.Append("\t");
														
						buf.Append(entity.ECPRTimeOfReceivables);buf.Append("\t");
														
						buf.Append(entity.ECPRRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "JobDiary")
				{
					buf.AppendLine("唯一编号\t序号\t条线\t负责人\t日期\t办理事项\t是否完成\t完成时间\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (JobDiary);
					foreach (var entity in tx.JobDiary)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.JDSerialNumber);buf.Append("\t");
														
						buf.Append(entity.JDStripe);buf.Append("\t");
														
						buf.Append(entity.JDPersonInCharge);buf.Append("\t");
														
						buf.Append(entity.JDDate);buf.Append("\t");
														
						buf.Append(entity.JDProcessingMatters);buf.Append("\t");
														
						buf.Append(entity.JDIsItFinished);buf.Append("\t");
														
						buf.Append(entity.JDCompletionTime);buf.Append("\t");
														
						buf.Append(entity.JDRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Notice")
				{
					buf.AppendLine("唯一编号\t标题\t内容\t作者\t通知发送日期\t通知发送对象\t备注\t摘要\t图片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Notice);
					foreach (var entity in tx.Notice)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.NTitle);buf.Append("\t");
														
						buf.Append(entity.NContent);buf.Append("\t");
														
						buf.Append(entity.NAuthor);buf.Append("\t");
														
						buf.Append(entity.NNotificationOfDateOfDispatch);buf.Append("\t");
														
						buf.Append(entity.NNotificationSenderObject);buf.Append("\t");
														
						buf.Append(entity.NRemarks);buf.Append("\t");
														
						buf.Append(entity.NAbstract);buf.Append("\t");
														
						buf.Append(entity.NPicture);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "DocumentManagement")
				{
					buf.AppendLine("唯一编号\t标题\t内容\t作者\t原件图片\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (DocumentManagement);
					foreach (var entity in tx.DocumentManagement)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.DMTitle);buf.Append("\t");
														
						buf.Append(entity.DMContent);buf.Append("\t");
														
						buf.Append(entity.DMAuthor);buf.Append("\t");
														
						buf.Append(entity.DMOriginalPicture);buf.Append("\t");
														
						buf.Append(entity.DMRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Population")
				{
					buf.AppendLine("唯一编号\t公民身份号码\t姓名\t性别\t出生日期\t居村委会\t住址\t年龄\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Population);
					foreach (var entity in tx.Population)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PCitizenshipNumber);buf.Append("\t");
														
						buf.Append(entity.PFullName);buf.Append("\t");
														
						buf.Append(entity.PGender);buf.Append("\t");
														
						buf.Append(entity.PDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.PNeighborhoodVillageCommittee);buf.Append("\t");
														
						buf.Append(entity.PAddress);buf.Append("\t");
														
						buf.Append(entity.PAge);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Newborn")
				{
					buf.AppendLine("唯一编号\t公民身份号码\t姓名\t性别\t出生日期\t居村委会\t住址\t年龄\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Newborn);
					foreach (var entity in tx.Newborn)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.NCitizenshipNumber);buf.Append("\t");
														
						buf.Append(entity.NFullName);buf.Append("\t");
														
						buf.Append(entity.NGender);buf.Append("\t");
														
						buf.Append(entity.NDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.NNeighborhoodVillageCommittee);buf.Append("\t");
														
						buf.Append(entity.NAddress);buf.Append("\t");
														
						buf.Append(entity.NAge);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "HouseProperty")
				{
					buf.AppendLine("唯一编号\t身份证\t地址\t楼栋号\t单元号\t门牌号\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (HouseProperty);
					foreach (var entity in tx.HouseProperty)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.HPId);buf.Append("\t");
														
						buf.Append(entity.HPAddress);buf.Append("\t");
														
						buf.Append(entity.HPBuildingNumber);buf.Append("\t");
														
						buf.Append(entity.HPUnitNumber);buf.Append("\t");
														
						buf.Append(entity.HPHouseNumber);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ReimbursementList")
				{
					buf.AppendLine("唯一编号\t姓名\t出发位置\t目的地位置\t交通费\t住宿费\t住勤补贴\t公交费\t报销日期\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ReimbursementList);
					foreach (var entity in tx.ReimbursementList)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.RLFullName);buf.Append("\t");
														
						buf.Append(entity.RLStartingPosition);buf.Append("\t");
														
						buf.Append(entity.RLDestinationLocation);buf.Append("\t");
														
						buf.Append(entity.RLTrafficExpense);buf.Append("\t");
														
						buf.Append(entity.RLHotelExpense);buf.Append("\t");
														
						buf.Append(entity.RLAccommodationAllowance);buf.Append("\t");
														
						buf.Append(entity.RLBusFare);buf.Append("\t");
														
						buf.Append(entity.RLDateOfReimbursement);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "MailList")
				{
					buf.AppendLine("唯一编号\t机构名称\t人员姓名\t身份证\t性别\t电话\t手机\t邮箱\t职位\t上级领导\tQQ\t微信\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (MailList);
					foreach (var entity in tx.MailList)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.MLOrganizationName);buf.Append("\t");
														
						buf.Append(entity.MLPersonnelName);buf.Append("\t");
														
						buf.Append(entity.MLId);buf.Append("\t");
														
						buf.Append(entity.MLGender);buf.Append("\t");
														
						buf.Append(entity.MLTelephone);buf.Append("\t");
														
						buf.Append(entity.MLMobilePhone);buf.Append("\t");
														
						buf.Append(entity.MLMailbox);buf.Append("\t");
														
						buf.Append(entity.MLPosition);buf.Append("\t");
														
						buf.Append(entity.MLSuperiorLeader);buf.Append("\t");
														
						buf.Append(entity.MLQq);buf.Append("\t");
														
						buf.Append(entity.MLWechat);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Poi")
				{
					buf.AppendLine("唯一编号\t地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Poi);
					foreach (var entity in tx.Poi)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PAddress);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ManagementOfPartyBuildingNews")
				{
					buf.AppendLine("唯一编号\t标题\t内容\t作者\t发布时间\t类别\t图片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ManagementOfPartyBuildingNews);
					foreach (var entity in tx.ManagementOfPartyBuildingNews)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.MOPBNTitle);buf.Append("\t");
														
						buf.Append(entity.MOPBNContent);buf.Append("\t");
														
						buf.Append(entity.MOPBNAuthor);buf.Append("\t");
														
						buf.Append(entity.MOPBNReleaseTime);buf.Append("\t");
														
						buf.Append(entity.MOPBNCategory);buf.Append("\t");
														
						buf.Append(entity.MOPBNPicture);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "FreeToShoot")
				{
					buf.AppendLine("唯一编号\t内容\t设备\t用户ID\t照片\t拍照时间\t位置\t姓名\t电话\t区域\t点赞数目\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (FreeToShoot);
					foreach (var entity in tx.FreeToShoot)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.FTSContent);buf.Append("\t");
														
						buf.Append(entity.FTSEquipment);buf.Append("\t");
														
						buf.Append(entity.FTSUserId);buf.Append("\t");
														
						buf.Append(entity.FTSPhoto);buf.Append("\t");
														
						buf.Append(entity.FTSPhotoop);buf.Append("\t");
														
						buf.Append(entity.FTSPosition);buf.Append("\t");
														
						buf.Append(entity.FTSFullName);buf.Append("\t");
														
						buf.Append(entity.FTSTelephone);buf.Append("\t");
														
						buf.Append(entity.FTSRegion);buf.Append("\t");
														
						buf.Append(entity.FTSNumberOfPoints);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ActiveInspection")
				{
					buf.AppendLine("唯一编号\t巡检问题\t创建时间\t状态\t用户\t区域\t图片\t位置\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ActiveInspection);
					foreach (var entity in tx.ActiveInspection)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.AIInspectionProblem);buf.Append("\t");
														
						buf.Append(entity.AICreationTime);buf.Append("\t");
														
						buf.Append(entity.AIState);buf.Append("\t");
														
						buf.Append(entity.AIUser);buf.Append("\t");
														
						buf.Append(entity.AIRegion);buf.Append("\t");
														
						buf.Append(entity.AIPicture);buf.Append("\t");
														
						buf.Append(entity.AIPosition);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "BusinessAppointment")
				{
					buf.AppendLine("唯一编号\t业务\t服务\t姓名\t身份证\t电话\t创建时间\t受理时间\t状态\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (BusinessAppointment);
					foreach (var entity in tx.BusinessAppointment)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.BABusiness);buf.Append("\t");
														
						buf.Append(entity.BAService);buf.Append("\t");
														
						buf.Append(entity.BAFullName);buf.Append("\t");
														
						buf.Append(entity.BAId);buf.Append("\t");
														
						buf.Append(entity.BATelephone);buf.Append("\t");
														
						buf.Append(entity.BACreationTime);buf.Append("\t");
														
						buf.Append(entity.BAAcceptanceTime);buf.Append("\t");
														
						buf.Append(entity.BAState);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "RecordOfRecommendations")
				{
					buf.AppendLine("唯一编号\t标题\t内容\t对象\t处理人\t处理日期\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (RecordOfRecommendations);
					foreach (var entity in tx.RecordOfRecommendations)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.RORTitle);buf.Append("\t");
														
						buf.Append(entity.RORContent);buf.Append("\t");
														
						buf.Append(entity.RORObject);buf.Append("\t");
														
						buf.Append(entity.RORDealingWithPeople);buf.Append("\t");
														
						buf.Append(entity.RORDateOfProcessing);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "StudyOnPartyStyleAndCleanGovernment")
				{
					buf.AppendLine("唯一编号\t标题\t内容\t学习对象\t学习日期\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (StudyOnPartyStyleAndCleanGovernment);
					foreach (var entity in tx.StudyOnPartyStyleAndCleanGovernment)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.SOPSACGTitle);buf.Append("\t");
														
						buf.Append(entity.SOPSACGContent);buf.Append("\t");
														
						buf.Append(entity.SOPSACGLearningObject);buf.Append("\t");
														
						buf.Append(entity.SOPSACGLearningDate);buf.Append("\t");
														
						buf.Append(entity.SOPSACGRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "CommunalFacilities")
				{
					buf.AppendLine("唯一编号\t名称\t位置\t类型\t归属\t换新日期\t是否损坏\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (CommunalFacilities);
					foreach (var entity in tx.CommunalFacilities)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.CFName);buf.Append("\t");
														
						buf.Append(entity.CFPosition);buf.Append("\t");
														
						buf.Append(entity.CFType);buf.Append("\t");
														
						buf.Append(entity.CFAscription);buf.Append("\t");
														
						buf.Append(entity.CFRenewalDate);buf.Append("\t");
														
						buf.Append(entity.CFIsItDamaged);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "SystemConfiguration")
				{
					buf.AppendLine("唯一编号\t标题\t分类\t子分类\t内容\t是否生效\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (SystemConfiguration);
					foreach (var entity in tx.SystemConfiguration)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.SCTitle);buf.Append("\t");
														
						buf.Append(entity.SCClassification);buf.Append("\t");
														
						buf.Append(entity.SCSubClassification);buf.Append("\t");
														
						buf.Append(entity.SCContent);buf.Append("\t");
														
						buf.Append(entity.SCIsItEffective);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "PartyBuilding")
				{
					buf.AppendLine("唯一编号\t标题\t内容\t发布时间\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (PartyBuilding);
					foreach (var entity in tx.PartyBuilding)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PBTitle);buf.Append("\t");
														
						buf.Append(entity.PBContent);buf.Append("\t");
														
						buf.Append(entity.PBReleaseTime);buf.Append("\t");
														
						buf.Append(entity.PBRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ManagementOfPartyFeePayment")
				{
					buf.AppendLine("唯一编号\t姓名\t电话\t金额\t日期\t收款人\t所属支部\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ManagementOfPartyFeePayment);
					foreach (var entity in tx.ManagementOfPartyFeePayment)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.MOPFPFullName);buf.Append("\t");
														
						buf.Append(entity.MOPFPTelephone);buf.Append("\t");
														
						buf.Append(entity.MOPFPAmountOfMoney);buf.Append("\t");
														
						buf.Append(entity.MOPFPDate);buf.Append("\t");
														
						buf.Append(entity.MOPFPPayee);buf.Append("\t");
														
						buf.Append(entity.MOPFPSubordinateBranch);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ContractManagement")
				{
					buf.AppendLine("唯一编号\t合同编号\t合同名称\t项目名称\t甲方签名\t乙方签名\t丙方签名\t签署日期\t签署机构\t合同文件上传\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ContractManagement);
					foreach (var entity in tx.ContractManagement)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.CMContractNumber);buf.Append("\t");
														
						buf.Append(entity.CMContractName);buf.Append("\t");
														
						buf.Append(entity.CMEntryName);buf.Append("\t");
														
						buf.Append(entity.CMSignatureOfPartya);buf.Append("\t");
														
						buf.Append(entity.CMSignatureOfPartyb);buf.Append("\t");
														
						buf.Append(entity.CMSignatureOfPartyc);buf.Append("\t");
														
						buf.Append(entity.CMSigningDate);buf.Append("\t");
														
						buf.Append(entity.CMSignatory);buf.Append("\t");
														
						buf.Append(entity.CMUploadContractDocuments);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "PersonalInformation")
				{
					buf.AppendLine("唯一编号\t登录名\t昵称\t真实姓名\t密码\t头像\t上次登录时间\t所属部门\t电话\t照片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (PersonalInformation);
					foreach (var entity in tx.PersonalInformation)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PILoginName);buf.Append("\t");
														
						buf.Append(entity.PINickname);buf.Append("\t");
														
						buf.Append(entity.PIRealName);buf.Append("\t");
														
						buf.Append(entity.PIPassword);buf.Append("\t");
														
						buf.Append(entity.PIHeadPortrait);buf.Append("\t");
														
						buf.Append(entity.PILastLogonTime);buf.Append("\t");
														
						buf.Append(entity.PISubordinateDepartments);buf.Append("\t");
														
						buf.Append(entity.PITelephone);buf.Append("\t");
														
						buf.Append(entity.PIPhoto);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ScheduleWork")
				{
					buf.AppendLine("唯一编号\t标题\t内容\t地点\t负责人\t电话\t开始时间\t结束时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ScheduleWork);
					foreach (var entity in tx.ScheduleWork)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.SWTitle);buf.Append("\t");
														
						buf.Append(entity.SWContent);buf.Append("\t");
														
						buf.Append(entity.SWPlace);buf.Append("\t");
														
						buf.Append(entity.SWPersonInCharge);buf.Append("\t");
														
						buf.Append(entity.SWTelephone);buf.Append("\t");
														
						buf.Append(entity.SWStartTime);buf.Append("\t");
														
						buf.Append(entity.SWEndingTime);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "SpecialTopicOnPartyBuilding")
				{
					buf.AppendLine("唯一编号\t标题\t预览\t发布时间\t查看\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (SpecialTopicOnPartyBuilding);
					foreach (var entity in tx.SpecialTopicOnPartyBuilding)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.STOPBTitle);buf.Append("\t");
														
						buf.Append(entity.STOPBPreview);buf.Append("\t");
														
						buf.Append(entity.STOPBReleaseTime);buf.Append("\t");
														
						buf.Append(entity.STOPBSee);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "BusinessGuide")
				{
					buf.AppendLine("唯一编号\t类别\t办事内容\t所需材料\t办事程序\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (BusinessGuide);
					foreach (var entity in tx.BusinessGuide)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.BGCategory);buf.Append("\t");
														
						buf.Append(entity.BGContentOfWork);buf.Append("\t");
														
						buf.Append(entity.BGRequiredMaterials);buf.Append("\t");
														
						buf.Append(entity.BGProcedure);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "PartyAffairsGuide")
				{
					buf.AppendLine("唯一编号\t标题\t内容\t类别\t适用范围\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (PartyAffairsGuide);
					foreach (var entity in tx.PartyAffairsGuide)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PAGTitle);buf.Append("\t");
														
						buf.Append(entity.PAGContent);buf.Append("\t");
														
						buf.Append(entity.PAGCategory);buf.Append("\t");
														
						buf.Append(entity.PAGScopeOfApplication);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "BusinessManagement")
				{
					buf.AppendLine("唯一编号\t业务类型\t服务类型\t申请人\t身份证\t性别\t大厅受理时间\t经办人\t创建时间\t状态\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (BusinessManagement);
					foreach (var entity in tx.BusinessManagement)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.BMBusinessType);buf.Append("\t");
														
						buf.Append(entity.BMServiceType);buf.Append("\t");
														
						buf.Append(entity.BMApplicant);buf.Append("\t");
														
						buf.Append(entity.BMId);buf.Append("\t");
														
						buf.Append(entity.BMGender);buf.Append("\t");
														
						buf.Append(entity.BMHallAcceptanceTime);buf.Append("\t");
														
						buf.Append(entity.BMAgent);buf.Append("\t");
														
						buf.Append(entity.BMCreationTime);buf.Append("\t");
														
						buf.Append(entity.BMState);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "MedicalInsuranceForChildren")
				{
					buf.AppendLine("唯一编号\t单位编号\t人员编号\t姓名\t身份证\t出生日期\t免缴种类\t免缴号码\t联系人\t联系电话\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (MedicalInsuranceForChildren);
					foreach (var entity in tx.MedicalInsuranceForChildren)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.MIFCUnitNumber);buf.Append("\t");
														
						buf.Append(entity.MIFCPersonnelNumber);buf.Append("\t");
														
						buf.Append(entity.MIFCFullName);buf.Append("\t");
														
						buf.Append(entity.MIFCId);buf.Append("\t");
														
						buf.Append(entity.MIFCDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.MIFCExemptionCategory);buf.Append("\t");
														
						buf.Append(entity.MIFCExemptionNumber);buf.Append("\t");
														
						buf.Append(entity.MIFCContacts);buf.Append("\t");
														
						buf.Append(entity.MIFCContactNumber);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "RuralMedicalTreatment")
				{
					buf.AppendLine("唯一编号\t人员编号\t姓名\t身份证\t免缴种类\t免缴号码\t联系人\t联系电话\t区域\t操作\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (RuralMedicalTreatment);
					foreach (var entity in tx.RuralMedicalTreatment)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.RMTPersonnelNumber);buf.Append("\t");
														
						buf.Append(entity.RMTFullName);buf.Append("\t");
														
						buf.Append(entity.RMTId);buf.Append("\t");
														
						buf.Append(entity.RMTExemptionCategory);buf.Append("\t");
														
						buf.Append(entity.RMTExemptionNumber);buf.Append("\t");
														
						buf.Append(entity.RMTContacts);buf.Append("\t");
														
						buf.Append(entity.RMTContactNumber);buf.Append("\t");
														
						buf.Append(entity.RMTRegion);buf.Append("\t");
														
						buf.Append(entity.RMTOperation);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "WelfarePayment")
				{
					buf.AppendLine("唯一编号\t姓名\t性别\t年龄\t身份证号\t福利类型\t发放金额\t发放日期\t被保人id\t住址\t区域\t操作\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (WelfarePayment);
					foreach (var entity in tx.WelfarePayment)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.WPFullName);buf.Append("\t");
														
						buf.Append(entity.WPGender);buf.Append("\t");
														
						buf.Append(entity.WPAge);buf.Append("\t");
														
						buf.Append(entity.WPIdNumber);buf.Append("\t");
														
						buf.Append(entity.WPWelfareType);buf.Append("\t");
														
						buf.Append(entity.WPPaymentAmount);buf.Append("\t");
														
						buf.Append(entity.WPDateOfIssue);buf.Append("\t");
														
						buf.Append(entity.WPInsuredId);buf.Append("\t");
														
						buf.Append(entity.WPAddress);buf.Append("\t");
														
						buf.Append(entity.WPRegion);buf.Append("\t");
														
						buf.Append(entity.WPOperation);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ServiceAppointment")
				{
					buf.AppendLine("唯一编号\t服务类型\t预约人\t预约时间\t身份证\t创建时间\t审核时间\t状态\t审核登记\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ServiceAppointment);
					foreach (var entity in tx.ServiceAppointment)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.SAServiceType);buf.Append("\t");
														
						buf.Append(entity.SAAppointments);buf.Append("\t");
														
						buf.Append(entity.SATimeOfAppointment);buf.Append("\t");
														
						buf.Append(entity.SAId);buf.Append("\t");
														
						buf.Append(entity.SACreationTime);buf.Append("\t");
														
						buf.Append(entity.SAAuditTime);buf.Append("\t");
														
						buf.Append(entity.SAState);buf.Append("\t");
														
						buf.Append(entity.SAAuditRegistration);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ScheduleManagement")
				{
					buf.AppendLine("唯一编号\t活动类型\t开始日期\t结束日期\t内容\t地点\t负责人\t电话\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ScheduleManagement);
					foreach (var entity in tx.ScheduleManagement)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.SMActivityType);buf.Append("\t");
														
						buf.Append(entity.SMStartDate);buf.Append("\t");
														
						buf.Append(entity.SMEndDate);buf.Append("\t");
														
						buf.Append(entity.SMContent);buf.Append("\t");
														
						buf.Append(entity.SMPlace);buf.Append("\t");
														
						buf.Append(entity.SMPersonInCharge);buf.Append("\t");
														
						buf.Append(entity.SMTelephone);buf.Append("\t");
														
						buf.Append(entity.SMRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ExpertManagement")
				{
					buf.AppendLine("唯一编号\t技术特长\t姓名\t性别\t出生日期\t身份证\t地址\t联系电话\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ExpertManagement);
					foreach (var entity in tx.ExpertManagement)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.EMTechnicalExpertise);buf.Append("\t");
														
						buf.Append(entity.EMFullName);buf.Append("\t");
														
						buf.Append(entity.EMGender);buf.Append("\t");
														
						buf.Append(entity.EMDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.EMId);buf.Append("\t");
														
						buf.Append(entity.EMAddress);buf.Append("\t");
														
						buf.Append(entity.EMContactNumber);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "PermissionAccess")
				{
					buf.AppendLine("唯一编号\t姓名\t访问时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (PermissionAccess);
					foreach (var entity in tx.PermissionAccess)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PAFullName);buf.Append("\t");
														
						buf.Append(entity.PAAccessTime);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ConvenienceGuide")
				{
					buf.AppendLine("唯一编号\t标题\t发布时间\t图片\t内容\t摘要\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ConvenienceGuide);
					foreach (var entity in tx.ConvenienceGuide)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.CGTitle);buf.Append("\t");
														
						buf.Append(entity.CGReleaseTime);buf.Append("\t");
														
						buf.Append(entity.CGPicture);buf.Append("\t");
														
						buf.Append(entity.CGContent);buf.Append("\t");
														
						buf.Append(entity.CGAbstract);buf.Append("\t");
														
						buf.Append(entity.CGRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ConvenientLife")
				{
					buf.AppendLine("唯一编号\t标题\t发布时间\t图片\t内容\t摘要\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ConvenientLife);
					foreach (var entity in tx.ConvenientLife)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.CLTitle);buf.Append("\t");
														
						buf.Append(entity.CLReleaseTime);buf.Append("\t");
														
						buf.Append(entity.CLPicture);buf.Append("\t");
														
						buf.Append(entity.CLContent);buf.Append("\t");
														
						buf.Append(entity.CLAbstract);buf.Append("\t");
														
						buf.Append(entity.CLRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "CharacteristicOfXiangxi")
				{
					buf.AppendLine("唯一编号\t标题\t发布时间\t图片\t内容\t摘要\t备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (CharacteristicOfXiangxi);
					foreach (var entity in tx.CharacteristicOfXiangxi)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.COXTitle);buf.Append("\t");
														
						buf.Append(entity.COXReleaseTime);buf.Append("\t");
														
						buf.Append(entity.COXPicture);buf.Append("\t");
														
						buf.Append(entity.COXContent);buf.Append("\t");
														
						buf.Append(entity.COXAbstract);buf.Append("\t");
														
						buf.Append(entity.COXRemarks);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ProposedTreatment")
				{
					buf.AppendLine("唯一编号\t标题\t内容\t对象\t处理人\t处理日期\t姓名\t身份证\t电话\t创建时间\t状态\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ProposedTreatment);
					foreach (var entity in tx.ProposedTreatment)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PTTitle);buf.Append("\t");
														
						buf.Append(entity.PTContent);buf.Append("\t");
														
						buf.Append(entity.PTObject);buf.Append("\t");
														
						buf.Append(entity.PTDealingWithPeople);buf.Append("\t");
														
						buf.Append(entity.PTDateOfProcessing);buf.Append("\t");
														
						buf.Append(entity.PTFullName);buf.Append("\t");
														
						buf.Append(entity.PTId);buf.Append("\t");
														
						buf.Append(entity.PTTelephone);buf.Append("\t");
														
						buf.Append(entity.PTCreationTime);buf.Append("\t");
														
						buf.Append(entity.PTState);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "VillageHistory")
				{
					buf.AppendLine("唯一编号\t菜单项\t主标题\t副标题\t图片\t摘要\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (VillageHistory);
					foreach (var entity in tx.VillageHistory)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.VHMenuItem);buf.Append("\t");
														
						buf.Append(entity.VHMainTitle);buf.Append("\t");
														
						buf.Append(entity.VHSubheading);buf.Append("\t");
														
						buf.Append(entity.VHPicture);buf.Append("\t");
														
						buf.Append(entity.VHAbstract);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "SpecialWork")
				{
					buf.AppendLine("唯一编号\t工作主题\t工作内容\t开始日期\t结束日期\t状态\t照片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (SpecialWork);
					foreach (var entity in tx.SpecialWork)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.SWWorkTheme);buf.Append("\t");
														
						buf.Append(entity.SWJobContent);buf.Append("\t");
														
						buf.Append(entity.SWStartDate);buf.Append("\t");
														
						buf.Append(entity.SWEndDate);buf.Append("\t");
														
						buf.Append(entity.SWState);buf.Append("\t");
														
						buf.Append(entity.SWPhoto);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "VideoPointInformation")
				{
					buf.AppendLine("唯一编号\t序号\t监控点名称\t监控点编号\t所属组织\t所属区域\t所属平台\t经度\t纬度\t地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (VideoPointInformation);
					foreach (var entity in tx.VideoPointInformation)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.VPISerialNumber);buf.Append("\t");
														
						buf.Append(entity.VPIMonitoringPointName);buf.Append("\t");
														
						buf.Append(entity.VPIMonitoringPointNumber);buf.Append("\t");
														
						buf.Append(entity.VPIAffiliatedOrganization);buf.Append("\t");
														
						buf.Append(entity.VPIAreasToWhichTheyBelong);buf.Append("\t");
														
						buf.Append(entity.VPISubordinatePlatform);buf.Append("\t");
														
						buf.Append(entity.VPILongitude);buf.Append("\t");
														
						buf.Append(entity.VPILatitude);buf.Append("\t");
														
						buf.Append(entity.VPIAddress);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "EmploymentAssistance")
				{
					buf.AppendLine("唯一编号\t个人编号\t姓名\t身份证号码\t性别\t民族\t年龄\t文化程度\t户口性质\t是否残疾\t培训意愿\t联系方式\t人员类型\t就业形式\t内容1\t内容2\t内容3\t内容4\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (EmploymentAssistance);
					foreach (var entity in tx.EmploymentAssistance)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.EAPersonalNumber);buf.Append("\t");
														
						buf.Append(entity.EAFullName);buf.Append("\t");
														
						buf.Append(entity.EAIdCardNo);buf.Append("\t");
														
						buf.Append(entity.EAGender);buf.Append("\t");
														
						buf.Append(entity.EANation);buf.Append("\t");
														
						buf.Append(entity.EAAge);buf.Append("\t");
														
						buf.Append(entity.EADegreeOfEducation);buf.Append("\t");
														
						buf.Append(entity.EAAccountCharacter);buf.Append("\t");
														
						buf.Append(entity.EAIsItDisabled);buf.Append("\t");
														
						buf.Append(entity.EATrainingIntention);buf.Append("\t");
														
						buf.Append(entity.EAContactInformation);buf.Append("\t");
														
						buf.Append(entity.EAPersonnelType);buf.Append("\t");
														
						buf.Append(entity.EAFormOfEmployment);buf.Append("\t");
														
						buf.Append(entity.EAContent1);buf.Append("\t");
														
						buf.Append(entity.EAContent2);buf.Append("\t");
														
						buf.Append(entity.EAContent3);buf.Append("\t");
														
						buf.Append(entity.EAContent4);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "DangerousHousing")
				{
					buf.AppendLine("唯一编号\t所有权人\t房屋座落\t房产证面积\t土地证面积\t测绘面积\t测绘增补面积\t安置面积\t签字时间\t交房时间\t补偿金额\t联系电话\t现居住地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (DangerousHousing);
					foreach (var entity in tx.DangerousHousing)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.DHOwner);buf.Append("\t");
														
						buf.Append(entity.DHHousingLocation);buf.Append("\t");
														
						buf.Append(entity.DHRealEstateCertificateArea);buf.Append("\t");
														
						buf.Append(entity.DHLandCertificateArea);buf.Append("\t");
														
						buf.Append(entity.DHMappingArea);buf.Append("\t");
														
						buf.Append(entity.DHSupplementaryAreaOfSurveyingAndMapping);buf.Append("\t");
														
						buf.Append(entity.DHResettlementArea);buf.Append("\t");
														
						buf.Append(entity.DHSignatureTime);buf.Append("\t");
														
						buf.Append(entity.DHTimeOfDelivery);buf.Append("\t");
														
						buf.Append(entity.DHCompensationAmount);buf.Append("\t");
														
						buf.Append(entity.DHContactNumber);buf.Append("\t");
														
						buf.Append(entity.DHCurrentResidentialAddress);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "IndustrialParkHousingReceipt")
				{
					buf.AppendLine("唯一编号\t@厂房楼栋\t开始时间\t结束时间\t付款金额\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (IndustrialParkHousingReceipt);
					foreach (var entity in tx.IndustrialParkHousingReceipt)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.IPHRFactoryBuilding);buf.Append("\t");
														
						buf.Append(entity.IPHRStartTime);buf.Append("\t");
														
						buf.Append(entity.IPHREndingTime);buf.Append("\t");
														
						buf.Append(entity.IPHRPaymentAmount);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "DemandCollection")
				{
					buf.AppendLine("唯一编号\t您需要什么内容\t期望交付时间\t您的姓名\t您的联系方式\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (DemandCollection);
					foreach (var entity in tx.DemandCollection)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.DCWhatDoYouNeed);buf.Append("\t");
														
						buf.Append(entity.DCExpectedDeliveryTime);buf.Append("\t");
														
						buf.Append(entity.DCYourName);buf.Append("\t");
														
						buf.Append(entity.DCYourContactInformation);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "InformationManagementOfPartyOrganizations")
				{
					buf.AppendLine("唯一编号\t党组织名称\t党组织书记\t党组织联系人\t党组织联系电话\t组织类别\t上级党组织名称\t党组织书记公民身份号码\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (InformationManagementOfPartyOrganizations);
					foreach (var entity in tx.InformationManagementOfPartyOrganizations)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.IMOPONameOfPartyOrganization);buf.Append("\t");
														
						buf.Append(entity.IMOPOSecretaryOfPartyOrganization);buf.Append("\t");
														
						buf.Append(entity.IMOPOPartyOrganizationContacts);buf.Append("\t");
														
						buf.Append(entity.IMOPOPartyOrganizationContactTelephone);buf.Append("\t");
														
						buf.Append(entity.IMOPOOrganizationCategory);buf.Append("\t");
														
						buf.Append(entity.IMOPONameOfPartyOrganizationAtHigherLevel);buf.Append("\t");
														
						buf.Append(entity.IMOPOCitizenshipNumberOfPartyOrganizationSecretary);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "CareForTheObject")
				{
					buf.AppendLine("唯一编号\t姓名\t性别\t类型\t身份证\t户口所在地\t常住地\t楼栋号\t单元号\t门牌号\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (CareForTheObject);
					foreach (var entity in tx.CareForTheObject)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.CFTOFullName);buf.Append("\t");
														
						buf.Append(entity.CFTOGender);buf.Append("\t");
														
						buf.Append(entity.CFTOType);buf.Append("\t");
														
						buf.Append(entity.CFTOId);buf.Append("\t");
														
						buf.Append(entity.CFTORegisteredResidence);buf.Append("\t");
														
						buf.Append(entity.CFTOPermanentResidence);buf.Append("\t");
														
						buf.Append(entity.CFTOBuildingNumber);buf.Append("\t");
														
						buf.Append(entity.CFTOUnitNumber);buf.Append("\t");
														
						buf.Append(entity.CFTOHouseNumber);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "RecruitmentAndEmploymentModule")
				{
					buf.AppendLine("唯一编号\t用人单位\t职位\t发布人\t职位描述\t职位职责内容\t职位要求内容\t生效时间\t失效时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (RecruitmentAndEmploymentModule);
					foreach (var entity in tx.RecruitmentAndEmploymentModule)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.RAEMEmployingUnit);buf.Append("\t");
														
						buf.Append(entity.RAEMPosition);buf.Append("\t");
														
						buf.Append(entity.RAEMPublisher);buf.Append("\t");
														
						buf.Append(entity.RAEMJobDescription);buf.Append("\t");
														
						buf.Append(entity.RAEMJobResponsibilities);buf.Append("\t");
														
						buf.Append(entity.RAEMContentsOfJobRequirements);buf.Append("\t");
														
						buf.Append(entity.RAEMEntryintoforceTime);buf.Append("\t");
														
						buf.Append(entity.RAEMFailureTime);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "PartyAndGroupFormation")
				{
					buf.AppendLine("唯一编号\t所属党组织\t成员姓名\t身份证号码\t创建时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (PartyAndGroupFormation);
					foreach (var entity in tx.PartyAndGroupFormation)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PAGFPartyOrganizationsAffiliatedToThem);buf.Append("\t");
														
						buf.Append(entity.PAGFNameOfMember);buf.Append("\t");
														
						buf.Append(entity.PAGFIdCardNo);buf.Append("\t");
														
						buf.Append(entity.PAGFCreationTime);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "PartyMemberActivities")
				{
					buf.AppendLine("唯一编号\t活动名称\t活动简介\t覆盖范围\t活动照片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (PartyMemberActivities);
					foreach (var entity in tx.PartyMemberActivities)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PMAActivityName);buf.Append("\t");
														
						buf.Append(entity.PMAActivityBrief);buf.Append("\t");
														
						buf.Append(entity.PMACoverageArea);buf.Append("\t");
														
						buf.Append(entity.PMAActivePhotos);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "BeautifulCountryside")
				{
					buf.AppendLine("唯一编号\t年份\t月份\t标题\t照片\t建设成果\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (BeautifulCountryside);
					foreach (var entity in tx.BeautifulCountryside)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.BCParticularYear);buf.Append("\t");
														
						buf.Append(entity.BCMonth);buf.Append("\t");
														
						buf.Append(entity.BCTitle);buf.Append("\t");
														
						buf.Append(entity.BCPhoto);buf.Append("\t");
														
						buf.Append(entity.BCAchievementsInConstruction);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "DrawWaterUpaHill")
				{
					buf.AppendLine("唯一编号\t年份\t月份\t标题\t照片\t建设成果\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (DrawWaterUpaHill);
					foreach (var entity in tx.DrawWaterUpaHill)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.DWUHParticularYear);buf.Append("\t");
														
						buf.Append(entity.DWUHMonth);buf.Append("\t");
														
						buf.Append(entity.DWUHTitle);buf.Append("\t");
														
						buf.Append(entity.DWUHPhoto);buf.Append("\t");
														
						buf.Append(entity.DWUHAchievementsInConstruction);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Propaganda")
				{
					buf.AppendLine("唯一编号\t标题\t类别\t子类别\t内容\t地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Propaganda);
					foreach (var entity in tx.Propaganda)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PTitle);buf.Append("\t");
														
						buf.Append(entity.PCategory);buf.Append("\t");
														
						buf.Append(entity.PSubcategory);buf.Append("\t");
														
						buf.Append(entity.PContent);buf.Append("\t");
														
						buf.Append(entity.PAddress);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Organization")
				{
					buf.AppendLine("唯一编号\t成员编号\t姓名\t上级\t组织名称\t所属支部\t地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Organization);
					foreach (var entity in tx.Organization)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.OMembershipNumber);buf.Append("\t");
														
						buf.Append(entity.OFullName);buf.Append("\t");
														
						buf.Append(entity.OSuperior);buf.Append("\t");
														
						buf.Append(entity.OOrganizationName);buf.Append("\t");
														
						buf.Append(entity.OSubordinateBranch);buf.Append("\t");
														
						buf.Append(entity.OAddress);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "LabourUnion")
				{
					buf.AppendLine("唯一编号\t单位组织机构代码\t单位或单位主体的国民经济行业分类代码\t单位或单位主体的单位类别\t单位地址\t上级工会\t单位工会名称\t建会时间\t工会负责人\t工会负责人联系电话\t工会办公电话\t本单位已交至苏州银行的会员身份证复印件数量\t单位职工总数人\t单位会员数人\t单位女职工数人\t单位女会员数人\t统计主题1\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (LabourUnion);
					foreach (var entity in tx.LabourUnion)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.LUUnitOrganizationCode);buf.Append("\t");
														
						buf.Append(entity.LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit);buf.Append("\t");
														
						buf.Append(entity.LUClassificationOfUnitsOrSubjectsOfUnits);buf.Append("\t");
														
						buf.Append(entity.LUUnitAddress);buf.Append("\t");
														
						buf.Append(entity.LUHigherLevelTradeUnion);buf.Append("\t");
														
						buf.Append(entity.LUUnitTradeUnionName);buf.Append("\t");
														
						buf.Append(entity.LUBuildingTime);buf.Append("\t");
														
						buf.Append(entity.LUTheHeadOfTheTradeUnion);buf.Append("\t");
														
						buf.Append(entity.LUTelephoneCallsFromTradeUnionLeaders);buf.Append("\t");
														
						buf.Append(entity.LUTradeUnionOfficeTelephone);buf.Append("\t");
														
						buf.Append(entity.LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou);buf.Append("\t");
														
						buf.Append(entity.LUTotalNumberOfEmployeesInaUnit);buf.Append("\t");
														
						buf.Append(entity.LUNumberOfUnitMembers);buf.Append("\t");
														
						buf.Append(entity.LUNumberOfFemaleEmployeesInaUnit);buf.Append("\t");
														
						buf.Append(entity.LUNumberOfFemaleMembersInaUnit);buf.Append("\t");
														
						buf.Append(entity.LUStatisticalTopic1);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "TradeUnionMembers")
				{
					buf.AppendLine("唯一编号\t姓名\t性别\t民族\t出生年月\t政治面貌\t学历\t籍贯XX省XX市\t入会时间\t身份证号\t地址单位地址\t手机号码\t身份证有效期限\t是否从事有毒有害工作是否\t备注1\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (TradeUnionMembers);
					foreach (var entity in tx.TradeUnionMembers)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.TUMFullName);buf.Append("\t");
														
						buf.Append(entity.TUMGender);buf.Append("\t");
														
						buf.Append(entity.TUMNation);buf.Append("\t");
														
						buf.Append(entity.TUMDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.TUMPoliticalOutlook);buf.Append("\t");
														
						buf.Append(entity.TUMEducation);buf.Append("\t");
														
						buf.Append(entity.TUMXxCityXxProvince);buf.Append("\t");
														
						buf.Append(entity.TUMAdmissionTime);buf.Append("\t");
														
						buf.Append(entity.TUMIdNumber);buf.Append("\t");
														
						buf.Append(entity.TUMAddressUnitAddress);buf.Append("\t");
														
						buf.Append(entity.TUMPhoneNumber);buf.Append("\t");
														
						buf.Append(entity.TUMLimitOfValidityOfIdentityCard);buf.Append("\t");
														
						buf.Append(entity.TUMWhetherToEngageInToxicAndHarmfulWorkOrNot);buf.Append("\t");
														
						buf.Append(entity.TUMRemarks1);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Personnel")
				{
					buf.AppendLine("唯一编号\t员工编号\t上级\t负责区域\t所属条线\t地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Personnel);
					foreach (var entity in tx.Personnel)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PEmployeeNumber);buf.Append("\t");
														
						buf.Append(entity.PSuperior);buf.Append("\t");
														
						buf.Append(entity.PResponsibleArea);buf.Append("\t");
														
						buf.Append(entity.PSubordinateLine);buf.Append("\t");
														
						buf.Append(entity.PAddress);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "HandlingOfGusuVillageProblem")
				{
					buf.AppendLine("唯一编号\t问题编号\t问题描述\t问题类别\t照片\t负责人\t问题状态\t确认时间\t处理时间\t回访时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (HandlingOfGusuVillageProblem);
					foreach (var entity in tx.HandlingOfGusuVillageProblem)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.HOGVPQuestionNumber);buf.Append("\t");
														
						buf.Append(entity.HOGVPProblemDescription);buf.Append("\t");
														
						buf.Append(entity.HOGVPQuestionCategories);buf.Append("\t");
														
						buf.Append(entity.HOGVPPhoto);buf.Append("\t");
														
						buf.Append(entity.HOGVPPersonInCharge);buf.Append("\t");
														
						buf.Append(entity.HOGVPProblemState);buf.Append("\t");
														
						buf.Append(entity.HOGVPConfirmationTime);buf.Append("\t");
														
						buf.Append(entity.HOGVPProcessingTime);buf.Append("\t");
														
						buf.Append(entity.HOGVPRevisitDays);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "FisheryAdministration")
				{
					buf.AppendLine("唯一编号\t渔证编号\t持证人姓名\t发证日期\t下次换证日期\t负责人\t地址\t是否有效\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (FisheryAdministration);
					foreach (var entity in tx.FisheryAdministration)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.FAFishingPermitNumber);buf.Append("\t");
														
						buf.Append(entity.FANameOfTheHolder);buf.Append("\t");
														
						buf.Append(entity.FADateOfIssue);buf.Append("\t");
														
						buf.Append(entity.FADateOfNextRenewal);buf.Append("\t");
														
						buf.Append(entity.FAPersonInCharge);buf.Append("\t");
														
						buf.Append(entity.FAAddress);buf.Append("\t");
														
						buf.Append(entity.FAIsItEffective);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "ListOfExecutiveCommitteesOfWomensFederation")
				{
					buf.AppendLine("唯一编号\t序号\t姓名\t出生年月\t职务\t性质\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (ListOfExecutiveCommitteesOfWomensFederation);
					foreach (var entity in tx.ListOfExecutiveCommitteesOfWomensFederation)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.LOECOWFSerialNumber);buf.Append("\t");
														
						buf.Append(entity.LOECOWFFullName);buf.Append("\t");
														
						buf.Append(entity.LOECOWFDateOfBirth);buf.Append("\t");
														
						buf.Append(entity.LOECOWFPost);buf.Append("\t");
														
						buf.Append(entity.LOECOWFNature);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Assets")
				{
					buf.AppendLine("唯一编号\t资产编号\t资产名称\t资产类别\t会计科目\t所属单位\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Assets);
					foreach (var entity in tx.Assets)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.AAssetNumber);buf.Append("\t");
														
						buf.Append(entity.AAssetName);buf.Append("\t");
														
						buf.Append(entity.AAssetClass);buf.Append("\t");
														
						buf.Append(entity.AAccountingSubjects);buf.Append("\t");
														
						buf.Append(entity.ASubordinateUnit);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Guardian")
				{
					buf.AppendLine("唯一编号\t姓名\t性别\t联系电话\t户籍所在地\t所在地区\t详细地址\t居住地\t提交人\t提交人电话\t社保卡正反面\t监护人身份证正反面\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Guardian);
					foreach (var entity in tx.Guardian)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.GFullName);buf.Append("\t");
														
						buf.Append(entity.GGender);buf.Append("\t");
														
						buf.Append(entity.GContactNumber);buf.Append("\t");
														
						buf.Append(entity.GLocationOfHouseholdRegistration);buf.Append("\t");
														
						buf.Append(entity.GLocation);buf.Append("\t");
														
						buf.Append(entity.GDetailedAddress);buf.Append("\t");
														
						buf.Append(entity.GPlaceOfResidence);buf.Append("\t");
														
						buf.Append(entity.GSubmitter);buf.Append("\t");
														
						buf.Append(entity.GAuthorsTelephoneNumber);buf.Append("\t");
														
						buf.Append(entity.GPositiveAndNegativeSideOfSocialSecurityCard);buf.Append("\t");
														
						buf.Append(entity.GThePositiveAndNegativeSidesOfGuardiansIdentityCard);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
											
				else if (title == "Photo")
				{
					buf.AppendLine("唯一编号\t类别\turl\t物理地址\t社保卡反面\t社保卡正面\t监护人身份证正面\t监护人身份证反面\t其他\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");
					var type = typeof (Photo);
					foreach (var entity in tx.Photo)
					{
						buf.Append(entity.id);
						buf.Append("\t");
						
													
						buf.Append(entity.PCategory);buf.Append("\t");
														
						buf.Append(entity.PUrl);buf.Append("\t");
														
						buf.Append(entity.PPhysicalAddress);buf.Append("\t");
														
						buf.Append(entity.PTheReverseSideOfSocialSecurityCard);buf.Append("\t");
														
						buf.Append(entity.PFrontOfSocialSecurityCard);buf.Append("\t");
														
						buf.Append(entity.PTheFrontOfGuardiansIdCard);buf.Append("\t");
														
						buf.Append(entity.PTheReverseOfGuardiansIdentityCard);buf.Append("\t");
														
						buf.Append(entity.POther);buf.Append("\t");
							
                        buf.Append(entity.ord); buf.Append("\t");
                        buf.Append(entity.VersionNo); buf.Append("\t");
                        buf.Append(entity.TransactionID); buf.Append("\t");
                        buf.Append(entity.CreateBy); buf.Append("\t");
                        buf.Append(entity.CreateOn); buf.Append("\t");
                        buf.Append(entity.UpdateBy); buf.Append("\t");
                        buf.Append(entity.UpdateOn); buf.Append("\t");
                        buf.Append(entity.DataLevel); buf.Append("\r\n");
					}
				}
				            }
            return buf.ToString();
        }

		public static void Proc(
			string fileType,
			string filePath,
			UserInformation user,
			out StringBuilder errorMsg){
			errorMsg = new StringBuilder();
            using (var tx = new DefaultContext())
            {
                Dictionary<string, Dictionary<string, string>> dic = null;
                string cacheFile = "table_mapping_file2019-3-12-13-33-51.txt";
                if (File.Exists(cacheFile))
                    dic = File.ReadAllText(cacheFile).Deserialize<Dictionary<string, Dictionary<string, string>>>();
                else
                {
#region init
					dic = new Dictionary<string, Dictionary<string,string>>();
									
					dic.Add("MenuConfiguration", new Dictionary<string,string>{ {"MCTitle","标题"},{"MCLink","链接"},{"MCPicture","图片"},{"MCParentTitle","父级标题"},{"MCMenuType","菜单类型"},{"MCOrder","顺序"},{"MCDisplayName","显示名称"} });
										
					dic.Add("RoleMenu", new Dictionary<string,string>{ {"RMRoleName","角色名称"},{"RMMenuTitle","菜单标题"} });
										
					dic.Add("UserRoles", new Dictionary<string,string>{ {"URRoleName","角色名称"},{"URLoginName","登录名"} });
										
					dic.Add("RoleConfiguration", new Dictionary<string,string>{ {"RCRoleName","角色名称"},{"RCAffiliatedOrganization","所属组织"} });
										
					dic.Add("UserInformation", new Dictionary<string,string>{ {"UILoginName","登录名"},{"UIPassword","密码"},{"UICustomerType","用户类型"},{"UIUserLevel","用户级别"},{"UIState","状态"},{"UINickname","昵称"},{"UIRealName","真实姓名"},{"UIHeadPortrait","头像"},{"UISubordinateDepartments","所属部门"},{"UITelephone","电话"},{"UIPhoto","照片"} });
										
					dic.Add("LoginRecord", new Dictionary<string,string>{ {"LRLoginName","登录名"},{"LRLoginTime","登录时间"} });
										
					dic.Add("UserMenu", new Dictionary<string,string>{ {"UMLoginName","登录名"},{"UMTitle","标题"} });
										
					dic.Add("InformationManagementOfPartyMembers", new Dictionary<string,string>{ {"IMOPMFullName","姓名"},{"IMOPMIdNumber","身份证号"},{"IMOPMDateOfBirth","出生日期"},{"IMOPMGender","性别"},{"IMOPMNation","民族"},{"IMOPMEducation","学历"},{"IMOPMCategory","类别"},{"IMOPMPartyBranch","所在党支部"},{"IMOPMDateOfJoiningTheParty","入党日期"},{"IMOPMDateOfCorrection","转正日期"},{"IMOPMPost","工作岗位"},{"IMOPMContactNumber","联系电话"},{"IMOPMFamilyAddress","家庭住址"} });
										
					dic.Add("PartyFeeManagement", new Dictionary<string,string>{ {"PFMFullName","姓名"},{"PFMIdNumber","身份证号"},{"PFMAge","年龄"},{"PFMPartyBranch","所在党支部"},{"PFMMonthlyIncome","月收入"},{"PFMMonthlyPartyMembershipFee","月党费"} });
										
					dic.Add("PartyRecord", new Dictionary<string,string>{ {"PRFullName","姓名"},{"PRIdCardNo","身份证号码"},{"PRCourseTitle","课程名称"},{"PRCourseSummary","课程摘要"},{"PRLearningSituation","学习情况"},{"PRCourseTime","课程时间"} });
										
					dic.Add("ThreeSessions", new Dictionary<string,string>{ {"TSDate","日期"},{"TSTheme","主题"},{"TSParticipant","参与人员"},{"TSNumberOfParticipants","与会人数"},{"TSHost","主持人"},{"TSContent","内容"},{"TSType","类型"} });
										
					dic.Add("ThematicLearning", new Dictionary<string,string>{ {"TLDate","日期"},{"TLThematicContent","专题内容"},{"TLParticipant","参与人员"},{"TLNumberOfParticipants","与会人数"},{"TLHost","主持人"},{"TLContent","内容"} });
										
					dic.Add("PolicyDocument", new Dictionary<string,string>{ {"PDFileNumber","文件号"},{"PDCategoriesOfPolicyDocuments","@政策文件类别"},{"PDThemeOfSpecialDocument","专文件主题"},{"PDContent","内容"},{"PDUploadFiles","上传文件"},{"PDParticularYear","年份"} });
										
					dic.Add("CategoriesOfPolicyDocuments", new Dictionary<string,string>{ {"COPDCategoryName","类别名称"},{"COPDDescribe","描述"} });
										
					dic.Add("ListOfActiveServicemen", new Dictionary<string,string>{ {"LOASFullName","姓名"},{"LOASNation","民族"},{"LOASFamilyAddress","家庭住址"},{"LOASIdCardNo","身份证号码"},{"LOASContactInformation","联系方式"},{"LOASFamilySituation","家庭情况"},{"LOASRemarks","备注"},{"LOASGender","性别"},{"LOASDateOfBirth","出生年月"},{"LOASDegreeOfEducation","文化程度"},{"LOASRegisteredResidence","户口所在地"} });
										
					dic.Add("ListOfConscripts", new Dictionary<string,string>{ {"LOCFullName","姓名"},{"LOCDateOfBirth","出生年月"},{"LOCDegreeOfEducation","文化程度"},{"LOCPoliticalOutlook","政治面貌"},{"LOCAccountCharacter","户口性质"},{"LOCUniversityOneIsGraduatedFrom","毕业院校"},{"LOCContactInformation","联系方式"},{"LOCIdCardNo","身份证号码"},{"LOCRemarks","备注"} });
										
					dic.Add("CommunistYouthLeague", new Dictionary<string,string>{ {"CYLSerialNumber","序号"},{"CYLFullName","姓名"},{"CYLGender","性别"},{"CYLDateOfBirth","出生年月"},{"CYLVolunteerTime","志愿时间"},{"CYLNativePlace","籍贯"},{"CYLEducation","学历"},{"CYLJoiningTheLeagueYear","入团年月"},{"CYLRemarks","备注"} });
										
					dic.Add("KeyPersonnel", new Dictionary<string,string>{ {"KPSerialNumber","序号"},{"KPFullName","姓名"},{"KPGender","性别"},{"KPPlaceOfResidence","居住地"},{"KPDomicile","户籍地"},{"KPCause","事由"},{"KPCurrentState","目前状态"},{"KPContactNumber","联系电话"},{"KPRemarks","备注"} });
										
					dic.Add("LettersAndVisits", new Dictionary<string,string>{ {"LAVSerialNumber","序号"},{"LAVComplaints","投诉事件"},{"LAVPlaceOfComplaint","投诉地点"},{"LAVHandlingResult","办理结果"} });
										
					dic.Add("TheTwoCategoryOfPersonnel", new Dictionary<string,string>{ {"TTCOPLocalCommunity","所在社区"},{"TTCOPFullName","姓名"},{"TTCOPGender","性别"},{"TTCOPIdCardNo","身份证号码"},{"TTCOPCharge","罪名"},{"TTCOPFamilyAddress","家庭住址"} });
										
					dic.Add("Family", new Dictionary<string,string>{ {"FNameOfFamilyOrganization","家庭组织名称"},{"FFullName","姓名"},{"FIdCardNo","身份证号码"},{"FNameOfNewborn","新生儿姓名"},{"FDeathCertificate","死亡证明"},{"FPlaceOfResidence","居住地"},{"FContactInformation","联系方式"} });
										
					dic.Add("Investors", new Dictionary<string,string>{ {"ISerialNumber","序号"},{"IHouseholdNumber","户编号"},{"IEquityCertificateNumber","股权证编号"},{"IIdCardNo","身份证号码"},{"IaHouseholder","户主"},{"IFullName","姓名"},{"IGender","性别"},{"IDateOfBirth","出生年月"},{"IOneYearOld","周岁"},{"IBasicStock","基本股"},{"IDeservedShare","应得股份股"},{"ITotalNumberOfSharesInaHousehold","户合计股数"},{"IWitnessing","确认签名"},{"IRightsIssue","配股说明"},{"IStatisticalTopic1","统计主题1"} });
										
					dic.Add("BonusRecord", new Dictionary<string,string>{ {"BRFullName","姓名"},{"BRIdCardNo","身份证号码"},{"BRShareType","股份类型"},{"BRShareRatio","股票占比"},{"BRPaymentAmount","发放金额"},{"BRPaymentTime","发放时间"},{"BRPersonInCharge","负责人"},{"BRContactInformationOfPersonInCharge","负责人联系方式"} });
										
					dic.Add("Cadre", new Dictionary<string,string>{ {"CFullName","姓名"},{"CIdCardNo","身份证号码"},{"CSuperiorLeader","上级领导"},{"CSubordinateBranch","所属支部"},{"CModelWorker","劳模"},{"CTypesOfCadres","干部类型"} });
										
					dic.Add("Militia", new Dictionary<string,string>{ {"MFullName","姓名"},{"MIdCardNo","身份证号码"},{"MSuperiorLeader","上级领导"},{"MDesignation","所属番号"},{"MMilitiaType","民兵类型"} });
										
					dic.Add("UnitedFrontMilitia", new Dictionary<string,string>{ {"UFMFullName","姓名"},{"UFMIdCardNo","身份证号码"},{"UFMSuperiorLeader","上级领导"},{"UFMDesignation","所属番号"},{"UFMMilitiaType","民兵类型"} });
										
					dic.Add("FactoryBuilding", new Dictionary<string,string>{ {"FBNameOfIndustrialPark","工业园名称"},{"FBSerialNumber","序号"},{"FBTenant","承租户"},{"FBStartStop","起止"},{"FBLesseeArea","承租面积"},{"FBDeposit","押金"},{"FBUnitPrice","单价"},{"FBMonthlyRent","月租金"},{"FBAnnualRent","年租金"},{"FBCharteredUnitNature","租凭单位性质"},{"FBEnvironmentalProtectionProcedures","环保手续"},{"FBBuiltupArea","建筑面积"},{"FBStartTime","开始时间"},{"FBEndingTime","结束时间"},{"FBContacts","联系人"},{"FBContactNumber","联系电话"},{"FBApprovalDocument","审批文件"},{"FBBuildingNumber","楼号"},{"FBUnitNumber","单元号"},{"FBHouseNumber","门牌号"},{"FBPersonInCharge","负责人"},{"FBContactInformationOfPersonInCharge","负责人联系方式"},{"FBRange","范围"},{"FBRemarks","备注"},{"FBAddress","地址"} });
										
					dic.Add("RentCollectionRecords", new Dictionary<string,string>{ {"RCREnterpriseName","企业名称"},{"RCRPersonInCharge","负责人"},{"RCRTelephoneCallsFromThePersonInCharge","负责人电话"},{"RCRPaymentAmount","付款金额"},{"RCRPayee","收款人"},{"RCRCashiersTelephone","收款人电话"},{"RCRAmountCollected","收款金额"},{"RCRCollectionTime","收款时间"},{"RCRTimeOfReceivables","应收款时间"},{"RCRRemarks","备注"},{"RCRNameOfIndustrialPark","工业园名称"} });
										
					dic.Add("ElectricityChargePaymentRecord", new Dictionary<string,string>{ {"ECPREnterpriseName","企业名称"},{"ECPRPersonInCharge","负责人"},{"ECPRTelephoneCallsFromThePersonInCharge","负责人电话"},{"ECPRPaymentAmount","付款金额"},{"ECPRPayee","收款人"},{"ECPRCashiersTelephone","收款人电话"},{"ECPRAmountCollected","收款金额"},{"ECPRCollectionTime","收款时间"},{"ECPRTimeOfReceivables","应收款时间"},{"ECPRRemarks","备注"} });
										
					dic.Add("JobDiary", new Dictionary<string,string>{ {"JDSerialNumber","序号"},{"JDStripe","条线"},{"JDPersonInCharge","负责人"},{"JDDate","日期"},{"JDProcessingMatters","办理事项"},{"JDIsItFinished","是否完成"},{"JDCompletionTime","完成时间"},{"JDRemarks","备注"} });
										
					dic.Add("Notice", new Dictionary<string,string>{ {"NTitle","标题"},{"NContent","内容"},{"NAuthor","作者"},{"NNotificationOfDateOfDispatch","通知发送日期"},{"NNotificationSenderObject","通知发送对象"},{"NRemarks","备注"},{"NAbstract","摘要"},{"NPicture","图片"} });
										
					dic.Add("DocumentManagement", new Dictionary<string,string>{ {"DMTitle","标题"},{"DMContent","内容"},{"DMAuthor","作者"},{"DMOriginalPicture","原件图片"},{"DMRemarks","备注"} });
										
					dic.Add("Population", new Dictionary<string,string>{ {"PCitizenshipNumber","公民身份号码"},{"PFullName","姓名"},{"PGender","性别"},{"PDateOfBirth","出生日期"},{"PNeighborhoodVillageCommittee","居村委会"},{"PAddress","住址"},{"PAge","年龄"} });
										
					dic.Add("Newborn", new Dictionary<string,string>{ {"NCitizenshipNumber","公民身份号码"},{"NFullName","姓名"},{"NGender","性别"},{"NDateOfBirth","出生日期"},{"NNeighborhoodVillageCommittee","居村委会"},{"NAddress","住址"},{"NAge","年龄"} });
										
					dic.Add("HouseProperty", new Dictionary<string,string>{ {"HPId","身份证"},{"HPAddress","地址"},{"HPBuildingNumber","楼栋号"},{"HPUnitNumber","单元号"},{"HPHouseNumber","门牌号"} });
										
					dic.Add("ReimbursementList", new Dictionary<string,string>{ {"RLFullName","姓名"},{"RLStartingPosition","出发位置"},{"RLDestinationLocation","目的地位置"},{"RLTrafficExpense","交通费"},{"RLHotelExpense","住宿费"},{"RLAccommodationAllowance","住勤补贴"},{"RLBusFare","公交费"},{"RLDateOfReimbursement","报销日期"} });
										
					dic.Add("MailList", new Dictionary<string,string>{ {"MLOrganizationName","机构名称"},{"MLPersonnelName","人员姓名"},{"MLId","身份证"},{"MLGender","性别"},{"MLTelephone","电话"},{"MLMobilePhone","手机"},{"MLMailbox","邮箱"},{"MLPosition","职位"},{"MLSuperiorLeader","上级领导"},{"MLQq","QQ"},{"MLWechat","微信"} });
										
					dic.Add("Poi", new Dictionary<string,string>{ {"PAddress","地址"} });
										
					dic.Add("ManagementOfPartyBuildingNews", new Dictionary<string,string>{ {"MOPBNTitle","标题"},{"MOPBNContent","内容"},{"MOPBNAuthor","作者"},{"MOPBNReleaseTime","发布时间"},{"MOPBNCategory","类别"},{"MOPBNPicture","图片"} });
										
					dic.Add("FreeToShoot", new Dictionary<string,string>{ {"FTSContent","内容"},{"FTSEquipment","设备"},{"FTSUserId","用户ID"},{"FTSPhoto","照片"},{"FTSPhotoop","拍照时间"},{"FTSPosition","位置"},{"FTSFullName","姓名"},{"FTSTelephone","电话"},{"FTSRegion","区域"},{"FTSNumberOfPoints","点赞数目"} });
										
					dic.Add("ActiveInspection", new Dictionary<string,string>{ {"AIInspectionProblem","巡检问题"},{"AICreationTime","创建时间"},{"AIState","状态"},{"AIUser","用户"},{"AIRegion","区域"},{"AIPicture","图片"},{"AIPosition","位置"} });
										
					dic.Add("BusinessAppointment", new Dictionary<string,string>{ {"BABusiness","业务"},{"BAService","服务"},{"BAFullName","姓名"},{"BAId","身份证"},{"BATelephone","电话"},{"BACreationTime","创建时间"},{"BAAcceptanceTime","受理时间"},{"BAState","状态"} });
										
					dic.Add("RecordOfRecommendations", new Dictionary<string,string>{ {"RORTitle","标题"},{"RORContent","内容"},{"RORObject","对象"},{"RORDealingWithPeople","处理人"},{"RORDateOfProcessing","处理日期"} });
										
					dic.Add("StudyOnPartyStyleAndCleanGovernment", new Dictionary<string,string>{ {"SOPSACGTitle","标题"},{"SOPSACGContent","内容"},{"SOPSACGLearningObject","学习对象"},{"SOPSACGLearningDate","学习日期"},{"SOPSACGRemarks","备注"} });
										
					dic.Add("CommunalFacilities", new Dictionary<string,string>{ {"CFName","名称"},{"CFPosition","位置"},{"CFType","类型"},{"CFAscription","归属"},{"CFRenewalDate","换新日期"},{"CFIsItDamaged","是否损坏"} });
										
					dic.Add("SystemConfiguration", new Dictionary<string,string>{ {"SCTitle","标题"},{"SCClassification","分类"},{"SCSubClassification","子分类"},{"SCContent","内容"},{"SCIsItEffective","是否生效"} });
										
					dic.Add("PartyBuilding", new Dictionary<string,string>{ {"PBTitle","标题"},{"PBContent","内容"},{"PBReleaseTime","发布时间"},{"PBRemarks","备注"} });
										
					dic.Add("ManagementOfPartyFeePayment", new Dictionary<string,string>{ {"MOPFPFullName","姓名"},{"MOPFPTelephone","电话"},{"MOPFPAmountOfMoney","金额"},{"MOPFPDate","日期"},{"MOPFPPayee","收款人"},{"MOPFPSubordinateBranch","所属支部"} });
										
					dic.Add("ContractManagement", new Dictionary<string,string>{ {"CMContractNumber","合同编号"},{"CMContractName","合同名称"},{"CMEntryName","项目名称"},{"CMSignatureOfPartya","甲方签名"},{"CMSignatureOfPartyb","乙方签名"},{"CMSignatureOfPartyc","丙方签名"},{"CMSigningDate","签署日期"},{"CMSignatory","签署机构"},{"CMUploadContractDocuments","合同文件上传"} });
										
					dic.Add("PersonalInformation", new Dictionary<string,string>{ {"PILoginName","登录名"},{"PINickname","昵称"},{"PIRealName","真实姓名"},{"PIPassword","密码"},{"PIHeadPortrait","头像"},{"PILastLogonTime","上次登录时间"},{"PISubordinateDepartments","所属部门"},{"PITelephone","电话"},{"PIPhoto","照片"} });
										
					dic.Add("ScheduleWork", new Dictionary<string,string>{ {"SWTitle","标题"},{"SWContent","内容"},{"SWPlace","地点"},{"SWPersonInCharge","负责人"},{"SWTelephone","电话"},{"SWStartTime","开始时间"},{"SWEndingTime","结束时间"} });
										
					dic.Add("SpecialTopicOnPartyBuilding", new Dictionary<string,string>{ {"STOPBTitle","标题"},{"STOPBPreview","预览"},{"STOPBReleaseTime","发布时间"},{"STOPBSee","查看"} });
										
					dic.Add("BusinessGuide", new Dictionary<string,string>{ {"BGCategory","类别"},{"BGContentOfWork","办事内容"},{"BGRequiredMaterials","所需材料"},{"BGProcedure","办事程序"} });
										
					dic.Add("PartyAffairsGuide", new Dictionary<string,string>{ {"PAGTitle","标题"},{"PAGContent","内容"},{"PAGCategory","类别"},{"PAGScopeOfApplication","适用范围"} });
										
					dic.Add("BusinessManagement", new Dictionary<string,string>{ {"BMBusinessType","业务类型"},{"BMServiceType","服务类型"},{"BMApplicant","申请人"},{"BMId","身份证"},{"BMGender","性别"},{"BMHallAcceptanceTime","大厅受理时间"},{"BMAgent","经办人"},{"BMCreationTime","创建时间"},{"BMState","状态"} });
										
					dic.Add("MedicalInsuranceForChildren", new Dictionary<string,string>{ {"MIFCUnitNumber","单位编号"},{"MIFCPersonnelNumber","人员编号"},{"MIFCFullName","姓名"},{"MIFCId","身份证"},{"MIFCDateOfBirth","出生日期"},{"MIFCExemptionCategory","免缴种类"},{"MIFCExemptionNumber","免缴号码"},{"MIFCContacts","联系人"},{"MIFCContactNumber","联系电话"} });
										
					dic.Add("RuralMedicalTreatment", new Dictionary<string,string>{ {"RMTPersonnelNumber","人员编号"},{"RMTFullName","姓名"},{"RMTId","身份证"},{"RMTExemptionCategory","免缴种类"},{"RMTExemptionNumber","免缴号码"},{"RMTContacts","联系人"},{"RMTContactNumber","联系电话"},{"RMTRegion","区域"},{"RMTOperation","操作"} });
										
					dic.Add("WelfarePayment", new Dictionary<string,string>{ {"WPFullName","姓名"},{"WPGender","性别"},{"WPAge","年龄"},{"WPIdNumber","身份证号"},{"WPWelfareType","福利类型"},{"WPPaymentAmount","发放金额"},{"WPDateOfIssue","发放日期"},{"WPInsuredId","被保人id"},{"WPAddress","住址"},{"WPRegion","区域"},{"WPOperation","操作"} });
										
					dic.Add("ServiceAppointment", new Dictionary<string,string>{ {"SAServiceType","服务类型"},{"SAAppointments","预约人"},{"SATimeOfAppointment","预约时间"},{"SAId","身份证"},{"SACreationTime","创建时间"},{"SAAuditTime","审核时间"},{"SAState","状态"},{"SAAuditRegistration","审核登记"} });
										
					dic.Add("ScheduleManagement", new Dictionary<string,string>{ {"SMActivityType","活动类型"},{"SMStartDate","开始日期"},{"SMEndDate","结束日期"},{"SMContent","内容"},{"SMPlace","地点"},{"SMPersonInCharge","负责人"},{"SMTelephone","电话"},{"SMRemarks","备注"} });
										
					dic.Add("ExpertManagement", new Dictionary<string,string>{ {"EMTechnicalExpertise","技术特长"},{"EMFullName","姓名"},{"EMGender","性别"},{"EMDateOfBirth","出生日期"},{"EMId","身份证"},{"EMAddress","地址"},{"EMContactNumber","联系电话"} });
										
					dic.Add("PermissionAccess", new Dictionary<string,string>{ {"PAFullName","姓名"},{"PAAccessTime","访问时间"} });
										
					dic.Add("ConvenienceGuide", new Dictionary<string,string>{ {"CGTitle","标题"},{"CGReleaseTime","发布时间"},{"CGPicture","图片"},{"CGContent","内容"},{"CGAbstract","摘要"},{"CGRemarks","备注"} });
										
					dic.Add("ConvenientLife", new Dictionary<string,string>{ {"CLTitle","标题"},{"CLReleaseTime","发布时间"},{"CLPicture","图片"},{"CLContent","内容"},{"CLAbstract","摘要"},{"CLRemarks","备注"} });
										
					dic.Add("CharacteristicOfXiangxi", new Dictionary<string,string>{ {"COXTitle","标题"},{"COXReleaseTime","发布时间"},{"COXPicture","图片"},{"COXContent","内容"},{"COXAbstract","摘要"},{"COXRemarks","备注"} });
										
					dic.Add("ProposedTreatment", new Dictionary<string,string>{ {"PTTitle","标题"},{"PTContent","内容"},{"PTObject","对象"},{"PTDealingWithPeople","处理人"},{"PTDateOfProcessing","处理日期"},{"PTFullName","姓名"},{"PTId","身份证"},{"PTTelephone","电话"},{"PTCreationTime","创建时间"},{"PTState","状态"} });
										
					dic.Add("VillageHistory", new Dictionary<string,string>{ {"VHMenuItem","菜单项"},{"VHMainTitle","主标题"},{"VHSubheading","副标题"},{"VHPicture","图片"},{"VHAbstract","摘要"} });
										
					dic.Add("SpecialWork", new Dictionary<string,string>{ {"SWWorkTheme","工作主题"},{"SWJobContent","工作内容"},{"SWStartDate","开始日期"},{"SWEndDate","结束日期"},{"SWState","状态"},{"SWPhoto","照片"} });
										
					dic.Add("VideoPointInformation", new Dictionary<string,string>{ {"VPISerialNumber","序号"},{"VPIMonitoringPointName","监控点名称"},{"VPIMonitoringPointNumber","监控点编号"},{"VPIAffiliatedOrganization","所属组织"},{"VPIAreasToWhichTheyBelong","所属区域"},{"VPISubordinatePlatform","所属平台"},{"VPILongitude","经度"},{"VPILatitude","纬度"},{"VPIAddress","地址"} });
										
					dic.Add("EmploymentAssistance", new Dictionary<string,string>{ {"EAPersonalNumber","个人编号"},{"EAFullName","姓名"},{"EAIdCardNo","身份证号码"},{"EAGender","性别"},{"EANation","民族"},{"EAAge","年龄"},{"EADegreeOfEducation","文化程度"},{"EAAccountCharacter","户口性质"},{"EAIsItDisabled","是否残疾"},{"EATrainingIntention","培训意愿"},{"EAContactInformation","联系方式"},{"EAPersonnelType","人员类型"},{"EAFormOfEmployment","就业形式"},{"EAContent1","内容1"},{"EAContent2","内容2"},{"EAContent3","内容3"},{"EAContent4","内容4"} });
										
					dic.Add("DangerousHousing", new Dictionary<string,string>{ {"DHOwner","所有权人"},{"DHHousingLocation","房屋座落"},{"DHRealEstateCertificateArea","房产证面积"},{"DHLandCertificateArea","土地证面积"},{"DHMappingArea","测绘面积"},{"DHSupplementaryAreaOfSurveyingAndMapping","测绘增补面积"},{"DHResettlementArea","安置面积"},{"DHSignatureTime","签字时间"},{"DHTimeOfDelivery","交房时间"},{"DHCompensationAmount","补偿金额"},{"DHContactNumber","联系电话"},{"DHCurrentResidentialAddress","现居住地址"} });
										
					dic.Add("IndustrialParkHousingReceipt", new Dictionary<string,string>{ {"IPHRFactoryBuilding","@厂房楼栋"},{"IPHRStartTime","开始时间"},{"IPHREndingTime","结束时间"},{"IPHRPaymentAmount","付款金额"} });
										
					dic.Add("DemandCollection", new Dictionary<string,string>{ {"DCWhatDoYouNeed","您需要什么内容"},{"DCExpectedDeliveryTime","期望交付时间"},{"DCYourName","您的姓名"},{"DCYourContactInformation","您的联系方式"} });
										
					dic.Add("InformationManagementOfPartyOrganizations", new Dictionary<string,string>{ {"IMOPONameOfPartyOrganization","党组织名称"},{"IMOPOSecretaryOfPartyOrganization","党组织书记"},{"IMOPOPartyOrganizationContacts","党组织联系人"},{"IMOPOPartyOrganizationContactTelephone","党组织联系电话"},{"IMOPOOrganizationCategory","组织类别"},{"IMOPONameOfPartyOrganizationAtHigherLevel","上级党组织名称"},{"IMOPOCitizenshipNumberOfPartyOrganizationSecretary","党组织书记公民身份号码"} });
										
					dic.Add("CareForTheObject", new Dictionary<string,string>{ {"CFTOFullName","姓名"},{"CFTOGender","性别"},{"CFTOType","类型"},{"CFTOId","身份证"},{"CFTORegisteredResidence","户口所在地"},{"CFTOPermanentResidence","常住地"},{"CFTOBuildingNumber","楼栋号"},{"CFTOUnitNumber","单元号"},{"CFTOHouseNumber","门牌号"} });
										
					dic.Add("RecruitmentAndEmploymentModule", new Dictionary<string,string>{ {"RAEMEmployingUnit","用人单位"},{"RAEMPosition","职位"},{"RAEMPublisher","发布人"},{"RAEMJobDescription","职位描述"},{"RAEMJobResponsibilities","职位职责内容"},{"RAEMContentsOfJobRequirements","职位要求内容"},{"RAEMEntryintoforceTime","生效时间"},{"RAEMFailureTime","失效时间"} });
										
					dic.Add("PartyAndGroupFormation", new Dictionary<string,string>{ {"PAGFPartyOrganizationsAffiliatedToThem","所属党组织"},{"PAGFNameOfMember","成员姓名"},{"PAGFIdCardNo","身份证号码"},{"PAGFCreationTime","创建时间"} });
										
					dic.Add("PartyMemberActivities", new Dictionary<string,string>{ {"PMAActivityName","活动名称"},{"PMAActivityBrief","活动简介"},{"PMACoverageArea","覆盖范围"},{"PMAActivePhotos","活动照片"} });
										
					dic.Add("BeautifulCountryside", new Dictionary<string,string>{ {"BCParticularYear","年份"},{"BCMonth","月份"},{"BCTitle","标题"},{"BCPhoto","照片"},{"BCAchievementsInConstruction","建设成果"} });
										
					dic.Add("DrawWaterUpaHill", new Dictionary<string,string>{ {"DWUHParticularYear","年份"},{"DWUHMonth","月份"},{"DWUHTitle","标题"},{"DWUHPhoto","照片"},{"DWUHAchievementsInConstruction","建设成果"} });
										
					dic.Add("Propaganda", new Dictionary<string,string>{ {"PTitle","标题"},{"PCategory","类别"},{"PSubcategory","子类别"},{"PContent","内容"},{"PAddress","地址"} });
										
					dic.Add("Organization", new Dictionary<string,string>{ {"OMembershipNumber","成员编号"},{"OFullName","姓名"},{"OSuperior","上级"},{"OOrganizationName","组织名称"},{"OSubordinateBranch","所属支部"},{"OAddress","地址"} });
										
					dic.Add("LabourUnion", new Dictionary<string,string>{ {"LUUnitOrganizationCode","单位组织机构代码"},{"LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit","单位或单位主体的国民经济行业分类代码"},{"LUClassificationOfUnitsOrSubjectsOfUnits","单位或单位主体的单位类别"},{"LUUnitAddress","单位地址"},{"LUHigherLevelTradeUnion","上级工会"},{"LUUnitTradeUnionName","单位工会名称"},{"LUBuildingTime","建会时间"},{"LUTheHeadOfTheTradeUnion","工会负责人"},{"LUTelephoneCallsFromTradeUnionLeaders","工会负责人联系电话"},{"LUTradeUnionOfficeTelephone","工会办公电话"},{"LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou","本单位已交至苏州银行的会员身份证复印件数量"},{"LUTotalNumberOfEmployeesInaUnit","单位职工总数人"},{"LUNumberOfUnitMembers","单位会员数人"},{"LUNumberOfFemaleEmployeesInaUnit","单位女职工数人"},{"LUNumberOfFemaleMembersInaUnit","单位女会员数人"},{"LUStatisticalTopic1","统计主题1"} });
										
					dic.Add("TradeUnionMembers", new Dictionary<string,string>{ {"TUMFullName","姓名"},{"TUMGender","性别"},{"TUMNation","民族"},{"TUMDateOfBirth","出生年月"},{"TUMPoliticalOutlook","政治面貌"},{"TUMEducation","学历"},{"TUMXxCityXxProvince","籍贯XX省XX市"},{"TUMAdmissionTime","入会时间"},{"TUMIdNumber","身份证号"},{"TUMAddressUnitAddress","地址单位地址"},{"TUMPhoneNumber","手机号码"},{"TUMLimitOfValidityOfIdentityCard","身份证有效期限"},{"TUMWhetherToEngageInToxicAndHarmfulWorkOrNot","是否从事有毒有害工作是否"},{"TUMRemarks1","备注1"} });
										
					dic.Add("Personnel", new Dictionary<string,string>{ {"PEmployeeNumber","员工编号"},{"PSuperior","上级"},{"PResponsibleArea","负责区域"},{"PSubordinateLine","所属条线"},{"PAddress","地址"} });
										
					dic.Add("HandlingOfGusuVillageProblem", new Dictionary<string,string>{ {"HOGVPQuestionNumber","问题编号"},{"HOGVPProblemDescription","问题描述"},{"HOGVPQuestionCategories","问题类别"},{"HOGVPPhoto","照片"},{"HOGVPPersonInCharge","负责人"},{"HOGVPProblemState","问题状态"},{"HOGVPConfirmationTime","确认时间"},{"HOGVPProcessingTime","处理时间"},{"HOGVPRevisitDays","回访时间"} });
										
					dic.Add("FisheryAdministration", new Dictionary<string,string>{ {"FAFishingPermitNumber","渔证编号"},{"FANameOfTheHolder","持证人姓名"},{"FADateOfIssue","发证日期"},{"FADateOfNextRenewal","下次换证日期"},{"FAPersonInCharge","负责人"},{"FAAddress","地址"},{"FAIsItEffective","是否有效"} });
										
					dic.Add("ListOfExecutiveCommitteesOfWomensFederation", new Dictionary<string,string>{ {"LOECOWFSerialNumber","序号"},{"LOECOWFFullName","姓名"},{"LOECOWFDateOfBirth","出生年月"},{"LOECOWFPost","职务"},{"LOECOWFNature","性质"} });
										
					dic.Add("Assets", new Dictionary<string,string>{ {"AAssetNumber","资产编号"},{"AAssetName","资产名称"},{"AAssetClass","资产类别"},{"AAccountingSubjects","会计科目"},{"ASubordinateUnit","所属单位"} });
										
					dic.Add("Guardian", new Dictionary<string,string>{ {"GFullName","姓名"},{"GGender","性别"},{"GContactNumber","联系电话"},{"GLocationOfHouseholdRegistration","户籍所在地"},{"GLocation","所在地区"},{"GDetailedAddress","详细地址"},{"GPlaceOfResidence","居住地"},{"GSubmitter","提交人"},{"GAuthorsTelephoneNumber","提交人电话"},{"GPositiveAndNegativeSideOfSocialSecurityCard","社保卡正反面"},{"GThePositiveAndNegativeSidesOfGuardiansIdentityCard","监护人身份证正反面"} });
										
					dic.Add("Photo", new Dictionary<string,string>{ {"PCategory","类别"},{"PUrl","url"},{"PPhysicalAddress","物理地址"},{"PTheReverseSideOfSocialSecurityCard","社保卡反面"},{"PFrontOfSocialSecurityCard","社保卡正面"},{"PTheFrontOfGuardiansIdCard","监护人身份证正面"},{"PTheReverseOfGuardiansIdentityCard","监护人身份证反面"},{"POther","其他"} });
					
					File.WriteAllText(cacheFile,dic.ToJson());
#endregion
				}
				var transactionId = Guid.NewGuid().ToString();
                var keypair = dic[fileType]; //commentses.ToDictionary(f => f.column_name, f => f.column_description);
                if (string.IsNullOrEmpty(fileType)) return ;
				else if (fileType == "MenuConfiguration") ExcelHelper.ExcelToNewEntityList<MenuConfiguration>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.MenuConfiguration.AddOrUpdate(one);
					});
				else if (fileType == "RoleMenu") ExcelHelper.ExcelToNewEntityList<RoleMenu>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.RoleMenu.AddOrUpdate(one);
					});
				else if (fileType == "UserRoles") ExcelHelper.ExcelToNewEntityList<UserRoles>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.UserRoles.AddOrUpdate(one);
					});
				else if (fileType == "RoleConfiguration") ExcelHelper.ExcelToNewEntityList<RoleConfiguration>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.RoleConfiguration.AddOrUpdate(one);
					});
				else if (fileType == "UserInformation") ExcelHelper.ExcelToNewEntityList<UserInformation>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.UserInformation.AddOrUpdate(one);
					});
				else if (fileType == "LoginRecord") ExcelHelper.ExcelToNewEntityList<LoginRecord>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.LoginRecord.AddOrUpdate(one);
					});
				else if (fileType == "UserMenu") ExcelHelper.ExcelToNewEntityList<UserMenu>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.UserMenu.AddOrUpdate(one);
					});
				else if (fileType == "InformationManagementOfPartyMembers") ExcelHelper.ExcelToNewEntityList<InformationManagementOfPartyMembers>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.InformationManagementOfPartyMembers.AddOrUpdate(one);
					});
				else if (fileType == "PartyFeeManagement") ExcelHelper.ExcelToNewEntityList<PartyFeeManagement>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.PartyFeeManagement.AddOrUpdate(one);
					});
				else if (fileType == "PartyRecord") ExcelHelper.ExcelToNewEntityList<PartyRecord>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.PartyRecord.AddOrUpdate(one);
					});
				else if (fileType == "ThreeSessions") ExcelHelper.ExcelToNewEntityList<ThreeSessions>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ThreeSessions.AddOrUpdate(one);
					});
				else if (fileType == "ThematicLearning") ExcelHelper.ExcelToNewEntityList<ThematicLearning>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ThematicLearning.AddOrUpdate(one);
					});
				else if (fileType == "PolicyDocument") ExcelHelper.ExcelToNewEntityList<PolicyDocument>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.PolicyDocument.AddOrUpdate(one);
					});
				else if (fileType == "CategoriesOfPolicyDocuments") ExcelHelper.ExcelToNewEntityList<CategoriesOfPolicyDocuments>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.CategoriesOfPolicyDocuments.AddOrUpdate(one);
					});
				else if (fileType == "ListOfActiveServicemen") ExcelHelper.ExcelToNewEntityList<ListOfActiveServicemen>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ListOfActiveServicemen.AddOrUpdate(one);
					});
				else if (fileType == "ListOfConscripts") ExcelHelper.ExcelToNewEntityList<ListOfConscripts>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ListOfConscripts.AddOrUpdate(one);
					});
				else if (fileType == "CommunistYouthLeague") ExcelHelper.ExcelToNewEntityList<CommunistYouthLeague>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.CommunistYouthLeague.AddOrUpdate(one);
					});
				else if (fileType == "KeyPersonnel") ExcelHelper.ExcelToNewEntityList<KeyPersonnel>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.KeyPersonnel.AddOrUpdate(one);
					});
				else if (fileType == "LettersAndVisits") ExcelHelper.ExcelToNewEntityList<LettersAndVisits>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.LettersAndVisits.AddOrUpdate(one);
					});
				else if (fileType == "TheTwoCategoryOfPersonnel") ExcelHelper.ExcelToNewEntityList<TheTwoCategoryOfPersonnel>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.TheTwoCategoryOfPersonnel.AddOrUpdate(one);
					});
				else if (fileType == "Family") ExcelHelper.ExcelToNewEntityList<Family>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Family.AddOrUpdate(one);
					});
				else if (fileType == "Investors") ExcelHelper.ExcelToNewEntityList<Investors>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Investors.AddOrUpdate(one);
					});
				else if (fileType == "BonusRecord") ExcelHelper.ExcelToNewEntityList<BonusRecord>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.BonusRecord.AddOrUpdate(one);
					});
				else if (fileType == "Cadre") ExcelHelper.ExcelToNewEntityList<Cadre>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Cadre.AddOrUpdate(one);
					});
				else if (fileType == "Militia") ExcelHelper.ExcelToNewEntityList<Militia>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Militia.AddOrUpdate(one);
					});
				else if (fileType == "UnitedFrontMilitia") ExcelHelper.ExcelToNewEntityList<UnitedFrontMilitia>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.UnitedFrontMilitia.AddOrUpdate(one);
					});
				else if (fileType == "FactoryBuilding") ExcelHelper.ExcelToNewEntityList<FactoryBuilding>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.FactoryBuilding.AddOrUpdate(one);
					});
				else if (fileType == "RentCollectionRecords") ExcelHelper.ExcelToNewEntityList<RentCollectionRecords>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.RentCollectionRecords.AddOrUpdate(one);
					});
				else if (fileType == "ElectricityChargePaymentRecord") ExcelHelper.ExcelToNewEntityList<ElectricityChargePaymentRecord>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ElectricityChargePaymentRecord.AddOrUpdate(one);
					});
				else if (fileType == "JobDiary") ExcelHelper.ExcelToNewEntityList<JobDiary>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.JobDiary.AddOrUpdate(one);
					});
				else if (fileType == "Notice") ExcelHelper.ExcelToNewEntityList<Notice>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Notice.AddOrUpdate(one);
					});
				else if (fileType == "DocumentManagement") ExcelHelper.ExcelToNewEntityList<DocumentManagement>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.DocumentManagement.AddOrUpdate(one);
					});
				else if (fileType == "Population") ExcelHelper.ExcelToNewEntityList<Population>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Population.AddOrUpdate(one);
					});
				else if (fileType == "Newborn") ExcelHelper.ExcelToNewEntityList<Newborn>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Newborn.AddOrUpdate(one);
					});
				else if (fileType == "HouseProperty") ExcelHelper.ExcelToNewEntityList<HouseProperty>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.HouseProperty.AddOrUpdate(one);
					});
				else if (fileType == "ReimbursementList") ExcelHelper.ExcelToNewEntityList<ReimbursementList>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ReimbursementList.AddOrUpdate(one);
					});
				else if (fileType == "MailList") ExcelHelper.ExcelToNewEntityList<MailList>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.MailList.AddOrUpdate(one);
					});
				else if (fileType == "Poi") ExcelHelper.ExcelToNewEntityList<Poi>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Poi.AddOrUpdate(one);
					});
				else if (fileType == "ManagementOfPartyBuildingNews") ExcelHelper.ExcelToNewEntityList<ManagementOfPartyBuildingNews>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ManagementOfPartyBuildingNews.AddOrUpdate(one);
					});
				else if (fileType == "FreeToShoot") ExcelHelper.ExcelToNewEntityList<FreeToShoot>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.FreeToShoot.AddOrUpdate(one);
					});
				else if (fileType == "ActiveInspection") ExcelHelper.ExcelToNewEntityList<ActiveInspection>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ActiveInspection.AddOrUpdate(one);
					});
				else if (fileType == "BusinessAppointment") ExcelHelper.ExcelToNewEntityList<BusinessAppointment>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.BusinessAppointment.AddOrUpdate(one);
					});
				else if (fileType == "RecordOfRecommendations") ExcelHelper.ExcelToNewEntityList<RecordOfRecommendations>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.RecordOfRecommendations.AddOrUpdate(one);
					});
				else if (fileType == "StudyOnPartyStyleAndCleanGovernment") ExcelHelper.ExcelToNewEntityList<StudyOnPartyStyleAndCleanGovernment>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.StudyOnPartyStyleAndCleanGovernment.AddOrUpdate(one);
					});
				else if (fileType == "CommunalFacilities") ExcelHelper.ExcelToNewEntityList<CommunalFacilities>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.CommunalFacilities.AddOrUpdate(one);
					});
				else if (fileType == "SystemConfiguration") ExcelHelper.ExcelToNewEntityList<SystemConfiguration>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.SystemConfiguration.AddOrUpdate(one);
					});
				else if (fileType == "PartyBuilding") ExcelHelper.ExcelToNewEntityList<PartyBuilding>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.PartyBuilding.AddOrUpdate(one);
					});
				else if (fileType == "ManagementOfPartyFeePayment") ExcelHelper.ExcelToNewEntityList<ManagementOfPartyFeePayment>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ManagementOfPartyFeePayment.AddOrUpdate(one);
					});
				else if (fileType == "ContractManagement") ExcelHelper.ExcelToNewEntityList<ContractManagement>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ContractManagement.AddOrUpdate(one);
					});
				else if (fileType == "PersonalInformation") ExcelHelper.ExcelToNewEntityList<PersonalInformation>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.PersonalInformation.AddOrUpdate(one);
					});
				else if (fileType == "ScheduleWork") ExcelHelper.ExcelToNewEntityList<ScheduleWork>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ScheduleWork.AddOrUpdate(one);
					});
				else if (fileType == "SpecialTopicOnPartyBuilding") ExcelHelper.ExcelToNewEntityList<SpecialTopicOnPartyBuilding>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.SpecialTopicOnPartyBuilding.AddOrUpdate(one);
					});
				else if (fileType == "BusinessGuide") ExcelHelper.ExcelToNewEntityList<BusinessGuide>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.BusinessGuide.AddOrUpdate(one);
					});
				else if (fileType == "PartyAffairsGuide") ExcelHelper.ExcelToNewEntityList<PartyAffairsGuide>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.PartyAffairsGuide.AddOrUpdate(one);
					});
				else if (fileType == "BusinessManagement") ExcelHelper.ExcelToNewEntityList<BusinessManagement>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.BusinessManagement.AddOrUpdate(one);
					});
				else if (fileType == "MedicalInsuranceForChildren") ExcelHelper.ExcelToNewEntityList<MedicalInsuranceForChildren>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.MedicalInsuranceForChildren.AddOrUpdate(one);
					});
				else if (fileType == "RuralMedicalTreatment") ExcelHelper.ExcelToNewEntityList<RuralMedicalTreatment>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.RuralMedicalTreatment.AddOrUpdate(one);
					});
				else if (fileType == "WelfarePayment") ExcelHelper.ExcelToNewEntityList<WelfarePayment>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.WelfarePayment.AddOrUpdate(one);
					});
				else if (fileType == "ServiceAppointment") ExcelHelper.ExcelToNewEntityList<ServiceAppointment>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ServiceAppointment.AddOrUpdate(one);
					});
				else if (fileType == "ScheduleManagement") ExcelHelper.ExcelToNewEntityList<ScheduleManagement>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ScheduleManagement.AddOrUpdate(one);
					});
				else if (fileType == "ExpertManagement") ExcelHelper.ExcelToNewEntityList<ExpertManagement>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ExpertManagement.AddOrUpdate(one);
					});
				else if (fileType == "PermissionAccess") ExcelHelper.ExcelToNewEntityList<PermissionAccess>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.PermissionAccess.AddOrUpdate(one);
					});
				else if (fileType == "ConvenienceGuide") ExcelHelper.ExcelToNewEntityList<ConvenienceGuide>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ConvenienceGuide.AddOrUpdate(one);
					});
				else if (fileType == "ConvenientLife") ExcelHelper.ExcelToNewEntityList<ConvenientLife>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ConvenientLife.AddOrUpdate(one);
					});
				else if (fileType == "CharacteristicOfXiangxi") ExcelHelper.ExcelToNewEntityList<CharacteristicOfXiangxi>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.CharacteristicOfXiangxi.AddOrUpdate(one);
					});
				else if (fileType == "ProposedTreatment") ExcelHelper.ExcelToNewEntityList<ProposedTreatment>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ProposedTreatment.AddOrUpdate(one);
					});
				else if (fileType == "VillageHistory") ExcelHelper.ExcelToNewEntityList<VillageHistory>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.VillageHistory.AddOrUpdate(one);
					});
				else if (fileType == "SpecialWork") ExcelHelper.ExcelToNewEntityList<SpecialWork>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.SpecialWork.AddOrUpdate(one);
					});
				else if (fileType == "VideoPointInformation") ExcelHelper.ExcelToNewEntityList<VideoPointInformation>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.VideoPointInformation.AddOrUpdate(one);
					});
				else if (fileType == "EmploymentAssistance") ExcelHelper.ExcelToNewEntityList<EmploymentAssistance>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.EmploymentAssistance.AddOrUpdate(one);
					});
				else if (fileType == "DangerousHousing") ExcelHelper.ExcelToNewEntityList<DangerousHousing>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.DangerousHousing.AddOrUpdate(one);
					});
				else if (fileType == "IndustrialParkHousingReceipt") ExcelHelper.ExcelToNewEntityList<IndustrialParkHousingReceipt>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.IndustrialParkHousingReceipt.AddOrUpdate(one);
					});
				else if (fileType == "DemandCollection") ExcelHelper.ExcelToNewEntityList<DemandCollection>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.DemandCollection.AddOrUpdate(one);
					});
				else if (fileType == "InformationManagementOfPartyOrganizations") ExcelHelper.ExcelToNewEntityList<InformationManagementOfPartyOrganizations>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.InformationManagementOfPartyOrganizations.AddOrUpdate(one);
					});
				else if (fileType == "CareForTheObject") ExcelHelper.ExcelToNewEntityList<CareForTheObject>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.CareForTheObject.AddOrUpdate(one);
					});
				else if (fileType == "RecruitmentAndEmploymentModule") ExcelHelper.ExcelToNewEntityList<RecruitmentAndEmploymentModule>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.RecruitmentAndEmploymentModule.AddOrUpdate(one);
					});
				else if (fileType == "PartyAndGroupFormation") ExcelHelper.ExcelToNewEntityList<PartyAndGroupFormation>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.PartyAndGroupFormation.AddOrUpdate(one);
					});
				else if (fileType == "PartyMemberActivities") ExcelHelper.ExcelToNewEntityList<PartyMemberActivities>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.PartyMemberActivities.AddOrUpdate(one);
					});
				else if (fileType == "BeautifulCountryside") ExcelHelper.ExcelToNewEntityList<BeautifulCountryside>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.BeautifulCountryside.AddOrUpdate(one);
					});
				else if (fileType == "DrawWaterUpaHill") ExcelHelper.ExcelToNewEntityList<DrawWaterUpaHill>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.DrawWaterUpaHill.AddOrUpdate(one);
					});
				else if (fileType == "Propaganda") ExcelHelper.ExcelToNewEntityList<Propaganda>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Propaganda.AddOrUpdate(one);
					});
				else if (fileType == "Organization") ExcelHelper.ExcelToNewEntityList<Organization>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Organization.AddOrUpdate(one);
					});
				else if (fileType == "LabourUnion") ExcelHelper.ExcelToNewEntityList<LabourUnion>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.LabourUnion.AddOrUpdate(one);
					});
				else if (fileType == "TradeUnionMembers") ExcelHelper.ExcelToNewEntityList<TradeUnionMembers>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.TradeUnionMembers.AddOrUpdate(one);
					});
				else if (fileType == "Personnel") ExcelHelper.ExcelToNewEntityList<Personnel>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Personnel.AddOrUpdate(one);
					});
				else if (fileType == "HandlingOfGusuVillageProblem") ExcelHelper.ExcelToNewEntityList<HandlingOfGusuVillageProblem>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.HandlingOfGusuVillageProblem.AddOrUpdate(one);
					});
				else if (fileType == "FisheryAdministration") ExcelHelper.ExcelToNewEntityList<FisheryAdministration>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.FisheryAdministration.AddOrUpdate(one);
					});
				else if (fileType == "ListOfExecutiveCommitteesOfWomensFederation") ExcelHelper.ExcelToNewEntityList<ListOfExecutiveCommitteesOfWomensFederation>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.ListOfExecutiveCommitteesOfWomensFederation.AddOrUpdate(one);
					});
				else if (fileType == "Assets") ExcelHelper.ExcelToNewEntityList<Assets>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Assets.AddOrUpdate(one);
					});
				else if (fileType == "Guardian") ExcelHelper.ExcelToNewEntityList<Guardian>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Guardian.AddOrUpdate(one);
					});
				else if (fileType == "Photo") ExcelHelper.ExcelToNewEntityList<Photo>(keypair, filePath, out errorMsg).ForEach(one=>{
				one.id = one.id ?? Guid.NewGuid().ToString();
                    one.CreateBy = one.CreateBy ?? user?.UILoginName ?? "未登录用户";
                    one.UpdateBy = user?.UILoginName ?? "未登录用户";
                    one.CreateOn = one.CreateOn ?? DateTime.Now;
                    one.TransactionID = transactionId;
                    one.UpdateOn = DateTime.Now;
                    one.IsDeleted = 0;
                    one.DataLevel = user?.DataLevel ?? "01";
					tx.Photo.AddOrUpdate(one);
					});					tx.SaveChanges();
            }
		}
    }
}
