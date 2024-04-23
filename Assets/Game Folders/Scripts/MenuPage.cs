using UnityEngine;
using UnityEngine.UI;

public class MenuPage : Page
{
    [SerializeField] private Button buttonHost;
    [SerializeField] private Button buttonClient;

    private void Start()
    {
        buttonHost.onClick.AddListener(() =>
        {
            GameManager.Instance.HostGame();
            GameManager.Instance.ChangeState(Gamestate.Lobby);
        });
        buttonClient.onClick.AddListener(() =>
        {
            GameManager.Instance.ClientGame();
            GameManager.Instance.ChangeState(Gamestate.Lobby);
        });
    }
}
