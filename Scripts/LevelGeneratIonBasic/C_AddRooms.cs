using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_AddRooms : MonoBehaviour
{
    C_RoomSpawner g_RoomSpawner ;

    // Start is called before the first frame update
    void Start()
    {
        g_RoomSpawner = GameObject.FindGameObjectWithTag("RoomSpawner").GetComponent<C_RoomSpawner>();
        g_RoomSpawner.g_Rooms.Add(this.gameObject);
    }
}
