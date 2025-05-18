using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    private PlayerInputManager playerInput;

    [SerializeField] private Transform target;       // 角色的 Transform
    [SerializeField] private float distance = 5f;    // 與角色的距離
    [SerializeField] private float height = 10f;     // 攝影機的高度
    [SerializeField] private float rotationSpeed = 100f; // Q/E 旋轉速度

    private float currentRotationAngle = 0f;         // 當前攝影機旋轉角度

    [SerializeField] private PlayerController player;

    public float cameraRotation;

    private void Start()
    {
        playerInput = FindObjectOfType<PlayerInputManager>();
        player = FindObjectOfType<PlayerController>();
        target = player.transform;

        IntializeCamera();
    }

    private void IntializeCamera()
    {
        playerInput.RotateCamera += SetCameraRotation;
    }

    public void OnDisable()
    {
        playerInput.RotateCamera -= SetCameraRotation;
    }

    public void SetCameraRotation(float angle)
    {
        cameraRotation = angle;
    }

    private void LateUpdate()
    {

        currentRotationAngle += cameraRotation * rotationSpeed * Time.deltaTime;

        // 2. 計算攝影機位置
        Quaternion currentRotation = Quaternion.Euler(0f, currentRotationAngle, 0f); // 水平旋轉
        Vector3 positionOffset = currentRotation * Vector3.back * distance;          // 根據角度計算偏移
        Vector3 cameraPosition = target.position + Vector3.up * height + positionOffset;

        // 3. 更新攝影機位置和看向目標
        transform.position = cameraPosition;
        transform.LookAt(target.position);
    }
}
