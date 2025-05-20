using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    public GameObject S_Content;
    public GameObject T_Content;

    private List<GameObject> S_Content_C;
    private List<GameObject> T_Content_C;



    public static string NameofBuilding;

    private string name;

    private void Start()
    {
        //�ϴ��� �ڳฦ list �� ��� onclick �� �����ϸ� �ɵ��� 
        foreach (var item in NameofBuilding)
        {
            
        }


    }

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

    public void SetType()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        if(NameofBuilding=="Syrup")
        {
            SyrupBTN.GetComponent<Image>().color = button.GetComponent<Image>().color;
        }
        else if (NameofBuilding=="Topping")
        {
            ToppingBTN.GetComponent<Image>().color = button.GetComponent<Image>().color;

        }

    }

}
