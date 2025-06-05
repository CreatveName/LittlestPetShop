using Unity.Cinemachine;
using UnityEngine;


public class NPCBounds : MonoBehaviour
{
    private Vector3 directionVector;
    private Transform npcTransform;
    private Rigidbody2D npcRigidbody;
    private bool _canMove = true;
    private bool _isMoving;
    public Collider2D _bound;
    public float _speed;
    public float _minMoveTime;
    public float _maxMoveTime;
    private float _moveTimeSeconds;
    public float _minWaitTime;
    public float _maxWaitTime;
    private float _waitTimeSeconds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveTimeSeconds = Random.Range(_minMoveTime, _maxMoveTime);
        _waitTimeSeconds = Random.Range(_minWaitTime, _maxWaitTime);
        npcTransform = GetComponent<Transform>();
        npcRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isMoving)
        {
            _moveTimeSeconds -= Time.deltaTime;
            if(_moveTimeSeconds <= 0)
            {
                _moveTimeSeconds = Random.Range(_minMoveTime, _maxMoveTime);
                _isMoving = false;
            }
            if (_canMove == true)
            {
                Move();
            }
        }
        else
        {
            _waitTimeSeconds -= Time.deltaTime;
            if(_waitTimeSeconds <= 0)
            {
                ChooseDifferentDirection();
                _waitTimeSeconds = Random.Range(_minWaitTime, _maxWaitTime);
                _isMoving = true;
            }
        }
    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();

        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }

    private void Move()
    {
        Vector3 movePosition = npcTransform.position + directionVector * _speed * Time.deltaTime;
        if (_bound.bounds.Contains(movePosition))
        {
            npcRigidbody.MovePosition(movePosition);
        }
        else
        {
            ChangeDirection();
        }
        
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch(direction)
        {
            case 0:
                directionVector = Vector3.right;
                break;
            case 1:
                directionVector = Vector3.up;
                break;
            case 2:
                directionVector = Vector3.left;
                break;
            case 3:
                directionVector = Vector3.down;
                break;
            case 4:
                break;
            default:
                break;
        }
    }
    void UpdateAnimation()
    {
        //WIP
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChooseDifferentDirection();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            _canMove = false; 
        }
        else
        {
            _canMove = true; 
        }
    }
}
