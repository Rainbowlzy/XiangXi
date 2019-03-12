

/* ------------------------------------------------------------ *
 * 此文件由生成器引擎根据既有规则生成，所有手工的更改将会被覆盖
 * 生成时间：03/12/2019 13:34:39
 * 生成版本：03/12/2019 13:33:51 
 * 作者：路正遥
 * ------------------------------------------------------------ */
using System;

namespace XiangXi.Evaluators 
{
    /// <summary>
    /// 菜单配置 搜索条件实体模型
    /// </summary>
    public class MenuConfigurationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string MCTitle { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string MCLink { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string MCPicture { get; set; }
        /// <summary>
        /// 父级标题
        /// </summary>
        public string MCParentTitle { get; set; }
        /// <summary>
        /// 菜单类型
        /// </summary>
        public string MCMenuType { get; set; }

        /// <summary>
        /// 最小顺序
        /// </summary>
        public int? MinMCOrder { get; set; }

        /// <summary>
        /// 最大顺序
        /// </summary>
        public int? MaxMCOrder { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string MCDisplayName { get; set; }

    }
    /// <summary>
    /// 角色菜单 搜索条件实体模型
    /// </summary>
    public class RoleMenuSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RMRoleName { get; set; }
        /// <summary>
        /// 菜单标题
        /// </summary>
        public string RMMenuTitle { get; set; }

    }
    /// <summary>
    /// 用户角色 搜索条件实体模型
    /// </summary>
    public class UserRolesSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string URRoleName { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string URLoginName { get; set; }

    }
    /// <summary>
    /// 角色配置 搜索条件实体模型
    /// </summary>
    public class RoleConfigurationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RCRoleName { get; set; }
        /// <summary>
        /// 所属组织
        /// </summary>
        public string RCAffiliatedOrganization { get; set; }

    }
    /// <summary>
    /// 用户信息 搜索条件实体模型
    /// </summary>
    public class UserInformationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string UILoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string UIPassword { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UICustomerType { get; set; }
        /// <summary>
        /// 用户级别
        /// </summary>
        public string UIUserLevel { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string[] UIState { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string UINickname { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string UIRealName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string UIHeadPortrait { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public string UISubordinateDepartments { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string UITelephone { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string UIPhoto { get; set; }

    }
    /// <summary>
    /// 登录记录 搜索条件实体模型
    /// </summary>
    public class LoginRecordSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LRLoginName { get; set; }

        /// <summary>
        /// 开始登录时间
        /// </summary>
        public DateTime? FromLRLoginTime { get; set; }

        /// <summary>
        /// 结束登录时间
        /// </summary>
        public DateTime? ToLRLoginTime { get; set; }

    }
    /// <summary>
    /// 用户菜单 搜索条件实体模型
    /// </summary>
    public class UserMenuSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string UMLoginName { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string UMTitle { get; set; }

    }
    /// <summary>
    /// 党员信息管理 搜索条件实体模型
    /// </summary>
    public class InformationManagementOfPartyMembersSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string IMOPMFullName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IMOPMIdNumber { get; set; }

        /// <summary>
        /// 开始出生日期
        /// </summary>
        public DateTime? FromIMOPMDateOfBirth { get; set; }

        /// <summary>
        /// 结束出生日期
        /// </summary>
        public DateTime? ToIMOPMDateOfBirth { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string IMOPMGender { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string IMOPMNation { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string IMOPMEducation { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string IMOPMCategory { get; set; }
        /// <summary>
        /// 所在党支部
        /// </summary>
        public string IMOPMPartyBranch { get; set; }

        /// <summary>
        /// 开始入党日期
        /// </summary>
        public DateTime? FromIMOPMDateOfJoiningTheParty { get; set; }

        /// <summary>
        /// 结束入党日期
        /// </summary>
        public DateTime? ToIMOPMDateOfJoiningTheParty { get; set; }

        /// <summary>
        /// 开始转正日期
        /// </summary>
        public DateTime? FromIMOPMDateOfCorrection { get; set; }

        /// <summary>
        /// 结束转正日期
        /// </summary>
        public DateTime? ToIMOPMDateOfCorrection { get; set; }
        /// <summary>
        /// 工作岗位
        /// </summary>
        public string IMOPMPost { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string IMOPMContactNumber { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string IMOPMFamilyAddress { get; set; }

    }
    /// <summary>
    /// 党费管理 搜索条件实体模型
    /// </summary>
    public class PartyFeeManagementSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string PFMFullName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string PFMIdNumber { get; set; }

        /// <summary>
        /// 最小年龄
        /// </summary>
        public int? MinPFMAge { get; set; }

        /// <summary>
        /// 最大年龄
        /// </summary>
        public int? MaxPFMAge { get; set; }
        /// <summary>
        /// 所在党支部
        /// </summary>
        public string PFMPartyBranch { get; set; }
        /// <summary>
        /// 月收入
        /// </summary>
        public string PFMMonthlyIncome { get; set; }
        /// <summary>
        /// 月党费
        /// </summary>
        public string PFMMonthlyPartyMembershipFee { get; set; }

    }
    /// <summary>
    /// 党课记录 搜索条件实体模型
    /// </summary>
    public class PartyRecordSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string PRFullName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string PRIdCardNo { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string PRCourseTitle { get; set; }
        /// <summary>
        /// 课程摘要
        /// </summary>
        public string PRCourseSummary { get; set; }
        /// <summary>
        /// 学习情况
        /// </summary>
        public string PRLearningSituation { get; set; }

        /// <summary>
        /// 开始课程时间
        /// </summary>
        public DateTime? FromPRCourseTime { get; set; }

        /// <summary>
        /// 结束课程时间
        /// </summary>
        public DateTime? ToPRCourseTime { get; set; }

    }
    /// <summary>
    /// 三会一课 搜索条件实体模型
    /// </summary>
    public class ThreeSessionsSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }


        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? FromTSDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? ToTSDate { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public string TSTheme { get; set; }
        /// <summary>
        /// 参与人员
        /// </summary>
        public string TSParticipant { get; set; }
        /// <summary>
        /// 与会人数
        /// </summary>
        public string TSNumberOfParticipants { get; set; }
        /// <summary>
        /// 主持人
        /// </summary>
        public string TSHost { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string TSContent { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string TSType { get; set; }

    }
    /// <summary>
    /// 专题学习 搜索条件实体模型
    /// </summary>
    public class ThematicLearningSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }


        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? FromTLDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? ToTLDate { get; set; }
        /// <summary>
        /// 专题内容
        /// </summary>
        public string TLThematicContent { get; set; }
        /// <summary>
        /// 参与人员
        /// </summary>
        public string TLParticipant { get; set; }
        /// <summary>
        /// 与会人数
        /// </summary>
        public string TLNumberOfParticipants { get; set; }
        /// <summary>
        /// 主持人
        /// </summary>
        public string TLHost { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string TLContent { get; set; }

    }
    /// <summary>
    /// 政策文件 搜索条件实体模型
    /// </summary>
    public class PolicyDocumentSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 文件号
        /// </summary>
        public string PDFileNumber { get; set; }
        /// <summary>
        /// @政策文件类别
        /// </summary>
        public string PDCategoriesOfPolicyDocuments { get; set; }
        /// <summary>
        /// 专文件主题
        /// </summary>
        public string PDThemeOfSpecialDocument { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string PDContent { get; set; }
        /// <summary>
        /// 上传文件
        /// </summary>
        public string PDUploadFiles { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public string PDParticularYear { get; set; }

    }
    /// <summary>
    /// 政策文件类别 搜索条件实体模型
    /// </summary>
    public class CategoriesOfPolicyDocumentsSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string COPDCategoryName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string COPDDescribe { get; set; }

    }
    /// <summary>
    /// 现役军人名单 搜索条件实体模型
    /// </summary>
    public class ListOfActiveServicemenSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string LOASFullName { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string LOASNation { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string LOASFamilyAddress { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string LOASIdCardNo { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string LOASContactInformation { get; set; }
        /// <summary>
        /// 家庭情况
        /// </summary>
        public string LOASFamilySituation { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string LOASRemarks { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string LOASGender { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public string LOASDateOfBirth { get; set; }
        /// <summary>
        /// 文化程度
        /// </summary>
        public string LOASDegreeOfEducation { get; set; }
        /// <summary>
        /// 户口所在地
        /// </summary>
        public string LOASRegisteredResidence { get; set; }

    }
    /// <summary>
    /// 征兵对象名单 搜索条件实体模型
    /// </summary>
    public class ListOfConscriptsSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string LOCFullName { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public string LOCDateOfBirth { get; set; }
        /// <summary>
        /// 文化程度
        /// </summary>
        public string LOCDegreeOfEducation { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string LOCPoliticalOutlook { get; set; }
        /// <summary>
        /// 户口性质
        /// </summary>
        public string LOCAccountCharacter { get; set; }
        /// <summary>
        /// 毕业院校
        /// </summary>
        public string LOCUniversityOneIsGraduatedFrom { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string LOCContactInformation { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string LOCIdCardNo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string LOCRemarks { get; set; }

    }
    /// <summary>
    /// 共青团 搜索条件实体模型
    /// </summary>
    public class CommunistYouthLeagueSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string CYLSerialNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string CYLFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string CYLGender { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public string CYLDateOfBirth { get; set; }

        /// <summary>
        /// 开始志愿时间
        /// </summary>
        public DateTime? FromCYLVolunteerTime { get; set; }

        /// <summary>
        /// 结束志愿时间
        /// </summary>
        public DateTime? ToCYLVolunteerTime { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string CYLNativePlace { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string CYLEducation { get; set; }
        /// <summary>
        /// 入团年月
        /// </summary>
        public string CYLJoiningTheLeagueYear { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string CYLRemarks { get; set; }

    }
    /// <summary>
    /// 重点人员 搜索条件实体模型
    /// </summary>
    public class KeyPersonnelSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string KPSerialNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string KPFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string KPGender { get; set; }
        /// <summary>
        /// 居住地
        /// </summary>
        public string KPPlaceOfResidence { get; set; }
        /// <summary>
        /// 户籍地
        /// </summary>
        public string KPDomicile { get; set; }
        /// <summary>
        /// 事由
        /// </summary>
        public string KPCause { get; set; }
        /// <summary>
        /// 目前状态
        /// </summary>
        public string[] KPCurrentState { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string KPContactNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string KPRemarks { get; set; }

    }
    /// <summary>
    /// 信访 搜索条件实体模型
    /// </summary>
    public class LettersAndVisitsSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string LAVSerialNumber { get; set; }
        /// <summary>
        /// 投诉事件
        /// </summary>
        public string LAVComplaints { get; set; }
        /// <summary>
        /// 投诉地点
        /// </summary>
        public string LAVPlaceOfComplaint { get; set; }
        /// <summary>
        /// 办理结果
        /// </summary>
        public string LAVHandlingResult { get; set; }

    }
    /// <summary>
    /// 两类人员 搜索条件实体模型
    /// </summary>
    public class TheTwoCategoryOfPersonnelSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 所在社区
        /// </summary>
        public string TTCOPLocalCommunity { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string TTCOPFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string TTCOPGender { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string TTCOPIdCardNo { get; set; }
        /// <summary>
        /// 罪名
        /// </summary>
        public string TTCOPCharge { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string TTCOPFamilyAddress { get; set; }

    }
    /// <summary>
    /// 家庭 搜索条件实体模型
    /// </summary>
    public class FamilySearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 家庭组织名称
        /// </summary>
        public string FNameOfFamilyOrganization { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FFullName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string FIdCardNo { get; set; }
        /// <summary>
        /// 新生儿姓名
        /// </summary>
        public string FNameOfNewborn { get; set; }
        /// <summary>
        /// 死亡证明
        /// </summary>
        public string FDeathCertificate { get; set; }
        /// <summary>
        /// 居住地
        /// </summary>
        public string FPlaceOfResidence { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string FContactInformation { get; set; }

    }
    /// <summary>
    /// 股民 搜索条件实体模型
    /// </summary>
    public class InvestorsSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string ISerialNumber { get; set; }
        /// <summary>
        /// 户编号
        /// </summary>
        public string IHouseholdNumber { get; set; }
        /// <summary>
        /// 股权证编号
        /// </summary>
        public string IEquityCertificateNumber { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IIdCardNo { get; set; }
        /// <summary>
        /// 户主
        /// </summary>
        public string IaHouseholder { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string IFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string IGender { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public string IDateOfBirth { get; set; }
        /// <summary>
        /// 周岁
        /// </summary>
        public string IOneYearOld { get; set; }
        /// <summary>
        /// 基本股
        /// </summary>
        public string IBasicStock { get; set; }
        /// <summary>
        /// 应得股份股
        /// </summary>
        public string IDeservedShare { get; set; }
        /// <summary>
        /// 户合计股数
        /// </summary>
        public string ITotalNumberOfSharesInaHousehold { get; set; }
        /// <summary>
        /// 确认签名
        /// </summary>
        public string IWitnessing { get; set; }
        /// <summary>
        /// 配股说明
        /// </summary>
        public string IRightsIssue { get; set; }
        /// <summary>
        /// 统计主题1
        /// </summary>
        public string IStatisticalTopic1 { get; set; }

    }
    /// <summary>
    /// 分红记录 搜索条件实体模型
    /// </summary>
    public class BonusRecordSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string BRFullName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string BRIdCardNo { get; set; }
        /// <summary>
        /// 股份类型
        /// </summary>
        public string BRShareType { get; set; }
        /// <summary>
        /// 股票占比
        /// </summary>
        public string BRShareRatio { get; set; }

        /// <summary>
        /// 最小发放金额
        /// </summary>
        public decimal? MinBRPaymentAmount { get; set; }

        /// <summary>
        /// 最大发放金额
        /// </summary>
        public decimal? MaxBRPaymentAmount { get; set; }

        /// <summary>
        /// 开始发放时间
        /// </summary>
        public DateTime? FromBRPaymentTime { get; set; }

        /// <summary>
        /// 结束发放时间
        /// </summary>
        public DateTime? ToBRPaymentTime { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string BRPersonInCharge { get; set; }
        /// <summary>
        /// 负责人联系方式
        /// </summary>
        public string BRContactInformationOfPersonInCharge { get; set; }

    }
    /// <summary>
    /// 干部 搜索条件实体模型
    /// </summary>
    public class CadreSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string CFullName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string CIdCardNo { get; set; }
        /// <summary>
        /// 上级领导
        /// </summary>
        public string CSuperiorLeader { get; set; }
        /// <summary>
        /// 所属支部
        /// </summary>
        public string CSubordinateBranch { get; set; }
        /// <summary>
        /// 劳模
        /// </summary>
        public string CModelWorker { get; set; }
        /// <summary>
        /// 干部类型
        /// </summary>
        public string CTypesOfCadres { get; set; }

    }
    /// <summary>
    /// 民兵 搜索条件实体模型
    /// </summary>
    public class MilitiaSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string MFullName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string MIdCardNo { get; set; }
        /// <summary>
        /// 上级领导
        /// </summary>
        public string MSuperiorLeader { get; set; }
        /// <summary>
        /// 所属番号
        /// </summary>
        public string MDesignation { get; set; }
        /// <summary>
        /// 民兵类型
        /// </summary>
        public string MMilitiaType { get; set; }

    }
    /// <summary>
    /// 统战民兵 搜索条件实体模型
    /// </summary>
    public class UnitedFrontMilitiaSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string UFMFullName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string UFMIdCardNo { get; set; }
        /// <summary>
        /// 上级领导
        /// </summary>
        public string UFMSuperiorLeader { get; set; }
        /// <summary>
        /// 所属番号
        /// </summary>
        public string UFMDesignation { get; set; }
        /// <summary>
        /// 民兵类型
        /// </summary>
        public string UFMMilitiaType { get; set; }

    }
    /// <summary>
    /// 厂房楼栋 搜索条件实体模型
    /// </summary>
    public class FactoryBuildingSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 工业园名称
        /// </summary>
        public string FBNameOfIndustrialPark { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public string FBSerialNumber { get; set; }
        /// <summary>
        /// 承租户
        /// </summary>
        public string FBTenant { get; set; }
        /// <summary>
        /// 起止
        /// </summary>
        public string FBStartStop { get; set; }

        /// <summary>
        /// 最小承租面积
        /// </summary>
        public int? MinFBLesseeArea { get; set; }

        /// <summary>
        /// 最大承租面积
        /// </summary>
        public int? MaxFBLesseeArea { get; set; }
        /// <summary>
        /// 押金
        /// </summary>
        public string FBDeposit { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public string FBUnitPrice { get; set; }
        /// <summary>
        /// 月租金
        /// </summary>
        public string FBMonthlyRent { get; set; }
        /// <summary>
        /// 年租金
        /// </summary>
        public string FBAnnualRent { get; set; }
        /// <summary>
        /// 租凭单位性质
        /// </summary>
        public string FBCharteredUnitNature { get; set; }
        /// <summary>
        /// 环保手续
        /// </summary>
        public string FBEnvironmentalProtectionProcedures { get; set; }

        /// <summary>
        /// 最小建筑面积
        /// </summary>
        public int? MinFBBuiltupArea { get; set; }

        /// <summary>
        /// 最大建筑面积
        /// </summary>
        public int? MaxFBBuiltupArea { get; set; }

        /// <summary>
        /// 开始开始时间
        /// </summary>
        public DateTime? FromFBStartTime { get; set; }

        /// <summary>
        /// 结束开始时间
        /// </summary>
        public DateTime? ToFBStartTime { get; set; }

        /// <summary>
        /// 开始结束时间
        /// </summary>
        public DateTime? FromFBEndingTime { get; set; }

        /// <summary>
        /// 结束结束时间
        /// </summary>
        public DateTime? ToFBEndingTime { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string FBContacts { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string FBContactNumber { get; set; }
        /// <summary>
        /// 审批文件
        /// </summary>
        public string FBApprovalDocument { get; set; }
        /// <summary>
        /// 楼号
        /// </summary>
        public string FBBuildingNumber { get; set; }
        /// <summary>
        /// 单元号
        /// </summary>
        public string FBUnitNumber { get; set; }
        /// <summary>
        /// 门牌号
        /// </summary>
        public string FBHouseNumber { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string FBPersonInCharge { get; set; }
        /// <summary>
        /// 负责人联系方式
        /// </summary>
        public string FBContactInformationOfPersonInCharge { get; set; }
        /// <summary>
        /// 范围
        /// </summary>
        public string FBRange { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string FBRemarks { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string FBAddress { get; set; }

    }
    /// <summary>
    /// 收租记录 搜索条件实体模型
    /// </summary>
    public class RentCollectionRecordsSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string RCREnterpriseName { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string RCRPersonInCharge { get; set; }
        /// <summary>
        /// 负责人电话
        /// </summary>
        public string RCRTelephoneCallsFromThePersonInCharge { get; set; }

        /// <summary>
        /// 最小付款金额
        /// </summary>
        public decimal? MinRCRPaymentAmount { get; set; }

        /// <summary>
        /// 最大付款金额
        /// </summary>
        public decimal? MaxRCRPaymentAmount { get; set; }
        /// <summary>
        /// 收款人
        /// </summary>
        public string RCRPayee { get; set; }
        /// <summary>
        /// 收款人电话
        /// </summary>
        public string RCRCashiersTelephone { get; set; }

        /// <summary>
        /// 最小收款金额
        /// </summary>
        public decimal? MinRCRAmountCollected { get; set; }

        /// <summary>
        /// 最大收款金额
        /// </summary>
        public decimal? MaxRCRAmountCollected { get; set; }

        /// <summary>
        /// 开始收款时间
        /// </summary>
        public DateTime? FromRCRCollectionTime { get; set; }

        /// <summary>
        /// 结束收款时间
        /// </summary>
        public DateTime? ToRCRCollectionTime { get; set; }

        /// <summary>
        /// 开始应收款时间
        /// </summary>
        public DateTime? FromRCRTimeOfReceivables { get; set; }

        /// <summary>
        /// 结束应收款时间
        /// </summary>
        public DateTime? ToRCRTimeOfReceivables { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string RCRRemarks { get; set; }
        /// <summary>
        /// 工业园名称
        /// </summary>
        public string RCRNameOfIndustrialPark { get; set; }

    }
    /// <summary>
    /// 电费缴纳记录 搜索条件实体模型
    /// </summary>
    public class ElectricityChargePaymentRecordSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string ECPREnterpriseName { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string ECPRPersonInCharge { get; set; }
        /// <summary>
        /// 负责人电话
        /// </summary>
        public string ECPRTelephoneCallsFromThePersonInCharge { get; set; }

        /// <summary>
        /// 最小付款金额
        /// </summary>
        public decimal? MinECPRPaymentAmount { get; set; }

        /// <summary>
        /// 最大付款金额
        /// </summary>
        public decimal? MaxECPRPaymentAmount { get; set; }
        /// <summary>
        /// 收款人
        /// </summary>
        public string ECPRPayee { get; set; }
        /// <summary>
        /// 收款人电话
        /// </summary>
        public string ECPRCashiersTelephone { get; set; }

        /// <summary>
        /// 最小收款金额
        /// </summary>
        public decimal? MinECPRAmountCollected { get; set; }

        /// <summary>
        /// 最大收款金额
        /// </summary>
        public decimal? MaxECPRAmountCollected { get; set; }

        /// <summary>
        /// 开始收款时间
        /// </summary>
        public DateTime? FromECPRCollectionTime { get; set; }

        /// <summary>
        /// 结束收款时间
        /// </summary>
        public DateTime? ToECPRCollectionTime { get; set; }

        /// <summary>
        /// 开始应收款时间
        /// </summary>
        public DateTime? FromECPRTimeOfReceivables { get; set; }

        /// <summary>
        /// 结束应收款时间
        /// </summary>
        public DateTime? ToECPRTimeOfReceivables { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string ECPRRemarks { get; set; }

    }
    /// <summary>
    /// 工作日志 搜索条件实体模型
    /// </summary>
    public class JobDiarySearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string JDSerialNumber { get; set; }
        /// <summary>
        /// 条线
        /// </summary>
        public string JDStripe { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string JDPersonInCharge { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? FromJDDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? ToJDDate { get; set; }
        /// <summary>
        /// 办理事项
        /// </summary>
        public string JDProcessingMatters { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public string JDIsItFinished { get; set; }

        /// <summary>
        /// 开始完成时间
        /// </summary>
        public DateTime? FromJDCompletionTime { get; set; }

        /// <summary>
        /// 结束完成时间
        /// </summary>
        public DateTime? ToJDCompletionTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string JDRemarks { get; set; }

    }
    /// <summary>
    /// 通知 搜索条件实体模型
    /// </summary>
    public class NoticeSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string NTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string NContent { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string NAuthor { get; set; }

        /// <summary>
        /// 开始通知发送日期
        /// </summary>
        public DateTime? FromNNotificationOfDateOfDispatch { get; set; }

        /// <summary>
        /// 结束通知发送日期
        /// </summary>
        public DateTime? ToNNotificationOfDateOfDispatch { get; set; }
        /// <summary>
        /// 通知发送对象
        /// </summary>
        public string NNotificationSenderObject { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string NRemarks { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string NAbstract { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string NPicture { get; set; }

    }
    /// <summary>
    /// 文档管理 搜索条件实体模型
    /// </summary>
    public class DocumentManagementSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string DMTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string DMContent { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string DMAuthor { get; set; }
        /// <summary>
        /// 原件图片
        /// </summary>
        public string DMOriginalPicture { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string DMRemarks { get; set; }

    }
    /// <summary>
    /// 人口 搜索条件实体模型
    /// </summary>
    public class PopulationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 公民身份号码
        /// </summary>
        public string PCitizenshipNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string PGender { get; set; }

        /// <summary>
        /// 开始出生日期
        /// </summary>
        public DateTime? FromPDateOfBirth { get; set; }

        /// <summary>
        /// 结束出生日期
        /// </summary>
        public DateTime? ToPDateOfBirth { get; set; }
        /// <summary>
        /// 居村委会
        /// </summary>
        public string PNeighborhoodVillageCommittee { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string PAddress { get; set; }

        /// <summary>
        /// 最小年龄
        /// </summary>
        public int? MinPAge { get; set; }

        /// <summary>
        /// 最大年龄
        /// </summary>
        public int? MaxPAge { get; set; }

    }
    /// <summary>
    /// 新生儿 搜索条件实体模型
    /// </summary>
    public class NewbornSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 公民身份号码
        /// </summary>
        public string NCitizenshipNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string NGender { get; set; }

        /// <summary>
        /// 开始出生日期
        /// </summary>
        public DateTime? FromNDateOfBirth { get; set; }

        /// <summary>
        /// 结束出生日期
        /// </summary>
        public DateTime? ToNDateOfBirth { get; set; }
        /// <summary>
        /// 居村委会
        /// </summary>
        public string NNeighborhoodVillageCommittee { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string NAddress { get; set; }

        /// <summary>
        /// 最小年龄
        /// </summary>
        public int? MinNAge { get; set; }

        /// <summary>
        /// 最大年龄
        /// </summary>
        public int? MaxNAge { get; set; }

    }
    /// <summary>
    /// 房产 搜索条件实体模型
    /// </summary>
    public class HousePropertySearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string HPId { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string HPAddress { get; set; }
        /// <summary>
        /// 楼栋号
        /// </summary>
        public string HPBuildingNumber { get; set; }
        /// <summary>
        /// 单元号
        /// </summary>
        public string HPUnitNumber { get; set; }
        /// <summary>
        /// 门牌号
        /// </summary>
        public string HPHouseNumber { get; set; }

    }
    /// <summary>
    /// 报销清单 搜索条件实体模型
    /// </summary>
    public class ReimbursementListSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string RLFullName { get; set; }
        /// <summary>
        /// 出发位置
        /// </summary>
        public string RLStartingPosition { get; set; }
        /// <summary>
        /// 目的地位置
        /// </summary>
        public string RLDestinationLocation { get; set; }
        /// <summary>
        /// 交通费
        /// </summary>
        public string RLTrafficExpense { get; set; }
        /// <summary>
        /// 住宿费
        /// </summary>
        public string RLHotelExpense { get; set; }
        /// <summary>
        /// 住勤补贴
        /// </summary>
        public string RLAccommodationAllowance { get; set; }
        /// <summary>
        /// 公交费
        /// </summary>
        public string RLBusFare { get; set; }

        /// <summary>
        /// 开始报销日期
        /// </summary>
        public DateTime? FromRLDateOfReimbursement { get; set; }

        /// <summary>
        /// 结束报销日期
        /// </summary>
        public DateTime? ToRLDateOfReimbursement { get; set; }

    }
    /// <summary>
    /// 通讯录 搜索条件实体模型
    /// </summary>
    public class MailListSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string MLOrganizationName { get; set; }
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string MLPersonnelName { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string MLId { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string MLGender { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string MLTelephone { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string MLMobilePhone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string MLMailbox { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string MLPosition { get; set; }
        /// <summary>
        /// 上级领导
        /// </summary>
        public string MLSuperiorLeader { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string MLQq { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public string MLWechat { get; set; }

    }
    /// <summary>
    /// Poi 搜索条件实体模型
    /// </summary>
    public class PoiSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string PAddress { get; set; }

    }
    /// <summary>
    /// 党建要闻管理 搜索条件实体模型
    /// </summary>
    public class ManagementOfPartyBuildingNewsSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string MOPBNTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string MOPBNContent { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string MOPBNAuthor { get; set; }

        /// <summary>
        /// 开始发布时间
        /// </summary>
        public DateTime? FromMOPBNReleaseTime { get; set; }

        /// <summary>
        /// 结束发布时间
        /// </summary>
        public DateTime? ToMOPBNReleaseTime { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string MOPBNCategory { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string MOPBNPicture { get; set; }

    }
    /// <summary>
    /// 随手拍 搜索条件实体模型
    /// </summary>
    public class FreeToShootSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string FTSContent { get; set; }
        /// <summary>
        /// 设备
        /// </summary>
        public string FTSEquipment { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string FTSUserId { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string FTSPhoto { get; set; }

        /// <summary>
        /// 开始拍照时间
        /// </summary>
        public DateTime? FromFTSPhotoop { get; set; }

        /// <summary>
        /// 结束拍照时间
        /// </summary>
        public DateTime? ToFTSPhotoop { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string FTSPosition { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FTSFullName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string FTSTelephone { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string FTSRegion { get; set; }
        /// <summary>
        /// 点赞数目
        /// </summary>
        public string FTSNumberOfPoints { get; set; }

    }
    /// <summary>
    /// 主动巡检 搜索条件实体模型
    /// </summary>
    public class ActiveInspectionSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 巡检问题
        /// </summary>
        public string AIInspectionProblem { get; set; }

        /// <summary>
        /// 开始创建时间
        /// </summary>
        public DateTime? FromAICreationTime { get; set; }

        /// <summary>
        /// 结束创建时间
        /// </summary>
        public DateTime? ToAICreationTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string[] AIState { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public string AIUser { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string AIRegion { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string AIPicture { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string AIPosition { get; set; }

    }
    /// <summary>
    /// 业务预约 搜索条件实体模型
    /// </summary>
    public class BusinessAppointmentSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 业务
        /// </summary>
        public string BABusiness { get; set; }
        /// <summary>
        /// 服务
        /// </summary>
        public string BAService { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string BAFullName { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string BAId { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string BATelephone { get; set; }

        /// <summary>
        /// 开始创建时间
        /// </summary>
        public DateTime? FromBACreationTime { get; set; }

        /// <summary>
        /// 结束创建时间
        /// </summary>
        public DateTime? ToBACreationTime { get; set; }

        /// <summary>
        /// 开始受理时间
        /// </summary>
        public DateTime? FromBAAcceptanceTime { get; set; }

        /// <summary>
        /// 结束受理时间
        /// </summary>
        public DateTime? ToBAAcceptanceTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string[] BAState { get; set; }

    }
    /// <summary>
    /// 提建议记录 搜索条件实体模型
    /// </summary>
    public class RecordOfRecommendationsSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string RORTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string RORContent { get; set; }
        /// <summary>
        /// 对象
        /// </summary>
        public string RORObject { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public string RORDealingWithPeople { get; set; }

        /// <summary>
        /// 开始处理日期
        /// </summary>
        public DateTime? FromRORDateOfProcessing { get; set; }

        /// <summary>
        /// 结束处理日期
        /// </summary>
        public DateTime? ToRORDateOfProcessing { get; set; }

    }
    /// <summary>
    /// 党风廉政学习 搜索条件实体模型
    /// </summary>
    public class StudyOnPartyStyleAndCleanGovernmentSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string SOPSACGTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string SOPSACGContent { get; set; }
        /// <summary>
        /// 学习对象
        /// </summary>
        public string SOPSACGLearningObject { get; set; }

        /// <summary>
        /// 开始学习日期
        /// </summary>
        public DateTime? FromSOPSACGLearningDate { get; set; }

        /// <summary>
        /// 结束学习日期
        /// </summary>
        public DateTime? ToSOPSACGLearningDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string SOPSACGRemarks { get; set; }

    }
    /// <summary>
    /// 公共设施 搜索条件实体模型
    /// </summary>
    public class CommunalFacilitiesSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string CFName { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string CFPosition { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string CFType { get; set; }
        /// <summary>
        /// 归属
        /// </summary>
        public string CFAscription { get; set; }

        /// <summary>
        /// 开始换新日期
        /// </summary>
        public DateTime? FromCFRenewalDate { get; set; }

        /// <summary>
        /// 结束换新日期
        /// </summary>
        public DateTime? ToCFRenewalDate { get; set; }
        /// <summary>
        /// 是否损坏
        /// </summary>
        public string CFIsItDamaged { get; set; }

    }
    /// <summary>
    /// 系统配置 搜索条件实体模型
    /// </summary>
    public class SystemConfigurationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string SCTitle { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string SCClassification { get; set; }
        /// <summary>
        /// 子分类
        /// </summary>
        public string SCSubClassification { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string SCContent { get; set; }
        /// <summary>
        /// 是否生效
        /// </summary>
        public string SCIsItEffective { get; set; }

    }
    /// <summary>
    /// 党建 搜索条件实体模型
    /// </summary>
    public class PartyBuildingSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string PBTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string PBContent { get; set; }

        /// <summary>
        /// 开始发布时间
        /// </summary>
        public DateTime? FromPBReleaseTime { get; set; }

        /// <summary>
        /// 结束发布时间
        /// </summary>
        public DateTime? ToPBReleaseTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string PBRemarks { get; set; }

    }
    /// <summary>
    /// 党费缴纳管理 搜索条件实体模型
    /// </summary>
    public class ManagementOfPartyFeePaymentSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string MOPFPFullName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string MOPFPTelephone { get; set; }

        /// <summary>
        /// 最小金额
        /// </summary>
        public decimal? MinMOPFPAmountOfMoney { get; set; }

        /// <summary>
        /// 最大金额
        /// </summary>
        public decimal? MaxMOPFPAmountOfMoney { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? FromMOPFPDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? ToMOPFPDate { get; set; }
        /// <summary>
        /// 收款人
        /// </summary>
        public string MOPFPPayee { get; set; }
        /// <summary>
        /// 所属支部
        /// </summary>
        public string MOPFPSubordinateBranch { get; set; }

    }
    /// <summary>
    /// 合同管理 搜索条件实体模型
    /// </summary>
    public class ContractManagementSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string CMContractNumber { get; set; }
        /// <summary>
        /// 合同名称
        /// </summary>
        public string CMContractName { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string CMEntryName { get; set; }
        /// <summary>
        /// 甲方签名
        /// </summary>
        public string CMSignatureOfPartya { get; set; }
        /// <summary>
        /// 乙方签名
        /// </summary>
        public string CMSignatureOfPartyb { get; set; }
        /// <summary>
        /// 丙方签名
        /// </summary>
        public string CMSignatureOfPartyc { get; set; }

        /// <summary>
        /// 开始签署日期
        /// </summary>
        public DateTime? FromCMSigningDate { get; set; }

        /// <summary>
        /// 结束签署日期
        /// </summary>
        public DateTime? ToCMSigningDate { get; set; }
        /// <summary>
        /// 签署机构
        /// </summary>
        public string CMSignatory { get; set; }
        /// <summary>
        /// 合同文件上传
        /// </summary>
        public string CMUploadContractDocuments { get; set; }

    }
    /// <summary>
    /// 个人信息 搜索条件实体模型
    /// </summary>
    public class PersonalInformationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string PILoginName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string PINickname { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string PIRealName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PIPassword { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string PIHeadPortrait { get; set; }

        /// <summary>
        /// 开始上次登录时间
        /// </summary>
        public DateTime? FromPILastLogonTime { get; set; }

        /// <summary>
        /// 结束上次登录时间
        /// </summary>
        public DateTime? ToPILastLogonTime { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public string PISubordinateDepartments { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string PITelephone { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string PIPhoto { get; set; }

    }
    /// <summary>
    /// 日程工作 搜索条件实体模型
    /// </summary>
    public class ScheduleWorkSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string SWTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string SWContent { get; set; }
        /// <summary>
        /// 地点
        /// </summary>
        public string SWPlace { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string SWPersonInCharge { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string SWTelephone { get; set; }

        /// <summary>
        /// 开始开始时间
        /// </summary>
        public DateTime? FromSWStartTime { get; set; }

        /// <summary>
        /// 结束开始时间
        /// </summary>
        public DateTime? ToSWStartTime { get; set; }

        /// <summary>
        /// 开始结束时间
        /// </summary>
        public DateTime? FromSWEndingTime { get; set; }

        /// <summary>
        /// 结束结束时间
        /// </summary>
        public DateTime? ToSWEndingTime { get; set; }

    }
    /// <summary>
    /// 党建专题 搜索条件实体模型
    /// </summary>
    public class SpecialTopicOnPartyBuildingSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string STOPBTitle { get; set; }
        /// <summary>
        /// 预览
        /// </summary>
        public string STOPBPreview { get; set; }

        /// <summary>
        /// 开始发布时间
        /// </summary>
        public DateTime? FromSTOPBReleaseTime { get; set; }

        /// <summary>
        /// 结束发布时间
        /// </summary>
        public DateTime? ToSTOPBReleaseTime { get; set; }
        /// <summary>
        /// 查看
        /// </summary>
        public string STOPBSee { get; set; }

    }
    /// <summary>
    /// 办事指南 搜索条件实体模型
    /// </summary>
    public class BusinessGuideSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string BGCategory { get; set; }
        /// <summary>
        /// 办事内容
        /// </summary>
        public string BGContentOfWork { get; set; }
        /// <summary>
        /// 所需材料
        /// </summary>
        public string BGRequiredMaterials { get; set; }
        /// <summary>
        /// 办事程序
        /// </summary>
        public string BGProcedure { get; set; }

    }
    /// <summary>
    /// 党务指南 搜索条件实体模型
    /// </summary>
    public class PartyAffairsGuideSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string PAGTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string PAGContent { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string PAGCategory { get; set; }
        /// <summary>
        /// 适用范围
        /// </summary>
        public string PAGScopeOfApplication { get; set; }

    }
    /// <summary>
    /// 业务管理 搜索条件实体模型
    /// </summary>
    public class BusinessManagementSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public string BMBusinessType { get; set; }
        /// <summary>
        /// 服务类型
        /// </summary>
        public string BMServiceType { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public string BMApplicant { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string BMId { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string BMGender { get; set; }

        /// <summary>
        /// 开始大厅受理时间
        /// </summary>
        public DateTime? FromBMHallAcceptanceTime { get; set; }

        /// <summary>
        /// 结束大厅受理时间
        /// </summary>
        public DateTime? ToBMHallAcceptanceTime { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        public string BMAgent { get; set; }

        /// <summary>
        /// 开始创建时间
        /// </summary>
        public DateTime? FromBMCreationTime { get; set; }

        /// <summary>
        /// 结束创建时间
        /// </summary>
        public DateTime? ToBMCreationTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string[] BMState { get; set; }

    }
    /// <summary>
    /// 少儿医保 搜索条件实体模型
    /// </summary>
    public class MedicalInsuranceForChildrenSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 单位编号
        /// </summary>
        public string MIFCUnitNumber { get; set; }
        /// <summary>
        /// 人员编号
        /// </summary>
        public string MIFCPersonnelNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string MIFCFullName { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string MIFCId { get; set; }

        /// <summary>
        /// 开始出生日期
        /// </summary>
        public DateTime? FromMIFCDateOfBirth { get; set; }

        /// <summary>
        /// 结束出生日期
        /// </summary>
        public DateTime? ToMIFCDateOfBirth { get; set; }
        /// <summary>
        /// 免缴种类
        /// </summary>
        public string MIFCExemptionCategory { get; set; }
        /// <summary>
        /// 免缴号码
        /// </summary>
        public string MIFCExemptionNumber { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string MIFCContacts { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string MIFCContactNumber { get; set; }

    }
    /// <summary>
    /// 农村医疗 搜索条件实体模型
    /// </summary>
    public class RuralMedicalTreatmentSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 人员编号
        /// </summary>
        public string RMTPersonnelNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RMTFullName { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string RMTId { get; set; }
        /// <summary>
        /// 免缴种类
        /// </summary>
        public string RMTExemptionCategory { get; set; }
        /// <summary>
        /// 免缴号码
        /// </summary>
        public string RMTExemptionNumber { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string RMTContacts { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string RMTContactNumber { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string RMTRegion { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string RMTOperation { get; set; }

    }
    /// <summary>
    /// 福利发放 搜索条件实体模型
    /// </summary>
    public class WelfarePaymentSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string WPFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string WPGender { get; set; }

        /// <summary>
        /// 最小年龄
        /// </summary>
        public int? MinWPAge { get; set; }

        /// <summary>
        /// 最大年龄
        /// </summary>
        public int? MaxWPAge { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string WPIdNumber { get; set; }
        /// <summary>
        /// 福利类型
        /// </summary>
        public string WPWelfareType { get; set; }

        /// <summary>
        /// 最小发放金额
        /// </summary>
        public decimal? MinWPPaymentAmount { get; set; }

        /// <summary>
        /// 最大发放金额
        /// </summary>
        public decimal? MaxWPPaymentAmount { get; set; }

        /// <summary>
        /// 开始发放日期
        /// </summary>
        public DateTime? FromWPDateOfIssue { get; set; }

        /// <summary>
        /// 结束发放日期
        /// </summary>
        public DateTime? ToWPDateOfIssue { get; set; }
        /// <summary>
        /// 被保人id
        /// </summary>
        public string WPInsuredId { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string WPAddress { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string WPRegion { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string WPOperation { get; set; }

    }
    /// <summary>
    /// 服务预约 搜索条件实体模型
    /// </summary>
    public class ServiceAppointmentSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 服务类型
        /// </summary>
        public string SAServiceType { get; set; }
        /// <summary>
        /// 预约人
        /// </summary>
        public string SAAppointments { get; set; }

        /// <summary>
        /// 开始预约时间
        /// </summary>
        public DateTime? FromSATimeOfAppointment { get; set; }

        /// <summary>
        /// 结束预约时间
        /// </summary>
        public DateTime? ToSATimeOfAppointment { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string SAId { get; set; }

        /// <summary>
        /// 开始创建时间
        /// </summary>
        public DateTime? FromSACreationTime { get; set; }

        /// <summary>
        /// 结束创建时间
        /// </summary>
        public DateTime? ToSACreationTime { get; set; }

        /// <summary>
        /// 开始审核时间
        /// </summary>
        public DateTime? FromSAAuditTime { get; set; }

        /// <summary>
        /// 结束审核时间
        /// </summary>
        public DateTime? ToSAAuditTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string[] SAState { get; set; }
        /// <summary>
        /// 审核登记
        /// </summary>
        public string SAAuditRegistration { get; set; }

    }
    /// <summary>
    /// 日程管理 搜索条件实体模型
    /// </summary>
    public class ScheduleManagementSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 活动类型
        /// </summary>
        public string SMActivityType { get; set; }

        /// <summary>
        /// 开始开始日期
        /// </summary>
        public DateTime? FromSMStartDate { get; set; }

        /// <summary>
        /// 结束开始日期
        /// </summary>
        public DateTime? ToSMStartDate { get; set; }

        /// <summary>
        /// 开始结束日期
        /// </summary>
        public DateTime? FromSMEndDate { get; set; }

        /// <summary>
        /// 结束结束日期
        /// </summary>
        public DateTime? ToSMEndDate { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string SMContent { get; set; }
        /// <summary>
        /// 地点
        /// </summary>
        public string SMPlace { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string SMPersonInCharge { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string SMTelephone { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string SMRemarks { get; set; }

    }
    /// <summary>
    /// 专家管理 搜索条件实体模型
    /// </summary>
    public class ExpertManagementSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 技术特长
        /// </summary>
        public string EMTechnicalExpertise { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string EMFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string EMGender { get; set; }

        /// <summary>
        /// 开始出生日期
        /// </summary>
        public DateTime? FromEMDateOfBirth { get; set; }

        /// <summary>
        /// 结束出生日期
        /// </summary>
        public DateTime? ToEMDateOfBirth { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string EMId { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string EMAddress { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string EMContactNumber { get; set; }

    }
    /// <summary>
    /// 权限访问 搜索条件实体模型
    /// </summary>
    public class PermissionAccessSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string PAFullName { get; set; }

        /// <summary>
        /// 开始访问时间
        /// </summary>
        public DateTime? FromPAAccessTime { get; set; }

        /// <summary>
        /// 结束访问时间
        /// </summary>
        public DateTime? ToPAAccessTime { get; set; }

    }
    /// <summary>
    /// 便民指南 搜索条件实体模型
    /// </summary>
    public class ConvenienceGuideSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string CGTitle { get; set; }

        /// <summary>
        /// 开始发布时间
        /// </summary>
        public DateTime? FromCGReleaseTime { get; set; }

        /// <summary>
        /// 结束发布时间
        /// </summary>
        public DateTime? ToCGReleaseTime { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string CGPicture { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string CGContent { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string CGAbstract { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string CGRemarks { get; set; }

    }
    /// <summary>
    /// 便民生活 搜索条件实体模型
    /// </summary>
    public class ConvenientLifeSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string CLTitle { get; set; }

        /// <summary>
        /// 开始发布时间
        /// </summary>
        public DateTime? FromCLReleaseTime { get; set; }

        /// <summary>
        /// 结束发布时间
        /// </summary>
        public DateTime? ToCLReleaseTime { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string CLPicture { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string CLContent { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string CLAbstract { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string CLRemarks { get; set; }

    }
    /// <summary>
    /// 香溪特色 搜索条件实体模型
    /// </summary>
    public class CharacteristicOfXiangxiSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string COXTitle { get; set; }

        /// <summary>
        /// 开始发布时间
        /// </summary>
        public DateTime? FromCOXReleaseTime { get; set; }

        /// <summary>
        /// 结束发布时间
        /// </summary>
        public DateTime? ToCOXReleaseTime { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string COXPicture { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string COXContent { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string COXAbstract { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string COXRemarks { get; set; }

    }
    /// <summary>
    /// 建议处理 搜索条件实体模型
    /// </summary>
    public class ProposedTreatmentSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string PTTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string PTContent { get; set; }
        /// <summary>
        /// 对象
        /// </summary>
        public string PTObject { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public string PTDealingWithPeople { get; set; }

        /// <summary>
        /// 开始处理日期
        /// </summary>
        public DateTime? FromPTDateOfProcessing { get; set; }

        /// <summary>
        /// 结束处理日期
        /// </summary>
        public DateTime? ToPTDateOfProcessing { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PTFullName { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string PTId { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string PTTelephone { get; set; }

        /// <summary>
        /// 开始创建时间
        /// </summary>
        public DateTime? FromPTCreationTime { get; set; }

        /// <summary>
        /// 结束创建时间
        /// </summary>
        public DateTime? ToPTCreationTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string[] PTState { get; set; }

    }
    /// <summary>
    /// 村史 搜索条件实体模型
    /// </summary>
    public class VillageHistorySearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 菜单项
        /// </summary>
        public string VHMenuItem { get; set; }
        /// <summary>
        /// 主标题
        /// </summary>
        public string VHMainTitle { get; set; }
        /// <summary>
        /// 副标题
        /// </summary>
        public string VHSubheading { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string VHPicture { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string VHAbstract { get; set; }

    }
    /// <summary>
    /// 专项工作 搜索条件实体模型
    /// </summary>
    public class SpecialWorkSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 工作主题
        /// </summary>
        public string SWWorkTheme { get; set; }
        /// <summary>
        /// 工作内容
        /// </summary>
        public string SWJobContent { get; set; }

        /// <summary>
        /// 开始开始日期
        /// </summary>
        public DateTime? FromSWStartDate { get; set; }

        /// <summary>
        /// 结束开始日期
        /// </summary>
        public DateTime? ToSWStartDate { get; set; }

        /// <summary>
        /// 开始结束日期
        /// </summary>
        public DateTime? FromSWEndDate { get; set; }

        /// <summary>
        /// 结束结束日期
        /// </summary>
        public DateTime? ToSWEndDate { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string[] SWState { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string SWPhoto { get; set; }

    }
    /// <summary>
    /// 视频点位信息 搜索条件实体模型
    /// </summary>
    public class VideoPointInformationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string VPISerialNumber { get; set; }
        /// <summary>
        /// 监控点名称
        /// </summary>
        public string VPIMonitoringPointName { get; set; }
        /// <summary>
        /// 监控点编号
        /// </summary>
        public string VPIMonitoringPointNumber { get; set; }
        /// <summary>
        /// 所属组织
        /// </summary>
        public string VPIAffiliatedOrganization { get; set; }
        /// <summary>
        /// 所属区域
        /// </summary>
        public string VPIAreasToWhichTheyBelong { get; set; }
        /// <summary>
        /// 所属平台
        /// </summary>
        public string VPISubordinatePlatform { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string VPILongitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string VPILatitude { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string VPIAddress { get; set; }

    }
    /// <summary>
    /// 就业援助 搜索条件实体模型
    /// </summary>
    public class EmploymentAssistanceSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 个人编号
        /// </summary>
        public string EAPersonalNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string EAFullName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string EAIdCardNo { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string EAGender { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string EANation { get; set; }

        /// <summary>
        /// 最小年龄
        /// </summary>
        public int? MinEAAge { get; set; }

        /// <summary>
        /// 最大年龄
        /// </summary>
        public int? MaxEAAge { get; set; }
        /// <summary>
        /// 文化程度
        /// </summary>
        public string EADegreeOfEducation { get; set; }
        /// <summary>
        /// 户口性质
        /// </summary>
        public string EAAccountCharacter { get; set; }
        /// <summary>
        /// 是否残疾
        /// </summary>
        public string EAIsItDisabled { get; set; }
        /// <summary>
        /// 培训意愿
        /// </summary>
        public string EATrainingIntention { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string EAContactInformation { get; set; }
        /// <summary>
        /// 人员类型
        /// </summary>
        public string EAPersonnelType { get; set; }
        /// <summary>
        /// 就业形式
        /// </summary>
        public string EAFormOfEmployment { get; set; }
        /// <summary>
        /// 内容1
        /// </summary>
        public string EAContent1 { get; set; }
        /// <summary>
        /// 内容2
        /// </summary>
        public string EAContent2 { get; set; }
        /// <summary>
        /// 内容3
        /// </summary>
        public string EAContent3 { get; set; }
        /// <summary>
        /// 内容4
        /// </summary>
        public string EAContent4 { get; set; }

    }
    /// <summary>
    /// 危房解危 搜索条件实体模型
    /// </summary>
    public class DangerousHousingSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 所有权人
        /// </summary>
        public string DHOwner { get; set; }
        /// <summary>
        /// 房屋座落
        /// </summary>
        public string DHHousingLocation { get; set; }

        /// <summary>
        /// 最小房产证面积
        /// </summary>
        public int? MinDHRealEstateCertificateArea { get; set; }

        /// <summary>
        /// 最大房产证面积
        /// </summary>
        public int? MaxDHRealEstateCertificateArea { get; set; }

        /// <summary>
        /// 最小土地证面积
        /// </summary>
        public int? MinDHLandCertificateArea { get; set; }

        /// <summary>
        /// 最大土地证面积
        /// </summary>
        public int? MaxDHLandCertificateArea { get; set; }

        /// <summary>
        /// 最小测绘面积
        /// </summary>
        public int? MinDHMappingArea { get; set; }

        /// <summary>
        /// 最大测绘面积
        /// </summary>
        public int? MaxDHMappingArea { get; set; }

        /// <summary>
        /// 最小测绘增补面积
        /// </summary>
        public int? MinDHSupplementaryAreaOfSurveyingAndMapping { get; set; }

        /// <summary>
        /// 最大测绘增补面积
        /// </summary>
        public int? MaxDHSupplementaryAreaOfSurveyingAndMapping { get; set; }

        /// <summary>
        /// 最小安置面积
        /// </summary>
        public int? MinDHResettlementArea { get; set; }

        /// <summary>
        /// 最大安置面积
        /// </summary>
        public int? MaxDHResettlementArea { get; set; }

        /// <summary>
        /// 开始签字时间
        /// </summary>
        public DateTime? FromDHSignatureTime { get; set; }

        /// <summary>
        /// 结束签字时间
        /// </summary>
        public DateTime? ToDHSignatureTime { get; set; }

        /// <summary>
        /// 开始交房时间
        /// </summary>
        public DateTime? FromDHTimeOfDelivery { get; set; }

        /// <summary>
        /// 结束交房时间
        /// </summary>
        public DateTime? ToDHTimeOfDelivery { get; set; }

        /// <summary>
        /// 最小补偿金额
        /// </summary>
        public decimal? MinDHCompensationAmount { get; set; }

        /// <summary>
        /// 最大补偿金额
        /// </summary>
        public decimal? MaxDHCompensationAmount { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string DHContactNumber { get; set; }
        /// <summary>
        /// 现居住地址
        /// </summary>
        public string DHCurrentResidentialAddress { get; set; }

    }
    /// <summary>
    /// 工业园房屋收款 搜索条件实体模型
    /// </summary>
    public class IndustrialParkHousingReceiptSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// @厂房楼栋
        /// </summary>
        public string IPHRFactoryBuilding { get; set; }

        /// <summary>
        /// 开始开始时间
        /// </summary>
        public DateTime? FromIPHRStartTime { get; set; }

        /// <summary>
        /// 结束开始时间
        /// </summary>
        public DateTime? ToIPHRStartTime { get; set; }

        /// <summary>
        /// 开始结束时间
        /// </summary>
        public DateTime? FromIPHREndingTime { get; set; }

        /// <summary>
        /// 结束结束时间
        /// </summary>
        public DateTime? ToIPHREndingTime { get; set; }

        /// <summary>
        /// 最小付款金额
        /// </summary>
        public decimal? MinIPHRPaymentAmount { get; set; }

        /// <summary>
        /// 最大付款金额
        /// </summary>
        public decimal? MaxIPHRPaymentAmount { get; set; }

    }
    /// <summary>
    /// 需求收集 搜索条件实体模型
    /// </summary>
    public class DemandCollectionSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 您需要什么内容
        /// </summary>
        public string DCWhatDoYouNeed { get; set; }

        /// <summary>
        /// 开始期望交付时间
        /// </summary>
        public DateTime? FromDCExpectedDeliveryTime { get; set; }

        /// <summary>
        /// 结束期望交付时间
        /// </summary>
        public DateTime? ToDCExpectedDeliveryTime { get; set; }
        /// <summary>
        /// 您的姓名
        /// </summary>
        public string DCYourName { get; set; }
        /// <summary>
        /// 您的联系方式
        /// </summary>
        public string DCYourContactInformation { get; set; }

    }
    /// <summary>
    /// 党组织信息管理 搜索条件实体模型
    /// </summary>
    public class InformationManagementOfPartyOrganizationsSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 党组织名称
        /// </summary>
        public string IMOPONameOfPartyOrganization { get; set; }
        /// <summary>
        /// 党组织书记
        /// </summary>
        public string IMOPOSecretaryOfPartyOrganization { get; set; }
        /// <summary>
        /// 党组织联系人
        /// </summary>
        public string IMOPOPartyOrganizationContacts { get; set; }
        /// <summary>
        /// 党组织联系电话
        /// </summary>
        public string IMOPOPartyOrganizationContactTelephone { get; set; }
        /// <summary>
        /// 组织类别
        /// </summary>
        public string IMOPOOrganizationCategory { get; set; }
        /// <summary>
        /// 上级党组织名称
        /// </summary>
        public string IMOPONameOfPartyOrganizationAtHigherLevel { get; set; }
        /// <summary>
        /// 党组织书记公民身份号码
        /// </summary>
        public string IMOPOCitizenshipNumberOfPartyOrganizationSecretary { get; set; }

    }
    /// <summary>
    /// 关爱对象 搜索条件实体模型
    /// </summary>
    public class CareForTheObjectSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string CFTOFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string CFTOGender { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string CFTOType { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string CFTOId { get; set; }
        /// <summary>
        /// 户口所在地
        /// </summary>
        public string CFTORegisteredResidence { get; set; }
        /// <summary>
        /// 常住地
        /// </summary>
        public string CFTOPermanentResidence { get; set; }
        /// <summary>
        /// 楼栋号
        /// </summary>
        public string CFTOBuildingNumber { get; set; }
        /// <summary>
        /// 单元号
        /// </summary>
        public string CFTOUnitNumber { get; set; }
        /// <summary>
        /// 门牌号
        /// </summary>
        public string CFTOHouseNumber { get; set; }

    }
    /// <summary>
    /// 招聘就业模块 搜索条件实体模型
    /// </summary>
    public class RecruitmentAndEmploymentModuleSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 用人单位
        /// </summary>
        public string RAEMEmployingUnit { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string RAEMPosition { get; set; }
        /// <summary>
        /// 发布人
        /// </summary>
        public string RAEMPublisher { get; set; }
        /// <summary>
        /// 职位描述
        /// </summary>
        public string RAEMJobDescription { get; set; }
        /// <summary>
        /// 职位职责内容
        /// </summary>
        public string RAEMJobResponsibilities { get; set; }
        /// <summary>
        /// 职位要求内容
        /// </summary>
        public string RAEMContentsOfJobRequirements { get; set; }

        /// <summary>
        /// 开始生效时间
        /// </summary>
        public DateTime? FromRAEMEntryintoforceTime { get; set; }

        /// <summary>
        /// 结束生效时间
        /// </summary>
        public DateTime? ToRAEMEntryintoforceTime { get; set; }

        /// <summary>
        /// 开始失效时间
        /// </summary>
        public DateTime? FromRAEMFailureTime { get; set; }

        /// <summary>
        /// 结束失效时间
        /// </summary>
        public DateTime? ToRAEMFailureTime { get; set; }

    }
    /// <summary>
    /// 党群结队 搜索条件实体模型
    /// </summary>
    public class PartyAndGroupFormationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 所属党组织
        /// </summary>
        public string PAGFPartyOrganizationsAffiliatedToThem { get; set; }
        /// <summary>
        /// 成员姓名
        /// </summary>
        public string PAGFNameOfMember { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string PAGFIdCardNo { get; set; }

        /// <summary>
        /// 开始创建时间
        /// </summary>
        public DateTime? FromPAGFCreationTime { get; set; }

        /// <summary>
        /// 结束创建时间
        /// </summary>
        public DateTime? ToPAGFCreationTime { get; set; }

    }
    /// <summary>
    /// 党员活动 搜索条件实体模型
    /// </summary>
    public class PartyMemberActivitiesSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string PMAActivityName { get; set; }
        /// <summary>
        /// 活动简介
        /// </summary>
        public string PMAActivityBrief { get; set; }
        /// <summary>
        /// 覆盖范围
        /// </summary>
        public string PMACoverageArea { get; set; }
        /// <summary>
        /// 活动照片
        /// </summary>
        public string PMAActivePhotos { get; set; }

    }
    /// <summary>
    /// 美丽乡村 搜索条件实体模型
    /// </summary>
    public class BeautifulCountrysideSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public string BCParticularYear { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public string BCMonth { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string BCTitle { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string BCPhoto { get; set; }
        /// <summary>
        /// 建设成果
        /// </summary>
        public string BCAchievementsInConstruction { get; set; }

    }
    /// <summary>
    /// 引水上山 搜索条件实体模型
    /// </summary>
    public class DrawWaterUpaHillSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public string DWUHParticularYear { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public string DWUHMonth { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string DWUHTitle { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string DWUHPhoto { get; set; }
        /// <summary>
        /// 建设成果
        /// </summary>
        public string DWUHAchievementsInConstruction { get; set; }

    }
    /// <summary>
    /// 宣传 搜索条件实体模型
    /// </summary>
    public class PropagandaSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string PTitle { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string PCategory { get; set; }
        /// <summary>
        /// 子类别
        /// </summary>
        public string PSubcategory { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string PContent { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string PAddress { get; set; }

    }
    /// <summary>
    /// 组织 搜索条件实体模型
    /// </summary>
    public class OrganizationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 成员编号
        /// </summary>
        public string OMembershipNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string OFullName { get; set; }
        /// <summary>
        /// 上级
        /// </summary>
        public string OSuperior { get; set; }
        /// <summary>
        /// 组织名称
        /// </summary>
        public string OOrganizationName { get; set; }
        /// <summary>
        /// 所属支部
        /// </summary>
        public string OSubordinateBranch { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string OAddress { get; set; }

    }
    /// <summary>
    /// 工会 搜索条件实体模型
    /// </summary>
    public class LabourUnionSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 单位组织机构代码
        /// </summary>
        public string LUUnitOrganizationCode { get; set; }
        /// <summary>
        /// 单位或单位主体的国民经济行业分类代码
        /// </summary>
        public string LUClassificationCodeOfNationalEconomyIndustryOfUnitOrSubjectOfUnit { get; set; }
        /// <summary>
        /// 单位或单位主体的单位类别
        /// </summary>
        public string LUClassificationOfUnitsOrSubjectsOfUnits { get; set; }
        /// <summary>
        /// 单位地址
        /// </summary>
        public string LUUnitAddress { get; set; }
        /// <summary>
        /// 上级工会
        /// </summary>
        public string LUHigherLevelTradeUnion { get; set; }
        /// <summary>
        /// 单位工会名称
        /// </summary>
        public string LUUnitTradeUnionName { get; set; }

        /// <summary>
        /// 开始建会时间
        /// </summary>
        public DateTime? FromLUBuildingTime { get; set; }

        /// <summary>
        /// 结束建会时间
        /// </summary>
        public DateTime? ToLUBuildingTime { get; set; }
        /// <summary>
        /// 工会负责人
        /// </summary>
        public string LUTheHeadOfTheTradeUnion { get; set; }
        /// <summary>
        /// 工会负责人联系电话
        /// </summary>
        public string LUTelephoneCallsFromTradeUnionLeaders { get; set; }
        /// <summary>
        /// 工会办公电话
        /// </summary>
        public string LUTradeUnionOfficeTelephone { get; set; }
        /// <summary>
        /// 本单位已交至苏州银行的会员身份证复印件数量
        /// </summary>
        public string LUNumberOfCopiesOfMembershipIdentityCardsSubmittedToBankOfSuzhou { get; set; }
        /// <summary>
        /// 单位职工总数人
        /// </summary>
        public string LUTotalNumberOfEmployeesInaUnit { get; set; }
        /// <summary>
        /// 单位会员数人
        /// </summary>
        public string LUNumberOfUnitMembers { get; set; }
        /// <summary>
        /// 单位女职工数人
        /// </summary>
        public string LUNumberOfFemaleEmployeesInaUnit { get; set; }
        /// <summary>
        /// 单位女会员数人
        /// </summary>
        public string LUNumberOfFemaleMembersInaUnit { get; set; }
        /// <summary>
        /// 统计主题1
        /// </summary>
        public string LUStatisticalTopic1 { get; set; }

    }
    /// <summary>
    /// 工会成员 搜索条件实体模型
    /// </summary>
    public class TradeUnionMembersSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string TUMFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string TUMGender { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string TUMNation { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public string TUMDateOfBirth { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string TUMPoliticalOutlook { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string TUMEducation { get; set; }
        /// <summary>
        /// 籍贯XX省XX市
        /// </summary>
        public string TUMXxCityXxProvince { get; set; }

        /// <summary>
        /// 开始入会时间
        /// </summary>
        public DateTime? FromTUMAdmissionTime { get; set; }

        /// <summary>
        /// 结束入会时间
        /// </summary>
        public DateTime? ToTUMAdmissionTime { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string TUMIdNumber { get; set; }
        /// <summary>
        /// 地址单位地址
        /// </summary>
        public string TUMAddressUnitAddress { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string TUMPhoneNumber { get; set; }
        /// <summary>
        /// 身份证有效期限
        /// </summary>
        public string TUMLimitOfValidityOfIdentityCard { get; set; }
        /// <summary>
        /// 是否从事有毒有害工作是否
        /// </summary>
        public string TUMWhetherToEngageInToxicAndHarmfulWorkOrNot { get; set; }
        /// <summary>
        /// 备注1
        /// </summary>
        public string TUMRemarks1 { get; set; }

    }
    /// <summary>
    /// 工作人员 搜索条件实体模型
    /// </summary>
    public class PersonnelSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string PEmployeeNumber { get; set; }
        /// <summary>
        /// 上级
        /// </summary>
        public string PSuperior { get; set; }
        /// <summary>
        /// 负责区域
        /// </summary>
        public string PResponsibleArea { get; set; }
        /// <summary>
        /// 所属条线
        /// </summary>
        public string PSubordinateLine { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string PAddress { get; set; }

    }
    /// <summary>
    /// 姑苏村问题处理 搜索条件实体模型
    /// </summary>
    public class HandlingOfGusuVillageProblemSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 问题编号
        /// </summary>
        public string HOGVPQuestionNumber { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string HOGVPProblemDescription { get; set; }
        /// <summary>
        /// 问题类别
        /// </summary>
        public string HOGVPQuestionCategories { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string HOGVPPhoto { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string HOGVPPersonInCharge { get; set; }
        /// <summary>
        /// 问题状态
        /// </summary>
        public string[] HOGVPProblemState { get; set; }

        /// <summary>
        /// 开始确认时间
        /// </summary>
        public DateTime? FromHOGVPConfirmationTime { get; set; }

        /// <summary>
        /// 结束确认时间
        /// </summary>
        public DateTime? ToHOGVPConfirmationTime { get; set; }

        /// <summary>
        /// 开始处理时间
        /// </summary>
        public DateTime? FromHOGVPProcessingTime { get; set; }

        /// <summary>
        /// 结束处理时间
        /// </summary>
        public DateTime? ToHOGVPProcessingTime { get; set; }

        /// <summary>
        /// 开始回访时间
        /// </summary>
        public DateTime? FromHOGVPRevisitDays { get; set; }

        /// <summary>
        /// 结束回访时间
        /// </summary>
        public DateTime? ToHOGVPRevisitDays { get; set; }

    }
    /// <summary>
    /// 渔政 搜索条件实体模型
    /// </summary>
    public class FisheryAdministrationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 渔证编号
        /// </summary>
        public string FAFishingPermitNumber { get; set; }
        /// <summary>
        /// 持证人姓名
        /// </summary>
        public string FANameOfTheHolder { get; set; }

        /// <summary>
        /// 开始发证日期
        /// </summary>
        public DateTime? FromFADateOfIssue { get; set; }

        /// <summary>
        /// 结束发证日期
        /// </summary>
        public DateTime? ToFADateOfIssue { get; set; }

        /// <summary>
        /// 开始下次换证日期
        /// </summary>
        public DateTime? FromFADateOfNextRenewal { get; set; }

        /// <summary>
        /// 结束下次换证日期
        /// </summary>
        public DateTime? ToFADateOfNextRenewal { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string FAPersonInCharge { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string FAAddress { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public string FAIsItEffective { get; set; }

    }
    /// <summary>
    /// 妇联执委名单 搜索条件实体模型
    /// </summary>
    public class ListOfExecutiveCommitteesOfWomensFederationSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string LOECOWFSerialNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string LOECOWFFullName { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public string LOECOWFDateOfBirth { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string LOECOWFPost { get; set; }
        /// <summary>
        /// 性质
        /// </summary>
        public string LOECOWFNature { get; set; }

    }
    /// <summary>
    /// 资产 搜索条件实体模型
    /// </summary>
    public class AssetsSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 资产编号
        /// </summary>
        public string AAssetNumber { get; set; }
        /// <summary>
        /// 资产名称
        /// </summary>
        public string AAssetName { get; set; }
        /// <summary>
        /// 资产类别
        /// </summary>
        public string AAssetClass { get; set; }
        /// <summary>
        /// 会计科目
        /// </summary>
        public string AAccountingSubjects { get; set; }
        /// <summary>
        /// 所属单位
        /// </summary>
        public string ASubordinateUnit { get; set; }

    }
    /// <summary>
    /// 监护人 搜索条件实体模型
    /// </summary>
    public class GuardianSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string GFullName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string GGender { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string GContactNumber { get; set; }
        /// <summary>
        /// 户籍所在地
        /// </summary>
        public string GLocationOfHouseholdRegistration { get; set; }
        /// <summary>
        /// 所在地区
        /// </summary>
        public string GLocation { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string GDetailedAddress { get; set; }
        /// <summary>
        /// 居住地
        /// </summary>
        public string GPlaceOfResidence { get; set; }
        /// <summary>
        /// 提交人
        /// </summary>
        public string GSubmitter { get; set; }
        /// <summary>
        /// 提交人电话
        /// </summary>
        public string GAuthorsTelephoneNumber { get; set; }
        /// <summary>
        /// 社保卡正反面
        /// </summary>
        public string GPositiveAndNegativeSideOfSocialSecurityCard { get; set; }
        /// <summary>
        /// 监护人身份证正反面
        /// </summary>
        public string GThePositiveAndNegativeSidesOfGuardiansIdentityCard { get; set; }

    }
    /// <summary>
    /// 照片 搜索条件实体模型
    /// </summary>
    public class PhotoSearchModel
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
		public int PageSize { get; set; } = 5;
		
        /// <summary>
        /// 页码
        /// </summary>
		public int PageIndex { get; set; } = 0;
		
        /// <summary>
        /// 搜索关键字
        /// </summary>
		public string SearchKey { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
		public string Sort { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string PCategory { get; set; }
        /// <summary>
        /// url
        /// </summary>
        public string PUrl { get; set; }
        /// <summary>
        /// 物理地址
        /// </summary>
        public string PPhysicalAddress { get; set; }
        /// <summary>
        /// 社保卡反面
        /// </summary>
        public string PTheReverseSideOfSocialSecurityCard { get; set; }
        /// <summary>
        /// 社保卡正面
        /// </summary>
        public string PFrontOfSocialSecurityCard { get; set; }
        /// <summary>
        /// 监护人身份证正面
        /// </summary>
        public string PTheFrontOfGuardiansIdCard { get; set; }
        /// <summary>
        /// 监护人身份证反面
        /// </summary>
        public string PTheReverseOfGuardiansIdentityCard { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        public string POther { get; set; }

    }
}
