using System.Collections.Generic;
using UnityEngine;

public class WeaponService : BaseMonoBeh, IService
{
    [SerializeField] private List<Weapon> _weapons;


    public Weapon CurrentWeapon { get; private set; }


    public void Use(int index)
    {
        if(_weapons.Count > index)
        {
            if(CurrentWeapon != null)
            {
                Destroy(CurrentWeapon.gameObject);
            }

            var weapon = Instantiate(_weapons[index]);
            CurrentWeapon = weapon;
        }
    }

    public void Shoot()
    {
        CurrentWeapon?.Shoot();
    }
}
