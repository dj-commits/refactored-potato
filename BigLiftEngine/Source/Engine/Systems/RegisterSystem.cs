using BigLiftEngine.Source.Engine.Components;
using BigLiftEngine.Source.Engine.Entities;
using System.Collections.Generic;


namespace BigLiftEngine.Source.Engine.Systems
{
    public static class RegisterSystem
    {
        public static Dictionary<int, List<Component>> entityComponents = new Dictionary<int, List<Component>>();
        public static Dictionary<int, Entity> registeredEntities = new Dictionary<int, Entity>();
        

        public static void RegisterComponent(int entityID, Component component)
        {
            if (entityComponents == null)
            {
                entityComponents = new Dictionary<int, List<Component>>();
            }
            if (entityComponents.ContainsKey(entityID))
            {
                entityComponents[entityID].Add(component);
            }
            else
            {
                entityComponents.Add(entityID, new List<Component>());
                entityComponents[entityID].Add(component);
            }

        }

        public static void RegisterEntity(int entityID, Entity entity)
        {
            if (!registeredEntities.ContainsKey(entityID))
            {
                registeredEntities.Add(entityID, entity);
            }

        }

        public static void DeregisterComponent(int entityID, Component component)
        {
            if (entityComponents.ContainsKey(entityID))
            {
                if (entityComponents[entityID].Contains(component))
                {
                    entityComponents[entityID].Remove(component);
                }
            }

        }

        public static void DeregisterEntity(int entityID, Entity entity)
        {
            if (registeredEntities.ContainsKey(entityID))
            {
                registeredEntities.Remove(entityID);
            }
            if (entityComponents.ContainsKey(entityID))
            {
                entityComponents.Remove(entityID);
            }

        }


        public static List<T> GetComponents<T>() where T : Component
        {
            if (entityComponents == null)
            {
                entityComponents = new Dictionary<int, List<Component>>();
            }
            List<T> components = new List<T>();
            foreach (List<Component> listOfComponents in entityComponents.Values)
            {
                foreach (Component component in listOfComponents)
                {
                    if (component.GetType().Equals(typeof(T)))
                    {
                        components.Add((T)component);
                    }
                }

            }
            return components;

        }

    }
}
