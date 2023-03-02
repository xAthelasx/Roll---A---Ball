using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody _rb;
    private int count;
    private int totalPickUp;

    private float movementX;
    private float movementY;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        totalPickUp = GameObject.FindGameObjectsWithTag("PickUp").Length;
        count = 0;
        winTextObject.SetActive(false);
        SetCountText();
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movement = movementValue.Get<Vector2>();

        movementX = movement.x;
        movementY = movement.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0, movementY);

        _rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= totalPickUp)
        {
            winTextObject.SetActive(true);
        }
    }
}
