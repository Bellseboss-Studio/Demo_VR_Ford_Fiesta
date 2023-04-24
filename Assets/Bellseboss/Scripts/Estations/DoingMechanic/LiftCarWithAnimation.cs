using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftCarWithAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool isFinishedTheAnimation;

    public void StartLift(){
        anim.SetBool("lift", true);
        StartCoroutine(IsFinishedAnimation());
    }
    
    public void EndLift(){
        anim.SetBool("lift", false);
        StartCoroutine(IsFinishedAnimation());
    }

    public bool IsFinishedTheAnimation => isFinishedTheAnimation;

    private IEnumerator IsFinishedAnimation(){
        isFinishedTheAnimation = false;
        yield return new WaitForSeconds(1);
        isFinishedTheAnimation = true;
    }

}
