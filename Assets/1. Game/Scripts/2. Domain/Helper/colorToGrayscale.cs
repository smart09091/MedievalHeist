using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class colorToGrayscale : MonoBehaviour
{

    [SerializeField ]private Texture2D []list;

    string fileName = "BASIC256_greyscale_Mona_Lisa";
    Texture2D graph;

    void Start()
    {
       // LoadImage();
        ConvertToGrayscale();
    }

    void LoadImage()
    {
       // graph = Resources.Load(fileName, typeof(Texture2D)) as Texture2D;
    }

    void ConvertToGrayscale()
    {

        graph = list[0];
        //Color32[] pixels = graph.GetPixels32();
        //for (int x = 0; x < graph.width; x++)
        //{
        //    for (int y = 0; y < graph.height; y++)
        //    {
        //        Color32 pixel = pixels[x + y * graph.width];

        //        int p = ((256 * 256 + pixel.r) * 256 + pixel.b) * 256 + pixel.g;
        //        int b = p % 256;
        //        p = Mathf.FloorToInt(p / 256);
        //        int g = p % 256;
        //        p = Mathf.FloorToInt(p / 256);
        //        int r = p % 256;
        //        float l = (0.2126f * r / 255f) + 0.7152f * (g / 255f) + 0.0722f * (b / 255f);
        //        Color c = new Color(l, l, l, 1);
        //        graph.SetPixel(x, y, c);


        //    }
        //}
        Color[] screenshotColors = graph.GetPixels(0);

        for (int i = 0; i < screenshotColors.Length; i++)
        {
            screenshotColors[i].r = screenshotColors[i].grayscale;
            screenshotColors[i].g = screenshotColors[i].grayscale;
            screenshotColors[i].b = screenshotColors[i].grayscale;
            screenshotColors[i].a = 1f;
        }

        graph.SetPixels(screenshotColors, 0);
        graph.Apply(false);
        var bytes = graph.EncodeToJPG();
      

        System.IO.File.WriteAllBytes(Application.dataPath + "/ScreenShot/Gray/" + list[0].name + ".png", bytes);
    }

   
}
