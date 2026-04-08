using UnityEngine;

public class DragAndLift : MonoBehaviour
{
    public static DragAndLift instance; // Singleton instance
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

    private Vector3 mOffset; // Khoảng cách từ tâm vật đến điểm click
    private float mZCoord; // Khoảng cách Z từ Camera đến vật thể

    [Header("Cài đặt nhấc vật")]
    public float liftAmount = 0.5f; // Khoảng cách y muốn nhấc lên

    void OnMouseDown()
    {
        // 1. Xác định khoảng cách Z từ Camera đến vật thể
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // 2. Tính toán offset (khoảng cách từ tâm vật đến điểm click) 
        // và cộng thêm liftAmount vào trục Y
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        mOffset.y += liftAmount;
    }

    private Vector3 GetMouseWorldPos()
    {
        // Tọa độ pixel của chuột (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // Tọa độ z của vật thể trong không gian thế giới
        mousePoint.z = mZCoord;

        // Chuyển đổi sang tọa độ thế giới
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        // Cập nhật vị trí vật thể theo chuột + offset đã tính
        transform.position = GetMouseWorldPos() + mOffset;
    }

    

     public void OnMouseUp()
    {
        mOffset = Vector3.zero;
    }

}