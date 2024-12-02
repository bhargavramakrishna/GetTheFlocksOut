using UnityEngine;
using UnityEngine.UI;

public class SheepBehavior : MonoBehaviour
{

    [SerializeField]
    private Slider grassBar;
    private float grassConsumptionRate = 30f;
    private objectfader _fader;
    private nextlevelmanager _nextlevelmanager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            // Attempt to get the objectfader component
            _fader = other.GetComponent<objectfader>();

            if (_fader != null) // Ensure the component exists
            {
                _fader.DoFade = true; // Trigger the fade effect
            }
            else
            {
                Debug.LogWarning($"Object '{other.name}' with tag 'wall' does not have an objectfader component.");
            }
        }
        if (other.CompareTag("portal"))
        {
            _nextlevelmanager = other.GetComponent<nextlevelmanager>();
            if (_nextlevelmanager != null)
            {
                _nextlevelmanager.sheep = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            // Attempt to get the objectfader component
            _fader = other.GetComponent<objectfader>();

            if (_fader != null) // Ensure the component exists
            {
                _fader.DoFade = false; // Reverse the fade effect
            }
            else
            {
                Debug.LogWarning($"Object '{other.name}' with tag 'wall' does not have an objectfader component.");
            }
        }
        if (other.CompareTag("portal"))
        {
            _nextlevelmanager = other.GetComponent<nextlevelmanager>();
            if (_nextlevelmanager != null)
            {
                _nextlevelmanager.sheep = false;
            }
        }
    }



    void Start()
    {
        //grassBar.value = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grass"))
        {
            EatGrass(collision.gameObject);
        }
     
    }


    private void EatGrass(GameObject grass)
    {
        if (grassBar != null)
        {
            grassBar.value = Mathf.Clamp(grassBar.value + grassConsumptionRate, 0, 100);
        }

        Destroy(grass);
    }
}
