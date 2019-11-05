using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    [SerializeField] private float defaultLength = 5.0f;
    [SerializeField] private GameObject dot = null;

    public Camera Camera { get; private set; } = null;

    private LineRenderer lineRenderer = null;
    private VRInputModule inputModule = null;

    private void Awake()
    {
        Camera = GetComponent<Camera>();
        Camera.enabled = false;

        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        // current.currentInputModule does not work
        inputModule = EventSystem.current.gameObject.GetComponent<VRInputModule>();
    }

    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // Use default or distance
        PointerEventData data = inputModule.Data;
        RaycastHit hit = CreateRaycast();

        // If nothing is hit, set do default length
        float colliderDistance = hit.distance == 0 ? defaultLength : hit.distance;
        float canvasDistance = data.pointerCurrentRaycast.distance == 0 ? defaultLength : data.pointerCurrentRaycast.distance;

        // Get the closest one
        float targetLength = Mathf.Min(colliderDistance, canvasDistance);

        // Default
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        // Set position of the dot
        dot.transform.position = endPosition;

        // Set linerenderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }
}
