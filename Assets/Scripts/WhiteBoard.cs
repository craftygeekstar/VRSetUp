using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(x:2048, y:2018);


    void Start()
    {
        var ren = GetComponent<Renderer>();
        texture = new Texture2D(width:(int)textureSize.x, height:(int)textureSize.y);
        ren.material.mainTexture = texture;
    }

    
}
