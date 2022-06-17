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
        //iŰ�� ������ �κ��丮 UI�� ���� Ų��.
        TryInventoryOpen();
        //item ����� ���� ������ó�� ����ϴ� Ű
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

    //�κ��丮 UI Ȱ��ȭ �Լ�
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

    //���������� �������� ����Ű�� �κ�
    public void UseItem(int _itemIndex)
    {
        //Debug.Log("UseItem �Լ� ȣ��");
        //�������� ����ϸ� �켱 �ش� �������� �ִ����� �ľ�
        if (items[_itemIndex] != null)
        {
            //������� �۵��� ��
            Debug.Log("UseItem�Լ��� �б⹮ ����");

            //���常 �����ϰ� ġ���. ������ enumŸ�� �Ⱦ���.
            PlayerCtrl.dmg += (int)items[_itemIndex].atk;
            PlayerCtrl.def += (int)items[_itemIndex].def;
            PlayerCtrl.currHp += (int)items[_itemIndex].rec;
            Debug.Log(PlayerCtrl.dmg);
            Debug.Log(PlayerCtrl.def);
            Debug.Log(PlayerCtrl.currHp);

            //����Ʈ ����.
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
