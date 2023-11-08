using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : ObjectManipulator
{
    private void Update()
    {
        if (_input.IsRotating)
        {
            _transform.Rotate(Vector3.up, -_input.Rotation.x);
        }
    }
}
