using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform player;
    

    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + 5f, player.position.y + 3.5f, transform.position.z) ;
    }
}
