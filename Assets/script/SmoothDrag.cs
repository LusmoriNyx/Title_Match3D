using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class SmoothDrag : MonoBehaviour
{
    private Rigidbody rb;
    private bool isDragging = false;
    private float zCoord;
    private Vector3 offset;

    [Header("Cấu hình di chuyển")]
    public float liftAmount = 0.5f;
    public float smoothTime = 0.1f;

    [Header("Cấu hình quán tính")]
    [Range(1f, 5f)]
    public float throwForceMultiplier = 1.5f; // Hệ số nhân lực quăng (tăng nếu muốn văng mạnh hơn)

    private Vector3 currentVelocity = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Interpolate giúp chuyển động mượt mà, không bị giật hình
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        var mouse = Mouse.current;
        if (mouse == null) return;

        // 1. KHI BẮT ĐẦU CHẠM
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    isDragging = true;
                    zCoord = Camera.main.WorldToScreenPoint(transform.position).z;

                    Vector3 mouseWorldPos = GetMouseWorldPos(mouse.position.ReadValue());
                    offset = transform.position - mouseWorldPos;
                    offset.y += liftAmount;

                    rb.useGravity = false;
                    // Quan trọng: Đặt dâmping (lực cản) thấp để vật bay tự nhiên
                    rb.linearDamping = 0.5f;
                    rb.angularDamping = 0.5f;
                }
            }
        }

        // 2. KHI THẢ TAY (Tạo quán tính)
        if (mouse.leftButton.wasReleasedThisFrame && isDragging)
        {
            isDragging = false;
            rb.useGravity = true;

            // Gán vận tốc hiện tại của cú kéo cho vật thể để nó văng đi
            rb.linearVelocity = currentVelocity * throwForceMultiplier;
        }
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 targetPos = GetMouseWorldPos(Mouse.current.position.ReadValue()) + offset;

            // SmoothDamp tính toán 'currentVelocity' dựa trên tốc độ di chuyển chuột của bạn
            Vector3 nextPos = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothTime);

            rb.MovePosition(nextPos);
        }
    }

    private Vector3 GetMouseWorldPos(Vector2 mousePos)
    {
        Vector3 mousePoint = new Vector3(mousePos.x, mousePos.y, zCoord);
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}