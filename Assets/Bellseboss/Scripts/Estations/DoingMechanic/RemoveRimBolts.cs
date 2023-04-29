using System;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRimBolts : MonoBehaviour{

    public Action onRemoveTheFirstBolt, onRemoveAllBolt;
    [SerializeField] private GameObject boltPrefab;
    [SerializeField] private Transform[] listOfPositionToBolts;

    private List<GameObject> boltsIntantiate;
    private bool isFinishedTheFirstBolt;
    private int countOfBolts;

    private void Awake() {
        boltsIntantiate = new List<GameObject>();
    }

    public void Configurate(){
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR("Configurate tire!");
        foreach(var bolt in boltsIntantiate){
            Destroy(bolt);
        }
        boltsIntantiate = new List<GameObject>();
        foreach(var position in listOfPositionToBolts){
            var bolt = Instantiate(boltPrefab, position);
            bolt.transform.localScale = Vector3.one;
            bolt.GetComponent<Tornillo>().onFinishedRemove += ()=>{
                if(!isFinishedTheFirstBolt){
                    onRemoveTheFirstBolt?.Invoke();
                    isFinishedTheFirstBolt = true;
                }
                countOfBolts++;
                if(countOfBolts >= listOfPositionToBolts.Length){
                    onRemoveAllBolt?.Invoke();
                }
            };
            boltsIntantiate.Add(bolt);
        }
    }
}
