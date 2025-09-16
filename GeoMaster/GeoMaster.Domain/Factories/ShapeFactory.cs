using System;
using System.Collections.Generic;
using GeoMaster.Application.Interfaces;

namespace GeoMaster.Domain.Factories
{
    public class Shape2DFactory
    {
        private readonly Dictionary<string, Func<object[], ICalculos2D>> _creators = new();

        public void Register(string key, Func<object[], ICalculos2D> creator)
        {
            _creators[key.ToLower()] = creator;
        }

        public ICalculos2D Create(string key, params object[] args)
        {
            if (_creators.TryGetValue(key.ToLower(), out var creator))
                return creator(args);
            throw new ArgumentException($"Forma 2D '{key}' não registrada.");
        }
    }

    public class Shape3DFactory
    {
        private readonly Dictionary<string, Func<object[], ICalculos3D>> _creators = new();

        public void Register(string key, Func<object[], ICalculos3D> creator)
        {
            _creators[key.ToLower()] = creator;
        }

        public ICalculos3D Create(string key, params object[] args)
        {
            if (_creators.TryGetValue(key.ToLower(), out var creator))
                return creator(args);
            throw new ArgumentException($"Forma 3D '{key}' não registrada.");
        }
    }
}
