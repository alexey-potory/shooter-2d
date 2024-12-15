using System.Collections;
using UnityEngine;

namespace Codebase.Infrastructure.Abstract
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
    }
}