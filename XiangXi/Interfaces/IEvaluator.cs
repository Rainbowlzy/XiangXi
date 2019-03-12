using System;
using XiangXi.Models;

namespace XiangXi.Interfaces
{
    public interface IEvaluator:IDisposable
    {
        /// <summary>
        /// 求值函数
        /// </summary>
        /// <param name="request">数据</param>
        /// <returns>返回值</returns>
        object Eval(CommonRequest request);
    }
}