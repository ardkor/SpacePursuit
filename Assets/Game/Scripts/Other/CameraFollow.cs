using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;

    private void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(playerTransform.position.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(playerTransform.position.y, minBounds.y, maxBounds.y);
        transform.position = newPosition;
    }
}
