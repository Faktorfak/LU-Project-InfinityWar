using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player; // A reference to the GameObject that the camera should follow
    public float offset;//value that represents the distance between the player and the camera on the x-axis
    public float offsetSmooting;//loat value that controls the smoothness of the camera's movement
    private Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per after other updates frame
    void LateUpdate()
    {
       playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0f) //  player are facing l or r
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);

        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmooting * Time.deltaTime);// moving camera with player 
    }
}
