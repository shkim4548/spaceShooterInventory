using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Transform slotParent;

    [SerializeField]
    private Slot[] slots;

    private int itemNum;

    [SerializeField]
    public static bool inventoryActivated = false;
    [SerializeField]
    private GameObject go_InventoryBase;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    void Awake()
    {
        FreshSlot();
    }

    private void Update()
    {
        //i키를 누르면 인벤토리 UI를 끄고 킨다.
        TryInventoryOpen();
        //item 사용을 위해 퀵슬롯처럼 사용하는 키
        GetItemKey();
    }

    public void FreshSlot()
    {
        int i = 0;
        for(;i<items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void AddItem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            Debug.Log("slots all full");
        }
    }

    public void InvenOpen()
    {
        go_InventoryBase.SetActive(true);
    }
    public void InvenClose()
    {
        go_InventoryBase.SetActive(false);
    }

    //인벤토리 UI 활성화 함수
    public void TryInventoryOpen()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;
            if (inventoryActivated)
                InvenOpen();
            else
                InvenClose();
        }
    }

    //실질적으로 아이템을 사용시키는 부분
    public void UseItem(int _itemIndex)
    {
        //Debug.Log("UseItem 함수 호출");
        //아이템을 사용하면 우선 해당 아이템이 있는지를 파악
        if (items[_itemIndex] != null)
        {
            //여기까진 작동을 함
            Debug.Log("UseItem함수의 분기문 접근");

            //스펙만 적용하고 치운다. 앞으로 enum타입 안쓴다.
            PlayerCtrl.dmg += (int)items[_itemIndex].atk;
            PlayerCtrl.def += (int)items[_itemIndex].def;
            PlayerCtrl.currHp += (int)items[_itemIndex].rec;
            Debug.Log(PlayerCtrl.dmg);
            Debug.Log(PlayerCtrl.def);
            Debug.Log(PlayerCtrl.currHp);

            //리스트 비운다.
            items.RemoveAt(_itemIndex);
            Destroy(slots[_itemIndex]);
            FreshSlot();
        }
    }

    public void GetItemKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("item 1 has called");
            UseItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("item 2 has called");
            UseItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItem(3);
        }
    }
}
