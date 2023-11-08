using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SpatialTracking;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class NonARSessionOrigin : MonoBehaviour
{
    [SerializeField] private Transform _cameraTargetTransform;
    [SerializeField] private Camera _camera;
    [SerializeField] private TrackedPoseDriver _trackedPoseDriver;
    [SerializeField] private Background _background;
    [SerializeField] private GameObject _prefabTemplate;

    private GameObject _prefab;
    private Transform _prefabParent;
    private bool _prefabWasNotInstantiated;
    
    private void OnEnable()
    {
        _trackedPoseDriver.enabled = false;

        _prefabWasNotInstantiated = false;
        _prefab = FindObjectOfType<ARPrefab>() ? FindObjectOfType<ARPrefab>().gameObject : null;
        
        if (!_prefab)
        {
            _prefab = Instantiate(_prefabTemplate);
            _prefabWasNotInstantiated = true;
        }

        _prefabParent = _prefab.transform.parent;
        _prefab.transform.parent = transform;
        _prefab.transform.rotation = Quaternion.identity;
        _prefab.transform.localScale = Vector3.one;
        _camera.transform.position = _cameraTargetTransform.position;
        _camera.transform.rotation = _cameraTargetTransform.rotation;
        
        Debug.Log($"Camera offset: {_camera.transform.position - _cameraTargetTransform.position}");
        Debug.Log($"Prefab position: {_prefab.transform.position}");
        
        _background.Enable();
    }

    private void OnDisable()
    {
        if (_prefabWasNotInstantiated)
        {
            Destroy(_prefab.gameObject);
        }
        else
        {
            _prefab.transform.parent = _prefabParent;
            _prefab.transform.localPosition = Vector3.zero;
            _prefab.transform.localRotation = Quaternion.identity;
            _prefab.transform.localScale = Vector3.one;
        }
        
        _trackedPoseDriver.enabled = true;
        _background.Disable();
    }
}
