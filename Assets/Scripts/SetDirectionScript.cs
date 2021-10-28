using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDirectionScript : MonoBehaviour
{
    public CompassDirection CurrentDirection;  
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            CurrentDirection = CompassDirection.North;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            CurrentDirection = CompassDirection.West;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            CurrentDirection = CompassDirection.South;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            CurrentDirection = CompassDirection.East;

        transform.rotation = Quaternion.Euler(0, 0, (int)CurrentDirection);
    }
}
