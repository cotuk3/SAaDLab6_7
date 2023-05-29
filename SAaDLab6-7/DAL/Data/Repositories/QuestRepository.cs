using SAaDLab4_5.DAL.Data;
using SAaDLab4_5.DAL.Data.IRepository;
using SAaDLab4_5.DAL.Models;
using SAaDLab4_5.DAL.Data.EF;

namespace SAaDLab4_5.DAL.Data.Repositories;
public class QuestRepository : IRepository<Quest>
{
    private QuestRoomDbContext _context;

    public QuestRepository(QuestRoomDbContext context)
    {
        _context = context;
    }

    public Quest Quest
    {
        get => default;
        set
        {
        }
    }

    #region IRepository
    public void Create(Quest quest)
    {
        _context.Quests.Add(quest);
    }

    public void Delete(int id)
    {
        Quest quest = _context.Quests.Find(id);

        if (quest != null)
            _context.Quests.Remove(quest);
    }

    public IEnumerable<Quest> GetAll()
    {
        return _context.Quests;
    }

    public Quest GetOne(int id)
    {
        return _context.Quests.Find(id);
    }

    public void Update(Quest item)
    {
        _context.Update(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }
    #endregion
}
