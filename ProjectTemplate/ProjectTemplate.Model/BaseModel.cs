using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Model
{
    /// <summary>
    /// 基础表属性
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [Index]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 更新时间
        /// </summary>
        [Index]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 是否可用
        /// </summary>
        [Index]
        public bool IsEnable { get; set; } = true;
    }
}