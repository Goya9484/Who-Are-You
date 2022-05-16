using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WhiteBoardMarker : MonoBehaviour
{
    [SerializeField] Transform tip;
    [SerializeField] int penSize = 5;

    Renderer penRender;
    Color[] colors;
    float tipHeight;

    RaycastHit hit;
    Whiteboard whiteboard;
    Vector2 touchPos, lastTouchPos;
    bool touchedLastFrame = false;
    Quaternion lastTouchRot;

    // Start is called before the first frame update
    void Start()
    {
        whiteboard = new Whiteboard();
        penRender = tip.GetComponent<Renderer>();
        colors = Enumerable.Repeat(penRender.material.color, penSize * penSize).ToArray();
        tipHeight = tip.localScale.y + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }
    void Draw()
    {
        
        if (Physics.Raycast(tip.position, -transform.forward, out hit, tipHeight) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (hit.transform.CompareTag("Whiteboard"))
            {
                if (whiteboard == null)
                {
                    whiteboard = hit.transform.GetComponent<Whiteboard>();
                }
            }
            touchPos = new Vector2(hit.textureCoord.x, hit.textureCoord.y);
            int x = (int)(touchPos.x * whiteboard.textureSize.x - (penSize / 2));
            int y = (int)(touchPos.y * whiteboard.textureSize.y - (penSize / 2));
            Vector2 vec = new Vector2(x, y);
            
            if (y < 0 || y > whiteboard.textureSize.y || x < 0 || x > whiteboard.textureSize.x)
                return;
            if (touchedLastFrame)
            {
                whiteboard.texture.SetPixels(x, y, penSize, penSize, colors);

                for(float f = 0.01f; f <= 1.0f; f += 0.01f)
                {
                    var lerpx = (int)Mathf.Lerp(lastTouchPos.x, x, f);
                    var lerpy = (int)Mathf.Lerp(lastTouchPos.y, y, f);
                    whiteboard.texture.SetPixels(lerpx, lerpy, penSize, penSize, colors);
                }

                //transform.rotation = lastTouchRot;
                whiteboard.texture.Apply();
            }

            Vector2 prevPos = new Vector2(x, y);
            lastTouchPos = prevPos;
            //lastTouchRot = transform.rotation;
            touchedLastFrame = true;
            return;
        }

        whiteboard = null;
        touchedLastFrame = false;
    }
}
