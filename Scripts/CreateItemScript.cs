using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateItemScript : MonoBehaviour
{
    [SerializeField] private GameObject materialObject;
    [SerializeField] private GameObject nameObject;
    [SerializeField] private GameObject loreObject;
    [SerializeField] private GameObject enchantsObject;
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private Button createItemButton;
    [SerializeField] private TMP_InputField inputField;

    private Coroutine coroutine;

    void Start()
    {
        inputField.gameObject.SetActive(false);
        createItemButton.onClick.AddListener(GetInput);
    }

    private void GetInput()
    {
        if (coroutine != null)
        {
            StopAllCoroutines();
            errorText.gameObject.SetActive(false);
            coroutine = null;
        }

        if (materialObject.GetComponent<ItemDropDownMenu>().GetMaterial() != null)
        {
            string materialName = materialObject.GetComponent<ItemDropDownMenu>().GetMaterial();
            string materialAmount = materialObject.GetComponent<ItemDropDownMenu>().GetAmount();
            string itemName = nameObject.GetComponent<ItemNameScript>().GetItemName();
            string itemLore = loreObject.GetComponent<ItemLoreScript>().GetItemLore();
            string enchantments = enchantsObject.GetComponent<EnchantmentsScript>().GetEnchantments();

            string output = "{\"type\":\"" + materialName.Replace('_', ' ') + "\",\"amount\":" + materialAmount + ",\"meta\":{\"displayname\":\"" +
                itemName + "\",\"lore\":[" + itemLore + "],\"enchantments\":{" + enchantments + "}}}";

            inputField.gameObject.SetActive(true);
            inputField.text = output;
        }
        else
        {
            coroutine = StartCoroutine(ManageErrorText());
        }
    }

    private IEnumerator ManageErrorText()
    {
        inputField.gameObject.SetActive(false);
        errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        errorText.gameObject.SetActive(false);
        coroutine = null;
        StopAllCoroutines();
    }
}
