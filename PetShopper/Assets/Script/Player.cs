using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed = 2.0f;
    public float _sprint = 7.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
