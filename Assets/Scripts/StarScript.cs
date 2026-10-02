using UnityEngine;

public class StarScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D _rbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _rbody.AddForceY(-speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() //move star down at constant rate
    {
        
        //Vector3 position = transform.position;
        //position.y += -1 * speed * Time.deltaTime;
        //transform.position = position;
        if (transform.position.y <= -4)
        {
            Destroy(gameObject);
        }
    }
}
