using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class EntityManager
    {
        List<Entity> entities;
        List<Entity> newEntities;

        public EntityManager()
        {
            entities = new List<Entity>();
            newEntities = new List<Entity>();
        }

        public void Update(GameTime gameTime)
        {
            //Neue hinzufügen
            foreach (Entity e in newEntities)
            {
                entities.Add(e);
            }
            newEntities.Clear();

            //Alle durchlaufen
            foreach (Entity e in entities)
            {
                e.Update(gameTime);
            }

            //Erst danach unnötige (rückwärts) entfernen
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                if (entities[i].IsDestroying)
                    entities.RemoveAt(i);
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Entity e in entities)
            {
                if (!e.IsDestroying)
                    e.Draw(gameTime);
            }
        }

        public void Add(Entity e)
        {
            e.EntityManager = this;
            newEntities.Add(e);
        }

        public void Clear()
        {
            entities.Clear();
            newEntities.Clear();
        }
    }
}
