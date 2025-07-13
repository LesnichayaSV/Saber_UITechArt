/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using System;
using System.Linq;
using UnityEngine.SceneManagement;

namespace UnityEngine.UI.Extensions.Examples.FancyScrollView
{
    [RequireComponent(typeof(Dropdown))]
    class ScenesDropdown : MonoBehaviour
    {
        readonly string[] scenes =
        {
            "1024x768",
            "1280x720",
            "1920x1080"           
        };

        void Start()
        {
            var dropdown = GetComponent<Dropdown>();
            dropdown.AddOptions(scenes.Select(x => new Dropdown.OptionData(x)).ToList());
            dropdown.value = Mathf.Max(0, Array.IndexOf(scenes, SceneManager.GetActiveScene().name));
            dropdown.onValueChanged.AddListener(value =>
                SceneManager.LoadScene(scenes[value], LoadSceneMode.Single));
        }
    }
}
