using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;

    public void OnMouseDown()
    {
        if (matched == false)
        {
            GameControl controlScript = gameControl.GetComponent<GameControl>();
            if (spriteRenderer.sprite == back)
            {
                if (controlScript.TokenUp(this))
                {
                    spriteRenderer.sprite = faces[faceIndex];
                    controlScript.CheckTokens();
                }
            }
            else
            {
                spriteRenderer.sprite = back;
                controlScript.TokenDown(this);
            }
        }
    }

    private void Awake()
    {
        gameControl = GameObject.Find("GameControl");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
