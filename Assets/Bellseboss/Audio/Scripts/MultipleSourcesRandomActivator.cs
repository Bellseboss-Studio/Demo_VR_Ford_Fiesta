using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MultipleSourcesRandomActivator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> m_ObjectsToActivate;
        [SerializeField] private float m_MinDelay;
        [SerializeField] private float m_MaxDelay;
        private int m_ObjectsIndex;
        private int m_NumberOfItemsInList;
        private float m_Delay;
        private float m_DelayBetweenIterations;
        
        private void Awake()
        {
            foreach (Transform childObject in transform)
            {
                m_ObjectsToActivate.Add(childObject.gameObject);
            }
        }

        private void Start()
        {
            m_NumberOfItemsInList = m_ObjectsToActivate.Count;
            StartCoroutine(ActivateSingleObject());
        }

        private IEnumerator ActivateSingleObject()
        {
            m_ObjectsIndex = Random.Range(0, m_NumberOfItemsInList);
            m_Delay = Random.Range(m_MinDelay, m_MaxDelay);
            yield return new WaitForSeconds(m_Delay);
            if (!m_ObjectsToActivate[m_ObjectsIndex].activeInHierarchy)
            {
                m_ObjectsToActivate[m_ObjectsIndex].SetActive(true);
            }
            else
            {
                int newIndex = Random.Range(0, m_NumberOfItemsInList);
                m_ObjectsToActivate[newIndex].SetActive(true);
            }

            StartCoroutine(ActivateSingleObject());
        }

    }
