using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{

    public class EnemyShoot : EnemyBase
    {
        public GunBase gunBase;
        public GameObject MeshChangeSleep;
        public Texture textureAwake;
        public Texture textureSleep;

        protected override void Init()
        {
            base.Init();

        }

  
        public void StartShooting()
        {
            Debug.Log("jdksandji");
            gunBase.StartShoot();
            MeshChangeSleep.GetComponent<Renderer>().material.SetTexture("_MainTex", textureAwake);
        }

        public void StopShooting()
        {
            gunBase.CancelShoot();
            MeshChangeSleep.GetComponent<Renderer>().material.SetTexture("_MainTex", textureSleep);
        }
    }
}
