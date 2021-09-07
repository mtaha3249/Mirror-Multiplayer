using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();

    [Client]
    private void Update()
    {
        if (!hasAuthority) return;

        if (!Input.GetKeyDown(KeyCode.Space)) return;

        // transform.Translate(movement);
        CmdMove();
    }

    [Command]
    private void CmdMove()
    {
        // validate
        ClientRPC();
    }

    [ClientRpc]
    private void ClientRPC()
    {
        transform.Translate(movement);
    }
}