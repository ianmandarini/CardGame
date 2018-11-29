using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Obs
{
  List<Action> listOfFunctionsSubscribed = new List<Action>();
  // Calls all subscribed functions to this observed object.
  public void trigger()
  {
    foreach(Action func in this.listOfFunctionsSubscribed)
    {
      func();
    }
  }
  // Adds the passed function to the "subscribed functions" list (listOfFunctionsSubscribed).
  // This makes it ready to be called when this observed object is triggered.
  public void subscribe(Action func)
  {
    this.listOfFunctionsSubscribed.Add(func);
  }

}

public class Obs<T>
{
  List<Action<T>> listOfFunctionsSubscribed = new List<Action<T>>();

  // Calls all subscribed functions to this observed object, passing "value" as a parameter
  public void trigger(T value)
  {
    foreach(Action<T> func in this.listOfFunctionsSubscribed)
    {
      func(value);
    }
  }
  // Adds the passed function to the "subscribed functions" list (listOfFunctionsSubscribed).
  // This makes it ready to be called when this observed object is triggered.
  public void subscribe(Action<T> func)
  {
    this.listOfFunctionsSubscribed.Add(func);
  }

}
