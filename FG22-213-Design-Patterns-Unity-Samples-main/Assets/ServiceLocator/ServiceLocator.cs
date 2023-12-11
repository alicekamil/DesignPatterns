
using System;
using System.Collections.Generic;

namespace ServiceLocator
{

    public class AdvancedServiceLocator
    {
        private Dictionary<Type, object> _services;
        
        public T GetService<T>()
        {
            throw new NotImplementedException();
        }

        public void ConfigureService<T>(object asInstance)
        {
            
        }
        
        
        public void ConfigureService<TAbstractType, TImplType>(bool lazy)
        {
            
        }
    }
    
    public static class ServiceLocator
    {
        public static ISkyboxService GetSkyboxService()
        {
            ISkyboxService overrideService = UnityEngine.Object.FindObjectOfType<OverrideSkyboxService>();
            return overrideService ?? new DefaultSkyboxService();
        }
    }
}