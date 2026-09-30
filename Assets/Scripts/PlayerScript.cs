using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    Rigidbody2D _rbody;

    SceneManagerScript sceneManager;
    PlayerShooting shooting;

    Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        sceneManager = GetComponent<SceneManagerScript>();
        shooting = GetComponent<PlayerShooting>();
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
}
