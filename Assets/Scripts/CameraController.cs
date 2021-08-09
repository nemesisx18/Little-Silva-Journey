using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Camera gameCamera;

    private void Update()
    {
        if (player.transform.position.y > -1)
        {
            gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
        }
        else
        {
            gameCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameCamera.transform.position.z);

        }
    }
}
