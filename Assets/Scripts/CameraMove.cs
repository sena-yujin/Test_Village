using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    public SpriteRenderer mapBounds;

    private float Speed = 0.5f;
    private Vector2 nowPos, prePos;
    private Vector3 movePos;
    private Vector3[] spriteCenters;
    private int currentIndex = 0;
    private float edgeBuffer = 0.5f;
    
    [SerializeField] private SpriteRenderer[] maps;
    [SerializeField] private Camera camera;
    [SerializeField] private Vector2 minCameraPos;
    [SerializeField] private Vector2 maxCameraPos;

    private void Start()
    {
        Bounds bounds = mapBounds.bounds;

        float vertExt = Camera.main.orthographicSize;
        float horzExt = vertExt * Screen.width / Screen.height;

        minCameraPos = new Vector2(bounds.min.x+horzExt,bounds.min.y+vertExt);
        maxCameraPos = new Vector2(bounds.max.x-horzExt,bounds.max.y-vertExt);

        spriteCenters = new Vector3[maps.Length];
        for(int i = 0; i < maps.Length;i++)
        {
            spriteCenters[i] = maps[i].bounds.center;
        }

        currentIndex = GetClosetSpriteIndex(camera.transform.position);

    }

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

            //distance gap if it is '- ; minus', then it is 'zoom in' 
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if (camera.orthographic)
            {
                camera.orthographicSize += deltaMagnitudeDiff * Speed;
                camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
            }
        }

    }

    //region pass
    private void LateUpdate()
    {
        Vector3 camPos = camera.transform.position;
        float camHalfWidth = camera.orthographicSize * camera.aspect;
        float camLeft = camPos.x - camHalfWidth;
        float camRight = camPos.x + camHalfWidth;

        Bounds currentBounds = maps[currentIndex].bounds;

        if(camRight>currentBounds.max.x+edgeBuffer && currentIndex<spriteCenters.Length-1)
        {
            currentIndex++;
            MoveCameraToIndex(currentIndex);
        }
        else if(camLeft<currentBounds.min.x-edgeBuffer&&currentIndex>0)
        {
            currentIndex--;
            MoveCameraToIndex(currentIndex);

        }

    }

    void MoveCameraToIndex(int index)
    {
        Vector3 target = spriteCenters[index];
        target.z = camera.transform.position.z;
        camera.transform.position = target;

    }

    int GetClosetSpriteIndex(Vector3 camPos)
    {
        float mindis = float.MaxValue;
        int index=0;

        for (int i = 0; i < spriteCenters.Length; i++)
        {
            float dis = Vector3.Distance(camPos, spriteCenters[i]);

            if (dis<mindis)
            {
                mindis = dis;
                index = i;

            }
        }

        return index;

    }

}
