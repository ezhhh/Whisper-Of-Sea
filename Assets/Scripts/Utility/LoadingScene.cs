using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public Slider scale;
    public void Loading()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(1);
        loadAsync.allowSceneActivation = false;
        while(!loadAsync.isDone)
        {
            scale.value = loadAsync.progress;
            if(loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
