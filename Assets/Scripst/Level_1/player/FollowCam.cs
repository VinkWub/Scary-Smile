using UnityEngine;
using Cinemachine;

public class FollowCam : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            CinemachineVirtualCamera vcam = GetComponent<CinemachineVirtualCamera>();
            vcam.Follow = player.transform;
        }
    }
}