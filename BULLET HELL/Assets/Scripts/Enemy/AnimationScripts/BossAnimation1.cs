using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation1 : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Sprite[] bossSprites; // Array of  boss sprites

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Calculate direction vector from boss to player
        Vector2 direction = (player.position - transform.position).normalized;

        // Calculate angle and map it to sprite index
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        int spriteIndex = Mathf.RoundToInt((angle + 180f) / 25.714f) % bossSprites.Length;

        // Update sprite
        spriteRenderer.sprite = bossSprites[spriteIndex];
    }
}
