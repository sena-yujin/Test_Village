using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingObject: MonoBehaviour, IPointerDownHandler
{
    //�ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�

    private bool blockOpen;
    private int blockLevel;
    private int typeID;
    private int itemID;
    private int penguinID;

    //�ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�


    public GameObject ChildCanvas;
    public GameObject Building;
    public GameObject SyrupBTN;
    public GameObject ToppingBTN;

    public static string NameofBuilding;

    private string name;

    public void OnPointerDown(PointerEventData eventData)
    {
        ChildCanvas.SetActive(true);
    }


    //Building ������Ʈ
    public void SetBuilding()
    {
        Building.SetActive(true);
        if (NameofBuilding == null) Debug.Log("���� �̸� ���µ�...?");
        Building.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"BuildingSprite/{NameofBuilding}");

        if(NameofBuilding =="Syrup")
        {
            SyrupBTN.SetActive(true);
        }
        else if(NameofBuilding=="Topping")
        {
            ToppingBTN.SetActive(true);
        }

    }

}
