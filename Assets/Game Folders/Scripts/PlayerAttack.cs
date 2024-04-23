using Unity.Netcode;
using UnityEngine;

public class PlayerAttack : NetworkBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform nozzle;
    public void Attack()
    {
        if (IsOwner)
        {
            Debug.Log("Attack!!");

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
        Debug.Log($"is host: {IsHost} Request Bullet to Server");
    }
}
