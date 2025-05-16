using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingObject: MonoBehaviour, IPointerDownHandler
{
    public GameObject ChildCanvas;
    public GameObject Building;

    private string name;

    public void OnPointerDown(PointerEventData eventData)
    {
        ChildCanvas.SetActive(true);
    }



    //Building 오브젝트
    public void SetBuilding()
    {
        Building.SetActive(true);
        Building.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BuildingSprite");


    }

    public void SetName()
    {


    }




}
