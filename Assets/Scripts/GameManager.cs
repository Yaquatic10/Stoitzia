
using UnityEngine;
public class GameManager : MonoBehaviour
{
  
 private bool _gameEnded = false;
 
    void Update()
    {
        
        if (_gameEnded)
            return;
        
        
        
        if (PlayerStats.Lives <= 0)
        {

           EnfGame();

        }
    }

   

    void EnfGame()
    {
        _gameEnded=true;
        Debug.Log("Game Over");
    }
}
