using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    float _speed = 5;

    [SerializeField]
    Transform _groundCheckPoint;
    bool _isGrounded;
    [SerializeField]
    Transform _frontGroundPoint;
    bool _isThereGroundToStepOn;

    [SerializeField]
    Transform _frontObstaclePoint;
    bool _isThereAnyObstacle;

    [SerializeField]
    LayerMask _groundLayers;

    private PlayerDetection playerDetection;

    Animator _animator;

    Rigidbody2D _rigidbody;

    private bool canmove = true;
    // Start is called before the first frame update
    void Start()
    {
        playerDetection = FindObjectOfType<PlayerDetection>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _isGrounded = Physics2D.Linecast(_groundCheckPoint.position, _groundCheckPoint.position + Vector3.down * .95f, _groundLayers);
        _isThereGroundToStepOn = Physics2D.Linecast(_groundCheckPoint.position, _frontGroundPoint.position, _groundLayers);
        _isThereAnyObstacle = Physics2D.Linecast(_groundCheckPoint.position, _frontObstaclePoint.position, _groundLayers);

       
         if (_isGrounded)
        {
            if (!_isThereGroundToStepOn || _isThereAnyObstacle)
            {
                ChangeDirection();
            }
           
            Move();
        }

        if (Mathf.Abs(_rigidbody.velocity.x) > 0.1f)
        {
            _animator.SetInteger("State", (int)AnimationState.WALK);
        }

        if (Input.GetKey(KeyCode.M))
        {
            _animator.SetInteger("State", (int)EnemyAnimationState.ENEMYDIE);
        }
        if (Input.GetKey(KeyCode.N))
        {
            _animator.SetInteger("State", (int)EnemyAnimationState.ENEMYATTACK);
        }

       
       
    }


    //void MoveTowardsPlayer()
    //{
    //    // Calculate the direction to the player
    //    Vector3 playerDirection = playerDetection.playerTransform.position - transform.position;

    //    // Change the direction based on the player's position
    //    transform.localScale = new Vector3(Mathf.Sign(playerDirection.x), 1, 1);

    //    // Move towards the player
    //    transform.position += playerDirection.normalized * _speed * Time.fixedDeltaTime;
    //}


    void Move()
    {
        transform.position += Vector3.left * transform.localScale.x * _speed;
    }

    void ChangeDirection()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(_groundCheckPoint.position, _groundCheckPoint.position + Vector3.down * .95f, Color.green, .001f);
        Debug.DrawLine(_groundCheckPoint.position, _frontGroundPoint.position, Color.green, .001f);
        Debug.DrawLine(_groundCheckPoint.position, _frontObstaclePoint.position, Color.green, .001f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            _animator.SetInteger("State", (int)EnemyAnimationState.ENEMYDIE);
            Destroy(collision.gameObject); // Destroy the bullet
            float delay = _animator.GetCurrentAnimatorClipInfo(0).Length; // Get the length of the current animation
            Invoke("DestroyEnemy", delay);

            ScoreSystem.Instance.ScoreValue += 100;

            // Update the UI text
            ScoreSystem.Instance.UpdateEnergyTextLabel();
        }
        if(collision.CompareTag("Player"))
        {
            _animator.SetInteger("State", (int)EnemyAnimationState.ENEMYATTACK);
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject); // Destroy the enemy
    }


}
