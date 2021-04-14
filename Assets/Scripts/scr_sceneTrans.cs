using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scr_sceneTrans : MonoBehaviour
{
    public string sceneToLoad;
    public Animator transition;
    public float transitionTime = 1f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(LoadScene(sceneToLoad));
        }
    }

    IEnumerator LoadScene(string index)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }

}
