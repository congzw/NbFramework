using System;
using System.Collections.Generic;

namespace NbCloud.Domain.Timetables.Meetings
{
    /// <summary>
    /// 会议预约
    /// </summary>
    public class MeetingOrder : TimeOrder
    {
        public MeetingOrder()
        {
            Participants = new List<MeetingParticipant>();
        }
        /// <summary>
        /// 会议主题
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// 会议内容
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// 主持人
        /// </summary>
        public virtual string Host { get; set; }
        /// <summary>
        /// 参与者
        /// </summary>
        public virtual IList<MeetingParticipant> Participants { get; set; }
    }

    public class MeetingParticipant
    {
        public virtual Guid? UserId { get; set; }
        public virtual string UserLoginName { get; set; }
        public virtual string UserNickName { get; set; }
        public virtual string MeetingRole { get; set; } //Host, Guest, ...
    }
}
