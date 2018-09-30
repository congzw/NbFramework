using NbFramework.Common;

namespace NbFramework.DataStandards.Dics
{
    public static class Dic_DicTypeCode
    {
        public static string OrgType = "OrgType";
        public static string Dic_DicTypeCode_OrgType(this GlobalRef globalRef)
        {
            return OrgType;
        }
        
        public static string Phase = "Phase";
        public static string Dic_DicTypeCode_Phase(this GlobalRef globalRef)
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

        public static string Dic_Phase_Phase0(this GlobalRef globalRef)
        {
            return Phase0;
        }
        public static string Dic_Phase_Phase1(this GlobalRef globalRef)
        {
            return Phase1;
        }
        public static string Dic_Phase_Phase2(this GlobalRef globalRef)
        {
            return Phase2;
        }
        public static string Dic_Phase_Phase3(this GlobalRef globalRef)
        {
            return Phase3;
        }
        public static string Dic_Phase_Phase4(this GlobalRef globalRef)
        {
            return Phase4;
        }
        public static string Dic_Phase_Phase5(this GlobalRef globalRef)
        {
            return Phase5;
        }
    }
}