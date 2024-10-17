using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public static float gravityCoe = -135f;
    public static float jumpForce = 45f;
    public static float jumpCoolDown = 0.4f;
    //time to stop go up: t = 45/135 ~ 0.33s
    //max height = 45*1/3 + 1/2 * -135 * (1/3)^2 = 7.5
}
