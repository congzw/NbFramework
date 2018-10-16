using System;
using System.Collections.Generic;
using System.Linq;
using NbFramework.Common;
using NbFramework.Common.Data;

namespace NbCloud.Domain.Timetables
{
    /// <summary>
    /// 课节模板
    /// </summary>
    public class SectionTemplate : NbEntity<SectionTemplate>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SectionTemplate()
        {
            Init();
        }

        private void Init()
        {
            Sections = new List<Section>();
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 课节
        /// </summary>
        public virtual IList<Section> Sections { get; set; }

        /// <summary>
        /// 增加课节
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public virtual MessageResult AddSection(Section section)
        {
            var messageResult = new MessageResult();
            //忽略所有的年月日，只用默认时间
            section.DateTimeRange = section.DateTimeRange.FixDateTimeRangeOfDefaultDay();

            if (section.DateTimeRange.End <= section.DateTimeRange.Start)
            {
                messageResult.Success = false;
                messageResult.Message = "课节的结束时间不能小于开始时间！";
                return messageResult;
            }

            var overlaps = Sections.Any(x => x.DateTimeRange.Overlaps(section.DateTimeRange));
            if (overlaps)
            {
                messageResult.Success = false;
                messageResult.Message = "要添加的课节时间段发生冲突：" +
                    string.Format("{0} ~ {1}", section.DateTimeRange.Start.ToString("HH:mm:ss"),
                    section.DateTimeRange.End.ToString("HH:mm:ss"));
                return messageResult;
            }

            Sections.Add(section);
            section.SectionTemplate = this;

            messageResult.Message = "操作成功";
            messageResult.Success = true;
            messageResult.Data = section.Id;
            return messageResult;
        }

        /// <summary>
        /// 删除课节
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public virtual MessageResult RemoveSection(Section section)
        {
            var messageResult = new MessageResult();

            var theOne = Sections.SingleOrDefault(x => x.Id == section.Id);
            if (theOne != null)
            {
                Sections.Remove(theOne);
                theOne.SectionTemplate = null;
            }

            messageResult.Message = "操作成功";
            messageResult.Success = true;
            messageResult.Data = section.Id;
            return messageResult;
        }

        /// <summary>
        /// 快速创建天模板的工厂方法
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="beginTime"></param>
        /// <param name="blockCount"></param>
        /// <param name="spanMinutes"></param>
        /// <param name="restMinutes"></param>
        /// <returns></returns>
        public static SectionTemplate FastCreateSectionTemplateOfDay(string templateName, DateTime beginTime, int blockCount, int spanMinutes, int restMinutes)
        {
            NbGuard.MakeSureIsNotDefault(templateName);
            NbGuard.MakeSureIsNotDefault(beginTime);
            NbGuard.MakeSureIsNotDefault(blockCount);
            NbGuard.MakeSureIsNotDefault(spanMinutes);

            var sectionTemplate = new SectionTemplate();
            sectionTemplate.Id = GuidHelper.GenerateComb();
            sectionTemplate.Name = templateName;

            var currentBeginTime = beginTime;
            var blockSpan = spanMinutes + restMinutes;

            for (int i = 0; i < blockCount; i++)
            {
                var currentRange = DateTimeRange.CreateMinuteRange(currentBeginTime, blockSpan);
                var section = new Section()
                {
                    DateTimeRange = currentRange,
                    Title = string.Format("第{0}节", i + 1)
                };

                sectionTemplate.AddSection(section);
                currentBeginTime = currentBeginTime.AddMinutes(blockSpan);
            }

            return sectionTemplate;
        }

        /// <summary>
        /// 默认模板的工厂方法
        /// </summary>
        /// <returns></returns>
        public static SectionTemplate FastCreateSectionTemplateOfDay()
        {
            var sectionTemplate = new SectionTemplate();
            sectionTemplate.Name = "默认模板";

            var currentBeginTime = new DateTime(2000, 1, 1, 8, 0, 0);
            int spanMinutes = 45;
            int restMinutes = 10;
            var blockSpan = spanMinutes + restMinutes;

            //第1节 08:00 ~ 08:45 
            //第2节 09:00 ~ 09:45 
            //第3节 10:00 ~ 10:45 
            //第4节 11:00 ~ 11:45 
            //午休  12:00 ~ 13:00  
            //第5节 13:00 ~ 13:45 
            //第6节 14:00 ~ 14:45 
            //第7节 15:00 ~ 15:45 
            //第8节 16:00 ~ 16:45  

            for (int i = 0; i < 4; i++)
            {
                var currentRange = DateTimeRange.CreateMinuteRange(currentBeginTime, spanMinutes);
                var section = new Section()
                {
                    DateTimeRange = currentRange,
                    Title = string.Format("第{0}节", i + 1)
                };
                sectionTemplate.AddSection(section);

                currentBeginTime = currentBeginTime.AddMinutes(blockSpan);
            }

            currentBeginTime = new DateTime(2000, 1, 1, 14, 0, 0);

            for (int i = 5; i < 9; i++)
            {
                var currentRange = DateTimeRange.CreateMinuteRange(currentBeginTime, spanMinutes);
                var section = new Section()
                {
                    DateTimeRange = currentRange,
                    Title = string.Format("第{0}节", i)
                };
                sectionTemplate.AddSection(section);

                currentBeginTime = currentBeginTime.AddMinutes(blockSpan);
            }


            return sectionTemplate;
        }
    }

    /// <summary>
    /// 组成课节模板的课节
    /// </summary>
    public class Section : NbEntity<Section>
    {
        /// <summary>
        /// 课节模板
        /// </summary>
        public virtual SectionTemplate SectionTemplate { get; set; }

        /// <summary>
        /// 课节的标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 课节的开始结束时间
        /// </summary>
        public virtual DateTimeRange DateTimeRange { get; set; }
    }
}
