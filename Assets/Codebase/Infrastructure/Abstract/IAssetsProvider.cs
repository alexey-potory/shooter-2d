using UnityEngine;

namespace Codebase.Infrastructure.Abstract
{
    public interface IAssetsProvider
    {
        TAsset GetAsset<TAsset>(string path) where TAsset : Object;
        TAsset[] GetAssets<TAsset>(string path) where TAsset : Object;
    }
}