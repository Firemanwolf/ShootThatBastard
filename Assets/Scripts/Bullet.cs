using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rgBody;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationTime;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float stuntSeconds;
    public float speed;
    private bool isColliding;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        rgBody = GetComponent<Rigidbody2D>();
        rgBody.velocity = transform.right * speed;
    }

    private void Update()
    {
        if (rgBody.velocity.magnitude < 0.12) Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (!isColliding)
        {
            speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime / accelerationTime);
            rgBody.velocity = transform.right * speed;
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(transform.forward * rotationSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.forward * -rotationSpeed);
            }
        }
        else StartCoroutine(Stunning());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        speed = rgBody.velocity.magnitude;
        if (collision.transform.TryGetComponent<Material>(out Material material))
        {
            material.TakeDamage(collision.relativeVelocity.magnitude / material.criticalVelocity);
        }
        if (collision.transform.TryGetComponent<Actor>(out Actor actor))
        {
            actor.TakeDamage(collision.relativeVelocity.magnitude / actor.criticalVelocity);
        }
    }

    IEnumerator Stunning()
    {
        yield return new WaitForSeconds(stuntSeconds);
        isColliding = false;
    }
}
