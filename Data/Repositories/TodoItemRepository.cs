using CompanyName.PetShop.RestApi.Data;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Data
{
    public class TodoItemRepository : IRepository<TodoItem>
    {
        private readonly PetAppContext db;

        public TodoItemRepository(PetAppContext context)
        {
            db = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return db.TodoItems.ToList();
        }

        public TodoItem Get(int id)
        {
            return db.TodoItems.FirstOrDefault(b => b.Id == id);
        }

        public void Add(TodoItem entity)
        {
            db.TodoItems.Add(entity);
            db.SaveChanges();
        }

        public void Edit(TodoItem entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            var item = db.TodoItems.FirstOrDefault(b => b.Id == id);
            db.TodoItems.Remove(item);
            db.SaveChanges();
        }
    }
}
