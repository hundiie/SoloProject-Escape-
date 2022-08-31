using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float X { get; private set; }
    public float Z { get; private set; }
    public bool Key_MOUSE_RIGHT { get; private set; }
    public bool Key_Shift { get; private set; }
    public bool Key_Ctrl { get; private set; }
    public bool Key_Space { get; private set; }
    public bool Key_Esc { get; private set; }
    public bool Key_T { get; private set; }
    public bool Key_R { get; private set; }
    private void FixedUpdate()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");
        Key_MOUSE_RIGHT = Input.GetKey(KeyCode.Mouse0);
        Key_Shift = Input.GetKey(KeyCode.LeftShift);
        Key_Ctrl = Input.GetKey(KeyCode.LeftControl);
        Key_Space = Input.GetKey(KeyCode.Space);
        Key_Esc = Input.GetKey(KeyCode.Escape);
        Key_T = Input.GetKey(KeyCode.T);
        Key_R = Input.GetKey(KeyCode.R);
    }
}
