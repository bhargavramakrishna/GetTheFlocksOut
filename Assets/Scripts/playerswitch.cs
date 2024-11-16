using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public GameObject Player;
    public GameObject Lamb;

    private Movement movementCharacter1;
    private Movement movementCharacter2;
    public  Canvas canvas1;
    public  Canvas canvas2;
    private bool characterOn = true;

  
    public CameraFollow cameraFollow;

    private void Start()
    {
        movementCharacter1 = Player.GetComponent<Movement>();
        movementCharacter2 = Lamb.GetComponent<Movement>();

        movementCharacter1.enabled = true;
        movementCharacter2.enabled = false;

        cameraFollow.SetTarget(Player.transform);
    }

    void Update()
    {
        HandleForm();
    }

    private void HandleForm()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (characterOn)
            {
                movementCharacter1.enabled = false;
                movementCharacter2.enabled = true;
                canvas1.enabled = false;
                canvas2.enabled = true;
                cameraFollow.SetTarget(Lamb.transform);

                characterOn = false;
            }
            else
            {
                movementCharacter1.enabled = true;
                movementCharacter2.enabled = false;
                canvas1.enabled = true;
                canvas2.enabled = false;

                cameraFollow.SetTarget(Player.transform);

                characterOn = true;
            }
        }
    }
}
