using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SolarController : MonoBehaviour
{
    public Transform a; // Sun
    public Transform b; // Earth
    public Transform c; // Moon
    public TMP_Text label;
    public Slider RotateSlider;
    public Slider PositionSlider;
    public Slider ScaleSlider;

    private void PrintInfo()
    {
        label.text = $@"
    Sol
        Position: ({a.position.x.ToString("F2") }, {a.position.y.ToString("F2") }, {a.position.z.ToString("F2") })
        Rotation: ({a.localEulerAngles.x.ToString("F2") }, {a.localEulerAngles.y.ToString("F2") }, {a.localEulerAngles.z.ToString("F2") })
        Scale: ({a.localScale.x.ToString("F2") },{a.localScale.y.ToString("F2") },{a.localScale.z.ToString("F2") })
    Tierra
        Position: ({b.position.x.ToString("F2") }, {b.position.y.ToString("F2") }, {b.position.z.ToString("F2") })
        Rotation: ({b.localEulerAngles.x.ToString("F2") }, {b.localEulerAngles.y.ToString("F2") }, {b.localEulerAngles.z.ToString("F2") })
        Scale: ({b.localScale.x.ToString("F2") },{b.localScale.y.ToString("F2") },{b.localScale.z.ToString("F2") })
    Luna
        Position: ({c.position.x.ToString("F2") }, {c.position.y.ToString("F2") }, {c.position.z.ToString("F2") })
        Rotation: ({c.localEulerAngles.x.ToString("F2") }, {c.localEulerAngles.y.ToString("F2") }, {c.localEulerAngles.z.ToString("F2") })
        Scale: ({c.localScale.x.ToString("F2") },{c.localScale.y.ToString("F2") },{c.localScale.z.ToString("F2") })
        ";
    }

    public void Rotate()
    {
        float value = RotateSlider.value;

        a.localEulerAngles = (new Vector3(0,value*360,0));
        b.localEulerAngles = (new Vector3(0,2*value*360,0));

        PrintInfo();
    
    }

    public void Position()
    {
        float value = PositionSlider.value;
        a.position = new Vector3(0,value,0);

        PrintInfo();
    }

    public void Scale()
    {
        float value = ScaleSlider.value;
        a.localScale = (new Vector3(3,3,3))*value;

        PrintInfo();
    }

    void Start()
    {
        PrintInfo();
    }
}
