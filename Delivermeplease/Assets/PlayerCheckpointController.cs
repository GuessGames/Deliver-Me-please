using UnityEngine;

public class PlayerCheckpointController : MonoBehaviour
{
    [SerializeField]
    private Transform playerMeshTransform;

    [SerializeField]
    private GameObject boxPrefab; // Попередньо створіть префаб коробки

    [SerializeField]
    private GameObject particleDestroyBoxPrefab; // Попередньо створіть префаб частинок для знищення коробки

    private GameObject currentBox;
    private bool hasBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            Checkpoint checkpoint = other.GetComponent<Checkpoint>();
            if (checkpoint != null)
            {
                if (!hasBox && checkpoint.GivesBox) // Якщо гравець не має коробки та чекпоінт видає коробку
                {
                    TakeBox(checkpoint);
                }
                else if (hasBox && !checkpoint.GivesBox) // Якщо гравець має коробку та чекпоінт знищує її
                {
                    DropBox(checkpoint);
                }
            }
        }
    }

    private void TakeBox(Checkpoint checkpoint)
    {
        // Створити коробку та прикріпити її перед гравцем
        currentBox = Instantiate(boxPrefab, playerMeshTransform.position, Quaternion.identity);
        currentBox.transform.parent = playerMeshTransform;
        hasBox = true;

        // Позначити чекпоінт як вже видали коробку

    }

    private void DropBox(Checkpoint checkpoint)
    {
        // Знищити коробку та забрати її з гравця
        Destroy(currentBox);
        hasBox = false;

        // Створити префаб частинок на місці знищеної коробки
        Instantiate(particleDestroyBoxPrefab, currentBox.transform.position, Quaternion.identity);

        // Позначити чекпоінт як вільний (без коробки)

    }
}
