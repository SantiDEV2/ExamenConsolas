using UnityEngine;

public class PlayerController: Character 
{
    private void Update()
    {
        Vector3 movement = (Input.GetAxisRaw("Horizontal") * Vector3.right);
        Move(movement);
    }
}
