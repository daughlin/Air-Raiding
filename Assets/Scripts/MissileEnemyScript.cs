using UnityEngine;

public class MissileEnemyScript : MonoBehaviour
{

    public int health;
    public SceneManagerScript sceneManager;

    public BasicEnemyShooting shooting;

    SpriteRenderer spriteRenderer;

    public float borderMargin = 0.5f;
    public float speed = 0.5f;

    private float minX;
    private float maxX;
    private int direction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (health <= 0)
        {
            health = 2;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (sceneManager == null)
        {
            sceneManager = FindAnyObjectByType<SceneManagerScript>();
        }

        Camera cam = Camera.main;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        float depth = cam.WorldToViewportPoint(transform.position).z;

        float leftEdge = cam.ViewportToWorldPoint(
            new Vector3(0f, 0.5f, depth)).x;

        float rightEdge = cam.ViewportToWorldPoint(
            new Vector3(1f, 0.5f, depth)).x;

        minX = leftEdge + borderMargin
            + (transform.position.x - sprite.bounds.min.x);

        maxX = rightEdge - borderMargin
            - (sprite.bounds.max.x - transform.position.x);

        direction = Random.Range(0, 2) == 0 ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (minX >= maxX) return;

        Vector3 position = transform.position;
        position.x += direction * speed * Time.deltaTime;

        if (position.x >= maxX)
        {
            position.x = maxX;
            direction = -1;
        }
        else if (position.x <= minX)
        {
            position.x = minX;
            direction = 1;
        }

        transform.position = position;
        shooting.Shoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player"))
        {
            sceneManager.HitEnemy();
            Destroy(gameObject);
        }
    }
}
