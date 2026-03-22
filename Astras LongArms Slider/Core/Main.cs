using GorillaLocomotion;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Astras_GUI_Template.Core;

public class Main : MonoBehaviour
{
    private Rect Window = new Rect(155, 155, 360, 460);
    private bool Open = false;
    private bool SLoaded = false;
    private Texture2D? WTexture, BTexture;
    private GUIStyle? WStyle, BStyle;
    private Texture2D? Slidertex, SliderThumbtex;
    private GUIStyle?  SliderStyle, SliderThumbStyle;
    private Color WColor = new Color(0.1f, 0.1f, 0.1f, 1f);
    private Color BColor = new Color(0.2f, 0.2f, 0.2f, 1f);
    private Color sliderTrackColor = new Color(0.15f, 0.15f, 0.15f, 1f);
    private Color sliderThumbColor = new Color(0.0f, 0.6f, 1f, 1f);
    private float WorldScaleValue = 0f;


    private void OnGUI()
    {
        if (!SLoaded)
        {
            INIT();
            SLoaded = true;
        }
        if (Open)
        {
            Window = GUILayout.Window(000321434, Window, UIM, "Astras LongArm Settings", WStyle);
        }
    }

    private void Update()
    {
        if (Keyboard.current.leftAltKey.wasPressedThisFrame)
        {
            Open = !Open;
        }
    }


    private void UIM(int id)
    {
        MMod();
        GUILayout.Space(5f);
        if (GUILayout.Button("Close", BStyle))
        {
            Open = !Open;
        }
        GUI.DragWindow();
    }

    private void MMod()
    {
        GUILayout.Label("Set WorldScale");
        WorldScaleValue = GUILayout.HorizontalSlider(WorldScaleValue, 0.1f, 5.5f, SliderStyle, SliderThumbStyle);
        GUILayout.Label($"World Scale: {WorldScaleValue}");
        GUILayout.Space(2f);
        if (GUILayout.Button("Set Arms (Custom)", BStyle))
        {
            SetArms(WorldScaleValue);
        }
        if (GUILayout.Button("Reset Arms", BStyle))
        {
            ResetArms();
        }
        GUILayout.Space(5f);
        GUILayout.Label("Presets:");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Random", BStyle))
        {
            WorldScaleValue = UnityEngine.Random.Range(0.1f, 5.5f);
            SetArms(WorldScaleValue);
        }
        if (GUILayout.Button("legit", BStyle))
        {
            WorldScaleValue = 2f;
            SetArms(WorldScaleValue);
        }
        if (GUILayout.Button("Normal LongArms", BStyle))
        {
            WorldScaleValue = 2.5f;
            SetArms(WorldScaleValue);
        }
        if (GUILayout.Button("Max", BStyle))
        {
            WorldScaleValue = 5.5f;
            SetArms(WorldScaleValue);
        }
        GUILayout.EndHorizontal();
    }

    private void ResetArms()
    {
        GTPlayer.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void SetArms(float ArmAmount)
    {
        GTPlayer.Instance.transform.localScale = new Vector3(ArmAmount, ArmAmount, ArmAmount);
    }

    private void INIT()
    {
        WTexture = MakeTexture(1, 1, WColor);
        BTexture = MakeTexture(1, 1, BColor);
        Slidertex = MakeTexture(1, 1, sliderTrackColor);
        SliderThumbtex = MakeTexture(1, 1, sliderThumbColor);

        WStyle = new GUIStyle(GUI.skin.window);
        WStyle.normal.background = WTexture;
        WStyle.hover.background = WTexture;
        WStyle.active.background = WTexture;
        WStyle.focused.background = WTexture;
        WStyle.onActive.background = WTexture;
        WStyle.onNormal.background = WTexture;
        WStyle.onFocused.background = WTexture;
        WStyle.normal.textColor = Color.white;
        WStyle.fontStyle = FontStyle.Normal;

        BStyle = new GUIStyle(GUI.skin.button);
        BStyle.normal.background = BTexture;
        BStyle.active.background = BTexture;
        BStyle.hover.background = BTexture;
        BStyle.focused.background = BTexture;
        BStyle.onHover.background = BTexture;
        BStyle.onNormal.background = BTexture;
        BStyle.onActive.background = BTexture;
        BStyle.onFocused.background = BTexture;
        BStyle.normal.textColor = Color.white;
        BStyle.hover.textColor = Color.blue;
        BStyle.active.textColor = Color.red;
        BStyle.focused.textColor = Color.white;
        BStyle.onNormal.textColor = Color.blue;
        BStyle.onHover.textColor = Color.blue;
        BStyle.onActive.textColor = Color.blue;
        BStyle.onFocused.textColor = Color.blue;

        SliderStyle = new GUIStyle(GUI.skin.horizontalSlider);
        SliderThumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb);
        SliderStyle.normal.background = Slidertex;
        SliderStyle.active.background = Slidertex;
        SliderStyle.hover.background = Slidertex;
        SliderThumbStyle.normal.background = SliderThumbtex;
        SliderThumbStyle.active.background = SliderThumbtex;
        SliderThumbStyle.hover.background = SliderThumbtex;
    }

    private Texture2D MakeTexture(int WW, int HH, Color COLL)
    {
        Texture2D H = new Texture2D(WW, HH);
        H.SetPixel(0, 0, COLL);
        H.Apply();
        return H;
    }
}