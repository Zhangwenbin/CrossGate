using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGateGoIn : MonoBehaviour
{
   public LayerMask virualWorldLayer;
   public LayerMask realWorldLayer;

   public Transform linkGate;
   public Transform virualCamera;
   public Transform realWorldCamera;
   public float disableTriggerTime;
   private void OnTriggerEnter(Collider other)
   {
      if (1<<other.gameObject.layer==realWorldLayer)
      {
         StartCoroutine(TriggerDisable(other));
         Transform otherTransform = other.transform;
         SetLayer(other.gameObject,virualWorldLayer);
         other.transform.parent = transform;
         var scale1 = transform.lossyScale;
         var localPos = otherTransform.localPosition;
         localPos = new Vector3(localPos.x * scale1.x, localPos.y * scale1.y, localPos.z * scale1.z);
           
         otherTransform.parent = linkGate;
         var scale2= linkGate.transform.lossyScale;
         otherTransform.localPosition =new Vector3(localPos.x/scale2.x,localPos.y/scale2.y,localPos.z/scale2.z) ;
         otherTransform.parent = null;

         otherTransform.parent = realWorldCamera;
         var localEuler = otherTransform.localEulerAngles;
         otherTransform.parent = virualCamera;
         otherTransform.localEulerAngles = localEuler;
         otherTransform.parent = null;
      }
      
   }

   void SetLayer(GameObject go,LayerMask _layer)
   {
      foreach (Transform trans in go.GetComponentsInChildren<Transform>())
      {
         trans.gameObject.layer = (int)Mathf.Log(_layer,2);
      }
   }
   
   IEnumerator TriggerDisable(Collider collider)
   {
      collider.enabled = false;
      yield return new WaitForSeconds(disableTriggerTime);
      collider.enabled = true;
   }
}
