using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Followed tutorial by Muddy Wolf: https://www.youtube.com/watch?v=Tsha7rp58LI

public class DrawSlingLine : MonoBehaviour
{
    private LineRenderer lr;
    
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 start, Vector3 end) {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = start;
        points[1] = end;

        lr.SetPositions(points);
    }

    public void ClearLine() {
        lr.positionCount = 0;
    }
}
