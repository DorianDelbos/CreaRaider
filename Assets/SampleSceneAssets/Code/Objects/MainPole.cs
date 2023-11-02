using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainPole : MonoBehaviour
{
    private PlayerInventory inventory;
    [SerializeField] private Item itemToPlace;
    [SerializeField] private Transform transformToPlace;
    [SerializeField] private UnityEvent onItemPlace;

    private void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void PlaceItemOn()
    {
        if (inventory.IsContain(itemToPlace))
        {
            Instantiate(itemToPlace.itemGameObject, transformToPlace.position, Quaternion.identity, transformToPlace);
            onItemPlace?.Invoke();

            inventory.RemoveItem(itemToPlace);
        }
    }
}
