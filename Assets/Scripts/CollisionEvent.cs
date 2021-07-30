using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField] GameObject ontopbarrel;
    [SerializeField] GameObject ontopbox;
    [SerializeField] GameObject boxonplacement;
    [SerializeField] GameObject barrelonplacement;
    [SerializeField] GameObject weightPoint1;
    [SerializeField] GameObject weightPoint2;
    [SerializeField] GameObject weightPoint3;
    [SerializeField] GameObject weightPoint4;
    [SerializeField] GameObject weightPoint5;
    [SerializeField] GameObject weightPoint6;
    [SerializeField] GameObject weightPoint7;
    [SerializeField] GameObject weightPoint8;
    [SerializeField] GameObject weightPoint9;
    [SerializeField] GameObject weightPoint10;
    //[SerializeField] GameObject RestartButton;
    public RobotAnimation robotAnimation;


    float maxWeight = 15;
    float currentWeight = 0;
    bool spawnedBarrel = true;
    bool spawnedBox = true;
    bool placementBarrel = true;
    bool placementBox = true;
    
    void Start()
    {
        robotAnimation = GameObject.Find("GameObject").GetComponent<RobotAnimation>();
    }
     private void OnTriggerEnter(Collider other)
     {
        SpawnController(other);   
        robotAnimation.RestartButtonTrigger();
     } 
     
     private void SpawnController(Collider other)
     {
        if(spawnedBox == true)
        {
            SpawnBox(other);
        }
        if(placementBox == true && currentWeight != 0)
        {
            BoxPlacement(other);
        }

        if(spawnedBarrel == true)
        {
            SpawnBarrel(other);
            //BarrelPlacement(other);
        }
        if(placementBarrel == true && currentWeight != 0)
        {
            BarrelPlacement(other);
        }
     }
     private void SpawnBox(Collider box)
     {
        if (box.gameObject.CompareTag("spawnedBox"))
        {
            box.gameObject.SetActive(false);
            ontopbarrel.SetActive(false);
            ontopbox.SetActive(true);
            BoxCounter.itemCounter += 1;
            WeightController();
            spawnedBarrel = false;
            placementBarrel = false;
            placementBox = true;
        }
     }
     private void SpawnBarrel(Collider barrel)
     {
        if (barrel.gameObject.CompareTag("spawnedBarrel"))
        {
            barrel.gameObject.SetActive(false);
            ontopbarrel.SetActive(true);
            ontopbox.SetActive(false);
            BarrelCounter.itemCounter += 1; 
            WeightController();
            spawnedBox = false;
            placementBox = false;
            placementBarrel = true;
        }
     }
    private void BarrelPlacement(Collider barp)
    {
        if (barp.gameObject.CompareTag("barrelonplacement"))
        {
            if(placementBarrel == true)
            {
                barrelonplacement.SetActive(true);
                ontopbarrel.SetActive(false);
            }
            spawnedBox = true;
            spawnedBarrel = true;
            //placementBox = true;
            PlacedCounter.itemCounter = PlacedCounter.itemCounter + BarrelCounter.itemCounter;
            WeightCounter.itemCounter = PlacedCounter.itemCounter * 3.5f;
            BarrelCounter.itemCounter = BarrelCounter.itemCounter - BarrelCounter.itemCounter;
            ResetWeight();
        }
    }

    public void ResetPlacement()
    {
        barrelonplacement.SetActive(false);
        boxonplacement.SetActive(false);
    }

    private void BoxPlacement(Collider boxp)
    {
        if (boxp.gameObject.CompareTag("boxonplacement"))
        {
            if(placementBox == true)
            {
                boxonplacement.SetActive(true);
                ontopbox.SetActive(false);
            }
            spawnedBarrel = true;
            spawnedBox = true;
            PlacedCounter.itemCounter = PlacedCounter.itemCounter + BoxCounter.itemCounter;
            WeightCounter.itemCounter = PlacedCounter.itemCounter * 3.5f;
            BoxCounter.itemCounter = BoxCounter.itemCounter - BoxCounter.itemCounter;
            ResetWeight();
        }
    }

    private void WeightController()
    {
        print(currentWeight);
        if(currentWeight <= maxWeight){
            if(currentWeight == 0){
                print("Initial weight: " + currentWeight);
            }
            currentWeight += 3.5f;
            print("Updated weight: " + currentWeight);
            if(currentWeight > 11)
            {
                if (spawnedBox == true && currentWeight > 13)
                {
                    spawnedBox = false;
                    spawnedBarrel = false;
                    placementBox = true;
                    placementBarrel = false;
                }
                if(spawnedBarrel == true && currentWeight > 13)
                {
                    spawnedBarrel = false;
                    spawnedBox = false;
                    placementBox = false;
                    placementBarrel = true;
                }     
                weightPoint7.SetActive(true);
                weightPoint8.SetActive(true);
                weightPoint9.SetActive(true);
                weightPoint10.SetActive(true);
            } 
            if(currentWeight >= 0 && currentWeight <= 5)
            {
                weightPoint1.SetActive(true);
                weightPoint2.SetActive(true);                           
            }
            if(currentWeight > 5 && currentWeight <= 7)
            {
                    weightPoint3.SetActive(true);
                    weightPoint4.SetActive(true);
                    weightPoint5.SetActive(true);
                    weightPoint6.SetActive(true);
            }              
        }
    }
    public void ResetWeight()
    {
        weightPoint1.SetActive(false);
        weightPoint2.SetActive(false);
        weightPoint3.SetActive(false);
        weightPoint4.SetActive(false);
        weightPoint5.SetActive(false);
        weightPoint6.SetActive(false);
        weightPoint7.SetActive(false);
        weightPoint8.SetActive(false);
        weightPoint9.SetActive(false);
        weightPoint10.SetActive(false);
        currentWeight = currentWeight - currentWeight;
    }
    
    public void ResetCounter()
    {
        BarrelCounter.itemCounter = BarrelCounter.itemCounter - BarrelCounter.itemCounter;
        BoxCounter.itemCounter = BoxCounter.itemCounter - BoxCounter.itemCounter;
        PlacedCounter.itemCounter = PlacedCounter.itemCounter - PlacedCounter.itemCounter;
        WeightCounter.itemCounter = WeightCounter.itemCounter - WeightCounter.itemCounter;
        spawnedBarrel = true;
        spawnedBox = true;
    }

    // public void RestartButtonTrigger(){
    //     if(PlacedCounter.itemCounter == 10 && WeightCounter.itemCounter >= 35)
    //     {
    //         RestartButton.SetActive(true);
    //     }
    //     else{
    //         RestartButton.SetActive(false);
    //     }
    // }        
}