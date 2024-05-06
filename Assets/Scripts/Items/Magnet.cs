using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Devices
{
    [SerializeField] private float intensity;
    [SerializeField] private float fieldRadius;
    [SerializeField] private LayerMask target;
    private float distancetoPlayer;
    private Vector2 pullForce;

    private void Update()
    {
        if (isOn)
        {
            Collider2D temp = Physics2D.OverlapCircle(transform.position, fieldRadius, target);
            if (temp != null)
            {
                distancetoPlayer = Vector2.Distance(temp.transform.position, transform.position);
                pullForce = (transform.position - temp.transform.position).normalized / distancetoPlayer * intensity;
                temp.attachedRigidbody.AddForce(pullForce, ForceMode2D.Force);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, fieldRadius);
    }
}
