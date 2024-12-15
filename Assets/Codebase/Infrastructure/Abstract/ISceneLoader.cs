using System;

namespace Codebase.Infrastructure.Abstract
{
    public interface ISceneLoader
    {
        void Load(string sceneName, bool forceReload, Action onLoaded = null);
    }
}