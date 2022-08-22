using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    private float mouseX;
    private float mouseY;

    [SerializeField] private float MouseSpeed;

    private void Start()
    {
        
    }
    private void Update()
    {
        CrameraMove();
    }

    private void CrameraMove()
    {
        mouseX += Input.GetAxis("Mouse X") * MouseSpeed;
        mouseY += Input.GetAxis("Mouse Y") * MouseSpeed;
        mouseY = Mathf.Clamp(mouseY, -65f, 55f);//½Ã¾ß°¢
        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
}
