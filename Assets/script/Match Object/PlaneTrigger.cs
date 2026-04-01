using UnityEngine;

public class PlaneTrigger : MonoBehaviour
{
    private BoxCollider PlaneBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlaneBox = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MatchObject"))
        {
            if (GetObject.instance.objectToGet1 == null)
            {
                GetObject.instance.objectToGet1 = other.gameObject;
                GetObject.instance.SetObjectPostion();

            }
            else if (GetObject.instance.ObjectToGet2 == null)
            {
                GetObject.instance.ObjectToGet2 = other.gameObject;
                GetObject.instance.SetObjectPostion();
            }
        }
    }
}
