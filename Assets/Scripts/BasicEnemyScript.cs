using Unity.VisualScripting;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{

    public float speed;
    Rigidbody2D _rbody;

    public SceneManagerScript sceneManager;

    SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (sceneManager == null)
        {
            sceneManager = FindAnyObjectByType<SceneManagerScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            sceneManager.HitEnemy();
            Destroy(gameObject);
        }
    }
}
