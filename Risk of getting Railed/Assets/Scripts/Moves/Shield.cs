using System;
using UnityEngine;

public class Shield : Move {
    public int shield = 1;
    public Shield(float dmgMult = 1) : base("Shield", 4) {
        shield = (int)Math.Ceiling(shield * dmgMult);
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        Texture2D texture = Resources.Load<Texture2D>("Shield");
        Sprite shieldSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

        GameObject shieldObject = new GameObject("Shield");
        SpriteRenderer spriteRenderer = shieldObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = shieldSprite;
        spriteRenderer.color = new Color(255, 255, 255, 0.4f);

        spriteRenderer.sortingOrder = 30;
        spriteRenderer.transform.localScale = new Vector3(1, 1, 1);
        Unit player = GameObject.Find("Player").GetComponent<Unit>();
        shieldObject.transform.position = new Vector3(performer.transform.localPosition.x, performer.transform.localPosition.y, 0);
        shieldObject.transform.SetParent(performer.transform);

        performer.CurrentShield += shield;

        return true;
    }
}