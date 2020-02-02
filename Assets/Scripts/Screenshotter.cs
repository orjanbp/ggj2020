using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshotter : MonoBehaviour
{
    public static Screenshotter instance;

    public Camera animalCam;
    public Renderer[] screenshotPictureFrames;
    int currentScreenshotRendererInSequence = 0;

    private void Awake() {
        instance = this;
    }

    public static void ScreenshotAndStore() {
        instance._ScreenshotAndStore();
    }

    void _ScreenshotAndStore() {
        Debug.LogError("Going to take and store screenshot!");
        RenderTexture rt = new RenderTexture(256, 256, 24);
        animalCam.targetTexture = rt;
        Texture2D screenShot = new Texture2D(256, 256, TextureFormat.RGB24, false);
        animalCam.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        animalCam.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        screenShot.Apply();
        Destroy(rt);

        Debug.LogError("This object will receive screenshot " + screenshotPictureFrames[currentScreenshotRendererInSequence].name, screenshotPictureFrames[currentScreenshotRendererInSequence]);

        screenshotPictureFrames[currentScreenshotRendererInSequence].material.SetTexture("_BaseMap", screenShot);
        currentScreenshotRendererInSequence++;
        if (currentScreenshotRendererInSequence >= screenshotPictureFrames.Length) {
            currentScreenshotRendererInSequence = 0;
        }
    }
}
