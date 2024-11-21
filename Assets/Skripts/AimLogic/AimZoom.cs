using UnityEngine;

public class AimZoom : MonoBehaviour
{
    public Camera mainCamera; // Основная камера
    public float normalFOV = 60f; // Обычное поле зрения
    public float zoomFOV = 30f;   // Поле зрения для зума (меньше = сильнее зум)
    public float zoomSpeed = 10f; // Скорость анимации зума

    private bool isZooming = false;

    public GameObject crosshair; // Ссылка на UI-объект прицела

    void Update()
    {
        // Проверяем, нажата ли левая кнопка мыши
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isZooming = true;
            crosshair.SetActive(true); // Включаем прицел
            mainCamera.fieldOfView = Mathf.Lerp(
               mainCamera.fieldOfView,
               zoomFOV,
               Time.deltaTime * zoomSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isZooming = false;
            crosshair.SetActive(false); // Выключаем прицел
            mainCamera.fieldOfView = Mathf.Lerp(
               mainCamera.fieldOfView,
               normalFOV,
               Time.deltaTime * zoomSpeed);
        }

    
    }
}