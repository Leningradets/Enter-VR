using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnimationSwitchButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        var animation = FindObjectOfType<RotationAndHoveringAnimation>();
        if (animation)
        {
            animation.enabled = !animation.enabled;
        }
    }
}
