using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGraphDataProvider
{
    float GetValue();
}

public class RandomGraphDataProvider : IGraphDataProvider
{
    public float GetValue()
    {
        return UnityEngine.Random.Range(-1.0f, 1.0f);
    }
}

public class DebugGUIGraphs : MonoBehaviour
{
    [SerializeReference] private IGraphDataProvider graphDataProvider = new RandomGraphDataProvider();

    // Start is called before the first frame update
    void Start()
    {
        DebugGUI.SetGraphProperties("KeyImuAx", "IMU accelX", 0, 0, 0, new Color(1, 1, 0), true);
        DebugGUI.SetGraphProperties("KeyImuAy", "IMU accelY", 0, 0, 0, new Color(1, 0, 1), true);
        DebugGUI.SetGraphProperties("KeyImuAz", "IMU accelZ", 0, 0, 0, new Color(0, 1, 1), true);
        DebugGUI.SetGraphProperties("KeyImuGx", "IMU gyroX", 0, 0, 1, new Color(1, 1, 0), true);
        DebugGUI.SetGraphProperties("KeyImuGy", "IMU gyroY", 0, 0, 1, new Color(1, 0, 1), true);
        DebugGUI.SetGraphProperties("KeyImuGz", "IMU gyroZ", 0, 0, 1, new Color(0, 1, 1), true);
        DebugGUI.SetGraphProperties("KeyImuMx", "IMU magX", 0, 0, 2, new Color(1, 1, 0), true);
        DebugGUI.SetGraphProperties("KeyImuMy", "IMU magY", 0, 0, 2, new Color(1, 0, 1), true);
        DebugGUI.SetGraphProperties("KeyImuMz", "IMU magZ", 0, 0, 2, new Color(0, 1, 1), true);

    }

    // Update is called once per frame
    void Update()
    {
        DebugGUI.Graph("KeyImuAx", Mathf.Sin(Time.time));
        DebugGUI.Graph("KeyImuAy", Mathf.Cos(Time.time));
        DebugGUI.Graph("KeyImuAz", Mathf.Clamp(Mathf.Tan(Time.time), -1f, 1f));
        DebugGUI.Graph("KeyImuGx", UnityEngine.Random.Range(-180.0f, 180.0f));
        DebugGUI.Graph("KeyImuGy", UnityEngine.Random.Range(-180.0f, 180.0f));
        DebugGUI.Graph("KeyImuGz", UnityEngine.Random.Range(-180.0f, 180.0f));
        DebugGUI.Graph("KeyImuMx", UnityEngine.Random.Range(-1.0f, 1.0f));
        DebugGUI.Graph("KeyImuMy", UnityEngine.Random.Range(-1.0f, 1.0f));
        DebugGUI.Graph("KeyImuMz", UnityEngine.Random.Range(-1.0f, 1.0f));

    }
}
