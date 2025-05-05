using UnityEngine;
using TMPro;

public class Eat : MonoBehaviour
{
    public string dragTag = "Draggable";      // Tag to check for
    public AudioClip destroySound;              // Assign in Inspector
    public AudioSource audioSource;             // Drag an AudioSource here
    public string brushTag = "Soap";
    public static int brushCount = 0;
    public static TextMeshProUGUI brushText;

    private void Start() 
    {
        if (brushText == null)
        {
            GameObject textObj = GameObject.Find("BrushCount"); // Must match name in Hierarchy
            if (textObj != null)
            {
                brushText = textObj.GetComponent<TextMeshProUGUI>();
                UpdateText(); // Initial display
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(dragTag))
        {
            if (audioSource && destroySound)
            {
                audioSource.PlayOneShot(destroySound);
            }

            Destroy(other.gameObject);
        }

        if(other.CompareTag(brushTag))
        {
            brushCount++;
            UpdateText();
        }
    }

    void UpdateText()
    {
        if (brushText != null)
        {
            brushText.text = "Brushes: " + brushCount;
        }
    }
}