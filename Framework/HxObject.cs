﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Hx001.Framework
{
    public class HxObject
    {
        private readonly List<HxComponent> _components = new List<HxComponent>();

        public void Attach(HxComponent component)
        {
            this._components.Add(component);
        }

        public T Get<T>() where T : HxComponent
        {
            foreach (HxComponent component in this._components)
            {
                if (component is T obj)
                    return obj;
            }
            return default (T);
        }

        public void Detach(HxComponent component)
        {
            this._components.Remove(component);
        }
    }
}