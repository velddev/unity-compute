using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Compute.Extensions
{
    public static class GameObjectExtensions
    {
        public static List<T> FindGameObjectFromChildrenWithType<T>(this GameObject gameobject) where T : Component
        {
            List<T> outputList = new List<T>();

            for(int i = 0; i < gameobject.transform.childCount; i++)
            {
                T o = gameobject.transform.GetChild(i).GetComponent<T>();
                if(o as T != null)
                {
                    outputList.Add(o as T);
                }
            }

            return (outputList.Count == 0) ? null : outputList;
        }
    }
}
