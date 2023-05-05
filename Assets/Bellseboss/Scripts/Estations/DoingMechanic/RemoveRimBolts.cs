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
        foreach(var bolt in boltsIntantiate){
            Destroy(bolt);
        }
        boltsIntantiate = new List<GameObject>();
        foreach(var position in listOfPositionToBolts){
            var bolt = Instantiate(boltPrefab, position);
            bolt.transform.localScale = Vector3.one;
            bolt.GetComponent<Tornillo>().onFinishedRemove += ()=>{
                if(!isFinishedTheFirstBolt){
                    //ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Removed the first bolt");
                    onRemoveTheFirstBolt?.Invoke();
                    isFinishedTheFirstBolt = true;
                }
                countOfBolts++;
                //ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"{countOfBolts} {listOfPositionToBolts.Length}");
                if(countOfBolts >= listOfPositionToBolts.Length){
                    ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Removed all bolt");
                    onRemoveAllBolt?.Invoke();
                }
            };
            boltsIntantiate.Add(bolt);
        }
    }
}
