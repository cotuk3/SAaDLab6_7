using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAaDLab4_5.DAL.Data.IRepository;
public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(); // отримання всіх об'єктів
    T GetOne(int id); // отримання одного об'єкта за id
    void Create(T item); // створення об'єкта
    void Update(T item); // оновлення об'єкта
    void Delete(int id); // видалення об'єкта за id
}
