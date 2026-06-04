namespace App05;

public interface IRepository<T>
{
    IEnumerable<T> List();
}