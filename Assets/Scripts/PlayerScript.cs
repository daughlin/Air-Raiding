using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    Rigidbody2D _rbody;

    public int health;

    [SerializeField] private Transform spriteVisual;
    [SerializeField] private float tiltAngle = 15f;
    [SerializeField] private float tiltSpeed = 10f;

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

    void LateUpdate()
    {
        float targetAngle = -moveDirection.x * tiltAngle;

        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

        spriteVisual.localRotation = Quaternion.Slerp(
            spriteVisual.localRotation,
            targetRotation,
            Time.deltaTime * tiltSpeed
        );
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
