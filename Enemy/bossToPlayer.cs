using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossToPlayer : MonoBehaviour
{

	public Transform player;

	public bool isFlipped = false;

	public void LookAtPlayer()
	{
		//Create a Vector3 variable to store the flipped scale
		Vector3 flipped = transform.localScale;
		//Flip the object on the Z-axis
		flipped.z *= -1f;
		// Check if the object's x position is less than the player's x position and if the object is currently flipped
		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		// Check if the object's x position is greater than the player's x position and if the object is not flipped
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

}