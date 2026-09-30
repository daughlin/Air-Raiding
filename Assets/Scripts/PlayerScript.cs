using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    Rigidbody2D _rbody;

    public int health;

    SceneManagerScript sceneManager;
    PlayerShooting shooting;

    Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        sceneManager = GetComponent<SceneManagerScript>();
        shooting = GetComponent<PlayerShooting>();
        if (health <= 0)
        {
            health = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (!sceneManager.GameOver())
        //{
            _rbody.linearVelocity = moveDirection * speed;
        //}
        //else
        //{
        //    _rbody.linearVelocity = Vector2.zero;
        //}
    }

    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
        Debug.Log($"Movement input: {moveDirection}");
    }

    void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            shooting.Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }
        if (health <= 0) 
        {
            Destroy(gameObject);
        }

    }
}
