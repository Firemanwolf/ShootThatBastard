using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrical : MonoBehaviour
{
    public bool isElectrical = false;
    [SerializeField] private float electricDamage;

    private void OnTriggerStay2D(Collider2D other)
    {

        if (isElectrical)
        { 
            if(other.transform.TryGetComponent<Electrical>(out Electrical eletric))
            {
                eletric.isElectrical = true;
            }
            if (other.transform.TryGetComponent<Actor>(out Actor actor))
            {
                actor.TakeDamage(electricDamage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
            if (other.transform.TryGetComponent<Electrical>(out Electrical eletric))
            {
                eletric.isElectrical = false;
            }
    }
}
