using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Класс для различных функций, которые пригодятся в разных частях программы
/// </summary>
public class Utils : MonoBehaviour
{
    public static Vector2 MousePos(Camera cam)
    {
        return new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);
    }
    public static GameObject ClickSelect(Camera cam)
    {
        Vector2 rayPos = MousePos(cam);
        RaycastHit2D hit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));
        Debug.Log(hit.transform.position);
        if (hit)
        {
            //Debug.Log(hit.transform.name);
            return hit.transform.gameObject;
        }
        else return null;
    }
}
