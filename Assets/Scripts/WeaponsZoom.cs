using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamerea;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomInFOV = 15f;

    bool zommedInToggle = false;
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zommedInToggle == false)
            {
                zommedInToggle = true;
                fpsCamerea.fieldOfView = zoomInFOV;
            }
            else
            {
                zommedInToggle = false;
                fpsCamerea.fieldOfView = zoomOutFOV;
            }
        }
    }
}
