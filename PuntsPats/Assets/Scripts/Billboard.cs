using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
  public GameObject mainCamera;
  public Transform cameraTransform;

  Quaternion rotation;
  Vector3 positionOffset;

  void Awake()
  {
    rotation = transform.parent.rotation;
    positionOffset = transform.localPosition;
    CalibrateBillboardOffset();
  }

  void Start()
  {
    mainCamera = GameObject.Find("Main Camera");
    cameraTransform = mainCamera.transform;
  }

  void LateUpdate()
  {
    transform.rotation = rotation;
    transform.position = transform.parent.position + positionOffset;

    transform.LookAt(transform.position + cameraTransform.forward);
  }

  void CalibrateBillboardOffset()
  {
    positionOffset.y -= 0.16f;
    positionOffset.x += 0.37f;
  }
}
