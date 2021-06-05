using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RoomSpawner : MonoBehaviour
{
    public GameObject [] g_LeftRooms ;

    public GameObject [] g_TopRooms ;

    public GameObject [] g_RightRooms ;

    public GameObject [] g_DownRooms ;

    public GameObject g_EmptyRoom ;

    public List<GameObject> g_Rooms ;

    public GameObject g_Boss ;

    float g_FloatWaitTime ;
    bool g_BoolIsSpawned ;

    void Start()
    {
        g_FloatWaitTime = 10.0f ;
        g_BoolIsSpawned = false ;
    }

    void Update()
    {
        g_FloatWaitTime -= Time.deltaTime ;

        if ( g_FloatWaitTime <= 0 )
        {
            if ( !g_BoolIsSpawned )
            {
                Instantiate( g_Boss , g_Rooms[ g_Rooms.Count - 1 ].transform.position , Quaternion.identity );
                g_BoolIsSpawned = true ;
            }
        }

    }

}
