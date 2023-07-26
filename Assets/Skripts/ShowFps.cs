using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowFps : MonoBehaviour
{
    private float fps;
    [SerializeField] private Text fpsText;

    private void Update()
    {
            fps = 1f / Time.deltaTime;
            fpsText.text = $"FPS: {(int)fps}";
    }
}
