using UnityEngine;

public class DoorHolders : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject key1;
    public GameObject key2;
    public Material objectmaterial;
    public bool playerkey=false;
    public bool sheepkey = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")  )
        {
           objectmaterial.color = Color.green;
           playerkey = true;
        }    
        if(collision.gameObject.CompareTag("sheep") )
        {

            objectmaterial.color = Color.red;
            sheepkey = true;
        }
        
    }
}
