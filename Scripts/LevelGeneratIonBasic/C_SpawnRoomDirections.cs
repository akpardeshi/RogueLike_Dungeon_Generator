using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SpawnRoomDirections : MonoBehaviour
{
    // 1 -- left 2 -- top 3 -- right 4 -- down
    public int g_RoomDirection ;
    float g_FloatSpawnTime ;
    C_RoomSpawner g_RoomSpawner ;
    public bool g_BoolIsSpawned ;
    
    void Start()
    {
        g_BoolIsSpawned = false ;
        g_RoomSpawner = GameObject.FindGameObjectWithTag("RoomSpawner").GetComponent<C_RoomSpawner>();
        g_FloatSpawnTime = 0.2f ;
        Invoke( "m_InitialiseRooms" , g_FloatSpawnTime );
    }

    void m_InitialiseRooms()
    {
        int l_RandomRoom ;

        if ( !g_BoolIsSpawned )
        {
            if ( g_RoomDirection == 1 )
            {
                l_RandomRoom = Random.Range ( 0 , g_RoomSpawner.g_RightRooms.Length) ; 
                Instantiate( g_RoomSpawner.g_RightRooms[l_RandomRoom], this.transform.position , Quaternion.identity );
            }

            else if ( g_RoomDirection == 2 )
            {
                l_RandomRoom = Random.Range ( 0 , g_RoomSpawner.g_DownRooms.Length) ; 
                Instantiate( g_RoomSpawner.g_DownRooms[l_RandomRoom], this.transform.position , Quaternion.identity );
            }

            else if ( g_RoomDirection == 3 )
            {
                l_RandomRoom = Random.Range ( 0 , g_RoomSpawner.g_LeftRooms.Length ) ; 
                Instantiate( g_RoomSpawner.g_LeftRooms[l_RandomRoom], this.transform.position , Quaternion.identity );
            }

            else if ( g_RoomDirection == 4 )
            {
                l_RandomRoom = Random.Range ( 0 , g_RoomSpawner.g_TopRooms.Length) ; 
                Instantiate( g_RoomSpawner.g_TopRooms[l_RandomRoom], this.transform.position , Quaternion.identity );
            } 

            g_BoolIsSpawned = true ;          
        }
    }

    void OnTriggerEnter2D( Collider2D trigger )
    {
        if ( trigger.gameObject.tag == "SpawnPoint" )
        {         
            if ( trigger.gameObject.GetComponent<C_SpawnRoomDirections>() )   
            {
                if ( !trigger.gameObject.GetComponent<C_SpawnRoomDirections>().g_BoolIsSpawned && !this.g_BoolIsSpawned  )
                {
                    Instantiate(g_RoomSpawner.g_EmptyRoom, this.transform.position , Quaternion.identity );
                    Destroy(this.gameObject);
                }
            }

            g_BoolIsSpawned = true ;
        }        
    } 
}
