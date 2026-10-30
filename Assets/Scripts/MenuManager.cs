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
        SceneManager.LoadScene("Credits");
    }

    public void GoToCharacters()
    {
        SceneManager.LoadScene("Characters");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Para elegir el personaje jugable
    /// </summary>
    /// <param name="characterIndex">Índice asociado al jugador</param>
    public void SelectCharacter(int characterIndex)
    {
        //guarda las preferencias
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        //va al menú principal
        GoToMenu();
    }

}
