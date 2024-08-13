
using System;
using UnityEngine;

public class Character : MonoBehaviour
{
   [SerializeField] private Rigidbody2D rigid;
   [SerializeField] private float speed = 1f;
   [SerializeField] private FieldOfView fov;

   private Camera _camera;

   private void Start()
   {
      _camera = Camera.main;
   }

   private void Update()
   {
      float vertical = Input.GetAxis("Vertical");
      float horizontal = Input.GetAxis("Horizontal");
      Vector2 movement = new Vector2(horizontal, vertical);
      rigid.velocity = movement * (speed * Time.deltaTime);

      Vector3 targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
      Vector3 dir = (targetPosition - transform.position).normalized;
      
      fov.SetDirection(dir);
      fov.SetOrigin(transform.position);
      
      float angle = Extensions.GetAngleFromVectorFloat(dir);
      transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
   }

   
}
