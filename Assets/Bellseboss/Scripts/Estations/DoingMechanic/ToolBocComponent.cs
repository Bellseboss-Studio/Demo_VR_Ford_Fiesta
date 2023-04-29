using System;
using System.Collections;
using UnityEngine;

public class ToolBocComponent : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip soundFxForBox;
    [SerializeField] private Animator anim;

    private bool isFinishedAnimation;

    private bool isTouchedTheBox;
    internal bool IsAnimationToOpenToolBoxFinished()
    {
        return isFinishedAnimation;
    }

    internal bool IsToolBoxTouched()
    {
        return isTouchedTheBox;
    }

    internal void StartAnimationToOpenBox()
    {
        anim.SetBool("open", true);
        StartCoroutine(FinishAnimation());
    }

    internal void StartSoundForWatch()
    {
        source.clip = soundFxForBox;
        source.loop = true;
        source.volume = 1;
        source.Play();
    }

    private IEnumerator FinishAnimation(){
        yield return new WaitForSeconds(2);
        isFinishedAnimation = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Hand")){
            isTouchedTheBox = true;
        }
    }
}