
using UnityEngine;

public class RotatorManager : MonoBehaviour
{
    private bool movementSetter;
    public int MovementSpeed;
    public int movementOffset=0;
    public Direction direction=Direction.LEFT;
    private void Update()
    {
        if (direction == Direction.LEFT)
        {
            transform.Rotate(0, 0, MovementSpeed*Time.deltaTime);
        }
        else
        {
            if(movementSetter==true)
            {
                transform.position=new Vector3(transform.position.x+(MovementSpeed*Time.deltaTime), transform.position.y,0);
                if(transform.position.x>movementOffset)
                {
                    movementSetter = false;
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x - (MovementSpeed * Time.deltaTime), transform.position.y, 0);
                if (transform.position.x < -1*movementOffset)
                {
                    movementSetter = true;
                }
            }
        }
    }
}

public enum Direction
{
    LEFT,
    RIGHT
}
