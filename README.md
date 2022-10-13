# Flappy-Bird-Clone

## Requirement
### Not using Unity Physics (Collider, Rigid Body,...)
Know collide through position of the player and the obstacle. 
Formula: Distance of the player <= (size of the player + size of the pipe)
```cs
		float distanceX = Mathf.Abs(transform.position.x - player.transform.position.x);
		float distanceY = Mathf.Abs(transform.position.y - player.transform.position.y);

		float offsetLocalScaleX = pipeSizeX + playerSizeX;
		float offsetLocalScaleY = pipeSizeY + playerSizeY;

		if (distanceX <= (playerSizeX + pipeSizeX) && distanceY <= (playerSizeY + pipeSizeY))
   {
			   // Lost Trigger
   }
```
