using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnchantmentHoverScript : MonoBehaviour
{
    public Dictionary<string, int> enchantmentDic = new Dictionary<string, int>();

    private GameObject enchantmentsObject;
    private Transform contentContainer;
    private Button removeEnchantsButton;
    private EnchantmentsScript enchantmentsScript;
    private TMP_Dropdown levelDropdown;
    private TMP_Dropdown enchantDropdown;
    private List<string> enchantmentLevelList = new List<string>();
    private List<string> enchantmentList = new List<string>();

    private void Start()
    {
        SetEnchantments();
        removeEnchantsButton = transform.GetChild(1).GetComponent<Button>();
        contentContainer = transform.parent;
        enchantmentsObject = contentContainer.parent.transform.parent.transform.parent.gameObject;
        enchantmentsScript = enchantmentsObject.GetComponent<EnchantmentsScript>();
        levelDropdown = gameObject.transform.GetChild(0).GetComponent<TMP_Dropdown>();
        enchantDropdown = gameObject.transform.GetChild(2).GetComponent<TMP_Dropdown>();

        removeEnchantsButton.onClick.AddListener(DeleteEnchantment);
        enchantDropdown.onValueChanged.AddListener(delegate { SetEnchantLevelList(enchantDropdown.options[enchantDropdown.value].text); });

        SetSelection();
    }

    private void Update()
    {
        SetLevelSelection();
    }

    private void DeleteEnchantment()
    {
        Destroy(removeEnchantsButton.transform.parent.gameObject);
        enchantmentsScript.enchantmentsCount -= 1;
        contentContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(contentContainer.GetComponent<RectTransform>().sizeDelta.x, contentContainer.GetComponent<RectTransform>().sizeDelta.y - 55);
    }

    public void OnHightlightEnter()
    {
        RectTransform rt = transform.GetChild(2).GetComponent<RectTransform>();
        if (GameObject.Find("Blocker") == null)
        {
            if (!transform.GetChild(0).gameObject.activeInHierarchy)
            {
                rt.sizeDelta = new Vector2(500 - 55, rt.sizeDelta.y);
                rt.anchoredPosition = new Vector2(rt.anchoredPosition.x + 55 / 2, rt.anchoredPosition.y);
            }
            else
            {
                rt.sizeDelta = new Vector2(500 - 55*2, rt.sizeDelta.y);
                rt.anchoredPosition = new Vector2(0, rt.anchoredPosition.y);
            }
        }
    }

    public void OnHightlightExit()
    {
        RectTransform rt = transform.GetChild(2).GetComponent<RectTransform>();
        if (transform.GetChild(0).gameObject.activeInHierarchy)
        {
            rt.sizeDelta = new Vector2(500 - 55, rt.sizeDelta.y);
            rt.anchoredPosition = new Vector2(0 - 55/2, rt.anchoredPosition.y);
            Debug.Log("1");
        }
        else
        {
            rt.sizeDelta = new Vector2(500, rt.sizeDelta.y);
            rt.anchoredPosition = new Vector2(0, rt.anchoredPosition.y);
            Debug.Log("2");
        }
    }

    private void SetLevelSelection()
    {
        if (enchantDropdown.value != 0 && !gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (enchantDropdown.value == 0 && gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void SetEnchantLevelList(string text)
    {
        enchantmentLevelList.Clear();
        if (enchantmentDic.ContainsKey(text))
        {
            for (int i = 0; i < enchantmentDic[text]; i++)
            {
                enchantmentLevelList.Add((i + 1).ToString());
            }
        }
        levelDropdown.ClearOptions();
        levelDropdown.AddOptions(enchantmentLevelList);
    }

    private void SetSelection()
    {
        SetEnchantList();
        TMP_Dropdown dropdown = gameObject.transform.GetChild(2).GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();
        dropdown.options.Add(new TMP_Dropdown.OptionData() { text = "Select Enchantment" });
        dropdown.AddOptions(enchantmentList);
    }

    private void SetEnchantList()
    {
        enchantmentList.Clear();
        for (int i = 0; i < enchantmentDic.Count; i++)
        {
            enchantmentList.Add(enchantmentDic.ElementAt(i).Key);
        }
    }

    public void SetEnchantments()
    {
        enchantmentDic.Clear();
        enchantmentDic.Add("AQUA_AFFINITY", 1);
        enchantmentDic.Add("BANE_OF_ARTHROPODS", 5);
        enchantmentDic.Add("BLAST_PROTECTION", 4);
        enchantmentDic.Add("CHANNELING", 1);
        enchantmentDic.Add("CURSE_OF_BINDING", 1);
        enchantmentDic.Add("CURSE_OF_VANISHING", 1);
        enchantmentDic.Add("DEPTH_STRIDER", 3);
        enchantmentDic.Add("EFFICIENCY", 5);
        enchantmentDic.Add("FEATHER_FALLING", 4);
        enchantmentDic.Add("FIRE_ASPECT", 2);
        enchantmentDic.Add("FIRE_PROTECTION", 4);
        enchantmentDic.Add("FLAME", 1);
        enchantmentDic.Add("FORTUNE", 3);
        enchantmentDic.Add("FROST_WALKER", 2);
        enchantmentDic.Add("IMPALING", 5);
        enchantmentDic.Add("INFINITY", 1);
        enchantmentDic.Add("KNOCKBACK", 2);
        enchantmentDic.Add("LOOTING", 3);
        enchantmentDic.Add("LOYALTY", 3);
        enchantmentDic.Add("LUCK_OF_THE_SEA", 3);
        enchantmentDic.Add("LURE", 3);
        enchantmentDic.Add("MENDING", 1);
        enchantmentDic.Add("MULTISHOT", 1);
        enchantmentDic.Add("PIERCING", 4);
        enchantmentDic.Add("POWER", 5);
        enchantmentDic.Add("PROJECTILE_PROTECTION", 4);
        enchantmentDic.Add("PROTECTION", 4);
        enchantmentDic.Add("PUNCH", 2);
        enchantmentDic.Add("QUICK_CHARGE", 3);
        enchantmentDic.Add("RESPIRATION", 3);
        enchantmentDic.Add("RIPTIDE", 3);
        enchantmentDic.Add("SHARPNESS", 5);
        enchantmentDic.Add("SILK_TOUCH", 1);
        enchantmentDic.Add("SMITE", 5);
        enchantmentDic.Add("SOUL_SPEED", 3);
        enchantmentDic.Add("SWEEPING_EDGE", 3);
        enchantmentDic.Add("SWIFT_SNEAK", 3);
        enchantmentDic.Add("THORNS", 3);
        enchantmentDic.Add("UNBREAKING", 3);
    }
}
