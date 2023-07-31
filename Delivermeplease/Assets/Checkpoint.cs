using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool hasBox;
    [SerializeField]
    private bool givesBox = true; // По замовчуванню чекпоінт видаватиме коробку

    public bool HasBox
    {
        get { return hasBox; }
        set { hasBox = value; }
    }

    public bool GivesBox
    {
        get { return givesBox; }
        set { givesBox = value; }
    }
}
