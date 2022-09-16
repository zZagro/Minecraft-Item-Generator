using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemNameScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    public string GetItemName()
    {
        if (inputField != null) return inputField.text.Replace("&", "§");
        else return " ";
    }
} 
