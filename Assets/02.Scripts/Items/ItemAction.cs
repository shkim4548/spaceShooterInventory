using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour
{
    public Inventory invenCtrl;

    private void OnTriggerEnter(Collider coll)
    {
        Item nowItem = coll.GetComponent<ItemPickUp>().item;

        if (coll.gameObject.CompareTag("ITEM"))
        {
            Debug.Log("item Coll");
            //�浹�� �κ��丮�� �������� �߰��Ѵ�.
            invenCtrl.AddItem(nowItem);
            Destroy(coll.gameObject);
        }
    }
}
