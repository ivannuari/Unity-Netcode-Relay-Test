using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GamePage : Page
{
    [SerializeField] private Button buttonHost;
    [SerializeField] private Button buttonClient;

    [SerializeField] private GameObject content;
    [SerializeField] private TMP_Text infoText;

    private void Start()
    {
        buttonHost.onClick.AddListener(() => 
        {
            NetworkManager.Singleton.StartHost();
            content.SetActive(false);
            infoText.text = $"Join as <color=green>Host!</color>";
        });
        buttonClient.onClick.AddListener(() => 
        {
            NetworkManager.Singleton.StartClient();
            content.SetActive(false);
            infoText.text = $"Join as <color=green>Client!</color>";
        });
    }
}
