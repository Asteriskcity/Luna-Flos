using System;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Guagua.CoreSystem;

namespace Guagua.WeaponSystem
{
    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField] Weapon weapon;

        private List<WeaponComponents> componentAlreadyOn = new();
        private List<WeaponComponents> componentAdded = new();
        private List<Type> componentDependencies = new();

        private Animator anim;

        private Form form;

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
            form = weapon.Core.GetCoreComponent<Form>();
            GenerateWeapon(form.weaponBox[0]);
        }

        public void GenerateWeapon(WeaponDataSO dataSO)
        {
            weapon.SetWeaponData(dataSO);

            componentAlreadyOn.Clear();
            componentAdded.Clear();
            componentDependencies.Clear();

            componentAlreadyOn = GetComponents<WeaponComponents>().ToList();

            componentDependencies = dataSO.GetAllDependencies();

            foreach (var dependency in componentDependencies)
            {
                if (componentAdded.FirstOrDefault(component => component.GetType() == dependency))
                    continue;

                var weaponcomponet =
                    componentAlreadyOn.FirstOrDefault(component => component.GetType() == dependency);

                if (weaponcomponet == null)
                {
                    weaponcomponet = gameObject.AddComponent(dependency) as WeaponComponents;
                }

                weaponcomponet.Init();

                componentAdded.Add(weaponcomponet);
            }

            var componentToRemove = componentAlreadyOn.Except(componentAdded);

            foreach (var weaponComponent in componentToRemove)
            {
                Destroy(weaponComponent);
            }

            anim.runtimeAnimatorController = dataSO.AnimatorController;

        }
    }
}
