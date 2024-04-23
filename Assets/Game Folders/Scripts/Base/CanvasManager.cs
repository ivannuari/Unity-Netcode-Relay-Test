using System;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Page[] allPage;

    private void Start()
    {
        allPage = GetComponentsInChildren<Page>(true);

        GameManager.Instance.OnStateChanged += OnGameStateChange;
    }

    void OnDestroy()
    {
        GameManager.Instance.OnStateChanged -= OnGameStateChange;
    }

    private void OnGameStateChange(Gamestate newState)
    {
        switch(newState)
        {
            case Gamestate.Loading:
            ChangePage(PageName.LoadingPage);
            break;
            case Gamestate.Menu:
            ChangePage(PageName.MenuPage);
            break;
            case Gamestate.Lobby:
            ChangePage(PageName.LobbyPage);
            break;
            case Gamestate.Game:
            ChangePage(PageName.GamePage);
            break;
            case Gamestate.Exit:
            break;
        }
    }

    private void ChangePage(PageName namePage)
    {
        foreach(Page p in allPage)
        {
            p.DisablePage();
        }

        Page findPage = Array.Find(allPage , p=> p.namaPage == namePage);
        if(findPage != null)
        {
            findPage.gameObject.SetActive(true);
        }
    }
}
