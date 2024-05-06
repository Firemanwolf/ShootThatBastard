using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Electrical))]
public class Water : Element
{
    // Start is called before the first frame update
    void Start()
    {
        type = elementType.water;
    }
}
