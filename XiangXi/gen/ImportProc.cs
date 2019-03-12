




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
											
				else if (title == "SocialConditionsAndPublicOpinions")
				{
					buf.AppendLine("序号\t类型	发布人	区域	详情	上传文件\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (SocialConditionsAndPublicOpinions);
					foreach (var entity in tx.SocialConditionsAndPublicOpinions)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "MenuConfiguration")
				{
					buf.AppendLine("序号\t标题	链接	图片	父级标题	菜单类型	顺序\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (MenuConfiguration);
					foreach (var entity in tx.MenuConfiguration)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "RoleMenu")
				{
					buf.AppendLine("序号\t角色名称	菜单标题\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (RoleMenu);
					foreach (var entity in tx.RoleMenu)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "UserRole")
				{
					buf.AppendLine("序号\t角色名称	登录名\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (UserRole);
					foreach (var entity in tx.UserRole)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "RoleConfiguration")
				{
					buf.AppendLine("序号\t角色名称	所属组织\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (RoleConfiguration);
					foreach (var entity in tx.RoleConfiguration)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "UserInformation")
				{
					buf.AppendLine("序号\t登录名	密码	用户类型	用户级别	状态	昵称	真实姓名	头像	所属部门	电话	照片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (UserInformation);
					foreach (var entity in tx.UserInformation)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "LogonRecord")
				{
					buf.AppendLine("序号\t登录名	登录时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (LogonRecord);
					foreach (var entity in tx.LogonRecord)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "UserMenu")
				{
					buf.AppendLine("序号\t登录名	标题\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (UserMenu);
					foreach (var entity in tx.UserMenu)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "InformationManagementOfPartyMembers")
				{
					buf.AppendLine("序号\t姓名	身份证号	出生日期	性别	民族	学历	类别	所在党支部	入党日期	转正日期	工作岗位	联系电话	家庭住址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (InformationManagementOfPartyMembers);
					foreach (var entity in tx.InformationManagementOfPartyMembers)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "PartyFeeManagement")
				{
					buf.AppendLine("序号\t姓名	身份证号	年龄	所在党支部	月收入	月党费\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (PartyFeeManagement);
					foreach (var entity in tx.PartyFeeManagement)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "RecordingLectures")
				{
					buf.AppendLine("序号\t姓名	身份证号码	课程名称	课程摘要	学习情况	课程时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (RecordingLectures);
					foreach (var entity in tx.RecordingLectures)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ThreeSessions")
				{
					buf.AppendLine("序号\t日期	主题	参与人员	与会人数	主持人	内容	类型\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ThreeSessions);
					foreach (var entity in tx.ThreeSessions)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ThematicStudy")
				{
					buf.AppendLine("序号\t日期	专题内容	参与人员	与会人数	主持人	内容\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ThematicStudy);
					foreach (var entity in tx.ThematicStudy)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "PolicyDocument")
				{
					buf.AppendLine("序号\t文件号	@政策文件类别	专文件主题	内容	上传文件	年份\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (PolicyDocument);
					foreach (var entity in tx.PolicyDocument)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "PolicyDocumentCategory")
				{
					buf.AppendLine("序号\t类别名称	描述\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (PolicyDocumentCategory);
					foreach (var entity in tx.PolicyDocumentCategory)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "UnitedFrontObjectDetails")
				{
					buf.AppendLine("序号\t姓名	性别	民族	家庭住址	身份证号码	联系方式	类型	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (UnitedFrontObjectDetails);
					foreach (var entity in tx.UnitedFrontObjectDetails)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "MuslimFoodSubsidies")
				{
					buf.AppendLine("序号\t姓名	性别	民族	家庭住址	身份证号码	联系方式	补贴标准	实发金额	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (MuslimFoodSubsidies);
					foreach (var entity in tx.MuslimFoodSubsidies)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ListOfActiveServicemen")
				{
					buf.AppendLine("序号\t姓名	民族	家庭住址	身份证号码	联系方式	家庭情况	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ListOfActiveServicemen);
					foreach (var entity in tx.ListOfActiveServicemen)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ListOfRecruits")
				{
					buf.AppendLine("序号\t姓名	出生年月	文化程度	政治面貌	户口性质	毕业院校	联系方式	身份证号码	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ListOfRecruits);
					foreach (var entity in tx.ListOfRecruits)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "TheCommunistYouthLeague")
				{
					buf.AppendLine("序号\t序号	姓名	性别	出生日期	志愿时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (TheCommunistYouthLeague);
					foreach (var entity in tx.TheCommunistYouthLeague)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "KeyPersonnel")
				{
					buf.AppendLine("序号\t序号	姓名	性别	居住地	户籍地	事由	目前状态	联系电话	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (KeyPersonnel);
					foreach (var entity in tx.KeyPersonnel)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "LetterAndVisit")
				{
					buf.AppendLine("序号\t序号	投诉事件	投诉地点	办理结果\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (LetterAndVisit);
					foreach (var entity in tx.LetterAndVisit)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "TwoCategoriesOfPersonnel")
				{
					buf.AppendLine("序号\t所在社区	姓名	性别	身份证号码	罪名	家庭住址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (TwoCategoriesOfPersonnel);
					foreach (var entity in tx.TwoCategoriesOfPersonnel)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "Family")
				{
					buf.AppendLine("序号\t家庭组织名称	姓名	身份证号码	新生儿姓名	死亡证明	居住地	联系方式\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (Family);
					foreach (var entity in tx.Family)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "Investors")
				{
					buf.AppendLine("序号\t姓名	身份证号码	产业名称	物业股占比	资产股占比	投资股占比	继承自	是否有效\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (Investors);
					foreach (var entity in tx.Investors)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "BonusRecord")
				{
					buf.AppendLine("序号\t姓名	身份证号码	股份类型	股票占比	发放金额	发放时间	负责人	负责人联系方式\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (BonusRecord);
					foreach (var entity in tx.BonusRecord)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "Cadre")
				{
					buf.AppendLine("序号\t姓名	身份证号码	上级领导	所属支部	劳模	干部类型\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (Cadre);
					foreach (var entity in tx.Cadre)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "Militia")
				{
					buf.AppendLine("序号\t姓名	身份证号码	上级领导	所属番号	民兵类型\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (Militia);
					foreach (var entity in tx.Militia)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ThreeProductionBuilding")
				{
					buf.AppendLine("序号\t名称	地址	楼号	单元号	门牌号	入驻企业名称	负责人	负责人联系方式	范围	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ThreeProductionBuilding);
					foreach (var entity in tx.ThreeProductionBuilding)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "Building")
				{
					buf.AppendLine("序号\t工业园名称	序号	承租户	起止	承租面积	押金	单价	月租金	年租金	租凭单位性质	环保手续	建筑面积	开始时间	结束时间	联系人	联系电话	审批文件	楼号	单元号	门牌号	负责人	负责人联系方式	范围	备注	地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (Building);
					foreach (var entity in tx.Building)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "RentRecord")
				{
					buf.AppendLine("序号\t企业名称	负责人	负责人电话	付款金额	收款人	收款人电话	收款金额	收款时间	应收款时间	备注	工业园名称\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (RentRecord);
					foreach (var entity in tx.RentRecord)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "RecordOfElectricityPayment")
				{
					buf.AppendLine("序号\t企业名称	负责人	负责人电话	付款金额	收款人	收款人电话	收款金额	收款时间	应收款时间	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (RecordOfElectricityPayment);
					foreach (var entity in tx.RecordOfElectricityPayment)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "WorkLog")
				{
					buf.AppendLine("序号\t序号	条线	负责人	日期	办理事项	是否完成	完成时间	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (WorkLog);
					foreach (var entity in tx.WorkLog)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "Advise")
				{
					buf.AppendLine("序号\t标题	内容	作者	通知发送日期	通知发送对象	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (Advise);
					foreach (var entity in tx.Advise)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "DocumentManagement")
				{
					buf.AppendLine("序号\t标题	内容	作者	原件图片	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (DocumentManagement);
					foreach (var entity in tx.DocumentManagement)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "Population")
				{
					buf.AppendLine("序号\t公民身份号码	姓名	性别	出生日期	居村委会	住址	年龄\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (Population);
					foreach (var entity in tx.Population)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "HouseProperty")
				{
					buf.AppendLine("序号\t身份证	地址	楼栋号	单元号	门牌号\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (HouseProperty);
					foreach (var entity in tx.HouseProperty)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ReimbursementList")
				{
					buf.AppendLine("序号\t姓名	出发位置	目的地位置	交通费	住宿费	住勤补贴	公交费	报销日期\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ReimbursementList);
					foreach (var entity in tx.ReimbursementList)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "MailList")
				{
					buf.AppendLine("序号\t机构名称	人员姓名	身份证	性别	电话	手机	邮箱	职位	上级领导	QQ	微信\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (MailList);
					foreach (var entity in tx.MailList)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "POI")
				{
					buf.AppendLine("序号\t地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (POI);
					foreach (var entity in tx.POI)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "PartyNewsManagement")
				{
					buf.AppendLine("序号\t标题	内容	作者	发布时间	类别	图片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (PartyNewsManagement);
					foreach (var entity in tx.PartyNewsManagement)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "Pat")
				{
					buf.AppendLine("序号\t内容	设备	用户ID	照片	拍照时间	位置	姓名	电话	区域	点赞数目\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (Pat);
					foreach (var entity in tx.Pat)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ActiveInspection")
				{
					buf.AppendLine("序号\t巡检问题	创建时间	状态	用户	区域	图片	位置\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ActiveInspection);
					foreach (var entity in tx.ActiveInspection)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "BusinessReservation")
				{
					buf.AppendLine("序号\t业务	服务	姓名	身份证	电话	创建时间	受理时间	状态\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (BusinessReservation);
					foreach (var entity in tx.BusinessReservation)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "SuggestionRecord")
				{
					buf.AppendLine("序号\t标题	内容	对象	处理人	处理日期\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (SuggestionRecord);
					foreach (var entity in tx.SuggestionRecord)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "TheStudyOfPartyStyleAndCleanGovernment")
				{
					buf.AppendLine("序号\t标题	内容	学习对象	学习日期	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (TheStudyOfPartyStyleAndCleanGovernment);
					foreach (var entity in tx.TheStudyOfPartyStyleAndCleanGovernment)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "Service")
				{
					buf.AppendLine("序号\t名称	位置	类型	归属	换新日期	是否损坏\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (Service);
					foreach (var entity in tx.Service)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "SystemConfiguration")
				{
					buf.AppendLine("序号\t标题	分类	子分类	内容	是否生效\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (SystemConfiguration);
					foreach (var entity in tx.SystemConfiguration)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "PartyBuilding")
				{
					buf.AppendLine("序号\t标题	内容	发布时间	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (PartyBuilding);
					foreach (var entity in tx.PartyBuilding)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "MembershipDuesPaymentManagement")
				{
					buf.AppendLine("序号\t姓名	电话	金额	日期	收款人	所属支部\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (MembershipDuesPaymentManagement);
					foreach (var entity in tx.MembershipDuesPaymentManagement)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ContractManagement")
				{
					buf.AppendLine("序号\t合同编号	合同名称	项目名称	甲方签名	乙方签名	丙方签名	签署日期	签署机构	合同文件上传\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ContractManagement);
					foreach (var entity in tx.ContractManagement)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "PersonalInformation")
				{
					buf.AppendLine("序号\t登录名	昵称	真实姓名	密码	头像	上次登录时间	所属部门	电话	照片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (PersonalInformation);
					foreach (var entity in tx.PersonalInformation)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ScheduleWork")
				{
					buf.AppendLine("序号\t标题	内容	地点	负责人	电话	开始时间	结束时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ScheduleWork);
					foreach (var entity in tx.ScheduleWork)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "PartyBuildingProject")
				{
					buf.AppendLine("序号\t标题	预览	发布时间	查看\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (PartyBuildingProject);
					foreach (var entity in tx.PartyBuildingProject)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "GuideToAffairs")
				{
					buf.AppendLine("序号\t类别	办事内容	所需材料	办事程序\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (GuideToAffairs);
					foreach (var entity in tx.GuideToAffairs)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "GuideToPartyAffairs")
				{
					buf.AppendLine("序号\t标题	内容	类别	适用范围\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (GuideToPartyAffairs);
					foreach (var entity in tx.GuideToPartyAffairs)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "BusinessManagement")
				{
					buf.AppendLine("序号\t业务类型	服务类型	申请人	身份证	性别	大厅受理时间	经办人	创建时间	状态\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (BusinessManagement);
					foreach (var entity in tx.BusinessManagement)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ChildrensMedicalInsuranceRegistration")
				{
					buf.AppendLine("序号\t单位编号	人员编号	姓名	身份证	出生日期	免缴种类	免缴号码	联系人	联系电话\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ChildrensMedicalInsuranceRegistration);
					foreach (var entity in tx.ChildrensMedicalInsuranceRegistration)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "RuralMedicalTreatment")
				{
					buf.AppendLine("序号\t人员编号	姓名	身份证	免缴种类	免缴号码	联系人	联系电话	区域	操作\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (RuralMedicalTreatment);
					foreach (var entity in tx.RuralMedicalTreatment)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "WelfareGrant")
				{
					buf.AppendLine("序号\t姓名	性别	年龄	身份证号	福利类型	发放金额	发放日期	被保人id	住址	区域	操作\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (WelfareGrant);
					foreach (var entity in tx.WelfareGrant)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ServiceReservation")
				{
					buf.AppendLine("序号\t服务类型	预约人	预约时间	身份证	创建时间	审核时间	状态	审核登记\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ServiceReservation);
					foreach (var entity in tx.ServiceReservation)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ScheduleManagement")
				{
					buf.AppendLine("序号\t活动类型	开始日期	结束日期	内容	地点	负责人	电话	备注\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ScheduleManagement);
					foreach (var entity in tx.ScheduleManagement)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "ExpertManagement")
				{
					buf.AppendLine("序号\t技术特长	姓名	性别	出生日期	身份证	地址	联系电话\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (ExpertManagement);
					foreach (var entity in tx.ExpertManagement)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "Access")
				{
					buf.AppendLine("序号\t姓名	访问时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (Access);
					foreach (var entity in tx.Access)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "aGuideToTheConvenienceOfPeople")
				{
					buf.AppendLine("序号\t标题	发布时间	图片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (aGuideToTheConvenienceOfPeople);
					foreach (var entity in tx.aGuideToTheConvenienceOfPeople)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "FeaturesOfXiangxi")
				{
					buf.AppendLine("序号\t标题	发布时间	图片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (FeaturesOfXiangxi);
					foreach (var entity in tx.FeaturesOfXiangxi)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "RecommendedTreatment")
				{
					buf.AppendLine("序号\t标题	内容	对象	处理人	处理日期	姓名	身份证	电话	创建时间	状态\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (RecommendedTreatment);
					foreach (var entity in tx.RecommendedTreatment)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "VillageHistory")
				{
					buf.AppendLine("序号\t菜单项	主标题	副标题	图片	摘要\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (VillageHistory);
					foreach (var entity in tx.VillageHistory)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "SpecialWork")
				{
					buf.AppendLine("序号\t工作主题	工作内容	开始日期	结束日期	状态	照片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (SpecialWork);
					foreach (var entity in tx.SpecialWork)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "VideoPointBitInformation")
				{
					buf.AppendLine("序号\t序号	监控点名称	监控点编号	所属组织	所属区域	所属平台	经度	纬度	地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (VideoPointBitInformation);
					foreach (var entity in tx.VideoPointBitInformation)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "EmploymentAssistance")
				{
					buf.AppendLine("序号\t个人编号	姓名	身份证号码	性别	民族	年龄	文化程度	户口性质	是否残疾	培训意愿	联系方式	人员类型	就业形式	内容1	内容2	内容3	内容4\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (EmploymentAssistance);
					foreach (var entity in tx.EmploymentAssistance)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "CriticalHousingCrisis")
				{
					buf.AppendLine("序号\t所有权人	房屋座落	房产证面积	土地证面积	测绘面积	测绘增补面积	安置面积	签字时间	交房时间	补偿金额	联系电话	现居住地址\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (CriticalHousingCrisis);
					foreach (var entity in tx.CriticalHousingCrisis)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "IndustrialParkHousingReceipts")
				{
					buf.AppendLine("序号\t@厂房楼栋	开始时间	结束时间	付款金额\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (IndustrialParkHousingReceipts);
					foreach (var entity in tx.IndustrialParkHousingReceipts)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "DemandCollection")
				{
					buf.AppendLine("序号\t您需要什么内容	期望交付时间	您的姓名	您的联系方式\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (DemandCollection);
					foreach (var entity in tx.DemandCollection)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "InformationManagementOfPartyOrganization")
				{
					buf.AppendLine("序号\t党组织名称	党组织书记	党组织联系人	联系电话	组织类别	上级党组织名称\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (InformationManagementOfPartyOrganization);
					foreach (var entity in tx.InformationManagementOfPartyOrganization)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "TheObjectOfCare")
				{
					buf.AppendLine("序号\t姓名	性别	类型	身份证	户口所在地	常住地	楼栋号	单元号	门牌号\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (TheObjectOfCare);
					foreach (var entity in tx.TheObjectOfCare)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "EmploymentModule")
				{
					buf.AppendLine("序号\t用人单位	职位	发布人	职位描述	职位职责内容	职位要求内容	生效时间	失效时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (EmploymentModule);
					foreach (var entity in tx.EmploymentModule)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "PartyGroupFormation")
				{
					buf.AppendLine("序号\t所属党组织	成员姓名	身份证号码	创建时间\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (PartyGroupFormation);
					foreach (var entity in tx.PartyGroupFormation)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "PartyMembersActivities")
				{
					buf.AppendLine("序号\t活动名称	活动简介	覆盖范围	活动照片\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (PartyMembersActivities);
					foreach (var entity in tx.PartyMembersActivities)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "BeautifulCountryside")
				{
					buf.AppendLine("序号\t年份	月份	标题	照片	建设成果\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (BeautifulCountryside);
					foreach (var entity in tx.BeautifulCountryside)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
											
				else if (title == "DrawWaterUpaHill")
				{
					buf.AppendLine("序号\t年份	月份	标题	照片	建设成果\t顺序号\t版本号\t会话编号\t创建人\t创建时间\t更新人\t更新时间\t数据级别\t");

					var type = typeof (DrawWaterUpaHill);
					foreach (var entity in tx.DrawWaterUpaHill)
					{
					    buf.AppendLine(string.Join("\t", type.GetProperties().Select(p => p.GetValue(entity))));
					}
				}
				            }
            return buf.ToString();
        }

		public static void Proc(
			string fileType,
			string filePath,
			out StringBuilder errorMsg){
			errorMsg = new StringBuilder();
            using (var tx = new DefaultContext())
            {
                Dictionary<string, Dictionary<string,string>> dic = new Dictionary<string, Dictionary<string,string>>();
									dic.Add("SocialConditionsAndPublicOpinions", new Dictionary<string,string>{ {"SCAPOForm","类型"},{"SCAPOPublisher","发布人"},{"SCAPODistrict","区域"},{"SCAPODetailsOfTheCase","详情"},{"SCAPOUploadingFiles","上传文件"} });
										dic.Add("MenuConfiguration", new Dictionary<string,string>{ {"MCCaption","标题"},{"MCLink","链接"},{"MCPicture","图片"},{"MCParentTitle","父级标题"},{"MCMenuType","菜单类型"},{"MCSequence","顺序"} });
										dic.Add("RoleMenu", new Dictionary<string,string>{ {"RMRoleName","角色名称"},{"RMMenuTitle","菜单标题"} });
										dic.Add("UserRole", new Dictionary<string,string>{ {"URRoleName","角色名称"},{"URLoginName","登录名"} });
										dic.Add("RoleConfiguration", new Dictionary<string,string>{ {"RCRoleName","角色名称"},{"RCAffiliatedOrganization","所属组织"} });
										dic.Add("UserInformation", new Dictionary<string,string>{ {"UILoginName","登录名"},{"UICode","密码"},{"UICustomerType","用户类型"},{"UIUserLevel","用户级别"},{"UIBackwardness","状态"},{"UINickname","昵称"},{"UIRealName","真实姓名"},{"UIHeadPortrait","头像"},{"UISubordinateDepartment","所属部门"},{"UIBooth","电话"},{"UIPhoto","照片"} });
										dic.Add("LogonRecord", new Dictionary<string,string>{ {"LRLoginName","登录名"},{"LRLoginTime","登录时间"} });
										dic.Add("UserMenu", new Dictionary<string,string>{ {"UMLoginName","登录名"},{"UMCaption","标题"} });
										dic.Add("InformationManagementOfPartyMembers", new Dictionary<string,string>{ {"IMOPMName","姓名"},{"IMOPMIdNumber","身份证号"},{"IMOPMDateOfBirth","出生日期"},{"IMOPMChairperson","性别"},{"IMOPMCivilization","民族"},{"IMOPMEducation","学历"},{"IMOPMCategory","类别"},{"IMOPMPartyBranch","所在党支部"},{"IMOPMDateOfAdmissionToTheParty","入党日期"},{"IMOPMDateOfCorrection","转正日期"},{"IMOPMPost","工作岗位"},{"IMOPMContactNumber","联系电话"},{"IMOPMHomeAddress","家庭住址"} });
										dic.Add("PartyFeeManagement", new Dictionary<string,string>{ {"PFMName","姓名"},{"PFMIdNumber","身份证号"},{"PFMAge","年龄"},{"PFMPartyBranch","所在党支部"},{"PFMMonthlyIncome","月收入"},{"PFMMonthlyPartyFee","月党费"} });
										dic.Add("RecordingLectures", new Dictionary<string,string>{ {"RLName","姓名"},{"RLIdCard","身份证号码"},{"RLCourseName","课程名称"},{"RLCourseSummary","课程摘要"},{"RLLearningSituation","学习情况"},{"RLCourseTime","课程时间"} });
										dic.Add("ThreeSessions", new Dictionary<string,string>{ {"TSDate","日期"},{"TSTheme","主题"},{"TSParticipants","参与人员"},{"TSNumberOfParticipants","与会人数"},{"TSHostess","主持人"},{"TSContent","内容"},{"TSForm","类型"} });
										dic.Add("ThematicStudy", new Dictionary<string,string>{ {"TSDate","日期"},{"TSThematicContent","专题内容"},{"TSParticipants","参与人员"},{"TSNumberOfParticipants","与会人数"},{"TSHostess","主持人"},{"TSContent","内容"} });
										dic.Add("PolicyDocument", new Dictionary<string,string>{ {"PDFileNumber","文件号"},{"PDPolicyDocumentCategory","@政策文件类别"},{"PDDedicatedDocumentTopics","专文件主题"},{"PDContent","内容"},{"PDUploadingFiles","上传文件"},{"PDParticularYear","年份"} });
										dic.Add("PolicyDocumentCategory", new Dictionary<string,string>{ {"PDCCategoryName","类别名称"},{"PDCDepict","描述"} });
										dic.Add("UnitedFrontObjectDetails", new Dictionary<string,string>{ {"UFODName","姓名"},{"UFODChairperson","性别"},{"UFODCivilization","民族"},{"UFODHomeAddress","家庭住址"},{"UFODIdCard","身份证号码"},{"UFODCommonModeOfContact","联系方式"},{"UFODForm","类型"},{"UFODRemarks","备注"} });
										dic.Add("MuslimFoodSubsidies", new Dictionary<string,string>{ {"MFSName","姓名"},{"MFSChairperson","性别"},{"MFSCivilization","民族"},{"MFSHomeAddress","家庭住址"},{"MFSIdCard","身份证号码"},{"MFSCommonModeOfContact","联系方式"},{"MFSStandardOfSubsidy","补贴标准"},{"MFSRealAmountOfMoney","实发金额"},{"MFSRemarks","备注"} });
										dic.Add("ListOfActiveServicemen", new Dictionary<string,string>{ {"LOASName","姓名"},{"LOASCivilization","民族"},{"LOASHomeAddress","家庭住址"},{"LOASIdCard","身份证号码"},{"LOASCommonModeOfContact","联系方式"},{"LOASFamilySituation","家庭情况"},{"LOASRemarks","备注"} });
										dic.Add("ListOfRecruits", new Dictionary<string,string>{ {"LORName","姓名"},{"LORDateOfBirth","出生年月"},{"LORDegreeOfEducation","文化程度"},{"LORPoliticalOutlook","政治面貌"},{"LORNatureOfHouseholdRegistration","户口性质"},{"LORUniversityOneIsGraduatedFrom","毕业院校"},{"LORCommonModeOfContact","联系方式"},{"LORIdCard","身份证号码"},{"LORRemarks","备注"} });
										dic.Add("TheCommunistYouthLeague", new Dictionary<string,string>{ {"TCYLSerialNumber","序号"},{"TCYLName","姓名"},{"TCYLChairperson","性别"},{"TCYLDateOfBirth","出生日期"},{"TCYLVolunteerTime","志愿时间"} });
										dic.Add("KeyPersonnel", new Dictionary<string,string>{ {"KPSerialNumber","序号"},{"KPName","姓名"},{"KPChairperson","性别"},{"KPPlaceOfResidence","居住地"},{"KPDomicilePlace","户籍地"},{"KPCause","事由"},{"KPCurrentState","目前状态"},{"KPContactNumber","联系电话"},{"KPRemarks","备注"} });
										dic.Add("LetterAndVisit", new Dictionary<string,string>{ {"LAVSerialNumber","序号"},{"LAVComplaints","投诉事件"},{"LAVPlaceOfComplaint","投诉地点"},{"LAVDealWithTheResults","办理结果"} });
										dic.Add("TwoCategoriesOfPersonnel", new Dictionary<string,string>{ {"TCOPTheCommunityInWhichItIsLocated","所在社区"},{"TCOPName","姓名"},{"TCOPChairperson","性别"},{"TCOPIdCard","身份证号码"},{"TCOPCharge","罪名"},{"TCOPHomeAddress","家庭住址"} });
										dic.Add("Family", new Dictionary<string,string>{ {"FFamilyOrganizationName","家庭组织名称"},{"FName","姓名"},{"FIdCard","身份证号码"},{"FNameOfTheNewborn","新生儿姓名"},{"FDeathCertificate","死亡证明"},{"FPlaceOfResidence","居住地"},{"FCommonModeOfContact","联系方式"} });
										dic.Add("Investors", new Dictionary<string,string>{ {"IName","姓名"},{"IIdCard","身份证号码"},{"IIndustryName","产业名称"},{"IPropertyShareRatio","物业股占比"},{"IAssetShareRatio","资产股占比"},{"IInvestmentShareRatio","投资股占比"},{"IInherit","继承自"},{"IIsItValid","是否有效"} });
										dic.Add("BonusRecord", new Dictionary<string,string>{ {"BRName","姓名"},{"BRIdCard","身份证号码"},{"BRTypesOfShares","股份类型"},{"BRShareRatio","股票占比"},{"BRAmountOfPayment","发放金额"},{"BRReleaseTime","发放时间"},{"BRSuperinrtendent","负责人"},{"BRContactModeOfThePersonInCharge","负责人联系方式"} });
										dic.Add("Cadre", new Dictionary<string,string>{ {"CName","姓名"},{"CIdCard","身份证号码"},{"CSuperiorLeadership","上级领导"},{"CBranch","所属支部"},{"CModelWorker","劳模"},{"CTypeOfCadre","干部类型"} });
										dic.Add("Militia", new Dictionary<string,string>{ {"MName","姓名"},{"MIdCard","身份证号码"},{"MSuperiorLeadership","上级领导"},{"MTheDesignation","所属番号"},{"MTypeOfMilitia","民兵类型"} });
										dic.Add("ThreeProductionBuilding", new Dictionary<string,string>{ {"TPBName","名称"},{"TPBAddress","地址"},{"TPBBuildingNumber","楼号"},{"TPBUnitNumber","单元号"},{"TPBDoorNumber","门牌号"},{"TPBTheNameOfEnterprise","入驻企业名称"},{"TPBSuperinrtendent","负责人"},{"TPBContactModeOfThePersonInCharge","负责人联系方式"},{"TPBExtent","范围"},{"TPBRemarks","备注"} });
										dic.Add("Building", new Dictionary<string,string>{ {"BIndustrialParkName","工业园名称"},{"BSerialNumber","序号"},{"BTenant","承租户"},{"BStartAndStop","起止"},{"BRentingArea","承租面积"},{"BDeposit","押金"},{"BUnitPrice","单价"},{"BMonthlyRent","月租金"},{"BAnnualRent","年租金"},{"BPropertyOfRentingUnits","租凭单位性质"},{"BEnvironmentalProtectionFormalities","环保手续"},{"BBuiltUpArea","建筑面积"},{"BStartTime","开始时间"},{"BEndTime","结束时间"},{"BContacts","联系人"},{"BContactNumber","联系电话"},{"BApprovalDocument","审批文件"},{"BBuildingNumber","楼号"},{"BUnitNumber","单元号"},{"BDoorNumber","门牌号"},{"BSuperinrtendent","负责人"},{"BContactModeOfThePersonInCharge","负责人联系方式"},{"BExtent","范围"},{"BRemarks","备注"},{"BAddress","地址"} });
										dic.Add("RentRecord", new Dictionary<string,string>{ {"RREnterpriseName","企业名称"},{"RRSuperinrtendent","负责人"},{"RREnterpriseLeaderPhone","负责人电话"},{"RRAmountOfPayment","付款金额"},{"RRPayee","收款人"},{"RRPayeePhone","收款人电话"},{"RRAmountCollected","收款金额"},{"RRCollectionTime","收款时间"},{"RRTimeOfReceivables","应收款时间"},{"RRRemarks","备注"},{"RRIndustrialParkName","工业园名称"} });
										dic.Add("RecordOfElectricityPayment", new Dictionary<string,string>{ {"ROEPEnterpriseName","企业名称"},{"ROEPSuperinrtendent","负责人"},{"ROEPEnterpriseLeaderPhone","负责人电话"},{"ROEPAmountOfPayment","付款金额"},{"ROEPPayee","收款人"},{"ROEPPayeePhone","收款人电话"},{"ROEPAmountCollected","收款金额"},{"ROEPCollectionTime","收款时间"},{"ROEPTimeOfReceivables","应收款时间"},{"ROEPRemarks","备注"} });
										dic.Add("WorkLog", new Dictionary<string,string>{ {"WLSerialNumber","序号"},{"WLLine","条线"},{"WLSuperinrtendent","负责人"},{"WLDate","日期"},{"WLHandlingMatters","办理事项"},{"WLIsItDone","是否完成"},{"WLCompletionTime","完成时间"},{"WLRemarks","备注"} });
										dic.Add("Advise", new Dictionary<string,string>{ {"ACaption","标题"},{"AContent","内容"},{"AAuthor","作者"},{"ANotificationDeliveryDate","通知发送日期"},{"ANotifyingTheSendingObject","通知发送对象"},{"ARemarks","备注"} });
										dic.Add("DocumentManagement", new Dictionary<string,string>{ {"DMCaption","标题"},{"DMContent","内容"},{"DMAuthor","作者"},{"DMOriginalPicture","原件图片"},{"DMRemarks","备注"} });
										dic.Add("Population", new Dictionary<string,string>{ {"PCitizenshipNumber","公民身份号码"},{"PName","姓名"},{"PChairperson","性别"},{"PDateOfBirth","出生日期"},{"PVillageCommittee","居村委会"},{"PAddress","住址"},{"PAge","年龄"} });
										dic.Add("HouseProperty", new Dictionary<string,string>{ {"HPIdNumber","身份证"},{"HPAddress","地址"},{"HPBuildingNumber","楼栋号"},{"HPUnitNumber","单元号"},{"HPDoorNumber","门牌号"} });
										dic.Add("ReimbursementList", new Dictionary<string,string>{ {"RLName","姓名"},{"RLStartingPosition","出发位置"},{"RLDestinationLocation","目的地位置"},{"RLTrafficExpense","交通费"},{"RLHotelExpense","住宿费"},{"RLAccommodationAllowance","住勤补贴"},{"RLBusFee","公交费"},{"RLDateOfReimbursement","报销日期"} });
										dic.Add("MailList", new Dictionary<string,string>{ {"MLOrganizationName","机构名称"},{"MLNameOfPersonnel","人员姓名"},{"MLIdNumber","身份证"},{"MLChairperson","性别"},{"MLBooth","电话"},{"ML","手机"},{"MLMailbox","邮箱"},{"MLPost","职位"},{"MLSuperiorLeadership","上级领导"},{"MLQQ","QQ"},{"MLWechat","微信"} });
										dic.Add("POI", new Dictionary<string,string>{ {"POIAddress","地址"} });
										dic.Add("PartyNewsManagement", new Dictionary<string,string>{ {"PNMCaption","标题"},{"PNMContent","内容"},{"PNMAuthor","作者"},{"PNMReleaseTime","发布时间"},{"PNMCategory","类别"},{"PNMPicture","图片"} });
										dic.Add("Pat", new Dictionary<string,string>{ {"PContent","内容"},{"PApparatus","设备"},{"PUserId","用户ID"},{"PPhoto","照片"},{"PPhotoOp","拍照时间"},{"PLocation","位置"},{"PName","姓名"},{"PBooth","电话"},{"PDistrict","区域"},{"PNumberOfPointsPraise","点赞数目"} });
										dic.Add("ActiveInspection", new Dictionary<string,string>{ {"AIInspectionProblem","巡检问题"},{"AICreationTime","创建时间"},{"AIBackwardness","状态"},{"AIClient","用户"},{"AIDistrict","区域"},{"AIPicture","图片"},{"AILocation","位置"} });
										dic.Add("BusinessReservation", new Dictionary<string,string>{ {"BRBanking","业务"},{"BRAttendant","服务"},{"BRName","姓名"},{"BRIdNumber","身份证"},{"BRBooth","电话"},{"BRCreationTime","创建时间"},{"BRHallAcceptanceTime","受理时间"},{"BRBackwardness","状态"} });
										dic.Add("SuggestionRecord", new Dictionary<string,string>{ {"SRCaption","标题"},{"SRContent","内容"},{"SRTarget","对象"},{"SRProcessingPerson","处理人"},{"SRProcessingDate","处理日期"} });
										dic.Add("TheStudyOfPartyStyleAndCleanGovernment", new Dictionary<string,string>{ {"TSOPSACGCaption","标题"},{"TSOPSACGContent","内容"},{"TSOPSACGLearningObject","学习对象"},{"TSOPSACGLearningDate","学习日期"},{"TSOPSACGRemarks","备注"} });
										dic.Add("Service", new Dictionary<string,string>{ {"SName","名称"},{"SLocation","位置"},{"SForm","类型"},{"SAscription","归属"},{"SNewDate","换新日期"},{"SIsItDamaged","是否损坏"} });
										dic.Add("SystemConfiguration", new Dictionary<string,string>{ {"SCCaption","标题"},{"SCClassification","分类"},{"SCSubclassification","子分类"},{"SCContent","内容"},{"SCIsItEffective","是否生效"} });
										dic.Add("PartyBuilding", new Dictionary<string,string>{ {"PBCaption","标题"},{"PBContent","内容"},{"PBReleaseTime","发布时间"},{"PBRemarks","备注"} });
										dic.Add("MembershipDuesPaymentManagement", new Dictionary<string,string>{ {"MDPMName","姓名"},{"MDPMBooth","电话"},{"MDPMConsolationAmount","金额"},{"MDPMDate","日期"},{"MDPMPayee","收款人"},{"MDPMBranch","所属支部"} });
										dic.Add("ContractManagement", new Dictionary<string,string>{ {"CMContractNumber","合同编号"},{"CMContractName","合同名称"},{"CMEntryName","项目名称"},{"CMSignatureOfPartya","甲方签名"},{"CMSignaturesOfPartyb","乙方签名"},{"CMPartycSignature","丙方签名"},{"CMDateOfSigning","签署日期"},{"CMSigningAgency","签署机构"},{"CMContractFileUpload","合同文件上传"} });
										dic.Add("PersonalInformation", new Dictionary<string,string>{ {"PILoginName","登录名"},{"PINickname","昵称"},{"PIRealName","真实姓名"},{"PICode","密码"},{"PIHeadPortrait","头像"},{"PILastLoginTime","上次登录时间"},{"PISubordinateDepartment","所属部门"},{"PIBooth","电话"},{"PIPhoto","照片"} });
										dic.Add("ScheduleWork", new Dictionary<string,string>{ {"SWCaption","标题"},{"SWContent","内容"},{"SWLocality","地点"},{"SWSuperinrtendent","负责人"},{"SWBooth","电话"},{"SWStartTime","开始时间"},{"SWEndTime","结束时间"} });
										dic.Add("PartyBuildingProject", new Dictionary<string,string>{ {"PBPCaption","标题"},{"PBPPreview","预览"},{"PBPReleaseTime","发布时间"},{"PBPSee","查看"} });
										dic.Add("GuideToAffairs", new Dictionary<string,string>{ {"GTACategory","类别"},{"GTAWorkContent","办事内容"},{"GTARequiredMaterials","所需材料"},{"GTAProceduralProcedure","办事程序"} });
										dic.Add("GuideToPartyAffairs", new Dictionary<string,string>{ {"GTPACaption","标题"},{"GTPAContent","内容"},{"GTPACategory","类别"},{"GTPAScopeOfApplication","适用范围"} });
										dic.Add("BusinessManagement", new Dictionary<string,string>{ {"BMBusinessType","业务类型"},{"BMServiceType","服务类型"},{"BMApplicant","申请人"},{"BMIdNumber","身份证"},{"BMChairperson","性别"},{"BMHallAcceptanceTime","大厅受理时间"},{"BMAgent","经办人"},{"BMCreationTime","创建时间"},{"BMBackwardness","状态"} });
										dic.Add("ChildrensMedicalInsuranceRegistration", new Dictionary<string,string>{ {"CMIRUnitNumber","单位编号"},{"CMIRPersonnelNumber","人员编号"},{"CMIRName","姓名"},{"CMIRIdNumber","身份证"},{"CMIRDateOfBirth","出生日期"},{"CMIRExemptedSpecies","免缴种类"},{"CMIRExemptionNumber","免缴号码"},{"CMIRContacts","联系人"},{"CMIRContactNumber","联系电话"} });
										dic.Add("RuralMedicalTreatment", new Dictionary<string,string>{ {"RMTPersonnelNumber","人员编号"},{"RMTName","姓名"},{"RMTIdNumber","身份证"},{"RMTExemptedSpecies","免缴种类"},{"RMTExemptionNumber","免缴号码"},{"RMTContacts","联系人"},{"RMTContactNumber","联系电话"},{"RMTDistrict","区域"},{"RMTDiscern","操作"} });
										dic.Add("WelfareGrant", new Dictionary<string,string>{ {"WGName","姓名"},{"WGChairperson","性别"},{"WGAge","年龄"},{"WGIdNumber","身份证号"},{"WGWelfareType","福利类型"},{"WGAmountOfPayment","发放金额"},{"WGDateOfIssuance","发放日期"},{"WGTheInsuredId","被保人id"},{"WGAddress","住址"},{"WGDistrict","区域"},{"WGDiscern","操作"} });
										dic.Add("ServiceReservation", new Dictionary<string,string>{ {"SRServiceType","服务类型"},{"SRReservations","预约人"},{"SRTimeOfAppointment","预约时间"},{"SRIdNumber","身份证"},{"SRCreationTime","创建时间"},{"SRAuditTime","审核时间"},{"SRBackwardness","状态"},{"SRAuditRegistration","审核登记"} });
										dic.Add("ScheduleManagement", new Dictionary<string,string>{ {"SMActivityType","活动类型"},{"SMStartDate","开始日期"},{"SMEndDate","结束日期"},{"SMContent","内容"},{"SMLocality","地点"},{"SMSuperinrtendent","负责人"},{"SMBooth","电话"},{"SMRemarks","备注"} });
										dic.Add("ExpertManagement", new Dictionary<string,string>{ {"EMTechnicalExpertise","技术特长"},{"EMName","姓名"},{"EMChairperson","性别"},{"EMDateOfBirth","出生日期"},{"EMIdNumber","身份证"},{"EMAddress","地址"},{"EMContactNumber","联系电话"} });
										dic.Add("Access", new Dictionary<string,string>{ {"AName","姓名"},{"AAccessTime","访问时间"} });
										dic.Add("aGuideToTheConvenienceOfPeople", new Dictionary<string,string>{ {"GTTCOPCaption","标题"},{"GTTCOPReleaseTime","发布时间"},{"GTTCOPPicture","图片"} });
										dic.Add("FeaturesOfXiangxi", new Dictionary<string,string>{ {"FOXCaption","标题"},{"FOXReleaseTime","发布时间"},{"FOXPicture","图片"} });
										dic.Add("RecommendedTreatment", new Dictionary<string,string>{ {"RTCaption","标题"},{"RTContent","内容"},{"RTTarget","对象"},{"RTProcessingPerson","处理人"},{"RTProcessingDate","处理日期"},{"RTName","姓名"},{"RTIdNumber","身份证"},{"RTBooth","电话"},{"RTCreationTime","创建时间"},{"RTBackwardness","状态"} });
										dic.Add("VillageHistory", new Dictionary<string,string>{ {"VHMenuItem","菜单项"},{"VHMainTitle","主标题"},{"VHSubtitle","副标题"},{"VHPicture","图片"},{"VHAbridge","摘要"} });
										dic.Add("SpecialWork", new Dictionary<string,string>{ {"SWWorkTheme","工作主题"},{"SWJobContent","工作内容"},{"SWStartDate","开始日期"},{"SWEndDate","结束日期"},{"SWBackwardness","状态"},{"SWPhoto","照片"} });
										dic.Add("VideoPointBitInformation", new Dictionary<string,string>{ {"VPBISerialNumber","序号"},{"VPBIMonitorPointName","监控点名称"},{"VPBIMonitoringPointNumber","监控点编号"},{"VPBIAffiliatedOrganization","所属组织"},{"VPBIBelongToTheRegion","所属区域"},{"VPBIPlatform","所属平台"},{"VPBILongitude","经度"},{"VPBILatitude","纬度"},{"VPBIAddress","地址"} });
										dic.Add("EmploymentAssistance", new Dictionary<string,string>{ {"EAPersonalNumber","个人编号"},{"EAName","姓名"},{"EAIdCard","身份证号码"},{"EAChairperson","性别"},{"EACivilization","民族"},{"EAAge","年龄"},{"EADegreeOfEducation","文化程度"},{"EANatureOfHouseholdRegistration","户口性质"},{"EAWhetherOrNotDisability","是否残疾"},{"EATrainingWill","培训意愿"},{"EACommonModeOfContact","联系方式"},{"EATypeOfPersonnel","人员类型"},{"EAFormOfEmployment","就业形式"},{"EAContent1","内容1"},{"EAContent2","内容2"},{"EAContent3","内容3"},{"EAContent4","内容4"} });
										dic.Add("CriticalHousingCrisis", new Dictionary<string,string>{ {"CHCOwner","所有权人"},{"CHCHouseSeat","房屋座落"},{"CHCRealEstateCertificateArea","房产证面积"},{"CHCLandCertificateArea","土地证面积"},{"CHCSurveyingArea","测绘面积"},{"CHCMappingArea","测绘增补面积"},{"CHCResettlementArea","安置面积"},{"CHCSignatureTime","签字时间"},{"CHCRoomTime","交房时间"},{"CHCAmountOfCompensation","补偿金额"},{"CHCContactNumber","联系电话"},{"CHCCurrentAddress","现居住地址"} });
										dic.Add("IndustrialParkHousingReceipts", new Dictionary<string,string>{ {"IPHRBuilding","@厂房楼栋"},{"IPHRStartTime","开始时间"},{"IPHREndTime","结束时间"},{"IPHRAmountOfPayment","付款金额"} });
										dic.Add("DemandCollection", new Dictionary<string,string>{ {"DCWhatDoYouNeed","您需要什么内容"},{"DCExpectedDeliveryTime","期望交付时间"},{"DCYourName","您的姓名"},{"DCYourContactInformation","您的联系方式"} });
										dic.Add("InformationManagementOfPartyOrganization", new Dictionary<string,string>{ {"IMOPONameOfPartyOrganization","党组织名称"},{"IMOPOPartyOrganizationSecretary","党组织书记"},{"IMOPOPartyOrganizationContacts","党组织联系人"},{"IMOPOContactNumber","联系电话"},{"IMOPOOrganizationCategory","组织类别"},{"IMOPONameOfHigherLevelPartyOrganization","上级党组织名称"} });
										dic.Add("TheObjectOfCare", new Dictionary<string,string>{ {"TOOCName","姓名"},{"TOOCChairperson","性别"},{"TOOCForm","类型"},{"TOOCIdNumber","身份证"},{"TOOCRegisteredResidence","户口所在地"},{"TOOCPermanentResidence","常住地"},{"TOOCBuildingNumber","楼栋号"},{"TOOCUnitNumber","单元号"},{"TOOCDoorNumber","门牌号"} });
										dic.Add("EmploymentModule", new Dictionary<string,string>{ {"EMEmployers","用人单位"},{"EMPost","职位"},{"EMPublisher","发布人"},{"EMJobDescription","职位描述"},{"EMJobResponsibilities","职位职责内容"},{"EMJobRequirements","职位要求内容"},{"EMEntryIntoForceTime","生效时间"},{"EMFailureTime","失效时间"} });
										dic.Add("PartyGroupFormation", new Dictionary<string,string>{ {"PGFPartyOrganization","所属党组织"},{"PGFNameOfaMember","成员姓名"},{"PGFIdCard","身份证号码"},{"PGFCreationTime","创建时间"} });
										dic.Add("PartyMembersActivities", new Dictionary<string,string>{ {"PMAActivityName","活动名称"},{"PMABriefIntroductionOfActivities","活动简介"},{"PMACoverageRange","覆盖范围"},{"PMAActivePhoto","活动照片"} });
										dic.Add("BeautifulCountryside", new Dictionary<string,string>{ {"BCParticularYear","年份"},{"BCMonth","月份"},{"BCCaption","标题"},{"BCPhoto","照片"},{"BCConstructionResults","建设成果"} });
										dic.Add("DrawWaterUpaHill", new Dictionary<string,string>{ {"DWUHParticularYear","年份"},{"DWUHMonth","月份"},{"DWUHCaption","标题"},{"DWUHPhoto","照片"},{"DWUHConstructionResults","建设成果"} });
					                var keypair = dic[fileType]; //commentses.ToDictionary(f => f.column_name, f => f.column_description);
                if (string.IsNullOrEmpty(fileType)) return ;
				else if (fileType == "SocialConditionsAndPublicOpinions") ExcelHelper.ExcelToNewEntityList<SocialConditionsAndPublicOpinions>(keypair, filePath, out errorMsg).ForEach(one=>tx.SocialConditionsAndPublicOpinions.AddOrUpdate(one));
				else if (fileType == "MenuConfiguration") ExcelHelper.ExcelToNewEntityList<MenuConfiguration>(keypair, filePath, out errorMsg).ForEach(one=>tx.MenuConfiguration.AddOrUpdate(one));
				else if (fileType == "RoleMenu") ExcelHelper.ExcelToNewEntityList<RoleMenu>(keypair, filePath, out errorMsg).ForEach(one=>tx.RoleMenu.AddOrUpdate(one));
				else if (fileType == "UserRole") ExcelHelper.ExcelToNewEntityList<UserRole>(keypair, filePath, out errorMsg).ForEach(one=>tx.UserRole.AddOrUpdate(one));
				else if (fileType == "RoleConfiguration") ExcelHelper.ExcelToNewEntityList<RoleConfiguration>(keypair, filePath, out errorMsg).ForEach(one=>tx.RoleConfiguration.AddOrUpdate(one));
				else if (fileType == "UserInformation") ExcelHelper.ExcelToNewEntityList<UserInformation>(keypair, filePath, out errorMsg).ForEach(one=>tx.UserInformation.AddOrUpdate(one));
				else if (fileType == "LogonRecord") ExcelHelper.ExcelToNewEntityList<LogonRecord>(keypair, filePath, out errorMsg).ForEach(one=>tx.LogonRecord.AddOrUpdate(one));
				else if (fileType == "UserMenu") ExcelHelper.ExcelToNewEntityList<UserMenu>(keypair, filePath, out errorMsg).ForEach(one=>tx.UserMenu.AddOrUpdate(one));
				else if (fileType == "InformationManagementOfPartyMembers") ExcelHelper.ExcelToNewEntityList<InformationManagementOfPartyMembers>(keypair, filePath, out errorMsg).ForEach(one=>tx.InformationManagementOfPartyMembers.AddOrUpdate(one));
				else if (fileType == "PartyFeeManagement") ExcelHelper.ExcelToNewEntityList<PartyFeeManagement>(keypair, filePath, out errorMsg).ForEach(one=>tx.PartyFeeManagement.AddOrUpdate(one));
				else if (fileType == "RecordingLectures") ExcelHelper.ExcelToNewEntityList<RecordingLectures>(keypair, filePath, out errorMsg).ForEach(one=>tx.RecordingLectures.AddOrUpdate(one));
				else if (fileType == "ThreeSessions") ExcelHelper.ExcelToNewEntityList<ThreeSessions>(keypair, filePath, out errorMsg).ForEach(one=>tx.ThreeSessions.AddOrUpdate(one));
				else if (fileType == "ThematicStudy") ExcelHelper.ExcelToNewEntityList<ThematicStudy>(keypair, filePath, out errorMsg).ForEach(one=>tx.ThematicStudy.AddOrUpdate(one));
				else if (fileType == "PolicyDocument") ExcelHelper.ExcelToNewEntityList<PolicyDocument>(keypair, filePath, out errorMsg).ForEach(one=>tx.PolicyDocument.AddOrUpdate(one));
				else if (fileType == "PolicyDocumentCategory") ExcelHelper.ExcelToNewEntityList<PolicyDocumentCategory>(keypair, filePath, out errorMsg).ForEach(one=>tx.PolicyDocumentCategory.AddOrUpdate(one));
				else if (fileType == "UnitedFrontObjectDetails") ExcelHelper.ExcelToNewEntityList<UnitedFrontObjectDetails>(keypair, filePath, out errorMsg).ForEach(one=>tx.UnitedFrontObjectDetails.AddOrUpdate(one));
				else if (fileType == "MuslimFoodSubsidies") ExcelHelper.ExcelToNewEntityList<MuslimFoodSubsidies>(keypair, filePath, out errorMsg).ForEach(one=>tx.MuslimFoodSubsidies.AddOrUpdate(one));
				else if (fileType == "ListOfActiveServicemen") ExcelHelper.ExcelToNewEntityList<ListOfActiveServicemen>(keypair, filePath, out errorMsg).ForEach(one=>tx.ListOfActiveServicemen.AddOrUpdate(one));
				else if (fileType == "ListOfRecruits") ExcelHelper.ExcelToNewEntityList<ListOfRecruits>(keypair, filePath, out errorMsg).ForEach(one=>tx.ListOfRecruits.AddOrUpdate(one));
				else if (fileType == "TheCommunistYouthLeague") ExcelHelper.ExcelToNewEntityList<TheCommunistYouthLeague>(keypair, filePath, out errorMsg).ForEach(one=>tx.TheCommunistYouthLeague.AddOrUpdate(one));
				else if (fileType == "KeyPersonnel") ExcelHelper.ExcelToNewEntityList<KeyPersonnel>(keypair, filePath, out errorMsg).ForEach(one=>tx.KeyPersonnel.AddOrUpdate(one));
				else if (fileType == "LetterAndVisit") ExcelHelper.ExcelToNewEntityList<LetterAndVisit>(keypair, filePath, out errorMsg).ForEach(one=>tx.LetterAndVisit.AddOrUpdate(one));
				else if (fileType == "TwoCategoriesOfPersonnel") ExcelHelper.ExcelToNewEntityList<TwoCategoriesOfPersonnel>(keypair, filePath, out errorMsg).ForEach(one=>tx.TwoCategoriesOfPersonnel.AddOrUpdate(one));
				else if (fileType == "Family") ExcelHelper.ExcelToNewEntityList<Family>(keypair, filePath, out errorMsg).ForEach(one=>tx.Family.AddOrUpdate(one));
				else if (fileType == "Investors") ExcelHelper.ExcelToNewEntityList<Investors>(keypair, filePath, out errorMsg).ForEach(one=>tx.Investors.AddOrUpdate(one));
				else if (fileType == "BonusRecord") ExcelHelper.ExcelToNewEntityList<BonusRecord>(keypair, filePath, out errorMsg).ForEach(one=>tx.BonusRecord.AddOrUpdate(one));
				else if (fileType == "Cadre") ExcelHelper.ExcelToNewEntityList<Cadre>(keypair, filePath, out errorMsg).ForEach(one=>tx.Cadre.AddOrUpdate(one));
				else if (fileType == "Militia") ExcelHelper.ExcelToNewEntityList<Militia>(keypair, filePath, out errorMsg).ForEach(one=>tx.Militia.AddOrUpdate(one));
				else if (fileType == "ThreeProductionBuilding") ExcelHelper.ExcelToNewEntityList<ThreeProductionBuilding>(keypair, filePath, out errorMsg).ForEach(one=>tx.ThreeProductionBuilding.AddOrUpdate(one));
				else if (fileType == "Building") ExcelHelper.ExcelToNewEntityList<Building>(keypair, filePath, out errorMsg).ForEach(one=>tx.Building.AddOrUpdate(one));
				else if (fileType == "RentRecord") ExcelHelper.ExcelToNewEntityList<RentRecord>(keypair, filePath, out errorMsg).ForEach(one=>tx.RentRecord.AddOrUpdate(one));
				else if (fileType == "RecordOfElectricityPayment") ExcelHelper.ExcelToNewEntityList<RecordOfElectricityPayment>(keypair, filePath, out errorMsg).ForEach(one=>tx.RecordOfElectricityPayment.AddOrUpdate(one));
				else if (fileType == "WorkLog") ExcelHelper.ExcelToNewEntityList<WorkLog>(keypair, filePath, out errorMsg).ForEach(one=>tx.WorkLog.AddOrUpdate(one));
				else if (fileType == "Advise") ExcelHelper.ExcelToNewEntityList<Advise>(keypair, filePath, out errorMsg).ForEach(one=>tx.Advise.AddOrUpdate(one));
				else if (fileType == "DocumentManagement") ExcelHelper.ExcelToNewEntityList<DocumentManagement>(keypair, filePath, out errorMsg).ForEach(one=>tx.DocumentManagement.AddOrUpdate(one));
				else if (fileType == "Population") ExcelHelper.ExcelToNewEntityList<Population>(keypair, filePath, out errorMsg).ForEach(one=>tx.Population.AddOrUpdate(one));
				else if (fileType == "HouseProperty") ExcelHelper.ExcelToNewEntityList<HouseProperty>(keypair, filePath, out errorMsg).ForEach(one=>tx.HouseProperty.AddOrUpdate(one));
				else if (fileType == "ReimbursementList") ExcelHelper.ExcelToNewEntityList<ReimbursementList>(keypair, filePath, out errorMsg).ForEach(one=>tx.ReimbursementList.AddOrUpdate(one));
				else if (fileType == "MailList") ExcelHelper.ExcelToNewEntityList<MailList>(keypair, filePath, out errorMsg).ForEach(one=>tx.MailList.AddOrUpdate(one));
				else if (fileType == "POI") ExcelHelper.ExcelToNewEntityList<POI>(keypair, filePath, out errorMsg).ForEach(one=>tx.POI.AddOrUpdate(one));
				else if (fileType == "PartyNewsManagement") ExcelHelper.ExcelToNewEntityList<PartyNewsManagement>(keypair, filePath, out errorMsg).ForEach(one=>tx.PartyNewsManagement.AddOrUpdate(one));
				else if (fileType == "Pat") ExcelHelper.ExcelToNewEntityList<Pat>(keypair, filePath, out errorMsg).ForEach(one=>tx.Pat.AddOrUpdate(one));
				else if (fileType == "ActiveInspection") ExcelHelper.ExcelToNewEntityList<ActiveInspection>(keypair, filePath, out errorMsg).ForEach(one=>tx.ActiveInspection.AddOrUpdate(one));
				else if (fileType == "BusinessReservation") ExcelHelper.ExcelToNewEntityList<BusinessReservation>(keypair, filePath, out errorMsg).ForEach(one=>tx.BusinessReservation.AddOrUpdate(one));
				else if (fileType == "SuggestionRecord") ExcelHelper.ExcelToNewEntityList<SuggestionRecord>(keypair, filePath, out errorMsg).ForEach(one=>tx.SuggestionRecord.AddOrUpdate(one));
				else if (fileType == "TheStudyOfPartyStyleAndCleanGovernment") ExcelHelper.ExcelToNewEntityList<TheStudyOfPartyStyleAndCleanGovernment>(keypair, filePath, out errorMsg).ForEach(one=>tx.TheStudyOfPartyStyleAndCleanGovernment.AddOrUpdate(one));
				else if (fileType == "Service") ExcelHelper.ExcelToNewEntityList<Service>(keypair, filePath, out errorMsg).ForEach(one=>tx.Service.AddOrUpdate(one));
				else if (fileType == "SystemConfiguration") ExcelHelper.ExcelToNewEntityList<SystemConfiguration>(keypair, filePath, out errorMsg).ForEach(one=>tx.SystemConfiguration.AddOrUpdate(one));
				else if (fileType == "PartyBuilding") ExcelHelper.ExcelToNewEntityList<PartyBuilding>(keypair, filePath, out errorMsg).ForEach(one=>tx.PartyBuilding.AddOrUpdate(one));
				else if (fileType == "MembershipDuesPaymentManagement") ExcelHelper.ExcelToNewEntityList<MembershipDuesPaymentManagement>(keypair, filePath, out errorMsg).ForEach(one=>tx.MembershipDuesPaymentManagement.AddOrUpdate(one));
				else if (fileType == "ContractManagement") ExcelHelper.ExcelToNewEntityList<ContractManagement>(keypair, filePath, out errorMsg).ForEach(one=>tx.ContractManagement.AddOrUpdate(one));
				else if (fileType == "PersonalInformation") ExcelHelper.ExcelToNewEntityList<PersonalInformation>(keypair, filePath, out errorMsg).ForEach(one=>tx.PersonalInformation.AddOrUpdate(one));
				else if (fileType == "ScheduleWork") ExcelHelper.ExcelToNewEntityList<ScheduleWork>(keypair, filePath, out errorMsg).ForEach(one=>tx.ScheduleWork.AddOrUpdate(one));
				else if (fileType == "PartyBuildingProject") ExcelHelper.ExcelToNewEntityList<PartyBuildingProject>(keypair, filePath, out errorMsg).ForEach(one=>tx.PartyBuildingProject.AddOrUpdate(one));
				else if (fileType == "GuideToAffairs") ExcelHelper.ExcelToNewEntityList<GuideToAffairs>(keypair, filePath, out errorMsg).ForEach(one=>tx.GuideToAffairs.AddOrUpdate(one));
				else if (fileType == "GuideToPartyAffairs") ExcelHelper.ExcelToNewEntityList<GuideToPartyAffairs>(keypair, filePath, out errorMsg).ForEach(one=>tx.GuideToPartyAffairs.AddOrUpdate(one));
				else if (fileType == "BusinessManagement") ExcelHelper.ExcelToNewEntityList<BusinessManagement>(keypair, filePath, out errorMsg).ForEach(one=>tx.BusinessManagement.AddOrUpdate(one));
				else if (fileType == "ChildrensMedicalInsuranceRegistration") ExcelHelper.ExcelToNewEntityList<ChildrensMedicalInsuranceRegistration>(keypair, filePath, out errorMsg).ForEach(one=>tx.ChildrensMedicalInsuranceRegistration.AddOrUpdate(one));
				else if (fileType == "RuralMedicalTreatment") ExcelHelper.ExcelToNewEntityList<RuralMedicalTreatment>(keypair, filePath, out errorMsg).ForEach(one=>tx.RuralMedicalTreatment.AddOrUpdate(one));
				else if (fileType == "WelfareGrant") ExcelHelper.ExcelToNewEntityList<WelfareGrant>(keypair, filePath, out errorMsg).ForEach(one=>tx.WelfareGrant.AddOrUpdate(one));
				else if (fileType == "ServiceReservation") ExcelHelper.ExcelToNewEntityList<ServiceReservation>(keypair, filePath, out errorMsg).ForEach(one=>tx.ServiceReservation.AddOrUpdate(one));
				else if (fileType == "ScheduleManagement") ExcelHelper.ExcelToNewEntityList<ScheduleManagement>(keypair, filePath, out errorMsg).ForEach(one=>tx.ScheduleManagement.AddOrUpdate(one));
				else if (fileType == "ExpertManagement") ExcelHelper.ExcelToNewEntityList<ExpertManagement>(keypair, filePath, out errorMsg).ForEach(one=>tx.ExpertManagement.AddOrUpdate(one));
				else if (fileType == "Access") ExcelHelper.ExcelToNewEntityList<Access>(keypair, filePath, out errorMsg).ForEach(one=>tx.Access.AddOrUpdate(one));
				else if (fileType == "aGuideToTheConvenienceOfPeople") ExcelHelper.ExcelToNewEntityList<aGuideToTheConvenienceOfPeople>(keypair, filePath, out errorMsg).ForEach(one=>tx.aGuideToTheConvenienceOfPeople.AddOrUpdate(one));
				else if (fileType == "FeaturesOfXiangxi") ExcelHelper.ExcelToNewEntityList<FeaturesOfXiangxi>(keypair, filePath, out errorMsg).ForEach(one=>tx.FeaturesOfXiangxi.AddOrUpdate(one));
				else if (fileType == "RecommendedTreatment") ExcelHelper.ExcelToNewEntityList<RecommendedTreatment>(keypair, filePath, out errorMsg).ForEach(one=>tx.RecommendedTreatment.AddOrUpdate(one));
				else if (fileType == "VillageHistory") ExcelHelper.ExcelToNewEntityList<VillageHistory>(keypair, filePath, out errorMsg).ForEach(one=>tx.VillageHistory.AddOrUpdate(one));
				else if (fileType == "SpecialWork") ExcelHelper.ExcelToNewEntityList<SpecialWork>(keypair, filePath, out errorMsg).ForEach(one=>tx.SpecialWork.AddOrUpdate(one));
				else if (fileType == "VideoPointBitInformation") ExcelHelper.ExcelToNewEntityList<VideoPointBitInformation>(keypair, filePath, out errorMsg).ForEach(one=>tx.VideoPointBitInformation.AddOrUpdate(one));
				else if (fileType == "EmploymentAssistance") ExcelHelper.ExcelToNewEntityList<EmploymentAssistance>(keypair, filePath, out errorMsg).ForEach(one=>tx.EmploymentAssistance.AddOrUpdate(one));
				else if (fileType == "CriticalHousingCrisis") ExcelHelper.ExcelToNewEntityList<CriticalHousingCrisis>(keypair, filePath, out errorMsg).ForEach(one=>tx.CriticalHousingCrisis.AddOrUpdate(one));
				else if (fileType == "IndustrialParkHousingReceipts") ExcelHelper.ExcelToNewEntityList<IndustrialParkHousingReceipts>(keypair, filePath, out errorMsg).ForEach(one=>tx.IndustrialParkHousingReceipts.AddOrUpdate(one));
				else if (fileType == "DemandCollection") ExcelHelper.ExcelToNewEntityList<DemandCollection>(keypair, filePath, out errorMsg).ForEach(one=>tx.DemandCollection.AddOrUpdate(one));
				else if (fileType == "InformationManagementOfPartyOrganization") ExcelHelper.ExcelToNewEntityList<InformationManagementOfPartyOrganization>(keypair, filePath, out errorMsg).ForEach(one=>tx.InformationManagementOfPartyOrganization.AddOrUpdate(one));
				else if (fileType == "TheObjectOfCare") ExcelHelper.ExcelToNewEntityList<TheObjectOfCare>(keypair, filePath, out errorMsg).ForEach(one=>tx.TheObjectOfCare.AddOrUpdate(one));
				else if (fileType == "EmploymentModule") ExcelHelper.ExcelToNewEntityList<EmploymentModule>(keypair, filePath, out errorMsg).ForEach(one=>tx.EmploymentModule.AddOrUpdate(one));
				else if (fileType == "PartyGroupFormation") ExcelHelper.ExcelToNewEntityList<PartyGroupFormation>(keypair, filePath, out errorMsg).ForEach(one=>tx.PartyGroupFormation.AddOrUpdate(one));
				else if (fileType == "PartyMembersActivities") ExcelHelper.ExcelToNewEntityList<PartyMembersActivities>(keypair, filePath, out errorMsg).ForEach(one=>tx.PartyMembersActivities.AddOrUpdate(one));
				else if (fileType == "BeautifulCountryside") ExcelHelper.ExcelToNewEntityList<BeautifulCountryside>(keypair, filePath, out errorMsg).ForEach(one=>tx.BeautifulCountryside.AddOrUpdate(one));
				else if (fileType == "DrawWaterUpaHill") ExcelHelper.ExcelToNewEntityList<DrawWaterUpaHill>(keypair, filePath, out errorMsg).ForEach(one=>tx.DrawWaterUpaHill.AddOrUpdate(one));					tx.SaveChanges();
            }
		}
    }
}
