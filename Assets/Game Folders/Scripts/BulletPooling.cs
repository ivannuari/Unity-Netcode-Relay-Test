using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private List<GameObject> bulletPool = new List<GameObject>();

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        for(int i = 0; i < 25; i++)
        {
            var _clone = Instantiate(bullet, transform);
            _clone.GetComponent<NetworkObject>().Spawn();
            bulletPool.Add(_clone);
        }
    }

    public GameObject RequestBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }
        return null;
    }
}
