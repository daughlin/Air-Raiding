using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingProjectile : MonoBehaviour
{
    public float turnSpeed = 25f;

    private Rigidbody2D rb;
    private Transform player;
    private Vector2 direction;
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Use the velocity assigned by the enemy's Shoot() method.
        speed = rb.linearVelocity.magnitude;
        direction = rb.linearVelocity.normalized;

        GameObject target = GameObject.FindGameObjectWithTag("Player");

        if (target != null)
        {
            player = target.transform;
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 toPlayer = (Vector2)player.position - rb.position;

            if (toPlayer.sqrMagnitude > 0.001f)
            {
                float angle = Vector2.SignedAngle(direction, toPlayer);
                float maxTurn = turnSpeed * Time.fixedDeltaTime;
                float turn = Mathf.Clamp(angle, -maxTurn, maxTurn);

                direction = (Vector2)(
                    Quaternion.Euler(0f, 0f, turn) * direction
                );
            }
        }

        rb.linearVelocity = direction.normalized * speed;
        float missileAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.SetRotation(missileAngle - 90f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}