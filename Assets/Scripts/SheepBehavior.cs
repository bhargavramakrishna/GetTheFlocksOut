using UnityEngine;
using UnityEngine.UI;

public class SheepBehavior : MonoBehaviour
{

    [SerializeField]
    private Slider grassBar;
    private float grassConsumptionRate = 30f;



    void Start()
    {
        grassBar.value = 0;
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
