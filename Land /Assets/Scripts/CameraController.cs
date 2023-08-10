using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
   [SerializeField] Transform player;
    [SerializeField] float speed;

    Transform camera;
    Vector3 offset;

    void Awake() 
    {
        camera = this.transform;
        offset = camera.position - player.position;
    }

    void Update() 
    {
        Follow();
    }

    void Follow()
    {
        camera.DOMoveX(player.position.x + offset.x, speed * Time.deltaTime);
        camera.DOMoveZ(player.position.z + offset.z, speed * Time.deltaTime);
    }

}
