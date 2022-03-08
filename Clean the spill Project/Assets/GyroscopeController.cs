using UnityEngine;

public class GyroscopeController : MonoBehaviour
{
    private float initialYAngle = 0f;
    private float appliedGyroYAngle = 0f;
    private float calibrationYAngle = 0f;

    private void Start()
    {
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        initialYAngle = gameObject.transform.eulerAngles.y;
    }

    private void Update()
    {
        ApplyGyroRotation();
        ApplyCalibration();
    }
    
    void OnGUI()
    {
        if( GUILayout.Button( "Calibrate", GUILayout.Width( 100 ), GUILayout.Height( 50 ) ) )
        {
            CalibrateYAngle();
        }
    }
    

    public void CalibrateYAngle()
    {
        calibrationYAngle = appliedGyroYAngle - initialYAngle; // Offsets the y angle in case it wasn't 0 at edit time.
    }

    private void ApplyGyroRotation()
    {
        gameObject.transform.localRotation = Input.gyro.attitude;

        gameObject.transform.Rotate(90f, 0f, 180f, Space.Self); // Swap "handedness" of quaternion from gyro.
        gameObject.transform.Rotate(90f, 90f, 0f,
            Space.World); // Rotate to make sense as a camera pointing out the top of your device.
        appliedGyroYAngle = gameObject.transform.eulerAngles.y; // Save the angle around y axis for use in calibration.
    }

    private void ApplyCalibration()
    {
        gameObject.transform.Rotate(0f, -calibrationYAngle, 0f,
            Space.World); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
    }
}