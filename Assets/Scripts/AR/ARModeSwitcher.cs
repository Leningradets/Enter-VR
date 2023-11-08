using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARModeSwitcher : MonoBehaviour
{
    [SerializeField] private ARSession _arSession;
    [SerializeField] private NonARSessionOrigin _nonARSessionOrigin;
    
    public void Switch()
    {
        _arSession.enabled = !_arSession.enabled;
        _nonARSessionOrigin.enabled = !_nonARSessionOrigin.enabled;
    }
}
