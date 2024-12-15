using Codebase.Infrastructure.Abstract;
using UnityEngine;

namespace Codebase.Infrastructure.Implementation
{
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
    }
}