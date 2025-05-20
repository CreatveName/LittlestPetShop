using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed = 4.0f;
    public float _sprint = 7.0f;
    private IInteractable currentInteractable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1){
            transform.Translate(0, Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime, 0);
        }else if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1){
            transform.Translate(Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime, 0, 0); 
        }
       
        if (Input.GetKey(KeyCode.LeftShift)){
            _speed = _sprint; 
        }else{
            _speed = 2.0f; 
        }

        if(currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            currentInteractable = interactable;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable) && interactable == currentInteractable)
        {
            currentInteractable = null;
        }
    }
}
