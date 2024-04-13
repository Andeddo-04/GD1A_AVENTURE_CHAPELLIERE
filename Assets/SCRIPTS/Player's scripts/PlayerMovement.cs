using Rewired;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float controler_horizontalMovement, controler_verticalMovement, keyboard_horizontalMovement, keyboard_verticalMovement;

    [SerializeField] private float moveSpeed;

    [SerializeField] private Rigidbody2D characterSprite;

    [SerializeField] private SpriteRenderer characterSpriteRenderer;

    private Vector3 velocity = Vector3.zero;

    public bool completeDongeon = false;

    private Vector2 lastMoveDirection = Vector2.right; // Store last move direction

    private Vector3 attackDirection;

    public GameObject crossHair,newPosition;

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
        crossHairTracker();
    }

    void MovePlayer()
    {
        // * Contrôle a la manette * \\
        controler_horizontalMovement = player.GetAxis("Controler_MoveHorizontal") * moveSpeed * Time.deltaTime;
        controler_verticalMovement = player.GetAxis("Controler_MoveVertical") * moveSpeed * Time.deltaTime;

        Vector3 targetVelocityWhisControler = new Vector2(controler_horizontalMovement, controler_verticalMovement);
        characterSprite.velocity = Vector3.SmoothDamp(characterSprite.velocity, targetVelocityWhisControler, ref velocity, 0.05f);

        // * Contrôle au clavier * \\
        keyboard_horizontalMovement = player.GetAxis("KeyBoard_MoveHorizontal") * moveSpeed * Time.deltaTime;
        keyboard_verticalMovement = player.GetAxis("KeyBoard_MoveVertical") * moveSpeed * Time.deltaTime;

        Vector3 targetVelocityWhisKeyBoard = new Vector2(keyboard_horizontalMovement, keyboard_verticalMovement);
        characterSprite.velocity = Vector3.SmoothDamp(characterSprite.velocity, targetVelocityWhisKeyBoard, ref velocity, 0.05f);
    }

    private void MoveCrossHair()
    {
        attackDirection = new Vector3(player.GetAxis("Controler_AimHorizontal"), player.GetAxis("Controler_AimVertical"), 0.0f);

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

    void crossHairTracker()
    {
        GameObject.FindGameObjectWithTag("crossHairTracker").transform.position = newPosition.transform.position;
    }
}