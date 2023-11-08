using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : ObjectManipulator
{
    private void Update()
    {
        if (_input.IsPinched)
        {
            _transform.localScale *= _input.Pinch;
        }
    }
}
