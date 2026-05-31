using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using System.Collections.Generic;
using DG.Tweening;

public class Handmanagement : MonoBehaviour
{   
  [SerializeField] private int maxHandSize = 10;

  [SerializeField] private GameObject Card; 

  [SerializeField] private SplineContainer splineContainer;

  [SerializeField] private Transform CardSpawn;

  private List<GameObject> handCards = new();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            DrawCard();
       
    }


    private void DrawCard()
    { 
         if(handCards.Count >= maxHandSize) return;
         GameObject g = Instantiate(Card, CardSpawn.position, CardSpawn.rotation);
        handCards.Add(g);
        UpdateCardPositions();  
    }
    private void UpdateCardPositions(){
        if(handCards.Count == 0) return;
        float cardSpacing = 1f/ maxHandSize;
        float firstCardPosition = 0.5f - (handCards.Count - 1)* cardSpacing / 2f;
        
        Spline spline = splineContainer.Spline;
      
        for(int i = 0; i < handCards.Count; i++){
            
            float p = firstCardPosition + i * cardSpacing;

            Vector3 splinePosition = splineContainer.transform.TransformPoint(spline.EvaluatePosition(p));
            Vector3 foward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, foward).normalized);

            handCards[i].transform.DOMove(splinePosition, 0.25f);
            handCards[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        }



    }


}
