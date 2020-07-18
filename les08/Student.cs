namespace les08
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public int group;
        public string departament;
        public string city;
        private int age;

        public Student(string firstName, string lastName, string university, string faculty, string departament, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.course = course;
            this.group = group;
            this.departament = departament;
            this.city = city;
            this.age = age;
        }
    }
}
