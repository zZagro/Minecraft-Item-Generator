using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] Button createItemButton;
    [SerializeField] Button allCreatedItemsButton;
    [SerializeField] Button settingsButton;

    void Start()
    {
        createItemButton.onClick.AddListener(onClickCreateItemButton);
        allCreatedItemsButton.onClick.AddListener(onClickAllCreatedItemsButton);
    }

    private void onClickCreateItemButton()
    {
        SceneManager.LoadScene("Scenes/ItemCreationMenu");
    }

    private void onClickAllCreatedItemsButton()
    {
        SceneManager.LoadScene("Scenes/PastItemsCreatedMenu");
    }
}
