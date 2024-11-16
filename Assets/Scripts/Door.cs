using System.Runtime;
using TMPro;
using UnityEditor.Analytics;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]private DoorHolders key1;
    [SerializeField] private DoorHolders key2;

    public Vector3 targetPosition;
    public float moveSpeed;

    private void Update()
    {
        if(key1.playerkey || key1.sheepkey == true && key2.sheepkey || key2.playerkey == true)
        {
            opendoor();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void opendoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
