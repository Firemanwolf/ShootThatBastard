using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour
{
    [SerializeField] protected UnityEvent onDefeatEvent;
    [SerializeField] protected float health;
    public float criticalVelocity;
    public float HP
    {
        get =>health;
        set
        {
            health = value;
            if (value <= 0) 
            {
                onDefeatEvent?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.GetComponent<Bullet>())
        {
            TakeDamage( other.relativeVelocity.magnitude / criticalVelocity);
        }
    }

    public void TakeDamage(float dmg)
    {
        dmg = Mathf.RoundToInt(dmg);
        HP -= dmg;
    }
}
