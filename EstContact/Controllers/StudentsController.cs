using EstContact.Models;
using EstContact.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstContact.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        public StudentsService _studentsService;
        public StudentsController(StudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public bool NotificationsIsReceived { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("{sudentsCount}/{messageCountById}")]
        public IActionResult Post(int sudentsCount, string messageCountById)
        {
            var messageCountArray = messageCountById.Trim().Split(' ');
            List<Student> students = new List<Student>();
            List<string> response = new List<string>();

            //Создаем сущности студентов
            for (int i = 0; i < messageCountArray.Length; i++)
            {
                var student = new Student
                {
                    Id = i + 1,
                    MessageCount = Convert.ToInt32(messageCountArray[i])
                };

                //Это Поликарп
                if (student.Id == 1)
                    student.NotificationIsReceived = true;

                students.Add(student);
            }

            //Отправка сообщений, начиная с Поликарпа
            foreach (var student in students)
            {
                var result = _studentsService.SendMessage(student, students);
                response.AddRange(result);

                NotificationsIsReceived = students.All(x => x.NotificationIsReceived);

                //Если все получили сообщение, останавливаем отправку
                if (NotificationsIsReceived)
                    break;
            }

            if (!NotificationsIsReceived)
            {
                return Json("-1");
            }
            else
            {
                return Json(new Tuple<int, List<string>>(response.Count, response));
            }

        }
    }
}
