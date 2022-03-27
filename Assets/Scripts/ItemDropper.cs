using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [System.Serializable]
    struct ItemWithChance
    {
        public Item item;
        public int chance;
    }

    [SerializeField] private ItemWithChance[] _itemList = null;
    private int _sumOfChances = 0;

    [SerializeField] private SFXPlayer _sfxPlayer;

    private void Start()
    {
        _sfxPlayer = FindObjectOfType<SFXPlayer>();
        foreach (ItemWithChance item in _itemList)
        {
            _sumOfChances += item.chance;
        }
    }
    private Item RandomItem()
    {
        if (_sumOfChances == 0) return null;
        int random = Random.Range(1, 101);
        int sum = 0;
        foreach(ItemWithChance item in _itemList)
        {
            sum += item.chance;
            if(sum >= random)
            {
                return item.item;
            }
        }
        return null;
    }
    public void DropItem()
    {
        Debug.Log("DropItem()");
        Item item = RandomItem();
        if (item == null) return;
        Debug.Log("item");
        _sfxPlayer.PlayAmmoDrop();
        Instantiate(item.gameObject, transform.position, Quaternion.Euler(0,0,0));
    }
}
