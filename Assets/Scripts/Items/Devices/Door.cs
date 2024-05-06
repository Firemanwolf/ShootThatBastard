using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Devices
{
    private Collider2D hitBox;
    private SpriteRenderer sprite;
    [SerializeField] private  Sprite OpenSprite;
    [SerializeField] private Sprite CloseSprite;

    protected override void Awake()
    {
        base.Awake();
        hitBox = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        hitBox.enabled = !isOn;
        if (isOn)
        {
            sprite.sprite = CloseSprite;
        }
        else sprite.sprite = OpenSprite;
    }
}
