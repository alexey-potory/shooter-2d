using System;
using System.Collections;
using Codebase.Exceptions;
using Codebase.Infrastructure.Abstract;
using UnityEngine.SceneManagement;

namespace Codebase.Infrastructure.Implementation
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(string sceneName, bool forceReload, Action onLoaded = null) => 
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, forceReload, onLoaded));

        private static IEnumerator LoadScene(string nextSceneName, bool forceReload, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextSceneName && !forceReload)
            {
                onLoaded?.Invoke();
                yield break;
            }

            var waitForNextScene = SceneManager.LoadSceneAsync(nextSceneName);

            if (waitForNextScene == null)
                throw new SceneLoadingException();
            
            while (!waitForNextScene.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
    }
}