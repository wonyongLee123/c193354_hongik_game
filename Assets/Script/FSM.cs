using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    RULE
    1. ONLY ONE INSTANCE EXIST 
    2. *EVERY* constructor (also copy) *DOES NOT EXIST IN PUBLIC*
    // from https://stackoverflow.com/questions/32628192/create-a-singleton-class-in-java-using-public-constructor
    // it based on RULE 1, 
    The reason it has to be a private constructor is because you want to prevent people from using it freely to create more than one instance.
    A public constructor is possible only if you are able to detect an instance already exist and forbid a another instance being created.
*/

public class FSM<T>
{   
    private T owner;
    private State<T> currentState;

    public FSM(T owner)
    {
        this.owner = owner;
    }


    public void ChangeState(State<T> state){
        if(state == null) return;        
        if(currentState != null) currentState.Exit(owner);
        currentState = state;
        currentState.Enter(owner);
    }
    public void Update()
    {
        if (currentState == null) return;
        currentState.Execute(owner);     
    }

    public State<T> CurrentState
    {
        get { return currentState; }
    }
}
