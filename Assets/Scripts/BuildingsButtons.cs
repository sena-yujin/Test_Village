using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsButtons : MonoBehaviour
{

    public void SetName()
    {
        string btnName = gameObject.name;
        BuildingObject.NameofBuilding = btnName.Replace("_BTN", "");
    }


}
