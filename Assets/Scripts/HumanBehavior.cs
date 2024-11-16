using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject key;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("key"))
        {
            Destroy(collision.gameObject);
            key.SetActive(true);
        }
    }
}
