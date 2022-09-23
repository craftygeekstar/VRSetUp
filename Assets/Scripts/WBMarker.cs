using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WBMarker : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private int penSize = 5;

    private Renderer ren;
    private Color[] colors;
    private float tipHeight;

    private RaycastHit touch;
    private WhiteBoard whiteboard;
    private Vector2 touchPos;

    private bool touchedLastFrame;
    private Vector2 lastTouchPos;
    private Quaternion lastTouchRot;

    //public float arenaWidth, arenaHeight, arenaDepth;

    void Start()
    {
        ren = tip.GetComponent<Renderer>();
        colors = Enumerable.Repeat(ren.material.color, penSize * penSize).ToArray();
        tipHeight = tip.localScale.y;
    }

    void FixedUpdate()
    {
        Drawing();
    }

    public void Drawing()
    {   
        if (Physics.Raycast(tip.position, transform.up, out touch, tipHeight))
        {
            if(touch.transform.CompareTag("whiteboard"))
            {
                if (whiteboard == null)
                {
                    whiteboard = touch.transform.GetComponent<WhiteBoard>();
                }

                touchPos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                 // float number to pixel number on the texture resolution.
                 var x = (int)(touchPos.x * whiteboard.textureSize.x - (penSize/2));
                 var y = (int)(touchPos.y * whiteboard.textureSize.y - (penSize/2));

                 if (x < 0 || x > whiteboard.textureSize.x || y < 0 || y > whiteboard.textureSize.y)
                 {
                    return;
                 }

                if (touchedLastFrame)
                {
                    //Set the point where the marker has touched the whiteboard
                    whiteboard.texture.SetPixels(x, y, penSize, penSize, colors);
                    //interpolate the line so it's not just dots where you touch the whiteboard
                    for (float f = 0.0f; f < 1.00f; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(lastTouchPos.y, y, f);
                        whiteboard.texture.SetPixels(lerpX, lerpY, penSize, penSize, colors);
                    }

                    //lock the rotation of the marker when you touch the marker
                    //transform.rotation = lastTouchRot;

                    whiteboard.texture.Apply();
                }

                lastTouchPos = new Vector2(x, y);
                lastTouchRot = transform.rotation;
                touchedLastFrame = true;
                return;
            }
        }

        whiteboard = null;
        touchedLastFrame = false;
    }
}
