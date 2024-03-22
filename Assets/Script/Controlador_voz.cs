using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class ControladorPorVoz : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> wordToAction;

    // Start is called before the first frame update
    void Start()
    {
        // Diccionario de acciones
        wordToAction = new Dictionary<string, Action>();
        wordToAction.Add("arriba", Avanza);
        wordToAction.Add("abajo", Retrocede);
        wordToAction.Add("izquierda", Izquierda);
        wordToAction.Add("derecha", Derecha);
        wordToAction.Add("salta", Salta);
        wordToAction.Add("azul", Azul);
        wordToAction.Add("rojo", Rojo);
        wordToAction.Add("verde", Verde);

        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += WordRecognized;
        keywordRecognizer.Start();
    }

    private void WordRecognized(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text);
        wordToAction[word.text].Invoke();
    }

    private void Avanza()
    {
        transform.Translate(Vector3.forward * 1.0f); 
    }

    private void Retrocede()
    {
        transform.Translate(Vector3.back * 1.0f); 
    }

    private void Izquierda()
    {
        transform.Translate(Vector3.left * 1.0f); 
    }

    private void Derecha()
    {
        transform.Translate(Vector3.right * 1.0f);
    }

    private void Salta()
    {
        Vector3 newPosition = transform.position + Vector3.forward * 1.0f + Vector3.up * 1.0f; // Salto hacia adelante
        transform.position = newPosition;
    }

    private void Azul()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    private void Rojo()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    private void Verde()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }
}