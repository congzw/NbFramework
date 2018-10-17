using System;

namespace NbCloud.Domain.Timetables.Courses
{
    /// <summary>
    /// 课程预约
    /// </summary>
    public class CourseOrder : TimeOrder
    {
        /// <summary>
        /// 课程的名称
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// 站点Id
        /// </summary>
        public virtual Guid SiteId { get; set; }
        /// <summary>
        /// 组织Id
        /// </summary>
        public virtual Guid OrgId { get; set; }
        /// <summary>
        /// 预约所属者（谁去上课）
        /// </summary>
        public virtual Guid TeacherId { get; set; }
        /// <summary>
        /// 教师名称
        /// </summary>
        public virtual string TeacherName { get; set; }

        /// <summary>
        /// 课节所属学科
        /// </summary>
        public virtual string SubjectCode { get; set; }
        /// <summary>
        /// 课节所属年级
        /// </summary>
        public virtual string GradeCode { get; set; }
        /// <summary>
        /// 课节所属学段
        /// </summary>
        public virtual string PhaseCode { get; set; }

        /// <summary>
        /// 存放物理文件的模块(例如ktpj,zdkt...)
        /// </summary>
        public virtual string CreateAppCode { get; set; }
        /// <summary>
        /// 课程接收人的账号（一般是预约人的账号）
        /// </summary>
        public virtual string AppRevicerDefine { get; set; }
        /// <summary>
        /// 应用于哪个模块
        /// </summary>
        public virtual string ApplyAppCode { get; set; }
    }
}