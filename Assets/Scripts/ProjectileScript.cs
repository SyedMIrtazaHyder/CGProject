using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject Bullet;

    public float ShootForce, UpwardForce;

    public float TimeBetweeenShooting, spread, ReloadTime, TimeBetweenShots;
    public int MagazineSize, BulletsPerTap;

    public bool AllowButtonHold;

    int Bulletsleft, BulletsShot;

    bool Shooting, ReadytoShoot, Reloading;
    public Camera FpsCam;
    public Transform AttackPoint;

    public bool AllowInvoke = true;

    /*public GameObject MuzzleFlash;
    public TextMeshProUGUI AmmunitionDisplay;*/

    private void Start()
    {
        Bulletsleft = MagazineSize;
        ReadytoShoot = true;
    }
    private void Update()
    {
        MyInputs();

        /*if (AmmunitionDisplay != null)
        {
            AmmunitionDisplay.SetText(Bulletsleft / BulletsPerTap + "/" + MagazineSize / BulletsPerTap);
        }*/
    }
    private void MyInputs()
    {
        if (AllowButtonHold) Shooting = Input.GetKey(KeyCode.Mouse0);
        else Shooting = Input.GetKeyDown(KeyCode.Mouse0);


        if (Input.GetKeyDown(KeyCode.R) && Bulletsleft < MagazineSize && !Reloading) Reload();

        if (ReadytoShoot && Shooting && !Reloading && Bulletsleft <= 0) Reload();

        if (ReadytoShoot && Shooting && !Reloading && Bulletsleft > 0)
        {
            BulletsShot = 0;
            Shoot();
        }

    }
    private void Shoot()
    {
        ReadytoShoot = false;
        Ray ray = FpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 TargetPoint;

        if (Physics.Raycast(ray, out hit))
            TargetPoint = hit.point;
        else
            TargetPoint = ray.GetPoint(75);

        Vector3 DireactionWithoutSpeed = TargetPoint - AttackPoint.position;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 DireactionWithSpread = DireactionWithoutSpeed + new Vector3(x, y, 0);

        GameObject CurrentBullet = Instantiate(Bullet, AttackPoint.position, Quaternion.identity);
        Destroy(CurrentBullet, 2f); //destorying bullet after 2 seconds of firing it

        CurrentBullet.transform.forward = DireactionWithSpread.normalized;
        CurrentBullet.GetComponent<Rigidbody>().AddForce(DireactionWithSpread.normalized * ShootForce, ForceMode.Impulse);
        CurrentBullet.GetComponent<Rigidbody>().AddForce(FpsCam.transform.up * UpwardForce, ForceMode.Impulse);

        /*if (MuzzleFlash != null)
            Instantiate(MuzzleFlash, AttackPoint.position, Quaternion.identity);*/
        BulletsShot++;
        Bulletsleft--;

        if (AllowInvoke)
        {
            Invoke("ResetShot", TimeBetweeenShooting);
            AllowInvoke = false;
        }
        if (BulletsShot > BulletsPerTap && Bulletsleft > 0)
        {
            Invoke("Shoot", TimeBetweenShots);
        }
    }
    private void ResetShot()
    {
        ReadytoShoot = true;
        AllowInvoke = true;

    }
    private void Reload()
    {
        Reloading = true;
        Invoke("ReloadFinished", ReloadTime);
    }
    private void ReloadFinished()
    {
        Bulletsleft = MagazineSize;
        Reloading = false;
    }

}
