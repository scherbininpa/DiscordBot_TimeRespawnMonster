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
        /// Время появления монстра в локации
        /// </summary>
        public TimeSpan AppearanceTime { get; }

        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        public string PathImage { get; }
    }
}
