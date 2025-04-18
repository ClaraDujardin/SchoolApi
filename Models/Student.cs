namespace SchoolApi.Models;
public class Student
{ 
    public int Id { get; set; }
    public Class Class { get; set; } = null!; //sois on mets required ou on lui donne une valeur Null par defaut
    public int ClassId { get; set; }

}



public class CreateStudentDTO()//les DTO sont reliés aux route ,c'est les models qui sont utilisés par la BD
{
    public required string NameStudent { get; set; }
    public required string Promo { get; set; }
    public required int Age { get; set; }
}