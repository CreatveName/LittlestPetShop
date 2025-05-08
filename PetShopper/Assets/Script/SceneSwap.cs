using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{

    public string PlayerTag = "Player";
    public string SceneName;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(PlayerTag))
        {
            SceneManager.LoadScene(SceneName);
        }
    }

}
