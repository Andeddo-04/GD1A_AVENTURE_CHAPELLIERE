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
        horizontalMovement = player.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = player.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement, verticalMovement);
        MoveCrossHair();

        // Flip the character based on last move direction
        if (horizontalMovement != 0)
        {
            lastMoveDirection = new Vector2(horizontalMovement, 0f);
            Flip();
        }
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
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