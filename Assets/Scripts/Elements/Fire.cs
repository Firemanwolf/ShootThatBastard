using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{
    [SerializeField] private float lastSeconds;
    [SerializeField] private float burningDamage;
    [SerializeField] private float burningRadius;
    [SerializeField] private LayerMask target;

    void Start()
    {
        type = elementType.fire;
    }

    private void Update()
    {
        lastSeconds -= Time.deltaTime;
        if (lastSeconds < 0) Destroy(gameObject);
        Collider2D temp = Physics2D.OverlapCircle(transform.position, burningRadius, target);
        if (temp != null)
        {
            if (temp.transform.TryGetComponent<Material>(out Material material))
            {
                material.hitPosition = temp.ClosestPoint(transform.position);
                material.CurrentBS -= Time.deltaTime;
                if (material.CurrentBS < 0.02) 
                {
                    material.burningEvent(burningDamage);
                }
            }
            if (temp.transform.TryGetComponent<Actor>(out Actor actor))
            {
                actor.TakeDamage( burningDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, burningRadius);
    }
}
