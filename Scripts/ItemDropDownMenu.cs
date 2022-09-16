using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;

public class ItemDropDownMenu : MonoBehaviour
{
    public float fullSizeHeight = 165;
    public float fullPosHeight = 240;

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject scrollView;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform contentContainer;

    private List<XMaterial> materials;
    private List<XMaterial> availableMaterials = new List<XMaterial>();
    private List<GameObject> buttonList = new List<GameObject>();

    void Start()
    {
        materials = Enum.GetValues(typeof(XMaterial)).Cast<XMaterial>().ToList();
        scrollView.SetActive(false);
        inputField.onValueChanged.AddListener(delegate { ManageScrollView(); });
    }

    private void SuggestMaterials()
    {
        buttonList.Clear();
        availableMaterials.Clear();
        for (int i = 0; i < contentContainer.childCount; i++)
        {
            Destroy(contentContainer.GetChild(i).gameObject);
        }

        for (int i = 0; i < materials.Count; i++)
        {
            if (materials[i].ToString().Contains(inputField.text.ToUpper().Replace(" ", "_")))
            {
                availableMaterials.Add(materials[i]);
            }
        }

        for (int i = 0; i < availableMaterials.Count; i++)
        {
            var b = Instantiate(buttonPrefab);
            b.GetComponentInChildren<TextMeshProUGUI>().text = availableMaterials[i].ToString();
            b.transform.SetParent(contentContainer);
            b.GetComponent<RectTransform>().sizeDelta = new Vector2(inputField.GetComponent<RectTransform>().sizeDelta.x, b.GetComponent<RectTransform>().sizeDelta.y);
            b.transform.localScale = Vector2.one;
            buttonList.Add(b);
        }
    }

    private void ManageScrollView()
    {
        if (inputField.text.Length > 0 && !IsTextMaterial())
        {
            if (!scrollView.activeSelf)
            {
                scrollView.SetActive(true);
            }
            SuggestMaterials();
            SetScrollViewHeight();
        }
        else
        {
            buttonList.Clear();
            availableMaterials.Clear();
            for (int i = 0; i < contentContainer.childCount; i++)
            {
                Destroy(contentContainer.GetChild(i).gameObject);
            }
            scrollView.SetActive(false);
        }
    }

    private void SetScrollViewHeight()
    {
        float height = 33 * buttonList.Count;
        RectTransform inputRt = inputField.GetComponent<RectTransform>();

        contentContainer.GetComponent<LayoutElement>().preferredHeight = height;
        contentContainer.GetComponent<LayoutElement>().preferredWidth = inputRt.sizeDelta.x;

        RectTransform rt = scrollView.GetComponent<RectTransform>();
        if (height < fullSizeHeight)
        {
            rt.sizeDelta = new Vector2(inputRt.sizeDelta.x, height);
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, fullPosHeight + (5 - buttonList.Count) * (33 / 2));
        }
        else
        {
            rt.sizeDelta = new Vector2(inputRt.sizeDelta.x, fullSizeHeight);
            rt.anchoredPosition = new Vector3(rt.anchoredPosition.x, fullPosHeight);
        }
    }

    public string GetMaterial()
    {
        if (IsTextMaterial()) return inputField.text;
        else return null;
    }

    public string GetAmount()
    {
        return "1";
    }

    private bool IsTextMaterial()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            if (materials[i].ToString() == inputField.text) return true;
        }
        return false;
    }
}
