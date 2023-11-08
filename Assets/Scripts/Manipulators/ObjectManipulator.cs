using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UserInput))]
public class ObjectManipulator : MonoBehaviour
{
    protected UserInput _input;
    protected Transform _transform;

    protected virtual void Awake()
    {
        _input = GetComponent<UserInput>();
        _transform = transform;
    }
}
