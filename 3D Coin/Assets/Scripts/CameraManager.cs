using UnityEngine;
using Unity.Cinemachine;
public class CameraManager : MonoBehaviour
{
    public CinemachineFreeLook cam;


    // Update is called once per frame
    void Update()
    {
        cam.m_XAxis.m_InputAxisValue = SimpleInput.GetAxis("lookX");
        cam.m_YAxis.m_InputAxisValue = SimpleInput.GetAxis("lookY");
    }
}
