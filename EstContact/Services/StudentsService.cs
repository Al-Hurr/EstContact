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
            foreach (var st in students)
            {
                if (student.Id == st.Id || st.NotificationIsReceived)
                    continue;

                if (student.MessageCount == 0)
                    break;

                response.Add($"{student.Id} {student.NotificationIsReceived} - {st.Id}");
                st.NotificationIsReceived = true;
                student.MessageCount--;
            }
            return response;
        }
    }
}
