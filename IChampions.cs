using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public interface IChampions
    {
        /// <summary>
        /// Уникальны идентификатор
        /// </summary>
        public string ID { get; }
        /// <summary>
        /// Имя чемпиона
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Количество НР
        /// </summary>
        public int HitPoint { get; }
        /// <summary>
        /// Время респа
        /// </summary>
        public TimeSpan RespawnTime { get; }
       
        /// <summary>
        /// Время появления
        /// </summary>
        public TimeSpan AppearanceTime { get; }
        public string GetName();
        public string GetDescription();
        public string GetPathImage();

        public TimeSpan MinTimeRespawn();
        public TimeSpan MaxTimeRespawn();
    }
}
