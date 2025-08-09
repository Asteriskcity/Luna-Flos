using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    public class WeaponSprite : WeaponComponent<WeaponSpriteData, AttackSprite>
    {
        private SpriteRenderer baseSpriteRender;
        private SpriteRenderer weaponSpriteRender;

        private int currentWeaponSpriteIndex;

        protected override void HandleEnter()
        {
            base.HandleEnter();

            currentWeaponSpriteIndex = 0;
        }

        private void HandleBaseSpriteChange(SpriteRenderer spriteRenderer)
        {
            if (!isAttackAcitve)
            {
                weaponSpriteRender.sprite = null;
                return;
            }

            var currentAttackSprites = currentAttackData.Sprites;

            if (currentWeaponSpriteIndex >= currentAttackSprites.Length)
            {
                Debug.LogWarning($"{weapon.name} weapon sprites length mismatch");
                return;
            }

            weaponSpriteRender.sprite = currentAttackSprites[currentWeaponSpriteIndex];

            currentWeaponSpriteIndex++;
        }

        protected override void Start()
        {
            base.Start();

            baseSpriteRender = weapon.BaseGameobject.GetComponent<SpriteRenderer>();
            weaponSpriteRender = weapon.WeaponSpriteGameobject.GetComponent<SpriteRenderer>();

            data = weapon.DataSO.GetData<WeaponSpriteData>();

            baseSpriteRender.RegisterSpriteChangeCallback(HandleBaseSpriteChange);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            baseSpriteRender.UnregisterSpriteChangeCallback(HandleBaseSpriteChange);


        }
    }
}



