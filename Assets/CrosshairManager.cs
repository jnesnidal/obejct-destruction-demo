using UnityEngine;

public class CrosshairManager : MonoBehaviour
{
    public Texture2D crosshairTexture;

    void OnGUI()
    {
        float size = 24f;
        float xMin = (Screen.width - size) / 2;
        float yMin = (Screen.height - size) / 2;
        GUI.DrawTexture(new Rect(xMin, yMin, size, size), crosshairTexture);
    }
}