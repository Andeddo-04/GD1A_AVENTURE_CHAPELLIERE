using Rewired;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement, verticalMovement;

    [SerializeField] private float moveSpeed;

    [SerializeField] private Rigidbody2D characterSprite;

    [SerializeField] private SpriteRenderer characterSpriteRenderer;

    private Vector3 velocity = Vector3.zero;

    public bool completeDongeon = false;

    private Vector2 lastMoveDirection = Vector2.right; // Store last move direction

    private Vector3 attackDirection;

    public GameObject crossHair;

    private Player player;

    public int playerId = 0;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }

    void Update()
    {
        MovePlayer();
        MoveCrossHair();
        RotatePlayerTowardsCrosshair();

        // Flip the character based on last move direction
        //if (horizontalMovement != 0)
        //{
        //    lastMoveDirection = new Vector2(horizontalMovement, 0f);
        //    Flip();
        //}
    }

    void MovePlayer()
    {
        horizontalMovement = player.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = player.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);
        characterSprite.velocity = Vector3.SmoothDamp(characterSprite.velocity, targetVelocity, ref velocity, 0.05f);
    }

    private void MoveCrossHair()
    {
        attackDirection = new Vector3(player.GetAxis("AimHorizontal"), player.GetAxis("AimVertical"), 0.0f);

        if (attackDirection.magnitude > 0.0f)
        {
            attackDirection.Normalize();
            attackDirection *= 2.0f;
            crossHair.transform.localPosition = attackDirection;
            crossHair.SetActive(true);
        } else
        {
            crossHair.SetActive(false);
        }
    }

    private void RotatePlayerTowardsCrosshair()
    {
        if (crossHair && crossHair.activeSelf)
        {
            // Get the direction from player position to crosshair position
            Vector3 directionToCrosshair = crossHair.transform.position - transform.position;

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(directionToCrosshair.y, directionToCrosshair.x) * Mathf.Rad2Deg;

            // Rotate the player sprite towards the crosshair
            characterSpriteRenderer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            // Reset the rotation of the player sprite if crosshair is not active
            characterSpriteRenderer.transform.rotation = Quaternion.identity;
        }

    }

    void Flip()
    {
        if (lastMoveDirection.x < 0)
        {
            characterSpriteRenderer.flipX = false;
        }
        else if (lastMoveDirection.x > 0)
        {
            characterSpriteRenderer.flipX = true;
        }
    }
}