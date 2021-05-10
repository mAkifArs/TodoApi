using TodoApi.DATA.Entities;
using TodoApi.DATA.Repositories.IRepository;

namespace TodoApi.DATA.Repositories.Repository
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly TodoApiDataContext _todoApiDataContext;

        public TodoListRepository(TodoApiDataContext todoApiContext)
        {
            _todoApiDataContext = todoApiContext;
        }

        public void AddTodoList(TodoList todoList)
        {
            _todoApiDataContext.TodoLists.Add(todoList);
            _todoApiDataContext.SaveChanges();
        }
    }
}