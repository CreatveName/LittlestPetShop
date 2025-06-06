using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwap : MonoBehaviour
{

    [SerializeField]
    private Animator sceneAnim;

    public string PlayerTag = "Player";
    public string SceneName;

    [SerializeField]
    private float timeToWait;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(PlayerTag))
        {
            StartCoroutine("LoadSceneWithTransition");
        }
    }

    public IEnumerator LoadSceneWithTransition()
    {
        sceneAnim.SetTrigger("Start");

        yield return new WaitForSeconds(timeToWait);

        SceneManager.LoadSceneAsync(SceneName);
    }

}
