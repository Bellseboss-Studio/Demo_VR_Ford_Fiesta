using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoIntroManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private SceneTransitionManager sceneManager;

    private void Start()
    {
        StartCoroutine(FinishingVideo());
    }

    private IEnumerator FinishingVideo()
    {
        yield return new WaitForSeconds((float) videoPlayer.clip.length + 1);
        sceneManager.GoToScene(1);
    }
}
