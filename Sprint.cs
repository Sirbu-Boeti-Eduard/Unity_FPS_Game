
using UnityEngine;

public class Sprint : MonoBehaviour {

    float walkSpeed;
    float sprintSpeed;

    PlayerController pm;

     void Start()
    {
        pm = (PlayerController)GetComponent<PlayerController>();
        walkSpeed = pm.speed;
        sprintSpeed = walkSpeed * 2;

    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            pm.speed = sprintSpeed;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            pm.speed = walkSpeed;
    }
}
