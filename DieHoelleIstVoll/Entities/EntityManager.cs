using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class EntityManager<T> where T : Entity
    {
        List<T> entities;
        List<T> newEntities;

        public List<T> Entities
        {
            get { return entities; }
        }

        public EntityManager()
        {
            entities = new List<T>();
            newEntities = new List<T>();
        }

        public void Update(float dt)
        {
            //Neue hinzufügen
            foreach (T e in newEntities)
            {
                entities.Add(e);
            }
            newEntities.Clear();

            //Alle durchlaufen
            foreach (T e in entities)
            {
                e.Update(dt);
            }

            //Erst danach unnötige (rückwärts) entfernen
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                if (entities[i].IsDestroying)
                    entities.RemoveAt(i);
            }
        }

        public void Draw()
        {
            foreach (T e in entities)
            {
                if (!e.IsDestroying)
                    e.Draw();
            }
        }

        public void Add(T e)
        {
            newEntities.Add(e);
        }

        public void Clear()
        {
            entities.Clear();
            newEntities.Clear();
        }
    }
}
