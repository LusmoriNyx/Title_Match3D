using UnityEngine;

public class DragAndLift : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

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
}