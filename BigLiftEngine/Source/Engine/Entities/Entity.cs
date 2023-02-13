using BigLiftEngine.Source.Engine.Components;
using BigLiftEngine.Source.Engine.Utilities;
using System.Collections.Generic;


namespace BigLiftEngine.Source.Engine.Entities
{
    public class Entity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Component> Components { get; set; }

        public Entity(string name)
        {
            ID = GenerateUniqueID.GetUniqueID();
            Name = name;
        }

        public void AddComponent(Component component)
        {
            if (Components == null)
            {
                Components = new List<Component>();
            }

            Components.Add(component);
        }

        public void SendMessageToAllComponents(int message)
        {
            foreach(Component component in Components)
            {
                component.ReceiveMessage(message);
            }
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in Components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            return null;
        }
    }
}
