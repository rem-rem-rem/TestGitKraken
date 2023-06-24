using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerinteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUi playerUI;
    private PlayerInput inputManager;
    private WeaponManager weaponManager;
    private Playeratk playeratk;

    protected Interactable interactable;

    protected GameObject wp;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUi>();
        inputManager = GetComponent<PlayerInput>();
        weaponManager = GetComponent<WeaponManager>();
        playeratk = GetComponent<Playeratk>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        //if (inputManager.onFoot.Drow.triggered)
        //{
        //    weaponManager.Swapweapon();
        //}

        //if(inputManager.onFoot.Drow.triggered)
        //{
        //    weaponManager.Drop();
        //}

        playerUI.UpdateText(string.Empty);
        //create a ray at the center of the camera, shooting outwards
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; //variable to store our collision information.

        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                interactable = hitInfo.collider.GetComponent<Interactable>();
               // Debug.Log(interactable.weaponDataSO);


                playerUI.UpdateText(interactable.promptMessage);
                if (hitInfo.transform.tag == "CanGrab")
                {
                    //Debug.Log("I can Grab");
                    wp = hitInfo.transform.gameObject;
                    //Debug.Log(wp);
                }



                if(inputManager.onFoot.Interactable.triggered && hitInfo.transform.tag == "CanGrab")
                {
                    Debug.Log("Tuong tac");
                    weaponManager.EquipWeapon(interactable.weaponDataSO);
                    playeratk.Getdata(interactable.weaponDataSO);
                    interactable.BaseInteract();
                }

            }
        }

    }
}
