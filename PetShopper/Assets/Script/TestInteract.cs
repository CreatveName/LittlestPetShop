using UnityEngine;

public class TestInteract : MonoBehaviour, IInteractable
{

    private bool isTriggered = false;
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (!isTriggered)
        {
            Debug.Log("Trigger Triggered");
            isTriggered = true;

            //PLACE LOGIC HERE: play dialouge code, open door, ...
            if (spriteRenderer != null && newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
            }
        }
    }

}
