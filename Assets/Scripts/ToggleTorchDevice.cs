using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTorchDevice : MonoBehaviour {

    private bool _isOn = false;
    public GameObject light;

    private void Start()
    {
        light.SetActive(false);
    }

    public void Operate()
    {
        if (_isOn)
            light.SetActive(false);
        else
            light.SetActive(true);
        _isOn = !_isOn;
    }
	
}
