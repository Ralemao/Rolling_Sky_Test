using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : Singleton<TouchManager>
{

    void Update()
    {
        CheckTouchCount();
    }

    private void CheckTouchCount()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = transform.position.z;
            transform.position = touchPos;
        }
    }
}
