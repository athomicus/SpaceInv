using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries 
{
    private Vector2 minBounds;
    private Vector2 maxBounds;
    
    public ScreenBoundaries()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0.1f,0.1f));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(0.9f,0.9f));
    }
    
   

    public Vector3 SetLimitedPosition(Vector3 position)
    {
        Vector3 newPos = new Vector3();
        newPos.x = Mathf.Clamp(position.x,minBounds.x,maxBounds.x);
        newPos.y = Mathf.Clamp(position.y,minBounds.y,maxBounds.y);
        return newPos;
    }

}
