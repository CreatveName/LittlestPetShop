using UnityEngine;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField]
    private Animator sceneAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("LoadSceneWithTransition");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadSceneWithTransition()
    {
        sceneAnim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
    }

}
