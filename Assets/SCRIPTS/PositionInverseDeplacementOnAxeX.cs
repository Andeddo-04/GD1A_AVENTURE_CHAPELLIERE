using UnityEngine;

public class PositionInverseDeplacementOnAxeX : MonoBehaviour
{
    public float moveSpeed;
    public Transform player; // Référence au joueur
    public GameObject elementToReverse; // Référence à l'élément à déplacer en inversé

    void Update()
    {
        // Récupère le mouvement horizontal du joueur
        float movementX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Calcule le déplacement inversé sur l'axe X pour l'élément à inverser
        float reverseMovementX = -movementX;

        // Applique le déplacement inversé sur l'axe X à l'élément à inverser
        elementToReverse.transform.position += Vector3.right * reverseMovementX * Time.deltaTime;
    }
}

