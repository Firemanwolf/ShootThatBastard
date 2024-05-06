using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    protected enum elementType
    {
        water,
        fire
    }

    [SerializeField] protected elementType type;

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.TryGetComponent<Element>(out Element element))
        {
            if (type != element.type) Destroy(gameObject);
        }
    }
}
