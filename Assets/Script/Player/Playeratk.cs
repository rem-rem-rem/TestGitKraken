using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeratk : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    protected Interactable interactable;

    public WeaponDataSO equippedWeapon;
    public Transform bulletSpawnPosition;
    public GameObject bulletPrefab;
    private float myTime = 0.0f;
    private float nextFire = 0.0f;

    [SerializeField] ParticleSystem expGun = null;
    [SerializeField] ParticleSystem expM4 = null;
    private bool firecooldown;
    private bool fire;
    public AudioSource Gunsource;
    public AudioSource M4source;

    private WeaponManager pleaseGivemeData;

    public GameObject bulletHole;

    public GameObject exp;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        pleaseGivemeData = GetComponent<WeaponManager>();
    }
    public void Getdata(WeaponDataSO weaponDataSO)
    {
        equippedWeapon = weaponDataSO;
    }

   // Update is called once per frame
    void Update()
    {

        myTime += Time.deltaTime;
        if (equippedWeapon != null && pleaseGivemeData.equippedWeapon != null )
        {
            Ray ray_atk = new Ray(cam.transform.position, cam.transform.forward);
            Debug.DrawRay(ray_atk.origin, ray_atk.direction * equippedWeapon.range);
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, equippedWeapon.range))
            {
                // Debug.Log(equippedWeapon);
                if(hit.collider.GetComponent<Interactable>() != null)
                {
                    interactable = hit.collider.GetComponent<Interactable>();


                    if (pleaseGivemeData != null && Input.GetButton("Fire1") && equippedWeapon.weaponName == "Gun" && myTime >= nextFire)
                    {
                        GameObject bh = Instantiate(bulletHole, hit.point + new Vector3(0f, 0f, -.02f), Quaternion.LookRotation(-hit.normal));
                        nextFire = myTime + equippedWeapon.timeDelay;
                        expGun.Play();
                        Gunsource.Play();
                        //var bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
                        Information information = hit.transform.GetComponent<Information>();
                        information.data = pleaseGivemeData;
                        interactable.BaseInteract();    
                        nextFire -= myTime;
                        myTime = 0.0F;
                    }

                    //Input.GetMouseButtonDown(0)
                    //GunVFX.SetActive(false);

                    if (pleaseGivemeData != null && Input.GetButton("Fire1") && equippedWeapon.weaponName == "M4" && myTime >= nextFire)
                    {
                        GameObject bh = Instantiate(bulletHole, hit.point + new Vector3(0f, 0f, -.02f), Quaternion.LookRotation(-hit.normal));
                        nextFire = myTime + equippedWeapon.timeDelay;
                        Information information = hit.transform.GetComponent<Information>();
                        information.data = pleaseGivemeData;
                        interactable.BaseInteract();
                        M4source.Play();
                        expM4.Play();
                        nextFire -= myTime;
                        myTime = 0.0F;
                    }
                }

            }

            if (pleaseGivemeData != null &&  Input.GetButton("Fire1") && equippedWeapon.weaponName == "M4" && myTime >= nextFire)
            {
                nextFire = myTime + equippedWeapon.timeDelay;
                expM4.Play();
                M4source.Play();
                nextFire -= myTime;
                myTime = 0.0F;
            }

            if (pleaseGivemeData != null &&  Input.GetButton("Fire1") && equippedWeapon.weaponName == "Gun" && myTime >= nextFire)
            {
                nextFire = myTime + equippedWeapon.timeDelay;
                expGun.Play();
                Gunsource.Play();
                nextFire -= myTime;
                myTime = 0.0F;
            }

            if (pleaseGivemeData != null && Input.GetMouseButtonDown(1))
            {
                Instantiate(exp, transform.position, transform.rotation);
            }
        }
    }
}
