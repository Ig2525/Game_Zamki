using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;
    public float easing = 0.5f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamicaly")]
    public float camZ;

    private void Awake()
    {
        camZ=this.transform.position.z;
    }

   // Update is called once per frame
    void FixedUpdate()
    {
        //   if (POI == null) return;  // выйти, если нет интересующего объекта
        // Получить позицию интересующего объекта
        //   Vector3 destination =POI.transform.position;
        
        //Возврат для другого выстрела:

        Vector3 destination;
        // Если нет интересующего объекта, вернуть Р:[ 0, 0, 0 ]      
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            // Получить позицию интересующего объекта
            destination = POI.transform.position;
            // Если интересующий объект - снаряд, убедиться, что он остановился
            if (POI.tag == "Progectile")
            {
                // Если он стоит на месте (то есть не двигается)
                if (POI.GetComponent<Rigidbody>().IsSleeping() )
                {
                    // Вернуть исходные настройки поля зрения камеры в следующем кадре
                    POI = null;      
                    return;
                }
            }
        }

        // Ограничить X и Y минимальными значениями
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination=Vector3.Lerp(transform.position, destination, easing);
        destination.z=camZ;
        transform.position=destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}
