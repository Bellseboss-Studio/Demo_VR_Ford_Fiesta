using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoIntroManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    private void Start()
    {
        StartCoroutine(FinishingVideo());
    }

    private IEnumerator FinishingVideo()
    {
        yield return new WaitForSeconds((float) videoPlayer.clip.length + 1);
        ServiceLocator.Instance.GetService<ISceneTransition>().GoScene(1);
    }
}
