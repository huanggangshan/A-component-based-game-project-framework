using System;
using System.Collections.Generic;
using System.Reflection;

namespace Model
{

    public class TypeInfo
    {
        public Type Type;
        public object[] Attrs;
    }
    
    public class Basesystem
    {
        private readonly Dictionary<Type, List<TypeInfo>> typeInfos = new Dictionary<Type, List<TypeInfo>>();
        
        public Basesystem() 
        {
            Assembly assembly = Assembly.Load("XXXXXXXXX");  //项目程序集名称

            Type[] assemblyTypes = assembly.GetTypes();
            
            foreach (Type assemblyType in assemblyTypes)
            {
                var attrs = assemblyType.GetCustomAttributes(true);
                
                foreach (Attribute attribute in attrs)
                {
                    var attrType = attribute.GetType();
                    if (!typeInfos.TryGetValue(attrType, out List<TypeInfo> infos))
                    {
                        infos = new List<TypeInfo>(); 
                        typeInfos.Add(attrType, infos);
                    }
                    
                    infos.Add(new TypeInfo {Type = assemblyType, Attrs = attrs});
                    
                }
                
            }
        }

        static void Main(string[] args)
        {
            Basesystem system = new Basesystem();
        }
    }
}