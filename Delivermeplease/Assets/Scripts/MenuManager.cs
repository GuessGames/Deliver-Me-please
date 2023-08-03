using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject gameCanvas;
    public Transform cameraFollowPosition;
    public Transform playerTransform;

    private Camera mainCamera;
    private bool isMenuActive = true;
    private Vector3 initialCameraPosition;

    private void Start()
    {
        mainCamera = Camera.main;
        initialCameraPosition = mainCamera.transform.position;
        SwitchToMenu();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // Перевірка чи не натискаємо на інтерфейс
        {
            if (isMenuActive)
            {
                SwitchToGame();
            }
        }

        if (!isMenuActive && playerTransform != null)
        {
            mainCamera.transform.position = cameraFollowPosition.position;
            mainCamera.transform.LookAt(playerTransform.position);
        }
    }

    private void SwitchToMenu()
    {
        menuCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        mainCamera.transform.position = initialCameraPosition;
        isMenuActive = true;
    }

    private void SwitchToGame()
    {
        menuCanvas.SetActive(false);
        gameCanvas.SetActive(true);

        LeanTween.move(mainCamera.gameObject, cameraFollowPosition.position, 1f).setOnComplete(() => {
            isMenuActive = false;
        });
    }
}
