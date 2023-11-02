using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("Gameobject & Components")]
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject inventoryContain;
    [SerializeField] private GameObject inventoryCasePrefab;

    [Space, Header("Inputs")]
    [SerializeField] private InputActionReference openMenuInput;

    [Space, Header("Settings")]
    private List<Item> inventory = new List<Item>();

    private void Update()
    {
        if (openMenuInput.action.WasPressedThisFrame())
        {
            ToggleInventory();
        }
    }

    public bool IsContain(Item item)
    {
        return inventory.Contains(item);
    }

    public void ToggleInventory()
    {
        Time.timeScale = (mapPanel.activeSelf ? 1f : 0f);
        Cursor.lockState = (mapPanel.activeSelf ? CursorLockMode.Locked : CursorLockMode.Confined);

        hudPanel.SetActive(!hudPanel.activeSelf);
        mapPanel.SetActive(!mapPanel.activeSelf);
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
        
        GameObject newCase = Instantiate(inventoryCasePrefab, inventoryContain.transform);
        newCase.transform.GetChild(0).GetComponent<Image>().sprite = item.sprite;
        newCase.transform.GetChild(1).GetComponent<TMP_Text>().text = item.displayText;
        newCase.transform.GetChild(2).GetComponent<TMP_Text>().text = item.description;

        inventoryContain.GetComponent<VerticalLayoutGroup>().SetLayoutVertical();
    }

    public void RemoveItem(Item item)
    {
        if (IsContain(item))
        {
            inventory.Remove(item);
        }
    }
}
