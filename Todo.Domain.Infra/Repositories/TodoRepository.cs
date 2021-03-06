﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositorios;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {

        private readonly DataContext _dataContext;

        public TodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(TodoItem todo)
        {
            _dataContext.Add(todo);
            _dataContext.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _dataContext.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _dataContext.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _dataContext.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _dataContext.Todos
                .FirstOrDefault(TodoQueries.GetById(id, user));
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _dataContext.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetByPeriodo(user, date, done))
                .OrderBy(x => x.Date);
        }

        public void Update(TodoItem todo)
        {
            _dataContext.Entry(todo).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}
