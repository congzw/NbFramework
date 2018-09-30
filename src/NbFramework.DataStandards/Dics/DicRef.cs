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
        [NbRefField("学科")]
        public static string Subject = "Subject";
        [NbRefField("年级")]
        public static string Grade = "Grade";
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

    public static class Dic_SubjectCode
    {
        [NbRefField("语文")]
        public static string GS001 = "GS001";
        [NbRefField("数学")]
        public static string GS002 = "GS002";
        [NbRefField("物理")]
        public static string GS003 = "GS003";
        [NbRefField("化学")]
        public static string GS004 = "GS004";
        [NbRefField("政治")]
        public static string GS005 = "GS005";
        [NbRefField("历史")]
        public static string GS006 = "GS006";
        [NbRefField("地理")]
        public static string GS007 = "GS007";
        [NbRefField("生物")]
        public static string GS008 = "GS008";
        [NbRefField("英语")]
        public static string GS009 = "GS009";
        [NbRefField("日语")]
        public static string GS010 = "GS010";
        [NbRefField("俄语")]
        public static string GS011 = "GS011";
        [NbRefField("自然")]
        public static string GS012 = "GS012";
        [NbRefField("音乐")]
        public static string GS013 = "GS013";
        [NbRefField("体育")]
        public static string GS014 = "GS014";
        [NbRefField("美术")]
        public static string GS015 = "GS015";
        [NbRefField("劳技")]
        public static string GS016 = "GS016";
        [NbRefField("思想品德")]
        public static string GS017 = "GS017";
        [NbRefField("信息技术")]
        public static string GS018 = "GS018";
        [NbRefField("社会")]
        public static string GS019 = "GS019";
        [NbRefField("职业技术")]
        public static string GS020 = "GS020";
        [NbRefField("综合实践")]
        public static string GS021 = "GS021";
        [NbRefField("研究性学习")]
        public static string GS022 = "GS022";
        [NbRefField("社区服务与社会实践")]
        public static string GS023 = "GS023";
        [NbRefField("品德与社会")]
        public static string GS024 = "GS024";
        [NbRefField("品德与生活")]
        public static string GS025 = "GS025";
        [NbRefField("科学")]
        public static string GS026 = "GS026";
        [NbRefField("生活与科技")]
        public static string GS027 = "GS027";
        [NbRefField("体育与健康")]
        public static string GS028 = "GS028";
        [NbRefField("艺术")]
        public static string GS029 = "GS029";
        [NbRefField("劳动技术")]
        public static string GS030 = "GS030";
        [NbRefField("公共卫生教育")]
        public static string GS031 = "GS031";
        [NbRefField("心理健康教育")]
        public static string GS032 = "GS032";
        [NbRefField("健康教育")]
        public static string GS033 = "GS033";
        [NbRefField("汉语")]
        public static string GS034 = "GS034";
        [NbRefField("历史与社会")]
        public static string GS035 = "GS035";
        [NbRefField("思想政治")]
        public static string GS036 = "GS036";
        [NbRefField("通用技术")]
        public static string GS037 = "GS037";
        [NbRefField("艺术欣赏音乐")]
        public static string GS038 = "GS038";
        [NbRefField("艺术欣赏美术")]
        public static string GS039 = "GS039";
    }

    public static class Dic_GradeCode
    {
        [NbRefField("托班")]
        public static string GO0a0 = "GO0a0";
        [NbRefField("小班")]
        public static string GO0a1 = "GO0a1";
        [NbRefField("中班")]
        public static string GO0a2 = "GO0a2";
        [NbRefField("大班")]
        public static string GO0a3 = "GO0a3";
        [NbRefField("小学一年级")]
        public static string GO003 = "GO003";
        [NbRefField("小学二年级")]
        public static string GO004 = "GO004";
        [NbRefField("小学三年级")]
        public static string GO005 = "GO005";
        [NbRefField("小学四年级")]
        public static string GO006 = "GO006";
        [NbRefField("小学五年级")]
        public static string GO007 = "GO007";
        [NbRefField("小学六年级")]
        public static string GO008 = "GO008";
        [NbRefField("初中一年级")]
        public static string GO009 = "GO009";
        [NbRefField("初中二年级")]
        public static string GO010 = "GO010";
        [NbRefField("初中三年级")]
        public static string GO011 = "GO011";
        [NbRefField("初中四年级")]
        public static string GO01A = "GO01A";
        [NbRefField("高中一年级")]
        public static string GO012 = "GO012";
        [NbRefField("高中二年级")]
        public static string GO013 = "GO013";
        [NbRefField("高中三年级")]
        public static string GO014 = "GO014";
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