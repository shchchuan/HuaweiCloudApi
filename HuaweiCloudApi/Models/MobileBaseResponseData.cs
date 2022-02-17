using System.Collections.Generic;
using System.ComponentModel;

namespace HuaweiCloudApi.Models
{
    /// <summary>
    /// 基本Response
    /// </summary>
    public class MobileBaseResponseData<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public EReponseCode Status { get; set; }
        /// <summary>
        /// 状态信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public T Data { get; set; }
    }
    /// <summary>
    /// page response data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResponseData<T>
    {
        public IList<T> List { get; set; }
        public long TotalCount { get; set; }
        public decimal Attribute { get; set; }
        public decimal Tab1 { get; set; }
        public decimal Tab2 { get; set; }
        public bool IsSeller { get; set; }
    }
    /// 返回值Code
    /// </summary>
    public enum EReponseCode
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        [Description("操作成功")]
        Success = 100,
        /// <summary>
        /// 用户未登录
        /// </summary>
        [Description("用户未登录")]
        NoLogin = 102,
        /// <summary>
        /// 参数错误
        /// </summary>
        [Description("参数错误")]
        ParameterError = 103,
        /// <summary>
        /// 业务错误
        /// </summary>
        [Description("业务错误")]
        BusinessError = 1010,
        /// <summary>
        /// 无法获取海报
        /// </summary>
        [Description("无法获取海报")]
        BusinessError_PosterFailed = 101001,
        /// <summary>
        /// 加入团失败
        /// </summary>
        [Description("加入团失败")]
        JoinGroupFailed = 101002,
        /// <summary>
        /// 系统错误
        /// </summary>
        [Description("系统错误")]
        SysError = 0,
    }
}
