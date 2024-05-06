using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isOn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<Bullet>())
            isOn = !isOn;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Electrical>(out Electrical cable))
        {
            cable.isElectrical = isOn;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Electrical>(out Electrical cable))
        {
            cable.isElectrical = false;
        }
    }
}
