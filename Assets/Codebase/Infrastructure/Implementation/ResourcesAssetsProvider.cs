using Codebase.Infrastructure.Abstract;
using UnityEngine;

namespace Codebase.Infrastructure.Implementation
{
    public class ResourcesAssetsProvider : IAssetsProvider
    {
        public TAsset GetAsset<TAsset>(string path) where TAsset : Object => 
            Resources.Load<TAsset>(path);

        public TAsset[] GetAssets<TAsset>(string path) where TAsset : Object => 
            Resources.LoadAll<TAsset>(path);
    }
}