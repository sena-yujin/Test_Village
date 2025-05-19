using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    private float Speed = 0.5f;
    private Vector2 nowPos, prePos;
    private Vector3 movePos;
  //  private bool isDragging = false;
    
    [SerializeField] private Camera camera;
    [SerializeField] private Vector2 minCameraPos;
    [SerializeField] private Vector2 maxCameraPos;


    //터치한 곳의 tag 가 land 인지 확인하는 조건 추가되어야함
    private void Update()
    {
        if(Input.touchCount==1)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase==TouchPhase.Began)
            {
                Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(touchWorldPos,Vector2.zero);

                if (hit.collider != null)
                {
                    Debug.Log("터치된 오브젝트 있음 → 상호작용");
                    hit.collider.GetComponent<IPointerDownHandler>()?.OnPointerDown(new PointerEventData(EventSystem.current));
                }
                else
                {
                   // isDragging = false;
                    prePos = touch.position - touch.deltaPosition;
                }
            }
            else if(touch.phase==TouchPhase.Moved)
            {

                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Time.deltaTime * Speed;
                camera.transform.Translate(movePos);

                Vector3 camPos = Camera.main.transform.position;
                camPos.x = Mathf.Clamp(camPos.x,minCameraPos.x,maxCameraPos.x);
                camPos.y = Mathf.Clamp(camPos.y,minCameraPos.y,maxCameraPos.y);
                Camera.main.transform.position = camPos;

                prePos = touch.position - touch.deltaPosition;

            }
        }

        if (Input.touchCount == 2) //when touched with 2 finger
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

            if (camera.orthographic)
            {
                camera.orthographicSize += deltaMagnitudeDiff * Speed;
                camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
            }

        }


    }




}
