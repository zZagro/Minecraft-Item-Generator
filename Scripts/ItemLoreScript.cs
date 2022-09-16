using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ItemLoreScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    public string GetItemLore()
    {
        string lore = "\"" + inputField.text.Replace("&", "§").Replace("\n", "\",\"") + "\"";

        if (inputField.text.Length > 0)
        {
            return lore;
        } 
        else
        {
            return " ";
        }
    }
}
