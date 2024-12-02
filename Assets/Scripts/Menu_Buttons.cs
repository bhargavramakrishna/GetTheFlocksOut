using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Buttons : MonoBehaviour
{

    public GameObject credits;
    public GameObject creditss;

    //method to load scene sample scene
    public void Loadscene()
    {
        //loads the sample scene using the method called Load scene
        SceneManager.LoadScene("SampleScene");

    }

    public void ToQuit()
    {
        Application.Quit();
    }

    public void Tutorial()   
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OpenCredit()
    {
         credits.SetActive(true);
    }

    public void CloseCredit()
    {
        credits.SetActive(false);
    }

    public void Openvideo()
    {
        creditss.SetActive(true);
    }

    public void Closevideo()
    {
        creditss.SetActive(false);
    }

    public void quittomainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void reload()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
