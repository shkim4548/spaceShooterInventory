using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private int itemId;
    private float timer = 10.0f;
    [SerializeField]
    private GameObject[] itemList;

    private void Start()
    {
        ItemSpawn();
    }

    private void Update()
    {
        ItemSpawn();
    }

    private void ItemSpawn()
    {
        int itemPosx = Random.Range(-25, 25);
        int itemPosz = Random.Range(-25, 25);

        Vector3 itemPos = new Vector3(itemPosx, 0, itemPosz);
        itemId = Random.Range(0, 3);

        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            Debug.Log("item Spwaned");
            Instantiate(itemList[itemId], itemPos, Quaternion.identity);
            timer = 10.0f;
        }
    }
}
