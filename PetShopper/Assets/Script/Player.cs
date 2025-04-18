using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    public float _speed = 2.0f;
    public float _sprint = 7.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerTransform.Translate(Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime, Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _sprint; 
        }
        else{
            _speed = 2.0f; 
        }
    }
}
