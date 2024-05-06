using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devices : Material
{
    [SerializeField]protected bool isOn = false;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent<Electrical>(out Electrical cable))
        {
            Debug.Log("worked");
            if (cable.isElectrical)
            { 
                isOn = true;
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.TryGetComponent<Electrical>(out Electrical cable))
        {
            if(cable.isElectrical)
                isOn = false;
        }
    }
}
