using UnityEngine;
using UnityEngine.SceneManagement;

public class SzenenWechsler : MonoBehaviour
{


    public void GeheZuMainScene()
    {
        SceneManager.LoadScene("MainScene");

    }
    public void GeheZuOptionScene()
    {
        SceneManager.LoadScene("OptionScene");
    }
    public void GeheZuLoadScene()
    {
        SceneManager.LoadScene("LoadScene");
    }
    public void SpielBeenden()
    {
        Application.Quit();
    }
}
