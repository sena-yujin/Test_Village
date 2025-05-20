using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingObject: MonoBehaviour, IPointerDownHandler
{
    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    private bool blockOpen;
    private int blockLevel;
    private int typeID;
    private int itemID;
    private int penguinID;

    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ


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
        //일단은 자녀를 list 에 담고 onclick 에 연결하면 될듯함 
        foreach (var item in NameofBuilding)
        {
            
        }


    }

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
