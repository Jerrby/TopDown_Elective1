using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes : MonoBehaviour
{
    private Vector2 mousePos;

    private float angle;

    public GameObject pistolClass;
    public GameObject smgClass;
    public GameObject sniperClass;
    
    public Transform pistol;
    public Transform smg;
    public Transform sniper;

    public Transform pistolPoint;
    public Transform smgPoint;
    public Transform sniperPoint;

    public GameObject bullet;

    private float shootSpeed;
    public float bulletSpeed;

    private int hp;
    private int dmg;

    private bool canShoot = true;

    public void Awake()
    {
        canShoot = true;
    }

    public void Update()
    {
        
        mousePos = Input.mousePosition;

        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x -= objPos.x;
        mousePos.y -= objPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        if (pistolClass.activeSelf)
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                StartCoroutine(shootPistol());
            }
        }

        if (smgClass.activeSelf)
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                StartCoroutine(shootSMG());
            }
        }

        if (sniperClass.activeSelf)
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                StartCoroutine(shootSniper());
            }
        }
    }

    public void FixedUpdate()
    {
        pistol.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        smg.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        sniper.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public IEnumerator shootPistol()
    {
        canShoot = false;
        hp = 15;
        dmg = 15;
        GameObject bulletCreate = Instantiate(bullet, pistolPoint.position, pistolPoint.rotation);
        Rigidbody2D bulletRB = bulletCreate.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(pistolPoint.right * bulletSpeed);
        Destroy(bulletCreate, 5);
        shootSpeed = .5f;
        yield return new WaitForSeconds(shootSpeed);
        canShoot = true;

    }

    public IEnumerator shootSMG()
    {
        canShoot = false;
        hp = 20;
        dmg = 10;
        GameObject bulletCreate = Instantiate(bullet, smgPoint.position, smgPoint.rotation);
        Rigidbody2D bulletRB = bulletCreate.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(smgPoint.right * bulletSpeed);
        Destroy(bulletCreate, 5);
        shootSpeed = .2f;
        yield return new WaitForSeconds(shootSpeed);
        canShoot = true;

    }
    public IEnumerator shootSniper()
    {
        canShoot = false;
        hp = 10;
        dmg = 20;
        GameObject bulletCreate = Instantiate(bullet, sniperPoint.position, sniperPoint.rotation);
        Rigidbody2D bulletRB = bulletCreate.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(sniperPoint.right * bulletSpeed);
        Destroy(bulletCreate, 5);
        shootSpeed = 1;
        yield return new WaitForSeconds(shootSpeed);
        canShoot = true;

    }
}


/*Idea is 3 classes: SMG(Machinist), Pistoleer(Pistol), Sniper (Sniper)
 *  SMG = High HP, Low DMG, Fast Fire Rate
 *  Pistol = Medium HP, Medium DMG, Medium FR
 *  Sniper = Small HP, High DMG, Slow FR
 *  
 *  
 *  Need HP modifier
 *  Need DMG Modifier
 */