using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotationAndHoveringAnimation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 60;
    [SerializeField] private float _hoveringAmplitude = 0.1f;
    [SerializeField] private float _hoveringSpeed = 0.5f;
    
    private void Update()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        transform.localPosition = new Vector3(0,(Mathf.Cos(Time.time * _hoveringSpeed) + 1) * 0.5f * _hoveringAmplitude, 0);
    }
}
