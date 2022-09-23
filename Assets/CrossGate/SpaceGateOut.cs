using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGateOut : MonoBehaviour
{
   public bool goin;
   public LayerMask layerOtherWorld;
   public LayerMask layer;

   private void OnTriggerEnter(Collider other)
   {
      if (goin==false)
      {
         if (1<<other.gameObject.layer==layerOtherWorld)
         {
            SetLayer(other.gameObject,layer);
         }
      }
      else
      {
         if (1<<other.gameObject.layer==layer)
         {
            SetLayer(other.gameObject,layerOtherWorld);
         }
      }
   
   }

   void SetLayer(GameObject go,LayerMask _layer)
   {
      foreach (Transform trans in go.GetComponentsInChildren<Transform>())
      {
         trans.gameObject.layer = (int)Mathf.Log(_layer,2);
      }
   }
}
