using Unity.Netcode;
using UnityEngine;

public class PlayerAttack : NetworkBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform nozzle;

    private BulletPooling _polling;

    private void Start()
    {
        _polling = GetComponent<BulletPooling>();
    }

    public void Attack()
    {
        if (IsOwner)
        {
            RequestPlayerAttackRpc();
        }
    }

    public Transform GetNozzlePosition()
    {
        return nozzle;
    }

    [Rpc(SendTo.ClientsAndHost)]
    private void RequestPlayerAttackRpc()
    {
        GameObject _bullet = _polling.RequestBullet();
        Debug.Log($"Bullet is Null : {_bullet == null}");
        if(_bullet == null )
        {
            return;
        }
        _bullet.SetActive(true);
        _bullet.GetComponent<Bullet>().SetBulletToActiveRpc();

        _bullet.transform.position = nozzle.position;

    }
}
