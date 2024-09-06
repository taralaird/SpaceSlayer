using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject xCanvas;

    public void ShowPanel()
    {
        xCanvas.SetActive(true);
    }

    public void ClosePanel()
    {
        xCanvas.SetActive(false);
    }
}