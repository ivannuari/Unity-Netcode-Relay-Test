using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField , Range(1f , 5f)] private float characterSpeed;
    [SerializeField] private GameObject[] skins;

    private Vector3 _networkPosition;

    public override void OnNetworkSpawn()
    {
        ChangeSkinRpc(IsOwnedByServer? 1: 0);

        if(IsOwner)
        {
            transform.position = GameManager.Instance.GetPosition(PlayerType.networkPlayer1);
        }
        else
        {
            transform.position = GameManager.Instance.GetPosition(PlayerType.networkPlayer2);
            transform.rotation = Quaternion.Euler(0f , 180f , 0f);
        }
    }

    private void Update()
    {
        if(!IsOwner)
        {
            transform.position = _networkPosition;
            return;
        }

        float xMove = Input.GetAxis("Horizontal");

        Vector3 _movement = new Vector3(xMove * Time.deltaTime * characterSpeed , 0f , 0f);
        Vector3 _pos = transform.position += _movement;
        RequestNetworkPositionRpc(_pos);
    }

    [Rpc(SendTo.NotOwner)]
    private void RequestNetworkPositionRpc(Vector3 newPos)
    {
        _networkPosition = -newPos;
    }

    [Rpc(SendTo.Everyone)]
    private void ChangeSkinRpc(int n)
    {
        foreach (var item in skins)
        {
            item.SetActive(true);
        }
        skins[n].SetActive(false);
    }
}