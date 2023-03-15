using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersController : MonoBehaviour
{
    // References to sliders in the UI
    public Slider scaleSlider;
    public Slider rotateSlider;

    // Private variables for storing slider values
    private float angleSliderNumber;
    private float scaleSliderNumber;

    // Private variables for caching transform and rotation
    private Transform transformCache;
    private Quaternion rotationQuaternion;

    void Start()
    {
        // Cache the transform
        transformCache = transform;

        // Cache the rotation quaternion
        rotationQuaternion = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        // Get the scale value from the slider and apply it to the game object's scale
        scaleSliderNumber = scaleSlider.value;
        Vector3 scale = new Vector3(scaleSliderNumber, scaleSliderNumber, scaleSliderNumber);
        transformCache.localScale = scale;

        // Get the rotation value from the slider and apply it to the game object's rotation
        angleSliderNumber = rotateSlider.value;
        rotationQuaternion.eulerAngles = new Vector3(0, angleSliderNumber, 0);
        transformCache.rotation = rotationQuaternion;
    }
}
