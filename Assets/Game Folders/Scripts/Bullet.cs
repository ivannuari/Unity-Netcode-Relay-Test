using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    private Vector3 _networkPos;

    private Rigidbody _rb;
    private PlayerAttack _playerAttack;
    private NetworkObject _netObject;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _netObject = GetComponent<NetworkObject>();

        Invoke("DisableObject", 3f);
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }

    public void SetPlayerAttackComponent(PlayerAttack playerAttack)
    {
        _playerAttack = playerAttack;
    }

    public override void OnNetworkSpawn()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(IsOwner)
        {
            _rb.velocity = transform.forward * 10f;
            SetPositionNetworkRpc(transform.position);
        }
        else
        {
            transform.position = _networkPos;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(IsOwner)
        {
            gameObject.SetActive(false);
        }
    }

    [Rpc(SendTo.ClientsAndHost)]
    private void SetPositionNetworkRpc(Vector3 newPos)
    {
        Vector3 pos = new Vector3(-newPos.x , newPos.y , -newPos.z);

        _networkPos = pos;
    }

    [Rpc(SendTo.NotOwner)]
    public void SetBulletToActiveRpc()
    {
        gameObject.SetActive(true);
    }
}