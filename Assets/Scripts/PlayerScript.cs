using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;

    private HitIndicator hitIndicator;
    Rigidbody2D _rbody;

    public int health;
    public TMP_Text lives;

    [SerializeField] private Transform spriteVisual;
    [SerializeField] private float tiltAngle = 15f;
    [SerializeField] private float tiltSpeed = 10f;

    SceneManagerScript sceneManager;
    PlayerShooting shooting;

    public AudioClip _badHitEffect;

    AudioSource _audioSource;

    Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rbody = GetComponent<Rigidbody2D>();
        sceneManager = GetComponent<SceneManagerScript>();
        shooting = GetComponent<PlayerShooting>();
        hitIndicator = GetComponent<HitIndicator>();
        if (health <= 0)
        {
            health = 1;
        }
        UpdateLives();
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
            _audioSource.PlayOneShot(_badHitEffect);
            shooting.Shoot();
        }
    }

    void UpdateLives()
    {

        lives.text = "";
        for (int i = 0; i < health; i++)
        {
            lives.text += "<3 ";
            Debug.Log("i=" + i);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            hitIndicator.ShowHit();
            UpdateLives();
        }
        if (health <= 0) 
        {
            Destroy(gameObject);
        }

    }
}
