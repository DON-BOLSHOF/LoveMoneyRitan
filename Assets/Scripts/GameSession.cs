using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class GameSession : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    public Timer Timer => _timer;
    
    private void Awake()
    {
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
    }

    private void Start()
    {
        _timer.StartTimer();
        
        Debug.Log("StartTimer");
    }

    private void FixedUpdate()
    {
        if(_timer.IsOver) Debug.Log("You've lost");
    }
}