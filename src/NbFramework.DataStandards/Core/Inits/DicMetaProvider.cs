namespace NbFramework.DataStandards.Core.Inits
{
    public interface IDicMetaProvider
    {
        DicMeta Create();
    }
    
    public abstract class BaseDicMetaProvider
    {
        
        ////var dicType = DicType.Create(Dic_DicType.OrgType, "组织类型", true, false);
        ////var dicMeta = DicMeta.Create(dicType);


        //var simpleJsonHelper = SimpleJsonHelper.Resolve();
        //var dicTypeCodeRefs = NbRefFieldValue.GetAllNbRefFieldStrings(typeof(Dic_DicType));
        //foreach (var nbRefFieldValue in dicTypeCodeRefs)
        //{
        //    var dicType = (DicType)simpleJsonHelper.Deserialize(nbRefFieldValue.ValueBag, typeof(DicType));
        //    //orgType.LogJson();
        //}


        //foreach (var nbRefFieldValue in dicTypeCodeRefs)
        //{
        //    var orgType = (DicType)simpleJsonHelper.Deserialize(nbRefFieldValue.ValueBag);
        //    dicMeta.DicType = orgType;
        //}
        //return dicMeta;
    }
}
