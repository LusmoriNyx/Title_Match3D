using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GetObject : MonoBehaviour
{
    // Khai báo các biến lưu trữ
    private GameObject objectToGet1, ObjectToGet2; // Đối tượng cần lấy
    public Transform object1Plane, Object2Plane; // Vị trí của đối tượng cần lấy
    public BoxCollider Plane1Box, Plane2Box;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Plane1Box = object1Plane.GetComponent<BoxCollider>();
       Plane2Box = Object2Plane.GetComponent<BoxCollider>();
    }

    // Khi đối tượng chạm vào Plane1Box, lấy ObjectToGet1 và đặt nó tại vị trí của object1Plane
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plane1Box"))
        {
            objectToGet1 = GameObject.FindGameObjectWithTag("ObjectToGet1");
            if (objectToGet1 != null)
            {
                objectToGet1.transform.position = object1Plane.position;
            }
        }
        else if (other.gameObject.CompareTag("Plane2Box"))
        {
            ObjectToGet2 = GameObject.FindGameObjectWithTag("ObjectToGet2");
            if (ObjectToGet2 != null)
            {
                ObjectToGet2.transform.position = Object2Plane.position;
            }
        }
    }
    // Điều chỉnh vị trí của đối tượng khi được đặt vào Plane1Box hoặc Plane2Box
    void SetObjectPostion()
    {
        if (objectToGet1 != null)
        {
            objectToGet1.transform.position = object1Plane.position;
        }
        if (ObjectToGet2 != null)
        {
            ObjectToGet2.transform.position = Object2Plane.position;
        }
    }

}
