using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera camera;
    private float xRotation = 0f;

    public float _xSensivity = 30f;
    public float _ySensivity = 30f;
    public float _lookXLimit;


    public void ProcessLook(Vector2 input)
    {
        var mouseX = input.x;
        var mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime * _ySensivity);
        xRotation = Mathf.Clamp(xRotation, -_lookXLimit, _lookXLimit);
        
        camera.transform.localRotation = Quaternion.Euler(xRotation,0,0);
        
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * _xSensivity) );
    }
}