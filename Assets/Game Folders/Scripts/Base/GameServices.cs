using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class GameServices : MonoBehaviour
{
    public async void RequestSignIn()
    {
        await UnityServices.InitializeAsync();

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        string id = AuthenticationService.Instance.PlayerId;
        Debug.Log($"<color=green>Success Sign In With Anonimous Account. ID : {id}</color>");
        GameManager.Instance.ChangeState(Gamestate.Menu);
    }

    public async void CreateLobby()
    {
        string lobbyName = "new lobby";
        int maxPlayers = 4;
        CreateLobbyOptions options = new CreateLobbyOptions();
        options.IsPrivate = false;

        Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);
        Debug.Log($"<color=green>Success Create lobby with ID : {lobby.Id}</color>");
    }
}
