using System;
using UnityEngine;

public class Weapon_swap : MonoBehaviour
{
    [Header("Sway Setting")]
    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
    

        Quaternion targetRotation = rotationX * rotationY ;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);


    }
}
