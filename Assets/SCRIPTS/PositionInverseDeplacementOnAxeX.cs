using UnityEngine;

public class PositionInverseDeplacementOnAxeX : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public GameObject elementToReverse; // Référence à l'élément à déplacer en inversé

    void Update()
    {
        // Récupère la position x du joueur
        float playerPositionX = player.position.x;

        // Calcule l'inverse de la position x du joueur pour l'élément à inverser
        float inversePositionX = -playerPositionX;

        // Récupère la position y du joueur
        float playerPositionY = player.position.y;

        // Modifie directement la position x de l'élément avec l'inverse de la position x du joueur
        // Modifie la position y de l'élément avec la position y du joueur
        elementToReverse.transform.position = new Vector3(inversePositionX, playerPositionY, elementToReverse.transform.position.z);
    }
}
