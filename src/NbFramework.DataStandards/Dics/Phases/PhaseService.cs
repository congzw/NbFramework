using System.Collections.Generic;
using NbFramework.DataStandards.Core.DicItems;

namespace NbFramework.DataStandards.Dics.Phases
{
    public class PhaseService : IPhaseService
    {
        public IList<IDicItem> GetPhases(GetPhasesArgs args)
        {
            //todo
            throw new System.NotImplementedException();
        }
    }

    #region abstracts

    public interface IPhaseService
    {
        IList<IDicItem> GetPhases(GetPhasesArgs args);
    }

    public class GetPhasesArgs
    {
    }
    
    #endregion
}
