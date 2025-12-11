using UnityEngine;

public class MobileControls : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private bool moveLeft = false;
    private bool moveRight = false;

    private void Start()
    {
        // Find the PlayerMovement script attached to your player
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void StartMoveLeft()
    {
        moveLeft = true;
    }

    public void StopMoveLeft()
    {
        moveLeft = false;
    }

    public void StartMoveRight()
    {
        moveRight = true;
    }

    public void StopMoveRight()
    {
        moveRight = false;
    }

    public void Jump()
    {
        if (playerMovement != null)
        {
            playerMovement.Jump();
            Debug.Log("Jump button pressed!");

        }
    }

    public void Attack()
    {
        if (playerMovement != null)
        {
            playerMovement.Attack();
            Debug.Log("Attack button pressed!");
        }
    }

    private void Update()
    {
        if (playerMovement != null)
        {
            if (moveLeft)
                playerMovement.SetHorizontalInput(-1);
            else if (moveRight)
                playerMovement.SetHorizontalInput(1);
            else
                playerMovement.SetHorizontalInput(0);
        }
    }
}
