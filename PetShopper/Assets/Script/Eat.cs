using UnityEngine;

public class Eat : MonoBehaviour
{
    public string targetTag = "Draggable";      // Tag to check for
    public AudioClip destroySound;              // Assign in Inspector
    public AudioSource audioSource;             // Drag an AudioSource here

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            if (audioSource && destroySound)
            {
                audioSource.PlayOneShot(destroySound);
            }

            Destroy(other.gameObject);
        }
    }
}