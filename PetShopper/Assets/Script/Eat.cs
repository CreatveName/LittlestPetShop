using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Eat : MonoBehaviour
{
    public string dragTag = "Draggable";      // Tag to check for
    public AudioClip destroySound;              // Assign in Inspector
    public AudioSource audioSource;             // Drag an AudioSource here
    public string brushTag = "Soap";
    public static int brushCount = 0;
    public static TextMeshProUGUI brushText;

    private static float countCD = 0.1f;
    private static float lastCT = -999f;

    public Slider mySlider;

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
        mySlider.minValue = 0f;
        mySlider.maxValue = 100f;
        mySlider.value = mySlider.minValue;
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

        if(other.CompareTag(brushTag) && Time.time - lastCT > countCD && brushCount < mySlider.maxValue)
        {
            brushCount++;
            lastCT = Time.time;
            mySlider.value = brushCount;
            UpdateText();
        }
    }

    void UpdateText()
    {
        if (brushText != null)
        {
            brushText.text = brushCount + "%";
        }
    }
}