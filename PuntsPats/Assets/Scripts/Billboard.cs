using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
  public GameObject camera;
  public Transform cameraTransform;

  Quaternion rotation;
  Vector3 positionOffset;

  void Awake()
  {
    rotation = transform.parent.rotation;
    positionOffset = transform.localPosition;
  }

  void Start()
  {
    camera = GameObject.Find("Main Camera");
    cameraTransform = camera.transform;
  }

  void LateUpdate()
  {
    transform.rotation = rotation;
    transform.position = transform.parent.position + positionOffset;

    transform.LookAt(transform.position + cameraTransform.forward);
  }
}
