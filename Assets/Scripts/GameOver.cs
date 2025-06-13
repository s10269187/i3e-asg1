using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

}

