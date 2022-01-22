namespace Udemy.Cqrs.CQRS.Results
{
    public class CreateStudentCommandResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}