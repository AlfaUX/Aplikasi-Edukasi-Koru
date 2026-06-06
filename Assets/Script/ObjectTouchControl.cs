using UnityEngine;
using Vuforia;

public class ObjectTouchControl : MonoBehaviour
{
    [Header("Rotation Speed")]
    public float rotationSpeed = 0.1f;

    [Header("Enable Rotation Axis")]
    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ = true;

    [Header("Zoom Settings")]
    public float zoomSpeed = 0.5f;
    public float minScale = 0.5f;
    public float maxScale = 5f;

    [Header("Reset Saat Tracking Hilang")]
    public bool resetRotationOnLost = true;
    public bool resetScaleOnLost = true;

    private Vector2 lastPosition;
    private bool isRotating = false;

    private Vector3 initialScale;
    private Quaternion initialRotation;

    private ObserverBehaviour observer;

    void Start()
    {
        // Simpan transform awal
        initialScale = transform.localScale;
        initialRotation = transform.localRotation;

        // Ambil observer Vuforia
        observer = GetComponent<ObserverBehaviour>();

        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnStatusChanged;
        }
    }

    void Update()
    {
        // =====================================
        // MOBILE TOUCH ROTATION
        // =====================================

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastPosition = touch.position;
                isRotating = true;
            }
            else if (touch.phase == TouchPhase.Moved && isRotating)
            {
                Vector2 delta = touch.position - lastPosition;

                RotateObject(delta);

                lastPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isRotating = false;
            }
        }

        // =====================================
        // MOBILE PINCH ZOOM
        // =====================================

        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos =
                touch0.position - touch0.deltaPosition;

            Vector2 touch1PrevPos =
                touch1.position - touch1.deltaPosition;

            float prevMagnitude =
                (touch0PrevPos - touch1PrevPos).magnitude;

            float currentMagnitude =
                (touch0.position - touch1.position).magnitude;

            float difference =
                currentMagnitude - prevMagnitude;

            ZoomObject(difference * zoomSpeed * Time.deltaTime);
        }

        // =====================================
        // PC / UNITY EDITOR ROTATION
        // =====================================

        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
            isRotating = true;
        }

        if (Input.GetMouseButton(0) && isRotating)
        {
            Vector2 currentPosition = Input.mousePosition;
            Vector2 delta = currentPosition - lastPosition;

            RotateObject(delta);

            lastPosition = currentPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        // Mouse Scroll Zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            ZoomObject(scroll);
        }
    }

    // =====================================
    // ROTATE OBJECT
    // =====================================

    void RotateObject(Vector2 delta)
    {
        // Rotate X
        if (rotateX)
        {
            transform.Rotate(
                delta.y * rotationSpeed,
                0,
                0,
                Space.World
            );
        }

        // Rotate Y
        if (rotateY)
        {
            transform.Rotate(
                0,
                -delta.x * rotationSpeed,
                0,
                Space.World
            );
        }

        // Rotate Z
        if (rotateZ)
        {
            transform.Rotate(
                0,
                0,
                -delta.x * rotationSpeed,
                Space.World
            );
        }
    }

    // =====================================
    // ZOOM
    // =====================================

    void ZoomObject(float increment)
    {
        Vector3 newScale =
            transform.localScale + Vector3.one * increment;

        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

        transform.localScale = newScale;
    }

    // =====================================
    // TRACKING STATUS
    // =====================================

    void OnStatusChanged(
        ObserverBehaviour behaviour,
        TargetStatus status)
    {
        bool isTracked =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED;

        // Tracking hilang
        if (!isTracked)
        {
            if (resetRotationOnLost)
            {
                transform.localRotation = initialRotation;
            }

            if (resetScaleOnLost)
            {
                transform.localScale = initialScale;
            }
        }
    }

    private void OnDestroy()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged -= OnStatusChanged;
        }
    }
}