using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float ZoomSpeed = 0.5f;

    public Camera camera;

    void Update()
    {

        if(Input.touchCount==2) //when touched with 2 finger
        {
            Touch touchZero = Input.GetTouch(0);  //First touch
            Touch touchOne = Input.GetTouch(1);   //second touch

            //previous frame touch pos- this frame touch pos
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // vector between touchs
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            //distance gap if it is '-', then it is 'zoom in' 
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if(camera.orthographic)
            {
                camera.orthographicSize += deltaMagnitudeDiff * ZoomSpeed;
                camera.orthographicSize = Mathf.Max(camera.orthographicSize,0.1f);
            }

        }
        



    }
}
