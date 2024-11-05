using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletProjectile : MonoBehaviour

{
   private Rigidbody bulletRigidbody;
   private GameObject projectile;
   public GameObject explosionEffect;
   private Vector3 FireballPosition;

   private void Awake()
   {
   bulletRigidbody = GetComponent<Rigidbody>();
   }
   private void Start()
   {
    float speed = 15f;
    bulletRigidbody.velocity = transform.forward * speed;
   }
   private void OnTriggerEnter(Collider other)
   {
    // Instantiate(explosionEffect);
    Destroy(gameObject);
   }
}
