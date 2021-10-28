using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    public float Distance;
    public LayerMask RaycastLayer;
    public GameObject point;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, Distance, RaycastLayer.value);

        if (hit.point == Vector2.zero)
        {
            Debug.DrawRay(transform.position, transform.up * Distance, Color.cyan);

        }

        else
        {
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
            point.transform.position = hit.point;
        }

    }
}
