using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSpriteMovement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            ChangeSprite(upSprite);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            ChangeSprite(downSprite);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            ChangeSprite(rightSprite);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            ChangeSprite(leftSprite);
            spriteRenderer.flipX = false;
        }
        print("directional sprites is working");
    }
    void ChangeSprite(Sprite s)
    {
        spriteRenderer.sprite = s;
    }
}
