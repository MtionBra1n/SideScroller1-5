using Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera playerVcam;
    public CinemachineVirtualCamera focusVcam;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerVcam.Priority = 0;
            
            focusVcam.Priority = 10;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerVcam.Priority = 10;
            focusVcam.Priority = 0;
            playerVcam.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = new Vector3(2, 2, 0);
        }
    }
}
