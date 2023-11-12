using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float hitDamage;
    [SerializeField] private Wood wood;
    [SerializeField] private ParticleSystem woodFX;
    private ParticleSystem.EmissionModule woodFXEmission;
    private Rigidbody knifeRb;
    private Vector3 movementVector;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        knifeRb = GetComponent<Rigidbody>();
        woodFXEmission = woodFX.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            movementVector = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0) * movementSpeed * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        transform.position += movementVector;

        Vector3 clampedKnife = transform.position;
        clampedKnife.x = Mathf.Clamp(clampedKnife.x, -1.2f, 1.2f);
        clampedKnife.y = Mathf.Clamp(clampedKnife.y, -2.8f, 2.5f);
        transform.position = clampedKnife;
    }

    private void OnCollisionExit(Collision collision)
    {
        woodFXEmission.enabled = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        Colls coll = collision.collider.GetComponent<Colls>();
        if (coll != null)
        {
            woodFXEmission.enabled = true;
            woodFX.transform.position = collision.contacts[0].point;
            
            coll.HitCollider(hitDamage);
            wood.Hit(coll.index,hitDamage);
        }
    }
}
