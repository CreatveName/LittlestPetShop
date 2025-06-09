using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed = 4.0f;
    public float _sprint = 7.0f;
    private IInteractable currentInteractable;

    [SerializeField] 
    private Animator pAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InteractDialogue();
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        PlayerMovement();
        pAnim.SetFloat("Speed", Input.GetAxisRaw("Horizontal"));
        pAnim.SetFloat("SpeedUp", Input.GetAxisRaw("Vertical"));
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

    private void PlayerMovement()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            pAnim.SetBool("Left", false);
            pAnim.SetBool("Right", false);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                pAnim.SetBool("Up", true);
                pAnim.SetBool("Down", false);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                pAnim.SetBool("Down", true);
                pAnim.SetBool("Up", false);
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                pAnim.SetBool("Up", false);
                pAnim.SetBool("Down", false);
            }

            transform.Translate(0, Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime, 0);
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            pAnim.SetBool("Up", false);
            pAnim.SetBool("Down", false);

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                pAnim.SetBool("Right", true);
                pAnim.SetBool("Left", false);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                pAnim.SetBool("Left", true);
                pAnim.SetBool("Right", false);
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                pAnim.SetBool("Right", false);
                pAnim.SetBool("Left", false);
            }

            transform.Translate(Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _sprint;
        }
        else
        {
            _speed = 2.0f;
        }

    }

    private void InteractDialogue()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }
}
