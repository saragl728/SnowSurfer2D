using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //TODO: unir las funciones a los botones
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");   //va al 1º nivel
    }

    public void ExitGame()
    {
        //¿debería preguntar si quiere salir?
        Application.Quit();
    }

    public void GoToCredits()
    {
        //TODO: hacer la scene de créditos
        SceneManager.LoadScene("Credits");
    }

    public void GoToCharacters()
    {
        //TODO: hacer la scene de los personajes
        SceneManager.LoadScene("Characters");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
