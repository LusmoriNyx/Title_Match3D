using UnityEngine;

public class PlaneTrigger : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MatchObject"))
        {
            Debug.Log("Collided with PlaneTrigger");

            if (GetObject.instance.objectToGet1 == null && GetObject.instance.object1Plane.isEmpty)
            {
                GetObject.instance.objectToGet1 = collision.gameObject;
                GetObject.instance.object1Plane.isEmpty = false;
                GetObject.instance.SetObjectPostion();
                //DragAndLift.instance.OnMouseUp();
            }

            else if (GetObject.instance.ObjectToGet2 == null && GetObject.instance.object2Plane.isEmpty)
            {
                GetObject.instance.ObjectToGet2 = collision.gameObject;
                GetObject.instance.object2Plane.isEmpty = false;
                GetObject.instance.SetObjectPostion();
                //DragAndLift.instance.OnMouseUp();
            }
        }
    }
}
