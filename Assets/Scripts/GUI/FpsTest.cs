using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsTest : MonoBehaviour
{
    public Text TextFps;
    public float DeltaTime;

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        DeltaTime += (Time.deltaTime - DeltaTime) * 0.1f;
        float fps = 1.0f / DeltaTime;
        TextFps.text = "fps: " + Mathf.Ceil(fps).ToString();
    }
}
