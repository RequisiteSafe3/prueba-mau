using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireFlies : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform[] pDots;
    [SerializeField] private float minDistance;
    private int randomNum;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        randomNum = Random.Range(0, pDots.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, pDots[randomNum].position, movementSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, pDots[randomNum].position) < minDistance) {
            randomNum = Random.Range(0, pDots.Length);
        }
    }

}
