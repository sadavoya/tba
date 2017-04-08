using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

namespace Utility
{
    public sealed class Useful
    {
        public static IEnumerable<T> findAllObjectsWithComponentsOfType<T>()
            where T : class
        {
            List<T> result = new List<T>();

            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (var go in allObjects)
            {
                //Debug.Log(string.Format("Type: {0}", go.GetType()));
                result.AddRange(go.GetComponents<T>());
            }
            return result;
        }

        public static Vector2[] getBoundingRectangle(Vector3 pos, Renderer rend)
        {
            var ext = rend.bounds.extents;

            var result = new Vector2[4];
            var mults = new int[] { -1, 1 };

            int i = 0;
            foreach (var xmult in mults)
            {
                foreach (var ymult in mults)
                {
                    result[i] = new Vector2(pos.x + xmult * ext.x, pos.y + ymult * ext.y);
                    i++;
                }
            }

            return result;
        }

        internal static void RestartCurrentLevel()
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

    }

    public interface IAction
    {
        void DoAction();
    }
    public abstract class Action : MonoBehaviour, IAction
    {
        public abstract void DoAction();
    }
}
