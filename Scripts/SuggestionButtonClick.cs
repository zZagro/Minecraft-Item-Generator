using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SuggestionButtonClick : MonoBehaviour
{
    private TMP_InputField inputField;
    private Button button;

    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        inputField.text = button.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
