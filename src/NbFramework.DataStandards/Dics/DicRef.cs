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
        [NbRefField("专本")]
        public static string Phase4 = "Phase4"; //专,本
        [NbRefField("研究生")]
        public static string Phase5 = "Phase5"; //研
    }
}