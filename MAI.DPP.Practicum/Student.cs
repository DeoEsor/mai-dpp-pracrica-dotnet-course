namespace MAI.DPP.Practicum;

    
public class Student : IEquatable<Student>
{

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName {get; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string MiddleName { get;  }
    
    /// <summary>
    /// 
    /// </summary>
    public string Group { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public string ZachetkaId { get;  }
    
    /// <summary>
    /// 
    /// </summary>
    public Course Course {get;}

    public Student(
        string firstName,
        string lastName, 
        string middleName,
        string group,
        string zachetkaId,
        Course course)
    {
        if (string.IsNullOrWhiteSpace(firstName) || 
            string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(middleName) || 
            string.IsNullOrWhiteSpace(group) ||
            string.IsNullOrWhiteSpace(zachetkaId))
        {
            throw new ArgumentNullException( "", "При создании студента произошла ошибка, одно из полей не проинициализировано");
        }
        
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Group = group;
        ZachetkaId = zachetkaId;
        Course = course;
    }

    public override string ToString()
    {
        return $"ФИО {LastName} {FirstName} {MiddleName} \t Группа {Group} \n\t Зачетка  {ZachetkaId} \n\t курс  {Course}";
    }
    
    public bool Equals(Student? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return FirstName == other.FirstName &&
               LastName == other.LastName &&
               MiddleName == other.MiddleName &&
               Group == other.Group &&
               ZachetkaId == other.ZachetkaId && 
               Course == other.Course;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Student)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, MiddleName, Group, ZachetkaId, (int)Course);
    }

    public static bool operator ==(Student? left, Student? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Student? left, Student? right)
    {
        return !Equals(left, right);
    }
}