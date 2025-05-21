using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject Content_S;
    public GameObject Content_T;

    public static string NameofBuilding;

    private string name;

    private void Start()
    {
        //'(true)' means it include deactive objects too
        Button[] sButtons = Content_S.GetComponentsInChildren<Button>(true);
        Button[] tButtons = Content_T.GetComponentsInChildren<Button>(true);

        foreach(var item in sButtons.Concat(tButtons))
        {
            if (!(item.gameObject.name == "Button_X"))
            {

                item.onClick.AddListener(() => SetType());
            }
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
            Content_S.GetComponentInParent<ScrollRect>().gameObject.SetActive(false);
        }
        else if (NameofBuilding=="Topping")
        {
            ToppingBTN.GetComponent<Image>().color = button.GetComponent<Image>().color;
            Content_T.GetComponentInParent<ScrollRect>().gameObject.SetActive(false);
        }

    }

}
