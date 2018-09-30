using System.Collections.Generic;
using System.Linq;
using NbFramework.Common;

namespace NbFramework.DataStandards.Dics
{
    //todo auto create spces docs
    public static class Dic_DicTypeCode
    {
        [NbRefField("组织类型")]
        public static string OrgType = "OrgType";
        [NbRefField("学段")]
        public static string Phase = "Phase";
    }

    public static class Dic_DicRelationCode
    {
        [NbRefField("组织类型-学段")]
        public static string OrgTypePhase = "OrgType.Phase";
        //[NbRefField("学段-学科")]
        //public static string PhaseSubject = "Phase.Subject";
        //[NbRefField("学段-年级")]
        //public static string PhaseGrade = "Phase.Grade";
        //[NbRefField("学段-学科-年级")]
        //public static string PhaseSubjectGrade = "Phase.Subject.Grade";
    }

    public static class Dic_OrgTypeCode
    {
        [NbRefField("教育局")]
        public static string JiaoYuJu = "JiaoYuJu";
        [NbRefField("科室")]
        public static string JiGou_KeShi = "JiGou-KeShi";
        [NbRefField("幼儿园")]
        public static string XueXiao_111 = "XueXiao-111";
        [NbRefField("教学点")]
        public static string XueXiao_218 = "XueXiao-218";
        [NbRefField("小学")]
        public static string XueXiao_211 = "XueXiao-211";
        [NbRefField("初中")]
        public static string XueXiao_311 = "XueXiao-311";
        [NbRefField("高中")]
        public static string XueXiao_342 = "XueXiao-342";
        [NbRefField("完全中学")]
        public static string XueXiao_341 = "XueXiao-341";
        [NbRefField("九年一贯制")]
        public static string XueXiao_312 = "XueXiao-312";
        [NbRefField("十二年一贯制")]
        public static string XueXiao_345 = "XueXiao-345"; 
    }
    
    public static class Dic_PhaseCode
    {
        [NbRefField("幼儿园")]
        public static string Phase0 = "Phase0"; //幼
        [NbRefField("小学")]
        public static string Phase1 = "Phase1"; //小
        [NbRefField("初中")]
        public static string Phase2 = "Phase2"; //初
        [NbRefField("高中")]
        public static string Phase3 = "Phase3"; //高
        //[NbRefField("专本")]
        //public static string Phase4 = "Phase4"; //专,本
        //[NbRefField("研究生")]
        //public static string Phase5 = "Phase5"; //研
    }

    public static class Dic_OrgTypePhase
    {
        [NbRefField("教育局.*")]
        public static string JiaoYuJu_Phases = "JiaoYuJu.*";
        [NbRefField("科室.*")]
        public static string JiGou_KeShi_Phases = "JiGou-KeShi.*";
        [NbRefField("幼儿园.幼")]
        public static string XueXiao_111_Phases = "XueXiao-111.Phase0";
        [NbRefField("教学点.小")]
        public static string XueXiao_218_Phases = "XueXiao-218.Phase1";
        [NbRefField("小学.小")]
        public static string XueXiao_211_Phases = "XueXiao-211.Phase1";
        [NbRefField("初中.初")]
        public static string XueXiao_311_Phases = "XueXiao-311.Phase2";
        [NbRefField("高中.高")]
        public static string XueXiao_342_Phases = "XueXiao-342.Phase3";
        [NbRefField("完全中学.初,高")]
        public static string XueXiao_341_Phases = "XueXiao-341.Phase2,Phase3";
        [NbRefField("九年一贯制.小,初")]
        public static string XueXiao_312_Phases = "XueXiao-312.Phase1,Phase2";
        [NbRefField("十二年一贯制.小,初,高")]
        public static string XueXiao_345_Phases = "XueXiao-345.Phase1,Phase2,Phase3"; 
    }

    /// <summary>
    /// 学段简称对应码
    /// </summary>
    internal class ShortPhaseDic : Dictionary<string, string>
    {
        private ShortPhaseDic()
        {
            this.Add("幼", "Phase0");
            this.Add("小", "Phase1");
            this.Add("初", "Phase2");
            this.Add("高", "Phase3");
            //this.Add("本", "Phase4");
            //this.Add("研", "Phase5");
        }

        internal static readonly ShortPhaseDic Instance = new ShortPhaseDic();
        internal IList<string> ConvertPhaseCodesFromNamesValue(string phaseNamesValue)
        {
            var phaseNames = SplitString(phaseNamesValue);
            if (phaseNames.Contains("*"))
            {
                return this.Values.ToList();
            }
            return phaseNames.Select(phaseName => this[phaseName]).ToList();
        }
        private static string[] SplitString(string value)
        {
            return string.IsNullOrWhiteSpace(value) ?
                new string[] { } : value.Split(_separator);
        }
        private static readonly char[] _separator = { ',', '，', '；', ';' };
    }
}