using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel: Material
{
    [SerializeField] private int elementAmount;
    [SerializeField] private GameObject instance;
    [SerializeField] private Vector2 projectingForce;
    private int hitDirection;

    public override float HP 
    { get => base.HP;
        set {
            health = value;
            if (value < 0) StartCoroutine(ProjectileShoot());
        }  
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        hitDirection = (int)Mathf.Sign(other.GetContact(0).normal.x);
    }

    IEnumerator ProjectileShoot()
    {
        while (elementAmount> 0)
        {
            GameObject temp = Instantiate(instance, transform.position, Quaternion.identity);
            temp.SetActive(true);
            temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(projectingForce.x * -hitDirection, projectingForce.y));
            elementAmount--;
            yield return new WaitForSeconds(1);
        }
        if(elementAmount <= 0)
            Destroy(gameObject);
    }
}
