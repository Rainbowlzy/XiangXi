  
using System;

namespace XiangXi.Evaluators 
{
    /// <summary>
    /// 回民清真饮食补贴发放 搜索条件实体模型
    /// </summary>
    public class MuslimFoodSubsidiesSearchModel
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
        /// 姓名
        /// </summary>
        public string MFSName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string MFSChairperson { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string MFSCivilization { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string MFSHomeAddress { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string MFSIdCard { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string MFSCommonModeOfContact { get; set; }
        /// <summary>
        /// 补贴标准
        /// </summary>
        public string MFSStandardOfSubsidy { get; set; }

        /// <summary>
        /// 最小实发金额
        /// </summary>
        public decimal? MinMFSRealAmountOfMoney { get; set; }

        /// <summary>
        /// 最大实发金额
        /// </summary>
        public decimal? MaxMFSRealAmountOfMoney { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string MFSRemarks { get; set; }

    }
}
