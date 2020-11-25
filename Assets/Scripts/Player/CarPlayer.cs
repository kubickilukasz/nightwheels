using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarPlayer : MonoBehaviour{

    //Speed of the car, if value is higher, the car go faster
    [SerializeField]
    float speed = 5f;

    //If mRigidbody.magnitude is more than this value, car can't go faster
    [SerializeField]
    float maxSpeed = 100;

    [SerializeField]
    float turnForce = 5f;

    [SerializeField]
    [Range(0,0.999f)]
    float friction = 0.5f;

    [SerializeField]
    [Range(0,0.999f)]
    float torqueFriction = 0.3f;

    //Actual direction of car
    Vector3 direction;

    //Actual speed of rotation of car
    Vector3 torque;

    //Handle to rigidbody
    Rigidbody mRigidbody;

    void Start(){
        mRigidbody = GetComponent<Rigidbody>();
    }

    void Update(){
        direction = new Vector3(0,0,1);
        torque = new Vector3(0,Input.GetAxis("Horizontal"),0);
    }

    void FixedUpdate(){
       // if(mRigidbody.velocity.magnitude < maxSpeed){
            mRigidbody.AddRelativeForce(direction * speed * Time.fixedDeltaTime); 
       // }else{
            //Friction
             mRigidbody.velocity *= friction; 
       // }

      //  if(torque.y < -0.5f || torque.y > 0.5f){
            mRigidbody.AddTorque(torque * turnForce * Time.fixedDeltaTime);
       // }else{
            mRigidbody.angularVelocity *= torqueFriction;
      //  }
    }

}
