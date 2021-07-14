using EstContact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstContact.Services
{
    public class StudentsService
    {
        /// <summary>
        /// Отправка сообщений
        /// </summary>
        /// <param name="student">Студент - отправитель</param>
        /// <param name="students">Список студентов</param>
        /// <returns>Список номеров студентов (отправитель - получатель)</returns>
        public List<string> SendMessage(Student student, List<Student> students)
        {
            List<string> response = new List<string>();
            int messageCount = 0;
            foreach (var st in students)
            {
                if (student.Id == st.Id || st.NotificationIsReceived)
                    continue;

                if (messageCount == student.MessageCount)
                    break;

                response.Add($"{student.Id} - {st.Id}");
                st.NotificationIsReceived = true;
                messageCount++;
            }
            return response;
        }
    }
}
