using System;
using System.Collections.Generic;
using NbFramework.Common;
using NbFramework.Common.Data;

namespace NbCloud.Domain.Timetables
{
    /// <summary>
    /// 预约基础信息（时间、地点、种类）
    /// </summary>
    public class TimeOrder : NbEntity<TimeOrder>
    {
        /// <summary>
        /// 会议室、教室等空间对象的Id
        /// </summary>
        public virtual string LocationId { get; set; }
        /// <summary>
        /// 时间范围
        /// </summary>
        public virtual DateTimeRange Range { get; set; }
        /// <summary>
        /// 如果Range来自于时间模板，则记录关联的时间模板的节Id
        /// </summary>
        public virtual string RangeTemplateSetionId { get; set; }
        /// <summary>
        /// 预约的种类（"","Course", "Activity", "Meeting", ...）
        /// </summary>
        public virtual string EventType { get; set; }
        /// <summary>
        /// 用于区分多种来源(A,B,...)
        /// </summary>
        public virtual string Source { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 创建预约的人
        /// </summary>
        public virtual string CreateBy { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime CreateDate { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public virtual string AuditBy { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public virtual DateTime AuditDate { get; set; }
    }
}
