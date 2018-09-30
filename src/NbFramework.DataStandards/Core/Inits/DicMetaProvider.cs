using System.Collections.Generic;
using NbFramework.Common;
using NbFramework.DataStandards.Core.DicTypes;
using NbFramework.DataStandards.Dics;

namespace NbFramework.DataStandards.Core.Inits
{
    public interface IDicMetaProvider
    {
        DicMeta Create();
    }
    
    public abstract class BaseDicMetaProvider
    {
        
    }
}
