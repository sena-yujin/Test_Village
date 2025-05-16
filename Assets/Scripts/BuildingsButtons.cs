using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsButtons : MonoBehaviour
{
    public static string NameofBuilding { get; private set; }
    
    private void Start()
    {
        string btnName = gameObject.name;
        NameofBuilding = btnName.Replace("_BTN","");

    }


}
