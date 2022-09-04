using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSlow : Bullet
{
  

   protected override void MoveBullet()
   {
       transform.position += transform.forward * speed * Time.deltaTime;
   }
}
