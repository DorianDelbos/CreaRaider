using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactable : MonoBehaviour
{
    public Item itemScriptable;

    private void Start()
    {
        Instantiate(itemScriptable.itemGameObject, transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().AddItem(this);
            GameManager.instance.AddPopup("You pick up " + itemScriptable.displayText);
            Destroy(gameObject);
        }
    }
}
