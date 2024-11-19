using UnityEngine;

public enum ActivableCategory
{
    MovingWall,
    Locked
}



public class ActivableType : MonoBehaviour
{
   public ActivableCategory category;

    public ActivableCategory GetActivableCategory()
    {

    return category; }
}
