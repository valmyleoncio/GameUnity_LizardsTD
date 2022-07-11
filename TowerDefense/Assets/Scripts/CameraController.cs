using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    private bool doMovement = false;
    public float scroollSpeed = 5f;

    private void Update() { 

        if(GameManager.GameIsOver){
            this.enabled = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;
        
        if (!doMovement)
            return; 

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness){
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness){
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness){
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness){
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scrool = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scrool * scroollSpeed * Time.deltaTime * 50;
        transform.position = pos;
    }
}
