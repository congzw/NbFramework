using NbFramework.Common;

namespace NbFramework.DataStandards.Dics
{
    public static class Dic_DicTypeCode
    {
        public static string OrgType = "OrgType";
        public static string Dic_DicTypeCode_OrgType(this NbRef nbRef)
        {
            return OrgType;
        }
        
        public static string Phase = "Phase";
        public static string Dic_DicTypeCode_Phase(this NbRef nbRef)
        {
            return Phase;
        }
    }
    
    //todo auto create spces docs.
    //todo auto wave by complier?
    public static class Dic_PhaseCode
    {
        public static string Phase0 = "Phase0"; //幼
        public static string Phase1 = "Phase1"; //小
        public static string Phase2 = "Phase2"; //初
        public static string Phase3 = "Phase3"; //高
        public static string Phase4 = "Phase4"; //本
        public static string Phase5 = "Phase5"; //研

        public static string Dic_Phase_Phase0(this NbRef nbRef)
        {
            return Phase0;
        }
        public static string Dic_Phase_Phase1(this NbRef nbRef)
        {
            return Phase1;
        }
        public static string Dic_Phase_Phase2(this NbRef nbRef)
        {
            return Phase2;
        }
        public static string Dic_Phase_Phase3(this NbRef nbRef)
        {
            return Phase3;
        }
        public static string Dic_Phase_Phase4(this NbRef nbRef)
        {
            return Phase4;
        }
        public static string Dic_Phase_Phase5(this NbRef nbRef)
        {
            return Phase5;
        }
    }

    public static class Dic_OrgTypeCode
    {
        [NbRefField("教育局")]
        public const string JiaoYuJu = "JiaoYuJu";
        [NbRefField("科室")]
        public const string JiGou_KeShi = "JiGou-KeShi";
        [NbRefField("幼儿园")]
        public const string XueXiao_111 = "XueXiao-111";
        [NbRefField("教学点")]
        public const string XueXiao_218 = "XueXiao-218";
        [NbRefField("小学")]
        public const string XueXiao_211 = "XueXiao-211";
        [NbRefField("初中")]
        public const string XueXiao_311 = "XueXiao-311";
        [NbRefField("高中")]
        public const string XueXiao_342 = "XueXiao-342";
        [NbRefField("完全中学")]
        public const string XueXiao_341 = "XueXiao-341";
        [NbRefField("九年一贯制")]
        public const string XueXiao_312 = "XueXiao-312";
        [NbRefField("十二年一贯制")]
        public const string XueXiao_345 = "XueXiao-345";  


    }
}