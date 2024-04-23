using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Gamestate currentState = Gamestate.Loading;
    [SerializeField] private Vector3[] playersPosition;
    private GameServices _services;

    public delegate void ChangeStateDelegate(Gamestate newState);
    public event ChangeStateDelegate OnStateChanged;

    private void Awake()
    {
        if(Instance is null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        _services = GetComponent<GameServices>();
    }

    private void Start()
    {
        _services.RequestSignIn();
    }

    public void ChangeState(Gamestate newState)
    {
        if(newState == currentState)
        {
            return;
        }
        currentState = newState;

        OnStateChanged?.Invoke(currentState);
    }

    public void HostGame()
    {
        _services.CreateLobby();
    }

    public void ClientGame()
    {

    }

    public Vector3 GetPosition(PlayerType tipePemain)
    {
        if(tipePemain == PlayerType.networkPlayer2)
        {
            return playersPosition[1];
        }
        else
        {
            return playersPosition[0];
        }
    }
}