using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingObject: MonoBehaviour, IPointerDownHandler
{
    public GameObject ChildCanvas;
    public GameObject Building;

    public static string NameofBuilding;

    private string name;

    public void OnPointerDown(PointerEventData eventData)
    {
        ChildCanvas.SetActive(true);
    }


    //Building 오브젝트
    public void SetBuilding()
    {
        Building.SetActive(true);
        if (NameofBuilding == null) Debug.Log("빌딩 이름 없는데...?");
        Building.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"BuildingSprite/{NameofBuilding}");

    }




}
