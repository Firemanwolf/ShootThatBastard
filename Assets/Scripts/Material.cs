 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Material : MonoBehaviour
{
    [SerializeField] protected GameObject fire;
    [SerializeField] protected float burningSeconds;
    public float criticalVelocity;
    protected float currentBS;
    [SerializeField]protected float health;
    public UnityAction<float> burningEvent;
    public virtual float HP
    {
        get => health;
        set
        {
            health = value;
            if(value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public float CurrentBS
    {
        get => currentBS;
        set
        {
            currentBS = value;
            if (value < 0)
            {
                Instantiate(fire, new Vector3(Random.Range(hitPosition.x-0.2f, hitPosition.x+0.3f),hitPosition.y, 0), Quaternion.identity);
                currentBS = burningSeconds;
            }
        }
    }

    public Vector2 hitPosition;

    protected virtual void Awake()
    {
        CurrentBS = burningSeconds;
        burningEvent += TakeDamage;
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.transform.GetComponent<Bullet>())
            TakeDamage((other.relativeVelocity.magnitude / criticalVelocity) * other.rigidbody.mass / other.otherRigidbody.mass);
    }

    public void TakeDamage(float dmg)
    {
        dmg = Mathf.RoundToInt(dmg);
        HP -= dmg;
    }
}
