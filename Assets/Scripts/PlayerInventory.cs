using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, ICollectable
{
    [SerializeField] private int maxItems = 8;
    private List<ItemSO> _itemList = new List<ItemSO>();

    public void Collect(ItemSO itemToCollect)
    {
        if(itemToCollect)
        {
            _itemList.Add(itemToCollect);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
