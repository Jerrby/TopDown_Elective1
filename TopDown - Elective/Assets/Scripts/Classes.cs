using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public TextMeshProUGUI textBox1;

    private float shootSpeed;
    public float bulletSpeed;

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
        GameObject bulletCreate = Instantiate(bullet, pistolPoint.position, pistolPoint.rotation);
        Rigidbody2D bulletRB = bulletCreate.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(pistolPoint.right * bulletSpeed);
        Destroy(bulletCreate, 5);
        shootSpeed = .5f;
        textBox1.text = "DONE";
        yield return new WaitForSeconds(shootSpeed);
        canShoot = true;

    }

    public IEnumerator shootSMG()
    {
        canShoot = false;
        GameObject bulletCreate = Instantiate(bullet, smgPoint.position, smgPoint.rotation);
        Rigidbody2D bulletRB = bulletCreate.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(smgPoint.right * bulletSpeed);
        Destroy(bulletCreate, 5);
        shootSpeed = .2f;
        textBox1.text = "DONE";
        yield return new WaitForSeconds(shootSpeed);
        canShoot = true;

    }
    public IEnumerator shootSniper()
    {
        canShoot = false;
        GameObject bulletCreate = Instantiate(bullet, sniperPoint.position, sniperPoint.rotation);
        Rigidbody2D bulletRB = bulletCreate.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(sniperPoint.right * bulletSpeed);
        Destroy(bulletCreate, 2.5f);
        shootSpeed = 1;
        textBox1.text = "DONE";
        yield return new WaitForSeconds(shootSpeed);
        canShoot = true;
    }
}