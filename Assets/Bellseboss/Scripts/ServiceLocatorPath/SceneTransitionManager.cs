using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour, ISceneTransition
{
    [SerializeField] private FadeAnimation fade;

    public void GoScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    private IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fade.FadeOut();
        var operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;
        var timer = 0f;
        while (timer <= fade.FadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }

    public void SetFade(FadeAnimation fadeAnimation)
    {
        fade = fadeAnimation;
    }
}