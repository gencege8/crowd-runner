using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Idle, Playing, Win, Lose}
    public GameState currentState;
    public static GameManager instance;
    void Awake()
    {
        instance = this;
        currentState = GameState.Idle;
    }

    public void StartGame()
    {
        currentState = GameState.Playing;
    }
    public void EndGame(bool didWin)
    {
        currentState = didWin ? GameState.Win : GameState.Lose;
    }
}
