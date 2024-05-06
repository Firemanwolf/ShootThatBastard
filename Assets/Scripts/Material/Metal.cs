using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Electrical))]
public class Metal : Material
{
    private void Update()
    {
        Debug.Log(currentBS);
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        if(other.transform.TryGetComponent<Bullet>(out Bullet bullet))
        {
            other.transform.Rotate(new Vector3(0,0,180));
        }
    }
}
