using Unity.VisualScripting;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
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
        if(other.CompareTag("portal"))
        {
            _nextlevelmanager=other.GetComponent<nextlevelmanager>();
            if(_nextlevelmanager != null)
            {
                _nextlevelmanager.player = true;
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
                _nextlevelmanager.player = false;
            }
        }
    }


}
