using System.Collections.Generic;
using UnityEngine;

public enum Genre
{
    SlotMachine,
    Idle,
    Strategy
}
public class Game
{
    public string GameName;
    public Genre GameGenre;
}

public class GameHandler : MonoBehaviour
{
    #region SINGLETON SETUP
    public static GameHandler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    //NEED TO ADD SAVING FOR THIS!
    private List<Game> _createdGameList = new List<Game>();

    public Game CreatedGame;

    public void CreateGame()
    {
        CreatedGame = new Game();
    }

    public void SetGameName(string gameName)
    {
        CreatedGame.GameName = gameName;
    }

    public void SetGameGenre(Genre gameGenre)
    {
        CreatedGame.GameGenre = gameGenre;
    }
}
