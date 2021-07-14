using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstContact.Models
{
    /// <summary>
    /// Студент
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Номер студента
        /// </summary>
       
        public int Id { get; set; }
        /// <summary>
        /// Количество сообщений, который может отправить студент
        /// </summary>
        public int MessageCount { get; set; }
        
        /// <summary>
        /// Сообщение получено
        /// </summary>
        public bool NotificationIsReceived { get; set; }

    }
}
