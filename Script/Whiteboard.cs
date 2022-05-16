using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    [HideInInspector]
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048,2048);
    [SerializeField] Texture2D defaultTexture;
    Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)(textureSize.y));
        /*texture.width = (int)textureSize.x; 
        texture.height = (int)textureSize.y; */
        r.material.mainTexture = texture;
    }
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            
            texture = new Texture2D((int)textureSize.x, (int)(textureSize.y));
            r.material.mainTexture = texture;
        }
    }
}
