using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void LateUpdate()
    {
        // ī�޶��� ��ǥ ��ġ
        Vector3 desiredPosition = player.position + offset;
        // ī�޶��� ���� ��ġ�� ��ǥ ��ġ�� �ε巴�� ����
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
        transform.position = smoothedPosition;

    }
}
