using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class EmisorComponent : MonoBehaviour{
    private Animator anim;
    private void Awake() {
        anim = GetComponent<Animator>();
    }
    private void OnEnable() {
        anim.SetBool("activate", true);
    }

    public void Disable(){
        //This animation should dutation less of wait for seconds
        anim.SetBool("activate", false);
        StartCoroutine(DisableAsync());
    }

    private IEnumerator DisableAsync(){
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}