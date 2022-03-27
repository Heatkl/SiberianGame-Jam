using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    PPM,
    SHOTGUN,
    HEALTH
}
public class Item : MonoBehaviour
{
    [SerializeField] private int _restoreAmount = 10;
    [SerializeField] private ItemType _itemType;

    public ItemType GetItemType() { return _itemType; }
    public int GetRestoreAmount() { return _restoreAmount; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("Player");
            collider.gameObject.GetComponent<PlayerResources>().TakeItem(this);
            Destroy(gameObject);
        }
    }
}
