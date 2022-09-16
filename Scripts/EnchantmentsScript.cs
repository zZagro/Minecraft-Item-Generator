using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class EnchantmentsScript : MonoBehaviour
{
    public float enchantmentsCount;
    public Dictionary<string, string> spigotEnchantmentsDic = new Dictionary<string, string>();

    [SerializeField] Toggle enchantmentToggle;
    [SerializeField] GameObject scrollView;
    [SerializeField] Button addEnchantsButton;
    [SerializeField] GameObject enchantment;
    [SerializeField] Transform contentContainer;

    private Dictionary<string, string> enchantmentsOutputDic = new Dictionary<string, string>();

    private void Start()
    {
        TranslateEnchantments();
        addEnchantsButton.onClick.AddListener(AddEnchantmentsButton);
        contentContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(contentContainer.GetComponent<RectTransform>().sizeDelta.x, 55);
    }

    private void Update()
    {
        CheckEnchantmentToggle();
    }

    public void CheckEnchantmentToggle()
    {
        if (enchantmentToggle.isOn)
        {
            scrollView.SetActive(true);
        } else
        {
            scrollView.SetActive(false);
            if (enchantmentsCount > 0)
            {
                DestroyDropdowns();
            }
        }
    }

    private void AddEnchantmentsButton()
    {
        contentContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(contentContainer.GetComponent<RectTransform>().sizeDelta.x, contentContainer.GetComponent<RectTransform>().sizeDelta.y + 55);
        GameObject enchant = Instantiate(enchantment);
        enchant.transform.SetParent(contentContainer);
        enchant.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollView.GetComponent<RectTransform>().sizeDelta.x, enchant.GetComponent<RectTransform>().sizeDelta.y);
        enchant.transform.localScale = Vector2.one;
        enchantmentsCount += 1;
        addEnchantsButton.transform.SetAsLastSibling();
    }

    private void DestroyDropdowns()
    {
        for (int i = 0; i < contentContainer.childCount; i++)
        {
            if (contentContainer.GetChild(i).gameObject != addEnchantsButton.gameObject)
            {
                Destroy(contentContainer.GetChild(i).gameObject);
            }
        }
        enchantmentsCount = 0f;
        Debug.Log(enchantmentsCount);
    }

    public string GetEnchantments()
    {
        string enchantmentsOutput = "{}";
        
        for (int i = 0; i < contentContainer.childCount; i++)
        {
            if (contentContainer.GetChild(i).name != "AddButton")
            {
                TMP_Dropdown enchantDropdown = contentContainer.GetChild(i).transform.GetChild(2).GetComponent<TMP_Dropdown>();
                TMP_Dropdown levelDropdown = contentContainer.GetChild(i).transform.GetChild(0).GetComponent<TMP_Dropdown>();
                if (!enchantmentsOutputDic.ContainsKey(enchantDropdown.options[enchantDropdown.value].text))
                enchantmentsOutputDic.Add(enchantDropdown.options[enchantDropdown.value].text, levelDropdown.options[levelDropdown.value].text);
            }
        }
        if (enchantmentsOutputDic.Count > 0)
        {
            for (int i = 0; i < enchantmentsOutputDic.Count; i++)
            {
                if (enchantmentsOutput == "{}")
                {
                    enchantmentsOutput = "\"" + spigotEnchantmentsDic.ElementAt(i).Value + "\":" + enchantmentsOutputDic.ElementAt(i).Value;
                }
                else
                {
                    enchantmentsOutput += ",\"" + spigotEnchantmentsDic.ElementAt(i).Value + "\":" + enchantmentsOutputDic.ElementAt(i).Value;
                }
            }
        }
        return enchantmentsOutput;
    }

    private void TranslateEnchantments()
    {
        spigotEnchantmentsDic.Clear();
        spigotEnchantmentsDic.Add("AQUA_AFFINITY", "WATER_WORKER");
        spigotEnchantmentsDic.Add("BANE_OF_ARTHROPODS", "DAMAGE_ARTHROPODS");
        spigotEnchantmentsDic.Add("BLAST_PROTECTION", "PROTECTION_EXPLOSIONS");
        spigotEnchantmentsDic.Add("CHANNELING", "CHANNELING");
        spigotEnchantmentsDic.Add("CURSE_OF_BINDING", "BINDING_CURSE");
        spigotEnchantmentsDic.Add("CURSE_OF_VANISHING", "VANISHING_CURSE");
        spigotEnchantmentsDic.Add("DEPTH_STRIDER", "DEPTH_STRIDER");
        spigotEnchantmentsDic.Add("EFFICIENCY", "DIG_SPEED");
        spigotEnchantmentsDic.Add("FEATHER_FALLING", "PROTECTION_FALL");
        spigotEnchantmentsDic.Add("FIRE_ASPECT", "FIRE_ASPECT");
        spigotEnchantmentsDic.Add("FIRE_PROTECTION", "PROTECTION_FIRE");
        spigotEnchantmentsDic.Add("FLAME", "ARROW_FIRE");
        spigotEnchantmentsDic.Add("FORTUNE", "LOOT_BONUS_BLOCKS");
        spigotEnchantmentsDic.Add("FROST_WALKER", "FROST_WALKER");
        spigotEnchantmentsDic.Add("IMPALING", "IMPALING");
        spigotEnchantmentsDic.Add("INFINITY", "ARROW_INFINITE");
        spigotEnchantmentsDic.Add("KNOCKBACK", "KNOCKBACK");
        spigotEnchantmentsDic.Add("LOOTING", "LOOT_BONUS_MOBS");
        spigotEnchantmentsDic.Add("LOYALTY", "LOYALTY");
        spigotEnchantmentsDic.Add("LUCK_OF_THE_SEA", "LUCK");
        spigotEnchantmentsDic.Add("LURE", "LURE");
        spigotEnchantmentsDic.Add("MENDING", "MENDING");
        spigotEnchantmentsDic.Add("MULTISHOT", "MULTISHOT");
        spigotEnchantmentsDic.Add("PIERCING", "PIERCING");
        spigotEnchantmentsDic.Add("POWER", "ARROW_DAMAGE");
        spigotEnchantmentsDic.Add("PROJECTILE_PROTECTION", "PROTECTION_PROJECTILE");
        spigotEnchantmentsDic.Add("PROTECTION", "PROTECTION_ENVIRONMENTAL");
        spigotEnchantmentsDic.Add("PUNCH", "ARROW_KNOCKBACK");
        spigotEnchantmentsDic.Add("QUICK_CHARGE", "QUICK_CHARGE");
        spigotEnchantmentsDic.Add("RESPIRATION", "OXYGEN");
        spigotEnchantmentsDic.Add("RIPTIDE", "RIPTIDE");
        spigotEnchantmentsDic.Add("SHARPNESS", "DAMAGE_ALL");
        spigotEnchantmentsDic.Add("SILK_TOUCH", "SILK_TOUCH");
        spigotEnchantmentsDic.Add("SMITE", "DAMAGE_UNDEAD");
        spigotEnchantmentsDic.Add("SOUL_SPEED", "SOUL_SPEED");
        spigotEnchantmentsDic.Add("SWEEPING_EDGE", "SWEEPING_EDGE");
        spigotEnchantmentsDic.Add("SWIFT_SNEAK", "SWIFT_SNEAK");
        spigotEnchantmentsDic.Add("THORNS", "THORNS");
        spigotEnchantmentsDic.Add("UNBREAKING", "DURABILITY");
    }
}
