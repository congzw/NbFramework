using System.Collections.Generic;
using NbFramework.DataStandards.Core.DicItems;

namespace NbFramework.DataStandards.Dics.OrgTypes
{
    public class OrgTypeService : IOrgTypeService
    {
        public IList<IDicItem> GetOrgTypes(GetOrgTypesArgs args)
        {
            //todo
            throw new System.NotImplementedException();
        }
    }

    #region abstracts

    public interface IOrgTypeService
    {
        IList<IDicItem> GetOrgTypes(GetOrgTypesArgs args);
    }

    public class GetOrgTypesArgs
    {
    }
    
    #endregion
}
