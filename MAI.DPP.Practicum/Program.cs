using System.Text.Json.Serialization;

namespace MAI.DPP.Practicum;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string firstName = "John";
            string lastName = "Полежайкин";
            string middleName = "Евгеньевич";
            string group = "М8О-115-23";
            string zachetkaId = Guid.NewGuid().ToString();
            Course course = Course.First;
        
            var student = new Student(
                firstName,
                lastName,
                middleName,
                group,
                zachetkaId,
                course
            );
            
            var student2 =  new Student(
                firstName,
                lastName,
                middleName,
                group,
                zachetkaId,
                course
            );
        
            Console.WriteLine(student);
            
            Console.WriteLine(student2 == student);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("Неудачная работа программы: " + e.Message);
        }
    }
}