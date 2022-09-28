using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour {
    public Camera cam;
    public Transform subject;

    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;

    float distanceFromSubect => transform.position.z - subject.position.z;
    float clippingPlane => (cam.transform.position.z + (distanceFromSubect > 0? cam.farClipPlane : cam.nearClipPlane)); // ? = if, 1 ":" -> or 2.
    float parallaxFactor => Mathf.Abs(distanceFromSubect) / clippingPlane; // Abs = Absolute value.

    private void Start() {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    private void Update() {
        Vector2 newPos = startPosition + travel * parallaxFactor * 19;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);

    }


}
