using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNave : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    AudioSource audiosource;
    
    // Start is called before the first frame update
    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        //Debug.Log(Time.deltaTime + " seg. " + (1.0f / Time.deltaTime) + " FPS");
        ProcesarInput();
    }

    private void OnCollisionEnter(Collision collision){

        switch (collision.gameObject.tag){
            case "SafeCollision":
                print("Colision segura...");
                break;
            case "UnsafeCollision":
                print("Colision insegura...");
                break;
        }
        // if(collision.gameObject.CompareTag("SafeCollision")){
        //     print("Colision segura...");
        // }
        // else if(collision.gameObject.CompareTag("UnsafeCollision")){
        //     print("Colision insegura...");
        // }
    }

    private void ProcesarInput(){
        propulsion();
        rotacion();
    }

    private void propulsion(){
        if(Input.GetKey(KeyCode.Space)){
            
            rigidbody.freezeRotation = true;
            
            //print("Propulsor");
            rigidbody.AddRelativeForce(Vector3.up);
            if (!audiosource.isPlaying){
                audiosource.Play();    
            }
        } else {
            audiosource.Stop();
        }

        rigidbody.freezeRotation = false;
    }

    private void rotacion(){
        if(Input.GetKey(KeyCode.D)){
            //print("Rotar derecha");
            //transform.Rotate(Vector3.back);
            var rotDer = transform.rotation;
            rotDer.z -= Time.deltaTime * 1;
            transform.rotation = rotDer;
        }
        else if(Input.GetKey(KeyCode.A)){
            //print("Rotar izquierda");
            //transform.Rotate(Vector3.forward);
            var rotIzq = transform.rotation;
            rotIzq.z += Time.deltaTime * 1;
            transform.rotation = rotIzq;
        }
    }
}
