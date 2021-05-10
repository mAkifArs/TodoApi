using TodoApi.DATA.Entities;

namespace TodoApi.DATA.Repositories.IRepository
{
    public interface ITodoListRepository
    {
        public void AddTodoList(TodoList todoList);
    }
}