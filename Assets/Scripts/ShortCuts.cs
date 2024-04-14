using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortCuts : MonoBehaviour
{
    public static bool isAttackButtonPressed => Input.GetMouseButtonDown(0);
    public static bool wasLeftShiftPressed => Input.GetKey(KeyCode.LeftShift);
    public static bool Horizontal => Input.GetAxis("Horizontal") != 0;
    public static bool Vertical => Input.GetAxis("Vertical") != 0;
    public static bool Jump => Input.GetKeyDown(KeyCode.Space);
}
