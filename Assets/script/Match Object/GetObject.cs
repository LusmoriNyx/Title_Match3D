using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GetObject : MonoBehaviour
{
    public static GetObject instance; // Singleton instance
     void Awake()
    {
        // Thiết lập singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Khai báo các biến lưu trữ
    public GameObject objectToGet1, ObjectToGet2; // Đối tượng cần lấy
    public Transform object1Plane, object2Plane; // Vị trí của đối tượng cần lấy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Khi đối tượng chạm vào Plane1Box, lấy ObjectToGet1 và đặt nó tại vị trí của object1Plane
   
    // Điều chỉnh vị trí của đối tượng khi được đặt vào Plane1Box hoặc Plane2Box
    public void SetObjectPostion()
    {
        Vector3 initialPosition1 = new Vector3 (object1Plane.transform.position.x, object1Plane.transform.position.y + 0.5f, object1Plane.transform.position.z); // Lưu vị trí ban đầu của object1Plane
        Vector3 initialPosition2 = new Vector3 (object2Plane.transform.position.x, object2Plane.transform.position.y + 0.5f, object2Plane.transform.position.z); // Lưu vị trí ban đầu của Object2Plane

        if (objectToGet1 != null)
        {
            // Đặt vị trí của objectToGet1 tại vị trí của object1Plane
            objectToGet1.transform.position = initialPosition1;
            // Khóa chuyển động của objectToGet1 để nó không bị ảnh hưởng bởi vật lý
            objectToGet1.GetComponent<Rigidbody>().isKinematic = true;
            // Xoay objectToGet1 để phù hợp với hướng của object1Plane
            objectToGet1.transform.rotation = object1Plane.rotation;
        }
        if (ObjectToGet2 != null)
        {
            // Đặt vị trí của ObjectToGet2 tại vị trí của Object2Plane
            ObjectToGet2.transform.position = initialPosition2;
            // Khóa chuyển động của ObjectToGet2 để nó không bị ảnh hưởng bởi vật lý
            ObjectToGet2.GetComponent<Rigidbody>().isKinematic = true;
            // Xoay ObjectToGet2 để phù hợp với hướng của Object2Plane
            ObjectToGet2.transform.rotation = object2Plane.rotation;
        }
    }

}
