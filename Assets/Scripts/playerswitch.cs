using UnityEngine;

public class playerswitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Character1;
    public GameObject Character2;

    private Movement movementcharacter1;
    private Movement movementcharacter2;
    private bool characterOn = true;

    private void Start()
    {
        movementcharacter1 = Character1.GetComponent<Movement>();
        movementcharacter2 = Character2.GetComponent<Movement>();
    }
    // Update is called once per frame
    void Update()
    {
        HandleForm();
    }
    private void HandleForm()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (characterOn == true)
            {
                //Character2.SetActive(true);
                //Character1.SetActive(false);
                movementcharacter1.enabled = false;
                movementcharacter2.enabled = true;
                characterOn = false;
            }
            else
            {
                //Character1.SetActive(true);
                //Character2.SetActive(false);
                movementcharacter1.enabled = true;
                movementcharacter2.enabled = false;
                characterOn = true;
            }

        }
    }
}
