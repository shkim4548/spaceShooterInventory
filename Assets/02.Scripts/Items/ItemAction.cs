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
            //충돌시 인벤토리에 아이템을 추가한다.
            invenCtrl.AddItem(nowItem);
            Destroy(coll.gameObject);
        }
    }
}
