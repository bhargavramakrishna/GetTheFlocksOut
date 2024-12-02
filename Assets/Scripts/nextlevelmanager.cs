using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class nextlevelmanager : MonoBehaviour
{
    public bool player = false;
    public bool sheep = false;
    public int secnumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if(player==true)
        {
            if (sheep == true)
            {
                toloadsec();
            }
        }
    }

    void toloadsec()
    {
        SceneManager.LoadScene(secnumber);
    }
}
